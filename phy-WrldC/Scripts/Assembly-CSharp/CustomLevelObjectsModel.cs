using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomLevelObjectsModel : BaseModel, ICollectionItem
{
	public enum OriginEnum
	{
		Level = 0,
		Part = 1,
		UserPart = 2
	}

	private Dictionary<int, LevelObjectModel> levelObjectModelMap;

	public string Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public OriginEnum Origin { get; set; }

	public string FilePath { get; set; }

	public Vector3 LastLevelObjectScale { get; private set; }

	public CustomLevelObjectsModel()
	{
		levelObjectModelMap = new Dictionary<int, LevelObjectModel>();
		Origin = OriginEnum.Level;
	}

	public void AddLevelObjectModel(LevelObjectModel levelObjectModel)
	{
		if (levelObjectModelMap.ContainsKey(levelObjectModel.Id))
		{
			throw new Exception("Try adding a Level Object with the same Id");
		}
		LastLevelObjectScale = levelObjectModel.Scale;
		levelObjectModelMap.Add(levelObjectModel.Id, levelObjectModel);
	}

	public LevelObjectModel GetLevelObjectModel(int id)
	{
		return levelObjectModelMap[id];
	}

	public LevelObjectModel[] GetAllLevelObjectModels()
	{
		return levelObjectModelMap.Values.ToArray();
	}

	public bool ContainsLevelObjectModel(int id)
	{
		return levelObjectModelMap.ContainsKey(id);
	}

	public int LevelObjectModelsCount()
	{
		return levelObjectModelMap.Values.Count;
	}

	public void ClearCustomLevelModel()
	{
		levelObjectModelMap.Clear();
	}

	public string GetId()
	{
		return Id;
	}
}
