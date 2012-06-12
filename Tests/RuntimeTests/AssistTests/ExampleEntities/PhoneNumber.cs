using System;
using System.Text.RegularExpressions;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests.ExampleEntities
{
    public class PhoneNumber
    {
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public string Number { get; set; }

        public static PhoneNumber Parse(string text)
        {
            var match = Regex.Match(text, @"^\+(?<country>\d+) (?<area>\d+) (?<number>.+)$");
            if(!match.Success) throw new FormatException("Incorrect format for a phone number");

            return new PhoneNumber
                {
                    CountryCode = int.Parse(match.Groups["country"].Value),
                    AreaCode = int.Parse(match.Groups["area"].Value),
                    Number = match.Groups["number"].Value
                };
        }
    }
}