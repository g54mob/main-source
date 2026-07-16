using System;
using UnityEngine;
using UnityEngine.Localization;

public class ModuleOverdrive : Module
{
	public bool chargeFromDamage;

	public bool maxChargeOnNewLevel;

	[SerializeField]
	private float chargePercentGainedFromDamage = 10f;

	public float firingTimeElapsed;

	public float OverdriveSpeedUpValue = 3f;

	[NonSerialized]
	public bool freeUse;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString overdriveActionLocalized;

	[SerializeField]
	private LocalizedString skipLevelActionLocalized;

	public override bool CanBeActivated => true;

	public bool CanSkipLevel { get; set; }

	public bool IsFiring { get; set; }

	public bool IsReadyToFire => base.cooldownTimeElapsed >= GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);

	public event Action OnOverdriveStart;

	public event Action OnOverdriveEnd;

	private new void Awake()
	{
		base.Awake();
	}

	private new void Start()
	{
		base.Start();
		LevelManager.Instance.LevelCompleted += EndOverdrive;
	}

	private new void Update()
	{
		base.Update();
		if (base.IsFullyBroken || base.IsEMPattached)
		{
			return;
		}
		if (IsFiring)
		{
			firingTimeElapsed += Time.deltaTime;
			Train.Instance.momentumTimer = 5f;
			if (firingTimeElapsed >= GetUpgradedStatValueByStatType(StatTypes.duration))
			{
				EndOverdrive();
			}
		}
		else
		{
			base.cooldownTimeElapsed += Time.deltaTime;
			anim.Play("Charging", 0, base.cooldownTimeElapsed / GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary));
		}
	}

	public void EndOverdrive()
	{
		if (IsFiring)
		{
			UpdateMainStat(firingTimeElapsed);
			Train.Instance.isInOverdrive = false;
			this.OnOverdriveEnd?.Invoke();
			IsFiring = false;
			Train.Instance.SpeedChange(0f - OverdriveSpeedUpValue);
			anim.Play("Charging");
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		if (!base.CanInteract())
		{
			return false;
		}
		if (!IsFiring && IsReadyToFire)
		{
			base.Interactable.actionNameLocalized = overdriveActionLocalized;
			return true;
		}
		if (CanSkipLevel && IsFiring && LevelManager.Instance.CurrentLevel.LevelType != LevelType.Boss)
		{
			base.Interactable.actionNameLocalized = skipLevelActionLocalized;
			return true;
		}
		return false;
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		if (!base.IsFullyBroken && !base.IsEMPattached)
		{
			base.OnInteractStart(interactor);
		}
	}

	public override void Activate()
	{
		if (IsFiring)
		{
			Train.Instance.GlobalDistance = LevelManager.Instance.CurrentLevel.LevelDistance + 19.2f;
			anim.Play("Firing");
			PlayModuleUniqueSound();
			this.OnOverdriveStart?.Invoke();
			CanSkipLevel = false;
			return;
		}
		Train.Instance.isInOverdrive = true;
		Train.Instance.SpeedChange(OverdriveSpeedUpValue);
		IsFiring = true;
		anim.Play("Firing");
		firingTimeElapsed = 0f;
		if (!freeUse)
		{
			base.cooldownTimeElapsed = 0f;
		}
		PlayModuleUniqueSound();
		this.OnOverdriveStart?.Invoke();
		base.Activate();
	}

	protected override void HandleLevelStarted()
	{
		base.cooldownTimeElapsed = (maxChargeOnNewLevel ? GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) : 0f);
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
		anim.SetFloat("Charge Time", 1f / GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary));
	}

	protected override void OnHealthChanged(HealthChangeInfo info)
	{
		base.OnHealthChanged(info);
		if (info.HealthChange < 0f && !IsFiring && chargeFromDamage)
		{
			base.cooldownTimeElapsed += GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) * chargePercentGainedFromDamage / 100f;
		}
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
		if (IsFiring)
		{
			UpdateMainStat(firingTimeElapsed);
			IsFiring = false;
			Train.Instance.SpeedChange(0f - OverdriveSpeedUpValue);
			this.OnOverdriveEnd?.Invoke();
		}
		firingTimeElapsed = 0f;
	}
}
