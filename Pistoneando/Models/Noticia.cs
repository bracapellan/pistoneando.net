using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pistoneando.Models
{
    [Table("Noticia")]
    public class Noticia
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Categoria")]
        public int       CategoriaID { get; set; }
        [Required]
        public string Titulo { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime  FechaPublicacion { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImagenPortada { get; set; }
        [MaxLength(170, ErrorMessage="Máximo 170 caracteres."), MinLength(50, ErrorMessage="Mínimo 50 caracteres.")]
        public string    DescripcionCorta { get; set; }
        public string    DescripcionLarga { get; set; }
        [Required]
        public string Contenido { get; set; }
        public virtual Categoria Categoria {get; set;}
    }

        [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Noticia> Noticia {get; set;}
    }

}
