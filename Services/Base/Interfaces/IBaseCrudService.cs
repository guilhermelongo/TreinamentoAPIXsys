
using Models;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base.Interfaces
{
    public interface IBaseCrudService<Request>
    {
        public Task<int?>CreateAsync(Request request);
        public Task<int?> BookInsert(List<Request> requests);

        public Task<int>UpdateAsync(Request request);

        public Task<PessoaEntity>GetByIdAsync(int id);

        public Task<IEnumerable<PessoaEntity>> GetListAsync();

        public Task<IEnumerable<ComboItem>> ComboItem();

        public Task<int>DeleteAsync(int id);
     
    }
}
