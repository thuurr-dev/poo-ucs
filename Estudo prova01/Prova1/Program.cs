using static Prova1.Ficha;

internal class Program
{
    static void Main(string[] args)
    {
        PessoaFisica pessoaFisica = new PessoaFisica();
        pessoaFisica.SetNome("Arthur");
        pessoaFisica.cpf = "123.456.789-00";

        Console.WriteLine("Nome: " + pessoaFisica.GetNome());
        Console.WriteLine("CPF: " + pessoaFisica.cpf);
    }
}