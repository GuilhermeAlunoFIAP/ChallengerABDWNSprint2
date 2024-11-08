using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ABDWNSprint1.Models
{
    public class Clinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cnpj
        {
            get => _cnpj;
            set
            {
                if (!ValidarCnpj(value))
                    throw new ArgumentException("CNPJ inválido.");
                _cnpj = value;
            }
        }
        private string _cnpj;


        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        public string FotoClinica { get; set; }


        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public ICollection<Relatorio> Relatorios { get; set; }





        public static bool ValidarCnpj(string cnpj)
        {
            
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            
            if (cnpj.Length != 14)
                return false;

            

            return true; 
        }
    }
}
