using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Trapano2Weapon : Weapon
{
	public Color[] _UnionSpriteColours;

	public Color[] _UnionTrailColours;

	private const float Mul = 16.666666f;

	private bool _003CIsUnion_003Ek__BackingField;

	public bool IsUnion
	{
		get
		{
			return _003CIsUnion_003Ek__BackingField;
		}
		set
		{
			_003CIsUnion_003Ek__BackingField = value;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_explosionType = WeaponType.FIREEXPLOSION;
		base.InitWeapon(characterController, weaponType);
		BulletPool projectilePool = _projectilePool;
		projectilePool.IsUncapped = true;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float num3 = num / 16.666666f;
		float num4 = frameWalk * 100f;
		float num5 = num4 * num3;
		float num6 = (base._003CTotalTime_003Ek__BackingField = num5 + num2);
		float num7 = base.PInterval();
		if (!(num6 < frameWalk))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0198: Expected I4, but got O
		//IL_0165: Expected F4, but got I4
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
						goto IL_01b5;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Trapano2Projectile component2 = gameObject2.GetComponent<Trapano2Projectile>();
							if ((object)component2 != null)
							{
								bool flag = component2.HasAlreadyHitObject(component);
								if (!flag)
								{
									float num3;
									object obj = default(object);
									if (component2._isYeeted != flag)
									{
										float num = base.PPower();
										float num2 = component2._durataMillis / 1000f;
										num3 = (float)obj * num2;
									}
									else
									{
										num3 = 0f;
									}
									float num4 = base.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									float num5 = (float)obj + num3;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									component.GetDamaged(num5, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num6 = num5 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num6;
								}
								goto IL_01b5;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01b5:
		return false;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
		CheckBeginningArcana();
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0192: Expected I4, but got O
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
						goto IL_01af;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Trapano2Projectile component2 = gameObject2.GetComponent<Trapano2Projectile>();
							if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0 && !component2.HasAlreadyHitObject(component))
							{
								float num = base.PPower();
								WeaponData currentWeaponData = _currentWeaponData;
								object obj = default(object);
								float num2 = (float)obj * 0.5f;
								HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
								float knockback = base.Knockback;
								component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
								float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
								base._003CStatsInflictedDamage_003Ek__BackingField = num3;
							}
							goto IL_01af;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01af:
		return false;
	}
}
