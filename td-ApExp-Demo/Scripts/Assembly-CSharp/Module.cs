using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Repairable))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Interactable))]
public class Module : Unit
{
	protected Animator anim;

	[Header("Module")]
	[SerializeField]
	private EnhancementModule enhModule;

	[SerializeField]
	protected Stats statsSO;

	public bool showRoof;

	[SerializeField]
	protected SpriteRenderer[] roofPartsSR;

	public bool zoom;

	[NonSerialized]
	public float aimPosThreashold = 0.001f;

	private float breakDelayTimer;

	private HealthChangeInfo originalBreakInfo;

	[NonSerialized]
	public float startHealAmount = 100f;

	[NonSerialized]
	public bool hardenBoostOn;

	[NonSerialized]
	public float hardenBoostDuration;

	[NonSerialized]
	public float hardenBoostAmount;

	[SerializeField]
	private bool trackDamageDealt;

	[SerializeField]
	private bool trackDamageMitigated;

	[SerializeField]
	protected List<StatusEffect> SnotEffects;

	[SerializeField]
	public GameObject Snot;

	[Header("Death")]
	[SerializeField]
	protected List<ExplodeSprite> explodeSprites;

	[SerializeField]
	protected GameObject explosionPrefab;

	[Header("SFX")]
	[SerializeField]
	protected SoundData empShockSound;

	[SerializeField]
	protected SoundData empTurnOffSound;

	[SerializeField]
	protected SoundData moduleUniqueSound;

	protected float previousAnimatorSpeed = 1f;

	private float _mainStat;

	[field: SerializeField]
	public bool hasCooldown { get; private set; }

	[field: SerializeField]
	public bool hasConsumption { get; private set; }

	public virtual bool CanBeActivated { get; }

	public ModuleSlot ModuleSlot { get; set; }

	public ModuleTypes ModuleType => enhModule.ModuleType;

	[field: SerializeField]
	public List<SpriteRenderer> moduleSrs { get; private set; }

	[field: SerializeField]
	public Outline OuterPartOutline { get; protected set; }

	[field: SerializeField]
	public Interactable Interactable { get; private set; }

	public Interactor CurrentInteractor { get; private set; }

	public Stats StatsSO => statsSO;

	public bool IsFullyBroken { get; private set; }

	public EnhancementModule Enhancement => enhModule;

	public string Name => enhModule.Name;

	public string Description => enhModule.Description;

	public float cooldownTimeElapsed { get; protected set; }

	[field: SerializeField]
	public string MainStatName { get; protected set; }

	public Wagon Wagon => ModuleSlot.Wagon;

	public event Action OnInteractStartEvent;

	public event Action OnInteractEndEvent;

	public event Action FullyBroken;

	public event Action<HealthChangeInfo> ModuleBreak;

	public static event Action<Module> OnModuleStartAiming;

	public static event Action<Module> OnModuleEndAiming;

	public event Action<float> OnMitigateDamage;

	public event Action OnEMPd;

	public event Action OnActivation;

	protected void ModuleStartAiming()
	{
		Module.OnModuleStartAiming?.Invoke(this);
	}

	protected void ModuleEndAiming()
	{
		Module.OnModuleEndAiming(this);
	}

	private void OnEnable()
	{
		Train.Instance.OnModuleEnabled(this);
	}

	private void OnDisable()
	{
		Train.Instance.OnModuleDisabled(this);
		if ((bool)statsSO)
		{
			statsSO.upgradeEvent -= OnUpgradeApplied;
			statsSO.instances--;
			if (statsSO.instances < 0)
			{
				statsSO.instances = 0;
			}
		}
	}

	public virtual void OnRemoveModule()
	{
		LevelManager.Instance.LevelCompleted -= HandleLevelCompleted;
		LevelManager.Instance.LevelStarted -= HandleLevelStarted;
		LevelManager.Instance.NextLevelSelected -= delegate
		{
			HandleNextLevelSelected();
		};
		LevelManager.Instance.DestinationReached -= HandleDestinationReached;
		GameManager.Instance.JourneyContinued -= HandleJourneyContinued;
	}

	public virtual void HandleDestinationReached()
	{
	}

	protected void OnUpgradeApplied(Stats stats, EnhancementUpgrade upgrade)
	{
		StartAndPostUpgrade();
	}

	protected new void Awake()
	{
		base.Awake();
		Interactable.CanInteract = CanInteract;
		Interactable.OnInteractStart += OnInteractStart;
		Interactable.OnInteractUpdate += OnInteractUpdate;
		Interactable.OnInteractEnd += OnInteractEnd;
		anim = GetComponent<Animator>();
		ModuleSlot = base.transform.parent.GetComponent<ModuleSlot>();
		base.HealthComponent.OnDeath += OnBreak;
		base.HealthComponent.OnRes += OnFix;
		FullyBroken += OnFullyBroken;
		if ((bool)base.HealthComponent)
		{
			base.HealthComponent.OnHealthChanged += OnHealthChanged;
		}
		if ((bool)statsSO)
		{
			statsSO.upgradeEvent += OnUpgradeApplied;
		}
		if ((bool)anim)
		{
			previousAnimatorSpeed = anim.speed;
		}
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	protected new void Start()
	{
		base.Start();
		StartAndPostUpgrade();
		LevelManager.Instance.LevelCompleted += HandleLevelCompleted;
		LevelManager.Instance.LevelStarted += HandleLevelStarted;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HandleNextLevelSelected();
		};
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		GameManager.Instance.JourneyContinued += HandleJourneyContinued;
		statsSO.instances++;
		if (trackDamageDealt)
		{
			CombatManager.Instance.HealthChanged += TrackDamageDealt;
		}
		if (trackDamageMitigated)
		{
			OnMitigateDamage += UpdateMainStat;
		}
		if (hasCooldown)
		{
			cooldownTimeElapsed = 999f;
		}
	}

	private void AudioController_OnInitialized()
	{
		SetEmpSoundChannels();
	}

	protected void Update()
	{
		if (hardenBoostOn)
		{
			hardenBoostDuration -= Time.deltaTime;
			if (hardenBoostDuration <= 0f)
			{
				base.HealthComponent.DamageReductionPercent -= hardenBoostAmount;
				hardenBoostOn = false;
			}
		}
		statsSO.UpdateSEs();
		breakDelayTimer -= Time.deltaTime;
		if (breakDelayTimer <= 0f && base.HealthComponent.IsDead && !IsFullyBroken)
		{
			Break(originalBreakInfo);
		}
	}

	private void OnBreak(HealthChangeInfo info)
	{
		originalBreakInfo = info;
		float moduleBreakDelayLB = GlobalFields.Instance.ModuleBreakDelayLB;
		float moduleBreakDelayUB = GlobalFields.Instance.ModuleBreakDelayUB;
		breakDelayTimer = ProbUtils.GetRandomWithUpperBias(moduleBreakDelayLB, moduleBreakDelayUB);
		AudioManager.Instance.PlayClipWithMixer(Train.Instance.moduleDestroyedClip, AMG.SFX, 0.5f);
		CameraController.Instance.Shake(0.5f, 0.5f);
		if (GlobalFields.Instance.ModuleBreakDelayLB > 0f)
		{
			ModuleSlot.SetDamageState(DamageStates.Broken);
		}
	}

	protected virtual void Break(HealthChangeInfo info)
	{
		if (Train.Instance.moduleDeathBulletBurst)
		{
			BulletBurst();
		}
		if (!IsFullyBroken)
		{
			DataTrackingManager.Instance.AddModulesBroken();
		}
		IsFullyBroken = true;
		this.FullyBroken?.Invoke();
		this.ModuleBreak?.Invoke(info);
		ModuleSlot.SetDamageState(DamageStates.Broken);
		Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(info.source, Train.Instance.HealthComponent, 0f - Train.Instance.hullDamageTakenOnModuleBreak * (1f + DifficultyManager.Instance.brokenModuleHullDamage), isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		AudioManager.Instance.PlayClipWithMixer(Train.Instance.moduleDestroyedClip, AMG.SFX, 0.5f);
		CameraController.Instance.Shake(0.7f, 0.5f);
		Train.Instance.OnModuleDestroyed(this);
		Train.Instance.CheckRepairableDamageOverkill(info);
		if (hardenBoostOn)
		{
			base.HealthComponent.DamageReductionPercent -= hardenBoostAmount;
			hardenBoostOn = false;
		}
		if ((bool)anim)
		{
			previousAnimatorSpeed = anim.speed;
			anim.speed = 0f;
		}
		if (Train.Instance.AutoRepairModules)
		{
			StartCoroutine(AutoRepairCoroutine());
		}
	}

	private IEnumerator AutoRepairCoroutine()
	{
		yield return new WaitForSeconds(Train.Instance.AutoRepairModulesTimer);
		base.HealthComponent.SetHealthWithInfo(new HealthChangeInfo(this, base.HealthComponent, Train.Instance.AutoRepairModulesHealthPercent, isPercent: true, null, canRes: true, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
	}

	public void EMPBreak(EMPProjectile empProj)
	{
		this.OnEMPd?.Invoke();
		attachedEMPs.Add(empProj);
		OnInteractEnd(CurrentInteractor);
		ModuleSlot.SetEmpPs(isOn: true);
		PlayEmpSound();
	}

	public void EMPFix(EMPProjectile empProj)
	{
		attachedEMPs.Remove(empProj);
		ModuleSlot.SetEmpPs(isOn: false);
		StopEmpSound();
	}

	protected virtual void PlayEmpSound()
	{
		soundBuilder.Play(empShockSound);
	}

	protected virtual void StopEmpSound()
	{
		soundBuilder.FindAndStop(empShockSound);
		soundBuilder.Play(empTurnOffSound);
	}

	protected virtual void SetEmpSoundChannels()
	{
	}

	protected virtual void OnFullyBroken()
	{
	}

	private void BulletBurst()
	{
		int num = 16;
		for (int i = 0; i < num; i++)
		{
			Quaternion rotation = Quaternion.Euler(0f, 0f, 360f / (float)num * (float)i);
			Projectile component = UnityEngine.Object.Instantiate(Train.Instance.bulletPrefab, base.transform.position, rotation).GetComponent<Projectile>();
			component.damage = 1f;
			component.sourceUnit = this;
			component.screenWarpCounter = Train.Instance.projectileScreenWarpCounter;
		}
	}

	protected virtual void OnFix(HealthChangeInfo info)
	{
		IsFullyBroken = false;
		base.HealthComponent.StopBurn();
		Train.Instance.OnModuleRepaired(this);
		if ((bool)anim)
		{
			anim.speed = previousAnimatorSpeed;
		}
	}

	protected virtual void OnHealthChanged(HealthChangeInfo info)
	{
		if (base.HealthComponent.HealthCurrent >= base.HealthComponent.HealthMax * 0.75f)
		{
			ModuleSlot.SetDamageState(DamageStates.None);
		}
		else if (base.HealthComponent.HealthCurrent <= 0f)
		{
			ModuleSlot.SetDamageState(DamageStates.Broken);
		}
		else if (base.HealthComponent.HealthCurrent >= base.HealthComponent.HealthMax * 0.5f && base.HealthComponent.HealthCurrent <= base.HealthComponent.HealthMax * 0.75f)
		{
			ModuleSlot.SetDamageState(DamageStates.Smoke1);
		}
		else if (base.HealthComponent.HealthCurrent >= base.HealthComponent.HealthMax * 0.25f && base.HealthComponent.HealthCurrent <= base.HealthComponent.HealthMax * 0.5f)
		{
			ModuleSlot.SetDamageState(DamageStates.Smoke2);
		}
		else if (base.HealthComponent.HealthCurrent > 0f && base.HealthComponent.HealthCurrent <= base.HealthComponent.HealthMax * 0.25f)
		{
			ModuleSlot.SetDamageState(DamageStates.Smoke3);
		}
		Train.Instance.OnModuleDamaged();
		if (info.HealthChange < 0f)
		{
			GameManager.Instance.TotalDamageTakenInRun += Mathf.Abs(info.HealthChange);
			if (base.HealthComponent.IsDead)
			{
				Health healthComponent = Train.Instance.HealthComponent;
				object source = info.source;
				Health healthComponent2 = Train.Instance.HealthComponent;
				float healthChange = info.HealthChange * Train.Instance.DirectHitHullDamageTaken;
				DamageType damageType = info.DamageType;
				healthComponent.ChangeHealthWithInfo(new HealthChangeInfo(source, healthComponent2, healthChange, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, damageType));
				DataTrackingManager.Instance.AddHullDamageTaken((0f - info.HealthChange) * Train.Instance.DirectHitHullDamageTaken);
			}
			else
			{
				DataTrackingManager.Instance.AddRegularDamageTaken(0f - info.HealthChange);
			}
		}
	}

	public float GetInitialStat(StatTypes statType)
	{
		return statsSO.GetInitialStatValue(statType);
	}

	public float GetUpgradedStatValueByStatType(StatTypes statType)
	{
		return statsSO.GetUpgradedStatValue(statType);
	}

	protected virtual void StartAndPostUpgrade()
	{
		base.HealthComponent.SetMaxHealth(GetUpgradedStatValueByStatType(StatTypes.health));
		HealthChangeInfo info = new HealthChangeInfo(this, base.HealthComponent, startHealAmount, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		base.HealthComponent.SetHealthWithInfo(info, hideHealParticles: true);
	}

	public virtual bool CanInteract()
	{
		if (!IsFullyBroken)
		{
			return !base.IsEMPattached;
		}
		return false;
	}

	protected virtual void OnSetPoint(Vector2 point)
	{
	}

	protected virtual void OnTranslatePoint(Vector2 point)
	{
	}

	protected virtual void OnInteractStart(Interactor interactor)
	{
		if (CanBeActivated)
		{
			Activate();
		}
		if (showRoof)
		{
			if ((bool)OuterPartOutline)
			{
				if (PlayerManager.Instance.IsCoop)
				{
					OuterPartOutline.SetOutline(isActive: true, interactor.playerController.GetPlayerColor());
				}
				else
				{
					OuterPartOutline.SetOutline(isActive: false, Color.white);
				}
			}
			ModuleSlot.Wagon.UpdateRoofsVisibility();
			if (!Train.ShowRoofOnEmptyWagons && PlayerManager.Instance.Players.Count == 1)
			{
				Train.Instance.SetRoofVisibilities(visible: true);
			}
		}
		if (zoom)
		{
			CameraController.Instance.InteractionZoomOut();
		}
		if (!Interactable.startOnly)
		{
			CurrentInteractor = interactor;
		}
		Interactable.OnSetPoint += OnSetPoint;
		Interactable.OnTranslatePoint += OnTranslatePoint;
		if (PlayerManager.Instance.Players.Count == 1)
		{
			foreach (Module module in Train.Instance.Modules)
			{
				if (module != null)
				{
					module.ShowRoofElement();
				}
			}
		}
		else
		{
			ShowRoofElement();
		}
		this.OnInteractStartEvent?.Invoke();
	}

	protected virtual void OnInteractUpdate(Interactor interactor)
	{
	}

	protected virtual void OnInteractEnd(Interactor interactor)
	{
		if (interactor == null)
		{
			return;
		}
		if (showRoof)
		{
			if ((bool)OuterPartOutline)
			{
				OuterPartOutline.SetOutline(isActive: false, Color.white);
			}
			if (!Train.ShowRoofOnEmptyWagons && PlayerManager.Instance.Players.Count == 1)
			{
				Train.Instance.SetRoofVisibilities(visible: false);
			}
			ModuleSlot.Wagon.UpdateRoofsVisibility();
		}
		if (zoom)
		{
			CameraController.Instance.ZoomIn();
		}
		CurrentInteractor = null;
		Interactable.OnSetPoint -= OnSetPoint;
		Interactable.OnTranslatePoint -= OnTranslatePoint;
		this.OnInteractEndEvent?.Invoke();
	}

	public virtual void ShowRoofElement()
	{
		if (roofPartsSR == null)
		{
			return;
		}
		SpriteRenderer[] array = roofPartsSR;
		foreach (SpriteRenderer spriteRenderer in array)
		{
			if (spriteRenderer != null)
			{
				spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
			}
		}
	}

	public virtual void TransparentRoofElement()
	{
		if (roofPartsSR == null)
		{
			return;
		}
		SpriteRenderer[] array = roofPartsSR;
		foreach (SpriteRenderer spriteRenderer in array)
		{
			if ((bool)spriteRenderer)
			{
				spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Train.Instance.WAGON_TRANSPARENCY_ALPHA);
			}
		}
	}

	public virtual void HideRoofElement()
	{
		if (roofPartsSR == null)
		{
			return;
		}
		SpriteRenderer[] array = roofPartsSR;
		foreach (SpriteRenderer spriteRenderer in array)
		{
			if ((bool)spriteRenderer)
			{
				spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
			}
		}
	}

	public virtual void OnReload(Interactor interactor)
	{
	}

	protected virtual void HandleLevelCompleted()
	{
	}

	protected virtual void HandleLevelStarted()
	{
		cooldownTimeElapsed = 0f;
	}

	protected virtual void HandleNextLevelSelected()
	{
	}

	public virtual void DamageMitigated(float damageMitigated)
	{
		GameManager.Instance.TotalDamageMitigatedInRun += damageMitigated;
		this.OnMitigateDamage?.Invoke(damageMitigated);
	}

	public virtual void ChargeModuleBy(float chargeAmount)
	{
		cooldownTimeElapsed += chargeAmount;
	}

	public virtual void RefundCooldown()
	{
		cooldownTimeElapsed += GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
	}

	public virtual void RefundConsumption()
	{
	}

	public virtual void Activate()
	{
		GameManager.Instance.TotalModulesActivated += 1f;
		this.OnActivation?.Invoke();
	}

	public virtual void HandleJourneyContinued()
	{
	}

	public void PlayModuleUniqueSound(float targetPitch = 0f)
	{
		soundBuilder.Play(moduleUniqueSound, targetPitch);
	}

	public void StopModuleUniqueSound(bool stopAll = false)
	{
		soundBuilder.FindAndStop(moduleUniqueSound, stopAll);
	}

	public EnhancementModule GetEnhancementModule()
	{
		return enhModule;
	}

	public virtual void AddResource(float amount, ResourceTypes resourceType)
	{
		switch (resourceType)
		{
		case ResourceTypes.Ammo:
			ResourceManager.Instance.Ammo.AddValue(amount);
			break;
		case ResourceTypes.Scrap:
			ResourceManager.Instance.Scrap.AddValue(amount);
			break;
		case ResourceTypes.Cores:
			ResourceManager.Instance.LootCores(amount);
			break;
		case ResourceTypes.Rerolls:
			ResourceManager.Instance.Rerolls.AddValue(amount);
			break;
		}
	}

	public void UpdateMainStat(float value)
	{
		_mainStat += value;
	}

	public virtual float GetMainStat()
	{
		return _mainStat;
	}

	protected virtual void TrackDamageDealt(HealthChangeInfo info)
	{
		if (!(info.Target == null) && !(info.Target.GetComponent<Unit>() == null) && !(info.HealthChange >= 0f) && info != null && info.source != null && info.source is UnityEngine.Object obj && obj != null && (bool)obj.GetComponent<Module>() && obj.GetComponent<Module>().Enhancement == enhModule)
		{
			_mainStat += Mathf.Abs(info.HealthChange);
		}
	}

	public void ExplodeOutsideParts()
	{
		StartCoroutine(DeathAnimation());
	}

	protected IEnumerator DeathAnimation()
	{
		IsFullyBroken = true;
		foreach (ExplodeSprite explodeSprite in explodeSprites)
		{
			UnityEngine.Object.Instantiate(explosionPrefab, explodeSprite.gameObject.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, UnityEngine.Random.Range(0.1f, 0.3f), 0f);
			explodeSprite.Explode();
			UnityEngine.Object.Destroy(explodeSprite.gameObject);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f, 0.5f));
		}
	}

	protected override void ApplySnot(float strength)
	{
		base.ApplySnot(strength);
		if (SnotEffects == null || SnotEffects.Count <= 0)
		{
			return;
		}
		foreach (StatusEffect snotEffect in SnotEffects)
		{
			statsSO.ApplyStatusEffect(snotEffect);
		}
	}

	protected override void RemoveSnot(float strength)
	{
		base.RemoveSnot(strength);
		if (SnotEffects != null && SnotEffects.Count > 0)
		{
			foreach (StatusEffect snotEffect in SnotEffects)
			{
				statsSO.RemoveStatusEffect(snotEffect);
			}
		}
		if ((bool)Snot)
		{
			UnityEngine.Object.Destroy(Snot);
		}
	}
}
