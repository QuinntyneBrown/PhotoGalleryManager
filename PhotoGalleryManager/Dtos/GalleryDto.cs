namespace PhotoGalleryManager.Dtos
{
    public class GalleryDto
    {
        public GalleryDto()
        {

        }

        public GalleryDto(Models.Gallery entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
