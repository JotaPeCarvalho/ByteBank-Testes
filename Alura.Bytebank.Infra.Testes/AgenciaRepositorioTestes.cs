using Alura.Bytebank.Infra.Testes.Servicos;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.Bytebank.Infra.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;
        public ITestOutputHelper SaidaConsoleTeste { get; set; }

        public AgenciaRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor executado com sucesso");

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();
            
        }



        [Fact]
        public void TestaCriarUmaAgencia()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agencia Central Coast City",
                Identificador = Guid.NewGuid(),
                Id = 3,
                Endereco = "Rua das Flores, 25",
                Numero = 1477
            };
            //Act
            var adicionada = _repositorio.Adicionar(agencia);

            //Assert
            Assert.True(adicionada);
        }

        [Fact]
        public void TestaRemoverDeterminadaAgencia()
        {
            //Arrange
            //Act
            var atualizado = _repositorio.Excluir(3);

            //Assert
            Assert.True(atualizado);

        }

        [Fact]
        public void TestaExcecaoConsultaAgenciaPorId()
        {
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => _repositorio.ObterPorId(33)
                );
        }

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = new Guid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }

        [Fact]
        public void TestaObterAgenciaMock()
        {
            //Arrange
            var repositorioMock = new Mock<IByteBankRepositorio>();
            var mock = repositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            repositorioMock.Verify(b => b.BuscarAgencias());
        }


    }
}
