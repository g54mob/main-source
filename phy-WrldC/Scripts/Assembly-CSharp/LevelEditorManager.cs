using System.Collections.Generic;
using System.Linq;
using RLD;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
	[SerializeField]
	private RLDApp rldApp;

	[SerializeField]
	private OrbitCamera orbitCamera;

	[SerializeField]
	private Camera levelEditorCamera;

	[SerializeField]
	private Canvas levelEditorCanvas;

	[SerializeField]
	private GameObject levelEditorObjectsFolder;

	[SerializeField]
	private Camera thumbnailCamera;

	[SerializeField]
	private GameObject logicLinePrefab;

	[SerializeField]
	private GameObject groundObject;

	[SerializeField]
	private GameObject failureZoneObject;

	[SerializeField]
	private ZoneInCollision startZoneInCollision;

	[SerializeField]
	private ZoneInCollision endZoneInCollision;

	[SerializeField]
	private LevelObjectView[] permanentLevelObjectViews;

	private LevelEditorEvents levelEditorEvents;

	public static LevelEditorManager Instance => Singleton<LevelEditorManager>.Instance;

	public static bool Exist => Singleton<LevelEditorManager>.Exist;

	public OrbitCamera OrbitCamera => orbitCamera;

	public Camera LevelEditorCamera => levelEditorCamera;

	public Camera ThumbnailCamera => thumbnailCamera;

	public bool IsCameraLocked { get; private set; }

	public LevelModel LevelModel { get; private set; }

	public Transform LevelEditorObjectsFolder => levelEditorObjectsFolder.transform;

	public GameObject LogicLinePrefab => logicLinePrefab;

	private void Awake()
	{
		orbitCamera.TargetMaskLayers = LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask;
	}

	public void Initialize()
	{
		levelEditorEvents = new LevelEditorEvents(levelEditorObjectsFolder.transform);
		SetCamerasSensitivity(GameManager.Instance.OptionsModel.CameraSensitivity);
		IsCameraLocked = false;
	}

	public void LoadLevelModel(LevelModel levelModel = null)
	{
		if (levelModel != null)
		{
			GameManager.Instance.CurrentCustomLevelModel = levelModel;
		}
		if (GameManager.Instance.CurrentCustomLevelModel == null)
		{
			LevelModel levelModel2 = LevelModelBuilder.LoadXml(PathNames.CustomLevelTemplateAES, isFileEncrypted: true);
			if (levelModel2 != null)
			{
				levelModel2.Place = LevelModel.LevelPlace.Test;
				GameManager.Instance.CurrentCustomLevelModel = levelModel2;
			}
			else
			{
				GameManager.Instance.CurrentCustomLevelModel = new LevelModel
				{
					Name = "Level Name",
					Description = "Level Description",
					SceneName = "EmptyLevel",
					Place = LevelModel.LevelPlace.Test
				};
			}
		}
		LevelModel = GameManager.Instance.CurrentCustomLevelModel;
		ClearObjectsSelection();
		MonoSingleton<RTUndoRedo>.Get.ClearActions();
		CreateAllLevelObjectViews();
		GameManager.Instance.GUIManager.LEPropertiesController.UpdateAfterLoadLevelModel();
	}

	public void RunLevelEditorEvents()
	{
		levelEditorEvents?.Run();
	}

	public void SetUICamera(Camera uiCamera)
	{
		levelEditorCanvas.worldCamera = uiCamera;
	}

	public void SetCamerasSensitivity(float sensitivity)
	{
		sensitivity = Mathf.Clamp(sensitivity, 0.25f, 10f);
		float xYRotationSpeed = 7f * sensitivity;
		OrbitCamera.SetXYRotationSpeed(xYRotationSpeed);
	}

	public void SetLockCamera(bool isLocked)
	{
		orbitCamera.SetMovementsActive(!isLocked);
		IsCameraLocked = isLocked;
	}

	public void SetToolsActivation(bool isActive)
	{
		levelEditorEvents.SetToolsActivation(isActive);
		rldApp.enabled = isActive;
	}

	public void SetGroundHeight(float height)
	{
		groundObject.transform.SetLocalPositionY(height);
	}

	public float GetGroundHeight()
	{
		return groundObject.transform.localPosition.y;
	}

	public void SetFailureZoneHeight(float height)
	{
		failureZoneObject.transform.SetLocalPositionY(height - 2.5f);
	}

	public float GetFailureZoneHeight()
	{
		return failureZoneObject.transform.localPosition.y + 2.5f;
	}

	public void SetFailureZoneVisibility(bool isVisible)
	{
		failureZoneObject.GetComponent<Renderer>().enabled = isVisible;
	}

	public bool AreZonesInCollision()
	{
		if (startZoneInCollision.ObjectsInCollisionCounter != 0 || endZoneInCollision.ObjectsInCollisionCounter != 0)
		{
			string text = LanguagesManager.Instance.GetText("warning.text.leveleditor.zones", "Can't go because the start or end zone are in collision with some object!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, -20f, 0f, WarningTooltipPanel.FloatDirection.Down);
			return true;
		}
		return false;
	}

	public void ClearObjectsSelection()
	{
		bool isEnabled = MonoSingleton<RTObjectSelection>.Get.IsEnabled;
		if (!isEnabled)
		{
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isEnabled: true);
		}
		MonoSingleton<RTObjectSelection>.Get.ClearSelection(allowUndoRedo: true);
		if (!isEnabled)
		{
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isEnabled: false);
		}
	}

	public void ClearLevelCustomObjects()
	{
		LevelModel.CustomLevelObjectsModel.ClearCustomLevelModel();
		levelEditorObjectsFolder.transform.RemoveAllChildren();
	}

	public void SetCameraFocus(Vector3 targetPosition)
	{
		orbitCamera.SetTargetPosition(targetPosition);
	}

	public bool IsCameraMoving()
	{
		return levelEditorEvents.IsCameraMoving();
	}

	public bool IsGizmoToolsEnabledAndObjectsSelected()
	{
		if (MonoSingleton<RTObjectSelection>.Get.IsEnabled)
		{
			return MonoSingleton<RTObjectSelection>.Get.NumSelectedObjects > 0;
		}
		return false;
	}

	public bool IsLevelObjectSelectedByGizmoTools(GameObject levelObject)
	{
		LevelObjectView componentInParent = levelObject.GetComponentInParent<LevelObjectView>();
		if (componentInParent == null)
		{
			return false;
		}
		return MonoSingleton<RTObjectSelection>.Get.SelectedObjects.Contains(componentInParent.gameObject);
	}

	public bool IsGizmoToolsBeingDragged()
	{
		if (!MonoSingleton<RTObjectSelectionGizmos>.Get.WorkGizmo.IsDragged)
		{
			return MonoSingleton<RTObjectSelectionGizmos>.Get.WorkGizmo.IsHovered;
		}
		return true;
	}

	public void TestLevel()
	{
		if (!AreZonesInCollision())
		{
			CreateAllCustomLevelObjectsModel();
			GameManager.Instance.LevelType = GameManager.LevelTypeState.Test;
			GameManager.Instance.GameMode = GameManager.GameModeState.Attacker;
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.LoadLevelAndChangeState(LevelModel, StartLevelState.Instance);
			}, LevelModel);
		}
	}

	public void CreateAllCustomLevelObjectsModel()
	{
		LevelModel.CustomLevelObjectsModel.ClearCustomLevelModel();
		LevelObjectView[] componentsInChildren = levelEditorObjectsFolder.GetComponentsInChildren<LevelObjectView>();
		LevelObjectView[] array = new LevelObjectView[permanentLevelObjectViews.Length + componentsInChildren.Length];
		permanentLevelObjectViews.CopyTo(array, 0);
		componentsInChildren.CopyTo(array, permanentLevelObjectViews.Length);
		LevelObjectModel[] allLevelObjectModels = CreateCustomLevelObjectModel(array).GetAllLevelObjectModels();
		foreach (LevelObjectModel levelObjectModel in allLevelObjectModels)
		{
			LevelModel.CustomLevelObjectsModel.AddLevelObjectModel(levelObjectModel);
		}
	}

	public static CustomLevelObjectsModel CreateCustomLevelObjectModel(LevelObjectView[] levelObjectViews)
	{
		CustomLevelObjectsModel customLevelObjectsModel = new CustomLevelObjectsModel();
		int id = 0;
		foreach (LevelObjectView levelObjectView in levelObjectViews)
		{
			if (levelObjectView.gameObject.activeSelf)
			{
				levelObjectView.Id = id;
				LevelObjectModel levelObjectModel = LevelEditorUtil.ConvertLevelObjectViewToModel(levelObjectView, id++);
				customLevelObjectsModel.AddLevelObjectModel(levelObjectModel);
			}
		}
		foreach (LevelObjectView levelObjectView2 in levelObjectViews)
		{
			if (levelObjectView2.LogicType == LevelObjectLogicType.Input && levelObjectView2.gameObject.activeSelf && !(levelObjectView2.LevelObjectViewOutput == null) && customLevelObjectsModel.ContainsLevelObjectModel(levelObjectView2.Id) && customLevelObjectsModel.ContainsLevelObjectModel(levelObjectView2.LevelObjectViewOutput.Id))
			{
				customLevelObjectsModel.GetLevelObjectModel(levelObjectView2.Id).LevelObjectOutputId = levelObjectView2.LevelObjectViewOutput.Id;
			}
		}
		return customLevelObjectsModel;
	}

	private void CreateAllLevelObjectViews()
	{
		levelEditorObjectsFolder.transform.RemoveAllChildren();
		LevelObjectModel[] allLevelObjectModels = LevelModel.CustomLevelObjectsModel.GetAllLevelObjectModels();
		new Dictionary<int, LevelObjectView>();
		foreach (LevelObjectModel levelObjectModel in allLevelObjectModels)
		{
			LevelObjectType levelObjectType = levelObjectModel.LevelObjectType;
			if ((uint)levelObjectType > 3u)
			{
				continue;
			}
			LevelObjectView[] array = permanentLevelObjectViews;
			foreach (LevelObjectView levelObjectView in array)
			{
				if (levelObjectModel.LevelObjectType == levelObjectView.LevelObjectType)
				{
					levelObjectView.transform.position = levelObjectModel.Position;
					levelObjectView.transform.rotation = levelObjectModel.Rotation;
					levelObjectView.transform.localScale = levelObjectModel.Scale;
				}
			}
		}
		Transform parentTransform = levelEditorObjectsFolder.transform;
		CreateMultableLevelObjectViews(LevelModel.CustomLevelObjectsModel, parentTransform);
	}

	public static LevelObjectView[] CreateMultableLevelObjectViews(CustomLevelObjectsModel customLevelObjectsModel, Transform parentTransform)
	{
		LevelObjectModel[] allLevelObjectModels = customLevelObjectsModel.GetAllLevelObjectModels();
		Dictionary<int, LevelObjectView> dictionary = new Dictionary<int, LevelObjectView>();
		foreach (LevelObjectModel levelObjectModel in allLevelObjectModels)
		{
			LevelObjectType levelObjectType = levelObjectModel.LevelObjectType;
			if ((uint)(levelObjectType - 4) > 2u)
			{
				continue;
			}
			GameObject gameObject = LevelEditorUtil.LoadLevelObjectPrefab(levelObjectModel, LevelEditorUtil.LevelObjectPrefabPlace.Editor);
			if (gameObject == null)
			{
				continue;
			}
			GameObject obj = Object.Instantiate(gameObject, parentTransform);
			obj.name = levelObjectModel.Name;
			obj.transform.position = levelObjectModel.Position;
			obj.transform.rotation = levelObjectModel.Rotation;
			LevelObjectView component = obj.GetComponent<LevelObjectView>();
			component.Initialize();
			component.LevelObjectScale = levelObjectModel.Scale;
			component.Id = levelObjectModel.Id;
			component.IsAffectedByPhysics = levelObjectModel.IsAffectedByPhysics;
			component.Mass = levelObjectModel.Mass;
			if (levelObjectModel.LevelObjectType == LevelObjectType.Structure || levelObjectModel.LevelObjectType == LevelObjectType.Active)
			{
				component.SetColor(levelObjectModel.Color);
				if (levelObjectModel.IsWithGrid)
				{
					component.SetMaterial(GlobalMaterialManager.Instance.LevelObjectWithGridMat, isWithGrid: true);
				}
				else
				{
					component.SetMaterial(GlobalMaterialManager.Instance.LevelObjectWithoutGridMat, isWithGrid: false);
				}
				if (levelObjectModel.IsAltTexOffset)
				{
					component.IsAltTexOffset = true;
				}
			}
			component.IsInvertedLogic = levelObjectModel.IsInvertedLogic;
			component.IsPressOnce = levelObjectModel.IsPressOnce;
			if (levelObjectModel.LevelObjectType == LevelObjectType.Structure && levelObjectModel.RotatorModel != null)
			{
				component.RotatorSpeed = levelObjectModel.RotatorModel.Speed;
				component.IsLocalSpaceRotator = levelObjectModel.RotatorModel.IsLocalSpace;
			}
			dictionary.Add(levelObjectModel.Id, component);
		}
		foreach (LevelObjectModel levelObjectModel2 in allLevelObjectModels)
		{
			if (levelObjectModel2.LogicType == LevelObjectLogicType.Input && levelObjectModel2.Id >= 0 && levelObjectModel2.LevelObjectOutputId >= 0)
			{
				LevelObjectView levelObjectView = null;
				if (dictionary.ContainsKey(levelObjectModel2.Id))
				{
					levelObjectView = dictionary[levelObjectModel2.Id];
				}
				if (!(levelObjectView == null) && dictionary.ContainsKey(levelObjectModel2.LevelObjectOutputId))
				{
					levelObjectView.LevelObjectViewOutput = dictionary[levelObjectModel2.LevelObjectOutputId];
				}
			}
		}
		return dictionary.Values.ToArray();
	}
}
