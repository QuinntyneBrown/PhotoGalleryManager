using System;
using System.Collections.Generic;

namespace PhotoGalleryManager.Models
{
    public class Gallery
    {
        public Gallery()
        {
            GalleryPhotos = new HashSet<GalleryPhoto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GalleryPhoto> GalleryPhotos { get; set; }
        public bool IsDeleted { get; set; }
    }
}
