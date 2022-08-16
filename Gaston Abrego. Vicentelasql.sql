ACTIVIDADES CLASE 10

SELECT * FROM Usuario
WHERE NombreUsuario = 'tcasazza'

SELECT * FROM Usuario
WHERE NombreUsuario = 'tcasazza'
AND Contraseña = 'SoyTobiasCasazza'

SELECT * FROM Usuario
WHERE NombreUsuario = 'tcasazza'
AND Contraseña = 'AAA'

SELECT * FROM Producto
WHERE IdUsuario = 1

INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)
VALUES ('Cesar', 'Vicentela', 'cvicent', 'boquitapa', 'cvicentela@outlook.com')

INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
VALUES ('Saco', 500, 1000, 10,1)


ACTIVIDADES DESAFIO ENTREGABLE 

SELECT * FROM ProductoVendido

SELECT * FROM ProductoVendido AS pv
INNER JOIN Producto as p
on p.Id = pv.IdProducto
WHERE (p.PrecioVenta*pv.Stock) > 10000
AND Descripciones LIKE '%ina'

INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario)
VALUES ('Aceite de Girasol Cocinera',350,500,20,1)


