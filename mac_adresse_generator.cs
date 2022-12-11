var randomNumberGenerator = new Random();
//string[] octetStrings = new string[6];
int numberOfAddresses = 1;

if (args.Length > 0)
{
    numberOfAddresses = int.Parse(args[0]);
}

//for (int j = 0; j < numberOfAddresses; j++)
//{
//	for (int i = 0; i < octetStrings.Length; ++i)
//	{
//		int octet = randomNumberGenerator.Next(0, 255);
//		octetStrings[i] = octet.ToString("X2");
//	}

//	Console.WriteLine(string.Join(":", octetStrings)); 
//}


for (int i = 0; i < numberOfAddresses; i++)
{
    string macAddress = "";
    for (int j = 0; j < 6; ++j)
    {
        int octet = randomNumberGenerator.Next(0, 255);
        macAddress += octet.ToString("X2");
        if (j < 5)
        {
            macAddress += ":";
        }
    }
    Console.WriteLine(macAddress);
}
