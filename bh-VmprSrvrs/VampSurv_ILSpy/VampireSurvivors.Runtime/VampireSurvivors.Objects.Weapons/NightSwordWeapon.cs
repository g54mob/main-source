using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class NightSwordWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int localIndex;

		public NightSwordWeapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							NightSwordWeapon nightSwordWeapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public float2 pos2;

		public int indexCopy;

		public NightSwordWeapon _003C_003E4__this;

		internal void _003CExplodeOnPlayer_003Eb__1()
		{
			float2 pos = default(float2);
			Projectile projectile = _003C_003E4__this.SpawnExplosionAt(pos, indexCopy, 1, 0f);
		}
	}

	public int _FireCounter;

	public int[] _FireAngles = new int[6] { 20, -20, -70, 30, -30, 70 };

	public int[] _FireX = new int[6] { -16, 16, 0, 16, -16, 0 };

	private bool _canExplode;

	public bool _CanFinish;

	private Timer _expodeTimer;

	private float _retaliationDelay = 600f;

	private bool _removedFiringTimer;

	public float _Volume = 1f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
		((NightSwordWeapon)(object)action).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((NightSwordWeapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action);
		Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
		((NightSwordWeapon)(object)action2).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
		((NightSwordWeapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action2);
		_canExplode = true;
		_explosionType = WeaponType.NIGHTSWORD;
		base._003CCanCrit_003Ek__BackingField = false;
	}

	public void SetAsRetaliatoryOnly()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		_removedFiringTimer = true;
		_retaliationDelay = 1000f;
	}

	public override void ResetFiringTimer()
	{
		if (!_removedFiringTimer)
		{
			base.ResetFiringTimer();
		}
		else if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override float PPower()
	{
		float num = base.PPower();
		float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
		return num + num;
	}

	public override bool LevelUp()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_039b: Expected O, but got F4
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_015b: Invalid comparison between O and F4
		//IL_016c: Expected F4, but got O
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_033d: Invalid comparison between O and F4
		//IL_018d: Invalid comparison between O and F4
		//IL_019e: Expected F4, but got O
		//IL_01b5: Expected O, but got I4
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_023f: Expected I4, but got O
		//IL_0209: Expected I4, but got O
		//IL_0215: Expected F4, but got O
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_02f0: Invalid comparison between F4 and O
		//IL_011e->IL011e: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL011e: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		List<EnemyController> list = Closest(((Equipment)this)._003COwner_003Ek__BackingField, core.Enemies);
		if (list._size <= 1)
		{
			if (list._size != 0)
			{
				bool flag = list._size <= 0;
				EnemyController[] items = list._items;
				Transform targetTransform = items[0].transform;
				_targetTransform = targetTransform;
			}
			else
			{
				_targetTransform = null;
			}
		}
		else
		{
			object obj = UnityEngine.Random.value;
			object obj3 = default(object);
			object obj2 = list._size * obj3;
			float num = (float)obj2 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj5 = default(object);
			object obj4 = list._size - obj5;
			object obj6 = obj4 - 1;
			bool flag2 = (nint)obj6 >= list._size;
			EnemyController[] items2 = list._items;
			object obj7 = obj4 - 1;
			Transform targetTransform2 = items2[obj7].transform;
			_targetTransform = targetTransform2;
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num2 = base.PAmount();
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num3 = (float)vector;
		if (!flag3)
		{
			float num4 = base.PAmount();
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num3 = (float)vector;
			if (!flag4)
			{
				Action<float> action = (Action<float>)1;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj8 = action * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj8 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Projectile projectile2 = base.FireOneProjectile(playerPos, (int)action, _targetTransform);
						num3 = (float)playerPos;
					}
					else
					{
						_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass14_0();
						CS_0024_003C_003E8__locals8._003C_003E4__this = this;
						CS_0024_003C_003E8__locals8.localIndex = (int)action;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_012f: Expected O, but got I4
							//IL_00b4: Expected O, but got I
							//IL_00e9: Expected I, but got O
							//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj10 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj10 == null)
									{
										return;
									}
									GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
											float2 position2 = ((ArcadeSprite)0).position;
											NightSwordWeapon nightSwordWeapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
											{
												nint num10 = (nint)gameObject2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num5 = (float)action * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num3 = num5 * 0.001f;
						Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					action = (Action<float>)(action + 1);
					float num6 = base.PAmount();
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<Action<float>, UIntPtr>(ref action));
			}
		}
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj9 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = num3;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public List<EnemyController> Closest(VampireSurvivors.Objects.Characters.CharacterController source, PhysicsGroup targets)
	{
		List<EnemyController> result = new List<EnemyController>();
		GameManager core = GM.Core;
		PhysicsGroup enemies = core.Enemies;
		float num = 3.4028235E+38f;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		return result;
	}

	public override void Cleanup()
	{
		Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
		((NightSwordWeapon)(object)action).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((NightSwordWeapon)(object)_signalBus).ExplodeOnPlayerDamage((GameplaySignals.CharacterReceivedDamageSignal)action);
		Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
		((NightSwordWeapon)(object)action2).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)this);
		((NightSwordWeapon)(object)_signalBus).ExplodeOnPlayerShield((GameplaySignals.CharacterLostShieldSignal)action2);
		base.Cleanup();
	}

	private void ExplodeOnPlayerDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
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
		ExplodeOnPlayer();
	}

	private void ExplodeOnPlayerShield(GameplaySignals.CharacterLostShieldSignal signal)
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
		ExplodeOnPlayer();
	}

	private unsafe void ExplodeOnPlayer()
	{
		//IL_020e: Expected I, but got O
		//IL_0224: Expected O, but got I
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_029b: Expected I, but got O
		//IL_0385: Expected O, but got I4
		//IL_039c: Expected I, but got I8
		//IL_0284: Expected I, but got I8
		//IL_047c->IL02ad: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL02ad: Incompatible stack heights: 1 vs 0
		//IL_041a->IL041f: Incompatible stack heights: 1 vs 0
		//IL_041f->IL0445: Incompatible stack heights: 1 vs 0
		if (!_canExplode)
		{
			return;
		}
		_canExplode = false;
		if (_expodeTimer != null)
		{
			_expodeTimer.Cancel();
		}
		float num = base.PInterval();
		float num2 = default(float);
		bool flag = num2 > _retaliationDelay;
		float num3 = num2;
		if (!flag)
		{
			num3 = _retaliationDelay;
		}
		Action onComplete = delegate
		{
			_canExplode = true;
		};
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expodeTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expodeTimer = expodeTimer;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = SpawnExplosionAt(position, 0, 1, 0f);
			bool flag2 = true;
			float num4 = 1f;
			while (true)
			{
				_003C_003Ec__DisplayClass19_0 obj = new _003C_003Ec__DisplayClass19_0();
				if (obj == null)
				{
					break;
				}
				obj._003C_003E4__this = this;
				obj.indexCopy = (flag2 ? 1 : 0);
				ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform arcadeTransform = body._transform;
					if (body._transform == null)
					{
						break;
					}
					arcadeTransform.position = ret;
				}
				obj.pos2 = ret;
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData == null)
				{
					break;
				}
				Action action = null;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r10_v7 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_0._003CExplodeOnPlayer_003Eb__1);
				((Delegate)action).m_target = obj;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r10_v7 (Il2CppMethodInfo)+4C]");
				object obj2 = (nint)0 >> 4;
				object obj3 = obj2 & 1;
				nint num6;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r10_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num6 = unchecked((nint)6447293664L);
						goto IL_037c;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num6 = ((Delegate)action).method_ptr;
				goto IL_037c;
				IL_037c:
				object obj4 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float num7 = (float)(flag2 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				num4 = num7 * 0.001f;
				Timer timer = Timers.Register(num4, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				if ((flag2 ? 1 : 0) >= 6)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_00f4: Expected I, but got O
		//IL_020c: Expected I, but got O
		if (_secondaryPool != null)
		{
			goto IL_0266;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(_explosionType);
			BulletPool secondaryPool = new BulletPool(projectilePrefab);
			_secondaryPool = secondaryPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					ArcadePhysics physics = s_scene.physics;
					if ((object)s_scene.physics != null)
					{
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+390]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(_secondaryPool, core.Enemies, collideCallback, processCallback, callbackContext);
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										ArcadePhysics physics2 = s_scene2.physics;
										if ((object)s_scene2.physics != null)
										{
											GameManager core2 = GM.Core;
											if ((object)GM.Core != null)
											{
												PhysicsManager physicsManager = core2._physicsManager;
												if (core2._physicsManager != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num2 = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(_secondaryPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
														goto IL_0266;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0313;
		IL_0313:
		return (Projectile)(object)new NullReferenceException();
		IL_0266:
		if (_secondaryPool != null)
		{
			Projectile projectile = _secondaryPool.SpawnAt(pos, this, enemiesHit);
			if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
			{
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
				{
					goto IL_0313;
				}
				Transform target = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				projectile.SetTarget(target);
			}
			return projectile;
		}
		goto IL_0313;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02c1: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						return false;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = PPower();
									float damage = default(float);
									base.DealDamage(component, damage);
									if (component._003CIsDead_003Ek__BackingField)
									{
										float value = UnityEngine.Random.value;
										WeaponData currentWeaponData = _currentWeaponData;
										if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
										{
											float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
											float num3 = value * currentWeaponData._003Cchance_003Ek__BackingField;
											if (!(num3 > value))
											{
												goto IL_02de;
											}
											Transform transform = component.transform;
											if ((object)transform != null)
											{
												Vector3 position = transform.position;
												if ((object)GM.Core != null && (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.LITTLEHEART)))
												{
													Vector2 pos = default(Vector2);
													Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
													if ((object)pickup != null)
													{
														pickup.GoToLowestHealthPlayer();
														pickup.Time = 1f;
														goto IL_02de;
													}
												}
											}
										}
										goto IL_02b3;
									}
								}
								goto IL_02de;
							}
						}
					}
				}
			}
		}
		goto IL_02b3;
		IL_02de:
		return true;
		IL_02b3:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected override bool OnBulletOverlapsEnemyRetaliation(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_046f: Expected I4, but got O
		//IL_01ff: Invalid comparison between F4 and I4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						return false;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (component2.HasAlreadyHitObject(component))
								{
									goto IL_048c;
								}
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									float num = ((Equipment)this)._003COwner_003Ek__BackingField.PArmor();
									object obj = default(object);
									float num4;
									float num5;
									if ((nint)obj > 0)
									{
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											goto IL_0461;
										}
										float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PArmor();
										float num3 = (float)obj * 0.1f;
										num4 = num3 + 1f;
										num5 = 1f;
									}
									else
									{
										num4 = 1f;
										num5 = 1f;
									}
									float num6 = PPower();
									float num7 = (float)obj * num4;
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
									{
										float num8 = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
										float num9 = (float)obj - num5;
										float num10 = num9 + num9;
										if (num10 > 0f)
										{
											float num11 = num10 + num5;
											num7 *= num11;
										}
										base.DealDamage(component, num7);
										GameManager core = GM.Core;
										if ((object)GM.Core != null)
										{
											ArcanaManager arcanaManager = core._arcanaManager;
											if (core._arcanaManager != null)
											{
												if (arcanaManager._003CHasDivineBloodline_003Ek__BackingField)
												{
													if (!component._003CIsDead_003Ek__BackingField)
													{
														goto IL_048c;
													}
													GameManager core2 = GM.Core;
													core2._arcanaManager.IncreaseBloodlineBonus(((Equipment)this)._003COwner_003Ek__BackingField);
												}
												if (!component._003CIsDead_003Ek__BackingField)
												{
													goto IL_048c;
												}
												float value = UnityEngine.Random.value;
												WeaponData currentWeaponData = _currentWeaponData;
												if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
												{
													float num12 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
													float num13 = value * currentWeaponData._003Cchance_003Ek__BackingField;
													if (!(num13 > value))
													{
														goto IL_048c;
													}
													Transform transform = component.transform;
													if ((object)transform != null)
													{
														Vector3 position = transform.position;
														if ((object)GM.Core != null && (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.LITTLEHEART)))
														{
															Vector2 pos = default(Vector2);
															Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
															if ((object)pickup != null)
															{
																pickup.GoToLowestHealthPlayer();
																pickup.Time = 1f;
																goto IL_048c;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0461;
		IL_0461:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_048c:
		return true;
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

	private void _003CExplodeOnPlayer_003Eb__19_0()
	{
		_canExplode = true;
	}
}
