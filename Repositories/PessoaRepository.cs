using Dapper;
using Models;
using Models.Entities;
using Repositories.Base;
using Repositories.Connections.Interfaces;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PessoaRepository : BaseRepository<PessoaEntity>, IPessoaRepository
    {
        private readonly IDbConnection _connection;

        public PessoaRepository(IEstagTestConnection connection) : base(connection)
        {
            _connection = connection;
        }
        //public async Task<bool> UpdateAsync(PessoaEntity entity)
        //{
        //    StringBuilder query = new StringBuilder();

        //    query.Append("UPDATE [dbo].[TB_PESSOA]");
        //    query.AppendLine(@$"
        //        SET NOME = '{entity.Nome}'

        //        WHERE ID = {entity.Id}

        //        ");

        //    IEnumerable<int> ids = await _connection.QueryAsync<int>(query.ToString());
        //    return true;
        //}

        //public async Task<PessoaEntity> GetByIdAsync(int id)
        //{
        //    StringBuilder query = new StringBuilder();

        //    query.Append($"SELECT * FROM [dbo].[TB_PESSOA] WHERE ID = {id}");

        //    IEnumerable<PessoaEntity> listPessoaEntity = new List<PessoaEntity>();
        //    listPessoaEntity = await _connection.QueryAsync<PessoaEntity>(query.ToString());

        //    return listPessoaEntity.FirstOrDefault();
        //}

        //public async Task<IEnumerable< PessoaEntity>> ListAsync()
        //{
        //    StringBuilder query = new StringBuilder();

        //    query.Append("SELECT * FROM [dbo].[TB_PESSOA]");

        //    IEnumerable<PessoaEntity> listaPessoaEntity = await _connection.QueryAsync<PessoaEntity>(query.ToString());

        //    return listaPessoaEntity.ToArray();
        //}



        public async Task<int?> BookInsert(List<PessoaEntity> pessoaEntities)
        {

            StringBuilder query = new StringBuilder();

            bool firsttime = true;

            query.Append(@"INSERT INTO [dbo].[TB_PESSOA]
                    (
                        [CPF],
                        [NOME],
                        [DataNascimento],
                        [Sexo]
                    )"
             );
            query.AppendLine($@"VALUES");
            foreach (PessoaEntity pessoa in pessoaEntities)
            {
                pessoa.AsCreated();
                query.AppendLine(firsttime ? string.Empty : ",");
                firsttime = false;

                query.AppendLine($"('{pessoa.Cpf}',");
                query.AppendLine($"'{pessoa.Nome}',");

                string birthDate = pessoa.DataNascimento?.ToString("yyyy-MM-dd");
                query.AppendLine(!string.IsNullOrWhiteSpace(birthDate) ? $"'{birthDate}'," : "NULL");
                query.AppendLine($"'{pessoa.Sexo}'");
                query.AppendLine($")");
            }
            IEnumerable<int> ids = await _connection.QueryAsync<int>(query.ToString());
            return ids.FirstOrDefault();

        }

        public async Task<IEnumerable<ComboItem>> ComboItemAsync()
        {
            StringBuilder query = new StringBuilder();

            query.Append("SELECT ID, NOME AS Text FROM [dbo].[TB_PESSOA]");

            IEnumerable<ComboItem> comboItem = await _connection.QueryAsync<ComboItem>(query.ToString());

            return comboItem;
        }


    }


    //public async Task<bool> DeleteAsync(int id)
    //{
    //    StringBuilder query = new StringBuilder();

    //    query.Append($"DELETE FROM [dbo].[TB_PESSOA] WHERE ID = {id}");

    //    IEnumerable<bool> ids = await _connection.QueryAsync<bool>(query.ToString());
    //    return true;  
    //}
}

