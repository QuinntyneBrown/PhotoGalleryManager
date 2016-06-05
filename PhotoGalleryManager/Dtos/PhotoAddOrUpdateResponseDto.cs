namespace PhotoGalleryManager.Dtos
{
    public class PhotoAddOrUpdateResponseDto: PhotoDto
    {
        public PhotoAddOrUpdateResponseDto(PhotoGalleryManager.Models.Photo entity)
            :base(entity)
        {

        }
    }
}
