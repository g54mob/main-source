using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class SwordWeapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__14_0;

		public static TweenCallback _003C_003E9__14_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__14_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__14_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public SwordWeapon _003C_003E4__this;

		public int finisherIndex;

		public bool isRetaliatory;

		public int volume;

		internal void _003CFireInternal_003Eb__0()
		{
			SwordWeapon swordWeapon = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)swordWeapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)swordWeapon)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				SwordWeapon swordWeapon2 = _003C_003E4__this;
				((Equipment)swordWeapon2)._003COwner_003Ek__BackingField.OnMeleeAttackAnim();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public int i;

		public _003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireInternal_003Eb__1()
		{
			//IL_01c6: Expected F4, but got I4
			//IL_0172: Expected F4, but got I4
			_003C_003Ec__DisplayClass19_0 obj = CS_0024_003C_003E8__locals1;
			SwordWeapon swordWeapon = obj._003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)swordWeapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)swordWeapon)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				_003C_003Ec__DisplayClass19_0 obj2 = CS_0024_003C_003E8__locals1;
				Vector2 pos = default(Vector2);
				if (obj2.finisherIndex == i)
				{
					SwordWeapon swordWeapon2 = obj2._003C_003E4__this;
					float2 position = ((Equipment)swordWeapon2)._003COwner_003Ek__BackingField.position;
					_003C_003Ec__DisplayClass19_0 obj3 = CS_0024_003C_003E8__locals1;
					SwordWeapon swordWeapon3 = obj3._003C_003E4__this;
					BulletPool pool = default(BulletPool);
					Projectile projectile = swordWeapon2.FireOneFinisherProjectile(pos, i, swordWeapon3._targetTransform, pool);
				}
				else if (!obj2.isRetaliatory)
				{
					SwordWeapon swordWeapon4 = obj2._003C_003E4__this;
					float2 position2 = ((Equipment)swordWeapon4)._003COwner_003Ek__BackingField.position;
					_003C_003Ec__DisplayClass19_0 obj4 = CS_0024_003C_003E8__locals1;
					Projectile projectile2 = swordWeapon4.FireOneProjectile(pos, i, obj4.volume);
				}
				else
				{
					SwordWeapon swordWeapon5 = obj2._003C_003E4__this;
					float2 position3 = ((Equipment)swordWeapon5)._003COwner_003Ek__BackingField.position;
					_003C_003Ec__DisplayClass19_0 obj5 = CS_0024_003C_003E8__locals1;
					Projectile projectile3 = swordWeapon5.FireOneRetaliatoryProjectile(pos, i, obj5.volume);
				}
			}
		}
	}

	private int _firingCounter;

	private int _lastFiringCounter;

	private int _maxFiringCounter = 5;

	private BulletPool _finisherPool;

	private BulletPool _retaliationPool;

	private bool _canRetaliate;

	private Timer _retaliationTimer;

	private Timer _meleeAnimEvent;

	protected bool _canDoFinisher;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_firingCounter = 0;
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((SwordWeapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
		((SwordWeapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
		((SwordWeapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((SwordWeapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		_canRetaliate = true;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((SwordWeapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
			((SwordWeapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((SwordWeapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((SwordWeapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		}
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_retaliationTimer != null)
		{
			_retaliationTimer.Cancel();
		}
		if (_meleeAnimEvent != null)
		{
			_meleeAnimEvent.Cancel();
		}
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			base._003CCanCrit_003Ek__BackingField = true;
		}
		CheckBeginningArcana();
	}

	public override void ParadoxFire()
	{
		FireInternal(isRetaliatory: false, skipTriggers: true);
	}

	public override void Fire(bool skipTriggers = false)
	{
		FireInternal();
	}

	public void ScreenShake()
	{
		//IL_00b3: Expected I, but got O
		//IL_0133: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 4;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__14_0;
		if (_003C_003Ec._003C_003E9__14_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__14_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__14_1;
		if (_003C_003Ec._003C_003E9__14_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	protected override void OnStart()
	{
		//IL_00b0: Expected I, but got O
		//IL_0246: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_02d7: Expected I, but got O
		base.OnStart();
		if (_retaliationPool != null)
		{
			goto IL_0179;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.SWORD);
		BulletPool retaliationPool = new BulletPool(projectilePrefab);
		_retaliationPool = retaliationPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			PhysicsManager physicsManager = core._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.SwordWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_retaliationPool, physicsManager._destructiblesGroup, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.SwordWeapon>)+390]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_retaliationPool, core2.Enemies, collideCallback2, processCallback, callbackContext);
				goto IL_0179;
			}
		}
		goto IL_0310;
		IL_0310:
		throw new NullReferenceException();
		IL_0179:
		if (_finisherPool != null)
		{
			return;
		}
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.SWORD_FINISHER);
		BulletPool finisherPool = new BulletPool(projectilePrefab2);
		_finisherPool = finisherPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			PhysicsManager physicsManager2 = core3._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.SwordWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_finisherPool, physicsManager2._destructiblesGroup, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.SwordWeapon>)+390]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_finisherPool, core4.Enemies, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0310;
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
			Timer retaliationTimer = Timers.Register(1.5000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_retaliationTimer = retaliationTimer;
			FireInternal(isRetaliatory: true, skipTriggers: true);
		}
	}

	protected virtual void FireInternal(bool isRetaliatory = false, bool skipTriggers = false)
	{
		//IL_01a6: Expected I4, but got I8
		//IL_0086: Expected I, but got O
		//IL_02a9: Expected F4, but got I4
		//IL_02c1: Expected F4, but got I4
		//IL_018e: Expected I, but got O
		//IL_02dc: Invalid comparison between O and F4
		//IL_025e: Expected F4, but got I4
		//IL_0276: Expected F4, but got I4
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_04f8: Invalid comparison between O and F4
		//IL_0205: Expected O, but got I4
		//IL_0523: Expected F4, but got O
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_03be: Expected F4, but got I4
		//IL_0487: Expected I, but got O
		//IL_0372: Expected F4, but got I4
		//IL_0389: Expected F4, but got I4
		//IL_04b1: Expected O, but got I4
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals23._003C_003E4__this = this;
		CS_0024_003C_003E8__locals23.isRetaliatory = isRetaliatory;
		if (((Equipment)this)._003CLevel_003Ek__BackingField >= 5 || _canDoFinisher)
		{
			int firingCounter = _firingCounter + 1;
			_firingCounter = firingCounter;
		}
		float num = base.PAmount();
		CS_0024_003C_003E8__locals23.volume = _firingCounter;
		object obj = default(object);
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (_firingCounter == _maxFiringCounter)
		{
			nint num2 = (nint)this;
			float num3 = base.PAmount();
			float num4 = (float)obj - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			int finisherIndex = default(int);
			CS_0024_003C_003E8__locals23.finisherIndex = finisherIndex;
			if (_meleeAnimEvent != null)
			{
				_meleeAnimEvent.Cancel();
			}
			WeaponData currentWeaponData = _currentWeaponData;
			Action onComplete = delegate
			{
				SwordWeapon swordWeapon = CS_0024_003C_003E8__locals23._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)swordWeapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)swordWeapon)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
				{
					SwordWeapon swordWeapon2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
					((Equipment)swordWeapon2)._003COwner_003Ek__BackingField.OnMeleeAttackAnim();
				}
			};
			float num5 = (float)CS_0024_003C_003E8__locals23.finisherIndex * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float num6 = num5 - 280f;
			float duration = num6 * 0.001f;
			Timer meleeAnimEvent = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_meleeAnimEvent = meleeAnimEvent;
			nint num7 = unchecked((nint)null);
		}
		else
		{
			CS_0024_003C_003E8__locals23.finisherIndex = -1;
		}
		if (_firingCounter >= _maxFiringCounter)
		{
			_firingCounter = 0;
		}
		Vector2 vector = default(Vector2);
		Vector2 vector2;
		if (CS_0024_003C_003E8__locals23.finisherIndex <= 0 && CS_0024_003C_003E8__locals23.finisherIndex != -1)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = FireOneFinisherProjectile(vector, 0, _targetTransform, (BulletPool)flag);
			vector2 = vector;
		}
		else if (!CS_0024_003C_003E8__locals23.isRetaliatory)
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num8 = CS_0024_003C_003E8__locals23.volume;
			Projectile projectile2 = FireOneProjectile(vector, 0, CS_0024_003C_003E8__locals23.volume);
			vector2 = vector;
		}
		else
		{
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num8 = CS_0024_003C_003E8__locals23.volume;
			Projectile projectile3 = FireOneRetaliatoryProjectile(vector, 0, CS_0024_003C_003E8__locals23.volume);
			vector2 = vector;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			int num9 = 1;
			bool flag2;
			do
			{
				WeaponData currentWeaponData2 = _currentWeaponData;
				object obj2 = num9 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj2 <= 0)
				{
					if (!CS_0024_003C_003E8__locals23.isRetaliatory)
					{
						float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						float num8 = CS_0024_003C_003E8__locals23.volume;
						Projectile projectile4 = FireOneProjectile(vector, num9, CS_0024_003C_003E8__locals23.volume);
					}
					else
					{
						float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						Projectile projectile5 = FireOneRetaliatoryProjectile(vector, num9, CS_0024_003C_003E8__locals23.volume);
					}
				}
				else
				{
					_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass19_1();
					CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals23;
					CS_0024_003C_003E8__locals32.i = num9;
					WeaponData currentWeaponData3 = _currentWeaponData;
					Action onComplete2 = delegate
					{
						//IL_01c6: Expected F4, but got I4
						//IL_0172: Expected F4, but got I4
						_003C_003Ec__DisplayClass19_0 obj4 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1;
						SwordWeapon swordWeapon = obj4._003C_003E4__this;
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)swordWeapon)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)swordWeapon)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
						{
							_003C_003Ec__DisplayClass19_0 obj5 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1;
							Vector2 pos = default(Vector2);
							if (obj5.finisherIndex == CS_0024_003C_003E8__locals32.i)
							{
								SwordWeapon swordWeapon2 = obj5._003C_003E4__this;
								float2 position6 = ((Equipment)swordWeapon2)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass19_0 obj6 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1;
								SwordWeapon swordWeapon3 = obj6._003C_003E4__this;
								BulletPool pool = default(BulletPool);
								Projectile projectile6 = swordWeapon2.FireOneFinisherProjectile(pos, CS_0024_003C_003E8__locals32.i, swordWeapon3._targetTransform, pool);
							}
							else if (!obj5.isRetaliatory)
							{
								SwordWeapon swordWeapon4 = obj5._003C_003E4__this;
								float2 position7 = ((Equipment)swordWeapon4)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass19_0 obj7 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1;
								Projectile projectile7 = swordWeapon4.FireOneProjectile(pos, CS_0024_003C_003E8__locals32.i, obj7.volume);
							}
							else
							{
								SwordWeapon swordWeapon5 = obj5._003C_003E4__this;
								float2 position8 = ((Equipment)swordWeapon5)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass19_0 obj8 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1;
								Projectile projectile8 = swordWeapon5.FireOneRetaliatoryProjectile(pos, CS_0024_003C_003E8__locals32.i, obj8.volume);
							}
						}
					};
					float num10 = (float)num9 * currentWeaponData3._003CrepeatInterval_003Ek__BackingField;
					float duration2 = num10 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					nint num7 = unchecked((nint)null);
				}
				num9++;
				flag2 = (nint)obj > num9;
				vector2 = (Vector2)num9;
			}
			while (flag2);
		}
		float num11 = base.PInterval();
		float num12 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num12 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num13 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		bool flag3 = default(bool);
		if (!flag3)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public Projectile FireOneProjectile(Vector2 pos, int index, float volume)
	{
		//IL_0047: Expected I, but got O
		//IL_0055: Expected I, but got O
		//IL_0065: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if (_projectilePool != null)
		{
			float2 pos2 = default(float2);
			projectile = _projectilePool.SpawnAt(pos2, this, index);
			bool flag = (object)projectile == null;
			projectile2 = null;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(SwordProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordProjectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v21+FFFFFFF8+v86 @ rax_v17*8]");
					if (0 == (nint)typeof(SwordProjectile))
					{
						obj3 = 1;
						goto IL_0164;
					}
				}
				obj3 = 0;
				goto IL_0164;
			}
			goto IL_018b;
		}
		return (Projectile)(object)new NullReferenceException();
		IL_0164:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_018b;
		IL_018b:
		if ((object)projectile2 == null || ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
		}
		return projectile2;
	}

	private Projectile FireOneRetaliatoryProjectile(Vector2 pos, int index, float volume)
	{
		//IL_0070: Expected I, but got O
		//IL_007e: Expected I, but got O
		//IL_008e: Expected O, but got I
		//IL_010e: Expected O, but got I4
		//IL_00ca: Expected O, but got I
		//IL_0100: Expected O, but got I4
		Debug.Log("FireOneRetaliatoryProjectile");
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if (_retaliationPool != null)
		{
			float2 pos2 = default(float2);
			projectile = _retaliationPool.SpawnAt(pos2, this, index);
			bool flag = (object)projectile == null;
			projectile2 = null;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(SwordProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordProjectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v23+FFFFFFF8+v108 @ rax_v19*8]");
					if (0 == (nint)typeof(SwordProjectile))
					{
						obj3 = 1;
						goto IL_0173;
					}
				}
				obj3 = 0;
				goto IL_0173;
			}
			goto IL_019a;
		}
		return (Projectile)(object)new NullReferenceException();
		IL_0173:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_019a;
		IL_019a:
		if ((object)projectile2 == null || ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
		}
		return projectile2;
	}

	private Projectile FireOneFinisherProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0047: Expected I, but got O
		//IL_0055: Expected I, but got O
		//IL_0065: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		Projectile projectile;
		Projectile result;
		object obj3;
		if (_finisherPool != null)
		{
			float2 pos2 = default(float2);
			projectile = _finisherPool.SpawnAt(pos2, this, index);
			bool flag = (object)projectile == null;
			result = null;
			if (flag)
			{
				goto IL_0124;
			}
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(SwordFinisherProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordFinisherProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordFinisherProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v10+FFFFFFF8+v80 @ rax_v6*8]");
				if (0 == (nint)typeof(SwordFinisherProjectile))
				{
					obj3 = 1;
					goto IL_0129;
				}
			}
			obj3 = 0;
			goto IL_0129;
		}
		return (Projectile)(object)new NullReferenceException();
		IL_0129:
		bool flag2 = obj3 == null;
		result = null;
		if (!flag2)
		{
			result = projectile;
		}
		goto IL_0124;
		IL_0124:
		return result;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		if (base._003CCanCrit_003Ek__BackingField)
		{
			base.StandardCritical(second, first);
			return false;
		}
		return base.OnBulletOverlapsEnemy(context, second, first);
	}

	private void _003COnPlayerHit_003Eb__18_0()
	{
		_canRetaliate = true;
	}
}
