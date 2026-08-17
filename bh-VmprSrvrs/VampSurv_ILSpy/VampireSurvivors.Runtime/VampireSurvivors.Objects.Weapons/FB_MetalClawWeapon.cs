using System;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class FB_MetalClawWeapon : Weapon
{
	private float maxCooldownOffset = 0.5f;

	private float cooldownOffset;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected override void OnUpdate()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj = default(object);
		float num2 = 1f / (float)obj;
		float num3 = num2 * characterController._currentHp;
		float num4 = 1f - num3;
		float num5 = num4 * maxCooldownOffset;
		cooldownOffset = num5;
	}

	public override float PInterval()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0197;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num3 = default(float);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			if (characterController2._sineCooldown == null)
			{
				goto IL_0197;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && characterController3._sineCooldown != null)
				{
					float value = characterController3._sineCooldown.Value;
					float num2 = num3 + characterController2._003CSilentCooldown_003Ek__BackingField;
					float num4 = num2 - cooldownOffset;
					num3 = value * num4;
					bool flag = !(0.1f < num3);
					float num5 = 0.1f;
					if (!flag)
					{
						num5 = num3;
					}
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null)
					{
						return num5 * currentWeaponData._003Cinterval_003Ek__BackingField;
					}
				}
			}
		}
		goto IL_0253;
		IL_0253:
		throw new NullReferenceException();
		IL_0197:
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
			WeaponData currentWeaponData2 = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num7 = num3 + characterController4._003CSilentCooldown_003Ek__BackingField;
				float num8 = num7 - cooldownOffset;
				bool flag2 = !(0.1f < num8);
				float num9 = 0.1f;
				if (!flag2)
				{
					num9 = num8;
				}
				return num9 * currentWeaponData2._003Cinterval_003Ek__BackingField;
			}
		}
		goto IL_0253;
	}
}
