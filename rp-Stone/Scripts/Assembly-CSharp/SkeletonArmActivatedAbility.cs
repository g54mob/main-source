using System.Collections.Generic;

public class SkeletonArmActivatedAbility : WeaponActivatedAbility
{
	public CustomAttack superAttack;

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

	public override bool IsEnabled()
	{
		if (myWeapon.Owner == null)
		{
			return false;
		}
		if (myWeapon.Owner.statModController == null)
		{
			return false;
		}
		if (myWeapon.Owner.statModController.debuffs == null)
		{
			return false;
		}
		HeroAI component = myWeapon.Owner.GetComponent<HeroAI>();
		if (component == null || component.targetEnemy == null)
		{
			return false;
		}
		if (!component.targetEnemy.Alive)
		{
			return false;
		}
		int num = component.targetEnemy.PositionX - myWeapon.Owner.PositionX;
		if (num < 4 || num > myWeapon.range + 1)
		{
			return false;
		}
		for (int i = 0; i < myWeapon.Owner.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list = myWeapon.Owner.statModController.debuffs[i];
			if (list.Count != 0 && list[0].id == "pick_pocket")
			{
				return true;
			}
		}
		return false;
	}

	protected override void Awake()
	{
		base.Awake();
		clock.cannotBeCleared = true;
	}
}
