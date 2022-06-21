using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;
using Models.Requests;
using Models.Responses.Base;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
/*São responsaveis pelas rotas 
 * 
 * A camada de controle é responsável por intermediar as requisições enviadas pelo View 
 * com as respostas fornecidas pelo Model, processando os dados que o usuário informou e
 * repassando para outras camadas. 

 */
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<GenericResponse<int?>> Create([FromBody] PersonRequest personRequest)
        {
            try
            {
                int? data = await _personService.CreateAsync(personRequest);
                return new GenericResponse<int?>(data).CreatedWithSucess();
            }
            catch (Exception exception)
            {
                return new GenericResponse<int?>().Error(HttpStatusCode.InternalServerError, exception.Message); ;
            }
        }

        [HttpPut]
        public async Task<GenericResponse<int>> Update([FromBody] PersonRequest personRequest)
        {
            try
            {
                int data = await _personService.UpdateAsync(personRequest);
                return new GenericResponse<int>(data).CreatedWithSucess();
            }
            catch (Exception exception)
            {
                return new GenericResponse<int>().Error(HttpStatusCode.InternalServerError, exception.Message); ;
            }
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<GenericResponse<PessoaEntity>> GetByIdAsync(int id)
        {
            try
            {
                PessoaEntity entity = await _personService.GetByIdAsync(id);
                return new GenericResponse<PessoaEntity>(entity).CreatedWithSucess();
            }
            catch (Exception exception)
            {
                return new GenericResponse<PessoaEntity>().Error(HttpStatusCode.InternalServerError, exception.Message); ;
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<GenericResponse<int>> DeleteAsync(int id)
        {
            try 
            {
             int enzo = await _personService.DeleteAsync(id);
                return new GenericResponse<int>().CreatedWithSucess();
            }
            catch(Exception exception)
            {
                return new GenericResponse<int>().Error(HttpStatusCode.InternalServerError, exception.Message);;
            }
        }

        [HttpGet]
        [Route("list")]
        public async Task<GenericResponse<IEnumerable<PessoaEntity>>> GetListAsync()
        {
            try
            {
                IEnumerable<PessoaEntity> entity = await _personService.GetListAsync();
                return new GenericResponse<IEnumerable<PessoaEntity>>(entity).CreatedWithSucess();
            }

            catch (Exception exception)
            {
                return new GenericResponse<IEnumerable<PessoaEntity>>().Error(HttpStatusCode.InternalServerError, exception.Message); ;
            }

        }
        [HttpGet]
        [Route("combo")]
        public async Task<GenericResponse<IEnumerable<ComboItem>>> ComboItemAsync()
        {
            try
            {
                IEnumerable<ComboItem> comboitem = await _personService.ComboItem();
                return new GenericResponse<IEnumerable<ComboItem>>(comboitem).CreatedWithSucess();
            }
            catch (Exception e)
            {
                return new GenericResponse<IEnumerable<ComboItem>>().Error(HttpStatusCode.InternalServerError, e.Message);
            }
        }












        //        [HttpGet]
        //        //[Route("List")]
        //        public async Task<GenericResponse<IEnumerable<PessoaEntity>>> ListAsync()
        //        {
        //            try
        //            {
        //                IEnumerable<PessoaEntity> entity = await _personService.ListAsync();
        //                return new GenericResponse<IEnumerable<PessoaEntity>>(entity).CreatedWithSucess();
        //            }
        //            catch (Exception e)
        //            {
        //                return new GenericResponse<IEnumerable<PessoaEntity>>().Error(HttpStatusCode.InternalServerError, e.Message);
        //            } 
        //        }

        //        [HttpGet]
        //        [Route("combo")]
        //        public async Task<GenericResponse<IEnumerable<ComboItem>>> ComboItemAsync()
        //        {
        //            try
        //            {
        //                IEnumerable<ComboItem> comboitem = await _personService.ComboItem();
        //                return new GenericResponse<IEnumerable<ComboItem>>(comboitem).CreatedWithSucess();
        //            }
        //            catch (Exception e)
        //            {
        //                return new GenericResponse<IEnumerable<ComboItem>>().Error(HttpStatusCode.InternalServerError, e.Message);
        //            }
        //        }

        //        [HttpDelete]
        //        [Route("{id}")]
        //        public async Task<GenericResponse<bool>>Delete(int id)
        //        {
        //            try
        //            {
        //                bool data = await _personService.DeleteAsync(id);
        //                return new GenericResponse<bool>().CreatedWithSucess();
        //            }
        //            catch (Exception e)
        //            {
        //                return new GenericResponse<bool>().Error(HttpStatusCode.InternalServerError, e.Message);
        //            }
        //        }
    }
}
