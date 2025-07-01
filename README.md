# Layered Microservices Example (.NET 8)

Este repositorio muestra una version sencilla de una arquitectura de microservicios con C# y .NET 8 siguiendo el esquema por capas. Existen dos microservicios (marcas y concesionarios) y un API Gateway que enruta las solicitudes.

## Estructura del proyecto

```
src/
  BrandService/
    BrandService.Api
    BrandService.Application
    BrandService.Domain
    BrandService.Infrastructure
  DealerService/
    DealerService.Api
    DealerService.Application
    DealerService.Domain
    DealerService.Infrastructure
  ApiGateway/
```

Cada microservicio mantiene sus datos en memoria para simplificar el ejemplo.

## Ejecución

1. Asegúrate de tener instalado **.NET 8 SDK**.
2. Compila cada proyecto y ejecútalo en terminales separadas:

```bash
# Brand service en puerto 5001
dotnet run --project src/BrandService/BrandService.Api

# Dealer service en puerto 5002
dotnet run --project src/DealerService/DealerService.Api

# API Gateway en puerto 5000
dotnet run --project src/ApiGateway
```

Con los servicios en marcha podrás acceder a:

- `http://localhost:5000/brands` para operaciones de marcas.
- `http://localhost:5000/dealers` para operaciones de concesionarios.

Todos los proyectos usan el modelo de capas: Domain, Application, Infrastructure y Api.
