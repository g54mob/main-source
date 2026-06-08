using System.Collections.Generic;
using UnityEngine;

public class HeavyHammerActivatedAbility : WeaponActivatedAbility
{
	public CustomAttack superAttack;

	public DebuffStatMod fatigueDebuffPrefab;

	public override SuperAbilityActivationState ActivateAbility()
	{
		SetAttack(superAttack);
		myWeapon.Attack(myWeapon.Owner);
		return base.ActivateAbility();
	}

	protected override void HandleWeaponStateChange(Weapon w, Weapon.State newState, Weapon.State prevState)
	{
		base.HandleWeaponStateChange(w, newState, prevState);
		if (newState == Weapon.State.Cooldown || newState == Weapon.State.Waiting)
		{
			if (currentAttack == superAttack)
			{
				SetAttack(base.defaultAttack);
			}
			RemoveAllAddedBuffs();
		}
	}

	protected override void HandleUnequipped(Character c, Weapon w)
	{
		base.HandleUnequipped(c, w);
		RemoveAllAddedBuffs();
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (currentAttack == superAttack && !dmg.tags.Contains("super"))
		{
			dmg.tags.Add("super");
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.amount > 0 && dmg.Owner != null && myWeapon != null && dmg.Owner == myWeapon.Owner && currentAttack == superAttack)
		{
			dmg.isCritical = true;
			dmg.criticalMultiplier += 1f;
			AddDebuff(c, fatigueDebuffPrefab);
		}
	}

	private DebuffStatMod AddDebuff(Character target, DebuffStatMod debuffPrefab)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			Hero hero = GameStates.Singleton.hero;
			debuffStatMod.sourceItem = myWeapon;
			debuffStatMod.character = hero;
			debuffStatMod.ticDuration = Mathf.FloorToInt(30f * ComputeStatWithId("armor_fatigue_duration"));
			debuffStatMod.element = ItemData.Element.Stone;
			debuffStatMod.statData = debuffStatMod.replacementStat;
			float num = target.armorPerSecond;
			if (target.statModController != null)
			{
				num = target.statModController.ModArmorPerSecond(num);
			}
			debuffStatMod.statData.baseValue = num * ComputeStatWithId("armor_fatigue_power") / -100f;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}

	public static float CalculateArmorLostToFatigue(Character targetCharacter, float armorToGain)
	{
		StatModController statModController = targetCharacter.statModController;
		if (statModController != null && statModController.debuffs != null)
		{
			for (int i = 0; i < statModController.debuffs.Count; i++)
			{
				List<StatModifier> list = statModController.debuffs[i];
				if (list.Count > 0 && list[0].id == "debuff_armor_fatigue")
				{
					float num = ((Weapon)list[0].sourceItem).GetComponent<HeavyHammerActivatedAbility>().ComputeStatWithId("armor_fatigue_power");
					return Mathf.FloorToInt(armorToGain * (num / 100f));
				}
			}
		}
		return 0f;
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.OnDestroy();
	}
}
