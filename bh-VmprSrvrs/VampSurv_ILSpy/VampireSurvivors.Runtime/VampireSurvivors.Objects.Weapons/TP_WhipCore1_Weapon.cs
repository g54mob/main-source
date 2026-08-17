using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_WhipCore1_Weapon : Weapon
{
	protected WeaponType _weaponNodeType = WeaponType.TP_HOLYWHIP1_NODE;

	protected BulletPool _nodePool;

	protected int _fireCounter;

	protected int _specialCounter = 3;

	protected int _subWeaponCounter = 7;

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
		if (++_fireCounter % _specialCounter == 0)
		{
			OnSpecialCounter(skipTriggers);
		}
		if (_fireCounter % _subWeaponCounter == 0)
		{
			OnSubWeaponCounter(skipTriggers);
		}
	}

	public virtual void OnSpecialCounter(bool skipTriggers = false)
	{
	}

	public virtual void OnSubWeaponCounter(bool skipTriggers = false)
	{
	}

	public Projectile CreateNodeProjectile(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_0162: Expected I, but got O
		//IL_027a: Expected I, but got O
		if (_nodePool != null)
		{
			goto IL_02d4;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(_weaponNodeType);
			BulletPool nodePool = new BulletPool(projectilePrefab);
			_nodePool = nodePool;
			BulletPool nodePool2 = _nodePool;
			if (_nodePool != null)
			{
				nodePool2.UpperLimit = 200;
				BulletPool nodePool3 = _nodePool;
				if (_nodePool != null)
				{
					nodePool3.IsUncapped = true;
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
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WhipCore1_Weapon>)+350]");
									ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num = (nint)this;
									if (physics.add != null)
									{
										ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
										CallbackContext callbackContext = default(CallbackContext);
										Collider collider = physics.add.overlap(_nodePool, core.Enemies, collideCallback, processCallback, callbackContext);
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
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WhipCore1_Weapon>)+3A0]");
															ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
															nint num2 = (nint)this;
															if (physics2.add != null)
															{
																Collider collider2 = physics2.add.overlap(_nodePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
																goto IL_02d4;
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
		goto IL_0311;
		IL_0311:
		return (Projectile)(object)new NullReferenceException();
		IL_02d4:
		float2 pos2 = default(float2);
		if (_nodePool != null)
		{
			return _nodePool.SpawnAt(pos2, this);
		}
		goto IL_0311;
	}

	protected override void OnDestroy()
	{
		if (_nodePool != null)
		{
			_nodePool.Destroy();
			_nodePool = null;
		}
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_nodePool != null)
		{
			_nodePool.Cleanup();
		}
		base.Cleanup();
	}
}
