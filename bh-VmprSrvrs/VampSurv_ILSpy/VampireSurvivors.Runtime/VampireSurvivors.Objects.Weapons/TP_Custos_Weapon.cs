using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Custos_Weapon : Weapon
{
	protected BulletPool _fireHeadPool;

	protected BulletPool _iceHeadPool;

	protected BulletPool _lightningHeadPool;

	protected BulletPool _fireTrailPool;

	protected BulletPool _iceTrailPool;

	protected BulletPool _lightningTrailPool;

	protected BulletPool _fireExplosionPool;

	protected BulletPool _iceExplosionPool;

	protected BulletPool _lightningExplosionPool;

	protected BulletPool _fireFireballPool;

	protected BulletPool _iceFireballPool;

	protected BulletPool _lightningFireballPool;

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(4f > num2);
		float result = 4f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	protected void InitAllBulletPools()
	{
		BulletPool fireHeadPool = InitBulletPool(WeaponType.TP_CUSTOS1);
		_fireHeadPool = fireHeadPool;
		BulletPool iceHeadPool = InitBulletPool(WeaponType.TP_CUSTOS2);
		_iceHeadPool = iceHeadPool;
		BulletPool lightningHeadPool = InitBulletPool(WeaponType.TP_CUSTOS3_BITE);
		_lightningHeadPool = lightningHeadPool;
		BulletPool fireExplosionPool = InitBulletPool(WeaponType.TP_DCUSTOS_EXPLOSION);
		_fireExplosionPool = fireExplosionPool;
		BulletPool iceExplosionPool = InitBulletPool(WeaponType.TP_SCUSTOS_EXPLOSION);
		_iceExplosionPool = iceExplosionPool;
		BulletPool lightningExplosionPool = InitBulletPool(WeaponType.TP_DCUSTOS_EXPLOSION);
		_lightningExplosionPool = lightningExplosionPool;
		BulletPool fireTrailPool = InitSecondaryBulletPool(WeaponType.TP_DCUSTOS_FIRE);
		_fireTrailPool = fireTrailPool;
		BulletPool iceTrailPool = InitSecondaryBulletPool(WeaponType.TP_DCUSTOS_FIRE);
		_iceTrailPool = iceTrailPool;
		BulletPool lightningTrailPool = InitSecondaryBulletPool(WeaponType.TP_DCUSTOS_FIRE);
		_lightningTrailPool = lightningTrailPool;
		BulletPool fireFireballPool = InitSecondaryBulletPool(WeaponType.TP_CUSTOS4_FIREBALL);
		_fireFireballPool = fireFireballPool;
		BulletPool iceFireballPool = InitSecondaryBulletPool(WeaponType.TP_CUSTOS4_FIREBALL);
		_iceFireballPool = iceFireballPool;
		BulletPool lightningFireballPool = InitSecondaryBulletPool(WeaponType.TP_CUSTOS4_FIREBALL);
		_lightningFireballPool = lightningFireballPool;
	}

	protected BulletPool InitBulletPool(WeaponType weaponType)
	{
		//IL_00c4: Expected I, but got O
		//IL_01da: Expected I, but got O
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(weaponType);
			BulletPool bulletPool = new BulletPool(projectilePrefab);
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+350]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(bulletPool, core.Enemies, collideCallback, processCallback, callbackContext);
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num2 = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(bulletPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
														return bulletPool;
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
		return (BulletPool)(object)new NullReferenceException();
	}

	protected BulletPool InitSecondaryBulletPool(WeaponType weaponType)
	{
		//IL_00c4: Expected I, but got O
		//IL_01da: Expected I, but got O
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(weaponType);
			BulletPool bulletPool = new BulletPool(projectilePrefab);
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+370]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(bulletPool, core.Enemies, collideCallback, processCallback, callbackContext);
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num2 = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(bulletPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
														return bulletPool;
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
		return (BulletPool)(object)new NullReferenceException();
	}

	public virtual Projectile AddFireTrailAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null)
		{
			bool flag = ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0;
			Projectile result = projectile;
			if (!flag)
			{
				result = null;
			}
			return result;
		}
		return null;
	}

	public virtual Projectile AddFireExplosionAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null)
		{
			bool flag = ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0;
			Projectile result = projectile;
			if (!flag)
			{
				result = null;
			}
			return result;
		}
		return null;
	}

	public virtual Projectile AddIceTrailAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null)
		{
			bool flag = ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0;
			Projectile result = projectile;
			if (!flag)
			{
				result = null;
			}
			return result;
		}
		return null;
	}

	public virtual Projectile AddIceExplosionAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite arcadeSprite = projectile.setTint(4379893u);
			return projectile;
		}
		return null;
	}

	public virtual Projectile AddLightningTrailAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null)
		{
			bool flag = ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0;
			Projectile result = projectile;
			if (!flag)
			{
				result = null;
			}
			return result;
		}
		return null;
	}

	public virtual Projectile AddLightningExplosionAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null)
		{
			bool flag = ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0;
			Projectile result = projectile;
			if (!flag)
			{
				result = null;
			}
			return result;
		}
		return null;
	}

	public override bool LevelUp()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Custos_Weapon>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_fireHeadPool != null)
		{
			_fireHeadPool.Cleanup();
		}
		if (_iceHeadPool != null)
		{
			_iceHeadPool.Cleanup();
		}
		if (_lightningHeadPool != null)
		{
			_lightningHeadPool.Cleanup();
		}
		if (_fireTrailPool != null)
		{
			_fireTrailPool.Cleanup();
		}
		if (_iceTrailPool != null)
		{
			_iceTrailPool.Cleanup();
		}
		if (_lightningTrailPool != null)
		{
			_lightningTrailPool.Cleanup();
		}
		if (_fireExplosionPool != null)
		{
			_fireExplosionPool.Cleanup();
		}
		if (_iceExplosionPool != null)
		{
			_iceExplosionPool.Cleanup();
		}
		if (_lightningExplosionPool != null)
		{
			_lightningExplosionPool.Cleanup();
		}
	}
}
