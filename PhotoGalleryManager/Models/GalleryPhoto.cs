namespace PhotoGalleryManager.Models
{
    public class GalleryPhoto
    {
        public GalleryPhoto()
        {

        }

        public int Id { get; set; }
        public int? GalleryId { get; set; }
        public int? PhotoId { get; set; }
        public Gallery Gallery { get; set; }
        public Photo Photo { get; set; }
    }
}
