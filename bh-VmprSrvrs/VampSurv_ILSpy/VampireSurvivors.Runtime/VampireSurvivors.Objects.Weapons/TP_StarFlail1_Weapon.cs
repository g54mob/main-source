using System;
using System.Runtime.CompilerServices;
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

public class TP_StarFlail1_Weapon : Weapon
{
	private BulletPool _bladePool;

	private BulletPool _swipeBodyPool;

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PRegen();
			float num3 = default(float);
			float num2 = num3 * 1.25f;
			float num4 = num2 + 1f;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num5 = num4 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num6 = num5 * num3;
					return num3 + num6;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public TP_StarFlail1_Blade_Projectile SpawnBladeAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_02c6: Expected I, but got O
		//IL_02d4: Expected I, but got O
		//IL_02e4: Expected O, but got I
		//IL_0364: Expected O, but got I4
		//IL_0320: Expected O, but got I
		//IL_0356: Expected O, but got I4
		//IL_00f3: Expected I, but got O
		//IL_020b: Expected I, but got O
		if (_bladePool != null)
		{
			goto IL_0265;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_STARFLAIL1_BLADE);
			BulletPool bladePool = new BulletPool(projectilePrefab);
			_bladePool = bladePool;
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+350]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(_bladePool, core.Enemies, collideCallback, processCallback, callbackContext);
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num2 = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(_bladePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
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
		goto IL_0376;
		IL_03f4:
		TP_StarFlail1_Blade_Projectile result;
		return result;
		IL_0265:
		if (_bladePool == null)
		{
			goto IL_0376;
		}
		Projectile projectile = _bladePool.SpawnAt(pos, this, enemiesHit);
		bool flag = (object)projectile == null;
		result = null;
		if (flag)
		{
			goto IL_03f4;
		}
		nint num3 = (nint)projectile;
		nint num4 = (nint)typeof(TP_StarFlail1_Blade_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_StarFlail1_Blade_Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_StarFlail1_Blade_Projectile>)+130]");
		object obj3;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v12+FFFFFFF8+v387 @ rax_v8*8]");
			if (0 == (nint)typeof(TP_StarFlail1_Blade_Projectile))
			{
				obj3 = 1;
				goto IL_03f9;
			}
		}
		obj3 = 0;
		goto IL_03f9;
		IL_0376:
		return (TP_StarFlail1_Blade_Projectile)(object)new NullReferenceException();
		IL_03f9:
		bool flag2 = obj3 == null;
		result = null;
		if (!flag2)
		{
			result = (TP_StarFlail1_Blade_Projectile)projectile;
		}
		goto IL_03f4;
	}

	public Projectile CreateSwipeBodyProjectile()
	{
		//IL_0161: Expected I, but got O
		//IL_0279: Expected I, but got O
		if (_swipeBodyPool != null)
		{
			goto IL_02d3;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_ALUCARDSPEAR_POMMEL);
			BulletPool swipeBodyPool = new BulletPool(projectilePrefab);
			_swipeBodyPool = swipeBodyPool;
			BulletPool swipeBodyPool2 = _swipeBodyPool;
			if (_swipeBodyPool != null)
			{
				swipeBodyPool2.UpperLimit = 100;
				BulletPool swipeBodyPool3 = _swipeBodyPool;
				if (_swipeBodyPool != null)
				{
					swipeBodyPool3.IsUncapped = true;
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
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+350]");
									ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num = (nint)this;
									if (physics.add != null)
									{
										ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
										CallbackContext callbackContext = default(CallbackContext);
										Collider collider = physics.add.overlap(_swipeBodyPool, core.Enemies, collideCallback, processCallback, callbackContext);
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
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+3A0]");
															ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
															nint num2 = (nint)this;
															if (physics2.add != null)
															{
																Collider collider2 = physics2.add.overlap(_swipeBodyPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
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
		float2 pos = default(float2);
		if (_swipeBodyPool != null)
		{
			return _swipeBodyPool.SpawnAt(pos, this);
		}
		goto IL_0310;
	}

	protected override void OnDestroy()
	{
		if (_swipeBodyPool != null)
		{
			_swipeBodyPool.Destroy();
		}
		_swipeBodyPool = null;
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_swipeBodyPool != null)
		{
			_swipeBodyPool.Cleanup();
		}
		base.Cleanup();
	}
}
