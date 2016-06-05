using PhotoGalleryManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhotoGalleryManager.Dtos
{
    public class PhotoUploadResponseDto
    {
        public PhotoUploadResponseDto(List<Photo> photos)
        {
            this.Photos = photos.Select(x => new PhotoDto(x)).ToList();
        }

        public ICollection<PhotoDto> Photos { get; set; }
    }
}
