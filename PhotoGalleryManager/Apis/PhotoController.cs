using PhotoGalleryManager.Data;
using PhotoGalleryManager.Dtos;
using PhotoGalleryManager.Models;
using PhotoGalleryManager.Services;
using PhotoGalleryManager.UploadHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PhotoGalleryManager.Apis
{
    [Authorize]
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        public PhotoController(IPhotoService photoService, IUow uow)
        {
            _photoService = photoService;
            _uow = uow;
            _photoRespository = uow.Photos;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(PhotoAddOrUpdateResponseDto))]
        public IHttpActionResult Add(PhotoAddOrUpdateRequestDto dto) { return Ok(_photoService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(PhotoAddOrUpdateResponseDto))]
        public IHttpActionResult Update(PhotoAddOrUpdateRequestDto dto) { return Ok(_photoService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<PhotoDto>))]
        public IHttpActionResult Get() { return Ok(_photoService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult GetById(int id) { return Ok(_photoService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_photoService.Remove(id)); }

        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(HttpRequestMessage request)
        {
            var photos = new List<Photo>();
            try
            {
                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                NameValueCollection formData = provider.FormData;
                IList<HttpContent> files = provider.Files;

                foreach (var file in files)
                {
                    var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
                        .Replace("&", "and")).Name;
                    Stream stream = await file.ReadAsStreamAsync();
                    var bytes = StreamHelper.ReadToEnd(stream);
                    var photo = new Photo();
                    photo.FileName = filename;
                    photo.Bytes = bytes;
                    photo.ContentType = System.Convert.ToString(file.Headers.ContentType);
                    _photoRespository.Add(photo);
                    photos.Add(photo);
                }

                _uow.SaveChanges();
            }
            catch (Exception exception)
            {
                var e = exception;
            }

            return Request.CreateResponse(HttpStatusCode.OK, new PhotoUploadResponseDto(photos));
        }
        protected readonly IPhotoService _photoService;
        protected readonly IRepository<Photo> _photoRespository;
        protected readonly IUow _uow;


    }
}
