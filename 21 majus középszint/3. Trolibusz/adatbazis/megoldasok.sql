-- A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!


-- 10. feladat:
CREATE DATABASE halozat DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;

-- 12. feladat:

INSERT into megallok (id, nev) VALUES (198, "Kőbányai garázs");
-- 13. feladat:
UPDATE jaratok SET Elsoajtos=0 WHERE id=20

-- 14. feladat:
SELECT jaratSzam from jaratok WHERE elsoAjtos=1

-- 15. feladat:
SELECT nev from megallok where nev like "%sétány" ORDER by nev

-- 16. feladat:
SELECT halozat.sorszam sorszam, megallok.nev megallo 
from megallok 
INNER JOIN halozat on megallok.id=halozat.megallo 
INNER JOIN jaratok on halozat.jarat=jaratok.id 
WHERE jaratok.jaratSzam="CITY" AND halozat.irany="A" 
ORDER by halozat.sorszam

-- 17. feladat:
SELECT megallok.nev megallo, COUNT(halozat.jarat) jaratokSzama
 from megallok
 INNER JOIN halozat on megallok.id=halozat.megallo
 GROUP by halozat.megallo 
 HAVING COUNT(halozat.jarat)>3
 ORDER by megallok.nev


