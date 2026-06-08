using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class XpGainWeapon : MonoBehaviour
{
	private Weapon myWeapon;

	private void HandleWeaponStateChange(Weapon weapon, Weapon.State newState, Weapon.State currentState)
	{
		if (base.enabled && newState == Weapon.State.Performing)
		{
			GameStates.Singleton.level.XpEarned++;
			AchievementController.singleton.ReportXPStoneUsed();
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
