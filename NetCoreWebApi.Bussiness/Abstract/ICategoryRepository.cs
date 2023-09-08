using NetCoreWebApi.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebApi.Bussiness.Abstract
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDTO>> GettAll();
        public Task<CategoryDTO> Create(CategoryDTO categoryDTO);   
        public Task<CategoryDTO> Update(CategoryDTO categoryDTO);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> Get(int id);
    }
}
