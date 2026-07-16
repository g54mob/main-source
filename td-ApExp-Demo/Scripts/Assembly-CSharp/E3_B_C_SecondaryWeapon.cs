using System;
using UnityEngine;

public class E3_B_C_SecondaryWeapon : EnemyComponent
{
	[Header("Secondary Weapon Fields")]
	[SerializeField]
	protected E3_B_Phase1Plane bossPlane;

	[SerializeField]
	protected GameObject swapppingClaw;

	[NonSerialized]
	public bool AttackComplete;

	private new void Awake()
	{
		base.Awake();
	}

	private new void Start()
	{
		base.Start();
	}

	private new void Update()
	{
		if (!GameManager.Instance.minigameInProgress && Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
		}
	}

	public override void Move()
	{
	}

	public override void Aim()
	{
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		sm.ForceState("Idle");
		GetComponent<SpriteRenderer>().enabled = false;
		swapppingClaw.SetActive(value: true);
		bossPlane.OnSecondaryDestroyed();
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	internal void Repair()
	{
		base.HealthComponent.Heal(100f, null, isPercent: true);
		base.HealthComponent.IsDead = false;
		GetComponent<SpriteRenderer>().enabled = true;
		swapppingClaw.SetActive(value: false);
	}

	public virtual void Activate()
	{
	}

	public virtual void Deactivate()
	{
	}

	protected override void OnHealthChanged(HealthChangeInfo info)
	{
		base.OnHealthChanged(info);
		if (info.HealthChange < 0f && info.DamageType != DamageType.AoE)
		{
			Health healthComponent = bossPlane.HealthComponent;
			Health healthComponent2 = bossPlane.HealthComponent;
			float healthChange = info.HealthChange;
			DamageType damageType = info.DamageType;
			healthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, healthComponent2, healthChange, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: true, showDamageNumbers: true, damageType));
		}
	}
}
