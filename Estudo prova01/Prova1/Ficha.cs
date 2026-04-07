using System;

namespace Prova1;

public class Ficha
{
    private static double INVESTIMENTO = 20; //valor do investimento para cada ficha (mesmo valor para todos)
    private required String nome {{ get; set; }}
    private required String cpf { get; set; }
    private required String email { get; set; }
    private String? telefone { get; set; }
    private String? endereco { get; set; }

    //private -> define que o atributo é privado, e só pode ser manipulad por métodos da própria class
    //static -> define que o atributo é de classe
    //double -> tipo do atributo, define que o valor armazenado é um número decimal
    //INVESTIMENTO : Os nomes de constantes sempre são representados em letras maiúsculas

    private Boolean foiPago; //Boolean -> tipo do atributo, define que o valor armazenado é verdadeiro ou falso

    //getters e setters -> métodos para acessar e modificar os atributos privados da classe
    //getters -> métodos para acessar os atributos privados da classe (ler dados)
    //setters -> métodos para modificar os atributos privados da classe (alterar dados)

    public String getNome() //getter
    {
        return nome;
    }

    public void setNome(String nome) //setter
    {
        this.nome = nome;
    }

    //para simplicar os getter e setter , eles sao usados assim:
    //public String Nome { get; set; }

    //Se apenas o get ou o set for necessário como publico isso pode ser feito definindo o acesso na propriedade.
    //public String Nome { get; private set; } // Somente leitura (getter público, setter privado)

/////////////////////////////////////////////////////////////////////////
    
    //metodos:
    //estrutura:
    //<modificador><tipo de retorno><nome do método>(<lista de parâmetros>) {
    //    //corpo do método
    //}

    //modificador -> define o nível de acesso do método (public, private, protected, default)
    //tipo de retorno -> define o tipo de dado que o método retorna (void, int, string, etc...)
    //nome do método -> define o nome do método, deve ser um identificador válido
    //lista de parâmetros -> define os parâmetros que o método recebe, separados por vírgula (tipo nome, tipo nome, ...)
    //corpo do método -> define as instruções que o método executa, entre chaves {}

    //Exemplo de método:
    public int soma(int a, int b)
    {
        int resultado = a + b;
        return resultado;
    }

/////////////////////////////////////////////////////////////////////////

    //construtores -> métodos especiais que não possuem tipo de retorno e que tem o mesmo nome da classe. Sua função é inicializar os atributos do objeto
    //no momento de sua criação. Uma classe pode ter mais de um construtor, o que muda é sua lista de parâmetros

    //exemplo de construtor:
    public Ficha(String nome, String cpf, String email)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.email = email;
    }

    //construtor padrão -> sempre que uma classe não tiver um construtor definido, o compilador cria um construtor padrão, que é um construtor sem parâmetros e 
    //que não inicializa os atributos do objeto. Se a classe tiver um construtor definido, o construtor padrão não é criado automaticamente, e se for necessário, 
    //deve ser definido explicitamente.

    //exemplo de construtor padrão:
    public Ficha()
    {
        //construtor padrão, sem parâmetros
    }

/////////////////////////////////////////////////////////////////////////

    //instanciação: é o processo de criar um objeto a partir de uma classe. Para instanciar um objeto, é necessário usar a palavra-chave 
    //"new" seguida do nome da classe e dos parâmetros do construtor, se necessário.

    //exemplo de instanciação:
    //Ficha ficha1 = new Ficha("Arthur", "12345678900", "arthur@email.com");

//////////////////////////////////////////////////////////////////////////

    //chamada de metodos: para chamar um método de um objeto, é necessário usar o nome do objeto seguido do operador "." e do nome do método,
    //seguido dos parâmetros do método, se necessário.

    //exemplo de chamada de método:
    //int resultado = ficha1.soma(10, 20);
    //ficha1.setNome("Arthur Bernardo");

//////////////////////////////////////////////////////////////////////////

    //herança: permite que classes compartilhem atributos e metodos atravas de "heranças"
    //exemplo de herança:
    public class Pessoa
    {
        private String nome
        
        public String GetNome() { 
            return nome; 
        }

        public void SetNome(String novoNome) { 
            nome = novoNome; 
        }
    }

    public class PessoaJuridica : Pessoa //pessoa juridica herda os atributos e métodos da classe pessoa
    {
        public String cnpj { get; set; }
    }

    //SuperClasse: A classe Pessoa nesse exemplo é a superclasse, pois é a classe que é herdada por outra classe.
    //A classe Pessoa sera a superclasse da classe PessoaFisica, pois a classe PessoaFisica herda os atributos e métodos da classe Pessoa.

    //SubClasse: A classe PessoaFisica nesse exemplo é a subclasse, pois é a classe que herda os atributos e métodos de outra classe.
    //A classe PessoaFisica sera a subclasse da classe Pessoa, pois a classe PessoaFisica herda os atributos e métodos da classe Pessoa.

    PessoaJuridica pessoaJuridica = new PessoaJuridica();
    pessoaJuridica.nome = "Arthur";
    pessoaJuridica.cnpj = "12.345.678/0001-00";

    //herança de herança: não ha limite para as heranças, pode-se herdar de uma classe que já herda de outra classe, formando uma hierarquia de classes.
    //exemplo de herança de herança:
    public class Industria : PessoaJuridica //a classe Industria herda os atributos e métodos da classe PessoaJuridica, que por sua vez herda os atributos 
    // e métodos da classe Pessoa
    {
        public String ramo { get; set; }
    }

/////////////////////////////////////////////////////////////////////////

    //classes abstratas: são classes que não podem ser instanciadas -> abstract
    //exemplo de classe abstrata:
    public abstract class Pessoa
    {
        private String nome;

        public String GetNome() { 
            return nome; 
        }

        public Pessoa()
        {
            
        }
    }

//////////////////////////////////////////////////////////////////////////

    //sobrescrita de métodos: se uma subclasse possui um metodo com o mesmo nome e tipo de parametros da superclasse, o metodo que sera chamado é o seu e não o herdado
    //exemplo de sobrescrita de métodos:

    public class Pessoa
    {
        public virtual String Nome { get; set; } //virtual -> define que o método pode ser sobrescrito por uma subclasse (override)
    }
    public class Industria : PessoaJuridica
    {
        public override String Nome
        {
            get { return base.Nome; }
            set { base.Nome = "Industria: " + value; }
        }

        public String RamoAtividade { get; set; }
    } 

    //override -> serve para sinalizar que um metodo esta substituindo o comportamento de seu ancestral
    //base -> sempre que precisamos invocar um metodo ancestral chamamos base()

    //pesquisar sobre ToString()!!!!!!!

//////////////////////////////////////////////////////////////////////////

    //sobrecarga de metodos: um metodo pode assumir formas diferentes das quais foram implementadas inicialmente e agir de modo diferente quando
    //invocado de forma diferente por outra classe 
    //exemplo de sobrecarga de métodos:
    public class Calculadora
    {
        public int Soma(int a, int b)
        {
            return a + b;
        }

        public double Soma(double a, double b)
        {
            return a + b;
        }

        public int Soma(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    //mesmos metodos, mas com lista de parametros diferentes
    //não ha limite para o numero de metodos sobrecarregados em uma classe

//////////////////////////////////////////////////////////////////////////

    //passagem de objetos por parametros -> um objeto pode possuir outro objeto dentro de si
    //maneira de definir e acessar o objeto aninhados é atraves de metodos

    Uniforme uniforme = new Uniforme();
    uniforme.setCamiseta(3);
    uniforme.setCalcao(1);
    uniforme.setMeiao(2);

    Time time1 = new Time();
    time1.setUniforme(uniforme);
    time1.setNome("Time 1");
}   