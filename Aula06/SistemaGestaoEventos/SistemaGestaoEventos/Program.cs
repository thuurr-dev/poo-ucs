using System.Security.Cryptography.X509Certificates;
using SistemaGestaoEventos;
using System.Collections.Generic;

internal class Program
{
    private static Local CadastrarLocal()
    {
        Console.WriteLine("Informe o nome do local: ");
        var nomeLocal = Console.ReadLine();
        Console.WriteLine("Informe o endereco do local: ");
        var enderecoLocal = Console.ReadLine();
        Console.WriteLine("Informe a capacidade");
        var capacidade = Console.ReadLine();
        Local local = new Local();
        local.Nome = nomeLocal;
        local.Endereco = enderecoLocal;
        local.Capacidade = int.Parse(capacidade);
        return local;
    }

    private static Palestrante CadastrarPalestrante()
    {
        Console.WriteLine("Informe o nome: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Informe o telefone: ");
        var telefone = Console.ReadLine();
        System.Console.WriteLine("Informe o email: ");
        var email = Console.ReadLine();
        System.Console.WriteLine("Informe o Valor Hora em R$: ");
        var valorHora = Console.ReadLine();
        
        Palestrante palestrante = new Palestrante();
        palestrante.Id = Guid.NewGuid().ToString();
        palestrante.Nome = nome;
        palestrante.Email = email;
        palestrante.Telefone = telefone;
        palestrante.ValorHora = decimal.Parse(valorHora);

        return palestrante;
    }

    public static Evento CadastrarEvento()
    {
        Console.WriteLine("Informe a data de inicio (Formato DD/MM/YYYY)");
        var inicio = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Informe a data de fim (Formato DD/MM/YYYY)");
        var fim = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Escolha um local informando o número dele");
        
        for(int i = 0; i < todosLocais.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {todosLocais[i].ObterDescricao()}");
        }
        int localEscolhido = int.Parse(Console.ReadLine());

        var novoEvento = new Evento();

        novoEvento.Id = Guid.NewGuid().ToString();
        novoEvento.Inicio = inicio;
        novoEvento.Fim = fim;
        novoEvento.Local = todosLocais[localEscolhido - 1]; //porque iniciou do 1 

        return novoEvento;
    }

    static void Listar<TipoDoObjeto>(List<TipoDoObjeto> meuVetor) where TipoDoObjeto : EntidadeComId
    {
        for(int i = 0; i < meuVetor.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {meuVetor[i].ObterDescricao()}");
        }
    }

    static List<Participante> todosParticipantes = new List<Participante>();
    static List<Palestrante> todosPalestrantes = new List<Palestrante>();
    static List<Local> todosLocais = new List<Local>();
    static List<Evento> todosEventos = new List<Evento>();

    private static void DeletarPalestrante()
    {
        if (todosPalestrantes.Count == 0)
        {
            Console.WriteLine("Nenhum palestrante cadastrado.");
            return;
        }
        Console.WriteLine("Escolha o palestrante para deletar:");
        Listar<Palestrante>(todosPalestrantes);
        Console.Write("Digite o número: ");
        if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 1 && numero <= todosPalestrantes.Count)
        {
            todosPalestrantes.RemoveAt(numero - 1);
            Console.WriteLine("Palestrante deletado com sucesso.");
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }
    }

    private static void EditarPalestrante()
    {
        if (todosPalestrantes.Count == 0)
        {
            Console.WriteLine("Nenhum palestrante cadastrado.");
            return;
        }
        Console.WriteLine("Escolha o palestrante para editar:");
        Listar<Palestrante>(todosPalestrantes);
        Console.Write("Digite o número: ");
        if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 1 && numero <= todosPalestrantes.Count)
        {
            var palestrante = todosPalestrantes[numero - 1];
            Console.WriteLine("Deixe em branco para manter o valor atual.");
            Console.Write($"Nome ({palestrante.Nome}): ");
            string nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome)) palestrante.Nome = nome;
            Console.Write($"Telefone ({palestrante.Telefone}): ");
            string telefone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefone)) palestrante.Telefone = telefone;
            Console.Write($"Email ({palestrante.Email}): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) palestrante.Email = email;
            Console.Write($"Valor Hora ({palestrante.ValorHora}): ");
            string valor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(valor) && decimal.TryParse(valor, out decimal v)) palestrante.ValorHora = v;
            Console.WriteLine("Palestrante editado com sucesso.");
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }
    }

    private static void Main(string[] args)
    {
        Evento evento;
        Palestra palestra;

        Console.WriteLine("Sistema de Gestão de Eventos");
        int opcao = 0;
        do
        {
            Console.WriteLine("10 - Cadastrar Local");
            Console.WriteLine("20 - Cadastrar Participante");
            Console.WriteLine("30 - Cadastrar Palestrante");
            Console.WriteLine("31 - Listar todos os Palestrantes");
            Console.WriteLine("32 - Editar Palestrante");
            Console.WriteLine("33 - Deletar Palestrante");
            Console.WriteLine("40 - Cadastrar Evento");
            Console.WriteLine("99 - Sair do sistema");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 10)
            {
                var localNovo = CadastrarLocal();
                todosLocais.Add(localNovo);
            }
            else if (opcao == 30)
            {
                //Pede para o usuario as informacoes e gera o objeto Palestrante
                var novoPalestrante = CadastrarPalestrante();
                todosPalestrantes.Add(novoPalestrante);
            }
            else if (opcao == 31)
            {
                Listar<Palestrante>(todosPalestrantes);
            }
            else if (opcao == 32)
            {
                EditarPalestrante();
            }
            else if (opcao == 33)
            {
                DeletarPalestrante();
            }
            else if (opcao == 40)
            {
                todosEventos.Add(CadastrarEvento());
            }

        }while(opcao != 99);
    }
}