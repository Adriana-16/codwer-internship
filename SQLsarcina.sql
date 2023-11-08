USE libraria;
/*CREATE TABLE publicare(
publicare_id INT PRIMARY KEY,
nume_publicare VARCHAR(20)
)
CREATE TABLE utilizator(
utilizator_id INT PRIMARY KEY,
nume VARCHAR(40),
email VARCHAR(30),
adresa VARCHAR(30),
comanda_id INT,
)
CREATE TABLE comenzi(
comanda_id INT PRIMARY KEY,
data_comada DATE,
pret FLOAT,
utilizator_id INT,
FOREIGN KEY (utilizator_id) REFERENCES utilizator(utilizator_id)
)
CREATE TABLE carti(
carte_id INT PRIMARY KEY,
titlu VARCHAR(40),
autor VARCHAR(50),
an_publicare INT,
pret INT,
publicare_id INT,
FOREIGN KEY (publicare_id) REFERENCES publicare(publicare_id),
comanda_id INT,
FOREIGN KEY(comanda_id) REFERENCES comenzi(comanda_id)
)

CREATE TABLE detalii_carti(
detalii_id INT PRIMARY KEY,
descriere VARCHAR(100),
numar_pagini INT,
limba VARCHAR(10),
carte_id INT,
FOREIGN KEY (carte_id) REFERENCES carti(carte_id)
)
*/
/*INSERT INTO publicare (publicare_id, nume_publicare) VALUES
     (1, 'Bestseller'),
	 (2, 'Clasics'),
	 (3, 'Carturesti'),
	 (4, 'Cartier'),
	 (5, 'Humanitas'),
	 (6, 'Litera'),
	 (7, 'Tera'),
	 (8, 'Univers')
INSERT INTO utilizator (utilizator_id, nume, email, adresa, comanda_id) VALUES 
     (1, 'Farima Adriana', 'adrianafarama116@gmail.com', 'ginta latina 15/2', 1),
	 (2, 'Nicolaescu Alina', 'alinanicolaescu10@gmail.com', 'buiucani 63/1', 2),
	 (3, 'Neceaeva Anastasia', 'anastasianeceaeva@gmail.com', 'posta veche 4', 3),
	 (4, 'Savitchi Eugenia', 'eugenia16@gmail.com', 'studentilor 10', 4),
	 (5, 'Voicu Max', 'maximvoicu7@mail.com', 'studentilor 10', 5),
	 (6, 'Gicu Gemu', 'gicugemu@gmail.com', 'buiucani 12', 6) 
INSERT INTO comenzi (comanda_id, data_comada, pret, utilizator_id) VALUES
     (1, '2021-10-21', 100.35, 1),
	 (2, '2022-01-15', 27.10, 2),
	 (3, '2023-08-23', 130.06, 3),
	 (4, '2020-07-05', 270.10, 4),
	 (5, '2021-03-23', 458.78, 5),
	 (6, '2004-03-16', 59.00, 6)
INSERT INTO carti(carte_id, titlu, autor, an_publicare, pret, publicare_id, comanda_id) VALUES
     (1, 'Mandrie si prejudecata', 'Jane Austen', 2005, 5, 2, 1),
	 (2, 'Idiotul', 'Feodor Dostoievski', 2015, 7, 2, 1),
	 (3, 'After', 'Anna Todd', 2019, 10, 1, 6),
	 (4, 'La rascruce de vanturi', 'Emily Bronte', 2001, 12, 7, 2),
	 (5, 'Enigma Otiliei', 'George Clinescu', 2016, 4, 6, 5),
	 (6, 'Ingeri si demoni', 'Dan Brown', 2009, 20, 8, 4),
	 (7, 'Si a fost noapte', 'Aureliu Busuioc', 2012, 3, 3, 3),
	 (8, 'Fericirea incepe azi', 'Jamie McGuire', 2020, 13, 5, 2) 
	 ALTER TABLE detalii_carti
	 ALTER COLUMN descriere VARCHAR(1000)
INSERT INTO detalii_carti (detalii_id, descriere, numar_pagini, limba, carte_id) VALUES
     (1, '"Pride and Prejudice" is a timeless tale of love, societal expectations, and personal transformation in 19th-century England.', 290, 'engleza', 1),
	 (2, '"Idiotul" explorează psihologia umană prin povestea lui Prince Myshkin, un om inocent învăluit în dileme morale în societatea rusă.', 590, 'romana', 2),
	 (3, '"After" este un roman de dragoste, ce explorează relația tumultuoasă dintre Tessa și Hardin, abordând teme precum dezvoltarea personală.', 300, 'romana', 3),
	 (4, '"Wuthering Heights" is a Gothic novel depicting a tumultuous love story and vengeful passions, centered around the relationship of Heathcliff and Catherine Earnshaw.', 320, 'engleza', 4),
	 (5, '"Enigma Otiliei" este un roman clasic românesc ce explorează lumea complexă a înaltei societăți din începutul secolului XX,', 220, 'romana', 5),
	 (6, '"Angels and Demons" is a thrilling mystery where symbologist Robert Langdon races against time to uncover a Vatican conspiracy.', 170, 'engleza', 6),
	 (7, '"Și a fost noapte" este o poveste sensibilă despre căutarea sensului într-un univers poetic în timpul unei nopți magice.', 92, 'romana', 7),
	 (8, '"Fericirea incepe azi" este un roman captivant care explorează întâlnirea a doi oameni și călătoria lor emoțională prin provocări și iubire', 330, 'romana', 8)

ALTER TABLE publicare 
ADD data_adaugarii DATETIME DEFAULT GETDATE()
ALTER TABLE publicare
ADD data_ultimei_modificari DATETIME DEFAULT GETDATE()

ALTER TABLE utilizator 
ADD data_adaugarii DATETIME DEFAULT GETDATE()
ALTER TABLE utilizator
ADD data_ultimei_modificari DATETIME DEFAULT GETDATE()

ALTER TABLE comenzi 
ADD data_adaugarii DATETIME DEFAULT GETDATE()
ALTER TABLE comenzi
ADD data_ultimei_modificari DATETIME DEFAULT GETDATE()

ALTER TABLE carti 
ADD data_adaugarii DATETIME DEFAULT GETDATE()
ALTER TABLE carti
ADD data_ultimei_modificari DATETIME DEFAULT GETDATE()

ALTER TABLE detalii_carti 
ADD data_adaugarii DATETIME DEFAULT GETDATE()
ALTER TABLE detalii_carti
ADD data_ultimei_modificari DATETIME DEFAULT GETDATE()*/

/*Sa se identifice toate cartile care au cel putin 300 de pagini si sa se afiseze numele lor*/
SELECT carti.titlu AS Carte, MAX(detalii_carti.numar_pagini) AS NumarPagini
FROM carti 
JOIN detalii_carti ON carti.carte_id = detalii_carti.carte_id
GROUP BY carti.titlu
HAVING MAX(detalii_carti.numar_pagini) >= 300


/*Sa se identifice toate comenzile care contin mai mult de o carte si sa se afiseze numele utilizatorului care a facut comanda si data comenzii*/
SELECT utilizator.nume AS utilizator, comenzi.data_comada AS Data
FROM utilizator
JOIN comenzi ON utilizator.utilizator_id = comenzi.utilizator_id
JOIN carti ON comenzi.comanda_id = carti.comanda_id
GROUP BY utilizator.nume, comenzi.data_comada, comenzi.comanda_id
HAVING COUNT (comenzi.comanda_id) > 1

/*Sa se identifice toate cartile care sunt in limba engleza si sa se afiseze numele si autorul lor */
SELECT carti.titlu AS Titlu, detalii_carti.limba AS limba, carti.autor AS Autor
FROM carti
JOIN detalii_carti ON carti.carte_id = detalii_carti.carte_id
WHERE detalii_carti.limba = 'engleza'











