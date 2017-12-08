using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminVehiculos.DL.DataModel;


namespace AdminVehiculos.BC.BL
{
    public class MarcaBCcs
    {
        public List<Marca> MarcaListar()
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Marca.ToList();
            // SELECT * FROM Personaje
        }

        public List<Marca> MarcaListar(String Filtro)
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Marca
                .Where(X => X.Acronimo.Contains(Filtro))
                .ToList();
            // SELECT * FROM Personaje 
            // WHERE Nombre LIKE '%' + @Nombre + '%'
        }

        public void MarcaRegistrar(Marca objMarca)
        {
            UPCEntities1 context = new UPCEntities1();
            context.Marca.Add(objMarca);
            context.SaveChanges();
            // INSERT INTO Personaje (@Nombre, ... )
        }

        public void MarcaEditar(Marca objMarca)
        {
            UPCEntities1 context = new UPCEntities1();
            Marca objMarcaOri = context.Marca
                .FirstOrDefault(X =>
                X.MarcaId == objMarca.MarcaId);
            objMarcaOri.Acronimo = objMarca.Acronimo;
            objMarcaOri.Descripcion = objMarca.Descripcion;
           
            context.SaveChanges();
            // UPDATE Personaje SET Nombre = @Nombre, ...
            // WHERE PersonajeId = @PersonajeId
        }

        public Marca MarcaObtener(int MarcaId)
        {
            UPCEntities1 context = new UPCEntities1();
            return context.Marca
                .FirstOrDefault(X =>
                X.MarcaId == MarcaId);
            // SELECT * FROM Personaje 
            // WHERE PersonajeId = @PersonajeId
            // PCSIJART@UPC.EDU.PE
        }

        public void MarcaEliminar(int MarcaId)
        {
            UPCEntities1 context = new UPCEntities1();
            Marca objMarca = context.Marca
                .FirstOrDefault(X =>
                X.MarcaId == MarcaId);
            context.Marca.Remove(objMarca);
            context.SaveChanges();
            // DELETE FROM Personaje
            // WHERE PersonajeId = @PersonajeId
        }
      
    }
}
