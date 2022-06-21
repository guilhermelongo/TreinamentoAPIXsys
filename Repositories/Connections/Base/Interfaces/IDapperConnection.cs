using System.Data;

namespace Repositories.Connections.Base.Interfaces
{
    public interface IDapperConnection : IDbConnection
    {
        public IDbConnection DapperConnection { get; set; }
    }
}
