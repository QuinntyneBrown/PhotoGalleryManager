using System;
using System.Collections.Generic;
using PhotoGalleryManager.Dtos;
using PhotoGalleryManager.Data;
using System.Linq;

namespace PhotoGalleryManager.Services
{
    public class GalleryService : IGalleryService
    {
        public GalleryService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Galleries;
            _cache = cacheProvider.GetCache();
        }

        public GalleryAddOrUpdateResponseDto AddOrUpdate(GalleryAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Gallery());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new GalleryAddOrUpdateResponseDto(entity);
        }

        public ICollection<GalleryDto> Get()
        {
            ICollection<GalleryDto> response = new HashSet<GalleryDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new GalleryDto(entity)); }
            return response;
        }

        public GalleryDto GetById(int id)
        {
            return new GalleryDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Gallery> _repository;
        protected readonly ICache _cache;
    }
}
