namespace BancoKRT.Models
{
    public class Cliente
    {
        public string Documento { get; set; } // CPF
        public string Agencia { get; set; } 
        public string Conta { get; set; }
        public decimal LimitePIX { get; set; }
    }
}
