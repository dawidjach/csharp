using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.Write("Umsatz: ");
double umsatz = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
double bonus = 0;

if (umsatz < 2_000)
{
    bonus = 0;
}
else if (umsatz >= 2_000 && umsatz <= 10_000)
{
    bonus = 100;
}
else if (umsatz <= 50_000)
{
    bonus = 0.02 * umsatz;
}
else
{
    bonus = 0.05 * umsatz;
}

Console.WriteLine("Bonus beträgt {0:F2}", bonus);
