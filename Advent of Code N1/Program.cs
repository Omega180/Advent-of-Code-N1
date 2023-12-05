// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string fileName = "C:\\Users\\Omga\\source\\repos\\Advent of Code N1\\Advent of Code N1\\bin\\Debug\\net8.0\\input.txt";

List<string> lines = new List<string>();

using (StreamReader sr = new StreamReader(fileName))
{
    string line;
    while ((line = sr.ReadLine()) != null)
    {
        lines.Add(line);
    }
}
string patternForTextAndNumbers = @"(?:(zero)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|([0-9]))";
string endPattern = @"(?:(zero)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|([0-9]))$";
int totalValue = 0;
string checkWord(string word)
{
    switch (word)
    {
        case ("zero"):
            return "0";
            break;
        case ("one"):
            return "1";
            break;
        case ("two"):
            return "2";
            break;
        case ("three"):
            return "3";
            break;
        case ("four"):
            return "4";
            break;
        case ("five"):
            return "5";
            break;
        case ("six"):
            return "6";
            break;
        case ("seven"):
            return "7";
            break;
        case ("eight"):
            return "8";
            break;
        case ("nine"):
            return "9";
            break;
    }
    return word;
}
for (int i = 0; i < lines.Count; i++)
{
    string singleLine = lines[i];
    string firstLine = "";
    string secondLine = "";
    MatchCollection matchCollection = Regex.Matches(singleLine, patternForTextAndNumbers);
    MatchCollection EndValue = Regex.Matches(singleLine, endPattern);
    firstLine = matchCollection[0].Value;
    secondLine = matchCollection[matchCollection.Count - 1].Value;
    string filteredFirstLine = checkWord(firstLine);
    string filteredSecondLine;
    if (EndValue.Count > 1)
    {
        filteredSecondLine = checkWord(EndValue[matchCollection.Count - 1].Value);
    }
    else
    {
        filteredSecondLine = checkWord(secondLine);
    }

        lines[i] = filteredFirstLine + filteredSecondLine;
    string fullString = lines[i].Substring(0, 1) + lines[i].Substring((lines[i].Length - 1), 1);
    totalValue = totalValue + Convert.ToInt16(fullString);
}

Console.WriteLine(totalValue);