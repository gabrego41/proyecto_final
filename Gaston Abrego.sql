SELECT * FROM ProductoVendido

SELECT * FROM ProductoVendido AS pv
INNER JOIN Producto as p
on p.Id = pv.IdProducto
WHERE (p.PrecioVenta*pv.Stock) > 10000
AND Descripciones LIKE '%ina'

INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario)
VALUES ('Aceite de Girasol Cocinera',350,500,20,1)