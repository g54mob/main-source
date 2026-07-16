using System;
using UnityEngine;

public class ModuleEMP : Module
{
	[SerializeField]
	private GameObject empAOEPrefab;

	private float? chargeTime;

	private float activationTimeElapsed;

	[NonSerialized]
	public bool randomDuration;

	[NonSerialized]
	public float percentChanceForGoodOutcome;

	[NonSerialized]
	public float decreaseDurationPercent;

	[NonSerialized]
	public float increaseDurationPercent;

	[NonSerialized]
	public float emergencyDurationReduction;

	[NonSerialized]
	[HideInInspector]
	public bool isAutoFiring;

	[NonSerialized]
	public bool destroyBombers;

	[NonSerialized]
	public bool destroyProjectiles;

	public override bool CanBeActivated => true;

	private new void Update()
	{
		base.Update();
		if (!base.IsFullyBroken && !base.IsEMPattached && !Activated())
		{
			Charging();
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	private bool Activated()
	{
		activationTimeElapsed += Time.deltaTime;
		if (activationTimeElapsed > GetUpgradedStatValueByStatType(StatTypes.duration))
		{
			return false;
		}
		anim.Play("Stage 0", 0);
		anim.Play("Activate", 1);
		return true;
	}

	private void Charging()
	{
		base.cooldownTimeElapsed += Time.deltaTime;
		if (base.cooldownTimeElapsed <= chargeTime / 3f)
		{
			anim.Play("Stage 1", 0);
			anim.Play("Charging", 1);
			return;
		}
		if (base.cooldownTimeElapsed <= chargeTime / 3f * 2f)
		{
			anim.Play("Stage 2", 0);
			return;
		}
		if (base.cooldownTimeElapsed < chargeTime)
		{
			anim.Play("Stage 3", 0);
			return;
		}
		anim.Play("Charged", 1);
		if (isAutoFiring)
		{
			Activate();
		}
	}

	public override bool CanInteract()
	{
		if (base.CanInteract() && !isAutoFiring && chargeTime.HasValue && activationTimeElapsed > GetUpgradedStatValueByStatType(StatTypes.duration))
		{
			return base.cooldownTimeElapsed >= chargeTime;
		}
		return false;
	}

	public override void Activate()
	{
		EMPAOE component = UnityEngine.Object.Instantiate(empAOEPrefab, base.transform.position, Quaternion.identity).GetComponent<EMPAOE>();
		component.sourceUnit = this;
		if (randomDuration)
		{
			if (ProbUtils.CheckWithLuck(percentChanceForGoodOutcome))
			{
				component.empDuration = GetUpgradedStatValueByStatType(StatTypes.duration) * (1f + increaseDurationPercent) * (1f - emergencyDurationReduction);
			}
			else
			{
				component.empDuration = GetUpgradedStatValueByStatType(StatTypes.duration) * (1f - decreaseDurationPercent) * (1f - emergencyDurationReduction);
			}
		}
		else
		{
			component.empDuration = GetUpgradedStatValueByStatType(StatTypes.duration) * (1f - emergencyDurationReduction);
		}
		component.damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		component.sunder = GetUpgradedStatValueByStatType(StatTypes.sunder);
		component.burn = GetUpgradedStatValueByStatType(StatTypes.burn);
		component.destroyBombers = destroyBombers;
		component.isDrone = base.IsEnemy;
		if (emergencyDurationReduction == 0f)
		{
			base.cooldownTimeElapsed = 0f;
			activationTimeElapsed = 0f;
		}
		PlayModuleUniqueSound();
		if (destroyProjectiles)
		{
			CombatManager.Instance.DestroyProjectiles();
		}
		base.Activate();
	}

	public void EmergencyActivation()
	{
	}

	protected override void StartAndPostUpgrade()
	{
		chargeTime = GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		SetAnimPlaybackEnabled(enabled: true);
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
	}

	protected override void OnFix(HealthChangeInfo info)
	{
		base.OnFix(info);
		SetAnimPlaybackEnabled(enabled: true);
	}

	private void SetAnimPlaybackEnabled(bool enabled)
	{
		if (enabled)
		{
			anim.SetFloat("ChargeTimeMul", 1f / chargeTime.Value);
			anim.SetFloat("ActivationTimeMul", 1f / GetUpgradedStatValueByStatType(StatTypes.duration));
		}
		else
		{
			anim.SetFloat("ChargeTimeMul", 0f);
			anim.Play("Stage 0", 0);
			anim.Play("Activate", 1);
		}
	}
}
