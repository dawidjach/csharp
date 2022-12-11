using System.Text;

PlayGame();

static void PlayGame()
{
    string choice;

    do
    {
        PlayRound();
        choice = ConsoleUtils.ReadString(
            "Noch einmal spielen (ja/nein)",
            new string[] { "j", "n", "ja", "nein" });
    }
    while (choice is "j" or "ja");
}

static void PlayRound()
{
    string solution = "hello".ToUpper();
    string partialSolution = new string('_', solution.Length);
    int failedAttempts = 0;
    const int maxAttempts = 10;

    while (solution != partialSolution && failedAttempts < maxAttempts)
    {
        PrintWord(partialSolution);
        char letter = ReadLetter("Buchstabe eingeben");
        if (partialSolution.Contains(letter))
        {
            Console.WriteLine("Den Buchstaben hast du doch schon aufgedeckt. Schussel!");
            failedAttempts++;
        }
        else if (solution.Contains(letter))
        {
            Console.WriteLine("Buchstabe richtig erraten.");
            partialSolution = RevealLetter(letter, partialSolution, solution);
        }
        else
        {
            Console.WriteLine("Buchstabe ist nicht enthalten!");
            failedAttempts++;
        }
    }

    if (solution == partialSolution)
    {
        Console.WriteLine($"Glückwunsch! Du hast das Wort {solution} erraten");
        Console.WriteLine($"Du hattest {failedAttempts} Fehlversuche.");
    }
    else
    {
        Console.WriteLine($"Du hast leider verloren. Das Lösungswort war {solution}.");
    }
}

// PrintWord("abc") -> A B C
static void PrintWord(string word)
{
    word = word.ToUpper();
    string joinedChars = string.Join(' ', word.ToCharArray());
    Console.WriteLine(joinedChars);
}

static char ReadLetter(string prompt)
{
    while (true)
    {
        Console.Write($"{prompt}: ");
        string line = Console.ReadLine()!.ToUpper().Trim();
        if (line.Length == 1 && char.IsLetter(line[0]))
        {
            return line[0];
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe. Erneut versuchen");
        }
    }
}

static string RevealLetter(char letter, string partialSolution, string solution)
{
    StringBuilder newPartialSolution = new(partialSolution);

    for (int i = 0; i < solution.Length; i++)
    {
        char letterAtIndex = solution[i];
        if (letterAtIndex == letter)
        {
            newPartialSolution[i] = letter;
        }
    }
    return newPartialSolution.ToString();
}
