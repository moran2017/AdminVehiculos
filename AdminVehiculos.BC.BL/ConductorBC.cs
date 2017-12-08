using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminVehiculos.DL.DataModel;

namespace AdminVehiculos.BC.BL
{
    public class ConductorBC
    {

        public List<Conductor> ConductorListar()
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Conductor.ToList();
            // SELECT * FROM Personaje
        }

        public List<Conductor> ConductorListar(String Filtro)
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Conductor
                .Where(X => X.DNI.Contains(Filtro))
                .ToList();
            // SELECT * FROM Personaje 
            // WHERE Nombre LIKE '%' + @Nombre + '%'
        }

        public void ConductorRegistrar(Conductor objConductor)
        {
            UPCEntities1 context = new UPCEntities1();
            context.Conductor.Add(objConductor);
            context.SaveChanges();
            // INSERT INTO Personaje (@Nombre, ... )
        }

        public void ConductorEditar(Conductor objConductor)
        {
            UPCEntities1 context = new UPCEntities1();
            Conductor objConductorOri = context.Conductor
                .FirstOrDefault(X =>
               X.ConductorId == objConductor.ConductorId);
            objConductorOri.DNI = objConductor.DNI;
            objConductorOri.Nombre = objConductor.Nombre;
            objConductorOri.Apellido = objConductor.Apellido;
            objConductorOri.Tipo = objConductor.Tipo;
            
            context.SaveChanges();
            // UPDATE Personaje SET Nombre = @Nombre, ...
            // WHERE PersonajeId = @PersonajeId
        }

        public Conductor ConductorObtener(int ConductorId)
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Conductor
                .FirstOrDefault(X =>
                X.ConductorId == ConductorId);
            // SELECT * FROM Personaje 
            // WHERE PersonajeId = @PersonajeId
            // PCSIJART@UPC.EDU.PE
        }

        public void ConductorEliminar(int ConductorId)
        {
            UPCEntities1 context = new UPCEntities1();
            Conductor objConductor = context.Conductor
                .FirstOrDefault(X =>
                X.ConductorId == ConductorId);
            context.Conductor.Remove(objConductor);
            context.SaveChanges();
            // DELETE FROM Personaje
            // WHERE PersonajeId = @PersonajeId
        }
      
    }
}
