using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Bytebank.Infra.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }


        [Fact]
        public void TestaObterClientes()
        {
            

            //Act 
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }

        [Fact]
        public void TestarObterClientePorId()
        {
            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert 
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void TestarObterClientesPorVariosId(int id)
        {
            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert 
            Assert.NotNull(cliente);
        }

     

    }
}
