using System;
using System.Collections.Generic;
using SmoothShakeFree;
using UnityEngine;

public class PlayerTower : GameplayObject
{
	[SerializeField]
	private WorldHealthBar worldHealthBar;

	[Header("FOW Area")]
	[SerializeField]
	private GameObject fowAreaObject;

	[Header("Conveyor Belts")]
	[SerializeField]
	private bool spawnConveyorBeltsOnStart = true;

	[SerializeField]
	private int conveyorBeltsCurrentTier;

	[SerializeField]
	private Transform[] conveyorBeltsTransforms;

	[SerializeField]
	private GameObject conveyorBeltPrefab_T1;

	[SerializeField]
	private GameObject conveyorBeltPrefab_T2;

	[SerializeField]
	private GameObject conveyorBeltPrefab_T3;

	private GameObject[] currentConveyorBelts;

	[Header("Starter towers")]
	[SerializeField]
	private Tower starterTowerPrefab;

	[SerializeField]
	private List<Transform> starterTowersSpawnTransforms;

	[SerializeField]
	private List<GameplayEffectData> starterTowersEffects;

	[Header("Damage animation")]
	[SerializeField]
	private ParticleSystem damageLightningStrikePS;

	[SerializeField]
	private AudioData damageLightningStrikeSound;

	[SerializeField]
	private SmoothShakeFreePreset lightningShakePreset;

	[Header("Game over animation")]
	[SerializeField]
	private GameObject mainModel;

	[SerializeField]
	private GameObject destroyedModel;

	[SerializeField]
	private ParticleSystem firstLightningsPS;

	[SerializeField]
	private ParticleSystem bigLightningPS;

	private bool hasLoadedData;

	private CombatComponent combatComponent;

	private PlacementComponent placementComponent;

	private StatsComponent statsComponent;

	public CombatComponent CombatComponent
	{
		get
		{
			return combatComponent;
		}
		set
		{
			combatComponent = value;
		}
	}

	public ParticleSystem FirstLightningsPS => firstLightningsPS;

	public ParticleSystem BigLightningPS => bigLightningPS;

	public GameObject MainModel => mainModel;

	public GameObject DestroyedModel => destroyedModel;

	public StatsComponent StatsComponent => statsComponent;

	public event Action<ResourceData, int> onBeltStoreResource;

	private void Awake()
	{
		CombatComponent = GetComponent<CombatComponent>();
		placementComponent = GetComponent<PlacementComponent>();
		statsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		combatComponent.onDamageTaken += OnDamageTaken;
		SetFOWRadius(StatsComponent.GetStat(EStats.LightTowerFOWRadius));
		if (spawnConveyorBeltsOnStart)
		{
			SetConveyorBeltsTier(conveyorBeltsCurrentTier);
		}
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
			{
				OnGameStarted();
			}
			else
			{
				LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
				lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
			}
		}
		StatsComponent.onStatChanged += OnStatChanged;
	}

	private void SpawnStarterTowers()
	{
		foreach (Transform starterTowersSpawnTransform in starterTowersSpawnTransforms)
		{
			Tower tower = UnityEngine.Object.Instantiate(starterTowerPrefab, starterTowersSpawnTransform);
			tower.PlacementComponent.Place();
			foreach (GameplayEffectData starterTowersEffect in starterTowersEffects)
			{
				tower.GameplayEffectsComponent.ApplyEffect(starterTowersEffect);
			}
			LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(tower.GameplayObject);
		}
	}

	private void SetFOWRadius(float radius)
	{
		fowAreaObject.transform.localScale = Vector3.one * radius;
		LTFunctionLibrary.GetFogOfWarController().UpdateFogOfWar();
	}

	public void SetConveyorBeltsTier(int tier)
	{
		conveyorBeltsCurrentTier = tier;
		if (currentConveyorBelts != null)
		{
			for (int num = currentConveyorBelts.Length - 1; num >= 0; num--)
			{
				ConveyorBelt component = currentConveyorBelts[num].GetComponent<ConveyorBelt_storage>();
				if (component.PlacementComponent.IsPlaced && component.CurrentBeltGroup != null)
				{
					component.ForceCallUnplace();
				}
				LTFunctionLibrary.GetPlayerData().RemovePlayerBuilding(component);
				UnityEngine.Object.Destroy(currentConveyorBelts[num]);
			}
		}
		currentConveyorBelts = new GameObject[3];
		int num2 = 0;
		currentConveyorBelts[num2] = SpawnConveyorBelt(tier, conveyorBeltsTransforms[num2]);
		placementComponent.ChildObjects[num2].gameplayObject = currentConveyorBelts[num2].GetComponent<GameplayObject>();
		num2 = 1;
		currentConveyorBelts[num2] = SpawnConveyorBelt(tier, conveyorBeltsTransforms[num2]);
		placementComponent.ChildObjects[num2].gameplayObject = currentConveyorBelts[num2].GetComponent<GameplayObject>();
		num2 = 2;
		currentConveyorBelts[num2] = SpawnConveyorBelt(tier, conveyorBeltsTransforms[num2]);
		placementComponent.ChildObjects[num2].gameplayObject = currentConveyorBelts[num2].GetComponent<GameplayObject>();
		GameObject[] array = currentConveyorBelts;
		for (int i = 0; i < array.Length; i++)
		{
			ConveyorBelt_storage component2 = array[i].GetComponent<ConveyorBelt_storage>();
			component2.onStoreResource += delegate(ResourceData resourceData, int amount)
			{
				this.onBeltStoreResource?.Invoke(resourceData, amount);
			};
			LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(component2);
		}
	}

	private GameObject SpawnConveyorBelt(int tier, Transform parent)
	{
		GameObject gameObject = tier switch
		{
			0 => UnityEngine.Object.Instantiate(conveyorBeltPrefab_T1, parent), 
			1 => UnityEngine.Object.Instantiate(conveyorBeltPrefab_T2, parent), 
			2 => UnityEngine.Object.Instantiate(conveyorBeltPrefab_T3, parent), 
			_ => UnityEngine.Object.Instantiate(conveyorBeltPrefab_T1, parent), 
		};
		gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		return gameObject;
	}

	private void OnGameStarted()
	{
		if (!hasLoadedData)
		{
			SpawnStarterTowers();
		}
		InitWorldHealthBar();
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			lTGameManager.onGameStarted = (Action)Delegate.Remove(lTGameManager.onGameStarted, new Action(OnGameStarted));
		}
	}

	private void InitWorldHealthBar()
	{
		if ((bool)worldHealthBar)
		{
			worldHealthBar = UnityEngine.Object.Instantiate(worldHealthBar);
			worldHealthBar.CombatComponent = CombatComponent;
		}
	}

	private void OnDamageTaken(GameObject cuaser, float damageTaken)
	{
		damageLightningStrikePS.Play();
		AudioSystem.Instance.PlaySound3D(damageLightningStrikeSound, damageLightningStrikePS.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 5f);
		if (base.Model.GetComponent<MeshRenderer>().isVisible)
		{
			LTFunctionLibrary.GetLTPlayerController().ShakeCamera(lightningShakePreset);
		}
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		switch (stat)
		{
		case EStats.LightTowerFOWRadius:
			SetFOWRadius(newValue);
			break;
		case EStats.MaxUnlockedTier:
			SetConveyorBeltsTier((int)newValue);
			break;
		}
	}

	public override void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		base.OnLoad(data, hasLoadedSomething);
		hasLoadedData = hasLoadedSomething;
	}
}
