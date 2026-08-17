using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_AlucardSpear1_Weapon : Weapon
{
	private BulletPool _pommelPool;

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
	}

	protected override void OnStart()
	{
		//IL_00bf: Expected I, but got O
		//IL_0162: Expected I, but got O
		base.OnStart();
		if (_pommelPool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_ALUCARDSPEAR_POMMEL);
			BulletPool pommelPool = new BulletPool(projectilePrefab);
			_pommelPool = pommelPool;
			BulletPool pommelPool2 = _pommelPool;
			pommelPool2.UpperLimit = 100;
			BulletPool pommelPool3 = _pommelPool;
			pommelPool3.IsUncapped = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSpear1_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_pommelPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSpear1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_pommelPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public Projectile CreatePommelProjectile(int index)
	{
		float2 pos = default(float2);
		if (_pommelPool != null)
		{
			return _pommelPool.SpawnAt(pos, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		if (_pommelPool != null)
		{
			_pommelPool.Destroy();
		}
		_pommelPool = null;
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_pommelPool != null)
		{
			_pommelPool.Cleanup();
		}
		base.Cleanup();
	}
}
