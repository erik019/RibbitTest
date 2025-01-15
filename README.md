# Ribbit Test API

Este proyecto es una API construida con .NET 8, utilizando Entity Framework Core y SQLite como base de datos. Esta API permite gestionar productos a trav�s de operaciones CRUD.

## Requisitos

- .NET 8
- Herramienta de l�nea de comandos `dotnet`
- SQLite (base de datos)

## Configuraci�n del Proyecto

### Configuraci�n de SQLite

1. La cadena de conexi�n se encuentra en el archivo `appsettings.json`. Por defecto, la base de datos se almacenar� en un archivo llamado `RibbitTest.db` en el directorio ra�z del proyecto.

   **appsettings.json**:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=RibbitTest.db"
     },
     ...
   }

### Crear la Migraci�n

1. Abre una terminal en el directorio ra�z del proyecto y crea la migraci�n inicial con el siguiente comando:
    
      `dotnet ef migrations add InitialCreate`

2. Aplica la migraci�n a la base de datos con el siguiente comando:

      `dotnet ef database update`

### Ejecuci�n del Proyecto

1. En la terminal ejecuta el siguiente comando para restaurar las dependencias de NuGet:

      `dotnet restore`

2. Luego de restaurar las dependencias, ejecuta el proyecto con el siguiente comando:

      `dotnet run`

## Consumo del API

1. **Obtener productos**

    - **M�todo**: GET  
    - **Endpoint**: `/api/Productos`  
    - **Descripci�n**: Devuelve los productos filtrados por nombre o rango de precios.  
    - **Ejemplo de solicitud**:
      ```
      GET /api/Productos?nombre=camisa&minPrecio=10&maxPrecio=50
      ```

2. **Obtener un producto por ID**

    - **M�todo**: GET  
    - **Endpoint**: `/api/Productos/{id}`  
    - **Descripci�n**: Devuelve los detalles de un producto espec�fico por su ID.  
    - **Ejemplo de solicitud**:
      ```
      GET /api/Productos/1
      ```

3. **Crear un nuevo producto**

    - **M�todo**: POST  
    - **Endpoint**: `/api/Productos`  
    - **Descripci�n**: Crea un nuevo producto. Debe enviar un JSON con los datos del producto.  
    - **Ejemplo de solicitud**:
      ```
      '{
         "Nombre": "Camisa Azul",
         "Descripcion": "Camisa de algod�n azul",
         "Precio": 35.00,
         "CantidadEnStock": 80
       }'
      ```

4. **Actualizar un producto existente**

    - **M�todo**: PUT  
    - **Endpoint**: `/api/Productos/{id}`  
    - **Descripci�n**: Actualiza un producto existente por su ID.  
    - **Ejemplo de solicitud**:
      ```
      '{
         "Id": 1,
         "Nombre": "Camisa Azul nuevo modelo",
         "Descripcion": "Camisa de algod�n azul y rojo",
         "Precio": 120.00,
         "CantidadEnStock": 15
       }'
      ```

5. **Eliminar un producto por ID**

    - **M�todo**: DELETE  
    - **Endpoint**: `/api/Productos/{id}`  
    - **Descripci�n**: Elimina un producto por su ID.  
    - **Ejemplo de solicitud**:
      ```
      DELETE /api/Productos/1
      ```
