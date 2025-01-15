# Ribbit Test API

Este proyecto es una API construida con .NET 8, utilizando Entity Framework Core y SQLite como base de datos. Esta API permite gestionar productos a través de operaciones CRUD.

## Requisitos

- .NET 8
- Herramienta de línea de comandos `dotnet`
- SQLite (base de datos)

## Configuración del Proyecto

### Configuración de SQLite

1. La cadena de conexión se encuentra en el archivo `appsettings.json`. Por defecto, la base de datos se almacenará en un archivo llamado `RibbitTest.db` en el directorio raíz del proyecto.

   **appsettings.json**:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=RibbitTest.db"
     },
     ...
   }

### Crear la Migración

1. Abre una terminal en el directorio raíz del proyecto y crea la migración inicial con el siguiente comando:
    
      `dotnet ef migrations add InitialCreate`

2. Aplica la migración a la base de datos con el siguiente comando:

      `dotnet ef database update`

### Ejecución del Proyecto

1. En la terminal ejecuta el siguiente comando para restaurar las dependencias de NuGet:

      `dotnet restore`

2. Luego de restaurar las dependencias, ejecuta el proyecto con el siguiente comando:

      `dotnet run`

## Consumo del API

1. **Obtener productos**

    - **Método**: GET  
    - **Endpoint**: `/api/Productos`  
    - **Descripción**: Devuelve los productos filtrados por nombre o rango de precios.  
    - **Ejemplo de solicitud**:
      ```
      GET /api/Productos?nombre=camisa&minPrecio=10&maxPrecio=50
      ```

2. **Obtener un producto por ID**

    - **Método**: GET  
    - **Endpoint**: `/api/Productos/{id}`  
    - **Descripción**: Devuelve los detalles de un producto específico por su ID.  
    - **Ejemplo de solicitud**:
      ```
      GET /api/Productos/1
      ```

3. **Crear un nuevo producto**

    - **Método**: POST  
    - **Endpoint**: `/api/Productos`  
    - **Descripción**: Crea un nuevo producto. Debe enviar un JSON con los datos del producto.  
    - **Ejemplo de solicitud**:
      ```
      '{
         "Nombre": "Camisa Azul",
         "Descripcion": "Camisa de algodón azul",
         "Precio": 35.00,
         "CantidadEnStock": 80
       }'
      ```

4. **Actualizar un producto existente**

    - **Método**: PUT  
    - **Endpoint**: `/api/Productos/{id}`  
    - **Descripción**: Actualiza un producto existente por su ID.  
    - **Ejemplo de solicitud**:
      ```
      '{
         "Id": 1,
         "Nombre": "Camisa Azul nuevo modelo",
         "Descripcion": "Camisa de algodón azul y rojo",
         "Precio": 120.00,
         "CantidadEnStock": 15
       }'
      ```

5. **Eliminar un producto por ID**

    - **Método**: DELETE  
    - **Endpoint**: `/api/Productos/{id}`  
    - **Descripción**: Elimina un producto por su ID.  
    - **Ejemplo de solicitud**:
      ```
      DELETE /api/Productos/1
      ```
