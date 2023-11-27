using System;

public class ReverseJokes
{


    public string reverseFile()
    {
        string jokes = readFile();

        Stack<char> myStack = new Stack<char>();

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < jokes.Length; i++)
        {
            char c = jokes[i];

            if (Char.IsWhiteSpace(c))
            {
               while (myStack.count != 0)
                {
                    builder.append(myStack.Pop());
                }
                builder.append(" ");
            }
            else
            {
                myStack.Push(c);
            }
           
        }
    }

    public void writeFile(string text)
    {
        string filePath = "C:\\Users\\Yisrael\\Downloads\\norrisjokesreversed.txt";

        try
        {
            using (StreamWriter sw = new StreamWriter(filePath)) 
            {
                sw.WriteLine(text); 
            }
            Console.WriteLine("Text has been written to the file.");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be written to:");
            Console.WriteLine(e.Message);
        }
    }


    public String readFile()
	{

        string filePath = "C:\\Users\\Yisrael\\Downloads\\norrisjokes.txt"; 

        try
        {
            // Open the file for reading using a StreamReader
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Read the entire file
                string fileContent = sr.ReadToEnd();
                return fileContent; 
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            return null;
        }


    }

    public static void Main(string[] args)
    {
        ReverseJokes reverseJokes = new ReverseJokes();
        string reversedText = reverseJokes.reverseFile();
        reverseJokes.writeFile(reversedText);
    }
}
