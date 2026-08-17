using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Chauve2_Weapon : TP_Chauve1_Weapon
{
	private BulletPool _beamPool;

	private const float _shootTimeMillis = 250f;

	public float ShootTimeMillis => 250f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
	}

	public Projectile SpawnBeamAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_0200: Expected I, but got O
		if (_beamPool != null)
		{
			goto IL_025a;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_CHAUVE2_BEAM);
			BulletPool beamPool = new BulletPool(projectilePrefab);
			_beamPool = beamPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					ArcadePhysics physics = s_scene.physics;
					if ((object)s_scene.physics != null)
					{
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							ArcadePhysicsCallback collideCallback = OnBeamOverlapsEnemy;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(_beamPool, core.Enemies, collideCallback, processCallback, callbackContext);
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										ArcadePhysics physics2 = s_scene2.physics;
										if ((object)s_scene2.physics != null)
										{
											GameManager core2 = GM.Core;
											if ((object)GM.Core != null)
											{
												PhysicsManager physicsManager = core2._physicsManager;
												if (core2._physicsManager != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Chauve2_Weapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(_beamPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
														goto IL_025a;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0296;
		IL_0296:
		return (Projectile)(object)new NullReferenceException();
		IL_025a:
		if (_beamPool != null)
		{
			return _beamPool.SpawnAt(pos, this, enemiesHit);
		}
		goto IL_0296;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0164: Expected I4, but got O
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
						goto IL_0150;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							TP_Chauve2_Projectile component2 = gameObject2.GetComponent<TP_Chauve2_Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if (!component2.IsCrit)
									{
										float num = base.PPower();
										float damage = default(float);
										base.DealDamage(component, damage);
										return false;
									}
									DealCritDamage(component);
								}
								goto IL_0150;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0150:
		return false;
	}

	private bool OnBeamOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_012b: Expected I4, but got O
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
						goto IL_0117;
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
									DealCritDamage(component);
								}
								goto IL_0117;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0117:
		return false;
	}

	private void DealCritDamage(EnemyController target)
	{
		WeaponData currentWeaponData = _currentWeaponData;
		float num = base.PPower();
		WeaponData currentWeaponData2 = _currentWeaponData;
		float num2 = ArcanaManager.CritMul * currentWeaponData._003CcritMul_003Ek__BackingField;
		object obj = default(object);
		float num3 = (float)obj * num2;
		HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData2._003ChitVFX_003Ek__BackingField);
		float knockback = base.Knockback;
		target.GetDamaged(num3, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
		float num4 = num3 + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
		((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num4;
	}
}
