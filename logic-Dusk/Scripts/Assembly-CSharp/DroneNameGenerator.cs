using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

public static class DroneNameGenerator
{
	private static List<string> _droneNameHistory = new List<string>(100);

	private static List<string> droneNameListUnsorted = new List<string>(50);

	private static List<string> droneNameListSorted = new List<string>(50);

	private static System.Random _randomGenForNames = new System.Random();

	private static bool isNameListInitialized = false;

	private static int listPosition = -1;

	public static void ShuffleNames()
	{
		if (!isNameListInitialized)
		{
			LoadNames();
		}
		int num = 0;
		int num2 = droneNameListUnsorted.Count * 4;
		int count = droneNameListUnsorted.Count;
		droneNameListSorted.Clear();
		do
		{
			int index = UnityEngine.Random.Range(0, count);
			if (!FastContains(droneNameListUnsorted[index]))
			{
				droneNameListSorted.Add(droneNameListUnsorted[index]);
			}
			else
			{
				num++;
			}
		}
		while (num < num2 || droneNameListSorted.Count != count);
		listPosition = -1;
	}

	private static bool FastContains(string name)
	{
		int count = droneNameListSorted.Count;
		int length = name.Length;
		for (int i = 0; i < count; i++)
		{
			string text = droneNameListSorted[i];
			if (text.Length == length && text[0] == name[0] && text == name)
			{
				return true;
			}
		}
		return false;
	}

	public static string Next()
	{
		if (!isNameListInitialized)
		{
			ShuffleNames();
		}
		listPosition++;
		if (listPosition >= droneNameListSorted.Count)
		{
			listPosition = 0;
		}
		return droneNameListSorted[listPosition];
	}

	public static string NextUnique()
	{
		int value = _randomGenForNames.Next(65, 91);
		return GetNextUniqueNameForAlpha(Convert.ToChar(value));
	}

	private static void LoadNames()
	{
		bool flag = false;
		if (File.Exists(GameFileHelper.DroneNameOverrideFullPath()))
		{
			string[] array = File.ReadAllLines(GameFileHelper.DroneNameOverrideFullPath());
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string text = array[i];
				if (text.Length <= 0)
				{
					continue;
				}
				char c = text[0];
				if (((c < 'A' || c > 'Z') && (c < 'a' || c > 'z')) || !ValidateNoSpecialCharacters(text))
				{
					continue;
				}
				bool flag2 = true;
				if ((c == 'a' || c == 'A' || c == 'd' || c == 'D' || c == 'r' || c == 'R') && text.Length > 1 && text[1] >= '0' && text[1] <= '9')
				{
					flag2 = false;
				}
				if (flag2)
				{
					if (text.Length < 10)
					{
						droneNameListUnsorted.Add(text);
					}
					else
					{
						droneNameListUnsorted.Add(text.Substring(0, 10));
					}
					flag = true;
				}
			}
		}
		else
		{
			FileStream fileStream = null;
			try
			{
				fileStream = File.Create(GameFileHelper.DroneNameOverrideFullPath());
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("Filed to create file!  Exception: {0}", ex.Message));
				return;
			}
			if (fileStream != null)
			{
				TextAsset textAsset = (TextAsset)Resources.Load("Data/dronenamesfile");
				try
				{
					byte[] bytes = Encoding.ASCII.GetBytes(Environment.NewLine);
					string[] array2 = textAsset.text.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					string[] array3 = array2;
					foreach (string text2 in array3)
					{
						string s = text2.Replace("\r", string.Empty);
						byte[] bytes2 = Encoding.UTF8.GetBytes(s);
						int count = bytes2.Length;
						fileStream.Write(bytes2, 0, count);
						fileStream.Write(bytes, 0, bytes.Length);
					}
				}
				catch (Exception ex2)
				{
					Debug.LogError(string.Format("Error while writing file!  Exception: {0}", ex2.Message));
					return;
				}
				finally
				{
					try
					{
						fileStream.Close();
					}
					catch (Exception)
					{
					}
				}
				LoadNames();
				return;
			}
		}
		if (!flag)
		{
			TextAsset textAsset2 = (TextAsset)Resources.Load("Data/DroneNames");
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(textAsset2.text);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//DroneNames/name");
			foreach (XmlNode item in xmlNodeList)
			{
				droneNameListUnsorted.Add(item.Attributes["value"].Value);
			}
		}
		droneNameListSorted.AddRange(droneNameListUnsorted);
		isNameListInitialized = true;
	}

	private static bool ValidateNoSpecialCharacters(string testString)
	{
		if (testString == null || testString == string.Empty)
		{
			return true;
		}
		int length = testString.Length;
		for (int i = 0; i < length; i++)
		{
			char c = testString[i];
			if (c == ';' || c == '|' || c == '=' || c == ',')
			{
				return false;
			}
		}
		return true;
	}

	public static void Reset()
	{
		isNameListInitialized = false;
		droneNameListUnsorted.Clear();
		droneNameListSorted.Clear();
	}

	private static string GetNextUniqueNameForAlpha(char startingCharacter)
	{
		string text = "fooo";
		switch (startingCharacter)
		{
		case 'A':
			text = "HAL";
			break;
		case 'B':
			text = "Brandon";
			break;
		case 'C':
			text = "Robby";
			break;
		case 'D':
			text = "Twiki";
			break;
		case 'E':
			text = "Ethan";
			break;
		case 'F':
			text = "Hailey";
			break;
		case 'G':
			text = "Jill";
			break;
		case 'H':
			text = "Holly";
			break;
		case 'I':
			text = "Ian";
			break;
		case 'J':
			text = "Jeremy";
			break;
		case 'K':
			text = "R2";
			break;
		case 'L':
			text = "Luke";
			break;
		case 'M':
			text = "Mouse";
			break;
		case 'N':
			text = "Marvin";
			break;
		case 'O':
			text = "Orson";
			break;
		case 'P':
			text = "Puck";
			break;
		case 'Q':
			text = "Qbert";
			break;
		case 'R':
			text = "Rick";
			break;
		case 'S':
			text = "Siren";
			break;
		case 'T':
			text = "Tim";
			break;
		case 'U':
			text = "Uber";
			break;
		case 'V':
			text = "Vinnie";
			break;
		case 'W':
			text = "Wally";
			break;
		case 'X':
			text = "Xeno";
			break;
		case 'Y':
			text = "Yule";
			break;
		case 'Z':
			text = "Zeke";
			break;
		default:
			Debug.LogError("Huh? Bad character for GetNextUniqueNameForAlpha?! - " + startingCharacter);
			break;
		}
		string uniqueName = text;
		int num = 2;
		while (_droneNameHistory.Any((string x) => x == uniqueName))
		{
			uniqueName = text + num++;
		}
		_droneNameHistory.Add(uniqueName);
		return uniqueName;
	}

	public static void ClearUniqueDroneNameHistory()
	{
		_droneNameHistory.Clear();
	}
}
