use Noticias

create table categorias(
IdCategorias int identity primary key,
Categoria varchar(40)
);
insert into categorias(Categoria) values('Deportes')
insert into categorias(Categoria) values('Farandula')
insert into categorias(Categoria) values('Entretenimiento')
insert into categorias(Categoria) values('Salud')
-----------------------------------------------------

create table Mundiales(
IdMundiales int identity primary key,
Continente varchar(40),
);
insert into Mundiales(Continente) values('Americano')
insert into Mundiales(Continente) values('Africano')
insert into Mundiales(Continente) values('Europeo')
insert into Mundiales(Continente) values('Oceania')
insert into Mundiales(Continente) values('Asia')
---------------------------------------------------------

create table Paises(
IdPais int identity primary key,
Pais varchar(40),
IdMundiales int constraint fk_Mundiales foreign key references Mundiales (IdMundiales) 
);

insert into Paises(Pais,IdMundiales) values('Estados Unidos','1')
insert into Paises(Pais,IdMundiales) values('Republica Dominicana','1')
insert into Paises(Pais,IdMundiales) values('Japon','5')
insert into Paises(Pais,IdMundiales) values('España','3')
------------------------------------------------------------

create table Noticiass(
IdNoticias int identity primary key,
Titulo varchar(500),
Autor varchar(40),
Descripcion varchar(max),
Link varchar(500),
Imagen image,
Fecha datetime,
IdCategorias int constraint fk_categorias foreign key references categorias (IdCategorias),
IdPais int constraint fk_Pais foreign key references Paises (IdPais)
);	
insert into Noticiass(Titulo,Autor,Descripcion,Link,Imagen,Fecha,IdCategorias,IdPais) 
values('Champions. Memphis languidece en el tormento goleador del Barcelona','Francisco Cabezas',
'Aunque pueda parecer contradictorio, el Barcelona cerró la noche de Champions del martes con cierto optimismo. El equipo fue incapaz de vencer al Benfica, requisito indispensable para haberse clasificado ya para los octavos de final de la competición.',
'https://www.elmundo.es/deportes/futbol/champions-league/2021/11/25/619e2c16fc6c83d1458b45ca.html','https://phantom-elmundo.unidadeditorial.es/3801b81c2d3bd8e5ba23ef63e7417aac/resize/746/f/webp/assets/multimedia/imagenes/2021/11/24/16377659948753.jpg',
'25/11/2021','1','3')






