using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Bussiness.Abstract;
using NetCoreWebApi.DataAccess.Concrete;
using NetCoreWebApi.DataAccess.Entities;
using NetCoreWebApi.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebApi.Bussiness.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mp;

        public CategoryRepository(ApplicationDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
        {
            var obj = _mp.Map<CategoryDTO, Category>(categoryDTO);
            obj.Created= DateTime.Now;
            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();
            return _mp.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(i=>i.Id==id);
            if (obj!=null)
            {
                _db.Categories.Remove(obj);
                await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
           var obj = await _db.Categories.FirstOrDefaultAsync(i=>i.Id == id);
            if (obj!=null)
            {
                return _mp.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GettAll()
        {
            return _mp.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(i => i.Id == categoryDTO.Id);
            if (obj!=null)
            {
                obj.Name = categoryDTO.Name;
                _db.Categories.Update(obj);
                await _db.SaveChangesAsync();
                return _mp.Map<Category,CategoryDTO>(obj);
            }
            return categoryDTO;
        }
    }
}
