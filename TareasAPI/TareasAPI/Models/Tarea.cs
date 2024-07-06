using System;
using System.Collections.Generic;

namespace TareasAPI.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int precio { get; set; }

    public string? categoria { get; set; }
  

    public string imagen { get; set; }


}
