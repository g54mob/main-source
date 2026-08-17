using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Backup_PrototypeDroneBWeapon : FB_RapidFireWeapon
{
	private BulletPool _planeBulletPool;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_011a: Expected I, but got O
		//IL_0128: Expected I, but got O
		//IL_0138: Expected O, but got I
		//IL_01b8: Expected O, but got I4
		//IL_0174: Expected O, but got I
		//IL_01aa: Expected O, but got I4
		//IL_0326: Expected I, but got O
		//IL_037d: Expected O, but got I
		//IL_0444: Expected I, but got O
		//IL_049b: Expected O, but got I
		//IL_04cf: Expected I4, but got O
		//IL_00e9->IL04de: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL04de: Incompatible stack heights: 1 vs 0
		//IL_0232->IL04de: Incompatible stack heights: 1 vs 0
		//IL_0254->IL04de: Incompatible stack heights: 1 vs 0
		//IL_02ab->IL04de: Incompatible stack heights: 1 vs 0
		//IL_05b4->IL04de: Incompatible stack heights: 1 vs 0
		//IL_02df->IL04de: Incompatible stack heights: 1 vs 0
		//IL_0306->IL04de: Incompatible stack heights: 1 vs 0
		//IL_0349->IL04de: Incompatible stack heights: 1 vs 0
		//IL_039a->IL04de: Incompatible stack heights: 1 vs 0
		//IL_05db->IL04de: Incompatible stack heights: 1 vs 0
		//IL_03ce->IL04de: Incompatible stack heights: 1 vs 0
		//IL_03f5->IL04de: Incompatible stack heights: 1 vs 0
		//IL_0424->IL04de: Incompatible stack heights: 1 vs 0
		//IL_0467->IL04de: Incompatible stack heights: 1 vs 0
		//IL_04d8->IL05e0: Incompatible stack heights: 1 vs 0
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		if (_planeBulletPool == null)
		{
			if ((object)_projectileFactory == null)
			{
				goto IL_04de;
			}
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FB_PLANES);
			BulletPool planeBulletPool = new BulletPool(projectilePrefab);
			_planeBulletPool = planeBulletPool;
			weaponType2 = WeaponType.POWER;
		}
		int num = 0;
		ArcadeSprite arcadeSprite = null;
		Vector2 pos = default(Vector2);
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		while (true)
		{
			ArcadeSprite arcadeSprite2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
			{
				break;
			}
			Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
			if ((object)cachedTrans == null)
			{
				break;
			}
			bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite2.body != null)
			{
				BaseBody body = arcadeSprite2.body;
				ArcadeTransform arcadeTransform = body._transform;
				if (body._transform == null)
				{
					break;
				}
				arcadeTransform.position = ret;
			}
			Projectile projectile = base.FireOneProjectile(pos, num, _targetTransform);
			ArcadeSprite arcadeSprite3;
			if ((object)projectile == null)
			{
				arcadeSprite3 = arcadeSprite;
				goto IL_01ca;
			}
			nint num2 = (nint)projectile;
			nint num3 = (nint)typeof(Backup_PlaneProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Backup_PlaneProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Backup_PlaneProjectile>)+130]");
			object obj3;
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v825 @ rax_v61+FFFFFFF8+v770 @ rax_v57*8]");
				if (0 == (nint)typeof(Backup_PlaneProjectile))
				{
					obj3 = 1;
					goto IL_056d;
				}
			}
			obj3 = 0;
			goto IL_056d;
			IL_056d:
			bool flag2 = obj3 == null;
			arcadeSprite3 = arcadeSprite;
			if (!flag2)
			{
				arcadeSprite3 = projectile;
			}
			goto IL_01ca;
			IL_01ca:
			Sprite sprite = SpriteManager.GetSprite("fb_A2_prototype", "items");
			if ((object)arcadeSprite3 == null)
			{
				break;
			}
			ArcadeSprite arcadeSprite4 = arcadeSprite3.setFrame(sprite);
			GameManager core = GM.Core;
			if ((object)GM.Core == null || (object)core._projectileFactory == null)
			{
				break;
			}
			Projectile projectilePrefab2 = core._projectileFactory.GetProjectilePrefab(WeaponType.FB_RAPIDFIRE);
			BulletPool bulletPool = new BulletPool(projectilePrefab2);
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene == null)
			{
				break;
			}
			ArcadePhysics physics = s_scene.physics;
			if ((object)s_scene.physics == null)
			{
				break;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeDroneBWeapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num5 = (nint)this;
			if (physics.add == null)
			{
				break;
			}
			Factory add = physics.add;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rsi_v6 (ArcadeSprite)+E8]");
			Collider collider = add.overlap((ArcadeColliderType)0, core2.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene == null)
			{
				break;
			}
			ArcadePhysics physics2 = s_scene2.physics;
			if ((object)s_scene2.physics == null)
			{
				break;
			}
			GameManager core3 = GM.Core;
			if ((object)GM.Core == null)
			{
				break;
			}
			PhysicsManager physicsManager = core3._physicsManager;
			if (core3._physicsManager == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeDroneBWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num6 = (nint)this;
			if (physics2.add == null)
			{
				break;
			}
			Factory add2 = physics2.add;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rsi_v6 (ArcadeSprite)+E8]");
			Collider collider2 = add2.overlap((ArcadeColliderType)0, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			num++;
			bool flag3 = num < 3;
			arcadeSprite = null;
			weaponType2 = (WeaponType)physicsManager._destructiblesGroup;
			if (!flag3)
			{
				return;
			}
		}
		goto IL_04de;
		IL_04de:
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_planeBulletPool.Cleanup();
	}

	public Backup_PrototypeDroneBWeapon()
	{
		//IL_0017: Expected O, but got I4
		base._particlesOffset = (float2)0;
		_ = 1047904911;
		((Weapon)this)._002Ector();
	}
}
