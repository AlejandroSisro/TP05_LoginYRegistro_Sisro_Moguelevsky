using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPs.Models;

namespace TPs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistrarUsuario(Usuario usuario)
    {
        HttpContext.Session.SetString("nombreUsuario", usuario.nombreUsuario ?? "");
        HttpContext.Session.SetString("nombre", usuario.nombre ?? "");
        HttpContext.Session.SetString("apellido", usuario.apellido ?? "");
        HttpContext.Session.SetString("contraseña", usuario.contraseña ?? "");
        HttpContext.Session.SetString("tipoUsuario", usuario.tipoUsuario ?? "");

        return RedirectToAction("Bienvenida");
    }

    public IActionResult Bienvenida()
    {
        var nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
        var nombre = HttpContext.Session.GetString("nombre");
        var apellido = HttpContext.Session.GetString("apellido");
        var contraseña = HttpContext.Session.GetString("contraseña");
        var tipoUsuario = HttpContext.Session.GetString("tipoUsuario");

        ViewData["nombreUsuario"] = nombreUsuario;
        ViewData["nombre"] = nombre;
        ViewData["apellido"] = apellido;
        ViewData["contraseña"] = contraseña;
        ViewData["tipoUsuario"] = tipoUsuario;

        return View();
    }

    public IActionResult Privacy()
    {
        var nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
        var nombre = HttpContext.Session.GetString("nombre");
        var apellido = HttpContext.Session.GetString("apellido");
        var contraseña = HttpContext.Session.GetString("contraseña");
        var tipoUsuario = HttpContext.Session.GetString("tipoUsuario");

        ViewData["nombreUsuario"] = nombreUsuario;
        ViewData["nombre"] = nombre;
        ViewData["apellido"] = apellido;
        ViewData["contraseña"] = contraseña;
        ViewData["tipoUsuario"] = tipoUsuario;

        return View();
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
