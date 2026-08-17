using System;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Light2_Weapon : TP_Light1_Weapon
{
	private float GrowthBonus;

	public override float PPower()
	{
		bool flag = !(5f > GrowthBonus);
		float num = 5f;
		if (!flag)
		{
			num = GrowthBonus;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num3 = currentWeaponData._003Cpower_003Ek__BackingField * num2;
				float num4 = num2 + num3;
				return num4 + num;
			}
		}
		throw new NullReferenceException();
	}

	public override float PArea()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		bool flag = !(2f > GrowthBonus);
		float num = 2f;
		if (!flag)
		{
			num = GrowthBonus;
		}
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj2 = default(object);
		object obj = obj2 * currentWeaponData._003Carea_003Ek__BackingField;
		return (float)obj + num;
	}

	public override float PSpeed()
	{
		bool flag = !(2f > GrowthBonus);
		float num = 2f;
		if (!flag)
		{
			num = GrowthBonus;
		}
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		float num3 = default(float);
		bool flag2 = !(5f > num3);
		float num4 = 5f;
		if (!flag2)
		{
			num4 = num3;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num5 = num4 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num5 *= value;
			}
		}
		return num5 + num;
	}

	public override float PDuration()
	{
		float num = GrowthBonus * 100f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = !(2000f > num);
		float num2 = 2000f;
		if (!flag)
		{
			num2 = num;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineDuration != null)
			{
				float num3 = characterController2.PDuration();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				float value = characterController3._sineDuration.Value;
				float num4 = value * num;
				bool flag2 = !(5f > num4);
				float num5 = 5f;
				if (!flag2)
				{
					num5 = num4;
				}
				float duration = base.Duration;
				return duration * num5;
			}
		}
		float num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		bool flag3 = !(5f > num);
		float num7 = 5f;
		if (!flag3)
		{
			num7 = num;
		}
		float duration2 = base.Duration;
		float num8 = duration2 * num7;
		return num8 + num2;
	}

	private void LateUpdate()
	{
		//IL_0038: Invalid comparison between I4 and F4
		//IL_004a: Expected F4, but got I4
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PGrowth();
		object obj = default(object);
		float num2 = (float)obj - 1f;
		float num3 = num2 * 0.5f;
		bool flag = !(0f < num3);
		float growthBonus = 0f;
		if (!flag)
		{
			growthBonus = num3;
		}
		GrowthBonus = growthBonus;
	}
}
