using System.Globalization;

// Ändere die Zeichenkodierung für Kommandozeilenausgaben auf UTF8.
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Gib Länge ein: ");
double length = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
Console.Write("Gib Breite ein: ");
double width = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
double area = length * width;
double circumference = 2 * length + 2 * width;
string output = string.Format(CultureInfo.InvariantCulture,
    "Fläche ist {0:F2} und Umfang ist {1:0000.00}", area, circumference);
Console.WriteLine(output);

// Beispiel:
// Gib Länge ein: 10
// Gib Breite ein: 2
// Fläche ist 20.00 und Umfang ist 0024.00
