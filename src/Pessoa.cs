using System;

namespace LHPetsCadastro
{
    /// <summary>
    /// Classe base abstrata para os clientes (tutores de animais e empresas)
    /// cadastrados na plataforma de gestão de clínicas veterinárias da Balti.
    /// </summary>
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public bool PagaImposto { get; set; }

        protected Pessoa(string nome, Endereco endereco, bool pagaImposto)
        {
            Nome = nome;
            Endereco = endereco;
            PagaImposto = pagaImposto;
        }

        public virtual void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Endereço: {Endereco}");
            Console.WriteLine($"Paga imposto: {(PagaImposto ? "Sim" : "Não")}");
        }
    }
}
