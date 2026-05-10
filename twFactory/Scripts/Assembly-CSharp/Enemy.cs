using System;
using LightTower;
using UnityEngine;

public class Enemy : Character, ISelectable, ISavable
{
	[Flags]
	public enum EEnemyType
	{
		Ground = 2,
		Flying = 4
	}

	[SerializeField]
	[Savable("enemyData", false, false)]
	private EnemyData data;

	[SerializeField]
	private EEnemyType enemyType = EEnemyType.Ground;

	[SerializeField]
	private int damage = 1;

	[SerializeField]
	private bool onlySendEventsOnDie;

	[SerializeField]
	private EnemyHealthBar enemyHealthBar;

	[SerializeField]
	private EnemySpawnVFX spawnVFXPrefab;

	[SerializeField]
	private GameObject deathVFX;

	[SerializeField]
	private AudioData deathSFX;

	[SerializeField]
	private AudioData hitSFX;

	[SerializeField]
	private float bossHealthMultiplier = 1f;

	[SerializeField]
	private float bossArmorMultiplier = 1f;

	[SerializeField]
	private float bossShieldMultiplier = 1f;

	private bool hasAppliedLifeMultiplier;

	private bool isEnabled = true;

	[Savable("enemyEssenceDropped", true, false)]
	private int enemyEssenceDropped;

	public EnemyData Data => data;

	public EnemyMovement EnemyMovement { get; private set; }

	public CombatComponent CombatComponent { get; private set; }

	public StatsComponent StatsComponent { get; private set; }

	public GameplayEffectsComponent GameplayEffectsComponent { get; private set; }

	public AbilityManager AbilityManager { get; private set; }

	public EEnemyType EnemyType => enemyType;

	public int EnemyEssenceDropped
	{
		get
		{
			return enemyEssenceDropped;
		}
		set
		{
			enemyEssenceDropped = value;
		}
	}

	public int Damage => damage;

	public bool IsEnabled
	{
		get
		{
			return isEnabled;
		}
		private set
		{
			isEnabled = value;
			base.gameObject.SetActive(isEnabled);
			movementComponent.MovementEnabled = isEnabled;
			this.onEnableChanged?.Invoke(isEnabled);
		}
	}

	public event Action<Enemy> onDie;

	public event Action<bool> onEnableChanged;

	protected override void Awake()
	{
		base.Awake();
		EnemyMovement = GetComponent<MovementComponent>() as EnemyMovement;
		CombatComponent = GetComponent<CombatComponent>();
		StatsComponent = GetComponent<StatsComponent>();
		AbilityManager = GetComponent<AbilityManager>();
		GameplayEffectsComponent = GetComponent<GameplayEffectsComponent>();
		if ((bool)EnemyMovement)
		{
			EnemyMovement enemyMovement = EnemyMovement;
			enemyMovement.onPathEndReached = (Action)Delegate.Combine(enemyMovement.onPathEndReached, new Action(OnPathEndReached));
		}
	}

	protected override void Start()
	{
		base.Start();
		ApplyLifeMultiplier();
		InitWorldHealthBar();
		CombatComponent.onDie += OnDie;
		CombatComponent.onDamageTaken += OnDamageTaken;
		if ((bool)spawnVFXPrefab)
		{
			IsEnabled = false;
			UnityEngine.Object.Instantiate(spawnVFXPrefab, base.transform.position, base.transform.rotation).onSpawnEnded += OnSpawnEnded;
		}
		if (MatchInfo.instance.CurrentMatchMode == EMatchMode.Endless && data.Boss)
		{
			onlySendEventsOnDie = false;
		}
	}

	private void ApplyLifeMultiplier()
	{
		if (hasAppliedLifeMultiplier)
		{
			return;
		}
		float num = MatchInfo.instance.CurrentMatchSettings.EnemyLifeMultiplier;
		if (MatchInfo.instance.CurrentMatchMode == EMatchMode.Endless)
		{
			LTGameManager_Endless lTGameManager_Endless = GameManager.instance as LTGameManager_Endless;
			num *= lTGameManager_Endless.EnemyLifeMultiplier;
			if (data.Boss)
			{
				float bossTotalLife = lTGameManager_Endless.GetBossTotalLife(LTFunctionLibrary.GetCyclesManager().CurrentCycle);
				bossTotalLife = (int)bossTotalLife / 100 * 100;
				float num2 = CombatComponent.MaxHealth * bossHealthMultiplier + CombatComponent.MaxArmor * bossArmorMultiplier + CombatComponent.MaxShield * bossShieldMultiplier;
				float num3 = CombatComponent.MaxHealth * bossHealthMultiplier / num2;
				float num4 = CombatComponent.MaxArmor * bossArmorMultiplier / num2;
				float num5 = CombatComponent.MaxShield * bossShieldMultiplier / num2;
				StatsComponent.SetStat(EStats.HealthMax, (int)(bossTotalLife * num3 / bossHealthMultiplier) / 50 * 50);
				StatsComponent.SetStat(EStats.ArmorMax, (int)(bossTotalLife * num4 / bossArmorMultiplier) / 50 * 50);
				StatsComponent.SetStat(EStats.ShieldMax, (int)(bossTotalLife * num5 / bossShieldMultiplier) / 50 * 50);
			}
		}
		if (num != 1f)
		{
			StatsComponent.SetStat(EStats.HealthMax, (int)(StatsComponent.GetStat(EStats.HealthMax) * num) / 5 * 5);
			StatsComponent.SetStat(EStats.Health, StatsComponent.GetStat(EStats.HealthMax));
			StatsComponent.SetStat(EStats.ArmorMax, (int)(StatsComponent.GetStat(EStats.ArmorMax) * num) / 5 * 5);
			StatsComponent.SetStat(EStats.Armor, StatsComponent.GetStat(EStats.ArmorMax));
			StatsComponent.SetStat(EStats.ShieldMax, (int)(StatsComponent.GetStat(EStats.ShieldMax) * num) / 5 * 5);
			StatsComponent.SetStat(EStats.Shield, StatsComponent.GetStat(EStats.ShieldMax));
		}
		hasAppliedLifeMultiplier = true;
	}

	private void InitWorldHealthBar()
	{
		if ((bool)enemyHealthBar)
		{
			enemyHealthBar = UnityEngine.Object.Instantiate(enemyHealthBar);
			enemyHealthBar.StatsComponent = StatsComponent;
			enemyHealthBar.GameplayEffectsComponent = GameplayEffectsComponent;
		}
	}

	private void OnPathEndReached()
	{
		LTFunctionLibrary.GetLTGameManager().DoDamagePlayer(Damage);
		CombatComponent.Kill();
	}

	private void OnDie(CombatComponent cc)
	{
		if (onlySendEventsOnDie)
		{
			this.onDie?.Invoke(this);
			CombatComponent.BCanBeDamaged = false;
			return;
		}
		if ((bool)deathVFX)
		{
			CapsuleCollider component = GetComponent<CapsuleCollider>();
			UnityEngine.Object.Instantiate(deathVFX, base.transform.position + component.center, Quaternion.identity, null).transform.localScale = Vector3.one * (component.radius / 0.15f);
		}
		AudioSystem.Instance.PlaySound3D(deathSFX, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f);
		LTFunctionLibrary.GetPlayerData().AddEnemyEssence(enemyEssenceDropped);
		this.onDie?.Invoke(this);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnDamageTaken(GameObject cuaser, float damageTaken)
	{
		if (damageTaken > 0f)
		{
			AudioSystem.Instance.PlaySound3D(hitSFX, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.VeryLow);
		}
	}

	private void OnSpawnEnded()
	{
		IsEnabled = true;
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}

	public override void OnPreLoad()
	{
		base.OnPreLoad();
		ApplyLifeMultiplier();
	}
}
