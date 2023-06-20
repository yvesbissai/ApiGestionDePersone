using ApiGestionDePersone.Modele;
using ApiGestionDePersone.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestApiGestionPersone;

public class Tests
{
    
    [Test]
    public void TestDeRecherche()
    {
        var p = new Persone("paul","johnson");
        Assert.Pass();
    }
}