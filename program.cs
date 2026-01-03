using System;
using System.Text.RegularExpressions;

Console.WriteLine("Palindrome Checker Service (Console Mode)");
Console.WriteLine("Enter text (or type 'exit' to quit):");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    string normalized = Regex.Replace(input.ToLower(), "[^a-z0-9]", "");
    bool isPalindrome = normalized == new string(normalized.Reverse().ToArray());

    string longest = FindLongestPalindrome(input);

    Console.WriteLine("Result:");
    Console.WriteLine($"Text              : {input}");
    Console.WriteLine($"Is Palindrome     : {isPalindrome}");
    Console.WriteLine($"Longest Palindrome: {longest}");
    Console.WriteLine($"Length            : {longest.Length}");
    Console.WriteLine();
}



static string FindLongestPalindrome(string s)
{
    if (string.IsNullOrEmpty(s)) return "";

    int start = 0, maxLen = 1;

    for (int i = 0; i < s.Length; i++)
    {
        Expand(s, i, i, ref start, ref maxLen);
        Expand(s, i, i + 1, ref start, ref maxLen);
    }

    return s.Substring(start, maxLen);
}

static void Expand(string s, int left, int right, ref int start, ref int maxLen)
{
    while (left >= 0 && right < s.Length && s[left] == s[right])
    {
        int len = right - left + 1;
        if (len > maxLen)
        {
            start = left;
            maxLen = len;
        }
        left--;
        right++;
    }
}
