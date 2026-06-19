using System.Collections.Generic;
using UnityEngine;

public class BuildableManager : MonoBehaviour
{
	private List<ulong> emptyList = new List<ulong>();

	private string basePath = "BuildObjects/";

	private string pensPath = "Pens/";

	private string pipesPath = "Pipes/";

	private string floorObjectsPath = "FloorObjects/";

	private string miscPath = "Misc/";

	private string utilityPath = "Utility/";

	private string toysPath = "Toys/";

	private Dictionary<BuildCategoriesPane.BuildCategory, List<ulong>> buildableObjectIDsByCategory = new Dictionary<BuildCategoriesPane.BuildCategory, List<ulong>>();

	private Dictionary<ulong, BuildableObject> IDObjectMap = new Dictionary<ulong, BuildableObject>();

	private Dictionary<BuildableObject, string> objToPathDict = new Dictionary<BuildableObject, string>();

	private Dictionary<BuildCategoriesPane.BuildCategory, List<BuildableObject>> categoriesToObjectDataDict = new Dictionary<BuildCategoriesPane.BuildCategory, List<BuildableObject>>();

	private void Awake()
	{
		FindAndRegisterAllBuildableObjects(basePath);
	}

	public List<ulong> GetAllBuildableObjectsForCategory(BuildCategoriesPane.BuildCategory category)
	{
		if (!buildableObjectIDsByCategory.ContainsKey(category))
		{
			return emptyList;
		}
		List<ulong> list = new List<ulong>();
		for (int i = 0; i < buildableObjectIDsByCategory[category].Count; i++)
		{
			list.Add(buildableObjectIDsByCategory[category][i]);
		}
		return list;
	}

	public BuildableObject GetObjectForID(ulong ID)
	{
		return IDObjectMap[ID];
	}

	private void FindAndRegisterAllBuildableObjects(string path)
	{
		LoadObjectPath(path + pensPath);
		LoadObjectPath(path + pipesPath);
		LoadObjectPath(path + floorObjectsPath + miscPath);
		LoadObjectPath(path + floorObjectsPath + toysPath);
		LoadObjectPath(path + floorObjectsPath + utilityPath);
		foreach (BuildCategoriesPane.BuildCategory key in buildableObjectIDsByCategory.Keys)
		{
			buildableObjectIDsByCategory[key].Sort();
		}
	}

	private void LoadObjectPath(string path)
	{
		Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			BuildableObject buildableObject = (BuildableObject)array[i];
			buildableObject.Initialize();
			if (!buildableObjectIDsByCategory.ContainsKey(buildableObject.buildCategory))
			{
				buildableObjectIDsByCategory[buildableObject.buildCategory] = new List<ulong>();
			}
			if (!categoriesToObjectDataDict.ContainsKey(buildableObject.buildCategory))
			{
				categoriesToObjectDataDict[buildableObject.buildCategory] = new List<BuildableObject>();
			}
			if (IDObjectMap.ContainsKey(buildableObject.ID))
			{
				Debug.LogError(string.Concat("ID Clash for Build object: ", buildableObject, " and ", IDObjectMap[buildableObject.ID]));
				break;
			}
			string value = path + buildableObject.name;
			IDObjectMap[buildableObject.ID] = buildableObject;
			objToPathDict[buildableObject] = value;
			categoriesToObjectDataDict[buildableObject.buildCategory].Add(buildableObject);
			buildableObjectIDsByCategory[buildableObject.buildCategory].Add(buildableObject.ID);
		}
	}

	public string GetPathForObject(BuildableObject item)
	{
		if (item == null)
		{
			return "";
		}
		return objToPathDict[item];
	}

	public BuildableObject GetObjectForPath(string path)
	{
		return (BuildableObject)Resources.Load(path);
	}

	public List<BuildableObject> GetAllObjectDataForCategory(BuildCategoriesPane.BuildCategory category)
	{
		return categoriesToObjectDataDict[category];
	}
}
