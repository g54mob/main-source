using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class XiGainWeapon : MonoBehaviour
{
	private Weapon myWeapon;

	private void HandleWeaponStateChange(Weapon weapon, Weapon.State newState, Weapon.State currentState)
	{
		if (base.enabled && newState == Weapon.State.Performing)
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, 1L);
			AchievementController.singleton.ReportKiStoneUsed();
		}
	}

	private void Awake()
	{
		myWeapon = GetComponent<Weapon>();
		Weapon weapon = myWeapon;
		weapon.OnStateChange = (Action<Weapon, Weapon.State, Weapon.State>)Delegate.Combine(weapon.OnStateChange, new Action<Weapon, Weapon.State, Weapon.State>(HandleWeaponStateChange));
	}

	private void OnDestroy()
	{
		if (myWeapon != null)
		{
			Weapon weapon = myWeapon;
			weapon.OnStateChange = (Action<Weapon, Weapon.State, Weapon.State>)Delegate.Remove(weapon.OnStateChange, new Action<Weapon, Weapon.State, Weapon.State>(HandleWeaponStateChange));
		}
	}
}
