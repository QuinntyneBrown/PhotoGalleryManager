using System.Collections.Generic;

namespace PhotoGalleryManager.Utils
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);

        List<ILoggerProvider> GetProviders();
    }
}
