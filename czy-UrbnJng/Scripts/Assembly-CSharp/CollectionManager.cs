using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Infrastructure.Services.LocalizationService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour, ISavedProgress, ISavedProgressReader
{
	[SerializeField]
	private List<ObjectSO> objectSOcollection;

	[SerializeField]
	private List<LevelSettingsSO> levelSettingsCollection;

	private Dictionary<string, string> playerCollection = new Dictionary<string, string>();

	public List<string> firstPlantsCollection = new List<string>();

	public List<string> skinsCollection = new List<string>();

	private Dictionary<PlantName, string> localizationPlantName = new Dictionary<PlantName, string>();

	private Dictionary<PlantName, string> localizationPlantTip = new Dictionary<PlantName, string>();

	private Queue<string> recentPlants = new Queue<string>(6);

	private int maxRecentItems = 6;

	private int currentSceneNumber;

	private int scoreMaxOnLevel;

	private const int ALL_SKINS_COUNT = 110;

	private const string LOVES_Localize_key = "Journal.Loves";

	private const string HATES_Localize_key = "Journal.Hates";

	private string currentLovesText;

	private string currentHatesText;

	private int uncommonChance = 15;

	private int rareChance = 10;

	private const int defaultUncommonChance = 15;

	private const int defaultRareChance = 10;

	private bool uncommonTrigger;

	private bool rareTrigger;

	public Action<ObjectSO, string> OnBuySkin;

	public Action OnLoadCollection;

	public static CollectionManager Instance { get; private set; }

	public event EventHandler OnNewPlantInCollection;

	private void Awake()
	{
		Instance = this;
		GetCurrentSceneNumber();
	}

	private void Start()
	{
		CheckForDuplicateGUIDs();
		LocalizePlants();
	}

	public void AddItemToPlayerCollection(string variantGUID, string objectGuid)
	{
		if (!playerCollection.ContainsKey(variantGUID))
		{
			playerCollection.Add(variantGUID, objectGuid);
		}
		if (playerCollection.Count == 110)
		{
			SteamIntegration.Instance.UnlockAchievement("ALL_SKINS_14", 14);
		}
	}

	public ObjectSO GetPlantSOByGUID(string guid)
	{
		return objectSOcollection.FirstOrDefault((ObjectSO obj) => obj.GUID == guid || obj.variantsList.Any((Variant variant) => variant.GUID == guid));
	}

	public ObjectSO GetRandomPlant()
	{
		foreach (LevelSettingsSO.ObjectOnLevel item in levelSettingsCollection[currentSceneNumber].objectsOnLevel)
		{
			if (!firstPlantsCollection.Contains(item.objectSO.GUID) && item.scoreToUnlock <= TotalScoreCalculator.Instance.GetTotalScore())
			{
				return item.objectSO;
			}
		}
		string guid = firstPlantsCollection[UnityEngine.Random.Range(0, firstPlantsCollection.Count)];
		return GetPlantSOByGUID(guid);
	}

	public (int, ObjectSO) GetRandomSkin(ObjectSO objectSo, bool randomPlant, int cardNumber)
	{
		int i = 0;
		int num = -1;
		ObjectSO objectSO = objectSo;
		for (; i < 1000; i++)
		{
			if (randomPlant && i != 0)
			{
				objectSO = GetRandomPlant();
			}
			num = GetSkinByCardNumber(objectSO, cardNumber);
			if (num != -1 && !recentPlants.Contains(objectSO.variantsList[num].GUID))
			{
				break;
			}
		}
		if (i >= 1000)
		{
			Debug.LogWarning("Max attempts reached. Returning the last selected plant.");
		}
		QueueCheck(objectSO.variantsList[num].GUID);
		return (num, objectSO);
	}

	public string GetPlantNameLocalize(PlantName plantNameKey)
	{
		foreach (KeyValuePair<PlantName, string> item in localizationPlantName)
		{
			if (plantNameKey == item.Key)
			{
				return item.Value;
			}
		}
		return null;
	}

	public string GetPlantTipLocalize(PlantName plantNameKey)
	{
		foreach (KeyValuePair<PlantName, string> item in localizationPlantTip)
		{
			if (plantNameKey == item.Key)
			{
				return item.Value;
			}
		}
		return null;
	}

	private int GetSkinByCardNumber(ObjectSO objectSo, int cardNumber)
	{
		if (cardNumber <= 2)
		{
			switch (cardNumber)
			{
			case 0:
			case 1:
				if (!HasRequiredRarity(objectSo, PlantRareLevel.Common))
				{
					return -1;
				}
				return GetVariantWithRarity(objectSo, PlantRareLevel.Common);
			case 2:
				if (!HasRequiredRarity(objectSo, PlantRareLevel.Uncommon))
				{
					return -1;
				}
				return GetVariantWithRarity(objectSo, PlantRareLevel.Uncommon);
			default:
				return -1;
			}
		}
		return GetSkinByRarityChance(objectSo);
	}

	private int GetSkinByRarityChance(ObjectSO objectSo)
	{
		int num = UnityEngine.Random.Range(0, 100);
		if (num <= rareChance && HasRequiredRarity(objectSo, PlantRareLevel.Rare))
		{
			rareTrigger = true;
			return GetVariantWithRarity(objectSo, PlantRareLevel.Rare);
		}
		if (num <= uncommonChance && HasRequiredRarity(objectSo, PlantRareLevel.Uncommon))
		{
			uncommonTrigger = true;
			return GetVariantWithRarity(objectSo, PlantRareLevel.Uncommon);
		}
		if (HasRequiredRarity(objectSo, PlantRareLevel.Common))
		{
			return GetVariantWithRarity(objectSo, PlantRareLevel.Common);
		}
		return -1;
	}

	private bool HasRequiredRarity(ObjectSO objectSo, PlantRareLevel rareLevel)
	{
		return objectSo.variantsList.Exists((Variant variant) => variant.rareLevel == rareLevel);
	}

	public void CalculateNewChances()
	{
		if (rareTrigger)
		{
			rareChance = 10;
		}
		else
		{
			rareChance += 5;
		}
		if (uncommonTrigger)
		{
			uncommonChance = 15;
		}
		else
		{
			uncommonChance += 5;
		}
		rareTrigger = false;
		uncommonTrigger = false;
	}

	private int GetVariantWithRarity(ObjectSO objectSo, PlantRareLevel rareLevel)
	{
		int num = 1000;
		int num2 = 0;
		int num3;
		do
		{
			num3 = UnityEngine.Random.Range(0, objectSo.variantsList.Count);
			num2++;
		}
		while (objectSo.variantsList[num3].rareLevel != rareLevel && num2 < num);
		if (num2 >= num)
		{
			Debug.LogWarning("Max attempts reached. Returning the last variant number.");
		}
		return num3;
	}

	public bool PlantCardOpen(string GUID)
	{
		return !playerCollection.ContainsKey(GUID);
	}

	public void AddPlantToCollection(string GUID)
	{
		if (!firstPlantsCollection.Contains(GUID))
		{
			firstPlantsCollection.Add(GUID);
		}
	}

	public void NewSkinPurchased(string GUID, ObjectSO objectSO)
	{
		if (!playerCollection.ContainsKey(GUID))
		{
			this.OnNewPlantInCollection?.Invoke(this, EventArgs.Empty);
			playerCollection.Add(GUID, objectSO.GUID);
			OnBuySkin?.Invoke(objectSO, GUID);
		}
	}

	private void CheckForDuplicateGUIDs()
	{
		List<string> list = new List<string>();
		foreach (ObjectSO item in objectSOcollection)
		{
			if (item.variantsList.Count > 0)
			{
				foreach (Variant variants in item.variantsList)
				{
					list.Add(variants.GUID);
				}
			}
			else
			{
				list.Add(item.GUID);
			}
		}
		if (list.Count != list.Distinct().Count())
		{
			Debug.LogError("Found duplicate GUID, check ObjectSO");
		}
	}

	public Dictionary<string, string> GetCollectedPlantsList()
	{
		return playerCollection;
	}

	public void LoadProgress(PlayerProgress progress)
	{
		if (progress.userCollection.Count == 0)
		{
			return;
		}
		playerCollection.Clear();
		foreach (KeyValuePair<string, string> item in progress.userCollection)
		{
			playerCollection.Add(item.Key, item.Value);
		}
		firstPlantsCollection.Clear();
		foreach (string item2 in progress.userFirstPlantCollection)
		{
			firstPlantsCollection.Add(item2);
		}
		skinsCollection.Clear();
		foreach (string item3 in progress.userSkinsCollection)
		{
			skinsCollection.Add(item3);
		}
		OnLoadCollection?.Invoke();
	}

	public void UpdateProgress(PlayerProgress progress)
	{
		progress.userFirstPlantCollection.Clear();
		foreach (string item in firstPlantsCollection)
		{
			progress.userFirstPlantCollection.Add(item);
		}
		progress.userSkinsCollection.Clear();
		foreach (string item2 in skinsCollection)
		{
			progress.userSkinsCollection.Add(item2);
		}
		progress.userCollection.Clear();
		foreach (KeyValuePair<string, string> item3 in playerCollection)
		{
			progress.userCollection.Add(item3.Key, item3.Value);
		}
	}

	private void UnlockFirstSkins()
	{
		foreach (ObjectSO item in objectSOcollection)
		{
			if (item.variantsList.Count > 0)
			{
				foreach (Variant variants in item.variantsList)
				{
					if (!playerCollection.ContainsKey(variants.GUID))
					{
						playerCollection.Add(variants.GUID, item.GUID);
					}
				}
			}
			else if (!playerCollection.ContainsKey(item.GUID))
			{
				playerCollection.Add(item.GUID, item.GUID);
			}
		}
	}

	public int GetPrice(ObjectSO objectSO, string GUID)
	{
		ObjectSO objectSO2 = objectSOcollection.Find((ObjectSO plant) => plant == objectSO);
		if (objectSO2.variantsList.Count != 0)
		{
			return objectSO2.variantsList.Find((Variant variant) => variant.GUID == GUID).price;
		}
		return objectSO2.price;
	}

	public int GetScoreMax()
	{
		return levelSettingsCollection[currentSceneNumber].scoreMax;
	}

	public void QueueCheck(string variantGUID)
	{
		if (recentPlants.Count >= maxRecentItems)
		{
			recentPlants.Dequeue();
		}
		recentPlants.Enqueue(variantGUID);
	}

	private void GetCurrentSceneNumber()
	{
		currentSceneNumber = SceneManager.GetActiveScene().buildIndex - 1;
	}

	public void LocalizePlants()
	{
		localizationPlantName.Clear();
		localizationPlantTip.Clear();
		currentLovesText = LocalizationManager.Localize("Journal.Loves");
		currentHatesText = LocalizationManager.Localize("Journal.Hates");
		foreach (ObjectSO item in objectSOcollection)
		{
			localizationPlantName.Add(item.objectName, LocalizationManager.Localize(item.objectNameLocalization));
		}
		foreach (ObjectSO item2 in objectSOcollection)
		{
			string text = "";
			if (item2.friendPlant.Count != 0)
			{
				text = currentLovesText + " " + GetPlantNameLocalize(item2.friendPlant[0]);
			}
			foreach (PlantName item3 in item2.friendPlant)
			{
				if (item3 != item2.friendPlant[0])
				{
					text = text + ", " + GetPlantNameLocalize(item3);
				}
			}
			if (text != "")
			{
				text += "\n\n";
			}
			if (item2.enemyPlant.Count != 0)
			{
				text = text + currentHatesText + " " + GetPlantNameLocalize(item2.enemyPlant[0]);
			}
			foreach (PlantName item4 in item2.enemyPlant)
			{
				if (item4 != item2.enemyPlant[0])
				{
					text = text + ", " + GetPlantNameLocalize(item4);
				}
			}
			localizationPlantTip.Add(item2.objectName, text);
		}
	}
}
