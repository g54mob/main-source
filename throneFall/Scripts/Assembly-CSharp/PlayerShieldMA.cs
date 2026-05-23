using UnityEngine;

public class PlayerShieldMA : ManualAttack
{
	public float effectDuration = 2f;

	private float disableEffectIn;

	public BattleAxeShieldFX shieldFX;

	private float cooldownRemember;

	public override void Start()
	{
		base.Start();
		shieldFX.gameObject.SetActive(value: true);
	}

	public override void Attack()
	{
		if (disableEffectIn <= 0f)
		{
			disableEffectIn = effectDuration;
			cooldownRemember = cooldown;
			EffectEnable();
		}
	}

	public override void Update()
	{
		base.Update();
		if (disableEffectIn > 0f && !IsDead())
		{
			disableEffectIn -= Time.deltaTime;
			EffectUpdate();
		}
		if (ShouldDisableEffect())
		{
			EffectDisable();
		}
	}

	private bool IsDead()
	{
		return hpPlayer.HpValue <= 0f;
	}

	private bool ShouldDisableEffect()
	{
		if (!(disableEffectIn + Time.deltaTime > 0f) || !(disableEffectIn <= Time.deltaTime))
		{
			return IsDead();
		}
		return true;
	}

	private void EffectEnable()
	{
		PlayerMovement.instance.Hp.invulnerable = true;
		shieldFX.Play(effectDuration);
	}

	private void EffectUpdate()
	{
		cooldown = cooldownRemember;
	}

	private void EffectDisable()
	{
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			PlayerMovement.instance.Hp.invulnerable = false;
		}
	}
}
