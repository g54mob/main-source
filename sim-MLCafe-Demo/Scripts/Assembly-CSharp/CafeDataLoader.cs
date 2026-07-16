using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CafeDataLoader : MonoBehaviour, IDataPersistence
{
	[SerializeField]
	private ItemLibrary fullItemLibrary;

	private ProductManager productManager;

	private PricingBoard pricingBoard;

	private ShopBuilder cafeShopBuilder;

	[SerializeField]
	private List<SaveableInstance> saveableObjects = new List<SaveableInstance>();

	public static UnityEvent OnLoadGameFinished = new UnityEvent();

	public static UnityEvent<GameData> OnLoadWorldFinished = new UnityEvent<GameData>();

	private bool isLoading;

	private bool loadFinished;

	private static CafeDataLoader instance;

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static bool IsLoadingOrHasLoaded()
	{
		if (!instance.loadFinished)
		{
			return instance.isLoading;
		}
		return true;
	}

	public static bool IsLoading()
	{
		return instance.isLoading;
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
		productManager = Object.FindFirstObjectByType<ProductManager>();
		pricingBoard = Object.FindFirstObjectByType<PricingBoard>();
		cafeShopBuilder = Object.FindFirstObjectByType<ShopBuilder>();
		saveableObjects = Object.FindObjectsByType<SaveableInstance>(FindObjectsSortMode.None).ToList();
	}

	public static bool SaveableInstanceExists(SaveableInstance saveableInstance)
	{
		return instance.saveableObjects.Exists((SaveableInstance x) => x.GetSaveData().id == saveableInstance.GetSaveData().id);
	}

	public static void RegisterNewSaveableInstance(SaveableInstance saveableInstance)
	{
		instance.saveableObjects.Add(saveableInstance);
	}

	public static void UnregisterSaveableInstance(SaveableInstance saveableInstance)
	{
		instance.saveableObjects.Remove(saveableInstance);
	}

	public void LoadData(GameData data, bool isNewGameData)
	{
		isLoading = true;
		if (data.registeredDynamicObjects.Count > 0)
		{
			saveableObjects.ForEach(delegate(SaveableInstance x)
			{
				Object.Destroy(x.gameObject);
			});
			saveableObjects.Clear();
		}
		GameModeManager.SetCurrentGameMode(data.gamemode);
		CafeShopManager.UpdateCafeShopName(data.cafeName);
		WalletSystem.GetPlayerWallet().SetBudget(data.budget);
		ProgressionManager.LoadCurrentLevel(data.level);
		WorldTime.LoadCurrentDate(data.gameDate);
		ProgressionManager.SetCurrentExperience(data.currentLvlXP);
		ProgressionManager.SetExperienceStats(data.currentExperienceStats);
		CafeShopManager.SetCafeShopRating(data.rating);
		DarkRoomManager.LoadDarkRoomStats(data);
		productManager.LoadData(data, isNewGameData);
		pricingBoard.LoadBoardSlots(data, isNewGameData);
		cafeShopBuilder.LoadData(data, isNewGameData);
		foreach (SaveableObjectData registeredDynamicObject in data.registeredDynamicObjects)
		{
			if (registeredDynamicObject.isSelfSocketPackageComponent || registeredDynamicObject.isSelfStorageComponent)
			{
				LoadSaveableInstance(registeredDynamicObject);
			}
		}
		foreach (SaveableObjectData registeredDynamicObject2 in data.registeredDynamicObjects)
		{
			if (!registeredDynamicObject2.isSelfSocketPackageComponent && !registeredDynamicObject2.isSelfStorageComponent)
			{
				LoadSaveableInstance(registeredDynamicObject2);
			}
		}
		foreach (SaveableInstance instance in saveableObjects)
		{
			SaveableInstance saveableInstance = saveableObjects.FirstOrDefault((SaveableInstance x) => x.GetSaveData().id == instance.GetSaveData().parentId);
			if (saveableInstance != null)
			{
				instance.Reparent(saveableInstance.transform);
			}
		}
		OnLoadWorldFinished.Invoke(data);
		StartCoroutine(ReloadSystems());
	}

	private IEnumerator ReloadSystems()
	{
		yield return new WaitForSeconds(1f);
		ProductManager.LoadUnlockedOptions();
		CafeShopManager.ReloadSystem();
		CustomerManager.ReloadSystem();
		DeliverSystem.ReloadSystem();
		WorldTime.UpdateWorldTimeLables();
		MouseCursorInteraction.HideAllOutlines();
		loadFinished = true;
		isLoading = false;
		OnLoadGameFinished.Invoke();
		StopCoroutine(ReloadSystems());
	}

	private void LoadSaveableInstance(SaveableObjectData savedData)
	{
		SaveableInstance component = Object.Instantiate(fullItemLibrary.itemInfos[savedData.item.id].prefab).GetComponent<SaveableInstance>();
		component.LoadData(savedData);
		saveableObjects.Add(component);
	}

	public void SaveData(ref GameData data)
	{
		data.cafeName = CafeShopManager.GetCafeShopName();
		data.budget = WalletSystem.GetPlayerWallet().GetCurrentBudget();
		data.level = ProgressionManager.GetCurrentLevel();
		data.gamemode = GameModeManager.GetCurrentGameMode();
		data.gameDate = WorldTime.GetCurrentDate();
		data.gameTime = WorldTime.GetGlobalTime();
		data.currentLvlXP = ProgressionManager.GetCurrentXP();
		data.currentExperienceStats = ProgressionManager.GetExperienceStats();
		data.rating = CafeShopManager.GetCafeShopRating();
		DarkRoomManager.SaveDarkRoomStats(data);
		saveableObjects = Object.FindObjectsByType<SaveableInstance>(FindObjectsSortMode.None).ToList();
		saveableObjects = saveableObjects.Where((SaveableInstance x) => x != null).ToList();
		data.registeredDynamicObjects.Clear();
		foreach (SaveableInstance saveableObject in saveableObjects)
		{
			saveableObject.SaveData(ref data);
		}
	}
}
