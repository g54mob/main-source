using UnityEngine;

public static class LevelEditorUtil
{
	public enum LevelObjectPrefabPlace
	{
		Editor = 0,
		Real = 1
	}

	public static GameObject LoadLevelObjectPrefab(string levelObjectName, LevelObjectPrefabPlace place)
	{
		return LoadLevelObjectPrefab(new LevelObjectModel
		{
			Name = levelObjectName,
			ResourceName = levelObjectName
		}, place);
	}

	public static GameObject LoadLevelObjectPrefab(LevelObjectModel levelObjectModel, LevelObjectPrefabPlace place)
	{
		string text = "Level/";
		string text2 = levelObjectModel.Name;
		switch (place)
		{
		case LevelObjectPrefabPlace.Editor:
			text = "Level Editor/Objects/";
			text2 = (string.IsNullOrEmpty(levelObjectModel.ResourceName) ? levelObjectModel.Name : levelObjectModel.ResourceName);
			break;
		case LevelObjectPrefabPlace.Real:
			text = "Level/";
			text2 = levelObjectModel.Name;
			break;
		}
		string[] array = new string[3] { "Structure", "Dynamics", "Actives" };
		if (levelObjectModel.LevelObjectType == LevelObjectType.Dynamic)
		{
			array = new string[3] { "Dynamics", "Structure", "Actives" };
		}
		else if (levelObjectModel.LevelObjectType == LevelObjectType.Active)
		{
			array = new string[3] { "Actives", "Structure", "Dynamics" };
		}
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = Resources.Load<GameObject>(string.Concat(text + array[i] + "/", text2));
			if (gameObject != null)
			{
				return gameObject;
			}
		}
		return null;
	}

	public static LevelObjectModel LoadLevelObjectModelFromPrefab(string levelObjectName)
	{
		GameObject gameObject = LoadLevelObjectPrefab(levelObjectName, LevelObjectPrefabPlace.Editor);
		if (gameObject == null)
		{
			return null;
		}
		GameObject gameObject2 = Object.Instantiate(gameObject);
		gameObject2.name = gameObject.name;
		LevelObjectView component = gameObject2.GetComponent<LevelObjectView>();
		if (component == null)
		{
			return null;
		}
		LevelObjectModel result = ConvertLevelObjectViewToModel(component);
		Object.Destroy(gameObject2);
		return result;
	}

	public static LevelObjectModel ConvertLevelObjectViewToModel(LevelObjectView levelObjectView, int id = -1)
	{
		LevelObjectModel levelObjectModel = new LevelObjectModel
		{
			Id = id,
			Name = levelObjectView.Name,
			ResourceName = levelObjectView.gameObject.name,
			LevelObjectType = levelObjectView.LevelObjectType,
			Position = levelObjectView.transform.position,
			Rotation = levelObjectView.transform.rotation,
			Scale = levelObjectView.LevelObjectScale,
			IsAffectedByPhysics = levelObjectView.IsAffectedByPhysics,
			Mass = levelObjectView.Mass,
			Color = levelObjectView.GetColor(),
			IsWithGrid = levelObjectView.IsWithGrid,
			IsAltTexOffset = levelObjectView.IsAltTexOffset,
			LogicType = levelObjectView.LogicType,
			IsInvertedLogic = levelObjectView.IsInvertedLogic,
			IsPressOnce = levelObjectView.IsPressOnce
		};
		if (levelObjectView.RotatorSpeed != Vector3.zero)
		{
			levelObjectModel.RotatorModel = new LORotatorModel
			{
				Speed = levelObjectView.RotatorSpeed,
				IsLocalSpace = levelObjectView.IsLocalSpaceRotator
			};
		}
		return levelObjectModel;
	}

	public static GameObject InstantiateLevelObjectsForUI(CustomLevelObjectsModel customLevelObjectsModel, Transform parentTransform, GameObject referenceBlockObject)
	{
		GameObject gameObject = new GameObject("CustomObjectsFolder");
		gameObject.layer = LayerNames.UI;
		gameObject.transform.SetParent(parentTransform);
		GameObject gameObject2 = new GameObject("NewCustomLevelObjects");
		gameObject2.layer = LayerNames.UI;
		gameObject2.transform.SetParent(gameObject.transform);
		LevelObjectView[] array = LevelEditorManager.CreateMultableLevelObjectViews(customLevelObjectsModel, gameObject2.transform);
		Bounds allMeshRenderersCombinedBounds = array[0].GetAllMeshRenderersCombinedBounds();
		foreach (LevelObjectView levelObjectView in array)
		{
			levelObjectView.gameObject.SetLayersRecursively(LayerNames.UI);
			levelObjectView.gameObject.SetTagsRecursively("Untagged");
			levelObjectView.SetGizmosVisibility(isVisible: false);
			levelObjectView.ShouldHideLogicLine = true;
			allMeshRenderersCombinedBounds.Encapsulate(levelObjectView.GetAllMeshRenderersCombinedBounds());
		}
		var (localScale, vector) = Util.NormalizedScaleAndCentroid(allMeshRenderersCombinedBounds, referenceBlockObject.transform.localScale.x);
		gameObject2.transform.localPosition = -vector;
		gameObject.transform.localPosition = referenceBlockObject.transform.localPosition;
		gameObject.transform.localRotation = referenceBlockObject.transform.localRotation;
		gameObject.transform.localScale = localScale;
		for (int j = 0; j < array.Length; j++)
		{
			array[j].SetTextureTilingScale(parentTransform.lossyScale.x * localScale.x);
		}
		return gameObject;
	}

	public static int UserAndWorkshopLevelCounter(LevelModel[] levelModels)
	{
		int num = 0;
		for (int i = 0; i < levelModels.Length; i++)
		{
			if (levelModels[i].Place == LevelModel.LevelPlace.User || levelModels[i].Place == LevelModel.LevelPlace.Workshop)
			{
				num++;
			}
		}
		return num;
	}
}
