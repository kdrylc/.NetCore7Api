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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mp;

        public ProductRepository(ApplicationDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            var obj = _mp.Map<ProductDTO, Product>(productDTO);
            var addedobj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();
            return _mp.Map<Product, ProductDTO>(addedobj.Entity);
        }

        public async Task<int> DeleteById(int id)
        {
           var obj =await _db.Products.FirstOrDefaultAsync(i=>i.Id == id);
            if (obj!=null)
            {
                _db.Products.Remove(obj);
                await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mp.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(i=>i.Id == id);
            if (obj!=null)
            {
                return _mp.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<List<ProductDTO>> GetProductByCategoryId(int id)
        {
            var result = await _db.Products.Where(i=>i.CategoryId == id).ToListAsync(); 
            var objprod = _mp.Map<List<Product>, List<ProductDTO>>(result);
            if (objprod.Count > 0)
            {
                return objprod;
            }
            return new List<ProductDTO>();
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
           var objfromdb=await _db.Products.FirstOrDefaultAsync(i=>i.Id==productDTO.Id);
            if (objfromdb!=null)
            {
                objfromdb.Name = productDTO.Name;
                objfromdb.Summary = productDTO.Summary;
                objfromdb.Detail = productDTO.Detail;
                objfromdb.Created = DateTime.Now;
                objfromdb.ImageUrl = productDTO.ImageUrl;
                objfromdb.CategoryId= productDTO.CategoryId;
                await _db.SaveChangesAsync();
                return _mp.Map<Product,ProductDTO>(objfromdb);        
            }
            return productDTO;
        }
    }
}
