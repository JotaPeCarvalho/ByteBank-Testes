using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infra.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoComBDMySQL()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar a base de dados");
            }

            //Assert
            Assert.True(conectado);
        }
    }
}
