using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_WineGlass1_Weapon : Weapon
{
	private BulletPool _invisibleProjectilePool;

	private BulletPool _explosionProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	private Projectile _explosionProjectilePrefab;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	protected override void OnStart()
	{
		//IL_0054: Expected I, but got O
		//IL_00f7: Expected I, but got O
		//IL_01b1: Expected I, but got O
		//IL_0254: Expected I, but got O
		base.OnStart();
		BulletPool invisibleProjectilePool = new BulletPool(_invisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass1_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			BulletPool explosionProjectilePool = new BulletPool(_explosionProjectilePrefab);
			_explosionProjectilePool = explosionProjectilePool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass1_Weapon>)+350]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider3 = physics3.add.overlap(_explosionProjectilePool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					PhysicsManager physicsManager2 = core4._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass1_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num4 = (nint)this;
					Collider collider4 = physics4.add.overlap(_explosionProjectilePool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void FireProjectiles(Vector2 position)
	{
		//IL_0023: Invalid comparison between F4 and I4
		//IL_0073: Invalid comparison between F4 and I4
		float num = base.PAmount();
		int num3 = default(int);
		float num2 = (float)num3 * 4f;
		bool flag = !(num2 > 0f);
		int num4 = 0;
		if (!flag)
		{
			do
			{
				Projectile projectile = base.FireOneProjectile(position, num4, _targetTransform);
				num4++;
			}
			while (num2 > (float)num4);
		}
	}

	public void FireExplosion(Vector2 position)
	{
		Projectile projectile = base.FireOneProjectile(position, 0, _targetTransform);
	}

	public override void Cleanup()
	{
		_invisibleProjectilePool.Cleanup();
		_explosionProjectilePool.Cleanup();
		base.Cleanup();
	}
}
