# Zaj�cia 5. - Entity Framework

## Aplikacja konsolowa + EF

1. Utworzenie pustego projektu aplikacji konsolowej o nazwie ```EF.ConsoleApp```
2. Instalacja Entity Framework przez NuGet przez [```Package Manager Console```](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console) (konsola PM) poleceniem ```Install-Package EntityFramework -ProjectName EF.ConsoleApp```
3. Definicja connection string do bazy danych (w tym przypadku ```mssqllocaldb```) w pliku konfiguracyjnym aplikacji ```App.config```
4. Dodanie nowego modelu o nazwie ```Dish``` (Danie).
5. Stworzenie ```DbContext``` (naszej furtki do bazy danych), kt�ra ��czy si� z baz� poprzez connection string zdefiniowany powy�ej w pliku ```App.config```. Nowy DbContext udost�pnia Nam dost�p do obiekt�w ```Dish``` poprzez ```DbSet<Dish> Dishes```.
6. W��czenie mechanizmu migracji poprzez wywo�anie polecenia ```Enable-Migrations``` w konsoli PM.
7. Dodanie pierwszej migracji ```Add-Migration "Initial Create"``` w konsoli PM. Powstanie nowy folder w projekcie ```Migrations``` w k�rym powstawa� b�d� kolejne migracje.
8. Aktualizacja bazy danych ```Update-Database -Verbose``` w konsoli PM (parametr ```-Verbose``` powoduje wy�wietlenie zapyta� SQL, kt�re wykonywane s� na bazie danych.
9. W tej chwili mo�na ju� doda� nowo utworzon� baz� do narz�dzia ```Server Explorer```:
   1. Prawym przyciskiem na ```Data connections```, wybierz ```Add Connection```.
   2. W ```Server name``` wpisa� ```(localdb)\mssqllocaldb```
   3. Nast�pnie poni�ej w ```Select or enter database name``` nale�y wybra� Nasz� baz� danych ```EFConsoleApp```
   4. W bazie danych powinna zosta� ju� stworzona tabela dla DataSet-u z ostatio stworzonej migracji. Zawarto�� migracji opisana jest w postaci kodu �r�d�owego w pliku ```Migrations/201710291448013_Initial Create.cs```
10. Seed - posianie wst�pnych danych i/lub danych testowych.
11. Pobieranie dany poprzez ```DataSet<Dish>``` wewn�trz utworzonego ```DbContext```. Przyk�ad w definicji cia�a programu.
```C#
using (var dbCtx = new DefaultAppDbConnection())
	{
		foreach (var item in dbCtx.Dishes)
		{
			Console.WriteLine($@"{item.DishId} {item.DishName} - {item.Price} \@ {item.CreatedBy}");
		}
	}
```