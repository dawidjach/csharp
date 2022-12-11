//int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//int[] invertedNumbers = ReverseArrayInPlace(numbers);
//Console.WriteLine(String.Join(',', invertedNumbers));

//int totalDays = 2221;
//TotalDaysToYearsMonthsAndDays(totalDays, out int years, out int months, out int days);
//Console.WriteLine($"{totalDays} Tage = {years} Jahre, {months} Monate, {days} Tage");

//Console.WriteLine(ReverseStringWithLoop("ABCDEF"));
//Console.WriteLine(ReverseStringWithRecursion("ABCDEFGH"));
//Console.WriteLine(BinaryToDecimal("10111"));
//Console.WriteLine(BinaryToDecimalRecursive("10111"));

//Console.WriteLine(EncryptWithCaesar("abc", -3));  // xyz
//Console.WriteLine(EncryptWithCaesar("xyz", -3));  // uvw
//Console.WriteLine(EncryptWithCaesar("xyz", 3));  // abc
//Console.WriteLine(EncryptWithCaesar(EncryptWithCaesar("abcde", 5), -5));
//string text = @"Glhv lvw hlq Ehlvslhowhaw ghu plw hlqhp Nolfn yhuvfkoüvvhow zhughq ndqq. Klhu ndqq dxfk hlq hljhqhq Whaw khuhlq jhvfkulhehq, rghu hlq Jhkhlpfrgh cxp Hqwvfkoüvvhoq khuhlq nrslhuw zhughq.";
//Console.WriteLine(EncryptWithCaesar(text, -3));
//Console.WriteLine(string.Join(", ", DecimalToReversedIntArray(987654321)));


// Invertiere ein Array mit einer Kopie (Hilfs-Array)
static int[] ReverseArrayWithHelperArray(int[] numbers)
{
    int[] inversed = new int[numbers.Length];

    // Variante 1
    //for (int i = 0; i < numbers.Length; i++)
    //{
    //    inversed[i] = numbers[numbers.Length - 1 - i];
    //}

    // Variante 2
    //for (int i = 0, j = numbers.Length - 1; i < numbers.Length; ++i, j--)
    //{
    //    inversed[i] = numbers[j];
    //}

    // Variante 3
    //for (int i = numbers.Length - 1; i >= 0; i--)
    //{
    //    inversed[numbers.Length - i - 1] = numbers[i];
    //}

    // Variante 4
    for (int i = 0; i < numbers.Length; ++i)
    {
        inversed[i] = numbers[^(i + 1)]; // Index-From-End-Operator
    }

    return inversed;
}

// Invertiere ein Array in-Place, d.h. ohne einen Hilfs-Array
static int[] ReverseArrayInPlace(int[] numbers)
{
    int length = numbers.Length;

    // Variante 1
    //for (int i = 0; i < length / 2; ++i)
    //{
    //    int copy = numbers[i];
    //    numbers[i] = numbers[length - 1 - i];
    //    numbers[length - 1 - i] = copy;
    //}

    // Variante 2
    //for (int i = 0, j = length - 1; i < length / 2; ++i, --j)
    //{
    //    int copy = numbers[i];
    //    numbers[i] = numbers[j];
    //    numbers[j] = copy;
    //}

    // Variante 3
    for (int i = 0; i < length / 2; ++i)
    {
        int copy = numbers[i];
        numbers[i] = numbers[^(i + 1)];
        numbers[^(i + 1)] = copy;
    }

    return numbers;
}


// Zerlegt eine Anzahl von Tagen in Jahre, Monate und Tage.
// Annahmen: 1 Jahr = 365 Tage, 1 Monat = 30 Tage
static void TotalDaysToYearsMonthsAndDays(int totalDays, out int years, out int months, out int days)
{
    years = totalDays / 365;
    // int remainingDays = totalDays - (totalDays / 365) * 365;
    int remainingDays = totalDays % 365;
    months = remainingDays / 30;
    days = remainingDays % 30;
}


static string ReverseStringWithLoop(string input)
{
    string reversed = "";

    // Variante 1
    //foreach (char c in input)
    //{
    //    reversed = c + reversed; // Prepend
    //}

    // Variante 2
    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversed += input[i]; // Append
        //reversed = reversed + input[i];
    }
    return reversed;
}


// Idee: Lösung für ABCDE errechnet sich aus Lösung für BCDE und A.
//       Lösung für BCDE errechnet sich aus Lösung für CDE und B.
//       Lösung für CDE errechnet sich aus Lösung für DE und C.
//       Lösung für DE errechnet sich aus Lösung für E und D.
//       Lösung für E errechnet sich aus Lösung für "" und E.
//       Lösung für "" ist "".
static string ReverseStringWithRecursion(string input, int indent = 0)
{
    // Ultra kurze Lösung:
    //return (input == "") ? input : ReverseStringWithRecursion(input[1..]) + input[0];

    Console.WriteLine("{0}Berechne Lösung für Input {1}", new string(' ', indent), input);
    if (input == "")
    {
        return ""; // Abbruchkriterium für Rekursion
    }

    char firstLetter = input[0];
    string rest = input[1..]; // input.Substring(1);
    string reversedRest = ReverseStringWithRecursion(rest, indent + 2);
    string result = reversedRest + firstLetter;

    Console.WriteLine("{0}Lösung für {1} ist {2}", new string(' ', indent), input, result);
    return result;
}



static int BinaryToDecimal(string binaryString)
{
    int decimalNumber = 0;

    // Variante 1
    foreach (char c in binaryString)
    {
        int digit = c == '0' ? 0 : 1;
        decimalNumber = decimalNumber * 2 + digit;
    }

    // Variante 2
    //int factor = 1; // factor ist Stellenwert, also 2^0, 2^1, 2^2 usw.
    //for (int i = binaryString.Length - 1; i >= 0; i--, factor *= 2)
    //{
    //    int digit = binaryString[i] == '0' ? 0 : 1;
    //    decimalNumber += digit * factor; 
    //}

    return decimalNumber;
}

static int BinaryToDecimalRecursive(string binaryString)
{
    if (binaryString == "") return 0;
    if (binaryString.Length == 1) // "0" oder "1"
    {
        return int.Parse(binaryString);
    }

    // 1011 | 1 
    string partialBinaryString = binaryString[0..^1];
    char lastDigit = binaryString[^1];
    int partialSolution = BinaryToDecimalRecursive(partialBinaryString);
    int solution = partialSolution * 2 + (lastDigit == '1' ? 1 : 0);
    return solution;
}

//Console.WriteLine(DecimalToBinary(23));

static string DecimalToBinary(int decimalNumber)
{
    string result = "";

    do
    {
        int digit = decimalNumber % 2;
        result = digit.ToString() + result;
        decimalNumber = decimalNumber / 2;
    }
    while (decimalNumber > 0);

    return result;
}

Console.WriteLine(DecimalToBinaryRecursive(3));


static string DecimalToBinaryRecursive(int decimalNumber)
{
    if (decimalNumber < 2) return decimalNumber.ToString();

    int digit = decimalNumber % 2;
    int rest = decimalNumber / 2;
    string partialSolution = DecimalToBinaryRecursive(rest);
    return partialSolution + digit.ToString();
}

static string EncryptWithCaesar(string input, int offset)
{
    string alphabet = "abcdefghijklmnopqrstuvwxyz";
    string result = "";
    offset = offset < 0 ? alphabet.Length + offset : offset;

    foreach (char c in input)
    {
        char lowerC = char.ToLower(c);

        if (!alphabet.Contains(lowerC))
        {
            result += c;
        }
        else
        {
            int alphabetIndex = lowerC - 'a';
            int nextIndex = (alphabetIndex + offset) % alphabet.Length;
            char encryptedLetter = alphabet[nextIndex];
            result += char.IsUpper(c) ? char.ToUpper(encryptedLetter) : encryptedLetter;
        }
    }

    return result;
}

static int[] DecimalToReversedIntArray(int number)
{
    int[] digits = new int[number.ToString().Length];
    int index = 0;

    do
    {
        int lastDigit = number % 10;
        number = number / 10;
        digits[index++] = lastDigit;
    }
    while (number > 0);

    return digits;
}
