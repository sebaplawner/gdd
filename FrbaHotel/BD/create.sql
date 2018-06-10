USE [GD1C2018]

CREATE TABLE FUNCIONALIDAD (
	func_id int NOT NULL PRIMARY KEY,
	func_nombre varchar(100) NOT NULL
	) 

CREATE TABLE ROL (
	rol_id int NOT NULL PRIMARY KEY,
	rol_nombre varchar(100) NOT NULL,
	rol_habilitado char(1) NOT NULL DEFAULT 1
	) 

CREATE TABLE FUNCIONALIDAD_ROL (
	func_id int NOT NULL FOREIGN KEY REFERENCES FUNCIONALIDAD(func_id),
	rol_id int NOT NULL FOREIGN KEY REFERENCES ROL(rol_id)
	) 

/* ESTA TABLA NO ESTA EN EL MODELO!! */
CREATE TABLE TIPO_DOCUMENTO (
	tipo_id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	tipo_nombre varchar(50) NOT NULL
	)

CREATE TABLE PERSONA (
	pers_tipo_doc int NOT NULL FOREIGN KEY REFERENCES TIPO_DOCUMENTO(tipo_id),
	pers_numero_doc varchar(10) NOT NULL ,
	pers_nombre varchar(100) NOT NULL,
	pers_apellido varchar(100) NOT NULL,
	pers_telefono varchar(50),
	pers_domicilio varchar(200),
	pers_fecha_nac smalldatetime NOT NULL,
	PRIMARY KEY (pers_tipo_doc, pers_numero_doc)
	)

CREATE TABLE PAIS (
	pais_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	pais_nombre varchar(100) NOT NULL
	)

CREATE TABLE CIUDAD (
	ciud_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ciud_nombre varchar(100) NOT NULL
	)

CREATE TABLE ESTRELLAS (
	estr_numero char(1) NOT NULL PRIMARY KEY,
	estr_recargo int NOT NULL
	)

CREATE TABLE HOTEL (
	hote_id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	hote_nombre varchar(100) NOT NULL,
	hote_email varchar(150) NOT NULL,
	hote_telefono varchar(50) NOT NULL,
	hote_domicilio varchar(200) NOT NULL,
	hote_ciudad int NOT NULL FOREIGN KEY REFERENCES CIUDAD(ciud_id),
	hote_pais int NOT NULL FOREIGN KEY REFERENCES PAIS(pais_id),
	hote_estrellas char(1) NOT NULL FOREIGN KEY REFERENCES ESTRELLAS(estr_numero),
	hote_fecha_creacion smalldatetime NOT NULL
	)

CREATE TABLE USUARIO (
	usua_usuario char(50) NOT NULL PRIMARY KEY,
	usua_password varchar(255) NOT NULL, /* este campo despues va a tener que ser un HASH*/
	usua_email varchar(150) NOT NULL,
	usua_rol_activo int NOT NULL FOREIGN KEY REFERENCES ROL(rol_id),
	usua_hotel_activo int NOT NULL FOREIGN KEY REFERENCES HOTEL(hote_id), 
	usua_intentos_login char(1) NOT NULL DEFAULT 0,
	usua_habilitado char(1) NOT NULL DEFAULT 1,
	usua_tipo_doc int NOT NULL ,
	usua_numero_doc varchar(10) NOT NULL,
	FOREIGN KEY (usua_tipo_doc, usua_numero_doc) REFERENCES PERSONA(pers_tipo_doc, pers_numero_doc)
	)

CREATE TABLE USUARIO_HOTEL (
	usua_usuario char(50) NOT NULL FOREIGN KEY REFERENCES USUARIO(usua_usuario),
	hote_id int NOT NULL FOREIGN KEY REFERENCES HOTEL(hote_id)
	)

CREATE TABLE HOTEL_BAJA_TEMPORAL (
	baja_hotel int NOT NULL FOREIGN KEY REFERENCES HOTEL(hote_id),
	baja_desde smalldatetime NOT NULL,
	baja_hasta smalldatetime,
	baja_descripcion varchar(2000)
	)

CREATE TABLE NACIONALIDAD (
	naci_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	naci_descripcion varchar(100) NOT NULL
	)

/* En el modelo porque se relacion cliente con persona? Y SE PUEDE ELIMINAR EL ID POR CLAVE COMPUESTA DOC Y NRO*/
/* Crear un trigger para validar que el mail sea unico */
CREATE TABLE CLIENTE (
	clie_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	clie_tipo_doc int NOT NULL FOREIGN KEY REFERENCES TIPO_DOCUMENTO(tipo_id),
	clie_numero_doc varchar(10) NOT NULL,
	clie_nombre varchar(100) NOT NULL,
	clie_apellido varchar(100) NOT NULL,
	clie_email varchar(150) NOT NULL,
	clie_habilitado char(1) NOT NULL DEFAULT 1,
	clie_domicilio varchar(200),
	clie_fecha_nac smalldatetime NOT NULL,
	clie_localidad varchar(50),
	clie_pais int NOT NULL FOREIGN KEY REFERENCES PAIS(pais_id),
	clie_nacionalidad int NOT NULL FOREIGN KEY REFERENCES NACIONALIDAD(naci_id)
	)
CREATE INDEX IDX_CLIENTE_clie_email ON CLIENTE (clie_email DESC);

CREATE TABLE REGIMEN (
	regi_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	regi_descripcion varchar(100) NOT NULL,
	regi_precio_base numeric(8,2) NOT NULL,
	regi_habilitado char(1) NOT NULL DEFAULT 1
	)

CREATE TABLE HOTEL_REGIMEN (
	regi_id int NOT NULL FOREIGN KEY REFERENCES REGIMEN(regi_id),
	hote_id int NOT NULL FOREIGN KEY REFERENCES HOTEL(hote_id)
	)

CREATE TABLE TIPO_HABITACION (
	tipo_id int NOT NULL PRIMARY KEY,
	tipo_descripcion varchar(50) NOT NULL,
	tipo_precio numeric(8,2) NOT NULL
	)

CREATE TABLE HABITACION (
	habi_hotel int NOT NULL FOREIGN KEY REFERENCES HOTEL(hote_id),
	habi_numero int NOT NULL,
	habi_piso int NOT NULL,
	habi_vista char(1) NOT NULL DEFAULT 'N',
	habi_tipo int NOT NULL FOREIGN KEY REFERENCES TIPO_HABITACION(tipo_id),
	habi_descripcion varchar(1000),
	habi_habilitada char(1) NOT NULL DEFAULT 1,
	PRIMARY KEY (habi_hotel, habi_numero)
	) 

CREATE TABLE COMODIDAD (
	como_id int NOT NULL PRIMARY KEY,
	como_descripcion varchar(100)
	)

CREATE TABLE HABITACION_COMODIDAD (
	como_id int NOT NULL FOREIGN KEY REFERENCES COMODIDAD(como_id),
	habi_hotel int NOT NULL,
	habi_numero int NOT NULL,
	FOREIGN KEY (habi_hotel, habi_numero) REFERENCES HABITACION(habi_hotel, habi_numero)
	)

/* TODO: UNA RESERVA PUEDE TENER VARIAS HABITACIONES */
CREATE TABLE RESERVA (
	rese_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	rese_hotel int NOT NULL FOREIGN KEY REFERENCES HOTEL(hote_id),
    rese_creacion smalldatetime DEFAULT GETDATE(),
	rese_desde smalldatetime NOT NULL,
	rese_duracion int NOT NULL,
	rese_tipo_habitacion int NOT NULL FOREIGN KEY REFERENCES TIPO_HABITACION(tipo_id),
	rese_regimen int NOT NULL FOREIGN KEY REFERENCES REGIMEN(regi_id),
	rese_cliente int NOT NULL FOREIGN KEY REFERENCES CLIENTE(clie_id),
	rese_precio int NOT NULL,
	rese_habitaciones int NOT NULL,
	rese_motivo_cancelacion varchar(100),
	rese_fecha_cancelacion smalldatetime,
	rese_usuario_cancelacion char(50) FOREIGN KEY REFERENCES USUARIO(usua_usuario)
	)

CREATE TABLE ESTADO (
	esta_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	esta_descripcion varchar(100) NOT NULL
	)

CREATE TABLE RESERVA_ESTADO (
	rese_id int NOT NULL FOREIGN KEY REFERENCES RESERVA(rese_id),
	esta_id int NOT NULL FOREIGN KEY REFERENCES ESTADO(esta_id),
	usua_id char(50) NOT NULL FOREIGN KEY REFERENCES USUARIO(usua_usuario),
	rese_esta_fecha smalldatetime NOT NULL
	)

CREATE TABLE CONSUMIBLE (
	cons_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	cons_descripcion varchar(100) NOT NULL,
	cons_precio numeric(8,2) NOT NULL
	)

/* necesita relacion con reserva? o cliente y habitacion? */
CREATE TABLE ESTADIA (
	esta_hotel int NOT NULL,
	esta_habitacion int NOT NULL,
	esta_cliente int NOT NULL FOREIGN KEY REFERENCES CLIENTE(clie_id),
	esta_reserva int NOT NULL FOREIGN KEY REFERENCES RESERVA(rese_id),
	esta_checkin smalldatetime NOT NULL,
	esta_checkout smalldatetime,
    esta_usua_checkin INT,
    esta_usua_checkout INT,
	esta_duracion int,
	FOREIGN KEY (esta_hotel, esta_habitacion) REFERENCES HABITACION(habi_hotel, habi_numero)
	)

/* los consumibles se relacionan con cliente y habitacion? no es mejor con reserva? */
CREATE TABLE CONSUMIBLE_ESTADIA (
    rese_id int NOT NULL FOREIGN KEY REFERENCES RESERVA(rese_id),
    cons_id int NOT NULL FOREIGN KEY REFERENCES CONSUMIBLE(cons_id),
    cons_cantidad int NOT NULL
	)

CREATE TABLE FORMA_PAGO (
	form_id int NOT NULL PRIMARY KEY,
	form_nombre nchar(100) NOT NULL
	) 

/* SE FACTURA CONTRA ESTADIA O CONTRA RESERVA? */
CREATE TABLE FACTURA (
    fact_numero int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    fact_reserva int NOT NULL FOREIGN KEY REFERENCES RESERVA(rese_id),
    fact_forma_pago int NOT NULL FOREIGN KEY REFERENCES FORMA_PAGO(form_id),
    fact_fecha smalldatetime NOT NULL DEFAULT GETDATE(),
    fact_total int NOT NULL
    )


CREATE TABLE FACTURA_LINEA (
    fact_numero int NOT NULL FOREIGN KEY REFERENCES FACTURA(fact_numero),
    fact_es_consumible BIT NOT NULL,
    fact_line_descripcion varchar(100) NOT NULL,
    fact_line_monto int NOT NULL,
    fact_line_cantidad int NOT NULL
    )


