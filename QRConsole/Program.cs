using DataMatrix.net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace QRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"c:\users\taylan\desktop\MgzSozlesme1.pdf";
            
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(filePath);

            if (f.PageCount > 0)
            {
                //Set image properties: Jpeg, 200 dpi

                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

                f.ImageOptions.Dpi = 200;

                //Save all PDF pages as page1.jpg, page2.jpg ... pageN.jpg

                //f.ToImage(@"c:\users\taylan\desktop\test2.jpg", 1);

                var image = f.ToDrawingImage(1);

                Bitmap bMap = new Bitmap(image);

                IBarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(bMap);

                DmtxImageDecoder decoder = new DmtxImageDecoder();

                List<string> oList = decoder.DecodeImage(bMap);

                int count = oList.Count;
            }


            
        }
    }
}
