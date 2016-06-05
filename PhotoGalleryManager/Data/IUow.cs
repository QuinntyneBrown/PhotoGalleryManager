namespace PhotoGalleryManager.Data
{
    public interface IUow
    {
        IRepository<Models.Gallery> Galleries { get; }
        IRepository<Models.Photo> Photos { get; }

        void SaveChanges();
    }
}
