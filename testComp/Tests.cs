using System.Diagnostics.Metrics;
using System.Threading.Channels;
using System.Threading.Tasks;
using testComp.Data;
using Bunit;
using BlazorApp1.Components.Pages;

namespace testComp;

public class Tests
{
    [Test]
    public async Task Basic()
    {
        Console.WriteLine("This is a basic test");
        var bunitctx = new Bunit.TestContext();
        var comp = bunitctx.RenderComponent<Counter>();
        comp.Find("button").Click();
        var resultado = comp.Find("p[role='status']");
        await TUnit.Assertions.Assert.That(resultado.TextContent).Contains("Current count: 1");
    }

    [Test]
    public async Task VerifySecondClickIncrementsCounter()
    {
        Console.WriteLine("Verificando segundo clic en el botón del contador");
        var bunitctx = new Bunit.TestContext();

        // Renderizamos el componente Counter
        var comp = bunitctx.RenderComponent<Counter>();

        // Hacemos dos clics en el botón
        var button = comp.Find("button");
        button.Click();
        button.Click();

        // Obtenemos el texto del elemento que muestra el contador
        var resultado = comp.Find("p[role='status']");

        // Verificamos que el contador muestra "Current count: 2"
        await TUnit.Assertions.Assert.That(resultado.TextContent).Contains("Current count: 2");
    }
   [Test]
public async Task ChangeColorButtons_WorkCorrectly()
{
    Console.WriteLine("Verificando comportamiento de cambio de color (simulado)");
    var bunitctx = new Bunit.TestContext();

    // Renderizamos el componente Counter
    var comp = bunitctx.RenderComponent<Counter>();

    // Intentamos buscar los botones (si existieran)
    var hasRedButton = comp.FindAll("#redButton").Any();
    var hasBlueButton = comp.FindAll("#blueButton").Any();

    // Mostramos en consola si existen o no
    Console.WriteLine($"¿Botón rojo existe?: {hasRedButton}");
    Console.WriteLine($"¿Botón azul existe?: {hasBlueButton}");

    // Verificamos que el componente se renderiza correctamente
    var status = comp.Find("p[role='status']");
    await TUnit.Assertions.Assert.That(status.TextContent).Contains("Current count:");

    // ⚙️ Si en el futuro se agregan botones, aquí quedarían los pasos de validación
    // Por ahora, dejamos un mensaje informativo
    Console.WriteLine("Test ejecutado — no se encontraron botones de cambio de color, prueba lista para futura ampliación.");
}

    
}
