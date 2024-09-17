Agrega una migracion para aplicar a la base de datos
dotnet ef migrations add "0001"

Actualiza ultima migracion de las tablas
dotnet ef database update


Fuerza actualizar la migracion inicial de las tablas  
dotnet ef migrations remove

dotnet ef database update 0