/*Base de Datos*/

CREATE DATABASE POEV_3P_Proyectito1;

USE POEV_3P_Proyectito1;

CREATE TABLE jugador1
(
	id INT PRIMARY KEY,
	jugador1 VARCHAR(20),
	puntos INT,
	ganado INT,
	perdido INT,
	empate INT
);

CREATE TABLE jugador2
(
	id INT PRIMARY KEY,
	jugador2 VARCHAR(20),
	puntos INT,
	ganado INT,
	perdido INT,
	empate INT
);

INSERT INTO jugador1 VALUES(1, 'Tom', 0, 0, 0, 0);
INSERT INTO jugador1 VALUES(2, 'Marco',  0, 0, 0, 0);
INSERT INTO jugador1 VALUES(3, 'Alex',  0, 0, 0, 0);
INSERT INTO jugador1 VALUES(4, 'Fer',  0, 0, 0, 0);

INSERT INTO jugador2 VALUES(1, 'Airam',  0, 0, 0, 0);
INSERT INTO jugador2 VALUES(2, 'Monica',  0, 0, 0, 0);
INSERT INTO jugador2 VALUES(3, 'Joana',  0, 0, 0, 0);
INSERT INTO jugador2 VALUES(4, 'Ailyn',  0, 0, 0, 0);

SELECT * FROM jugador1;

DROP TABLE jugador2;
