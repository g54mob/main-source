using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
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

public class TP_Shield2_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public TP_Shield2_Weapon _003C_003E4__this;

		public Vector2 __pos;

		public BulletPool pool;

		public float anlgeUnit;

		public float _angleOffset;
	}

	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0299: Expected O, but got I4
			//IL_012b: Expected I, but got O
			//IL_0133: Expected I, but got O
			//IL_0143: Expected O, but got I
			//IL_01c3: Expected O, but got I4
			//IL_017f: Expected O, but got I
			//IL_01b5: Expected O, but got I4
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Expected O, but got Unknown
			//IL_0084->IL0239: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL0239: Incompatible stack heights: 1 vs 0
			//IL_00d5->IL0239: Incompatible stack heights: 1 vs 0
			//IL_01f9->IL0239: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass14_0 obj = CS_0024_003C_003E8__locals1;
			TP_Shield2_Meteor_Projectile tP_Shield2_Meteor_Projectile;
			object obj6;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass14_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Shield2_Weapon tP_Shield2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							tP_Shield2_Meteor_Projectile = (TP_Shield2_Meteor_Projectile)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Shield2_Weapon._targetTransform);
							if ((object)tP_Shield2_Meteor_Projectile == null)
							{
								return;
							}
							nint num = (nint)typeof(TP_Shield2_Meteor_Projectile);
							nint num2 = (nint)tP_Shield2_Meteor_Projectile;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+C8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rcx_v20+FFFFFFF8+v405 @ rcx_v14*8]");
								if (0 == (nint)typeof(TP_Shield2_Meteor_Projectile))
								{
									obj6 = 1;
									goto IL_02b6;
								}
							}
							obj6 = 0;
							goto IL_02b6;
						}
					}
				}
			}
			goto IL_0239;
			IL_02b6:
			bool flag2 = obj6 == null;
			TP_Shield2_Meteor_Projectile tP_Shield2_Meteor_Projectile2 = null;
			if (!flag2)
			{
				tP_Shield2_Meteor_Projectile2 = tP_Shield2_Meteor_Projectile;
			}
			if ((object)tP_Shield2_Meteor_Projectile2 != null)
			{
				_003C_003Ec__DisplayClass14_0 obj7 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					object obj8 = localIndex * obj7.anlgeUnit;
					float angleVelocity = (float)obj8 - obj7._angleOffset;
					tP_Shield2_Meteor_Projectile2.SetAngleVelocity(angleVelocity);
					return;
				}
				goto IL_0239;
			}
			return;
			IL_0239:
			throw new NullReferenceException();
		}
	}

	private BulletPool _standardPool;

	private BulletPool _retaliationPool;

	private bool _canRetaliate;

	private Timer _retaliationTimer;

	private float RetaliationDelay = 1500f;

	public int SlotNumber = 1;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((TP_Shield2_Weapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
		((TP_Shield2_Weapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
		((TP_Shield2_Weapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((TP_Shield2_Weapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		_canRetaliate = true;
		((TP_Shield2_Weapon)(object)characterController2.HeldShieldSlots).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		List<Weapon> heldShieldSlots = characterController3.HeldShieldSlots;
		SlotNumber = heldShieldSlots._size;
	}

	private void OnPlayerHit()
	{
		//IL_0048: Expected O, but got I
		if (!_canRetaliate)
		{
			return;
		}
		BulletPool projectilePool = _projectilePool;
		ObjectPool pool = projectilePool._pool;
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj = num - 0;
		if ((nint)obj > 0)
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
			float duration = RetaliationDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer retaliationTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_retaliationTimer = retaliationTimer;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 position2 = default(Vector2);
			FireProjectiles(_retaliationPool, position2, allDirections: true);
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_retaliationPool.Cleanup();
		_standardPool.Cleanup();
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((TP_Shield2_Weapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
			((TP_Shield2_Weapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((TP_Shield2_Weapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((TP_Shield2_Weapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		}
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_retaliationTimer != null)
		{
			_retaliationTimer.Cancel();
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = ((List<object>)(object)characterController.HeldShieldSlots).Remove((object)this);
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
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_SHIELD2_METEORS);
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_retaliationPool, physicsManager._destructiblesGroup, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon>)+390]");
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
		if (_standardPool != null)
		{
			return;
		}
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_SHIELD2_METEORS);
		BulletPool standardPool = new BulletPool(projectilePrefab2);
		_standardPool = standardPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			PhysicsManager physicsManager2 = core3._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_standardPool, physicsManager2._destructiblesGroup, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon>)+350]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_standardPool, core4.Enemies, collideCallback4, processCallback, callbackContext);
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
	}

	public void FireStandardProjectiles(Vector2 position)
	{
		FireProjectiles(_standardPool, position);
	}

	public void FireProjectiles(BulletPool pool, Vector2 position, bool allDirections = false)
	{
		//IL_0045: Expected O, but got I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0066: Expected I, but got O
		//IL_006a: Unsupported input type for neg.
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0437: Invalid comparison between F4 and I4
		//IL_048b: Invalid comparison between F4 and I4
		//IL_0551: Invalid comparison between F4 and I4
		//IL_01b1: Invalid comparison between F4 and I4
		//IL_03ba: Invalid comparison between F4 and I4
		//IL_01e7: Expected F4, but got I
		//IL_01f4: Expected O, but got I4
		//IL_0229: Expected I, but got O
		//IL_0231: Expected I, but got O
		//IL_0241: Expected O, but got I
		//IL_02c1: Expected O, but got I4
		//IL_027d: Expected O, but got I
		//IL_02b3: Expected O, but got I4
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
		obj._003C_003E4__this = this;
		obj.pool = pool;
		if (obj.pool == null)
		{
			obj.pool = _standardPool;
		}
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		object obj2 = (flipX ? 1 : 0) ^ 1;
		object obj3 = obj2 * 2;
		Action action = (Action)(obj3 - 1);
		nint num = (nint)this;
		Action action2 = (Action)(0 - action);
		if ((SlotNumber & 1) != 0)
		{
			action2 = action;
		}
		float num2 = base.PAmount();
		bool flag = !allDirections;
		float num4 = default(float);
		float num3 = num4;
		if (!flag)
		{
			num3 = num4 + num4;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num5 = ((!allDirections) ? ((float)Math.PI / 2f) : ((float)Math.PI));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018746895Eh\"");
		float num6 = ((num3 != 0f) ? (num3 + 1f) : num3);
		float num7 = num5 / num6;
		obj._angleOffset = (float)Math.PI / 4f;
		obj.anlgeUnit = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		bool flag2 = num3 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187468997h\"");
		bool flag3 = false;
		if (!flag2)
		{
			flag3 = true;
		}
		if ((nint)action2 == -1)
		{
			float anlgeUnit = num7 * -1f;
			obj._angleOffset = (float)Math.PI * 3f / 4f;
			obj.anlgeUnit = anlgeUnit;
		}
		Vector2 _pos = default(Vector2);
		obj.__pos = _pos;
		if (!(num3 > 0f))
		{
			return;
		}
		bool flag4 = false;
		float num9 = default(float);
		float num8 = num9;
		TP_Shield2_Meteor_Projectile tP_Shield2_Meteor_Projectile = default(TP_Shield2_Meteor_Projectile);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass14_1();
			CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = obj;
			int localIndex = (flag3 ? 1 : 0) + (flag4 ? 1 : 0);
			CS_0024_003C_003E8__locals13.localIndex = localIndex;
			float num10 = (float)(flag4 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			object obj8;
			if (!(num10 > 0f))
			{
				_003C_003Ec__DisplayClass14_0 obj4 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v14 (VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon+<>c__DisplayClass14_0)+1C]");
				num8 = 0f;
				object obj5 = (flag3 ? 1 : 0) + (flag4 ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if ((object)tP_Shield2_Meteor_Projectile != null)
				{
					nint num11 = (nint)typeof(TP_Shield2_Meteor_Projectile);
					nint num12 = (nint)tP_Shield2_Meteor_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
					if (num13 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+C8]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rcx_v27+FFFFFFF8+v812 @ rcx_v21*8]");
						if (0 == (nint)typeof(TP_Shield2_Meteor_Projectile))
						{
							obj8 = 1;
							goto IL_04d2;
						}
					}
					obj8 = 0;
					goto IL_04d2;
				}
			}
			else
			{
				Action onComplete = delegate
				{
					//IL_0299: Expected O, but got I4
					//IL_012b: Expected I, but got O
					//IL_0133: Expected I, but got O
					//IL_0143: Expected O, but got I
					//IL_01c3: Expected O, but got I4
					//IL_017f: Expected O, but got I
					//IL_01b5: Expected O, but got I4
					//IL_020d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0212: Expected O, but got Unknown
					//IL_0084->IL0239: Incompatible stack heights: 1 vs 0
					//IL_00b3->IL0239: Incompatible stack heights: 1 vs 0
					//IL_00d5->IL0239: Incompatible stack heights: 1 vs 0
					//IL_01f9->IL0239: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass14_0 obj11 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
					TP_Shield2_Meteor_Projectile tP_Shield2_Meteor_Projectile3;
					object obj16;
					if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null && (object)obj11._003C_003E4__this != null)
					{
						GameObject gameObject = obj11._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj12 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass14_0 obj13 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Shield2_Weapon tP_Shield2_Weapon = obj13._003C_003E4__this;
								if ((object)obj13._003C_003E4__this != null && (object)obj13._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									tP_Shield2_Meteor_Projectile3 = (TP_Shield2_Meteor_Projectile)obj13._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals13.localIndex, tP_Shield2_Weapon._targetTransform);
									if ((object)tP_Shield2_Meteor_Projectile3 == null)
									{
										return;
									}
									nint num15 = (nint)typeof(TP_Shield2_Meteor_Projectile);
									nint num16 = (nint)tP_Shield2_Meteor_Projectile3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
									object obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
									nint num17 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+130]");
									if (num17 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Meteor_Projectile>)+C8]");
										object obj15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rcx_v20+FFFFFFF8+v405 @ rcx_v14*8]");
										if (0 == (nint)typeof(TP_Shield2_Meteor_Projectile))
										{
											obj16 = 1;
											goto IL_02b6;
										}
									}
									obj16 = 0;
									goto IL_02b6;
								}
							}
						}
					}
					goto IL_0239;
					IL_02b6:
					bool flag7 = obj16 == null;
					TP_Shield2_Meteor_Projectile tP_Shield2_Meteor_Projectile4 = null;
					if (!flag7)
					{
						tP_Shield2_Meteor_Projectile4 = tP_Shield2_Meteor_Projectile3;
					}
					if ((object)tP_Shield2_Meteor_Projectile4 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass14_0 obj17 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
					{
						object obj18 = CS_0024_003C_003E8__locals13.localIndex * obj17.anlgeUnit;
						float angleVelocity = (float)obj18 - obj17._angleOffset;
						tP_Shield2_Meteor_Projectile4.SetAngleVelocity(angleVelocity);
						return;
					}
					goto IL_0239;
					IL_0239:
					throw new NullReferenceException();
				};
				float num14 = (float)(flag4 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				float duration = num14 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			goto IL_03a4;
			IL_03a4:
			flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
			continue;
			IL_04d2:
			bool flag5 = obj8 == null;
			TP_Shield2_Meteor_Projectile tP_Shield2_Meteor_Projectile2 = null;
			if (!flag5)
			{
				tP_Shield2_Meteor_Projectile2 = tP_Shield2_Meteor_Projectile;
			}
			if ((object)tP_Shield2_Meteor_Projectile2 != null)
			{
				_003C_003Ec__DisplayClass14_0 obj9 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
				object obj10 = CS_0024_003C_003E8__locals13.localIndex * obj9.anlgeUnit;
				num8 = (float)obj10 - obj9._angleOffset;
				tP_Shield2_Meteor_Projectile2.SetAngleVelocity(num8);
			}
			goto IL_03a4;
		}
		while (num3 > (float)(flag4 ? 1 : 0));
	}

	private void _003COnPlayerHit_003Eb__7_0()
	{
		_canRetaliate = true;
	}
}
