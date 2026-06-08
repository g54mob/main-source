using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponStateSfx : MonoBehaviour
{
	[Serializable]
	public class AlternativeSfx
	{
		public string sfxId;

		public ItemData.Element elementType;

		public int minDistance;

		public int maxDistance = 999;
	}

	public string idleSfx;

	public string castSfx;

	public int maxCastTics;

	public int minCastTics;

	public float delayForMaxCastTics;

	public float delayForMinCastTics;

	public string perfSfx;

	public float perfDelay;

	public AlternativeSfx[] alternativeSfx;

	private Weapon myWeapon;

	private Sfx idleSound;

	private void HandleWeaponStateChange(Weapon weapon, Weapon.State newState, Weapon.State currentState)
	{
		if (!base.enabled)
		{
			return;
		}
		float delay = 0f;
		switch (newState)
		{
		case Weapon.State.Casting:
		{
			int castTics = myWeapon.GetCastTics();
			if (maxCastTics == minCastTics)
			{
				if (castTics <= minCastTics)
				{
					delay = delayForMinCastTics;
				}
				else if (castTics >= maxCastTics)
				{
					delay = delayForMaxCastTics;
				}
			}
			else if (castTics > 0 && maxCastTics > minCastTics)
			{
				delay = (float)(castTics - minCastTics) / (float)(maxCastTics - minCastTics) * (delayForMaxCastTics - delayForMinCastTics) + delayForMinCastTics;
				delay = Mathf.Min(delay, (float)castTics / 30f);
			}
			PlaySfx(castSfx, delay);
			break;
		}
		case Weapon.State.Performing:
			if (!string.IsNullOrEmpty(perfSfx))
			{
				PlaySfx(perfSfx, perfDelay);
			}
			break;
		}
	}

	private void PlaySfx(string sfxId, float delay)
	{
		Weapon component = GetComponent<Weapon>();
		for (int i = 0; i < this.alternativeSfx.Length; i++)
		{
			AlternativeSfx alternativeSfx = this.alternativeSfx[i];
			if (alternativeSfx.elementType == component.element && component.distanceToTargetX >= alternativeSfx.minDistance && component.distanceToTargetX <= alternativeSfx.maxDistance)
			{
				sfxId = alternativeSfx.sfxId;
				break;
			}
		}
		if (!string.IsNullOrEmpty(sfxId))
		{
			SfxController.singleton.Play(sfxId, ignoreDuplicateSfxInSameFrame: true, delay);
		}
	}

	private void Update()
	{
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
