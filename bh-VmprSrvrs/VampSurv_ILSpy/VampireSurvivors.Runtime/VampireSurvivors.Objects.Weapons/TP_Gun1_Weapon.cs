using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Gun1_Weapon : Weapon
{
	private Projectile _shrapnelPrefab;

	protected BulletPool _shrapnelPool;

	protected BulletPool _gunPool;

	protected Timer _throwTimer;

	protected int _bulletCounter;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_009e: Expected I, but got O
		//IL_025c: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_02ff: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (_gunPool != null)
		{
			goto IL_0179;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_GUN1_GUN);
		BulletPool gunPool = new BulletPool(projectilePrefab);
		_gunPool = gunPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_gunPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_gunPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0179;
			}
		}
		goto IL_0338;
		IL_0338:
		throw new NullReferenceException();
		IL_0179:
		if (_shrapnelPool != null)
		{
			return;
		}
		BulletPool shrapnelPool = new BulletPool(_shrapnelPrefab);
		_shrapnelPool = shrapnelPool;
		BulletPool shrapnelPool2 = _shrapnelPool;
		shrapnelPool2.UpperLimit = 100;
		BulletPool shrapnelPool3 = _shrapnelPool;
		shrapnelPool3.IsUncapped = true;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_shrapnelPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_shrapnelPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0338;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_002a: Expected O, but got F4
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0175: Invalid comparison between O and F4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num = default(float);
		Projectile projectile = base.FireOneProjectile((Vector2)num, 0, _targetTransform);
		bool flag = ++_bulletCounter < 6;
		float num2 = num;
		if (!flag)
		{
			if (_throwTimer != null)
			{
				_throwTimer.Cancel();
			}
			Action onComplete = delegate
			{
				//IL_0029: Expected I4, but got I8
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Vector2 pos = default(Vector2);
				Projectile projectile2 = base.FireOneProjectile(pos, -1, _targetTransform);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer throwTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_throwTimer = throwTimer;
			_bulletCounter = 0;
			num2 = 0.25f;
		}
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void Cleanup()
	{
		if (_gunPool != null)
		{
			_gunPool.Cleanup();
		}
		if (_shrapnelPool != null)
		{
			_shrapnelPool.Cleanup();
		}
		base.Cleanup();
	}

	public virtual void FireShrapnel(Vector2 position, Vector2 velocity, float pAngle = 0f)
	{
		//IL_01d7: Invalid comparison between F4 and I4
		//IL_002e: Expected I, but got O
		//IL_003c: Expected I, but got O
		//IL_004c: Expected O, but got I
		//IL_00cc: Expected O, but got I4
		//IL_0088: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_0168: Invalid comparison between F4 and I4
		float num = base.PAmount();
		float num2 = pAngle * ((float)Math.PI / 180f);
		object obj = default(object);
		float num3 = (float)obj + 1f;
		float num4 = num2 - (float)Math.PI / 4f;
		float num5 = (float)Math.PI / 2f / num3;
		if (!(num3 > 0f))
		{
			return;
		}
		int num6 = 0;
		int num7 = 0;
		bool flag2;
		do
		{
			Projectile projectile = base.FireOneProjectile(position, num6, _targetTransform);
			TP_Gun1Shrapnel_Projectile tP_Gun1Shrapnel_Projectile;
			if ((object)projectile == null)
			{
				tP_Gun1Shrapnel_Projectile = null;
				goto IL_021a;
			}
			nint num8 = (nint)projectile;
			nint num9 = (nint)typeof(TP_Gun1Shrapnel_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Gun1Shrapnel_Projectile>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Gun1Shrapnel_Projectile>)+130]");
			object obj4;
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v28+FFFFFFF8+v183 @ rax_v24*8]");
				if (0 == (nint)typeof(TP_Gun1Shrapnel_Projectile))
				{
					obj4 = 1;
					goto IL_01f3;
				}
			}
			obj4 = 0;
			goto IL_01f3;
			IL_01f3:
			bool flag = obj4 == null;
			tP_Gun1Shrapnel_Projectile = null;
			if (!flag)
			{
				tP_Gun1Shrapnel_Projectile = (TP_Gun1Shrapnel_Projectile)projectile;
			}
			goto IL_021a;
			IL_021a:
			if ((object)tP_Gun1Shrapnel_Projectile != null && ((UnityEngine.Object)tP_Gun1Shrapnel_Projectile).m_CachedPtr != (IntPtr)0)
			{
				float num11 = (float)num7 * num5;
				float angleAim = num11 + num4;
				tP_Gun1Shrapnel_Projectile.ApplyAngleVelocity(angleAim);
				tP_Gun1Shrapnel_Projectile.EnableTrail(enable: true);
			}
			num6++;
			flag2 = num3 > (float)num6;
			num7 = num6;
		}
		while (flag2);
	}

	protected override void OnDestroy()
	{
		if (_shrapnelPool != null)
		{
			_shrapnelPool.Cleanup();
		}
		if (_gunPool != null)
		{
			_gunPool.Cleanup();
		}
		if (_shrapnelPool != null)
		{
			_shrapnelPool.Destroy();
		}
		if (_gunPool != null)
		{
			_gunPool.Destroy();
		}
		base.OnDestroy();
	}

	private void _003CFire_003Eb__6_0()
	{
		//IL_0029: Expected I4, but got I8
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, -1, _targetTransform);
	}
}
