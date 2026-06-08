using UnityEngine;

public class TalismanActivatedAbility : WeaponActivatedAbility
{
	public string summonId;

	private void SummonElemental()
	{
		SummonManager component = myWeapon.Owner.GetComponent<SummonManager>();
		if (component != null)
		{
			if (component.HasSummonWithId(summonId))
			{
				component.Unsummon(summonId);
			}
			else
			{
				component.SummonAlly(summonId, myWeapon);
			}
		}
		else
		{
			Debug.LogError("Couldn't summon " + summonId);
		}
	}

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		myWeapon.Attack(myWeapon.Owner);
		SfxController.singleton.Play("wand_cast");
		return null;
	}

	protected override void HandleWeaponStateChange(Weapon w, Weapon.State newState, Weapon.State prevState)
	{
		base.HandleWeaponStateChange(w, newState, prevState);
		if (newState == Weapon.State.Performing)
		{
			SummonElemental();
		}
	}

	protected override void HandleUnequipped(Character c, Weapon w)
	{
		base.HandleUnequipped(c, w);
	}
}
