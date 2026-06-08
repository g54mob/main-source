using System.Collections.Generic;

public class CrusaderActivatedAbility : WeaponActivatedAbility
{
	public CustomAttack superAttack;

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		SetAttack(superAttack);
		myWeapon.Attack(myWeapon.Owner);
		return base.ActivateAbility();
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
		for (int i = 0; i < myWeapon.Owner.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list = myWeapon.Owner.statModController.debuffs[i];
			if (list[0].id == "sanctity" && list.Count >= 4)
			{
				return true;
			}
		}
		return false;
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

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}
}
