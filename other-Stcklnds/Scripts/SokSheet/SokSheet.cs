using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "SokSheet", menuName = "ScriptableObjects/SokSheet", order = 1)]
public class SokSheet : ScriptableObject
{
	public string SheetId = "1PTo8bPVILAnhirTtNvP_Llha8fW7peURM6szY0cH_As";

	private string[][] _table;

	public bool LoadSpecificTab;

	public string TabGid = "0";

	public string Tsv;

	public string[][] Table
	{
		get
		{
			if (_table == null)
			{
				_table = ParseTableFromTsv(Tsv);
			}
			return _table;
		}
	}

	public void LoadSheetData()
	{
		Tsv = LoadTsvFromGoogleSheets(SheetId, LoadSpecificTab ? TabGid : "0");
		_table = ParseTableFromTsv(Tsv);
	}

	public string[] FindRow(string rowId)
	{
		for (int i = 0; i < Table.GetLength(0); i++)
		{
			if (Table[i][0] == rowId)
			{
				return Table[i];
			}
		}
		return null;
	}

	public int GetColumnIndex(string columnName)
	{
		for (int i = 0; i < Table[0].GetLength(0); i++)
		{
			if (Table[0][i] == columnName)
			{
				return i;
			}
		}
		Debug.LogError("No column found with name " + columnName);
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
			array2[i] = text.Split('\t');
		}
		Debug.Log($"Loaded {array.Length - 1} rows");
		return array2;
	}

	private static string LoadTsvFromGoogleSheets(string sheetId, string tabId)
	{
		UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = UnityWebRequest.Get("https://docs.google.com/spreadsheets/u/0/d/" + sheetId + "/export?format=tsv&gid=" + tabId).SendWebRequest();
		int num = 0;
		while (!unityWebRequestAsyncOperation.isDone)
		{
			Thread.Sleep(100);
			num += 100;
			if (num >= 5000)
			{
				return null;
			}
		}
		return unityWebRequestAsyncOperation.webRequest.downloadHandler.text;
	}
}
