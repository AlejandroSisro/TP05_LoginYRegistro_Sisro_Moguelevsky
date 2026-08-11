//Codigo mejorado usando ask en copilot, usando un codigo hecho por nosotros.

const regexNombre = /^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$/;

function validarFormulario() {
    const nombreUsuario = document.getElementById("inputNombreUsuario").value.trim();
    const nombre = document.getElementById("inputNombre").value.trim();
    const apellido = document.getElementById("inputApellido").value.trim();
    const contraseña = document.getElementById("inputContraseña").value.trim();
    const tipoUsuario = document.getElementById("inputTipoUsuario").value;
    if (nombreUsuario === "" || nombre === "" || apellido === "" || contraseña === "" || tipoUsuario === "") {
        console.log("Error: Todos los campos son obligatorios.");
        return false;
    }
    if (nombreUsuario.length < 12) {
        console.log("Error: El nombre de usuario debe tener mínimo 12 caracteres.");
        return false;
    } 
    if (contraseña.length < 8) {
        console.log("Error: La contraseña debe tener mínimo 8 caracteres.");
        return false;
    }
    if (nombre.length < 3) {
        console.log("Error: El nombre debe tener mínimo 3 caracteres.");
        return false;
    }
    if (!regexNombre.test(nombre)) {
        console.log("Error: El nombre contiene caracteres no permitidos.");
        return false;
    }
    if (!regexNombre.test(apellido)) {
        console.log("Error: El apellido contiene caracteres no permitidos.");
        return false;
    }
    console.log("Éxito: Todos los datos son válidos.");
    return true;
}
