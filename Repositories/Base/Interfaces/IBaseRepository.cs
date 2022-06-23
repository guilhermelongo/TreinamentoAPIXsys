using Models;
using Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Base.Interfaces
{
    public interface IBaseRepository<Entity>
    {
        public Task<int?>InsertAsync(Entity entity);

        public Task<int?> BookInsert(List<Entity> entity);

        public Task<int>UpdateAsync(Entity entity);

        public Task<Entity>GetByIdAsync(int id);

        public Task<IEnumerable<PessoaEntity>> GetListAsync();

       public Task<IEnumerable<ComboItem>>ComboItemAsync();

        public Task<int>DeleteAsync(int id);
    }
}
