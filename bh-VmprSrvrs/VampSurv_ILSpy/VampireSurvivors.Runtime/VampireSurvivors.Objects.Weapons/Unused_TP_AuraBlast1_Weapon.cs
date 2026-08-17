using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_TP_AuraBlast1_Weapon : TP_WhipCore1_Weapon
{
	protected BulletPool _slamPool;

	protected override void Awake()
	{
		base.Awake();
		_weaponNodeType = WeaponType.TP_unused1_node;
	}

	public Projectile CreateSlamProjectile(float2 pos)
	{
		//IL_0161: Expected I, but got O
		//IL_0279: Expected I, but got O
		if (_slamPool != null)
		{
			goto IL_02d3;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_unused1_slam);
			BulletPool slamPool = new BulletPool(projectilePrefab);
			_slamPool = slamPool;
			BulletPool slamPool2 = _slamPool;
			if (_slamPool != null)
			{
				slamPool2.UpperLimit = 100;
				BulletPool slamPool3 = _slamPool;
				if (_slamPool != null)
				{
					slamPool3.IsUncapped = true;
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
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+350]");
									ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num = (nint)this;
									if (physics.add != null)
									{
										ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
										CallbackContext callbackContext = default(CallbackContext);
										Collider collider = physics.add.overlap(_slamPool, core.Enemies, collideCallback, processCallback, callbackContext);
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
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+3A0]");
															ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
															nint num2 = (nint)this;
															if (physics2.add != null)
															{
																Collider collider2 = physics2.add.overlap(_slamPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
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
		if (_slamPool != null)
		{
			return _slamPool.SpawnAt(pos, this);
		}
		goto IL_0310;
	}

	protected override void OnDestroy()
	{
		if (_slamPool != null)
		{
			_slamPool.Destroy();
			_slamPool = null;
		}
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_slamPool != null)
		{
			_slamPool.Cleanup();
		}
		if (_nodePool != null)
		{
			_nodePool.Cleanup();
		}
		((Weapon)this).Cleanup();
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}
}
