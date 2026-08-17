using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
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

public class TP_Acid1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public float __area;

		public Vector2 pos;

		public float __repeatInterval;

		public TP_Acid1_Weapon _003C_003E4__this;

		public float __amount;

		public Action _003C_003E9__0;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_01ae: Invalid comparison between F4 and I4
			//IL_0030: Expected O, but got I
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_008c: Expected O, but got I8
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Expected O, but got Unknown
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_018f: Invalid comparison between F4 and I4
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass23_1();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj = num ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj2 = 0 & obj;
				bool flag2 = (nint)obj2 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag3 = (nint)0 < (nint)0;
				CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = this;
				object obj3 = (flag ? 1 : 0) & 0x80000007L;
				if (flag3 != flag2)
				{
					object obj4 = obj3 - 1;
					object obj5 = obj4 | -8;
					obj3 = obj5 + 1;
				}
				object obj6 = obj3 * __area;
				Vector2 _pos = (Vector2)(obj6 + (object)pos);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Acid1_Weapon+<>c__DisplayClass23_0)+18]");
				_ = 0;
				CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
				CS_0024_003C_003E8__locals8.__pos = _pos;
				object obj7 = flag * __repeatInterval;
				if ((nint)obj7 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Acid1_Weapon tP_Acid1_Weapon = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_0160: Expected O, but got I4
						//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass23_0 obj8 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
						{
							GameObject gameObject = obj8._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj9 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj9 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass23_0 obj10 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Acid1_Weapon tP_Acid1_Weapon2 = obj10._003C_003E4__this;
									if ((object)obj10._003C_003E4__this != null && (object)obj10._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj10._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals8.localIndex, tP_Acid1_Weapon2._targetTransform);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num2 = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Acid1_Weapon._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_1
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_0160: Expected O, but got I4
			//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass23_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass23_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Acid1_Weapon tP_Acid1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Acid1_Weapon._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private bool _003CCanFireNormally_003Ek__BackingField = true;

	private bool _initialisedParticles;

	private float _cursorAngle;

	private float _angleUnit = 0.0174533f;

	private float _targetAngle = (float)Math.PI / 2f;

	private float _mul = 333.33334f;

	private bool _cooldownAffectedByMovement;

	public PhaserSprite _cursor;

	public PhaserSprite GeminiCursor;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_ACID1_COUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual float PlayerFacing => 1f;

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
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Acid15");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(2);
		GeminiCursor = _cursor;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.7f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0127: Expected I, but got O
		//IL_0181: Expected I, but got O
		//IL_01f1: Expected F4, but got I4
		//IL_01c0: Expected F4, but got I4
		//IL_02eb: Expected O, but got Ref
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = base.PInterval();
		if (_cooldownAffectedByMovement)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = frameWalk * 100f;
			float num4 = deltaTime2 * 1000f;
			float num5 = num4 / _mul;
			float num6 = num5 * num3;
			float num7 = num6 + base._003CTotalTime_003Ek__BackingField;
			base._003CTotalTime_003Ek__BackingField = num7;
		}
		if (!((base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
		if (IsPrimaryWeapon)
		{
			staticTotalTime = base._003CTotalTime_003Ek__BackingField;
		}
		float num8 = base._003CTotalTime_003Ek__BackingField * 0.85f;
		float num9 = num8 / deltaTime;
		float alpha = num9 + 0.15f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		nint num10 = (nint)typeof(ArcadePhysics);
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v18 (ArcadeSprite)+230]");
		float num11;
		if ((nint)0 <= (nint)0)
		{
			num11 = _cursorAngle;
		}
		else
		{
			bool flipX = arcadeSprite.flipX;
			nint num12 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid1_Weapon>)+5D0]");
			num10 = 0;
			if (!flipX)
			{
				if (IsPrimaryWeapon)
				{
					goto IL_01f6;
				}
				num11 = 0f;
			}
			else
			{
				if (!IsPrimaryWeapon)
				{
					goto IL_01f6;
				}
				num11 = 0f;
			}
		}
		goto IL_038e;
		IL_01f6:
		num11 = (float)Math.PI;
		goto IL_038e;
		IL_038e:
		_targetAngle = num11;
		_angleUnit = 0.000872665f;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num13 = deltaTime3 * 1000f;
		float num14 = num13 * 0.000872665f;
		float num15;
		if (!(num11 > _cursorAngle))
		{
			num15 = _cursorAngle - num14;
			if (num15 < num11)
			{
				num15 = num11;
			}
		}
		else
		{
			float num16 = num14 + _cursorAngle;
			bool flag = !(num16 > num11);
			num15 = num16;
			if (!flag)
			{
				num15 = num11;
			}
		}
		_cursorAngle = num15;
		float num17 = num15 + (float)Math.PI;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserSprite phaserSprite2 = _cursor.setPosition(position);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
		Transform transform = _cursor.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
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
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Invalid comparison between O and F4
		//IL_0087: Expected F4, but got O
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (IsPrimaryWeapon)
		{
			Fire_FireCounter(skipTriggers);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		//IL_00a9: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals21.pos = pos;
		CS_0024_003C_003E8__locals21._003C_003E4__this = this;
		float num = base.PAmount();
		CS_0024_003C_003E8__locals21.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num3 = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		CS_0024_003C_003E8__locals21.__area = 0.08f;
		float playerFacing = PlayerFacing;
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		object obj = (flipX ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		float num4 = (float)obj3 * num3;
		float _area = num4 * 0.08f;
		CS_0024_003C_003E8__locals21.__area = _area;
		float num5 = base.PSpeedRepeatInterval();
		CS_0024_003C_003E8__locals21.__repeatInterval = num3;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num6 = default(int);
		DisplayCursorVFX(num6, hitBoxDelay2);
		if (num6 <= 0)
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
			WeaponData currentWeaponData = _currentWeaponData;
			float num7 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num8);
			Action onComplete = CS_0024_003C_003E8__locals21._003C_003E9__0;
			if (CS_0024_003C_003E8__locals21._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals21._003C_003E9__0 = delegate
				{
					//IL_01ae: Invalid comparison between F4 and I4
					//IL_0030: Expected O, but got I
					//IL_0040: Unknown result type (might be due to invalid IL or missing references)
					//IL_0045: Expected O, but got Unknown
					//IL_008c: Expected O, but got I8
					//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
					//IL_01d4: Expected O, but got Unknown
					//IL_0214: Unknown result type (might be due to invalid IL or missing references)
					//IL_0219: Expected O, but got Unknown
					//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b6: Expected O, but got Unknown
					//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c4: Expected O, but got Unknown
					//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d2: Expected O, but got Unknown
					//IL_018f: Invalid comparison between F4 and I4
					if (CS_0024_003C_003E8__locals21.__amount > 0f)
					{
						bool flag2 = false;
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						do
						{
							_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass23_1();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							object obj4 = num11 ^ 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							object obj5 = 0 & obj4;
							bool flag3 = (nint)obj5 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag4 = (nint)0 < (nint)0;
							CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals21;
							object obj6 = (flag2 ? 1 : 0) & 0x80000007L;
							if (flag4 != flag3)
							{
								object obj7 = obj6 - 1;
								object obj8 = obj7 | -8;
								obj6 = obj8 + 1;
							}
							object obj9 = obj6 * CS_0024_003C_003E8__locals21.__area;
							Vector2 _pos = (Vector2)(obj9 + (object)CS_0024_003C_003E8__locals21.pos);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Acid1_Weapon+<>c__DisplayClass23_0)+18]");
							_ = 0;
							CS_0024_003C_003E8__locals26.localIndex = (flag2 ? 1 : 0);
							CS_0024_003C_003E8__locals26.__pos = _pos;
							object obj10 = flag2 * CS_0024_003C_003E8__locals21.__repeatInterval;
							if ((nint)obj10 <= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							}
							else
							{
								TP_Acid1_Weapon tP_Acid1_Weapon = CS_0024_003C_003E8__locals21._003C_003E4__this;
								Action onComplete2 = delegate
								{
									//IL_0160: Expected O, but got I4
									//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
									//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
									//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass23_0 obj11 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null && (object)obj11._003C_003E4__this != null)
									{
										GameObject gameObject = obj11._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj12 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass23_0 obj13 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Acid1_Weapon tP_Acid1_Weapon2 = obj13._003C_003E4__this;
												if ((object)obj13._003C_003E4__this != null && (object)obj13._003C_003E4__this != null)
												{
													Vector2 pos2 = default(Vector2);
													Projectile projectile = obj13._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals26.localIndex, tP_Acid1_Weapon2._targetTransform);
													return;
												}
											}
										}
									}
									throw new NullReferenceException();
								};
								float num12 = (float)(flag2 ? 1 : 0) * CS_0024_003C_003E8__locals21.__repeatInterval;
								float duration2 = num12 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								tP_Acid1_Weapon._lastShotTimer = lastShotTimer;
							}
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
						}
						while (CS_0024_003C_003E8__locals21.__amount > (float)(flag2 ? 1 : 0));
					}
				});
			}
			float num9 = (float)(flag ? 1 : 0) * num7;
			float num10 = num9 + 1f;
			float duration = num10 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < num6);
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				_counterWeapon = weaponByType;
				_counterWeapon.Cleanup();
				GameObject gameObject = _counterWeapon.gameObject;
				gameObject.SetActive(value: true);
			}
		}
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
		//IL_0192: Expected I, but got O
		//IL_01dd: Expected I, but got O
		//IL_01ed: Expected O, but got I
		//IL_0229: Expected O, but got I
		//IL_0266: Expected O, but got I
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_0349: Expected O, but got I
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
		while (true)
		{
			nint num = (nint)weapon;
			if (((Equipment)weapon)._003CLevel_003Ek__BackingField >= ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				break;
			}
			bool flag = weapon.LevelUp(skipFire: true);
		}
		nint num2 = (nint)typeof(TP_Acid1_WeaponCounter);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid1_WeaponCounter>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid1_WeaponCounter>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v30+FFFFFFF8+v127 @ rax_v29*8]");
			if (0 == (nint)typeof(TP_Acid1_WeaponCounter))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Acid1_WeaponCounter>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v30+FFFFFFF8+v549 @ rcx_v25*8]");
				object obj6 = 0 - typeof(TP_Acid1_WeaponCounter);
				bool flag2 = obj6 == null;
				bool flag3 = !flag2;
				Weapon weapon2 = null;
				if (!flag3)
				{
					weapon2 = weapon;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rsi_v5 (VampireSurvivors.Objects.Weapons.Weapon)+170]");
				GeminiCursor = (PhaserSprite)0;
				GM.Core.SetSeenWeapon(_counterWeaponType);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0113: Expected O, but got Ref
		//IL_016a->IL0114: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0114: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0114: Incompatible stack heights: 1 vs 0
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
}
