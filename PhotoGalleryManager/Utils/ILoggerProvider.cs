namespace PhotoGalleryManager.Utils
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string name);
    }
}
