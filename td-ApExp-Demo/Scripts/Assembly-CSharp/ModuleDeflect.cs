using System;
using UnityEngine;

public class ModuleDeflect : Module
{
	private int deflectedShotsCount;

	private bool hasAppliedUpgradeThisLevel;

	[SerializeField]
	public GameObject deflectAoePrefab;

	[NonSerialized]
	public float autoWaveCooldown;

	[NonSerialized]
	public bool autoWaveOn;

	private float timer;

	[NonSerialized]
	public float deflectSpeed;

	[NonSerialized]
	public float deflectDamage;

	[NonSerialized]
	public float deflectDamageIncrease;

	[NonSerialized]
	public bool deflectCanBoostCannon;

	[NonSerialized]
	public bool deflectWidthIncrease;

	[NonSerialized]
	public bool deflectDoubleWave;

	[NonSerialized]
	public bool deflectRefundCooldown;

	[NonSerialized]
	public bool deflectSplitBullet;

	[NonSerialized]
	public int deflectCharges;

	[NonSerialized]
	public bool deflectCanHack;

	[NonSerialized]
	public float deflectHackProbability;

	private new void Start()
	{
		base.Start();
		UIManager.Instance.DeflectIndicator.SetDeflectsActive(active: true);
		Train.Instance.moduleDeflectOn = true;
		Train.Instance.moduleDeflect = this;
		timer = autoWaveCooldown;
	}

	private new void Update()
	{
		base.Update();
		if (base.IsFullyBroken || base.IsEMPattached)
		{
			return;
		}
		if (autoWaveOn)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				AutoWave();
				timer = autoWaveCooldown;
			}
		}
		if ((float)deflectCharges >= GetUpgradedStatValueByStatType(StatTypes.capacity))
		{
			UIManager.Instance.DeflectIndicator.UpdateDeflect(0f);
			base.cooldownTimeElapsed = 0f;
			anim.Play("Uncharged");
			return;
		}
		anim.Play("Charged");
		base.cooldownTimeElapsed += Time.deltaTime;
		float normalizedTime = base.cooldownTimeElapsed / GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		UIManager.Instance.DeflectIndicator.UpdateDeflect(normalizedTime);
		if (base.cooldownTimeElapsed >= GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
		{
			base.cooldownTimeElapsed = 0f;
			deflectCharges++;
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public void RegisterDeflection()
	{
		if (!hasAppliedUpgradeThisLevel)
		{
			deflectedShotsCount++;
			Debug.Log($"Deflected Shots: {deflectedShotsCount}/10");
			if (deflectedShotsCount >= 10 && deflectCanBoostCannon)
			{
				ApplyDamageBoostToCannon();
				hasAppliedUpgradeThisLevel = true;
			}
		}
	}

	private void ApplyDamageBoostToCannon()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null && moduleByType.cannon != null)
		{
			moduleByType.cannon.ApplyDamageBoost(0.15f);
			Debug.Log("Deflect Upgrade Applied: Cannon damage increased by 0.15!");
		}
	}

	protected override void HandleLevelStarted()
	{
		deflectCharges = (int)GetUpgradedStatValueByStatType(StatTypes.capacity);
		deflectedShotsCount = 0;
		hasAppliedUpgradeThisLevel = false;
	}

	public override bool CanInteract()
	{
		return false;
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
		deflectCharges = 0;
	}

	protected override void OnFix(HealthChangeInfo info)
	{
		base.OnFix(info);
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
		UIManager.Instance.DeflectIndicator.SetDeflectChargeMax((int)GetUpgradedStatValueByStatType(StatTypes.capacity));
		deflectSpeed = GetUpgradedStatValueByStatType(StatTypes.projectileSpeed);
		deflectDamage = GetUpgradedStatValueByStatType(StatTypes.damage);
	}

	public void AutoWave()
	{
		Vector2 normalized = UnityEngine.Random.insideUnitCircle.normalized;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normalized);
		DeflectAOE component = UnityEngine.Object.Instantiate(deflectAoePrefab, base.transform.position, rotation).GetComponent<DeflectAOE>();
		component.speed = deflectSpeed;
		component.damage = deflectDamage;
		component.deflectDamageIncrease = deflectDamageIncrease;
		PlayModuleUniqueSound();
		if (deflectWidthIncrease)
		{
			component.SetWidthMedium();
		}
	}

	public void SpawnWave(Vector2 startingPosition, Vector2 direction, float damage)
	{
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
		DeflectAOE component = UnityEngine.Object.Instantiate(deflectAoePrefab, startingPosition, rotation).GetComponent<DeflectAOE>();
		component.speed = deflectSpeed;
		component.damage = damage;
		component.deflectDamageIncrease = deflectDamageIncrease;
		PlayModuleUniqueSound();
		if (deflectWidthIncrease)
		{
			component.SetWidthMedium();
		}
	}

	public override void RefundConsumption()
	{
		base.RefundConsumption();
		deflectCharges++;
	}
}
