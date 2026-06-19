using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CSVReader
{
	public static string[] cachedCsvLineArray = null;

	private static char currentParsedCharacter;

	private const char quoteChar = '"';

	private static StringBuilder staticStringBuilder = new StringBuilder();

	public static void DebugOutputGrid(string[,] grid)
	{
		string text = "";
		for (int i = 0; i < grid.GetUpperBound(1); i++)
		{
			for (int j = 0; j < grid.GetUpperBound(0); j++)
			{
				text += grid[j, i];
				text += "|";
			}
			text += "\n";
		}
	}

	public static Dictionary<string, List<string>> SplitCsvDict(string csvText, int overrideColumnCount = 0, bool debug = false)
	{
		string[,] array = SplitCsvGrid(csvText, cutQuotes: true, overrideColumnCount);
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		if (debug && Application.isEditor)
		{
			DebugOutputGrid(array);
		}
		for (int i = 0; i < array.GetLength(1); i++)
		{
			List<string> list = new List<string>();
			string text = "";
			if (array[0, i] != null)
			{
				text = array[0, i].ToUpperInvariant();
				for (int j = 1; j < array.GetLength(0); j++)
				{
					string.IsNullOrEmpty(array[j, i]);
					list.Add(array[j, i]);
				}
				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text) && !dictionary.ContainsKey(text))
				{
					dictionary.Add(text, list);
				}
			}
		}
		return dictionary;
	}

	public static string[,] SplitCsvGrid(string csvText, bool cutQuotes = true, int overrideColumnCount = 0)
	{
		csvText = csvText.Replace("\n", "");
		csvText = csvText.Replace("\\n", "\n");
		string[] array = csvText.Replace("\r", "").Split(new string[4] { ",ENDLINE,", ",ENDLINE", "ENDLINE,", "ENDLINE" }, StringSplitOptions.None);
		int a = overrideColumnCount;
		cachedCsvLineArray = new string[GetCsvLineLength(array[0])];
		a = Mathf.Max(a, cachedCsvLineArray.Length);
		string[,] array2 = new string[a + 1, array.Length + 1];
		for (int i = 0; i < array.Length; i++)
		{
			SplitCsvLine(array[i], cachedCsvLineArray, cutQuotes);
			for (int j = 0; j < a; j++)
			{
				array2[j, i] = cachedCsvLineArray[j];
			}
		}
		return array2;
	}

	public static void SplitCsvLine(string line, string[] output, bool cutQuotes = true)
	{
		int num = 0;
		int num2 = -1;
		line = ReplaceUnQuotedChars(line, ',', '|');
		for (int i = 0; i < line.Length; i++)
		{
			if (num == output.Length)
			{
				break;
			}
			if (line[i].Equals('|'))
			{
				if (i - num2 - 1 == 0)
				{
					output[num] = "";
				}
				else
				{
					output[num] = line.Substring(num2 + 1, i - num2 - 1);
				}
				num++;
				num2 = i;
			}
		}
		int num3 = output.Length - 1;
		if (num <= num3)
		{
			output[num3] = line.Substring(num2 + 1, line.Length - num2 - 1);
			num++;
		}
		if (cutQuotes)
		{
			for (int j = 0; j < output.Length; j++)
			{
				output[j] = output[j].Trim('"');
			}
		}
	}

	public static int GetCsvLineLength(string line)
	{
		line = ReplaceUnQuotedChars(line, ',', '|');
		return line.Split('|').Length;
	}

	public static string[] SplitCsvLine(string line, bool cutQuotes = true)
	{
		line = ReplaceUnQuotedChars(line, ',', '|');
		string[] array = line.Split('|');
		if (cutQuotes)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim('"');
			}
		}
		return array;
	}

	private static string ReplaceUnQuotedChars(string line, char original, char replace)
	{
		staticStringBuilder.Clear();
		bool flag = false;
		for (int i = 0; i < line.Length; i++)
		{
			currentParsedCharacter = line[i];
			if (currentParsedCharacter.Equals('"'))
			{
				flag = !flag;
			}
			else if (!flag && currentParsedCharacter.Equals(original))
			{
				staticStringBuilder.Append(replace);
			}
			else
			{
				staticStringBuilder.Append(currentParsedCharacter);
			}
		}
		return staticStringBuilder.ToString();
	}
}
