using Models.Entities;
using Models.Requests;


namespace Models.Mappers.Base.Interfaces
{
    public interface IPersonMapper : IBaseMapper<PersonRequest, PessoaEntity>
    {
    }
}
