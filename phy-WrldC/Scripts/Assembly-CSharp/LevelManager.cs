using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[Header("Folders")]
	public GameObject atackerZone;

	public GameObject defenderZone;

	public GameObject goalZone;

	public GameObject failureZones;

	public GameObject dynamicObjectsFolder;

	public GameObject staticObjectsFolder;

	public GameObject collectableFolder;

	[Header("Others")]
	public Transform customStartPreviewPoint;

	public Transform customEndPreviewPoint;

	private GameManager gameManager;

	private LevelModel levelModel;

	private LevelView levelView;

	public static LevelManager Instance => Singleton<LevelManager>.Instance;

	public static bool Exist => Singleton<LevelManager>.Exist;

	public bool IsBrainDestroyedGoal => levelModel.IsBrainDestroyedGoal;

	public bool HasDefenderZone
	{
		get
		{
			if (levelModel.HasDefenderZone)
			{
				return defenderZone != null;
			}
			return false;
		}
	}

	public GameObject SelectedZone { get; private set; }

	private void Start()
	{
		if (!GameManager.Exist)
		{
			SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
		}
	}

	public void Initialize()
	{
		gameManager = GameManager.Instance;
		levelModel = gameManager.LevelController.model;
		levelView = base.gameObject.AddComponent<LevelView>();
		gameManager.LevelController.SetView(levelView);
		levelView.Initialize();
		levelView.SetCollectablesInteractivity(levelModel.IsThereCollectables && levelModel.IsLevelCompleted);
		ZonesInit();
		Physics.gravity = levelModel.Gravity;
		gameManager.CheatModel.ResetCheats();
		Debug.Log("LEVEL MANAGER INITIALIZED: " + levelModel.Id);
	}

	public void BeforeUnloadLevel()
	{
		Physics.gravity = Util.DefaultGravity;
	}

	private void ZonesInit()
	{
		GameManager.GameModeState gameMode = gameManager.GameMode;
		if ((uint)gameMode <= 1u || gameMode != GameManager.GameModeState.Defender)
		{
			SelectedZone = atackerZone;
			if (defenderZone != null)
			{
				if (levelModel.HasDefenderZone)
				{
					SetActiveDelimitationZone(defenderZone, shouldBeActived: false);
				}
				else
				{
					defenderZone.SetActive(value: false);
				}
			}
		}
		else
		{
			SelectedZone = defenderZone;
			SetActiveDelimitationZone(atackerZone, shouldBeActived: false);
		}
		gameManager.attackerCreationFolder.transform.position = atackerZone.transform.position;
		gameManager.attackerCreationFolder.transform.rotation = atackerZone.transform.rotation;
		if (defenderZone != null)
		{
			gameManager.defenderCreationFolder.transform.position = defenderZone.transform.position;
			gameManager.defenderCreationFolder.transform.rotation = defenderZone.transform.rotation;
		}
		SelectedZone.SetActive(value: true);
	}

	public void SetLevelMode(bool isEditing)
	{
		SetActiveDelimitationZone(SelectedZone, isEditing);
		if (!isEditing)
		{
			levelView.StartLevel();
			return;
		}
		levelView.StopLevel();
		levelView.ResetLevel();
	}

	public void RestoresDynamicObjects()
	{
		foreach (DynamicObjectBase allDynamicObject in levelView.GetAllDynamicObjects())
		{
			allDynamicObject.Recycle();
		}
	}

	public void SetUpToActionDynamicObjects()
	{
		foreach (DynamicObjectBase allDynamicObject in levelView.GetAllDynamicObjects())
		{
			allDynamicObject.SetupToAction();
		}
	}

	public void RestoresCollectables()
	{
		levelView.SetCollectablesInteractivity(levelModel.IsThereCollectables && levelModel.IsLevelCompleted);
	}

	private void SetActiveDelimitationZone(GameObject zoneObject, bool shouldBeActived)
	{
		zoneObject.transform.Find("DelimitationZone").gameObject.SetActive(shouldBeActived);
	}

	public bool IsAnyBlockBodyOutside(CreationView creationView)
	{
		return atackerZone.GetComponent<DelimitationZone>().IsAnyBlockBodyOutside(creationView);
	}

	public Rigidbody[] GetAllLevelRigidbodies()
	{
		List<Rigidbody> list = new List<Rigidbody>();
		foreach (DynamicObjectBase allDynamicObject in levelView.GetAllDynamicObjects())
		{
			if (allDynamicObject.Rigidbody != null)
			{
				list.Add(allDynamicObject.Rigidbody);
			}
		}
		return list.ToArray();
	}

	public bool IsUsingRestrictedBlocks(CreationModel creationModel)
	{
		if (levelModel.RestrictedBlocksEnum != LevelModel.RestrictedBlocks.None)
		{
			string[] restrictedBlocks = GameManager.Instance.RestrictedBlocksData.GetRestrictedBlocks(levelModel.RestrictedBlocksEnum);
			if (restrictedBlocks != null && restrictedBlocks.Length != 0)
			{
				foreach (BlockModel item in creationModel.GetAllBlockModel())
				{
					for (int i = 0; i < restrictedBlocks.Length; i++)
					{
						if (item.Schematic.Id == restrictedBlocks[i])
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}
}
