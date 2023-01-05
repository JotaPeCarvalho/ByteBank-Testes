using Alura.ByteBank.Dados.Contexto;

namespace Alura.Bytebank.Infra.Testes;

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