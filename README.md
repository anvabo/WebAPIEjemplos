# WebAPIEjemplos

API para poder usar desde cualquier cliente, ya sea web, movil, etc.

Lo usaremos en todos los ejemplos para el curso de Vue 3 con TypeScript

## Ejecución desde Visual Studio

Compilar el proyecto y ejecutarlo desde Visual Studio. Arranca la web en el puerto 44308
https://localhost:44308/usuarios

Disponemos del swagger para poder visualizar todos los endpoints https://localhost:44308/swagger/index.html


## Ejecución por comandos

```
dotnet run
```

o ponemos el puerto en caso de que no arranque en el puerto 44308

```
dotnet run --urls=https://localhost:44308
```

## Ejecución del binario

```
.\bin\Debug\net6.0\WebAPIEjemplos.exe
```

o ponemos el puerto en caso de que no arranque en el puerto 44308

```
.\bin\Debug\net6.0\WebAPIEjemplos.exe --urls=https://localhost:44308
```

## Acceso desde el navegador

https://localhost:44308/usuarios

https://localhost:44308/swagger/index.html