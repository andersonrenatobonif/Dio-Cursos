using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstudoMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O Campo descrição é Obrigatório")]


        public string Descricao { get; set; }

       // public List<Produto> Produtos { get; set; }
    }
}
