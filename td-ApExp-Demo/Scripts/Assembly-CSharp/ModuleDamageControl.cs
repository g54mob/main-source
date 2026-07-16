using System;
using System.Collections.Generic;
using UnityEngine;

public class ModuleDamageControl : Module
{
	private float emptyTimeElapsed;

	[SerializeField]
	private AnimationClip fillingClip;

	[SerializeField]
	private AnimationClip emptyingClip;

	[SerializeField]
	private float moduleHealingPerSec = 1f;

	[NonSerialized]
	private float totalHealOnLastUse;

	private bool finishedHealing;

	[NonSerialized]
	public bool healingMechanicChanged;

	public override bool CanBeActivated => true;

	public bool IsHealing { get; private set; }

	public event Action Started;

	public event Action Ended;

	public event Action<float> OnFinishedHealing;

	private new void Start()
	{
		base.Start();
		emptyTimeElapsed = 100f;
		finishedHealing = true;
	}

	private new void Update()
	{
		base.Update();
		if (!base.IsFullyBroken && !base.IsEMPattached && !Emptying())
		{
			Filling();
		}
	}

	protected override void HandleLevelCompleted()
	{
		base.HandleLevelCompleted();
		base.cooldownTimeElapsed = GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		emptyTimeElapsed = GetUpgradedStatValueByStatType(StatTypes.duration);
		if (IsHealing)
		{
			ResetModule();
			this.Ended?.Invoke();
		}
	}

	private void Filling()
	{
		if (IsHealing)
		{
			this.Ended?.Invoke();
			if (!finishedHealing)
			{
				this.OnFinishedHealing?.Invoke(totalHealOnLastUse);
				finishedHealing = true;
				totalHealOnLastUse = 0f;
			}
		}
		IsHealing = false;
		base.cooldownTimeElapsed += Time.deltaTime;
		float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		float normalizedTime = base.cooldownTimeElapsed / upgradedStatValueByStatType;
		if (base.cooldownTimeElapsed < upgradedStatValueByStatType)
		{
			anim.Play("Filling", 0, normalizedTime);
		}
		else
		{
			anim.Play("Full");
		}
	}

	private bool Emptying()
	{
		IsHealing = true;
		emptyTimeElapsed += Time.deltaTime;
		if (emptyTimeElapsed >= GetUpgradedStatValueByStatType(StatTypes.duration))
		{
			return false;
		}
		finishedHealing = false;
		anim.Play("Emptying");
		if (!healingMechanicChanged)
		{
			HealModules();
		}
		Train.Instance.RemoveAllBurn();
		return true;
	}

	public void HealDamageTaken(Dictionary<Module, float> healing)
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module && healing.ContainsKey(module))
			{
				module.HealthComponent.Heal(healing[module], this);
			}
		}
	}

	private void HealModules()
	{
		GetUpgradedStatValueByStatType(StatTypes.duration);
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				Health healthComponent = module.HealthComponent;
				float num = moduleHealingPerSec * GetUpgradedStatValueByStatType(StatTypes.damage) * Time.deltaTime;
				healthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, healthComponent, num, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
				totalHealOnLastUse += num;
				UpdateMainStat(num);
			}
		}
	}

	public override bool CanInteract()
	{
		if (base.cooldownTimeElapsed >= GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
		{
			return emptyTimeElapsed > GetUpgradedStatValueByStatType(StatTypes.duration);
		}
		return false;
	}

	public override void Activate()
	{
		base.cooldownTimeElapsed = 0f;
		emptyTimeElapsed = 0f;
		this.Started?.Invoke();
		PlayModuleUniqueSound();
		base.Activate();
	}

	protected override void StartAndPostUpgrade()
	{
		SetAnimPlaybackEnabled(enabled: true);
	}

	private void SetAnimPlaybackEnabled(bool enabled)
	{
		if (enabled)
		{
			anim.SetFloat("FillTime", 1f / GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) * fillingClip.length);
			anim.SetFloat("EmptyTime", 1f / GetUpgradedStatValueByStatType(StatTypes.duration) * emptyingClip.length);
		}
		else
		{
			anim.SetFloat("FillTime", 0f);
			anim.Play("Empty");
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	private void ResetModule()
	{
		finishedHealing = true;
		totalHealOnLastUse = 0f;
		IsHealing = false;
		base.cooldownTimeElapsed = 0f;
		anim.Play("Full");
	}
}
