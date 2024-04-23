using System;
using System.Text;

/*
LinkedIN Course Challenge
Task: Determine whether the string is a palindrom based upon these rules: 
A Palindrom reads the same both forward and backwards, regardless of letter case
Examples: Radar and rotor are both palindromes
You must ignore spaces and punctuation

Parameters
 teststring: The string to test for palindrome
*/


public class Answer { 

    public static Boolean ShowExpectedResult = false; 
    public static Boolean ShowHints = false;

    public static bool IsPalindrome(string thestr){
        StringBuilder myStringBuilder = new StringBuilder();
        foreach(char c in thestr){
            if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c)){
                myStringBuilder.Append(c);
            }
        }
        // Convert to Lowercase
        string lowerCase = myStringBuilder.ToString().ToLower();
        // Convert to lowercase and reverse the string 
        StringBuilder reversed = new StringBuilder();
        for (int i = lowerCase.Length - 1; i >= 0; i--){
            reversed.Append(lowerCase[i]);
        };
        //Convert to string for comparison
        string reverse = reversed.ToString().ToLower();
        if (lowerCase == reverse){
            return true
        }
        
        return false;
    }
}


string[] teststrings = { "Hello World!", "Race car!", "Rotor", "More cowbell!", "Madam, I'm Adam." };
int palcount = 0;
foreach (string str in teststrings) {
	bool learnerResult = Answer.IsPalindrome(str);
	if (learnerResult)
		palcount++;
}

