using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Drawing.Imaging;
using System.Threading;



class Program
{
    static void Main(string[] args)
    {
        // Crear el reporte HTML
        var reporter = new ExtentSparkReporter("reporte.html");
        var extent = new ExtentReports();
        extent.AttachReporter(reporter);

        // Crear un test
        var test = extent.CreateTest("Prueba de Lectulandia")
                         .Info("Iniciando navegador y abriendo Lectulandia");

        // Inicializar Selenium
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        try
        {
            driver.Navigate().GoToUrl("https://ww3.lectulandia.com/");
            test.Pass("Página cargada exitosamente");

            // Captura de pantalla
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath = "screenshot.png"; // Ruta del archivo .png
            screenshot.SaveAsFile(screenshotPath);  // Solo se pasa la ruta, sin especificar formato

            test.AddScreenCaptureFromPath(screenshotPath);  // Añadimos la captura al reporte
        }
        catch (Exception ex)
        {
            test.Fail("Error en la prueba: " + ex.Message);
        }

        // Cerrar navegador
        driver.Quit();
        test.Info("Prueba finalizada");
        extent.Flush();  // Finalizar el reporte

        Console.WriteLine("Iniciando prueba...");

         driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://ww3.lectulandia.com/");

        Console.WriteLine("Página cargada correctamente.");

        // Espera 20 segundos antes de cerrar para ver qué pasa
        Thread.Sleep(20000);

        
    }

    
    

}
