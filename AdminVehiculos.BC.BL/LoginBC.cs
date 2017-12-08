using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminVehiculos.DL.DataModel;

namespace AdminVehiculos.BC.BL
{
    public class LoginBC
    {
        public Login LoginValidar(string Codigo, String Password)
        {

            UPCEntities1 context = new UPCEntities1();

           return context.Login.FirstOrDefault(x => x.Codigo == Codigo && x.Password == Password);
           
        }
    }
}
