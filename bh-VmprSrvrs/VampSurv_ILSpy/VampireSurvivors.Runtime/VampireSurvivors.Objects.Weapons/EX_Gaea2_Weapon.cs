using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class EX_Gaea2_Weapon : EX_Gaea1_Weapon
{
	private BulletPool _retaliationPool;

	private bool _canRetaliate;

	private Timer _retaliationTimer;

	public override float PPower()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((characterController._isInvul || characterController._receivingDamage) ? 2f : 1f);
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num3 = currentWeaponData._003Cpower_003Ek__BackingField * num2;
				float num4 = num3 * num;
				return num2 + num4;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((EX_Gaea2_Weapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
		((EX_Gaea2_Weapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
		((EX_Gaea2_Weapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((EX_Gaea2_Weapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		_canRetaliate = true;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((EX_Gaea2_Weapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
			((EX_Gaea2_Weapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((EX_Gaea2_Weapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((EX_Gaea2_Weapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		}
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_retaliationTimer != null)
		{
			_retaliationTimer.Cancel();
		}
	}

	protected override void OnStart()
	{
		//IL_0092: Expected I, but got O
		//IL_0123: Expected I, but got O
		base.OnStart();
		if (_retaliationPool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.EX_GAEA1);
			BulletPool retaliationPool = new BulletPool(projectilePrefab);
			_retaliationPool = retaliationPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			PhysicsManager physicsManager = core._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Gaea2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_retaliationPool, physicsManager._destructiblesGroup, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Gaea2_Weapon>)+390]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_retaliationPool, core2.Enemies, collideCallback2, processCallback, callbackContext);
		}
	}

	private void OnPlayerHitDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+CharacterReceivedDamageSignal)+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		OnPlayerHit();
	}

	private void OnPlayerHitShield(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_0113: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		OnPlayerHit();
	}

	private void OnPlayerHit()
	{
		if (_canRetaliate)
		{
			_canRetaliate = false;
			if (_retaliationTimer != null)
			{
				_retaliationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer retaliationTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_retaliationTimer = retaliationTimer;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 pos = default(float2);
			Projectile projectile = _retaliationPool.SpawnAt(pos, this);
		}
	}

	private Projectile FireOneRetaliatoryProjectile(Vector2 pos, int index)
	{
		float2 pos2 = default(float2);
		if (_retaliationPool != null)
		{
			return _retaliationPool.SpawnAt(pos2, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	private void _003COnPlayerHit_003Eb__9_0()
	{
		_canRetaliate = true;
	}
}
