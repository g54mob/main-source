using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_TP_SimonCurse1_Weapon : TP_WhipCore1_Weapon
{
	protected BulletPool _firePool;

	protected BulletPool _explosionPool;

	protected override void Awake()
	{
		base.Awake();
		_weaponNodeType = WeaponType.TP_WINDWHIP1_NODE;
	}

	public Projectile CreateFireProjectile(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_0161: Expected I, but got O
		//IL_0279: Expected I, but got O
		if (_firePool != null)
		{
			goto IL_02d3;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_WINDWHIP1_FIRE);
			BulletPool firePool = new BulletPool(projectilePrefab);
			_firePool = firePool;
			BulletPool firePool2 = _firePool;
			if (_firePool != null)
			{
				firePool2.UpperLimit = 100;
				BulletPool firePool3 = _firePool;
				if (_firePool != null)
				{
					firePool3.IsUncapped = true;
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
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_SimonCurse1_Weapon>)+350]");
									ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num = (nint)this;
									if (physics.add != null)
									{
										ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
										CallbackContext callbackContext = default(CallbackContext);
										Collider collider = physics.add.overlap(_firePool, core.Enemies, collideCallback, processCallback, callbackContext);
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
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_SimonCurse1_Weapon>)+3A0]");
															ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
															nint num2 = (nint)this;
															if (physics2.add != null)
															{
																Collider collider2 = physics2.add.overlap(_firePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
																goto IL_02d3;
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
			}
		}
		goto IL_0310;
		IL_0310:
		return (Projectile)(object)new NullReferenceException();
		IL_02d3:
		if (_firePool != null)
		{
			return _firePool.SpawnAt(pos, this);
		}
		goto IL_0310;
	}

	public Projectile SpawnWhipExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_00f3: Expected I, but got O
		//IL_020b: Expected I, but got O
		if (_explosionPool != null)
		{
			goto IL_0265;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_WINDWHIP1_EXPLOSION);
			BulletPool explosionPool = new BulletPool(projectilePrefab);
			_explosionPool = explosionPool;
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_SimonCurse1_Weapon>)+370]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(_explosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_SimonCurse1_Weapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num2 = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(_explosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
														goto IL_0265;
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
		goto IL_02a1;
		IL_02a1:
		return (Projectile)(object)new NullReferenceException();
		IL_0265:
		if (_explosionPool != null)
		{
			return _explosionPool.SpawnAt(pos, this, enemiesHit);
		}
		goto IL_02a1;
	}

	protected override void OnDestroy()
	{
		if (_firePool != null)
		{
			_firePool.Destroy();
			_firePool = null;
		}
		if (_explosionPool != null)
		{
			_explosionPool.Destroy();
			_explosionPool = null;
		}
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_firePool != null)
		{
			_firePool.Cleanup();
		}
		if (_explosionPool != null)
		{
			_explosionPool.Cleanup();
		}
		if (_nodePool != null)
		{
			_nodePool.Cleanup();
		}
		((Weapon)this).Cleanup();
	}
}
