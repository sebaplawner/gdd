USE [GD1C2018]

DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + ']'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

DROP TABLE FACTURA_LINEA
DROP TABLE FACTURA
DROP TABLE FORMA_PAGO
DROP TABLE CONSUMIBLE_ESTADIA
DROP TABLE ESTADIA
DROP TABLE CONSUMIBLE
DROP TABLE RESERVA_ESTADO 
DROP TABLE ESTADO
DROP TABLE RESERVA
DROP TABLE HABITACION_COMODIDAD 
DROP TABLE COMODIDAD 
DROP TABLE HABITACION
DROP TABLE TIPO_HABITACION
DROP TABLE HOTEL_REGIMEN
DROP TABLE REGIMEN
DROP INDEX IDX_CLIENTE_clie_email ON CLIENTE
DROP TABLE CLIENTE
DROP TABLE NACIONALIDAD
DROP TABLE HOTEL_BAJA_TEMPORAL
DROP TABLE USUARIO_HOTEL
DROP TABLE USUARIO
DROP TABLE HOTEL
DROP TABLE ESTRELLAS
DROP TABLE CIUDAD
DROP TABLE PAIS
DROP TABLE PERSONA
DROP TABLE TIPO_DOCUMENTO
DROP TABLE FUNCIONALIDAD_ROL
DROP TABLE FUNCIONALIDAD
DROP TABLE ROL
