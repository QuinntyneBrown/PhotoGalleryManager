using PhotoGalleryManager.Dtos;
using System.Collections.Generic;

namespace PhotoGalleryManager.Services
{
    public interface IPhotoService
    {
        PhotoAddOrUpdateResponseDto AddOrUpdate(PhotoAddOrUpdateRequestDto request);
        ICollection<PhotoDto> Get();
        PhotoDto GetById(int id);
        dynamic Remove(int id);
    }
}
