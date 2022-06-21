using Dapper;
using Models;
using Models.Entities;
using Models.Entities.Base;
using Repositories.Base.Interfaces;
using Repositories.Connections.Base.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Base
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        IDapperConnection _connection;
        public BaseRepository(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<int?> InsertAsync(Entity entity)
        {
            entity.AsCreated();
            return await _connection.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(Entity entity)
        {
            entity.AsUpdated();
            return await _connection.UpdateAsync(entity);

        }

        public async Task<Entity> GetByIdAsync(int id)
        {

            return await _connection.GetAsync<Entity>(id);

        }

        public async Task<int> DeleteAsync(int id)
        {

            return await _connection.DeleteAsync<Entity>(id);
        }

        public async Task<IEnumerable<PessoaEntity>> GetListAsync() 
        {
            return await _connection.GetListAsync<PessoaEntity>();

        
        
        }

        public Task<IEnumerable<ComboItem>> ComboItemAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
