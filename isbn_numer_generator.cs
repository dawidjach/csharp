switch (args)
{
    case { Length: 1 } when args[0] is "generate":
        Generate();
        break;

    case { Length: 2 } when args[0] is "validate":
        Validate(args[1]);
        break;

    default:
        Console.WriteLine("Usage: ");
        Console.WriteLine("generate        -- Generates ISBN-13");
        Console.WriteLine("validate <ISBN> -- Validates an ISBN-13");
        break;
}

static void Validate(string formattedIsbn)
{
    formattedIsbn = formattedIsbn.Replace("-", "");
    int sum = 0;
    for (int i = 0; i < formattedIsbn.Length; i++)
    {
        int digit = int.Parse(formattedIsbn[i].ToString());
        sum += (i % 2 == 0) ? digit : 3 * digit;
    }

    Console.WriteLine("{0}", sum % 10 == 0 ? "valid" : "invalid");
}

static void Generate()
{
    Random generator = new();

    int[] isbn = new int[13];
    int sum = 0;
    for (int i = 0; i < isbn.Length - 1; i++)
    {
        int randomDigit = generator.Next(0, 9);
        isbn[i] = randomDigit;
        sum += (i % 2 == 0) ? randomDigit : 3 * randomDigit;
    }

    int lastDigit = sum % 10;
    int checkDigit = lastDigit > 0 ? 10 - lastDigit : 0;
    isbn[^1] = checkDigit;

    string formattedIsbn = string.Format("{0}-{1}-{2}-{3}-{4}",
        string.Join("", isbn[..3]),
        isbn[3].ToString(),
        string.Join("", isbn[4..9]),
        string.Join("", isbn[9..12]),
        isbn[12].ToString());

    Console.WriteLine(formattedIsbn);
}
