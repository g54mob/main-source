using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SilverWindWeapon : Weapon
{
	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		_explodeOnExpire = false;
		_explosionType = WeaponType.RAYEXPLOSION;
	}

	public override float PPower()
	{
		float num = base.PPower();
		float bloodlineArmorValue = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineArmorValue;
		return num + num;
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_explodeOnExpire = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_013b: Expected O, but got I
		//IL_019c: Invalid comparison between F4 and I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				float num = PPower();
				WeaponData currentWeaponData = _currentWeaponData;
				HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
				float knockback = base.Knockback;
				float value = default(float);
				component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
				float num2 = PPower();
				float num3 = (base._003CStatsInflictedDamage_003Ek__BackingField = knockback + base._003CStatsInflictedDamage_003Ek__BackingField);
				if (component._003CIsDead_003Ek__BackingField)
				{
					List<float> critChancesArray = _critChancesArray;
					int critIndex = _critIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					int num4 = (int)((nint)critIndex % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)num4 >= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					int critIndex2 = _critIndex + 1;
					_critIndex = critIndex2;
					WeaponData currentWeaponData2 = _currentWeaponData;
					float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					float num6 = num3 * currentWeaponData2._003Cchance_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v16+20+v123 @ rdx_v17 (System.Int32)*4]");
					if (!(num6 < 0f))
					{
						Transform transform = component.transform;
						Vector3 position = transform.position;
						if (!_gameMan.IsStageHost && NetworkItems.IsNetworkItem(ItemType.LITTLEHEART))
						{
							throw new NullReferenceException();
						}
						Vector2 pos = default(Vector2);
						Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
						pickup.GoToLowestHealthPlayer();
						pickup.Time = 1f;
						GameObject gameObject3 = pickup.gameObject;
						LittleHeart component3 = gameObject3.GetComponent<LittleHeart>();
						component3._Volume = 0.1f;
					}
				}
			}
		}
		return false;
	}
}
