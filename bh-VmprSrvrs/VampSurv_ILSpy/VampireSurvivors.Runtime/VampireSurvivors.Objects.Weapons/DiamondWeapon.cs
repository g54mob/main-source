using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class DiamondWeapon : Weapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0087: Expected O, but got Ref
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Ref, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Ref, but got Unknown
		if (!IsHoming)
		{
			GameManager gameMan = _gameMan;
			ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
			Transform targetTransform = gameMan._stage.PickRandomEnemy(ref rng);
			_targetTransform = targetTransform;
		}
		else
		{
			GameManager core = GM.Core;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				Transform targetTransform2 = enemyController.transform;
				_targetTransform = targetTransform2;
			}
			else
			{
				GameManager gameMan2 = _gameMan;
				ref Unity.Mathematics.Random rng2 = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
				Transform targetTransform3 = gameMan2._stage.PickRandomEnemy(ref rng2);
				_targetTransform = targetTransform3;
			}
		}
		base.Fire(skipTriggers);
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_explodeOnExpire = true;
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			base._003CFreezeChance_003Ek__BackingField = 0.25f;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager3 = gameMan._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0169: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0186;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									float num2 = default(float);
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_0186;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0186:
		return false;
	}
}
