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

public class TP_SwordBrothers_Weapon : Weapon
{
	private Projectile _fireballPrefab;

	private BulletPool _fireballPool;

	private bool _isManualFire;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Magic;
	}

	public override float PPower()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = currentWeaponData._003Cpower_003Ek__BackingField * num;
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num3 = num2 + num2;
				return num + num3;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		WeaponData currentWeaponData = _currentWeaponData;
		currentWeaponData._003CsecondaryPower_003Ek__BackingField = 0.5f;
	}

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected override void OnStart()
	{
		//IL_00ad: Expected I, but got O
		//IL_0150: Expected I, but got O
		base.OnStart();
		if (_fireballPool == null)
		{
			BulletPool fireballPool = new BulletPool(_fireballPrefab);
			_fireballPool = fireballPool;
			BulletPool fireballPool2 = _fireballPool;
			fireballPool2.UpperLimit = 100;
			BulletPool fireballPool3 = _fireballPool;
			fireballPool3.IsUncapped = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_fireballPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_fireballPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0123: Invalid comparison between O and F4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		((Equipment)this)._003COwner_003Ek__BackingField.IsInvul = true;
		PlayerModifierStats playerStats = characterController._playerStats;
		float num = playerStats._003CInvulTimeBonus_003Ek__BackingField + 5000f;
		float num2 = num * 0.001f;
		if (num2 > characterController._invincibilityTimer)
		{
			characterController._invincibilityTimer = num2;
		}
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = num2;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void ResetFiringTimer()
	{
		if (!_isManualFire)
		{
			base.ResetFiringTimer();
		}
		else if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public TP_SwordBrothers_Firing_Projectile FireSwordProjectile()
	{
		//IL_0056: Expected I, but got O
		//IL_0064: Expected I, but got O
		//IL_0074: Expected O, but got I
		//IL_00b0: Expected O, but got I
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			TP_SwordBrothers_Firing_Projectile tP_SwordBrothers_Firing_Projectile = (TP_SwordBrothers_Firing_Projectile)base.FireOneProjectile(pos, 0);
			if ((object)tP_SwordBrothers_Firing_Projectile == null)
			{
				return tP_SwordBrothers_Firing_Projectile;
			}
			nint num = (nint)tP_SwordBrothers_Firing_Projectile;
			nint num2 = (nint)typeof(TP_SwordBrothers_Firing_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Firing_Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Firing_Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Firing_Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Firing_Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v12+FFFFFFF8+v83 @ rax_v7*8]");
				if (0 == (nint)typeof(TP_SwordBrothers_Firing_Projectile))
				{
					TP_SwordBrothers_Firing_Projectile tP_SwordBrothers_Firing_Projectile2 = null;
					return tP_SwordBrothers_Firing_Projectile;
				}
			}
			return null;
		}
		return (TP_SwordBrothers_Firing_Projectile)(object)new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		if (_fireballPool != null)
		{
			_fireballPool.Destroy();
		}
		_fireballPool = null;
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_fireballPool != null)
		{
			_fireballPool.Cleanup();
		}
		base.Cleanup();
	}
}
