public class HatchetActivatedAbility : WeaponActivatedAbility
{
	public CustomAttack attack0;

	public CustomAttack attack1;

	private int attackIndex;

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		SetAttack(attack0);
		attackIndex = 1;
		myWeapon.Attack(myWeapon.Owner);
		return null;
	}

	protected override void HandleWeaponStateChange(Weapon w, Weapon.State newState, Weapon.State prevState)
	{
		base.HandleWeaponStateChange(w, newState, prevState);
		if (newState == Weapon.State.Cooldown)
		{
			if (attackIndex == 1)
			{
				SetAttack(attack1);
				attackIndex++;
				myWeapon.Attack(myWeapon.Owner);
			}
			else
			{
				SetAttack(base.defaultAttack);
				attackIndex = 0;
			}
		}
	}

	protected override void HandleUnequipped(Character c, Weapon w)
	{
		base.HandleUnequipped(c, w);
		attackIndex = 0;
	}
}
