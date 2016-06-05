using System;
using System.Collections.Generic;

namespace PhotoGalleryManager.Models
{
    public class Photo
    {
        public Photo()
        {
            GalleryPhotos = new HashSet<GalleryPhoto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FileFullName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? FileModified { get; set; }
        public long Size { get; set; }
        public string RelativePath { get { return $"api/photo/serve?uniqueid={UniqueId}"; } }
        public Byte[] Bytes { get; set; } = new byte[0];
        public Guid? UniqueId { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public ICollection<GalleryPhoto> GalleryPhotos { get; set; }
        public bool IsDeleted { get; set; }
    }
}
