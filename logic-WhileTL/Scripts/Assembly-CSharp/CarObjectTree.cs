using System.Collections.Generic;
using ReinforcementLearning.Environment;
using UnityEngine;

public static class CarObjectTree
{
	public const string emptyName = "empty";

	public const string carName = "car";

	public const string wallName = "wall";

	public const string unknownName = "unknown";

	public const string objectName = "object";

	private static Dictionary<string, int> nameToCodeDict = new Dictionary<string, int>();

	private static Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

	public static Dictionary<string, Sprite> smallCarObjectSprite = new Dictionary<string, Sprite>();

	public static Dictionary<string, Sprite> bigCarObjectSprite = new Dictionary<string, Sprite>();

	public static Dictionary<string, Sprite> emptyCarObjectSprite = new Dictionary<string, Sprite>();

	public static Dictionary<string, string> parentsDict = new Dictionary<string, string>();

	public static Dictionary<int, string> codeToNameDict = new Dictionary<int, string>();

	private static bool inited = false;

	public static void Init()
	{
		if (!inited)
		{
			inited = true;
			InitLeafs();
			BuildTree();
			LoadSprites();
		}
	}

	private static void InitLeafs()
	{
		nameToCodeDict["empty"] = 1;
		nameToCodeDict["car"] = 2;
		nameToCodeDict["wall"] = 4;
		codeToNameDict[1] = "empty";
		codeToNameDict[2] = "car";
		codeToNameDict[4] = "wall";
	}

	private static void BuildTree()
	{
		Logic.GetCarObjectTreeHierarchy().ForEach(delegate(CarObjectTreeHierarchy x)
		{
			if (x.KeyName != x.parent)
			{
				if (!adjacencyList.ContainsKey(x.parent))
				{
					adjacencyList[x.parent] = new List<string>();
				}
				adjacencyList[x.parent].Add(x.KeyName);
				parentsDict[x.KeyName] = x.parent;
			}
		});
		Dfs("unknown");
	}

	private static void Dfs(string vertexName)
	{
		if (!adjacencyList.ContainsKey(vertexName))
		{
			return;
		}
		adjacencyList[vertexName].ForEach(delegate(string childName)
		{
			Dfs(childName);
			if (!nameToCodeDict.ContainsKey(vertexName))
			{
				nameToCodeDict[vertexName] = 0;
			}
			nameToCodeDict[vertexName] |= nameToCodeDict[childName];
		});
		codeToNameDict[nameToCodeDict[vertexName]] = vertexName;
	}

	private static void LoadSprites()
	{
		Logic.GetCarObjectTreeHierarchy().ForEach(delegate(CarObjectTreeHierarchy x)
		{
			smallCarObjectSprite[x.KeyName] = Logic.LoadSprite(x.smallSpriteName);
			bigCarObjectSprite[x.KeyName] = Logic.LoadSprite(x.bigSpriteName);
			emptyCarObjectSprite[x.KeyName] = Logic.LoadSprite(x.emptySpriteName);
		});
	}

	private static int GetCodeByCellObject(CellObjects obj)
	{
		return obj switch
		{
			CellObjects.empty => 1, 
			CellObjects.car => 2, 
			CellObjects.wall => 4, 
			_ => 0, 
		};
	}

	public static string GetNameByCellObject(CellObjects obj)
	{
		return obj switch
		{
			CellObjects.empty => "empty", 
			CellObjects.car => "car", 
			CellObjects.wall => "wall", 
			_ => "unknown", 
		};
	}

	public static IEnumerator<string> MoveToRoot(string nodeName)
	{
		if (!(nodeName == "unknown"))
		{
			yield return parentsDict[nodeName];
		}
	}

	public static IEnumerator<string> MoveToRoot(CellObjects obj)
	{
		return MoveToRoot(GetNameByCellObject(obj));
	}

	public static int GetCodeByName(string name)
	{
		if (!nameToCodeDict.ContainsKey(name))
		{
			return 0;
		}
		return nameToCodeDict[name];
	}

	public static string Step(string curNode, CellObjects trueObject)
	{
		string result = "unknown";
		if (!adjacencyList.ContainsKey(curNode))
		{
			return result;
		}
		adjacencyList[curNode].ForEach(delegate(string x)
		{
			int num = nameToCodeDict[x];
			if (num == (num | GetCodeByCellObject(trueObject)))
			{
				result = x;
			}
		});
		return result;
	}

	public static string GetNameByCode(int code)
	{
		return codeToNameDict[code];
	}
}
