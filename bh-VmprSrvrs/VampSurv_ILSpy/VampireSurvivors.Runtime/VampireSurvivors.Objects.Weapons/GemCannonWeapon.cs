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

public class GemCannonWeapon : Weapon
{
	private Projectile _ExplosionProjectilePrefab;

	private float _003CGemValue_003Ek__BackingField = 1f;

	private string _003CGemFrame_003Ek__BackingField = "GemBlue";

	private BulletPool _explosionPool;

	public float GemValue
	{
		get
		{
			return _003CGemValue_003Ek__BackingField;
		}
		set
		{
			_003CGemValue_003Ek__BackingField = value;
		}
	}

	public string GemFrame
	{
		get
		{
			return _003CGemFrame_003Ek__BackingField;
		}
		set
		{
			_003CGemFrame_003Ek__BackingField = value;
		}
	}

	protected override void OnStart()
	{
		base.OnStart();
		BulletPool explosionPool = new BulletPool(_ExplosionProjectilePrefab);
		_explosionPool = explosionPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnExplosionOverlapsEnemy;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_explosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			ArcadePhysicsCallback collideCallback2 = OnExplosionOverlapsDestructible;
			Collider collider2 = physics2.add.overlap(_explosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PPower()
	{
		return _003CGemValue_003Ek__BackingField;
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
		//IL_026d->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0183->IL0183: Incompatible stack heights: 1 vs 0
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
						goto IL_0183;
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
								if (component2.HasAlreadyHitObject(component))
								{
									goto IL_0183;
								}
								float num = PPower();
								WeaponData currentWeaponData = _currentWeaponData;
								HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
								float knockback = base.Knockback;
								float value = default(float);
								component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
								float num2 = PPower();
								float num3 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
								base._003CStatsInflictedDamage_003Ek__BackingField = num3;
								Transform transform = component.transform;
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v24 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v24 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									if (_explosionPool != null)
									{
										float2 pos = default(float2);
										Projectile projectile = _explosionPool.SpawnAt(pos, this);
										goto IL_0183;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0183:
		return false;
	}

	private bool OnExplosionOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
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
									float num = PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									float value = default(float);
									component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num2 = PPower();
									float num3 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
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

	private bool OnExplosionOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0119: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Destructible component = gameObject.GetComponent<Destructible>();
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
								float num = PPower();
								if ((object)component == null)
								{
									goto IL_010b;
								}
								float value = default(float);
								component.GetDamaged(value, HitVfxType.Default, 1f, WeaponType.VOID, hasKb: false);
							}
							return false;
						}
					}
				}
			}
		}
		goto IL_010b;
		IL_010b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void TriggerExplosion(Vector2 pos)
	{
		float2 pos2 = default(float2);
		Projectile projectile = _explosionPool.SpawnAt(pos2, this);
	}

	public override void Cleanup()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Cleanup();
		}
		if (_explosionPool != null)
		{
			_explosionPool.Cleanup();
		}
	}
}
