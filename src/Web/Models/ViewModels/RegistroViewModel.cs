using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModels
{
    public class RegistroViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite seu {0}")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite um email")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "A {0} deve conter no minímo {1} caractere")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a senha de confirmação não coincidem")]
        public string ConfirmarSenha { get; set; }

        [Display(Name = "Lembrar de mim?")]
        public bool LembrarDeMim { get; set; }
    }
}