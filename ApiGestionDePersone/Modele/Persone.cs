using Microsoft.EntityFrameworkCore;

namespace ApiGestionDePersone.Modele;
using System.Linq;
using System.ComponentModel.DataAnnotations;
[PrimaryKey(nameof(id))]
public class Persone
{
    
    public int id { get; }
    
    [Required]
    [MaxLength(15)]
    public string? Prenom { get; set; }
    
    [Required]
    [MinLength(2),MaxLength(10)]
    public string? Nom { get; set; }

    public Persone(string nom, string prenom)
    {
        Prenom = prenom;
        Nom = nom;
    }
}