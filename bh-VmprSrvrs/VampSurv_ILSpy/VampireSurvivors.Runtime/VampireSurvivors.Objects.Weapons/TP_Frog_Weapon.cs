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

public class TP_Frog_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public TP_Frog_Weapon _003C_003E4__this;

		public Vector2 pos;

		public float __repeatInterval;

		public float __amount;

		public Action _003C_003E9__0;

		internal unsafe void _003CFireProjectiles_003Eb__0()
		{
			//IL_0362: Invalid comparison between F4 and I4
			//IL_002b: Expected I, but got O
			//IL_0052: Expected O, but got I
			//IL_04d1: Expected O, but got F4
			//IL_04ee: Expected O, but got I8
			//IL_03a7: Expected O, but got I
			//IL_0522: Expected O, but got F4
			//IL_052f: Expected O, but got I8
			//IL_00c1: Expected O, but got I4
			//IL_00b3: Expected I, but got I8
			//IL_0426: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Expected O, but got Unknown
			//IL_0109: Expected O, but got I4
			//IL_00fb: Expected I, but got I8
			//IL_030d: Expected I, but got O
			//IL_0151: Expected O, but got I4
			//IL_015f: Expected I, but got O
			//IL_016f: Expected O, but got I
			//IL_0339: Invalid comparison between F4 and I4
			//IL_01ef: Expected O, but got I4
			//IL_0137: Expected I, but got O
			//IL_047d: Expected I, but got O
			//IL_01ab: Expected O, but got I
			//IL_020a: Expected I, but got O
			//IL_01e1: Expected O, but got I4
			//IL_0260: Expected O, but got I4
			//IL_0270: Expected I, but got O
			//IL_0100->IL04fc: Incompatible stack heights: 1 vs 0
			float _amount = __amount;
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool flag4 = default(bool);
			Vector2 vector = default(Vector2);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass15_1();
				CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = this;
				nint num = (nint)typeof(_003C_003Ec__DisplayClass15_1);
				CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj == null)
					{
						break;
					}
					num = unchecked((nint)6573110936L);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v581 @ rax_v18 (should have been resolved before IL gen)");
				object obj2 = UnityEngine.Random.value;
				bool flag2 = 0.5f > 0.25f;
				object obj3 = 4294967295L;
				if (!flag2)
				{
					obj3 = 1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj4 = 0;
				float num2 = (float)obj3 * 0.25f;
				float num3 = num2 + (float)pos;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag3 = obj4 == null;
					num = unchecked((nint)6573110936L);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v703 @ rax_v26 (should have been resolved before IL gen)");
				bool isPrimaryWeapon = _003C_003E4__this.IsPrimaryWeapon;
				CS_0024_003C_003E8__locals8.jumpPos = (Vector2)num3;
				object obj5 = 4294967295L;
				if (!isPrimaryWeapon)
				{
					obj5 = 1;
				}
				float num4 = (float)obj5 * 0.5f;
				float num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Frog_Weapon+<>c__DisplayClass15_0)+1C]");
				float num6 = num5 + 0f;
				object obj6 = flag * __repeatInterval;
				TP_Frog_Weapon tP_Frog_Weapon = _003C_003E4__this;
				bool flag5;
				nint num7;
				object obj9;
				Action<float> action;
				if ((nint)obj6 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if (!flag4)
					{
						flag5 = false;
						num7 = (nint)tP_Frog_Weapon;
						action = (Action<float>)vector;
						goto IL_0490;
					}
					action = (Action<float>)((bool*)(flag4 ? 1 : 0))->m_value;
					nint num8 = (nint)typeof(TP_Frog_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ r8_v7 (System.Action`1<System.Single>)+130]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
					if (num9 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ r8_v7 (System.Action`1<System.Single>)+C8]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rax_v53+FFFFFFF8+v813 @ rax_v49*8]");
						if (0 == (nint)typeof(TP_Frog_Projectile))
						{
							obj9 = 1;
							goto IL_0457;
						}
					}
					obj9 = 0;
					goto IL_0457;
				}
				Action action2 = delegate
				{
					//IL_025c: Expected O, but got I4
					//IL_0108: Expected I, but got O
					//IL_0116: Expected I, but got O
					//IL_0126: Expected O, but got I
					//IL_01a6: Expected O, but got I4
					//IL_0162: Expected O, but got I
					//IL_0198: Expected O, but got I4
					//IL_0084->IL01fc: Incompatible stack heights: 1 vs 0
					//IL_00b3->IL01fc: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass15_0 obj10 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
					TP_Frog_Projectile tP_Frog_Projectile;
					Vector2 destintion = default(Vector2);
					TP_Frog_Projectile tP_Frog_Projectile2;
					object obj15;
					if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
					{
						GameObject gameObject = obj10._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag10 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj11 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass15_0 obj12 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Frog_Weapon tP_Frog_Weapon2 = obj12._003C_003E4__this;
								if ((object)obj12._003C_003E4__this != null)
								{
									tP_Frog_Projectile = (TP_Frog_Projectile)obj12._003C_003E4__this.FireOneProjectile(destintion, CS_0024_003C_003E8__locals8.localIndex, tP_Frog_Weapon2._targetTransform);
									bool flag11 = (object)tP_Frog_Projectile == null;
									tP_Frog_Projectile2 = null;
									if (!flag11)
									{
										nint num12 = (nint)tP_Frog_Projectile;
										nint num13 = (nint)typeof(TP_Frog_Projectile);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
										nint num14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
										if (num14 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+C8]");
											object obj14 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v36+FFFFFFF8+v375 @ rax_v32*8]");
											if (0 == (nint)typeof(TP_Frog_Projectile))
											{
												obj15 = 1;
												goto IL_027e;
											}
										}
										obj15 = 0;
										goto IL_027e;
									}
									goto IL_02a5;
								}
							}
						}
					}
					throw new NullReferenceException();
					IL_027e:
					bool flag12 = obj15 == null;
					tP_Frog_Projectile2 = null;
					if (!flag12)
					{
						tP_Frog_Projectile2 = tP_Frog_Projectile;
					}
					goto IL_02a5;
					IL_02a5:
					if ((object)tP_Frog_Projectile2 != null && ((UnityEngine.Object)tP_Frog_Projectile2).m_CachedPtr != (IntPtr)0)
					{
						tP_Frog_Projectile2.Jump(destintion);
					}
				};
				float num10 = (float)(flag ? 1 : 0) * __repeatInterval;
				float duration = num10 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				tP_Frog_Weapon._lastShotTimer = lastShotTimer;
				bool flag6 = false;
				nint num11 = (nint)action2;
				action = null;
				goto IL_0317;
				IL_0317:
				_amount = __amount;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				if (!(__amount > (float)(flag ? 1 : 0)))
				{
					return;
				}
				continue;
				IL_0490:
				bool flag7 = !flag5;
				flag6 = flag4;
				num11 = num7;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v826 @ rbx_v11 (System.Boolean)+10]");
					bool flag8 = (nint)0 == 0;
					flag6 = flag4;
					num11 = num7;
					if (!flag8)
					{
						((TP_Frog_Projectile)flag5).Jump(vector);
						flag6 = flag4;
						num11 = (nint)vector;
						action = null;
					}
				}
				goto IL_0317;
				IL_0457:
				bool flag9 = obj9 == null;
				flag5 = false;
				num7 = (nint)typeof(TP_Frog_Projectile);
				if (!flag9)
				{
					flag5 = flag4;
					num7 = (nint)typeof(TP_Frog_Projectile);
				}
				goto IL_0490;
			}
			MissingMethodException ex = new MissingMethodException();
			throw ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public int localIndex;

		public Vector2 jumpPos;

		public _003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_025c: Expected O, but got I4
			//IL_0108: Expected I, but got O
			//IL_0116: Expected I, but got O
			//IL_0126: Expected O, but got I
			//IL_01a6: Expected O, but got I4
			//IL_0162: Expected O, but got I
			//IL_0198: Expected O, but got I4
			//IL_0084->IL01fc: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL01fc: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass15_0 obj = CS_0024_003C_003E8__locals1;
			TP_Frog_Projectile tP_Frog_Projectile;
			Vector2 vector = default(Vector2);
			TP_Frog_Projectile tP_Frog_Projectile2;
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
					_003C_003Ec__DisplayClass15_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Frog_Weapon tP_Frog_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							tP_Frog_Projectile = (TP_Frog_Projectile)obj3._003C_003E4__this.FireOneProjectile(vector, localIndex, tP_Frog_Weapon._targetTransform);
							bool flag2 = (object)tP_Frog_Projectile == null;
							tP_Frog_Projectile2 = null;
							if (!flag2)
							{
								nint num = (nint)tP_Frog_Projectile;
								nint num2 = (nint)typeof(TP_Frog_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+C8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v36+FFFFFFF8+v375 @ rax_v32*8]");
									if (0 == (nint)typeof(TP_Frog_Projectile))
									{
										obj6 = 1;
										goto IL_027e;
									}
								}
								obj6 = 0;
								goto IL_027e;
							}
							goto IL_02a5;
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_027e:
			bool flag3 = obj6 == null;
			tP_Frog_Projectile2 = null;
			if (!flag3)
			{
				tP_Frog_Projectile2 = tP_Frog_Projectile;
			}
			goto IL_02a5;
			IL_02a5:
			if ((object)tP_Frog_Projectile2 != null && ((UnityEngine.Object)tP_Frog_Projectile2).m_CachedPtr != (IntPtr)0)
			{
				tP_Frog_Projectile2.Jump(vector);
			}
		}
	}

	private PhaserSprite _cursor;

	private SpriteTextureData _cursorSpriteData;

	private float _cursorMinAlpha;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual bool IsPrimaryWeapon => true;

	protected override int ProjectilePoolSize => 100;

	public override float PArea()
	{
		float result = TP_Frog2_Weapon.PAreaMax;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		if (TP_Frog2_Weapon.PAreaMax > num2)
		{
			result = num2;
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, (string)_cursorSpriteData, (string)_cursorSpriteData);
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		PhaserSprite cursor = _cursor;
		if ((object)_cursor != null && ((UnityEngine.Object)cursor).m_CachedPtr != (IntPtr)0)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			PhaserSprite phaserSprite = _cursor.setPosition(position);
			PhaserSprite phaserSprite2 = _cursor.setAlpha(_cursorMinAlpha);
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
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
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 99 Invalid \"Jump target not found in method: 0x187431020\"");
	}

	private unsafe void UpdateCursor(float interval)
	{
		//IL_010b: Expected O, but got Ref
		float num = 1f - _cursorMinAlpha;
		float num2 = num * base._003CTotalTime_003Ek__BackingField;
		float num3 = num2 / interval;
		float alpha = num3 + _cursorMinAlpha;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserSprite phaserSprite2 = _cursor.setPosition(position);
		if (IsPrimaryWeapon)
		{
		}
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
		if (IsPrimaryWeapon)
		{
		}
		Transform transform = _cursor.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
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

	private unsafe void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals21._003C_003E4__this = this;
		CS_0024_003C_003E8__locals21.pos = pos;
		float num = base.PAmount();
		CS_0024_003C_003E8__locals21.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float _repeatInterval = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num3 = base.PSpeedRepeatInterval();
		CS_0024_003C_003E8__locals21.__repeatInterval = _repeatInterval;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num4 = default(int);
		DisplayCursorVFX(num4, hitBoxDelay2);
		if (num4 <= 0)
		{
			return;
		}
		bool flag = false;
		float num6 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num5 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num6);
			Action onComplete = CS_0024_003C_003E8__locals21._003C_003E9__0;
			if (CS_0024_003C_003E8__locals21._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals21._003C_003E9__0 = delegate
				{
					//IL_0362: Invalid comparison between F4 and I4
					//IL_002b: Expected I, but got O
					//IL_0052: Expected O, but got I
					//IL_04d1: Expected O, but got F4
					//IL_04ee: Expected O, but got I8
					//IL_03a7: Expected O, but got I
					//IL_0522: Expected O, but got F4
					//IL_052f: Expected O, but got I8
					//IL_00c1: Expected O, but got I4
					//IL_00b3: Expected I, but got I8
					//IL_0426: Unknown result type (might be due to invalid IL or missing references)
					//IL_042b: Expected O, but got Unknown
					//IL_0109: Expected O, but got I4
					//IL_00fb: Expected I, but got I8
					//IL_030d: Expected I, but got O
					//IL_0151: Expected O, but got I4
					//IL_015f: Expected I, but got O
					//IL_016f: Expected O, but got I
					//IL_0339: Invalid comparison between F4 and I4
					//IL_01ef: Expected O, but got I4
					//IL_0137: Expected I, but got O
					//IL_047d: Expected I, but got O
					//IL_01ab: Expected O, but got I
					//IL_020a: Expected I, but got O
					//IL_01e1: Expected O, but got I4
					//IL_0260: Expected O, but got I4
					//IL_0270: Expected I, but got O
					//IL_0100->IL04fc: Incompatible stack heights: 1 vs 0
					float _amount = CS_0024_003C_003E8__locals21.__amount;
					if (CS_0024_003C_003E8__locals21.__amount > 0f)
					{
						bool flag2 = false;
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						bool flag6 = default(bool);
						Vector2 vector = default(Vector2);
						while (true)
						{
							_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass15_1();
							CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals21;
							nint num8 = (nint)typeof(_003C_003Ec__DisplayClass15_1);
							CS_0024_003C_003E8__locals26.localIndex = (flag2 ? 1 : 0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								if (obj == null)
								{
									break;
								}
								num8 = unchecked((nint)6573110936L);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v581 @ rax_v18 (should have been resolved before IL gen)");
							object obj2 = UnityEngine.Random.value;
							bool flag3 = 0.5f > 0.25f;
							object obj3 = 4294967295L;
							if (!flag3)
							{
								obj3 = 1;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							object obj4 = 0;
							float num9 = (float)obj3 * 0.25f;
							float num10 = num9 + (float)CS_0024_003C_003E8__locals21.pos;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag4 = obj4 == null;
								num8 = unchecked((nint)6573110936L);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v703 @ rax_v26 (should have been resolved before IL gen)");
							bool isPrimaryWeapon = CS_0024_003C_003E8__locals21._003C_003E4__this.IsPrimaryWeapon;
							CS_0024_003C_003E8__locals26.jumpPos = (Vector2)num10;
							object obj5 = 4294967295L;
							if (!isPrimaryWeapon)
							{
								obj5 = 1;
							}
							float num11 = (float)obj5 * 0.5f;
							float num12 = num11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Frog_Weapon+<>c__DisplayClass15_0)+1C]");
							float num13 = num12 + 0f;
							object obj6 = flag2 * CS_0024_003C_003E8__locals21.__repeatInterval;
							TP_Frog_Weapon tP_Frog_Weapon = CS_0024_003C_003E8__locals21._003C_003E4__this;
							bool flag5;
							nint num15;
							Action<float> action2;
							if ((nint)obj6 > 0)
							{
								Action action = delegate
								{
									//IL_025c: Expected O, but got I4
									//IL_0108: Expected I, but got O
									//IL_0116: Expected I, but got O
									//IL_0126: Expected O, but got I
									//IL_01a6: Expected O, but got I4
									//IL_0162: Expected O, but got I
									//IL_0198: Expected O, but got I4
									//IL_0084->IL01fc: Incompatible stack heights: 1 vs 0
									//IL_00b3->IL01fc: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass15_0 obj10 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
									TP_Frog_Projectile tP_Frog_Projectile;
									Vector2 vector2 = default(Vector2);
									TP_Frog_Projectile tP_Frog_Projectile2;
									object obj15;
									if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
									{
										GameObject gameObject = obj10._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag11 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj11 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass15_0 obj12 = CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals26.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Frog_Weapon tP_Frog_Weapon2 = obj12._003C_003E4__this;
												if ((object)obj12._003C_003E4__this != null)
												{
													tP_Frog_Projectile = (TP_Frog_Projectile)obj12._003C_003E4__this.FireOneProjectile(vector2, CS_0024_003C_003E8__locals26.localIndex, tP_Frog_Weapon2._targetTransform);
													bool flag12 = (object)tP_Frog_Projectile == null;
													tP_Frog_Projectile2 = null;
													if (!flag12)
													{
														nint num19 = (nint)tP_Frog_Projectile;
														nint num20 = (nint)typeof(TP_Frog_Projectile);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
														object obj13 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
														nint num21 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
														if (num21 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+C8]");
															object obj14 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v36+FFFFFFF8+v375 @ rax_v32*8]");
															if (0 == (nint)typeof(TP_Frog_Projectile))
															{
																obj15 = 1;
																goto IL_027e;
															}
														}
														obj15 = 0;
														goto IL_027e;
													}
													goto IL_02a5;
												}
											}
										}
									}
									throw new NullReferenceException();
									IL_027e:
									bool flag13 = obj15 == null;
									tP_Frog_Projectile2 = null;
									if (!flag13)
									{
										tP_Frog_Projectile2 = tP_Frog_Projectile;
									}
									goto IL_02a5;
									IL_02a5:
									if ((object)tP_Frog_Projectile2 != null && ((UnityEngine.Object)tP_Frog_Projectile2).m_CachedPtr != (IntPtr)0)
									{
										tP_Frog_Projectile2.Jump(vector2);
									}
								};
								float num14 = (float)(flag2 ? 1 : 0) * CS_0024_003C_003E8__locals21.__repeatInterval;
								float duration2 = num14 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration2, action, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								tP_Frog_Weapon._lastShotTimer = lastShotTimer;
								flag5 = false;
								num15 = (nint)action;
								action2 = null;
								goto IL_0317;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							object obj9;
							if (flag6)
							{
								action2 = (Action<float>)((bool*)(flag6 ? 1 : 0))->m_value;
								nint num16 = (nint)typeof(TP_Frog_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ r8_v7 (System.Action`1<System.Single>)+130]");
								nint num17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+130]");
								if (num17 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ r8_v7 (System.Action`1<System.Single>)+C8]");
									object obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rax_v53+FFFFFFF8+v813 @ rax_v49*8]");
									if (0 == (nint)typeof(TP_Frog_Projectile))
									{
										obj9 = 1;
										goto IL_0457;
									}
								}
								obj9 = 0;
								goto IL_0457;
							}
							bool flag7 = false;
							nint num18 = (nint)tP_Frog_Weapon;
							action2 = (Action<float>)vector;
							goto IL_0490;
							IL_0317:
							_amount = CS_0024_003C_003E8__locals21.__amount;
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							if (!(CS_0024_003C_003E8__locals21.__amount > (float)(flag2 ? 1 : 0)))
							{
								return;
							}
							continue;
							IL_0490:
							bool flag8 = !flag7;
							flag5 = flag6;
							num15 = num18;
							if (!flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v826 @ rbx_v11 (System.Boolean)+10]");
								bool flag9 = (nint)0 == 0;
								flag5 = flag6;
								num15 = num18;
								if (!flag9)
								{
									((TP_Frog_Projectile)flag7).Jump(vector);
									flag5 = flag6;
									num15 = (nint)vector;
									action2 = null;
								}
							}
							goto IL_0317;
							IL_0457:
							bool flag10 = obj9 == null;
							flag7 = false;
							num18 = (nint)typeof(TP_Frog_Projectile);
							if (!flag10)
							{
								flag7 = flag6;
								num18 = (nint)typeof(TP_Frog_Projectile);
							}
							goto IL_0490;
						}
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				});
			}
			float num7 = (float)(flag ? 1 : 0) * num5;
			float duration = num7 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < num4);
	}

	private Vector2 GetJumpDestination(Vector2 pos)
	{
		//IL_0010: Expected O, but got I
		//IL_014b: Expected O, but got F4
		//IL_0168: Expected O, but got I8
		//IL_00f6: Expected O, but got I
		//IL_0084: Expected O, but got I4
		//IL_0076: Expected O, but got I8
		//IL_0142: Expected O, but got F4
		//IL_00be: Expected O, but got I8
		//IL_00c3->IL0176: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TP_Frog_Weapon tP_Frog_Weapon = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_Frog_Weapon = (TP_Frog_Weapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v8 (should have been resolved before IL gen)");
		object obj2 = UnityEngine.Random.value;
		bool flag2 = 0.5f > 0.25f;
		object obj3 = 4294967295L;
		if (!flag2)
		{
			obj3 = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		float num = (float)obj3 * 0.25f;
		float num2 = num + (float)pos;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag3 = obj4 == null;
			tP_Frog_Weapon = (TP_Frog_Weapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v188 @ rax_v16 (should have been resolved before IL gen)");
		if (!IsPrimaryWeapon)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-68), the output could be wrong!");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 120 ConditionalJump @-1, v173 @ ZF_v11 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
		return (Vector2)num2;
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
		CheckBeginningArcana();
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
			while (((Equipment)weapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				bool flag = weapon.LevelUp(skipFire: true);
			}
			GM.Core.SetSeenWeapon(_counterWeaponType);
		}
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
		PhaserSprite cursor = _cursor;
		_isVisible = visible;
		if ((object)_cursor != null && ((UnityEngine.Object)cursor).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _cursor.setVisible(visible);
		}
	}

	public TP_Frog_Weapon()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1599]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_cursorSpriteData = (SpriteTextureData)"TP_VFX_Frog_Cursor";
		_cursorMinAlpha = 0.15f;
		_counterWeaponType = WeaponType.TP_FROG_COUNTER;
		base._002Ector();
	}
}
