using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Requests
{
    public class PersonRequest
    {
        public int? Id { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
