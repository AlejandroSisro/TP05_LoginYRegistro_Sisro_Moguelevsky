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
        Usuario usuario = new Usuario
        {
            nombreUsuario = HttpContext.Session.GetString("nombreUsuario") ?? string.Empty,
            nombre = HttpContext.Session.GetString("nombre") ?? string.Empty,
            apellido = HttpContext.Session.GetString("apellido") ?? string.Empty,
            contraseña = HttpContext.Session.GetString("contraseña") ?? string.Empty,
            tipoUsuario = HttpContext.Session.GetString("tipoUsuario") ?? string.Empty
        };
        ViewBag.usuario = usuario;
        ViewBag.nombreUsuario = usuario.nombreUsuario;
        ViewBag.nombre = usuario.nombre;
        ViewBag.apellido = usuario.apellido;
        ViewBag.contraseña = usuario.contraseña;
        ViewBag.tipoUsuario = usuario.tipoUsuario;

        return View();
    }

    public IActionResult Privacy()
    {
        Usuario usuario = new Usuario
        {
            nombreUsuario = HttpContext.Session.GetString("nombreUsuario") ?? string.Empty,
            nombre = HttpContext.Session.GetString("nombre") ?? string.Empty,
            apellido = HttpContext.Session.GetString("apellido") ?? string.Empty,
            contraseña = HttpContext.Session.GetString("contraseña") ?? string.Empty,
            tipoUsuario = HttpContext.Session.GetString("tipoUsuario") ?? string.Empty
        };

        ViewBag.usuario = usuario;
        ViewBag.nombreUsuario = usuario.nombreUsuario;
        ViewBag.nombre = usuario.nombre;
        ViewBag.apellido = usuario.apellido;
        ViewBag.contraseña = usuario.contraseña;
        ViewBag.tipoUsuario = usuario.tipoUsuario;

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
