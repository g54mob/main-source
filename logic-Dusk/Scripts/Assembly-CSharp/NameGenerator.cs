using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public static class NameGenerator
{
	private static List<string> systemNameListUnsorted = new List<string>();

	private static List<string> systemNameListSorted = new List<string>();

	private static List<string> galaxyNameListUnsorted = new List<string>();

	private static List<string> galaxyNameListSorted = new List<string>();

	private static List<string> derelictNameListUnsorted = new List<string>();

	private static List<string> derelictNameListSorted = new List<string>();

	private static List<string> outpostNameListUnsorted = new List<string>();

	private static List<string> outpostNameListSorted = new List<string>();

	private static bool isSystemNameListInitialized = false;

	private static bool isGalaxyNameListInitialized = false;

	private static bool isDerelictNameListInitialized = false;

	private static bool isOutpostNameListInitialized = false;

	private static int listPositionSystem = -1;

	private static int listPositionSystemLoopCount = 0;

	private static int listPositionGalaxy = -1;

	private static int listPositionGalaxyLoopCount = 0;

	private static int listPositionDerelict = -1;

	private static int listPositionDerelictLoopCount = 0;

	private static int listPositionOutpost = -1;

	private static int listPositionOutpostLoopCount = 0;

	public static void ShuffleSystemNames()
	{
		if (!isSystemNameListInitialized)
		{
			isSystemNameListInitialized = LoadNames("SystemNames", systemNameListUnsorted, systemNameListSorted);
		}
		if (!isSystemNameListInitialized)
		{
			return;
		}
		int num = 0;
		int num2 = systemNameListUnsorted.Count * systemNameListUnsorted.Count;
		systemNameListSorted.Clear();
		do
		{
			int index = Random.Range(0, systemNameListUnsorted.Count);
			if (!systemNameListSorted.Contains(systemNameListUnsorted[index]))
			{
				systemNameListSorted.Add(systemNameListUnsorted[index]);
			}
			else
			{
				num++;
			}
		}
		while (num < num2 && systemNameListSorted.Count != systemNameListUnsorted.Count);
		listPositionSystem = -1;
		listPositionSystemLoopCount = 0;
	}

	public static string NextSystemName()
	{
		if (!isSystemNameListInitialized)
		{
			ShuffleSystemNames();
		}
		string empty = string.Empty;
		do
		{
			listPositionSystem++;
			if (listPositionSystem >= systemNameListSorted.Count)
			{
				listPositionSystem = 0;
				listPositionSystemLoopCount++;
			}
			empty = systemNameListSorted[listPositionSystem];
		}
		while (empty == null || string.IsNullOrEmpty(empty));
		if (listPositionSystemLoopCount > 0)
		{
			empty = string.Format("{0} {1}", empty, listPositionSystemLoopCount + 1);
		}
		return empty;
	}

	public static void ShuffleGalaxyNames()
	{
		if (!isGalaxyNameListInitialized)
		{
			isGalaxyNameListInitialized = LoadNames("GalaxyNames", galaxyNameListUnsorted, galaxyNameListSorted);
		}
		if (!isGalaxyNameListInitialized)
		{
			return;
		}
		int num = 0;
		int num2 = galaxyNameListUnsorted.Count * galaxyNameListUnsorted.Count;
		galaxyNameListSorted.Clear();
		do
		{
			int index = Random.Range(0, galaxyNameListUnsorted.Count);
			if (!galaxyNameListSorted.Contains(galaxyNameListUnsorted[index]))
			{
				galaxyNameListSorted.Add(galaxyNameListUnsorted[index]);
			}
			else
			{
				num++;
			}
		}
		while (num < num2 && galaxyNameListSorted.Count != galaxyNameListUnsorted.Count);
		listPositionGalaxy = -1;
		listPositionGalaxyLoopCount = 0;
	}

	public static string NextGalaxyName()
	{
		if (!isGalaxyNameListInitialized)
		{
			ShuffleGalaxyNames();
		}
		string empty = string.Empty;
		do
		{
			listPositionGalaxy++;
			if (listPositionGalaxy >= galaxyNameListSorted.Count)
			{
				listPositionGalaxy = 0;
				listPositionGalaxyLoopCount++;
			}
			empty = galaxyNameListSorted[listPositionGalaxy];
		}
		while (empty == null || string.IsNullOrEmpty(empty));
		if (listPositionGalaxyLoopCount > 0)
		{
			empty = string.Format("{0} {1}", empty, listPositionGalaxyLoopCount + 1);
		}
		return empty;
	}

	public static void ShuffleDerelictNames()
	{
		if (!isDerelictNameListInitialized)
		{
			isDerelictNameListInitialized = LoadNames("ShipNames", derelictNameListUnsorted, derelictNameListSorted);
		}
		if (!isDerelictNameListInitialized)
		{
			return;
		}
		int num = 0;
		int num2 = derelictNameListUnsorted.Count * derelictNameListUnsorted.Count;
		derelictNameListSorted.Clear();
		List<string> list = new List<string>(derelictNameListUnsorted.Count);
		int count = derelictNameListUnsorted.Count;
		for (int i = 0; i < count; i++)
		{
			list.Add(derelictNameListUnsorted[i]);
		}
		do
		{
			int index = Random.Range(0, list.Count);
			string text = list[index];
			if (!ContainsLoop(derelictNameListSorted, text))
			{
				derelictNameListSorted.Add(text);
				list.RemoveAt(index);
			}
			else
			{
				num++;
			}
		}
		while (num < num2 && derelictNameListSorted.Count != derelictNameListUnsorted.Count);
		listPositionDerelict = -1;
		listPositionDerelictLoopCount = 0;
	}

	private static bool ContainsLoop(List<string> lst, string name)
	{
		if (name == string.Empty)
		{
			return false;
		}
		int count = lst.Count;
		char c = name[0];
		for (int i = 0; i < count; i++)
		{
			string text = lst[i];
			if (text.Length == name.Length && text[0] == c && text == name)
			{
				return true;
			}
		}
		return false;
	}

	public static string NextDerelictName()
	{
		if (!isDerelictNameListInitialized)
		{
			ShuffleDerelictNames();
		}
		string empty = string.Empty;
		do
		{
			listPositionDerelict++;
			if (listPositionDerelict >= derelictNameListSorted.Count)
			{
				listPositionDerelict = 0;
				listPositionDerelictLoopCount++;
			}
			empty = derelictNameListSorted[listPositionDerelict];
		}
		while (empty == null || string.IsNullOrEmpty(empty));
		if (listPositionDerelictLoopCount > 0)
		{
			empty = string.Format("{0} {1}", empty, listPositionDerelictLoopCount + 1);
		}
		return empty;
	}

	public static void ShuffleOutpostNames()
	{
		if (!isOutpostNameListInitialized)
		{
			isOutpostNameListInitialized = LoadNames("OutpostNames", outpostNameListUnsorted, outpostNameListSorted);
		}
		if (!isOutpostNameListInitialized)
		{
			return;
		}
		int num = 0;
		int num2 = outpostNameListUnsorted.Count * outpostNameListUnsorted.Count;
		outpostNameListSorted.Clear();
		List<string> list = new List<string>(outpostNameListUnsorted.Count);
		int count = outpostNameListUnsorted.Count;
		for (int i = 0; i < count; i++)
		{
			list.Add(outpostNameListUnsorted[i]);
		}
		do
		{
			int index = Random.Range(0, list.Count);
			string name = list[index];
			if (!ContainsLoop(outpostNameListSorted, name))
			{
				outpostNameListSorted.Add(list[index]);
				list.RemoveAt(index);
			}
			else
			{
				num++;
			}
		}
		while (num < num2 && outpostNameListSorted.Count != outpostNameListUnsorted.Count);
		listPositionOutpost = -1;
		listPositionOutpostLoopCount = 0;
	}

	public static string NextOutpostName()
	{
		if (!isOutpostNameListInitialized)
		{
			ShuffleOutpostNames();
		}
		string empty = string.Empty;
		do
		{
			listPositionOutpost++;
			if (listPositionOutpost >= outpostNameListSorted.Count)
			{
				listPositionOutpost = 0;
				listPositionOutpostLoopCount++;
			}
			empty = outpostNameListSorted[listPositionOutpost];
		}
		while (empty == null || string.IsNullOrEmpty(empty));
		if (listPositionOutpostLoopCount > 0)
		{
			empty = string.Format("{0} {1}", empty, listPositionOutpostLoopCount + 1);
		}
		return empty;
	}

	private static bool LoadNames(string fileNameNoExt, List<string> unsortedList, List<string> sortedList)
	{
		unsortedList.Clear();
		sortedList.Clear();
		TextAsset textAsset = (TextAsset)Resources.Load(string.Format("Data/{0}", fileNameNoExt));
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes(string.Format("//{0}/name", fileNameNoExt));
		foreach (XmlNode item in xmlNodeList)
		{
			string text = item.Attributes["value"].Value.Trim();
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace(":", "*");
				text = text.Replace(";", "*");
				text = text.Replace("=", "*");
				unsortedList.Add(text);
			}
		}
		sortedList.AddRange(unsortedList);
		return true;
	}
}
