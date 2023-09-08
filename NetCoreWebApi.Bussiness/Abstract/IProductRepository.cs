using NetCoreWebApi.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebApi.Bussiness.Abstract
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> GetById(int id);
        public Task<ProductDTO> Create(ProductDTO productDTO);
        public Task<ProductDTO> Update(ProductDTO productDTO);
        public Task<int> DeleteById(int id);
        public Task<List<ProductDTO>> GetProductByCategoryId(int id);
    }
}
