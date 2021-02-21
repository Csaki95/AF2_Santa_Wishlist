# Alkfejl III. kötelező program III.
Santa Claus

## Feladat

A feladat egy karácsonyi kívánságlista webalkalmazás elkészítése.

A program célja ASP.NET Core MVC struktúra, és Entity Framework megismerése.

### Eredeti kiírás

- A Mikulás ajándéknyilvántartó alkalmazásának elkészítése C# nyelven
WinForms környezetben, mely követi az MVC modellt.
- Az adatok SQLite adatbázisban tárolandók.
- Az adatbázis sémáját santaclaus.sql tartalmazza.

#### Kívánság hozzáadása

- Új ablakban kell lennie a hozzáadásnak.
- Egy kívánság a következo tulajdonságokkal bír:

| Név | Típus | További információ |
| --- | --- | --- |
| Név | szöveg | nem üres, egyedi |
| Szín | szöveg | nem üres |
| Tömeg | szám | pozitív |
| Prioritás | szám | 1-10 |

#### Kívánság böngészése

- A kívánságokat lehet listázni, viszont a Prioritás érték ne látszódjon,
ellenben az érték szerint legyen rendezve a lista (magasabb szám elöl).
- A lista egy DataGridView-be jelenjen meg.

#### Kívánság módosítása

- A listában egy kívánságra kattintva módosítható legyen.
    - A “kívánság hozzáadása” Form-ot használva.
    - A DataGridView-ban ne lehessen össze-vissza átírni az értékeket.
- Módosítható elem: szín, prioritás.

## Megvalósítás

A feladatkiírásnak megfelelően a lista prioritás szerint van rendezve ami nem látható, de Details-ra kattintva látszik az ellenőrzéséhez.

Edit-ben a cshtml-ben le van tiltva a név, és a súly. A backend PresentController Edit metódusban pedig csak a szín, és prioritás mentődik ennek megfelelően.