using System;
/* LinkedIn Learning Challenge Question
For this challenge, you will write some code that determines the type of an argument that is passed to your function.
In .NET, all data types are essentially objects and are subclasses of the base object class.

Task: Return True if the Arg Argument's Type is the same as teh TypeToCount

Parameters: 
Arg: An object that will be one of integer, char,string, double, or boolean
TypeToCount: A string description of the type of interest

*/
public class Answer {
    // Change these Boolean values to control whether you see 
    // the expected result and/or hints.
    public  static Boolean ShowExpectedResult = false;
    public  static Boolean ShowHints = false;

    public static bool CountTheType(object Arg, string TypeToCount) {
        if (Arg.GetType().ToString() == TypeToCount){
            return true;
        }
        // Your code goes here. Return true if the type of the Arg is the same
        // as what the TypeToCount parameter says to count.
        return false;
    }
}

object[] items = {1, 2, "Hello!", "World", 'X', true, 2.0, ".NET", 'A'};
int total = 0;
string CountType = "System.String";
foreach (object item in items) {
    if (Answer.CountTheType(item, CountType)) {
		total++;
	}
}

