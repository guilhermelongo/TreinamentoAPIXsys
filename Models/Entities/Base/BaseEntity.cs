using Dapper;
using Models.Entities.Base.Interfaces;
using System;

namespace Models.Entities.Base

//Minha classe Base

{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [IgnoreUpdate]
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Deletado { get; set; }


        public BaseEntity AsCreated()
        {
            DataCriacao = DateTime.Now;
            DataAtualizacao = null;
            Deletado = false;
            return this;
        }
        public BaseEntity AsUpdated()
        {
            DataAtualizacao = DateTime.Now;
            return this;
        }

        

        public BaseEntity AsDeleted()
        {
            Deletado = false;
            return this;
        }

    }
}
