using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Fire1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public float __area;

		public Vector2 pos;

		public TP_Fire1_Weapon _003C_003E4__this;

		public float __repeatInterval;

		public float __amount;
	}

	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public int localI;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0015: Expected O, but got I4
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_02e2: Invalid comparison between F4 and I4
			//IL_029d: Expected O, but got F4
			//IL_00ed: Expected O, but got F4
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_0163: Expected I, but got O
			//IL_0250: Expected I, but got O
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals1;
			object obj2 = localI + 1;
			_003C_003Ec__DisplayClass22_0 obj3 = CS_0024_003C_003E8__locals1;
			object obj4 = obj2 * obj.__area;
			int num = 0;
			int num2 = 0;
			Action<float> action2 = default(Action<float>);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (obj3.__amount > (float)num2)
			{
				_003C_003Ec__DisplayClass22_2 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass22_2();
				CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 = this;
				object obj5 = UnityEngine.Random.value;
				_003C_003Ec__DisplayClass22_0 obj6 = CS_0024_003C_003E8__locals1;
				float num3 = obj3.__amount + obj3.__amount;
				float num4 = num3 * (float)Math.PI;
				TP_Fire1_Weapon tP_Fire1_Weapon = obj6._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num5 = num4 * tP_Fire1_Weapon.GroundRadiusX;
				float num6 = num5 * (float)obj4;
				float num7 = num6 + (float)obj6.pos;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num8 = num4 * tP_Fire1_Weapon.GroundRadiusY;
				CS_0024_003C_003E8__locals9.__pos = (Vector2)num7;
				float num9 = num8 * (float)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r12_v5 (VampireSurvivors.Objects.Weapons.TP_Fire1_Weapon+<>c__DisplayClass22_0)+18]");
				float num10 = 0f - num9;
				_003C_003Ec__DisplayClass22_0 obj7 = CS_0024_003C_003E8__locals1;
				object obj8 = num * obj7.__repeatInterval;
				if ((nint)obj8 <= 0)
				{
					nint num11 = (nint)obj7._003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					bool flag = (byte)num != 0;
					Action<float> action = action2;
				}
				else
				{
					CS_0024_003C_003E8__locals9.localIndex = num;
					_003C_003Ec__DisplayClass22_0 obj9 = CS_0024_003C_003E8__locals1;
					_003C_003Ec__DisplayClass22_0 obj10 = CS_0024_003C_003E8__locals1;
					TP_Fire1_Weapon tP_Fire1_Weapon2 = obj9._003C_003E4__this;
					Action action3 = delegate
					{
						//IL_01ff: Expected O, but got I4
						//IL_00d7->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0106->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0125->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0147->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0176->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0198->IL01c8: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass22_1 obj11 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 != null)
						{
							_003C_003Ec__DisplayClass22_0 obj12 = obj11.CS_0024_003C_003E8__locals1;
							if (obj11.CS_0024_003C_003E8__locals1 != null && (object)obj12._003C_003E4__this != null)
							{
								GameObject gameObject = obj12._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj13 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj13 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass22_1 obj14 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2;
									if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 != null)
									{
										_003C_003Ec__DisplayClass22_0 obj15 = obj14.CS_0024_003C_003E8__locals1;
										if (obj14.CS_0024_003C_003E8__locals1 != null && CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 != null && obj14.CS_0024_003C_003E8__locals1 != null)
										{
											TP_Fire1_Weapon tP_Fire1_Weapon3 = obj15._003C_003E4__this;
											if ((object)obj15._003C_003E4__this != null && (object)obj15._003C_003E4__this != null)
											{
												Vector2 pos = default(Vector2);
												Projectile projectile = obj15._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals9.localIndex, tP_Fire1_Weapon3._targetTransform);
												return;
											}
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num12 = (float)num * obj10.__repeatInterval;
					float duration = num12 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, action3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Fire1_Weapon2._lastShotTimer = lastShotTimer;
					bool flag = false;
					nint num11 = (nint)action3;
					Action<float> action = null;
				}
				obj3 = CS_0024_003C_003E8__locals1;
				num++;
				num2 = num;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_2
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals2;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_01ff: Expected O, but got I4
			//IL_00d7->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0106->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0125->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0147->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0176->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0198->IL01c8: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass22_1 obj = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass22_0 obj2 = obj.CS_0024_003C_003E8__locals1;
				if (obj.CS_0024_003C_003E8__locals1 != null && (object)obj2._003C_003E4__this != null)
				{
					GameObject gameObject = obj2._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj3 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass22_1 obj4 = CS_0024_003C_003E8__locals2;
						if (CS_0024_003C_003E8__locals2 != null)
						{
							_003C_003Ec__DisplayClass22_0 obj5 = obj4.CS_0024_003C_003E8__locals1;
							if (obj4.CS_0024_003C_003E8__locals1 != null && CS_0024_003C_003E8__locals2 != null && obj4.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Fire1_Weapon tP_Fire1_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null && (object)obj5._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Fire1_Weapon._targetTransform);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private bool _003CCanFireNormally_003Ek__BackingField = true;

	private float GroundRadiusX = 0.32f;

	private float GroundRadiusY = 0.08f;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private bool _lockCursor;

	private EnemyController _lockOnTarget;

	private bool _canLockOn;

	private Timer _lockOnTimer;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_FIRE1_COUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual bool IsPrimaryWeapon => true;

	public bool CanFireNormally
	{
		get
		{
			return _003CCanFireNormally_003Ek__BackingField;
		}
		set
		{
			_003CCanFireNormally_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Fire18");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_canLockOn = true;
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		_explosionType = WeaponType.FIREEXPLOSION;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_01cf: Expected O, but got Ref
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon && _003CCanFireNormally_003Ek__BackingField)
			{
				base.Fire();
			}
		}
		if (IsPrimaryWeapon)
		{
			staticTotalTime = base._003CTotalTime_003Ek__BackingField;
		}
		float num3 = base._003CTotalTime_003Ek__BackingField * 0.75f;
		float num4 = num3 / deltaTime;
		float alpha = num4 + 0.25f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		if (!IsPrimaryWeapon)
		{
			return;
		}
		bool flag;
		if (_lockCursor)
		{
			ArcadeSprite lockOnTarget = _lockOnTarget;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v48 (ArcadeSprite)+260]");
			if ((nint)0 == 0)
			{
				float2 position = lockOnTarget.position;
				PhaserSprite phaserSprite2 = _cursor.setPosition(position);
				flag = !_hasCounterSet;
				goto IL_03d1;
			}
			_lockCursor = false;
		}
		GameManager core = GM.Core;
		float2 position2 = _cursor.position;
		object obj = default(object);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true, 0.1618f);
		if ((bool)enemyController && _canLockOn)
		{
			float2 position3 = enemyController.position;
			PhaserSprite phaserSprite3 = _cursor.setPosition(position3);
			_lockCursor = true;
			_lockOnTarget = enemyController;
			flag = !_hasCounterSet;
			goto IL_03d1;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float2 position6 = default(float2);
		if ((object)GM.Core != null)
		{
			float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			if ((object)GM.Core != null)
			{
				PhaserSprite phaserSprite4 = _cursor.setPosition(position6);
				flag = !_hasCounterSet;
				goto IL_03d1;
			}
		}
		throw new NullReferenceException();
		IL_03d1:
		if (!flag)
		{
			float2 position7 = _cursor.position;
			_counterWeapon.OnMirrorData(position6);
		}
	}

	public override void OnMirrorData(Vector2 position)
	{
		//IL_00ba->IL0069: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_cursor != null)
				{
					float2 position2 = default(float2);
					PhaserSprite phaserSprite = _cursor.setPosition(position2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected float CalcRadAngle(float x1, float y1, float x2, float y2)
	{
		float num = x2 - x1;
		object obj = default(object);
		float result = (float)obj - y1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		return result;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00df: Invalid comparison between O and F4
		//IL_010a: Expected F4, but got O
		_lockCursor = false;
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		bool flag = num2 > 1000f;
		float num3 = 1000f;
		if (!flag)
		{
			num3 = num2;
		}
		_canLockOn = false;
		if (_lockOnTimer != null)
		{
			_lockOnTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_canLockOn = true;
		};
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer lockOnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_lockOnTimer = lockOnTimer;
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		float num4 = base.PInterval();
		float num5 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num5 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num6 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (IsPrimaryWeapon)
		{
			Weapon counterWeapon = _counterWeapon;
			if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
			{
				_counterWeapon.Fire(skipTriggers);
			}
		}
	}

	public unsafe void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		//IL_0165: Expected I, but got O
		//IL_017b: Expected O, but got I
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_01f2: Expected I, but got O
		//IL_026c: Expected O, but got I4
		//IL_0283: Expected I, but got I8
		//IL_01db: Expected I, but got I8
		_003C_003Ec__DisplayClass22_0 obj = new _003C_003Ec__DisplayClass22_0();
		obj.pos = pos;
		obj._003C_003E4__this = this;
		float num = base.PAmount();
		obj.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num3 = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num4 = base.PArea();
		int num5 = default(int);
		float _repeatInterval = (obj.__area = num3 / (float)num5);
		float num6 = base.PSpeedRepeatInterval();
		obj.__repeatInterval = _repeatInterval;
		float hitBoxDelay2 = base.HitBoxDelay;
		DisplayCursorVFX(num5, hitBoxDelay2);
		if (num5 <= 0)
		{
			return;
		}
		bool flag = false;
		float num8 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass22_1 obj2 = new _003C_003Ec__DisplayClass22_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localI = (flag ? 1 : 0);
			WeaponData currentWeaponData = _currentWeaponData;
			float num7 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num8);
			Action action = null;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_1._003CFireProjectiles_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num10;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num10 = unchecked((nint)6447293664L);
					goto IL_0263;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num10 = ((Delegate)action).method_ptr;
			goto IL_0263;
			IL_0263:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num11 = (float)(flag ? 1 : 0) * num7;
			float duration = num11 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < num5);
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire(skipTriggers);
		}
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void CheckArcanas()
	{
		//IL_04bd->IL040a: Incompatible stack heights: 1 vs 0
		//IL_04f8->IL0445: Incompatible stack heights: 2 vs 0
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		if ((object)_gameMan != null)
		{
			ArcanaManager arcanaManager = gameMan._arcanaManager;
			if (gameMan._arcanaManager != null)
			{
				List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
				if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							GameManager gameMan2 = _gameMan;
							if ((object)_gameMan != null)
							{
								float heartOfFirePower = base.HeartOfFirePower;
								if (gameMan2._arcanaManager != null)
								{
									float newWeaponPower = default(float);
									gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
									goto IL_011c;
								}
							}
							goto IL_040a;
						}
					}
					goto IL_011c;
				}
			}
		}
		goto IL_040a;
		IL_040a:
		throw new NullReferenceException();
		IL_011c:
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			ArcanaManager arcanaManager2 = core._arcanaManager;
			if (core._arcanaManager != null)
			{
				List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
				if (arcanaManager2._003CActiveArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj2 = default(object);
					if ((nint)obj2 <= -1)
					{
						return;
					}
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController._weaponsManager != null)
					{
						Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
						if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
						{
							return;
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._weaponsFacade != null)
						{
							bool allowDuplicates = default(bool);
							Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
							if ((object)weapon != null)
							{
								while (((Equipment)weapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
								{
									bool flag = weapon.LevelUp(skipFire: true);
								}
								if ((object)GM.Core != null)
								{
									GM.Core.SetSeenWeapon(_counterWeaponType);
									_hasCounterSet = true;
									if ((object)_counterWeapon != null)
									{
										_counterWeapon.Cleanup();
										TP_Fire1_Weapon counterWeapon = (TP_Fire1_Weapon)_counterWeapon;
										if ((object)_counterWeapon != null)
										{
											bool flag2 = ((UnityEngine.Object)counterWeapon).m_CachedPtr == (IntPtr)0;
											IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)counterWeapon).m_CachedPtr);
											GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
											if ((object)gameObject != null)
											{
												bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
												return;
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
		goto IL_040a;
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0112: Expected O, but got Ref
		//IL_0169->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0113: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
			if ((object)pool != null)
			{
				SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
				if ((object)_cursor != null)
				{
					Transform transform = _cursor.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor != null)
						{
							Transform transform2 = _cursor.transform;
							if ((object)transform2 != null)
							{
								Vector3 localEulerAngles = transform2.localEulerAngles;
								if ((object)objectComponent != null)
								{
									object obj = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj), angle, texture, frame, flip);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_lockOnTimer != null)
		{
			_lockOnTimer.Cancel();
		}
	}

	private void _003CFire_003Eb__21_0()
	{
		_canLockOn = true;
	}
}
