namespace LHPetsCadastro
{
    /// <summary>
    /// Representa o endereço de uma Pessoa Física ou Jurídica cadastrada
    /// na plataforma de gestão de clínicas veterinárias da Balti.
    /// </summary>
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public TipoEndereco Tipo { get; set; }

        public Endereco(string logradouro, string cidade, TipoEndereco tipo)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{Logradouro}, {Cidade} ({Tipo})";
        }
    }
}
