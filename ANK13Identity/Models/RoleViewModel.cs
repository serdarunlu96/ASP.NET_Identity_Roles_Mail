using System.ComponentModel.DataAnnotations;

namespace ANK13Identity.Models
{
    public class RoleViewModel
    {
        [Key]  //Scaffold yapacağımız için sırf primary key olsun diye key yazdık.
      
        public string Name { get; set; }
    }
}
