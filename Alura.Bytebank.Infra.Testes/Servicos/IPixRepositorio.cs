using Alura.Bytebank.Infra.Testes.Servicos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Bytebank.Infra.Testes.Servicos
{
    public interface IPixRepositorio
    {
     
        
            public PixDTO consultaPix(Guid pix);
       
    }
}
