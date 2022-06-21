
using Models;
using Models.Entities;
using Models.Mappers.Base.Interfaces;
using Models.Requests;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPersonMapper _personMapper;

        public PersonService(IPessoaRepository pessoaRepository, IPersonMapper personMapper)
        {
            _pessoaRepository = pessoaRepository;
            _personMapper = personMapper;
        }

        public async Task<int?>CreateAsync(PersonRequest request)
        {
            if(request.Name.Length >50)
            {
                throw new Exception("CAMPO NOME DE PESSOA NAO PODE SER MAIOR Q 50 CARACTERES.");
            }

            PessoaEntity entity = _personMapper.ToEntity(request);
            return await _pessoaRepository.InsertAsync(entity);
        }

        public async Task<int>UpdateAsync(PersonRequest request)
        {
            if (request.Name.Length >50)
            {
                throw new Exception("CANPO NOME DE PESSOA NAO PODE SER MAIOR Q 50 CARACTERES");
            }
            PessoaEntity entity = _personMapper.ToEntity(request);
            return await _pessoaRepository.UpdateAsync(entity);
        }

        public async Task<PessoaEntity> GetByIdAsync(int id)
        {
    
            return await _pessoaRepository.GetByIdAsync(id);
        }


        public async Task<int> DeleteAsync(int id)
        {
            return await _pessoaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PessoaEntity>> GetListAsync()
        {
            return await _pessoaRepository.GetListAsync();
        }

        //public async Task<IEnumerable<PessoaEntity>> ListAsync()
        //{
        //    return await _pessoaRepository.ListAsync();
        //}

        public async Task<IEnumerable<ComboItem>> ComboItem()
        {
           return await _pessoaRepository.ComboItemAsync();
        }

        //public async Task<bool>DeleteAsync(int id) {

        //    PessoaEntity entity = new PessoaEntity();
        //    entity.Id = id;
        //    return await _pessoaRepository.DeleteAsync(entity.Id);
        //}


    }
}
