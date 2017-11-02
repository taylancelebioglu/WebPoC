namespace QRreader.Models
{
    public partial class ImageFile
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string BarcodeFormat { get; set; }
        public string BarcodeText { get; set; }
    }
}