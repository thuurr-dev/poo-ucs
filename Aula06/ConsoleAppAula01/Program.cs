using ConsoleAppAula01;

internal class Program
{
    private static void Main(string[] args)
    {
        Moto minhaMoto = new Moto();
        minhaMoto.CC = 150;
        minhaMoto.Placa = "AAAA222";
        minhaMoto.Modelo = "CG";
        minhaMoto.Marca = "Honda";
        Console.WriteLine(minhaMoto.Descricao());

        Veiculo veiculoTeste = new Moto();
        (veiculoTeste as Moto).CC = 150;
        veiculoTeste.Placa = "AAAA222";
        veiculoTeste.Modelo = "CG";
        veiculoTeste.Marca = "Honda";
        Console.WriteLine((veiculoTeste as Moto).CC); //cast

        //dessa maneira nao funciona pois nao esta instaciado - gera erro
        // Veiculo veiculoTeste = new Moto();
        // (veiculoTeste as Moto).CC = 150;
        // veiculoTeste.Placa = "AAAA222";
        // veiculoTeste.Modelo = "CG";
        // veiculoTeste.Marca = "Honda";
        // Console.WriteLine((veiculoTeste as Caminhao).CC); //cast

        Veiculo meuCaminhao = new Caminhao();
        (meuCaminhao as Caminhao).PesoTotalParaTransporte = 150;
        meuCaminhao.Placa = "AAAA222";
        meuCaminhao.Modelo = "CG";
        meuCaminhao.Marca = "Honda";
        Console.WriteLine((meuCaminhao as Caminhao).PesoTotalParaTransporte); //cast

        Gerente g = new Gerente();
        g.VeiculoDoFuncionario = new Carro();

        Motorista m = new Motorista();
        m.VeiculoDoFuncionario = new Caminhao();

        OfficeBoy boy = new OfficeBoy();
        boy.VeiculoDoFuncionario = new Moto();
    }
}