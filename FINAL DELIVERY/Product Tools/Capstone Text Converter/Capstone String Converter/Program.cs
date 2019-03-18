//Capstone String converter
//by Richard kimsey
//   3/26/2018


//HOW TO USE:
//1 - copy and paste a table's field into input.txt
//2 - run the program
//3 - the numbers from that field will go into three output files, one for each number
//4 - copy and paste the output back into the table

//for example, an entry might be "41.5mm  - 47.5mm"
//after running this program, the first output file would have 41.5
//the second would have 47.5
//and the third would be an empty string for this entry

//there are some things to watch out for:
//some data uses a european style decimal point, using a comma instead of a period
//this program won't read this correctly
//there are probably other potential errors like this
//double check the output to make sure there are no errors!!!



using System;
using System.IO;
using System.Collections;


class Program
{
	public static void Main(string[] args)
	{
		string fileText = System.IO.File.ReadAllText("input.txt");
		StringReader strReader = new StringReader(fileText);
		
		ArrayList n1 = new ArrayList();
		ArrayList n2 = new ArrayList();
		ArrayList n3 = new ArrayList();
		int currentNum = 0;
		
		strReader.ReadLine(); //skip the first line
		string line = strReader.ReadLine();
		
		while (line != null)
		{
			n1.Add(readNumber(ref line));
			n2.Add(readNumber(ref line));
			n3.Add(readNumber(ref line));
			
			line = strReader.ReadLine();
		}
		
		string[] output = n1.ToArray(typeof(string)) as string[];
		System.IO.File.WriteAllLines("output1.txt", output);
		
		output = n2.ToArray(typeof(string)) as string[];
		System.IO.File.WriteAllLines("output2.txt", output);
		
		output = n3.ToArray(typeof(string)) as string[];
		System.IO.File.WriteAllLines("output3.txt", output);
		
		Console.WriteLine("Done");
		Console.ReadLine();
	}
	
	public static string readNumber(ref string line)
	{
		if (line == "")
		{
			return "";
		}
		
		string num = "";
		char c = line[0];
		while( !((c >= '0' && c <= '9') || c == '.') ) //while c is not a number or decimal
		{
			line = line.Remove(0, 1);
			
			if (line == "")
			{
				return "";
			}
			
			c = line[0];
		}
		
		while((c >= '0' && c <= '9') || c == '.')  //while c is a number or decimal
		{
			num += c;
			
			line = line.Remove(0, 1);
			if (line == "")
			{
				break;
			}
			c = line[0];
		}
		
		return num;
	}
}