using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Battilia2Weapon : BattiliaWeapon
{
	protected override BulletPool GetBulletPool()
	{
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.BATTILIA2);
			return new BulletPool(projectilePrefab);
		}
		return (BulletPool)(object)new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public override float PAmount()
	{
		//IL_00dc: Invalid comparison between F4 and I4
		//IL_00f9: Expected F4, but got I4
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			float num3 = default(float);
			float num2 = num3 - 100f;
			num3 = num2 / 20f;
			bool flag = !(20f > num3);
			float num4 = 20f;
			if (!flag)
			{
				num4 = num3;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
				WeaponData currentWeaponData = _currentWeaponData;
				bool flag2 = !(10f > num3);
				float num6 = 10f;
				if (!flag2)
				{
					num6 = num3;
				}
				if (_currentWeaponData != null)
				{
					if (!(num4 > 0f))
					{
						num4 = 0f;
					}
					float num7 = num6 + (float)currentWeaponData._003Camount_003Ek__BackingField;
					return num7 + num4;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PPower()
	{
		//IL_0057: Invalid comparison between F4 and I4
		//IL_0077: Expected F4, but got I4
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			float num3 = default(float);
			float num2 = num3 - 100f;
			float num4 = num2 / 200f;
			if (num4 < 0f)
			{
				num4 = 0f;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num5 = currentWeaponData._003Cpower_003Ek__BackingField * num3;
					float num6 = num3 + num5;
					return num6 + num4;
				}
			}
		}
		throw new NullReferenceException();
	}

	public Battilia2Weapon()
	{
		base._retaliationDelay = 1500f;
		batAlpha = 1f;
		shadowAlpha = 0.35f;
		physScale = 1f;
		maxPhysScale = 5f;
		((Weapon)this)._002Ector();
	}
}
