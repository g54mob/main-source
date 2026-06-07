using System;
using System.Collections.Generic;
using System.Threading;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "LocResources", menuName = "ScriptableObjects/LocResources", order = 1)]
public class LocResources : SerializedScriptableObject
{
	[HideInInspector]
	public string[][] LocTable;

	public TextAsset CharacterSet;

	public List<LanguageCharacterSet> LanguageCharacterSets = new List<LanguageCharacterSet>();

	public const string spreadsheetId = "1_rDRA3tQX-UjBa_Yy8Prm4KPo_OY6jLwZKx6uTofLr0";

	public static LocResources Default => Resources.Load<LocResources>("Localization/LocResources");

	private static string defaultCharacterSet => Resources.Load<TextAsset>("Localization/DefaultCharSet").text;

	public int GetLanguageColumnIndex(string language)
	{
		for (int i = 0; i < LocTable[0].Length; i++)
		{
			if (LocTable[0][i] == language)
			{
				return i;
			}
		}
		Debug.LogError("No column exists for " + language);
		return -1;
	}

	private string[][] ParseTableFromTsv(string tsv)
	{
		string[] array = tsv.Split('\n');
		string[][] array2 = new string[array.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			text = text.Replace("\r", "");
			text = text.Replace("#", "\n");
			array2[i] = text.Split('\t');
		}
		Debug.Log($"Loaded {array.Length - 1} rows");
		return array2;
	}

	public void LoadLocData()
	{
		string tsv = LoadTsvFromGoogleSheets();
		LocTable = ParseTableFromTsv(tsv);
	}

	public void WriteCharacterSets()
	{
		string characterSet = GetCharacterSet();
		WriteStringToTextAsset(CharacterSet, characterSet);
		foreach (LanguageCharacterSet languageCharacterSet in LanguageCharacterSets)
		{
			WriteStringToTextAsset(languageCharacterSet.TargetFile, GetCharacterSetForLanguage(languageCharacterSet.LanguageName));
		}
	}

	private static void WriteStringToTextAsset(TextAsset asset, string content)
	{
	}

	private string GetCharacterSetForLanguage(string language)
	{
		HashSet<char> hashSet = new HashSet<char>();
		string text = defaultCharacterSet;
		foreach (char item in text)
		{
			if (!hashSet.Contains(item))
			{
				hashSet.Add(item);
			}
		}
		int languageColumnIndex = GetLanguageColumnIndex(language);
		for (int j = 0; j < LocTable.GetLength(0); j++)
		{
			string text2 = LocTable[j][languageColumnIndex];
			for (int k = 0; k < text2.Length; k++)
			{
				if (!hashSet.Contains(text2[k]))
				{
					hashSet.Add(text2[k]);
				}
			}
		}
		string text3 = "";
		foreach (char item2 in hashSet)
		{
			text3 += item2;
		}
		return text3;
	}

	private string GetCharacterSet()
	{
		HashSet<char> hashSet = new HashSet<char>();
		string text = defaultCharacterSet;
		foreach (char item in text)
		{
			if (!hashSet.Contains(item))
			{
				hashSet.Add(item);
			}
		}
		for (int j = 0; j < LocTable.GetLength(0); j++)
		{
			for (int k = 0; k < LocTable[j].GetLength(0); k++)
			{
				string text2 = LocTable[j][k];
				for (int l = 0; l < text2.Length; l++)
				{
					if (!hashSet.Contains(text2[l]))
					{
						hashSet.Add(text2[l]);
					}
				}
			}
		}
		string text3 = "";
		foreach (char item2 in hashSet)
		{
			text3 += item2;
		}
		return text3;
	}

	private static string LoadTsvFromGoogleSheets()
	{
		UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = UnityWebRequest.Get("https://docs.google.com/spreadsheets/u/0/d/1_rDRA3tQX-UjBa_Yy8Prm4KPo_OY6jLwZKx6uTofLr0/export?format=tsv").SendWebRequest();
		int num = 0;
		while (!unityWebRequestAsyncOperation.isDone)
		{
			Thread.Sleep(100);
			num += 100;
			if (num >= 5000)
			{
				throw new Exception("Sheets call timed out. Please check your internet connection");
			}
		}
		return unityWebRequestAsyncOperation.webRequest.downloadHandler.text;
	}
}
