let nombreUsuario;
let contraseña;
let nombre;
let apellido;
let tipoUsuario;
const regexNombre = /^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$/;
 do
 {
  console.log("Ingrese su nombre de usuario (mínimo 12 caracteres)");
 }while (nombreUsuario.length < 12)
 do
 {
  console.log("Ingrese su contraseña (mínimo 8 caracteres)");
 }while (contraseña.length < 8)
 do
 {
  console.log("Ingrese su contraseña (mínimo 8 caracteres)");
 }while (nombre.length < 8)

if (regexNombre.test(nombre)) {
    console.log("El nombre es válido.");
} else {
    console.log("El nombre contiene caracteres no permitidos.");
}
if (regexNombre.test(apellido)) {
    console.log("El apellido es válido.");
} else {
    console.log("El apellido contiene caracteres no permitidos.");
}
function validarFormulario() {
    nombreUsuario = document.getElementById("inputNombreUsuario").value;
    nombre = document.getElementById("inputNombre").value;
    apellido = document.getElementById("inputApellido").value;
    contraseña = document.getElementById("inputContraseña").value;
    tipoUsuario = document.getElementById("inputTipoUsuario").value;
    if (nombre == "" || apellido == "" || contraseña == "" || nombreUsuario == "" || tipoUsuario == "") {
        console.log("Error: Hay campos vacíos en el formulario.");
        return false; 
    }
    console.log("Éxito: Todos los campos tienen texto.");
    return true;
}

