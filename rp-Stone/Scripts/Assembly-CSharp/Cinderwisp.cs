using System;
using UnityEngine;

public class Cinderwisp : Summon
{
	public DebuffStatMod ignitionPrefab;

	public AsciiAnimation superAttackAnim;

	private int ignitionDps;

	private int maxIgnitionCount;

	private Action damageTimingCallback;

	public void PlaySuperAbilityState(Action damageTimingCallback)
	{
		this.damageTimingCallback = damageTimingCallback;
		SetState(State.Custom);
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		if (newState == State.Custom)
		{
			base.MySprite = superAttackAnim.Sprite;
			superAttackAnim.Play();
			SfxController.singleton.Play("cinderwisp_super_1");
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Custom)
		{
			if (base.stateElapsedTics == 16)
			{
				SfxController.singleton.Play("cinderwisp_super_2");
			}
			else if (base.stateElapsedTics == 20 && damageTimingCallback != null)
			{
				damageTimingCallback();
				damageTimingCallback = null;
			}
			else if (base.stateElapsedTics >= 30)
			{
				SetState(State.Idle);
			}
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.Owner == this && Alive && dmg.type != Damage.Type.Dot && c.Alive)
		{
			AddIgnition(c);
		}
	}

	private void ClearAllIgnitions()
	{
		for (int num = IgnitionStatMod.allIgnitions.Count - 1; num >= 0; num--)
		{
			IgnitionStatMod.allIgnitions[num].End();
		}
	}

	private void AddIgnition(Character target)
	{
		DebuffStatMod debuffStatMod = AddDebuff(target, ignitionPrefab);
		if (!(debuffStatMod == null) && target.Alive)
		{
			debuffStatMod.OnDestroyed += HandleIgnitionDestroyed;
			IgnitionStatMod ignitionStatMod = debuffStatMod as IgnitionStatMod;
			if (ignitionStatMod != null)
			{
				ignitionStatMod.damagePerPeriod = ignitionDps;
			}
			if (IgnitionStatMod.allIgnitions.Count == 1)
			{
				AddActivatedAbility();
			}
			if (IgnitionStatMod.allIgnitions.Count > maxIgnitionCount)
			{
				IgnitionStatMod.allIgnitions[0].End();
			}
		}
	}

	private void HandleIgnitionDestroyed(StatModifier debuff)
	{
		debuff.OnDestroyed -= HandleIgnitionDestroyed;
		if (IgnitionStatMod.allIgnitions.Count == 0)
		{
			RemoveActivatedAbility();
		}
	}

	public override object GetCustomProperty(string propertyName)
	{
		if (propertyName == "ignition")
		{
			return IgnitionStatMod.allIgnitions.Count;
		}
		return base.GetCustomProperty(propertyName);
	}

	private void AddActivatedAbility()
	{
		DynamicActivatedAbilityProvider component = base.owner.GetComponent<DynamicActivatedAbilityProvider>();
		CinderwispDevourAbility component2 = GetComponent<CinderwispDevourAbility>();
		component.Add(component2);
		GameStates.Singleton.abilityActivationHUD.UpdateContents();
	}

	private void RemoveActivatedAbility()
	{
		if (base.owner != null)
		{
			DynamicActivatedAbilityProvider component = base.owner.GetComponent<DynamicActivatedAbilityProvider>();
			CinderwispDevourAbility component2 = GetComponent<CinderwispDevourAbility>();
			component.Remove(component2);
			GameStates.Singleton.abilityActivationHUD.UpdateContents();
		}
	}

	public override void Die(DeathReason reason)
	{
		base.Die(reason);
		ClearAllIgnitions();
	}

	protected override void Start()
	{
		base.Start();
		SfxController.singleton.Preload("cinderwisp_super_1");
		SfxController.singleton.Preload("cinderwisp_super_2");
		if (!(base.sourceWeapon != null))
		{
			return;
		}
		WeaponActivatedAbility component = base.sourceWeapon.GetComponent<WeaponActivatedAbility>();
		if (component != null)
		{
			int num = Mathf.FloorToInt(component.ComputeStatWithId("cinderwisp_attack_period") * 30f);
			if (base.weapon != null)
			{
				base.weapon.cooldown = num - base.weapon.perf - base.weapon.cast;
			}
			ignitionDps = Mathf.RoundToInt(component.ComputeStatWithId("ignition_dps"));
			maxIgnitionCount = Mathf.FloorToInt(component.ComputeStatWithId("ignition_max_count"));
			CinderwispDevourAbility component2 = GetComponent<CinderwispDevourAbility>();
			component2.damagePerIgnite = Mathf.RoundToInt(component.ComputeStatWithId("devour_damage"));
			component2.cooldown = Mathf.RoundToInt(component.ComputeStatWithId("devour_cooldown") * 30f);
		}
	}

	protected override void OnDestroy()
	{
		RemoveActivatedAbility();
		ClearAllIgnitions();
		damageTimingCallback = null;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.OnDestroy();
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}
}
