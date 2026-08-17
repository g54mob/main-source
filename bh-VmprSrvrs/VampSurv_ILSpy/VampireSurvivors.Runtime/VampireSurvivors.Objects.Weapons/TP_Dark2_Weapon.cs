using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Dark2_Weapon : TP_Dark1_Weapon
{
	private float MagnetBonus;

	public override float PPower()
	{
		bool flag = !(5f > MagnetBonus);
		float num = 5f;
		if (!flag)
		{
			num = MagnetBonus;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num3 = num + currentWeaponData._003Cpower_003Ek__BackingField;
				float num4 = num3 * num2;
				return num2 + num4;
			}
		}
		throw new NullReferenceException();
	}

	public override float PArea()
	{
		bool flag = !(2f > MagnetBonus);
		float num = 2f;
		if (!flag)
		{
			num = MagnetBonus;
		}
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		float num3 = num + currentWeaponData._003Carea_003Ek__BackingField;
		object obj = default(object);
		return num3 * (float)obj;
	}

	public override float PSpeed()
	{
		float num = MagnetBonus * 0.5f;
		bool flag = !(2f > num);
		float num2 = 2f;
		if (!flag)
		{
			num2 = num;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num4 = num * currentWeaponData._003Cspeed_003Ek__BackingField;
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				num = num4 + num2;
				bool flag2 = !(5f > num);
				float num5 = 5f;
				if (!flag2)
				{
					num5 = num;
				}
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						goto IL_014f;
					}
					if (characterController2._sineSpeed != null)
					{
						float value = characterController2._sineSpeed.Value;
						num5 *= value;
					}
				}
				return num5;
			}
		}
		goto IL_014f;
		IL_014f:
		throw new NullReferenceException();
	}

	public override float PDuration()
	{
		bool flag = !(2f > MagnetBonus);
		float num = 2f;
		if (!flag)
		{
			num = MagnetBonus;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj = default(object);
		float num4;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineDuration != null)
			{
				float num2 = characterController2.PDuration();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				float value = characterController3._sineDuration.Value;
				float num3 = (float)obj + num;
				num4 = value * num3;
				goto IL_0164;
			}
		}
		float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		num4 = (float)obj + num;
		goto IL_0164;
		IL_0164:
		bool flag2 = !(5f > num4);
		float num6 = 5f;
		if (!flag2)
		{
			num6 = num4;
		}
		float duration = base.Duration;
		return duration * num6;
	}

	private void LateUpdate()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0126: Invalid comparison between I4 and F4
		//IL_0138: Expected F4, but got I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController._magnet;
		EggFloat radius = magnet.Radius;
		float num = radius._eggVal + radius._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018740ECA7h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_00fd;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00fd;
		IL_00fd:
		float num2 = num - 30f;
		float num3 = num2 / 400f;
		bool flag = !(0f < num3);
		float magnetBonus = 0f;
		if (!flag)
		{
			magnetBonus = num3;
		}
		MagnetBonus = magnetBonus;
	}
}
