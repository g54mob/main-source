using MoreMountains.Feedbacks;
using UnityEngine;

public class BerryGrower : MonoBehaviour
{
	private Plant parentPlant;

	public bool isGrowingHalted;

	[SerializeField]
	private GameObject berryPrefab;

	[SerializeField]
	private GameObject growingBerryPrefab;

	private const float GROWTHRATE_BASE = 1.25f;

	private int currBerryTier;

	public GameObject spawned_GrowingBerry;

	[Header("Growing")]
	[SerializeField]
	private float currentGrowth;

	[SerializeField]
	private float growTimeMax;

	public float delayBeforeGrowing;

	public const float BERRYSPAWN_UPWARDBOOP = 4f;

	public const float BERRYSPAWN_FORWARDBOOP = 4f;

	public const float BERRYSPAWN_TORQUEBOOP = 6.5f;

	[SerializeField]
	private bool isCultist;

	private BerryCultist_AI cultistScript;

	[SerializeField]
	private bool isMainGardenPlant;

	private bool hasCheckedWhichBerryToGrowAtRoundStart;

	[Header("Flower Petals")]
	[SerializeField]
	private MeshFilter flowerPetal_MeshFilter;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_BerryPloop;

	private void Awake()
	{
		parentPlant = GetComponentInParent<Plant>();
	}

	private void Start()
	{
		ResetGrowth();
		if (isCultist)
		{
			cultistScript = base.transform.root.gameObject.GetComponent<BerryCultist_AI>();
			SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[cultistScript.GetBerryTier()]);
			SetRandomDelayForCultists();
		}
	}

	private void SetRandomDelayForCultists()
	{
		delayBeforeGrowing = Random.Range(0f, 3f);
	}

	private void OnEnable()
	{
		ResetGrowth();
	}

	private void Update()
	{
		if (isCultist)
		{
			HandleGrowth();
		}
		if (isMainGardenPlant)
		{
			HandleRoundStartBerryChoosing();
		}
	}

	private void HandleRoundStartBerryChoosing()
	{
		if (!hasCheckedWhichBerryToGrowAtRoundStart && GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			PickAndAssignRandomBerryTierFromCurrentCultistsInYard();
			hasCheckedWhichBerryToGrowAtRoundStart = true;
			if (isMainGardenPlant && !PlayerStats.Singleton.treeUpgrade_Unlocked && !PlayerStats.Singleton.bushUpgrade_Unlocked)
			{
				currentGrowth = growTimeMax * 0.8f;
			}
		}
	}

	public void SelectNewBerryToGrow(BerryProfile _newBerry)
	{
		if ((bool)spawned_GrowingBerry)
		{
			Object.Destroy(spawned_GrowingBerry);
		}
		growTimeMax = _newBerry.growthMaxTime;
		currBerryTier = _newBerry.tier;
		if ((bool)_newBerry.berryPrefab)
		{
			berryPrefab = _newBerry.berryPrefab;
		}
		if ((bool)_newBerry.berryGrowingPrefab)
		{
			growingBerryPrefab = _newBerry.berryGrowingPrefab;
			GameObject obj = (spawned_GrowingBerry = Object.Instantiate(growingBerryPrefab, base.transform));
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localEulerAngles = Vector3.zero;
			base.transform.localScale = Vector3.zero;
		}
		ResetGrowth();
	}

	private void ResetGrowth()
	{
		currentGrowth = 0f;
	}

	public void HandleGrowth()
	{
		if (GameManager.Singleton.gameState != GameManager.GameState.Playing || isGrowingHalted || GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			return;
		}
		if (delayBeforeGrowing > 0f)
		{
			delayBeforeGrowing -= Time.deltaTime;
		}
		else if (currentGrowth < growTimeMax)
		{
			currentGrowth += Time.deltaTime * (1.25f * GameManager.Singleton.globalBerryGrowthRate);
		}
		else
		{
			currentGrowth = 0f;
			Rigidbody component = Object.Instantiate(berryPrefab, spawned_GrowingBerry.transform.GetChild(0).transform.position, spawned_GrowingBerry.transform.GetChild(0).transform.rotation).GetComponent<Rigidbody>();
			AudioManager.Singleton.PlayBerrySpawnPopSFX(component.transform.position);
			feedback_BerryPloop?.PlayFeedbacks();
			AddCuteDropPhysics(component);
			if (!isCultist)
			{
				TickUpBerrysProducedStatOnOurPlantBed();
			}
			AddToGlobalBerryGrownTotals();
			if (isMainGardenPlant && GameManager.Singleton.spawnedCultists.Count > 0)
			{
				PickAndAssignRandomBerryTierFromCurrentCultistsInYard();
			}
		}
		if ((bool)growingBerryPrefab)
		{
			base.transform.localScale = Vector3.one * (currentGrowth / growTimeMax);
		}
	}

	public void ResetAndHideHalfGrownBerry()
	{
		base.transform.localScale = Vector3.zero;
		currentGrowth = 0f;
	}

	public void PickAndAssignRandomBerryTierFromCurrentCultistsInYard()
	{
		if (GameManager.Singleton.spawnedCultists.Count <= 0)
		{
			return;
		}
		if (PlayerStats.Singleton.berryPicker_IsUnlocked)
		{
			switch (GameManager.Singleton.berryPickerInScene.berryPickerState)
			{
			case BerryPicker.BerryPickerState.Random:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[Random.Range(0, PlayerStats.Singleton.highestBerryTierGrown + 1)]);
				break;
			case BerryPicker.BerryPickerState.RandomFromBuddies:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[GameManager.Singleton.spawnedCultists[Random.Range(0, GameManager.Singleton.spawnedCultists.Count)].GetBerryTier()]);
				break;
			case BerryPicker.BerryPickerState.Blueberry:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[0]);
				break;
			case BerryPicker.BerryPickerState.Raspberry:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[1]);
				break;
			case BerryPicker.BerryPickerState.Strawberry:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[2]);
				break;
			case BerryPicker.BerryPickerState.Kiwi:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[3]);
				break;
			case BerryPicker.BerryPickerState.Plum:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[4]);
				break;
			case BerryPicker.BerryPickerState.Apple:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[5]);
				break;
			case BerryPicker.BerryPickerState.Pear:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[6]);
				break;
			case BerryPicker.BerryPickerState.Peach:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[7]);
				break;
			case BerryPicker.BerryPickerState.Banana:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[8]);
				break;
			case BerryPicker.BerryPickerState.Pineapple:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[9]);
				break;
			case BerryPicker.BerryPickerState.Watermelon:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[10]);
				break;
			case BerryPicker.BerryPickerState.Pumpkin:
				SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[11]);
				break;
			case BerryPicker.BerryPickerState.Off:
				break;
			}
		}
		else
		{
			SelectNewBerryToGrow(GameManager.Singleton.prefabBank.berryProfiles[Random.Range(0, PlayerStats.Singleton.highestBerryTierGrown + 1)]);
		}
	}

	private void TickUpBerrysProducedStatOnOurPlantBed()
	{
		parentPlant.parentPlantBed.IncreaseBerriesProducedStat();
	}

	private void AddCuteDropPhysics(Rigidbody _droppedRB)
	{
		_droppedRB.linearVelocity = Vector3.zero;
		_droppedRB.angularVelocity = Vector3.zero;
		if (isCultist)
		{
			_droppedRB.AddForce(Vector3.up * 4f + (base.transform.up * -1f + base.transform.forward * -0.5f) * 4f, ForceMode.VelocityChange);
		}
		else
		{
			_droppedRB.linearVelocity = FlingUtility.CalculateArcVelocity(_droppedRB.transform.position, GameManager.Singleton.prefabBank.mainPlant_BerryLaunchTarget.position, 1.25f);
		}
		Vector3 normalized = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
		_droppedRB.AddTorque(normalized * 6.5f, ForceMode.VelocityChange);
	}

	private void AddToGlobalBerryGrownTotals()
	{
		PlayerStats.Singleton.berryTotal_Total++;
		AchievementChecks();
		switch (currBerryTier)
		{
		case 0:
			PlayerStats.Singleton.berryTotal_Blueberry++;
			break;
		case 1:
			PlayerStats.Singleton.berryTotal_Raspberry++;
			break;
		case 2:
			PlayerStats.Singleton.berryTotal_Strawberry++;
			break;
		case 3:
			PlayerStats.Singleton.berryTotal_Kiwi++;
			break;
		case 4:
			PlayerStats.Singleton.berryTotal_Plum++;
			break;
		case 5:
			PlayerStats.Singleton.berryTotal_Apple++;
			break;
		case 6:
			PlayerStats.Singleton.berryTotal_Pear++;
			break;
		case 7:
			PlayerStats.Singleton.berryTotal_Peach++;
			break;
		case 8:
			PlayerStats.Singleton.berryTotal_Banana++;
			break;
		case 9:
			PlayerStats.Singleton.berryTotal_Pineapple++;
			break;
		case 10:
			PlayerStats.Singleton.berryTotal_Watermelon++;
			break;
		case 11:
			PlayerStats.Singleton.berryTotal_Pumpkin++;
			break;
		}
	}

	public void SwapToBelladonnaFlowerPetals()
	{
		flowerPetal_MeshFilter.mesh = GameManager.Singleton.purpleFlower_Mesh;
	}

	private void AchievementChecks()
	{
		if (PlayerStats.Singleton.berryTotal_Total >= 100 && !GameManager.Singleton.achievement_HasCheckedForBerriesGrownThisRound_Hundred)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_GrowBerries_100"))
			{
				AchievementHelper.UnlockAchievement("ACH_GrowBerries_100");
			}
			GameManager.Singleton.achievement_HasCheckedForBerriesGrownThisRound_Hundred = true;
		}
		if (PlayerStats.Singleton.berryTotal_Total >= 1000 && !GameManager.Singleton.achievement_HasCheckedForBerriesGrownThisRound_Thousand)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_GrowBerries_Thousand"))
			{
				AchievementHelper.UnlockAchievement("ACH_GrowBerries_Thousand");
			}
			GameManager.Singleton.achievement_HasCheckedForBerriesGrownThisRound_Thousand = true;
		}
		if (PlayerStats.Singleton.berryTotal_Total >= 66666 && !GameManager.Singleton.achievement_HasCheckedForBerriesGrownThisRound_HundoThousand)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_GrowBerries_HundoThousand"))
			{
				AchievementHelper.UnlockAchievement("ACH_GrowBerries_HundoThousand");
			}
			GameManager.Singleton.achievement_HasCheckedForBerriesGrownThisRound_HundoThousand = true;
		}
	}
}
