using System;
using System.Collections.Generic;
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

public class HatWeapon : Weapon
{
	[NonSerialized]
	public int MaxHats;

	[NonSerialized]
	public int DragogionRand;

	private BulletPool _explosionPool;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0080: Expected I, but got O
		//IL_0123: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		_bounces = 2;
		if (_explosionPool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.C1_HATCOLLECTION_EXPLO);
			BulletPool explosionPool = new BulletPool(projectilePrefab);
			_explosionPool = explosionPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.HatWeapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_explosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.HatWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_explosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0148: Expected F4, but got I4
		//IL_014d: Expected I, but got O
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00a7: Invalid comparison between O and F4
		//IL_0060: Expected F4, but got I
		float num = base.PAmount();
		int num2 = default(int);
		bool flag = MaxHats > num2;
		int num3 = num2;
		if (!flag)
		{
			num3 = MaxHats;
		}
		bool flag2 = num3 <= 0;
		float num4 = 0f;
		nint num5 = unchecked((nint)null);
		if (!flag2)
		{
			Vector2 pos = default(Vector2);
			bool flag3;
			do
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Projectile projectile = base.FireOneProjectile(pos, (int)num5, _targetTransform);
				num5++;
				flag3 = num3 > num5;
				num4 = num5;
			}
			while (flag3);
		}
		float num6 = base.PInterval();
		float num7 = _lastFiringInterval - num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num8 = base.PInterval();
			_lastFiringInterval = num4;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public float throwInterval()
	{
		//IL_003f: Invalid comparison between F4 and O
		float num = base.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = currentWeaponData._003CrepeatInterval_003Ek__BackingField * (float)obj;
		float num3 = base.PInterval();
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			WeaponData currentWeaponData2 = _currentWeaponData;
			return currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
		}
		float num4 = base.PInterval();
		float num5 = base.PAmount();
		float num6 = (float)obj + 1f;
		return (float)obj / num6;
	}

	public void ExplodeAt(float x, float y, int index)
	{
		float2 pos = default(float2);
		Projectile projectile = _explosionPool.SpawnAt(pos, this, index);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_explosionPool != null)
		{
			_explosionPool.Cleanup();
		}
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 3;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public HatWeapon()
	{
		//IL_0026: Expected I4, but got I8
		MaxHats = 10;
		DragogionRand = -1;
		base._002Ector();
	}
}
