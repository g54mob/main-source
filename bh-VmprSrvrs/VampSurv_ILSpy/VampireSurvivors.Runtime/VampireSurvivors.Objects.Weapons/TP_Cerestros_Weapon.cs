using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Cerestros_Weapon : TP_Custos_Weapon
{
	private BulletPool _firePool_;

	private BulletPool _fireExplosionPool_;

	private BulletPool _icePool_;

	private BulletPool _iceExplosionPool_;

	private BulletPool _sinistroPool_;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_009e: Expected I, but got O
		//IL_0234: Expected I, but got O
		//IL_03ca: Expected I, but got O
		//IL_0560: Expected I, but got O
		//IL_06f6: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_02d7: Expected I, but got O
		//IL_046d: Expected I, but got O
		//IL_0603: Expected I, but got O
		//IL_0799: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (_firePool_ != null)
		{
			goto IL_0179;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_DCUSTOS_FIRE);
		BulletPool firePool_ = new BulletPool(projectilePrefab);
		_firePool_ = firePool_;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1633 @ r8_v63 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_firePool_, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1753 @ r8_v66 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_firePool_, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0179;
			}
		}
		goto IL_07d2;
		IL_07d2:
		throw new NullReferenceException();
		IL_063b:
		if (_sinistroPool_ != null)
		{
			return;
		}
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_CUSTOS2);
		BulletPool sinistroPool_ = new BulletPool(projectilePrefab2);
		_sinistroPool_ = sinistroPool_;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_sinistroPool_, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1765 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_sinistroPool_, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_07d2;
		IL_030f:
		if (_icePool_ != null)
		{
			goto IL_04a5;
		}
		Projectile projectilePrefab3 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_SCUSTOS_MIRAGE);
		BulletPool icePool_ = new BulletPool(projectilePrefab3);
		_icePool_ = icePool_;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			ArcadePhysics physics5 = s_scene5.physics;
			GameManager core5 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num5 = (nint)this;
			Collider collider5 = physics5.add.overlap(_icePool_, core5.Enemies, collideCallback5, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				ArcadePhysics physics6 = s_scene6.physics;
				GameManager core6 = GM.Core;
				PhysicsManager physicsManager3 = core6._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1759 @ r8_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num6 = (nint)this;
				Collider collider6 = physics6.add.overlap(_icePool_, physicsManager3._destructiblesGroup, collideCallback6, processCallback, callbackContext);
				goto IL_04a5;
			}
		}
		goto IL_07d2;
		IL_0179:
		if (_fireExplosionPool_ != null)
		{
			goto IL_030f;
		}
		Projectile projectilePrefab4 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_DCUSTOS_EXPLOSION);
		BulletPool fireExplosionPool_ = new BulletPool(projectilePrefab4);
		_fireExplosionPool_ = fireExplosionPool_;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene7 = ArcadePhysics.s_scene;
			ArcadePhysics physics7 = s_scene7.physics;
			GameManager core7 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1644 @ r8_v50 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback7 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num7 = (nint)this;
			Collider collider7 = physics7.add.overlap(_fireExplosionPool_, core7.Enemies, collideCallback7, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene8 = ArcadePhysics.s_scene;
				ArcadePhysics physics8 = s_scene8.physics;
				GameManager core8 = GM.Core;
				PhysicsManager physicsManager4 = core8._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1756 @ r8_v53 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback8 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num8 = (nint)this;
				Collider collider8 = physics8.add.overlap(_fireExplosionPool_, physicsManager4._destructiblesGroup, collideCallback8, processCallback, callbackContext);
				goto IL_030f;
			}
		}
		goto IL_07d2;
		IL_04a5:
		if (_iceExplosionPool_ != null)
		{
			goto IL_063b;
		}
		Projectile projectilePrefab5 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_SCUSTOS_EXPLOSION);
		BulletPool iceExplosionPool_ = new BulletPool(projectilePrefab5);
		_iceExplosionPool_ = iceExplosionPool_;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene9 = ArcadePhysics.s_scene;
			ArcadePhysics physics9 = s_scene9.physics;
			GameManager core9 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1656 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback9 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num9 = (nint)this;
			Collider collider9 = physics9.add.overlap(_iceExplosionPool_, core9.Enemies, collideCallback9, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene10 = ArcadePhysics.s_scene;
				ArcadePhysics physics10 = s_scene10.physics;
				GameManager core10 = GM.Core;
				PhysicsManager physicsManager5 = core10._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1762 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Cerestros_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback10 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num10 = (nint)this;
				Collider collider10 = physics10.add.overlap(_iceExplosionPool_, physicsManager5._destructiblesGroup, collideCallback10, processCallback, callbackContext);
				goto IL_063b;
			}
		}
		goto IL_07d2;
	}

	public override Projectile AddFireTrailAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		bool flag = (object)projectile == null;
		Projectile result = projectile;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			result = projectile;
			if (!flag2)
			{
				result = null;
			}
		}
		return result;
	}

	public override Projectile AddFireExplosionAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		bool flag = (object)projectile == null;
		Projectile result = projectile;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			result = projectile;
			if (!flag2)
			{
				result = null;
			}
		}
		return result;
	}

	public override Projectile AddIceTrailAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		bool flag = (object)projectile == null;
		Projectile result = projectile;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			result = projectile;
			if (!flag2)
			{
				result = null;
			}
		}
		return result;
	}

	public override Projectile AddIceExplosionAt(Vector2 pos)
	{
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
		if ((object)projectile != null)
		{
			if (((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
			{
				return null;
			}
			ArcadeSprite arcadeSprite = projectile.setTint(4379893u);
			return projectile;
		}
		return (Projectile)(object)new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Invalid comparison between O and F4
		//IL_0178: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile2 = base.FireOneProjectile(vector, 1, _targetTransform);
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile3 = base.FireOneProjectile(vector, 2, _targetTransform);
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile4 = base.FireOneProjectile(vector, 0, _targetTransform);
		float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile5 = base.FireOneProjectile(vector, 1, _targetTransform);
		float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile6 = base.FireOneProjectile(vector, 2, _targetTransform);
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

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_firePool_ != null)
		{
			_firePool_.Cleanup();
		}
		if (_fireExplosionPool_ != null)
		{
			_fireExplosionPool_.Cleanup();
		}
		if (_icePool_ != null)
		{
			_icePool_.Cleanup();
		}
		if (_iceExplosionPool_ != null)
		{
			_iceExplosionPool_.Cleanup();
		}
	}
}
