using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TimeManager))]
[RequireComponent(typeof(CyclesManager))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(VictoryAnimation))]
[RequireComponent(typeof(GameOverAnimation))]
[RequireComponent(typeof(IdleManager))]
[RequireComponent(typeof(GameStatsManager))]
public abstract class LTGameManager : GameManager, ISavable
{
	public enum EShowGridMode
	{
		All = 0,
		Full = 1,
		Partial = 2
	}

	public enum EGameState
	{
		None = 0,
		Playing = 1,
		Victory = 2,
		Defeat = 3,
		EndingAnimation = 4
	}

	public static int playedGames;

	public static bool wishlistMessageShown;

	public Action onGameStarted;

	public Action onGameEnded;

	public Action onGameOver;

	public Action onVictoryAnimationStarted;

	public Action onGameOverAnimationStarted;

	public Action onShowGridChanged;

	public ScriptableRendererFeature circleRangeIndicatorRenderer;

	public ScriptableRendererFeature squaredRangeIndicatorRenderer;

	[Header("References")]
	[SerializeField]
	private PlayerTower playerTower;

	[SerializeField]
	private EnemyTower enemyTower;

	[SerializeField]
	private Material worldGridMaterial;

	[SerializeField]
	private Material circleRangeIndicatorMaterial;

	[SerializeField]
	private Material squaredRangeIndicatorMaterial;

	[Header("Tower Upgrade Animation")]
	[SerializeField]
	private ParticleSystem towerUpgradeParticlesBody;

	[SerializeField]
	private ParticleSystem towerUpgradeParticlesBlinks;

	[SerializeField]
	private ParticleSystem towerUpgradeParticlesBase;

	[SerializeField]
	private AudioData towerUpgradeSound;

	[Header("Gameplay")]
	[SerializeField]
	private List<ResourceData> resourceDatasReferences;

	[SerializeField]
	[Tooltip("Porcentaje de coste devuelto al vender un edificio que no sea torre")]
	private float sellBuildingCostMultiplier = 0.5f;

	[SerializeField]
	[Tooltip("Porcentaje de coste devuelto al vender una torre")]
	private float sellTowerCostMultiplier = 0.5f;

	[SerializeField]
	[Tooltip("Tiempo que tiene que estar atacando una torre para poder ser mejorada")]
	private float towerExperienceToUpgrade = 90f;

	[Header("Debug")]
	[SerializeField]
	private bool freeCosts;

	[SerializeField]
	private bool ignoreExperienceToUpgrade;

	[SerializeField]
	protected bool noEnemies;

	[SerializeField]
	[Tooltip("Player buildings already added on scene that have to be added to the PlayerBuildings list on Start")]
	private GameplayObject[] scenePlayerBuildings;

	private GameStatsManager gameStatsManager;

	private TimeManager timeManager;

	private CyclesManager cyclesManager;

	private PlayerData playerData;

	private IdleManager idleManager;

	protected VictoryAnimation victoryAnimation;

	protected BossVictoryAnimation bossVictoryAnimation;

	protected GameOverAnimation gameOverAnimation;

	private GameplayEffectsComponent playerGameplayEffectsComponent;

	private StatsComponent playerStatsComponent;

	private bool showFullGrid;

	private bool showPartialGrid;

	private bool firstTimeBossDefeated;

	private EGameState gameState;

	[Savable("isLoadedGame", true, false)]
	private bool isLoadedGame;

	[Savable("chestCoins", true, false)]
	private int chestCoins;

	[Savable("killedBossesAmount", true, false)]
	private int killedBossesAmount;

	private Coroutine updateGridCenterPositionCoroutine;

	public GameStatsManager GameStatsManager
	{
		get
		{
			return gameStatsManager;
		}
		private set
		{
			gameStatsManager = value;
		}
	}

	public TimeManager TimeManager
	{
		get
		{
			return timeManager;
		}
		private set
		{
			timeManager = value;
		}
	}

	public CyclesManager CyclesManager
	{
		get
		{
			return cyclesManager;
		}
		private set
		{
			cyclesManager = value;
		}
	}

	public EGameState GameState
	{
		get
		{
			return gameState;
		}
		protected set
		{
			gameState = value;
		}
	}

	public PlayerData PlayerData
	{
		get
		{
			return playerData;
		}
		set
		{
			playerData = value;
		}
	}

	public IdleManager IdleManager => idleManager;

	public PlayerTower PlayerTower
	{
		get
		{
			return playerTower;
		}
		set
		{
			playerTower = value;
		}
	}

	public EnemyTower EnemyTower
	{
		get
		{
			return enemyTower;
		}
		set
		{
			enemyTower = value;
		}
	}

	public GameplayObject[] ScenePlayerBuildings
	{
		get
		{
			return scenePlayerBuildings;
		}
		set
		{
			scenePlayerBuildings = value;
		}
	}

	public int ChestCoins
	{
		get
		{
			return chestCoins;
		}
		set
		{
			chestCoins = value;
		}
	}

	public float SellTowerCostMultiplier => sellTowerCostMultiplier;

	public float TowerExperienceToUpgrade
	{
		get
		{
			if (!ignoreExperienceToUpgrade)
			{
				return towerExperienceToUpgrade;
			}
			return 0f;
		}
	}

	public bool FirstTimeBossDefeated
	{
		get
		{
			return firstTimeBossDefeated;
		}
		protected set
		{
			firstTimeBossDefeated = value;
		}
	}

	public StatsComponent PlayerStatsComponent => playerStatsComponent;

	public bool IsLoadedGame => isLoadedGame;

	protected int KilledBossesAmount
	{
		get
		{
			return killedBossesAmount;
		}
		private set
		{
			killedBossesAmount = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GameStatsManager = GetComponent<GameStatsManager>();
		TimeManager = GetComponent<TimeManager>();
		CyclesManager = GetComponent<CyclesManager>();
		PlayerData = GetComponent<PlayerData>();
		idleManager = GetComponent<IdleManager>();
		victoryAnimation = GetComponent<VictoryAnimation>();
		gameOverAnimation = GetComponent<GameOverAnimation>();
		bossVictoryAnimation = GetComponent<BossVictoryAnimation>();
	}

	protected override void Start()
	{
		base.Start();
		victoryAnimation.onVictoryAnimationEnded += delegate
		{
			EndGame();
		};
		gameOverAnimation.onGameOverAnimationEnded += delegate
		{
			GameOver();
		};
		LTFunctionLibrary.GetSpawnersManager().onEnemyDies += OnEnemyDie;
		if ((bool)bossVictoryAnimation)
		{
			bossVictoryAnimation.onVictoryAnimationEnded += delegate
			{
				EndGame();
			};
		}
		if ((bool)PlayerTower)
		{
			PlayerTower.CombatComponent.onDie += OnPlayerTowerDie;
		}
		if ((bool)EnemyTower)
		{
			EnemyTower.CombatComponent.onDie += OnEnemyTowerDie;
		}
		CyclesManager obj = CyclesManager;
		obj.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(obj.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		GameplayObject[] array = ScenePlayerBuildings;
		foreach (GameplayObject building in array)
		{
			playerData.AddPlayerBuilding(building);
		}
	}

	private void OnDestroy()
	{
		HideRangeIndicator();
		ShowGrid(show: false, EShowGridMode.All);
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded -= LoadPlayerUpgrades;
	}

	public override void SpawnPlayer()
	{
		base.SpawnPlayer();
		playerGameplayEffectsComponent = base.PlayerCharacter.GetComponent<GameplayEffectsComponent>();
		playerStatsComponent = base.PlayerCharacter.GetComponent<StatsComponent>();
		if ((bool)LTFunctionLibrary.GetPlayerUpgradesManager())
		{
			LoadPlayerUpgrades();
			LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded += LoadPlayerUpgrades;
		}
		StartGame();
	}

	protected virtual void LoadPlayerUpgrades()
	{
		foreach (PlayerUpgrade allAvailableUpgrade in LTFunctionLibrary.GetPlayerUpgradesManager().GetAllAvailableUpgrades())
		{
			GameplayEffectData[] grantedGameplayEffects = allAvailableUpgrade.GrantedGameplayEffects;
			foreach (GameplayEffectData effectData in grantedGameplayEffects)
			{
				playerGameplayEffectsComponent.ApplyEffect(effectData);
			}
		}
	}

	protected virtual void StartGame()
	{
		if (SceneManager.GetActiveScene().buildIndex > 2)
		{
			playedGames++;
		}
		Time.timeScale = 1f;
		GameState = EGameState.Playing;
		onGameStarted?.Invoke();
	}

	public void RestartGame()
	{
		if (MatchInfo.instance.CurrentLevelData == null)
		{
			LoadingScreenController.sceneToLoadIdx = 0;
		}
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

	public virtual void GameOver()
	{
		CheckIsNewRecord();
		GameState = EGameState.Defeat;
		if (SaveSystem.instance.ExistsSavedGame())
		{
			SaveSystem.instance.DeleteSavedGame();
		}
		if ((bool)MatchInfo.instance.CurrentLevelData)
		{
			LTFunctionLibrary.GetLevelsProgressionManager().SetLevelPlayed(MatchInfo.instance.CurrentLevelData.Id);
		}
		LTFunctionLibrary.GetPlayerUpgradesManager().AddMoney(CalculateMoneyReward(hasWon: false, includeChests: true));
		PauseGame(pause: true);
		onGameOver?.Invoke();
	}

	protected virtual void EndGame()
	{
		CheckIsNewRecord();
		GameState = EGameState.Victory;
		PauseGame(pause: true);
		onGameEnded?.Invoke();
	}

	private void CheckIsNewRecord()
	{
		if (!(LTFunctionLibrary.GetMatchInfo().CurrentLevelData == null))
		{
			LevelsProgressionManager.FLevelProgressionInfo levelProgressionInfoByID = LTFunctionLibrary.GetLevelsProgressionManager().GetLevelProgressionInfoByID(LTFunctionLibrary.GetMatchInfo().CurrentLevelData.Id);
			EMapSize mapSize = LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings.MapSize;
			int num = CalculateScore();
			int score = levelProgressionInfoByID.GetScore(mapSize);
			if (num > score)
			{
				levelProgressionInfoByID.SetScore(mapSize, num);
				SaveSystem.instance.SaveData();
			}
		}
	}

	public void DoDamagePlayer(int damage)
	{
		PlayerTower.CombatComponent.DoDamage(null, new FDamageData(damage, EDamageMultiplier.Normal, EDamageMultiplier.Normal, EDamageMultiplier.Normal));
	}

	public void ShowGrid(bool show, EShowGridMode showGridMode)
	{
		switch (showGridMode)
		{
		case EShowGridMode.All:
			showPartialGrid = show;
			showFullGrid = show;
			break;
		case EShowGridMode.Full:
			showFullGrid = show;
			break;
		case EShowGridMode.Partial:
			showPartialGrid = show;
			break;
		}
		if (showFullGrid)
		{
			worldGridMaterial.SetInt("_Active", 1);
			worldGridMaterial.SetInt("_CutCircle", 0);
			this.StopCoroutineCheckingVar(ref updateGridCenterPositionCoroutine);
		}
		else if (showPartialGrid)
		{
			worldGridMaterial.SetInt("_Active", 1);
			worldGridMaterial.SetInt("_CutCircle", 1);
			this.StartCoroutineCheckingVar(UpdateGridCenterPositionCoroutine(), ref updateGridCenterPositionCoroutine);
		}
		else
		{
			worldGridMaterial.SetInt("_Active", 0);
			this.StopCoroutineCheckingVar(ref updateGridCenterPositionCoroutine);
		}
		onShowGridChanged?.Invoke();
	}

	public bool IsGridVisible(EShowGridMode showGridMode)
	{
		switch (showGridMode)
		{
		case EShowGridMode.All:
			if (!showFullGrid)
			{
				return showPartialGrid;
			}
			return true;
		case EShowGridMode.Full:
			return showFullGrid;
		case EShowGridMode.Partial:
			return showPartialGrid;
		default:
			return false;
		}
	}

	public void ToggleShowFullGrid()
	{
		if (IsGridVisible(EShowGridMode.Full))
		{
			ShowGrid(show: false, EShowGridMode.Full);
		}
		else
		{
			ShowGrid(show: true, EShowGridMode.Full);
		}
	}

	public void ShowCircleRangeIndicator(Vector3 position, float radius, float innerRadius)
	{
		circleRangeIndicatorRenderer.SetActive(active: true);
		circleRangeIndicatorMaterial.SetVector("_Center", position);
		circleRangeIndicatorMaterial.SetFloat("_Radius", radius);
		circleRangeIndicatorMaterial.SetFloat("_InnerRadius", innerRadius);
		circleRangeIndicatorMaterial.SetVector("_ForwardDirection", Vector3.forward);
		circleRangeIndicatorMaterial.SetFloat("_ConeAngle", 360f);
	}

	public void ShowConeRangeIndicator(Vector3 position, float radius, float innerRadius, Vector3 forwardDirection, float degrees)
	{
		circleRangeIndicatorRenderer.SetActive(active: true);
		circleRangeIndicatorMaterial.SetVector("_Center", position);
		circleRangeIndicatorMaterial.SetFloat("_Radius", radius);
		circleRangeIndicatorMaterial.SetFloat("_InnerRadius", innerRadius);
		circleRangeIndicatorMaterial.SetVector("_ForwardDirection", forwardDirection);
		circleRangeIndicatorMaterial.SetFloat("_ConeAngle", degrees);
	}

	public void ShowSquaredRangeIndicator(Vector3 position, float width, float lenght, Vector3 forwardDirection)
	{
		squaredRangeIndicatorRenderer.SetActive(active: true);
		squaredRangeIndicatorMaterial.SetVector("_Center", position + forwardDirection * (lenght * 0.5f + 0.5f));
		if ((int)forwardDirection.z != 0)
		{
			squaredRangeIndicatorMaterial.SetFloat("_Width", width);
			squaredRangeIndicatorMaterial.SetFloat("_Length", lenght);
		}
		else
		{
			squaredRangeIndicatorMaterial.SetFloat("_Width", lenght);
			squaredRangeIndicatorMaterial.SetFloat("_Length", width);
		}
	}

	public void HideRangeIndicator()
	{
		circleRangeIndicatorRenderer.SetActive(active: false);
		squaredRangeIndicatorRenderer.SetActive(active: false);
	}

	public bool CanAfford(IEnumerable<Cost> cost)
	{
		foreach (Cost item in cost)
		{
			if (PlayerData.Inventory.GetStoredObjectAmount(item.Resource.Id) < item.Amount)
			{
				return false;
			}
		}
		return true;
	}

	public bool PayCost(IEnumerable<Cost> cost)
	{
		if (CanAfford(cost))
		{
			Storage_ResourceData inventory = PlayerData.Inventory;
			foreach (Cost item in cost)
			{
				inventory.RemoveStoredObjectByID(item.Resource.Id, item.Amount);
			}
			return true;
		}
		return false;
	}

	public bool SellBuilding(GameplayObject buildingToSell)
	{
		if (!buildingToSell.ObjectData.CanBeSold)
		{
			return false;
		}
		if (buildingToSell.ObjectData.Type == EGameplayObjectType.Tower && buildingToSell.GetComponent<Tower>().IsUpgrading)
		{
			return false;
		}
		Cost[] array = new Cost[buildingToSell.ObjectData.FullCost.Length];
		buildingToSell.ObjectData.FullCost.CopyTo(array, 0);
		if (DeleteBuilding(buildingToSell))
		{
			Storage_ResourceData playerInventory = LTFunctionLibrary.GetPlayerInventory();
			Cost[] array2 = array;
			foreach (Cost cost in array2)
			{
				playerInventory.StoreObject(cost.Resource, Mathf.CeilToInt((float)cost.Amount * ((buildingToSell.ObjectData.Type == EGameplayObjectType.Tower) ? SellTowerCostMultiplier : sellBuildingCostMultiplier)), Storage_ResourceData.EStoreSource.Refund);
			}
			return true;
		}
		return false;
	}

	public bool DeleteBuilding(GameplayObject buildingToRemove)
	{
		if (playerData.RemovePlayerBuilding(buildingToRemove))
		{
			if (buildingToRemove.TryGetComponent<GemsComponent>(out var component))
			{
				for (int i = 0; i < component.Gems.Length; i++)
				{
					if (component.Gems[i] != null)
					{
						playerData.AddGem(component.Gems[i]);
						component.RemoveGem(i);
					}
				}
			}
			buildingToRemove.GetComponent<PlacementComponent>().Unplace();
			UnityEngine.Object.Destroy(buildingToRemove.gameObject);
			return true;
		}
		return false;
	}

	public Tower UpgradeTower(Tower towerToUpgrade, GameplayObjectData upgradeData)
	{
		if (CanAfford(upgradeData.Cost))
		{
			LTFunctionLibrary.GetLTGameManager().PayCost(upgradeData.Cost);
			towerToUpgrade.PlacementComponent.Unplace();
			Tower component = UnityEngine.Object.Instantiate(upgradeData.Prefab, towerToUpgrade.transform.position, towerToUpgrade.transform.rotation).GetComponent<Tower>();
			component.SetData(towerToUpgrade.GetData());
			towerToUpgrade.IsUpgrading = true;
			component.IsUpgrading = true;
			List<GemData> list = towerToUpgrade.GemsComponent.Gems.ToList();
			GameObject model = towerToUpgrade.GameplayObject.Model;
			model.transform.SetParent(null, worldPositionStays: true);
			LTFunctionLibrary.GetLTGameManager().DeleteBuilding(towerToUpgrade.GameplayObject);
			LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(component.GameplayObject);
			for (int i = 0; i < list.Count; i++)
			{
				component.GemsComponent.AddGem(list[i]);
				playerData.RemoveGem(list[i]);
			}
			PlayTowerUpgradeAnimation(model, component);
			return component;
		}
		return null;
	}

	private void PlayTowerUpgradeAnimation(GameObject towerToUpgradeModel, Tower upgradedTower)
	{
		GameObject upgradedTowerModel = upgradedTower.GameplayObject.Model;
		upgradedTowerModel.SetActive(value: false);
		Color emissiveColor = new Color(1.97f, 1.55f, 0.74f) * 2f;
		float modelHeight = 0.25f;
		float duration = 0.4f;
		float shakeDuration = 0.75f;
		float towerRadius = (float)Mathf.Max(upgradedTower.PlacementComponent.Width, upgradedTower.PlacementComponent.Length) * 0.5f;
		Renderer[] towerToUpgradeRenderers = towerToUpgradeModel.GetComponentsInChildren<Renderer>();
		AudioSystem.Instance.PlaySound2D(towerUpgradeSound, AudioSystem.EAudioMixerGroup.UI, 0f, 0f, loop: false, AudioSystem.EAudioPriority.High);
		ParticleSystem particleSystem = UnityEngine.Object.Instantiate(towerUpgradeParticlesBlinks, upgradedTower.PlacementComponent.GetCenter(), Quaternion.identity);
		ParticleSystem.ShapeModule shape = particleSystem.shape;
		shape.radius = towerRadius + 0.5f;
		particleSystem.Play(withChildren: true);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = towerToUpgradeModel.transform.DOLocalMoveY(modelHeight, duration).SetEase(Ease.OutCirc).SetUpdate(isIndependentUpdate: true);
		tweenerCore.onComplete = (TweenCallback)Delegate.Combine(tweenerCore.onComplete, (TweenCallback)delegate
		{
			Renderer[] array = towerToUpgradeRenderers;
			foreach (Renderer renderer in array)
			{
				if (renderer.material.HasProperty("_Emission"))
				{
					renderer.material.DOColor(emissiveColor, "_Emission", shakeDuration).SetEase(Ease.InQuart).SetUpdate(isIndependentUpdate: true);
				}
			}
			Sequence sequence = DOTween.Sequence();
			int num = 3;
			float duration2 = shakeDuration / (float)num;
			for (int j = 1; j <= num; j++)
			{
				float num2 = (float)j / (float)num * 0.02f;
				sequence.Append(towerToUpgradeModel.transform.DOShakePosition(duration2, new Vector3(1f, 0f, 1f) * num2, 100, 90f, snapping: false, fadeOut: false).SetUpdate(isIndependentUpdate: true));
			}
			sequence.Play().SetUpdate(isIndependentUpdate: true);
			sequence.onComplete = (TweenCallback)Delegate.Combine(sequence.onComplete, (TweenCallback)delegate
			{
				UnityEngine.Object.Destroy(towerToUpgradeModel);
				upgradedTower.PlacementComponent.Place();
				upgradedTower.IsUpgrading = false;
				upgradedTowerModel.SetActive(value: true);
				upgradedTowerModel.transform.localPosition += Vector3.up * modelHeight;
				upgradedTowerModel.transform.DOLocalMoveY(0f, 0.04f).SetEase(Ease.Linear).SetUpdate(isIndependentUpdate: true);
				Renderer[] componentsInChildren = upgradedTowerModel.GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer2 in componentsInChildren)
				{
					if (renderer2.material.HasProperty("_Emission"))
					{
						renderer2.material.SetColor("_Emission", emissiveColor);
						renderer2.material.DOColor(Color.black, "_Emission", 0.15f).SetEase(Ease.OutSine).SetUpdate(isIndependentUpdate: true);
					}
				}
				MeshFilter[] componentsInChildren2 = upgradedTowerModel.GetComponentsInChildren<MeshFilter>();
				CombineInstance[] array2 = new CombineInstance[componentsInChildren2.Length];
				for (int l = 0; l < componentsInChildren2.Length; l++)
				{
					array2[l].mesh = componentsInChildren2[l].sharedMesh;
					array2[l].transform = upgradedTowerModel.transform.worldToLocalMatrix * componentsInChildren2[l].transform.localToWorldMatrix;
				}
				Mesh mesh = new Mesh();
				mesh.CombineMeshes(array2, mergeSubMeshes: true, useMatrices: true);
				ParticleSystem particleSystem2 = UnityEngine.Object.Instantiate(towerUpgradeParticlesBody, upgradedTower.PlacementComponent.GetCenter(), upgradedTower.transform.rotation);
				ParticleSystem.ShapeModule shape2 = particleSystem2.shape;
				ParticleSystem.MainModule main = particleSystem2.main;
				shape2.mesh = mesh;
				main.startDelay = 0.065f;
				particleSystem2.Play();
				ParticleSystem particleSystem3 = UnityEngine.Object.Instantiate(towerUpgradeParticlesBase, upgradedTower.PlacementComponent.GetCenter(), Quaternion.identity);
				ParticleSystem.ShapeModule shape3 = particleSystem3.shape;
				ParticleSystem.MainModule main2 = particleSystem3.main;
				shape3.radius = towerRadius;
				main2.startDelay = 0.04f;
				particleSystem3.Play(withChildren: true);
			});
		});
	}

	public abstract int CalculateMoneyReward(bool hasWon, bool includeChests);

	public virtual int CalculateScore()
	{
		GameStatsManager obj = LTFunctionLibrary.GetGameStatsManager();
		float totalDamage = obj.GetTotalDamageReport().TotalDamage;
		float totalObtainedResourceValue = obj.GetTotalObtainedResourceValue();
		int num = LTFunctionLibrary.GetCyclesManager().CurrentCycle + 1;
		int num2 = KilledBossesAmount;
		float num3 = 1f;
		MatchSettings currentMatchSettings = LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings;
		num3 = MatchSettings.GetEnemyLifeMultiplier(currentMatchSettings.MatchDifficulty);
		float num4 = 1f;
		if (!currentMatchSettings.BuildDuringPause)
		{
			num4 = 1.2f;
		}
		return Mathf.CeilToInt((totalDamage + totalObtainedResourceValue) / 1000f * (float)num * (float)(num2 + 1) * num3 * num4);
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		if (Time.timeSinceLevelLoad > 20f && mode == ECycleMode.Neutral && cycle > 0 && (bool)MatchInfo.instance.CurrentLevelData)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("levelDataId", MatchInfo.instance.CurrentLevelData.Id);
			dictionary.Add("mapGeneratorVersion", MatchInfo.instance.CurrentLevelData.MapGeneratorVersion);
			dictionary.Add("currentCycle", LTFunctionLibrary.GetCyclesManager().CurrentCycle);
			dictionary.Add("currentTime", LTFunctionLibrary.GetTimeManager().GetTimeSeconds());
			dictionary.Add("matchMode", MatchInfo.instance.CurrentMatchMode);
			SaveSystem.instance.SaveGame(dictionary);
		}
	}

	private void OnEnemyDie(Enemy enemy)
	{
		if (enemy.Data.Boss && gameState != EGameState.EndingAnimation)
		{
			KilledBossesAmount++;
		}
	}

	protected virtual void OnPlayerTowerDie(CombatComponent combatComponent)
	{
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Play);
		GameState = EGameState.EndingAnimation;
		PlayerTower.CombatComponent.BCanBeDamaged = false;
		gameOverAnimation.PlayGameOverAnimation();
		onGameOverAnimationStarted?.Invoke();
	}

	private void OnEnemyTowerDie(CombatComponent combatComponent)
	{
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Play);
		GameState = EGameState.EndingAnimation;
		PlayerTower.CombatComponent.BCanBeDamaged = false;
		victoryAnimation.PlayVictoryAnimation();
		onVictoryAnimationStarted?.Invoke();
	}

	private IEnumerator UpdateGridCenterPositionCoroutine()
	{
		while (true)
		{
			worldGridMaterial.SetVector("_CenterPosition", (base.PlayerController as LTPlayerController).GetPointerWorldPosition());
			yield return null;
		}
	}

	public void OnSave()
	{
		isLoadedGame = true;
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
