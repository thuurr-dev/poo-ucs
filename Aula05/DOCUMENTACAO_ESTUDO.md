# Documentação do Projeto - Aula 05: Sistema de Veículos e Funcionários

## 📚 Visão Geral
Este projeto é um exemplo prático de **Programação Orientada a Objetos (POO)** em C#. Ele demonstra conceitos fundamentais como **herança**, **polimorfismo**, **classes abstratas**, **genéricos** e **encapsulamento**.

---

## 🏗️ Estrutura de Classes

### 1. **Classe Abstrata `Veiculo`** (Base de tudo)
**Arquivo:** `Veiculo.cs`

```csharp
public abstract class Veiculo
```

#### O que é uma classe abstrata?
- Uma classe que **não pode ser instanciada diretamente**
- Serve como **template** (molde) para outras classes
- Define características e comportamentos que todas as subclasses devem ter

#### Características:
| Propriedade | Tipo | Descrição |
|---|---|---|
| `Placa` | String | Identifica o veículo (ex: "AAAA222") |
| `Marca` | String | Fabricante do veículo (ex: "Honda") |
| `Modelo` | String | Nome do modelo (ex: "CG") |
| `DescricaoDoVeiculo` | String | Descrição específica do veículo |

#### Métodos Importantes:
- **`MinhaDescricao()`** → Método **abstrato** (cada subclasse implementa do seu jeito)
- **`Descricao()`** → Método concreto que chama `MinhaDescricao()` e adiciona mais informações

#### Construtor padrão:
```csharp
public Veiculo()
{
    Placa = "Não Informada";
    Marca = "Não informada";
    Modelo = "Precisa definir";
}
```
Inicializa valores padrão para não deixar nada vazio.

---

### 2. **Classe `Moto`** (Herda de Veiculo)
**Arquivo:** `Moto.cs`

```csharp
public class Moto : Veiculo
```

#### O que significa `: Veiculo`?
- A classe `Moto` **herda** de `Veiculo`
- Uma moto **É UM** veiculo, então tem todas as propriedades da classe pai
- Em Java seria: `public class Moto extends Veiculo`

#### Propriedade Especial:
- **`CC`** (cilindradas) → Exclusive da Moto
  - Ex: 150 CC é uma moto "pequenininha"
  - Ex: 1000 CC é uma moto de potência

#### Implementação:
```csharp
public override string MinhaDescricao()
{
    return "Uma Moto";
}
```
- `override` = "eu vou fazer de um jeito diferente que minha classe pai"
- Cada tipo de veículo tem sua própria descrição

---

### 3. **Classe `Caminhao`** (Herda de Veiculo)
**Arquivo:** `Caminhao.cs`

Seguem o mesmo padrão da Moto, mas com:
- **`PesoTotalParaTransporte`** → Capacidade de carga em kg
- **`MinhaDescricao()`** retorna "Caminhão"

---

### 4. **Classe `Carro`** (Herda de Veiculo)
**Arquivo:** `Carro.cs`

Seguem o mesmo padrão, mas com:
- **`TotalPassageiros`** → Quantas pessoas cabem no carro
- **`MinhaDescricao()`** retorna "Carro de Passeio"

---

## 💼 Classes de Funcionários

### **Classe Genérica `Funcionario<TQualquerCoisa>`**
**Arquivo:** `Funcionario.cs`

#### O que são Genéricos `<T>`?
Genéricos permitem que uma classe trabalhe com **qualquer tipo**, mas com restrições:

```csharp
public class Funcionario<TQualquerCoisa> where TQualquerCoisa : Veiculo
```

#### Leitura em português:
- "Funcionário é genérico (pode ser qualquer coisa)"
- "MAS aquela coisa SÓ pode ser um Veiculo ou algo que herda de Veiculo"
- `where TQualquerCoisa : Veiculo` = **constraint (restrição)**

#### Por quê usar Genéricos?
```csharp
// SEM genéricos (ruim):
public class Funcionario
{
    public Veiculo VeiculoDoFuncionario {get;set;} // genérico demais
}

// COM genéricos (bom):
public class Funcionario<T> where T : Veiculo
{
    public T VeiculoDoFuncionario {get;set;} // tipo específico, mas flexível
}
```

#### Propriedades do Funcionário:
| Propriedade | Tipo | Descrição |
|---|---|---|
| `Nome` | String | Nome do funcionário |
| `SalarioBruto` | decimal | Salário antes de descontos |
| `SalarioLiquido` | decimal | Salário após descontos (read-only) |
| `Cargo` | CargoInfo | Informações do cargo |
| `VeiculoDoFuncionario` | T (genérico) | Veículo específico do funcionário |

#### Método de Cálculo de Salário:
```csharp
public decimal GerarSalarioLiquido()
{
    DescontarINSS();    // Desconto previdenciário
    DescontarIR();      // Desconto de Imposto de Renda
    ContribuirFGTS();   // Fundo de Garantia
    return SalarioLiquido;
}
```

---

### **Classe `Gerente`** (Herda de Funcionario)
**Arquivo:** `Gerente.cs`

```csharp
public class Gerente : Funcionario<Carro>
{
}
```

#### O que isso significa?
- Um `Gerente` **é um tipo especial** de `Funcionario`
- Um `Gerente` **sempre terá um `Carro`** como seu veículo
- O tipo genérico foi **"fixado"** como `Carro`

**Exemplo de uso:**
```csharp
Gerente g = new Gerente();
g.VeiculoDoFuncionario = new Carro(); // ✅ OK
// g.VeiculoDoFuncionario = new Moto(); // ❌ ERRO! Gerente deve ter Carro
```

---

### **Classe `Motorista`** (Herda de Funcionario)
**Arquivo:** `Motorista.cs`

```csharp
public class Motorista : Funcionario<Caminhao>
{
}
```

Um `Motorista` **sempre terá um `Caminhao`** como seu veículo de trabalho.

---

### **Classe `OfficeBoy`**
Segue o mesmo padrão, mas com `Moto`.

---

## 🎯 Hierarquia Completa em Diagrama

```
┌─────────────────────┐
│   Veiculo (abstrata)│
└──────────┬──────────┘
           │
    ┌──────┼──────┬──────┐
    │      │      │      │
┌───▼──┐ ┌─▼───┐ ┌─▼───┐┌─▼────┐
│ Moto │ │Carro│ │Camp. ││...  │
└───┬──┘ └─┬───┘ └─┬───┘└─┬────┘
    │      │      │      │
    │      │      │      │
    │   ┌──▼──────▼──────┤
    │   │ Funcionario<T> │
    │   └──┬──────────┬──┘
    │      │          │
┌───▼──┐   │      ┌───▼──────┐
│Office │  │      │ Gerente  │
│ Boy  │  │      │(Carro)  │
└──────┘  │      └──────────┘
          │
       ┌──▼─────────┐
       │ Motorista  │
       │(Caminhao) │
       └────────────┘
```

---

## 📖 Entendendo o `Program.cs`

### **Parte 1: Trabalhando com Moto diretamente**

```csharp
Moto minhaMoto = new Moto();
minhaMoto.CC = 150;
minhaMoto.Placa = "AAAA222";
minhaMoto.Modelo = "CG";
minhaMoto.Marca = "Honda";
Console.WriteLine(minhaMoto.Descricao());
```

**O que acontece:**
1. Cria uma nova Moto
2. Define as propriedades específicas
3. `minhaMoto.Descricao()` retorna: `"Uma Moto |  Marca: Honda Modelo CG e Placa AAAA222"`

---

### **Parte 2: Usando Polimorfismo com Cast**

```csharp
Veiculo veiculoTeste = new Moto();
(veiculoTeste as Moto).CC = 150;  // CAST
veiculoTeste.Placa = "AAAA222";
```

**O que é `as` (cast seguro)?**
- `as` = "trate isso como se fosse um ..."
- `(veiculoTeste as Moto)` = "use veiculoTeste como se fosse uma Moto"
- Se não conseguir fazer o cast, retorna `null` (não gera erro)

**Por que fazer isso?**
```csharp
Veiculo v = new Moto();
// v.CC = 150; ❌ Erro! Veiculo não tem CC
// (v as Moto).CC = 150; ✅ OK! Agora é tratada como Moto
```

---

### **Parte 3: Testando com Caminhão**

```csharp
Veiculo meuCaminhao = new Caminhao();
(meuCaminhao as Caminhao).PesoTotalParaTransporte = 150;
```

Mesmo conceito: uma variável `Veiculo` armazenando um `Caminhao`, mas com cast para acessar propriedades específicas.

---

### **Parte 4: Criando Funcionários**

```csharp
Gerente g = new Gerente();
g.VeiculoDoFuncionario = new Carro();

Motorista m = new Motorista();
m.VeiculoDoFuncionario = new Caminhao();

OfficeBoy boy = new OfficeBoy();
boy.VeiculoDoFuncionario = new Moto();
```

**O que acontece:**
1. Cria gerente, motorista e office boy
2. Cada um recebe seu veículo **específico**
3. Gerente automaticamente trabalha com Carro
4. Motorista automaticamente trabalha com Caminhao
5. OfficeBoy automaticamente trabalha com Moto

---

## 🔑 Conceitos-Chave de POO Usados

| Conceito | Explicação | Exemplo |
|----------|-----------|---------|
| **Herança** | Uma classe herda propriedades de outra | `Moto : Veiculo` |
| **Polimorfismo** | Mesmo método, comportamentos diferentes | `MinhaDescricao()` em cada classe |
| **Classe Abstrata** | Não pode instanciar, serve de template | `Veiculo` |
| **Método Abstrato** | Obriga subclasses a implementarem | `abstract MinhaDescricao()` |
| **Override** | Reimplementar método da classe pai | `override MinhaDescricao()` |
| **Genéricos** | Classe que trabalha com vários tipos | `Funcionario<T>` |
| **Constraint** | Limita o tipo genérico | `where T : Veiculo` |
| **Encapsulamento** | Controlar acesso às propriedades | `{ get; set; }` e `{ get; private set; }` |

---

## 💡 Dicas de Estudo

1. **Desenhando**: Faça diagramas UML das relações entre classes
2. **Instanciação**: Pratique criar objetos e acessar propriedades
3. **Polimorfismo**: Entenda por quê usar `Veiculo v = new Moto()`
4. **Genéricos**: Pense "que tipo preciso guardar aqui?"
5. **Casts**: Pratique converter tipos com `as`

---

## 📝 Pergunta para Auto-Avaliação

1. Por que `Veiculo` é abstrata?
2. Qual é a diferença entre `Moto`, `Carro` e `Caminhao`?
3. O que faz um `Gerente` ser diferente de um `Motorista`?
4. Por que usar genéricos em `Funcionario<T>`?
5. Quando você usaria `as` (cast)?

---

**Bora estudar e dominar POO!** 🚀
