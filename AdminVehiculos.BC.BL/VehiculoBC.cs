using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminVehiculos.DL.DataModel;

namespace AdminVehiculos.BC.BL
{
   public class VehiculoBC
    {
        public List<Vehiculos> VehiculoListar()
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Vehiculos.ToList();
            // SELECT * FROM Personaje
        }

        public List<Vehiculos> VehiculoListar(String Filtro)
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Vehiculos
                .Where(X => X.Placa.Contains(Filtro))
                .ToList();
            // SELECT * FROM Personaje 
            // WHERE Nombre LIKE '%' + @Nombre + '%'
        }

        public void VehiculoRegistrar(Vehiculos objVehiculo)
        {
            UPCEntities1 context = new UPCEntities1();
            context.Vehiculos.Add(objVehiculo);
            context.SaveChanges();
            // INSERT INTO Personaje (@Nombre, ... )
        }

        public void VehiculoEditar(Vehiculos objVehiculo)
        {
            UPCEntities1 context = new UPCEntities1();
            Vehiculos objVehiculoOri = context.Vehiculos
                .FirstOrDefault(X =>
                X.VehiculoId == objVehiculo.VehiculoId);
            objVehiculoOri.Placa = objVehiculo.Placa;
            objVehiculoOri.kilometraje = objVehiculo.kilometraje;
            objVehiculoOri.MarcaId = objVehiculo.MarcaId;
            objVehiculoOri.ConductorId = objVehiculo.ConductorId;
            context.SaveChanges();
            // UPDATE Personaje SET Nombre = @Nombre, ...
            // WHERE PersonajeId = @PersonajeId
        }

        public Vehiculos VehiculoObtener(int VehiculoId)
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Vehiculos
                .FirstOrDefault(X =>
                X.VehiculoId == VehiculoId);
            // SELECT * FROM Personaje 
            // WHERE PersonajeId = @PersonajeId
            // PCSIJART@UPC.EDU.PE
        }

        public void VehiculoEliminar(int VehiculoId)
        {
            UPCEntities1 context = new UPCEntities1();
            Vehiculos objVehiculo = context.Vehiculos
                .FirstOrDefault(X =>
                X.VehiculoId == VehiculoId);
            context.Vehiculos.Remove(objVehiculo);
            context.SaveChanges();
            // DELETE FROM Personaje
            // WHERE PersonajeId = @PersonajeId
        }
      
    }
}
