using QRreader.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;

namespace QRreader.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Display(ImageFile img)
        {
            return View(img);
        }
        [HttpPost]
        public ActionResult Create(ImageFile img, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = HttpContext.Server.MapPath("~/Images/") + file.FileName;
                    file.SaveAs(path);
                    img.ImagePath = path;
                }

                IBarcodeReader reader = new BarcodeReader();
                // load a bitmap
                var barcodeBitmap = (Bitmap)Bitmap.FromFile(img.ImagePath);
                // detect and decode the barcode inside the bitmap
                var result = reader.Decode(barcodeBitmap);
                // do something with the result
                if (result != null)
                {
                    img.BarcodeFormat = result.BarcodeFormat.ToString();
                    img.BarcodeText = result.Text;
                }
                return View("Display", img);

                //return RedirectToAction("Display", new { img = img });
            }
            return View("Display", img);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Upload");
        }
    }
}