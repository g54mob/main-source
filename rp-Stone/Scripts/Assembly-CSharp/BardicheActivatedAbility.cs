using UnityEngine;

public class BardicheActivatedAbility : WeaponActivatedAbility
{
	public CustomAttack superAttack;

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		SetAttack(superAttack);
		myWeapon.Attack(myWeapon.Owner);
		return null;
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
		if (dmg.bullet != null && dmg.bullet.weapon == myWeapon && currentAttack == superAttack && dmg.amount >= c.Hitpoints + Mathf.CeilToInt(c.Armor) && c.tags.Contains("boss"))
		{
			BardicheExecuteEventController.singleton.ReportExecute();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		base.OnDestroy();
	}
}
