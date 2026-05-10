using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Character, ISelectable, ISampleableData, ISavable
{
	public struct FTowerStats
	{
		private float damage;

		private float attackSpeed;

		private float range;

		public float Damage => damage;

		public float AttackSpeed => attackSpeed;

		public float Range => range;

		public FTowerStats(float damage, float attackSpeed, float range)
		{
			this.damage = damage;
			this.attackSpeed = attackSpeed;
			this.range = range;
		}

		public void ApplyGE(IEnumerable<GameplayEffectData> GEDatas)
		{
			float num = damage;
			float num2 = attackSpeed;
			float num3 = range;
			foreach (GameplayEffectData GEData in GEDatas)
			{
				if (!(GEData is GE_StatModifierData))
				{
					continue;
				}
				GE_StatModifierData gE_StatModifierData = GEData as GE_StatModifierData;
				switch (gE_StatModifierData.Stat)
				{
				case EStats.BaseDamage:
					if (gE_StatModifierData.ModifierOperation == ModifierOperation.Additive)
					{
						damage += gE_StatModifierData.StatValue;
					}
					else if (gE_StatModifierData.ModifierOperation == ModifierOperation.Multiplicative)
					{
						damage += num * gE_StatModifierData.StatValue;
					}
					break;
				case EStats.AttackSpeed:
					if (gE_StatModifierData.ModifierOperation == ModifierOperation.Additive)
					{
						attackSpeed += gE_StatModifierData.StatValue;
					}
					else if (gE_StatModifierData.ModifierOperation == ModifierOperation.Multiplicative)
					{
						attackSpeed += num2 * gE_StatModifierData.StatValue;
					}
					break;
				case EStats.Range:
					if (gE_StatModifierData.ModifierOperation == ModifierOperation.Additive)
					{
						range += gE_StatModifierData.StatValue;
					}
					else if (gE_StatModifierData.ModifierOperation == ModifierOperation.Multiplicative)
					{
						range += num3 * gE_StatModifierData.StatValue;
					}
					break;
				}
			}
		}
	}

	[SerializeField]
	private float experiencieMultiplier = 1f;

	[SerializeField]
	private float height;

	[SerializeField]
	private TowerTargetProvider defaultTargetProvider;

	[Savable("experience", true, false)]
	private float experience;

	private bool hasReceivedExperienceThisFrame;

	private float currentAttackSpeed;

	[Savable("firstTargetProviderId", true, false)]
	private string firstTargetProviderId;

	[Savable("secondTargetProviderId", true, false)]
	private string secondTargetProviderId;

	private TowerCombatComponent combatComponent;

	private TowerAnimationComponent animationComponent;

	private PlacementComponent placementComponent;

	private StatsComponent statsComponent;

	private GameplayEffectsComponent gameplayEffectsComponent;

	private GemsComponent gemsComponent;

	private GameplayObject gameplayObject;

	private AbilityManager abilityManager;

	private Enemy target;

	private bool canChangeTarget = true;

	private int isEnabled;

	private bool isUpgrading;

	private Coroutine selectionCoroutine;

	public Enemy Target
	{
		get
		{
			return target;
		}
		set
		{
			if (CanChangeTarget && target != value)
			{
				Enemy arg = target;
				target = value;
				this.onTargetChanged?.Invoke(target, arg);
			}
		}
	}

	public bool CanChangeTarget
	{
		get
		{
			return canChangeTarget;
		}
		set
		{
			canChangeTarget = value;
		}
	}

	public TowerCombatComponent CombatComponent => combatComponent;

	public StatsComponent StatsComponent => statsComponent;

	public GameplayEffectsComponent GameplayEffectsComponent => gameplayEffectsComponent;

	public GemsComponent GemsComponent => gemsComponent;

	public GameplayObject GameplayObject => gameplayObject;

	public PlacementComponent PlacementComponent => placementComponent;

	public float Experience
	{
		get
		{
			return experience;
		}
		private set
		{
			experience = Mathf.Min(value, LTFunctionLibrary.GetLTGameManager().TowerExperienceToUpgrade);
			this.onExperienceChanged?.Invoke(experience, experience / LTFunctionLibrary.GetLTGameManager().TowerExperienceToUpgrade);
		}
	}

	public bool IsEnabled
	{
		get
		{
			return isEnabled == 0;
		}
		set
		{
			if (value)
			{
				isEnabled = Math.Max(isEnabled - 1, 0);
			}
			else
			{
				isEnabled++;
			}
			if (!value && isEnabled == 1)
			{
				abilityManager.CurrentAbility?.CancelAbility();
				this.onTowerEnabledChanged?.Invoke(obj: false);
			}
			else if (isEnabled == 0)
			{
				this.onTowerEnabledChanged?.Invoke(obj: true);
			}
		}
	}

	public bool IsUpgrading
	{
		get
		{
			return isUpgrading;
		}
		set
		{
			bool num = isUpgrading;
			isUpgrading = value;
			if (num && !isUpgrading)
			{
				this.onEndedUpgrade?.Invoke();
			}
		}
	}

	public float Height => height;

	public TowerTargetProvider DefaultTargetProvider => defaultTargetProvider;

	public event Action<Enemy, Enemy> onTargetChanged;

	public event Action<float, float> onExperienceChanged;

	public event Action<bool> onTowerEnabledChanged;

	public event Action onEndedUpgrade;

	private void AutoCalculateHeight()
	{
		Bounds bounds = default(Bounds);
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			bounds.Encapsulate(meshRenderer.bounds);
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			bounds.Encapsulate(skinnedMeshRenderer.bounds);
		}
		height = bounds.max.y;
	}

	protected override void Awake()
	{
		combatComponent = GetComponent<TowerCombatComponent>();
		animationComponent = GetComponent<TowerAnimationComponent>();
		placementComponent = GetComponentInParent<PlacementComponent>();
		statsComponent = GetComponent<StatsComponent>();
		gameplayEffectsComponent = GetComponent<GameplayEffectsComponent>();
		gemsComponent = GetComponent<GemsComponent>();
		gameplayObject = GetComponent<GameplayObject>();
		abilityManager = GetComponent<AbilityManager>();
		IsEnabled = false;
		base.Awake();
	}

	protected override void Start()
	{
		base.Start();
		PlacementComponent.onPlace += OnPlace;
		PlacementComponent.onUnplace += OnUnplace;
		currentAttackSpeed = statsComponent.GetStatBase(EStats.AttackSpeed);
		if ((bool)animationComponent)
		{
			animationComponent.onAnimationAllowTargetChange += delegate
			{
				CanChangeTarget = true;
			};
			animationComponent.onAnimationPreventTargetChange += delegate
			{
				CanChangeTarget = false;
			};
		}
		if (PlacementComponent.IsPlaced)
		{
			OnPlace(PlacementComponent);
		}
		StatsComponent.onStatChanged += OnStatChanged;
		combatComponent.onDamageEnemy += OnDamageEnemy;
	}

	private void Update()
	{
		if (IsEnabled && !IsUpgrading && (bool)target && target.CombatComponent.IsAlive())
		{
			CombatComponent.Aim(target.CombatComponent.TargetObject);
			CombatComponent.Attack(target.CombatComponent);
		}
		hasReceivedExperienceThisFrame = false;
	}

	public override void OnPosses(Controller controller)
	{
		base.OnPosses(controller);
		(controller as TowerController).transform.position = PlacementComponent.GetCenter();
	}

	public bool IsFullExperience()
	{
		return experience >= LTFunctionLibrary.GetLTGameManager().TowerExperienceToUpgrade;
	}

	private void OnPlace(PlacementComponent placementComponent)
	{
		IsEnabled = true;
		UpdateRange();
	}

	private void OnUnplace(PlacementComponent placementComponent)
	{
		IsEnabled = false;
	}

	public void Select()
	{
		this.StartCoroutineCheckingVar(SelectionCoroutine(), ref selectionCoroutine);
	}

	public void Deselect()
	{
		this.StopCoroutineCheckingVar(ref selectionCoroutine);
		LTFunctionLibrary.GetLTGameManager().HideRangeIndicator();
	}

	private void UpdateRange()
	{
		(base.Controller as TowerController).SetRange(Mathf.Max(GetTowerRange(), 1f));
		if (selectionCoroutine != null)
		{
			this.StopCoroutineCheckingVar(ref selectionCoroutine);
			this.StartCoroutineCheckingVar(SelectionCoroutine(), ref selectionCoroutine);
		}
	}

	private IEnumerator SelectionCoroutine()
	{
		WaitForSecondsRealtime wfs = new WaitForSecondsRealtime(0.02f);
		while (true)
		{
			LTFunctionLibrary.GetLTGameManager().ShowCircleRangeIndicator(PlacementComponent.GetCenter(), GetTowerRange(), 0f);
			yield return wfs;
		}
	}

	private float GetTowerRange()
	{
		float num = StatsComponent.GetStat(EStats.Range);
		if (!PlacementComponent.IsPlaced)
		{
			List<GameplayEffectData> gameplayEffectDatasToApplyToBuilding = LTFunctionLibrary.GetGameplayEffectDatasToApplyToBuilding(GetComponent<GameplayObject>().ObjectData);
			Vector3[] occupiedPositions = placementComponent.GetOccupiedPositions();
			foreach (Vector3 position in occupiedPositions)
			{
				foreach (GameplayObject adjacentBuiltObject in LTFunctionLibrary.GetGrid().GetAdjacentBuiltObjects(position))
				{
					if (adjacentBuiltObject.TryGetComponent<Obelisk>(out var component))
					{
						gameplayEffectDatasToApplyToBuilding.AddRange(component.GameplayEffectsToApply);
					}
				}
			}
			if (gameplayEffectDatasToApplyToBuilding != null)
			{
				foreach (GameplayEffectData item in gameplayEffectDatasToApplyToBuilding)
				{
					if (!(item is GE_StatModifierData))
					{
						continue;
					}
					GE_StatModifierData gE_StatModifierData = item as GE_StatModifierData;
					if (gE_StatModifierData.Stat == EStats.Range)
					{
						switch (gE_StatModifierData.ModifierOperation)
						{
						case ModifierOperation.Additive:
							num += gE_StatModifierData.StatValue;
							break;
						case ModifierOperation.Multiplicative:
							num += statsComponent.GetStatBase(EStats.Range) * gE_StatModifierData.StatValue;
							break;
						}
					}
				}
			}
		}
		return num;
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		switch (stat)
		{
		case EStats.Range:
			UpdateRange();
			break;
		case EStats.AttackSpeed:
			currentAttackSpeed = statsComponent.GetStatBase(EStats.AttackSpeed);
			break;
		}
	}

	private void OnDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 vector, bool isMainDamage, object auxData, FDamageReport report)
	{
		if (!hasReceivedExperienceThisFrame)
		{
			Experience += 1f / currentAttackSpeed * experiencieMultiplier;
			hasReceivedExperienceThisFrame = true;
		}
	}

	public Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object>
		{
			{
				"firstTargetProvider",
				(base.Controller as TowerController).FirstTargetProvider
			},
			{
				"secondTargetProvider",
				(base.Controller as TowerController).SecondTargetProvider
			},
			{
				"keepTarget",
				(base.Controller as TowerController).KeepTarget
			}
		};
	}

	public void SetData(Dictionary<string, object> data)
	{
		(base.Controller as TowerController).FirstTargetProvider = (TowerTargetProvider)data["firstTargetProvider"];
		(base.Controller as TowerController).SecondTargetProvider = (TowerTargetProvider)data["secondTargetProvider"];
		(base.Controller as TowerController).KeepTarget = (bool)data["keepTarget"];
	}

	public static FTowerStats GetTotalTowerStats(Tower tower)
	{
		StatsComponent component = tower.GetComponent<StatsComponent>();
		GameplayObject component2 = tower.GetComponent<GameplayObject>();
		FTowerStats result = new FTowerStats(component.GetStatBase(EStats.BaseDamage), component.GetStatBase(EStats.AttackSpeed), component.GetStatBase(EStats.Range));
		result.ApplyGE(LTFunctionLibrary.GetGameplayEffectDatasToApplyToBuilding(component2.ObjectData));
		return result;
	}

	public new void OnSave()
	{
		TowerController towerController = base.Controller as TowerController;
		firstTargetProviderId = towerController.FirstTargetProvider.Id;
		secondTargetProviderId = towerController.SecondTargetProvider.Id;
	}

	public new void OnPreLoad()
	{
	}

	public new void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			TowerController obj = base.Controller as TowerController;
			obj.FirstTargetProvider = obj.TargetProviders.Find((TowerTargetProvider x) => x.Id == firstTargetProviderId);
			obj.SecondTargetProvider = obj.TargetProviders.Find((TowerTargetProvider x) => x.Id == secondTargetProviderId);
		}
	}
}
