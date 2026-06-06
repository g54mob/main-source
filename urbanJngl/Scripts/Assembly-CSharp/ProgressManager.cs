using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour, ISavedProgress, ISavedProgressReader
{
	public class OnPlantCreatedEventArgs : EventArgs
	{
		public string GUID;
	}

	[Serializable]
	public class ObjectOnLevel
	{
		public int ID;

		public ObjectSO objectSO;

		public int maxQuantity;

		public int scoreToUnlock;

		public bool isUnlocked;

		public int quantity;

		public bool isSpawned;
	}

	[SerializeField]
	private LevelSettingsSO levelSettingsSO;

	[SerializeField]
	private List<ObjectOnLevel> objectsOnLevelList = new List<ObjectOnLevel>();

	private List<string> PlantsOnPanel = new List<string>();

	private List<string> PlantsForLoad = new List<string>();

	public bool IsSpawnButtonVisible = true;

	public int currentScoreMax;

	public int plantButtonCounter;

	private int balanceScoreCounter;

	private const int balancePointsMultiplicatorMax = 4;

	public Action<int> UpdateButtonCount;

	public Action OnLoadIsFinished;

	public Action<ObjectSO, string> SpawnButtonOnPanel;

	public static ProgressManager Instance { get; private set; }

	public event EventHandler<OnPlantCreatedEventArgs> OnPlantCreated;

	private void Awake()
	{
		Instance = this;
		CreateObjectsOnLevel(levelSettingsSO);
		UnlockObjects();
		currentScoreMax = GetCurrentScoreMax();
	}

	private void Start()
	{
		PlantCreatingSystem.Instance.OnPlantCreated += PlantCreatingSystem_OnPlantCreated;
		MovementSystem instance = MovementSystem.Instance;
		instance.OnCancelMoving = (Action<ObjectSO, string>)Delegate.Combine(instance.OnCancelMoving, new Action<ObjectSO, string>(CancelMoving));
		MovementSystem.Instance.OnStopMovingItem += MovementSystem_OnStopMoving;
	}

	private void MovementSystem_OnStopMoving(object sender, EventArgs e)
	{
		UnlockObjects();
	}

	private void CancelMoving(ObjectSO objectSo, string GUID)
	{
		SpawnButtonOnPanel(objectSo, GUID);
	}

	private void PlantCreatingSystem_OnPlantCreated(object sender, PlantCreatingSystem.OnPlantCreatedEventArgs e)
	{
		this.OnPlantCreated?.Invoke(this, new OnPlantCreatedEventArgs
		{
			GUID = e.GUID
		});
	}

	private void OnDestroy()
	{
		PlantCreatingSystem.Instance.OnPlantCreated -= PlantCreatingSystem_OnPlantCreated;
		MovementSystem instance = MovementSystem.Instance;
		instance.OnCancelMoving = (Action<ObjectSO, string>)Delegate.Remove(instance.OnCancelMoving, new Action<ObjectSO, string>(CancelMoving));
		MovementSystem.Instance.OnStopMovingItem -= MovementSystem_OnStopMoving;
	}

	private void CreateObjectsOnLevel(LevelSettingsSO levelSettingsSO)
	{
		for (int i = 0; i < levelSettingsSO.objectsOnLevel.Count; i++)
		{
			objectsOnLevelList.Add(SetObjectOnLevel(i, levelSettingsSO.objectsOnLevel[i].objectSO, levelSettingsSO.objectsOnLevel[i].maxQuantity, levelSettingsSO.objectsOnLevel[i].scoreToUnlock, isUnlocked: false, levelSettingsSO.objectsOnLevel[i].maxQuantity, isSpawned: false));
		}
		CheckOrderByScore();
	}

	private ObjectOnLevel SetObjectOnLevel(int ID, ObjectSO objectSO, int maxQuantity, int scoreToUnlock, bool isUnlocked, int quantity, bool isSpawned)
	{
		return new ObjectOnLevel
		{
			ID = ID,
			objectSO = objectSO,
			maxQuantity = maxQuantity,
			scoreToUnlock = scoreToUnlock,
			isUnlocked = isUnlocked,
			quantity = quantity,
			isSpawned = isSpawned
		};
	}

	public bool IsAllPlantsSpawned()
	{
		int num = 0;
		foreach (ObjectOnLevel objectsOnLevel in objectsOnLevelList)
		{
			if (objectsOnLevel.isUnlocked && objectsOnLevel.isSpawned)
			{
				num++;
			}
		}
		if (num < objectsOnLevelList.Count)
		{
			return false;
		}
		return true;
	}

	private void UnlockObjects()
	{
		foreach (ObjectOnLevel objectsOnLevel in objectsOnLevelList)
		{
			if (TotalScoreCalculator.Instance.GetTotalScore() >= objectsOnLevel.scoreToUnlock && !objectsOnLevel.isUnlocked)
			{
				objectsOnLevel.isUnlocked = true;
			}
		}
	}

	public int GetNextScoreToUnlock()
	{
		int num = 0;
		plantButtonCounter++;
		if (balanceScoreCounter < 4)
		{
			balanceScoreCounter++;
		}
		UpdateButtonCount(plantButtonCounter);
		using (IEnumerator<ObjectOnLevel> enumerator = objectsOnLevelList.Where((ObjectOnLevel t) => !t.isUnlocked).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return currentScoreMax = enumerator.Current.scoreToUnlock;
			}
		}
		int num2 = currentScoreMax;
		List<ObjectOnLevel> list = objectsOnLevelList;
		int result;
		if (num2 < list[list.Count - 1].scoreToUnlock)
		{
			List<ObjectOnLevel> list2 = objectsOnLevelList;
			result = list2[list2.Count - 1].scoreToUnlock;
		}
		else
		{
			result = (currentScoreMax += balanceScoreCounter * 10);
		}
		return result;
	}

	private int GetCurrentScoreMax()
	{
		int num = (from t in objectsOnLevelList
			where !t.isUnlocked
			select t.scoreToUnlock).FirstOrDefault();
		if (num == 0)
		{
			num = levelSettingsSO.scoreMax;
		}
		return num;
	}

	private void CheckOrderByScore()
	{
		int scoreToUnlock = objectsOnLevelList[0].scoreToUnlock;
		for (int i = 1; i < objectsOnLevelList.Count; i++)
		{
			if (objectsOnLevelList[i].scoreToUnlock >= scoreToUnlock)
			{
				scoreToUnlock = objectsOnLevelList[i].scoreToUnlock;
			}
			else
			{
				Debug.LogWarning("Wrong order in objectsOnLevelList object№" + i);
			}
		}
	}

	public bool IsSpawned(int index)
	{
		return objectsOnLevelList[index].isSpawned;
	}

	public bool IsUnlocked(int index)
	{
		return objectsOnLevelList[index].isUnlocked;
	}

	public int GetScoreToUnlock(int index)
	{
		return objectsOnLevelList[index].scoreToUnlock;
	}

	public void MinusPlantButtonCounter()
	{
		plantButtonCounter--;
		UpdateButtonCount(plantButtonCounter);
	}

	public void PlusPlantButtonCounter()
	{
		plantButtonCounter++;
		UpdateButtonCount(plantButtonCounter);
	}

	public void SetIsSpawned(int index, bool value)
	{
		objectsOnLevelList[index].isSpawned = value;
	}

	public int GetObjectOnLevelListCount()
	{
		return objectsOnLevelList.Count;
	}

	public ObjectSO GetObjectSO(int index)
	{
		return objectsOnLevelList[index].objectSO;
	}

	public List<string> GetPlantsForLoad()
	{
		return PlantsForLoad;
	}

	public List<string> GetPlantsOnPanel()
	{
		return PlantsOnPanel;
	}

	public void LoadProgress(PlayerProgress progress)
	{
		if (progress.CreativeMode)
		{
			return;
		}
		plantButtonCounter = progress.PlantButtonCounter;
		balanceScoreCounter = progress.BalanceScoreCounter;
		if (progress.MaxScore > currentScoreMax)
		{
			currentScoreMax = progress.MaxScore;
		}
		NewScoreUI.Instance.UpdateMaxScore(currentScoreMax);
		IsSpawnButtonVisible = progress.IsSpawnButtonVisible;
		foreach (ObjectOnLevel objectsOnLevel in objectsOnLevelList)
		{
			if (TotalScoreCalculator.Instance.GetTotalScore() >= objectsOnLevel.scoreToUnlock && !objectsOnLevel.isUnlocked)
			{
				objectsOnLevel.isUnlocked = true;
			}
		}
		foreach (string item in progress.PlantsOnButton_new)
		{
			PlantsForLoad.Add(item);
		}
		foreach (InfoForObjectsOnLevel info in progress.infoForObjects)
		{
			foreach (ObjectOnLevel item2 in objectsOnLevelList.Where((ObjectOnLevel objectOnLevel) => info.ID == objectOnLevel.ID))
			{
				item2.quantity = info.quantity;
				item2.isSpawned = info.isSpawned;
				item2.isUnlocked = info.isUnlocked;
			}
		}
		UpdateButtonCount(plantButtonCounter);
		OnLoadIsFinished?.Invoke();
	}

	public void UpdateProgress(PlayerProgress progress)
	{
		if (progress.CreativeMode)
		{
			return;
		}
		progress.currentLevel = SceneManager.GetActiveScene().name;
		progress.Score = TotalScoreCalculator.Instance.GetTotalScore();
		progress.MaxScore = currentScoreMax;
		progress.BalanceScoreCounter = balanceScoreCounter;
		progress.IsSpawnButtonVisible = IsSpawnButtonVisible;
		progress.PlantButtonCounter = plantButtonCounter;
		progress.infoForObjects.Clear();
		progress.PlantsOnButton_new.Clear();
		foreach (string item in PlantsOnPanel)
		{
			progress.PlantsOnButton_new.Add(item);
		}
		foreach (ObjectOnLevel objectsOnLevel in objectsOnLevelList)
		{
			InfoForObjectsOnLevel infoForObjectsOnLevel = new InfoForObjectsOnLevel();
			infoForObjectsOnLevel.ID = objectsOnLevel.ID;
			infoForObjectsOnLevel.quantity = objectsOnLevel.quantity;
			infoForObjectsOnLevel.isSpawned = objectsOnLevel.isSpawned;
			infoForObjectsOnLevel.isUnlocked = objectsOnLevel.isUnlocked;
			progress.infoForObjects.Add(infoForObjectsOnLevel);
		}
	}
}
