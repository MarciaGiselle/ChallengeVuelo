CREATE DATABASE Vuelos; 
USE Vuelos;
create table Vuelo (
Id int primary key identity(1,1) not null,
Numero varchar(30) not null,
HorarioLlegada time not null,
LineaAerea varchar(30) not null,
Demorado bit not null
);

