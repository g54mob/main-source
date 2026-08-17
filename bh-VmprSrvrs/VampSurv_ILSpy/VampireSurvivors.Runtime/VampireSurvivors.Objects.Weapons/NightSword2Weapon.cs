using System;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class NightSword2Weapon : NightSwordWeapon
{
	public override float PPower()
	{
		//IL_008c: Invalid comparison between F4 and I4
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
			WeaponData currentWeaponData = _currentWeaponData;
			float num3 = default(float);
			float num2 = num3 - 1f;
			num3 = num2 + num2;
			if (_currentWeaponData != null)
			{
				float num4 = currentWeaponData._003Cpower_003Ek__BackingField;
				if (num3 > 0f)
				{
					num3++;
					num4 *= num3;
				}
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
						float num5 = num3 * num4;
						return num3 + num5;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
		((NightSwordWeapon)(object)action).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((NightSwordWeapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action);
		Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
		((NightSwordWeapon)(object)action2).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
		((NightSwordWeapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action2);
		base._canExplode = true;
		_explosionType = WeaponType.NIGHTSWORD;
		((Weapon)this)._003CCanCrit_003Ek__BackingField = false;
		_FireAngles = new int[6] { 20, -20, -70, 30, -30, 0 };
		_CanFinish = true;
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		_Volume = 0.5f;
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		if (!((Equipment)this)._003COwner_003Ek__BackingField.DrainWeaponsImmunity)
		{
			CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			object obj = default(object);
			float num2 = characterController._currentHp / (float)obj;
			float num3 = num2 * 4f;
			bool flag = !(1f < num3);
			float damageAmount = 1f;
			if (!flag)
			{
				damageAmount = num3;
			}
			((Equipment)this)._003COwner_003Ek__BackingField.TriggerGetDamagedByOwnWeapon(damageAmount);
		}
	}

	public NightSword2Weapon()
	{
		_FireAngles = new int[6] { 20, -20, -70, 30, -30, 70 };
		_FireX = new int[6] { -16, 16, 0, 16, -16, 0 };
		base._retaliationDelay = 600f;
		_Volume = 1f;
		((Weapon)this)._002Ector();
	}
}
