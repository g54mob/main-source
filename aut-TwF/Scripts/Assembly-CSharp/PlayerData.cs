using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Storage_ResourceData))]
public class PlayerData : MonoBehaviour, ISavable
{
	[Serializable]
	public class PlayerBuilding
	{
		[SerializeField]
		private GameplayObjectData buildingData;

		[SerializeField]
		[Rename("Unlocked")]
		private bool isUnlocked;

		[SerializeField]
		private int tier;

		[SerializeField]
		private bool hideIfLocked;

		[SerializeField]
		[Rename("Demo")]
		private bool availableInDemo;

		public GameplayObjectData BuildingData => buildingData;

		public bool IsUnlocked
		{
			get
			{
				return isUnlocked;
			}
			set
			{
				isUnlocked = value;
			}
		}

		public int Tier
		{
			get
			{
				return tier;
			}
			set
			{
				tier = value;
			}
		}

		public bool HideIfLocked
		{
			get
			{
				return hideIfLocked;
			}
			set
			{
				hideIfLocked = value;
			}
		}

		public bool AvailableInDemo
		{
			get
			{
				return availableInDemo;
			}
			set
			{
				availableInDemo = value;
			}
		}

		public PlayerBuilding(GameplayObjectData buildingData, bool isUnlocked, int tier, bool hideIfLocked, bool availableInDemo)
		{
			this.buildingData = buildingData;
			this.isUnlocked = isUnlocked;
			this.tier = tier;
			HideIfLocked = hideIfLocked;
			this.availableInDemo = availableInDemo;
		}
	}

	[Header("References")]
	[SerializeField]
	private ResourceData enemyEssenceResourceData;

	[SerializeField]
	private List<PlayerBuilding> availableBuildings;

	[SerializeField]
	private List<PlayerBuilding> availableTowers;

	[Header("Gameplay")]
	private bool canBuildTowersOverLimit;

	[SerializeField]
	private GE_DotData bleedDotData;

	[SerializeField]
	private GE_DotData burnDotData;

	[SerializeField]
	private GE_DotData poisonDotData;

	[Savable("playerBuildings", false, true)]
	private List<GameplayObject> playerBuildings;

	[Savable("playerTowers", false, true)]
	private List<GameplayObject> playerTowers;

	[Savable("playerGems", false, true)]
	private List<GemData> playerGems;

	private Storage_ResourceData inventory;

	private Dictionary<string, object> loadedData;

	public List<PlayerBuilding> AvailableBuildings => availableBuildings;

	public List<PlayerBuilding> AvailableTowers => availableTowers;

	public List<PlayerBuilding> AvailableBuildingsAndTowers
	{
		get
		{
			List<PlayerBuilding> list = new List<PlayerBuilding>();
			list.AddRange(AvailableBuildings);
			list.AddRange(AvailableTowers);
			return list;
		}
	}

	public List<GameplayObject> PlayerBuildings
	{
		get
		{
			return playerBuildings;
		}
		private set
		{
			playerBuildings = value;
		}
	}

	public List<GameplayObject> PlayerTowers
	{
		get
		{
			return playerTowers;
		}
		private set
		{
			playerTowers = value;
		}
	}

	public List<GameplayObject> PlayerBuildingsAndTowers
	{
		get
		{
			List<GameplayObject> list = new List<GameplayObject>();
			list.AddRange(PlayerBuildings);
			list.AddRange(playerTowers);
			return list;
		}
	}

	public List<GemData> PlayerGems
	{
		get
		{
			return playerGems;
		}
		private set
		{
			playerGems = value;
		}
	}

	public Storage_ResourceData Inventory
	{
		get
		{
			return inventory;
		}
		set
		{
			inventory = value;
		}
	}

	public ResourceData EnemyEssenceResourceData => enemyEssenceResourceData;

	public bool CanBuildTowersOverLimit
	{
		get
		{
			return canBuildTowersOverLimit;
		}
		set
		{
			canBuildTowersOverLimit = value;
		}
	}

	public event Action<GameplayObject> onPlayerBuildingAdded;

	public event Action<GameplayObject> onPlayerBuildingRemoved;

	public event Action<GameplayObject> onPlayerTowerAdded;

	public event Action<GameplayObject> onPlayerTowerRemoved;

	public event Action<int> onEnemyEssenceAdded;

	private void Awake()
	{
		PlayerBuildings = new List<GameplayObject>();
		PlayerTowers = new List<GameplayObject>();
		playerGems = new List<GemData>();
		Inventory = GetComponent<Storage_ResourceData>();
		AddTowerUpgradesDatas();
	}

	private void Start()
	{
		PlayerUpgradesManager playerUpgradesManager = LTFunctionLibrary.GetPlayerUpgradesManager();
		if (playerUpgradesManager.UnlockedUpgrades != null && playerUpgradesManager.UnlockedUpgrades.Count > 0)
		{
			OnPlayerUpgradesLoaded();
		}
		else
		{
			LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded += OnPlayerUpgradesLoaded;
		}
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	private void OnGameStarted()
	{
		StatsComponent playerStatsComponent = LTFunctionLibrary.GetPlayerStatsComponent();
		playerStatsComponent.onStatChanged += OnPlayerStatChanged;
		OnPlayerStatChanged(EStats.BleedStacksConsumedPerTick, playerStatsComponent.GetStat(EStats.BleedStacksConsumedPerTick), 0f);
		OnPlayerStatChanged(EStats.BurnStacksConsumedPerTick, playerStatsComponent.GetStat(EStats.BurnStacksConsumedPerTick), 0f);
		OnPlayerStatChanged(EStats.PoisonStacksConsumedPerTick, playerStatsComponent.GetStat(EStats.PoisonStacksConsumedPerTick), 0f);
		InstantiateBuildings();
		LoadGems();
	}

	private void OnPlayerUpgradesLoaded()
	{
		CanBuildTowersOverLimit = LTFunctionLibrary.GetPlayerUpgradesManager().HasUnlockedUpgrade("PlayerUpgrade_towerTaxes_unlock");
	}

	private void OnDestroy()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded -= OnPlayerUpgradesLoaded;
	}

	private void AddTowerUpgradesDatas()
	{
		int count = AvailableTowers.Count;
		for (int i = 0; i < count; i++)
		{
			GameplayObjectData buildingData = AvailableTowers[i].BuildingData;
			if (!buildingData.IsUpgrade())
			{
				for (int j = 0; j < buildingData.UpgradeObjects.Length; j++)
				{
					AvailableTowers.Add(new PlayerBuilding(buildingData.UpgradeObjects[j], isUnlocked: false, AvailableTowers[i].Tier, hideIfLocked: false, availableInDemo: false));
				}
			}
		}
	}

	public void UnlockBuilding(GameplayObjectData buildingData)
	{
		if (buildingData.Type == EGameplayObjectType.Tower)
		{
			foreach (PlayerBuilding availableTower in AvailableTowers)
			{
				if (availableTower.BuildingData == buildingData)
				{
					availableTower.IsUnlocked = true;
				}
			}
			return;
		}
		foreach (PlayerBuilding availableBuilding in AvailableBuildings)
		{
			if (availableBuilding.BuildingData == buildingData)
			{
				availableBuilding.IsUnlocked = true;
			}
		}
	}

	public bool CanBuild(GameplayObject building)
	{
		if (building.ObjectData.Type == EGameplayObjectType.Tower)
		{
			if (!canBuildTowersOverLimit)
			{
				return !HasReachedTowerLimit();
			}
			return true;
		}
		return true;
	}

	public bool IsBuildingUnlocked(GameplayObjectData buildingData)
	{
		if (buildingData.Type == EGameplayObjectType.Tower)
		{
			return AvailableTowers.Find((PlayerBuilding x) => x.BuildingData == buildingData)?.IsUnlocked ?? false;
		}
		return AvailableBuildings.Find((PlayerBuilding x) => x.BuildingData == buildingData)?.IsUnlocked ?? false;
	}

	public void AddPlayerBuilding(GameplayObject building)
	{
		GameplayObjectData objectData = building.ObjectData;
		if ((object)objectData != null && objectData.Type == EGameplayObjectType.Tower)
		{
			PlayerTowers.AddUnique(building);
			this.onPlayerTowerAdded?.Invoke(building);
		}
		else
		{
			PlayerBuildings.AddUnique(building);
			this.onPlayerBuildingAdded?.Invoke(building);
		}
	}

	public void AddGem(GemData gemToAdd)
	{
		if ((bool)gemToAdd)
		{
			playerGems.Add(gemToAdd);
			SortPlayerGems();
		}
	}

	public void RemoveGem(GemData gemToRemove)
	{
		if ((bool)gemToRemove)
		{
			playerGems.Remove(gemToRemove);
			SortPlayerGems();
		}
	}

	private void SortPlayerGems()
	{
		playerGems.Sort(delegate(GemData x, GemData y)
		{
			int num = y.Value.CompareTo(x.Value);
			if (num == 0)
			{
				num = x.Id.CompareTo(y.Id);
			}
			return num;
		});
	}

	public void AddEnemyEssence(int amount, bool sendEvent = true, bool directlyFromEnemy = true)
	{
		if (directlyFromEnemy)
		{
			float num = (float)amount * LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.EnemyEssenceMultiplier);
			amount = (int)num + ((UnityEngine.Random.value <= num - (float)(int)num) ? 1 : 0);
		}
		inventory.StoreObject(enemyEssenceResourceData, amount, directlyFromEnemy ? Storage_ResourceData.EStoreSource.Enemy : Storage_ResourceData.EStoreSource.Effect);
		if (sendEvent)
		{
			this.onEnemyEssenceAdded?.Invoke(amount);
		}
	}

	public bool RemovePlayerBuilding(GameplayObject building)
	{
		bool result = false;
		if (building.ObjectData.Type == EGameplayObjectType.Tower)
		{
			if (PlayerTowers.Remove(building))
			{
				result = true;
				this.onPlayerTowerRemoved?.Invoke(building);
			}
		}
		else if (PlayerBuildings.Remove(building))
		{
			result = true;
			this.onPlayerBuildingRemoved?.Invoke(building);
		}
		return result;
	}

	public bool HasReachedTowerLimit()
	{
		return (float)playerTowers.Count >= LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.MaxTowersAmount);
	}

	public float GetCurrentTowersTaxesMultiplier()
	{
		float stat = LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.MaxTowersAmount);
		float stat2 = LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.MaxTowersTaxes);
		return FunctionLibrary.RoundToDecimals(1f + Mathf.Max((float)(playerTowers.Count + 1) - stat, 0f) * stat2, 2);
	}

	private void InstantiateBuildings()
	{
		if (loadedData == null)
		{
			return;
		}
		if (loadedData.ContainsKey("playerBuildings"))
		{
			foreach (Dictionary<string, object> item in loadedData["playerBuildings"] as List<Dictionary<string, object>>)
			{
				Vector3 position = (Vector3)item["transform.position"];
				Quaternion rotation = (Quaternion)item["transform.rotation"];
				string gameplayObjectId = (item["objectData"] as Dictionary<string, object>)["id"] as string;
				GameObject gameObject = InstantiatePlayerBuilding(position, rotation, gameplayObjectId);
				if ((bool)gameObject)
				{
					SaveSystem.LoadObjectData(gameObject, item);
				}
			}
		}
		if (loadedData.ContainsKey("playerTowers"))
		{
			foreach (Dictionary<string, object> item2 in loadedData["playerTowers"] as List<Dictionary<string, object>>)
			{
				Vector3 position = (Vector3)item2["transform.position"];
				Quaternion rotation = (Quaternion)item2["transform.rotation"];
				string gameplayObjectId = (item2["objectData"] as Dictionary<string, object>)["id"] as string;
				GameObject gameObject = InstantiatePlayerBuilding(position, rotation, gameplayObjectId);
				if ((bool)gameObject)
				{
					SaveSystem.LoadObjectData(gameObject, item2);
				}
			}
		}
		FogOfWarController.instance.UpdateFogOfWar();
	}

	private GameObject InstantiatePlayerBuilding(Vector3 position, Quaternion rotation, string gameplayObjectId)
	{
		PlacementComponent component = UnityEngine.Object.Instantiate(LTAssetsReferences.instance.GetBuildingDataById(gameplayObjectId).Prefab, position, rotation).GetComponent<PlacementComponent>();
		if (component.Place(checkCanBuildOnCurrentPosition: true, allowAutoSellableObjects: true, checkVisibility: false))
		{
			AddPlayerBuilding(component.MainObject);
			return component.gameObject;
		}
		UnityEngine.Object.Destroy(component.gameObject);
		return null;
	}

	private void LoadGems()
	{
		if (loadedData == null || !loadedData.ContainsKey("playerGems"))
		{
			return;
		}
		foreach (Dictionary<string, object> item in loadedData["playerGems"] as List<Dictionary<string, object>>)
		{
			AddGem(LTAssetsReferences.instance.GetGemDataById(item["id"] as string));
		}
	}

	private void OnPlayerStatChanged(EStats stat, float newValue, float oldValue)
	{
		switch (stat)
		{
		case EStats.BleedStacksConsumedPerTick:
			bleedDotData.StacksPerTick = Mathf.RoundToInt(newValue);
			break;
		case EStats.BurnStacksConsumedPerTick:
			burnDotData.StacksPerTick = Mathf.RoundToInt(newValue);
			break;
		case EStats.PoisonStacksConsumedPerTick:
			poisonDotData.StacksPerTick = Mathf.RoundToInt(newValue);
			break;
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			loadedData = data;
		}
	}
}
