using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Earth2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__18_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__18_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1461;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public float __repeatInterval;

		public TP_Earth2_Weapon _003C_003E4__this;

		public Vector2 pos;

		public float __amount;

		public Action _003C_003E9__0;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0149: Invalid comparison between F4 and I4
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_012a: Invalid comparison between F4 and I4
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass22_1();
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = this;
				CS_0024_003C_003E8__locals7.localIndex = (flag2 ? 1 : 0);
				object obj = flag * __repeatInterval;
				if ((nint)obj <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Earth2_Weapon tP_Earth2_Weapon = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_0160: Expected O, but got I4
						//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass22_0 obj2 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj2._003C_003E4__this != null)
						{
							GameObject gameObject = obj2._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj3 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass22_0 obj4 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Earth2_Weapon tP_Earth2_Weapon2 = obj4._003C_003E4__this;
									if ((object)obj4._003C_003E4__this != null && (object)obj4._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj4._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals7.localIndex, tP_Earth2_Weapon2._targetTransform);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Earth2_Weapon._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag2 = (byte)((flag2 ? 1u : 0u) + 2u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_0160: Expected O, but got I4
			//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass22_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Earth2_Weapon tP_Earth2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Earth2_Weapon._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_2
	{
		public Vector2 mirrorPos;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals2;

		public Action _003C_003E9__2;

		internal void _003CFireProjectiles_003Eb__2()
		{
			//IL_0188: Invalid comparison between F4 and I4
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals2;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (obj.__amount > (float)(flag3 ? 1 : 0))
			{
				_003C_003Ec__DisplayClass22_3 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass22_3();
				CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals3 = this;
				CS_0024_003C_003E8__locals8.localIndex = (flag2 ? 1 : 0);
				_003C_003Ec__DisplayClass22_0 obj2 = CS_0024_003C_003E8__locals2;
				object obj3 = flag * obj2.__repeatInterval;
				if ((nint)obj3 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Earth2_Weapon tP_Earth2_Weapon = obj2._003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_01ff: Expected O, but got I4
						//IL_00d7->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0106->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0125->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0147->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0176->IL01c8: Incompatible stack heights: 1 vs 0
						//IL_0198->IL01c8: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass22_2 obj4 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals3;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals3 != null)
						{
							_003C_003Ec__DisplayClass22_0 obj5 = obj4.CS_0024_003C_003E8__locals2;
							if (obj4.CS_0024_003C_003E8__locals2 != null && (object)obj5._003C_003E4__this != null)
							{
								GameObject gameObject = obj5._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj6 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass22_2 obj7 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals3;
									if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals3 != null)
									{
										_003C_003Ec__DisplayClass22_0 obj8 = obj7.CS_0024_003C_003E8__locals2;
										if (obj7.CS_0024_003C_003E8__locals2 != null && CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals3 != null && obj7.CS_0024_003C_003E8__locals2 != null)
										{
											TP_Earth2_Weapon tP_Earth2_Weapon2 = obj8._003C_003E4__this;
											if ((object)obj8._003C_003E4__this != null && (object)obj8._003C_003E4__this != null)
											{
												Vector2 pos = default(Vector2);
												Projectile projectile = obj8._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals8.localIndex, tP_Earth2_Weapon2._targetTransform);
												return;
											}
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num = (float)(flag ? 1 : 0) * obj2.__repeatInterval;
					float duration = num * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Earth2_Weapon._lastShotTimer = lastShotTimer;
				}
				obj = CS_0024_003C_003E8__locals2;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag2 = (byte)((flag2 ? 1u : 0u) + 2u) != 0;
				flag3 = flag;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_3
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass22_2 CS_0024_003C_003E8__locals3;

		internal void _003CFireProjectiles_003Eb__3()
		{
			//IL_01ff: Expected O, but got I4
			//IL_00d7->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0106->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0125->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0147->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0176->IL01c8: Incompatible stack heights: 1 vs 0
			//IL_0198->IL01c8: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass22_2 obj = CS_0024_003C_003E8__locals3;
			if (CS_0024_003C_003E8__locals3 != null)
			{
				_003C_003Ec__DisplayClass22_0 obj2 = obj.CS_0024_003C_003E8__locals2;
				if (obj.CS_0024_003C_003E8__locals2 != null && (object)obj2._003C_003E4__this != null)
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
						_003C_003Ec__DisplayClass22_2 obj4 = CS_0024_003C_003E8__locals3;
						if (CS_0024_003C_003E8__locals3 != null)
						{
							_003C_003Ec__DisplayClass22_0 obj5 = obj4.CS_0024_003C_003E8__locals2;
							if (obj4.CS_0024_003C_003E8__locals2 != null && CS_0024_003C_003E8__locals3 != null && obj4.CS_0024_003C_003E8__locals2 != null)
							{
								TP_Earth2_Weapon tP_Earth2_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null && (object)obj5._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Earth2_Weapon._targetTransform);
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

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public TP_Earth2_Weapon _003C_003E4__this;

		public EnemyController target;

		internal void _003COnBulletOverlapsEnemy_003Eb__0(Pickup pickup)
		{
			//IL_0044: Expected I, but got O
			//IL_004c: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_0098: Expected O, but got I
			//IL_00d5: Expected O, but got I
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_01e1: Expected O, but got F4
			//IL_0188: Expected F4, but got I4
			if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			nint num = (nint)typeof(Coin);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v14+FFFFFFF8+v298 @ rax_v8*8]");
				if (0 == (nint)typeof(Coin))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v14+FFFFFFF8+v364 @ rcx_v13*8]");
					object obj4 = 0 - typeof(Coin);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					Coin coin = null;
					if (!flag2)
					{
						coin = (Coin)pickup;
					}
					coin.Bejewel();
					TP_Earth2_Weapon tP_Earth2_Weapon = _003C_003E4__this;
					float2 position = target.position;
					Vector2 pos = default(Vector2);
					RenderingExtensions.EmitParticleAt(tP_Earth2_Weapon._jewelPickupVfx, pos, 20);
					object obj5 = UnityEngine.Random.value;
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupGold, 100f, 1, 0f, volume, rate, detune, loop, 1f);
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	private Material _Material;

	private bool _initialisedParticles;

	private ParticleSystem _jewelPickupVfx;

	private PhaserSprite _cursor;

	private float _topBarHeight;

	private bool _hasGemini;

	private TP_Earth1_Weapon _earth1Weapon;

	private List<uint> _baseTints;

	private List<uint> _rainbowTints;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public List<uint> BaseTints => _baseTints;

	public List<uint> RainbowTints => _rainbowTints;

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Rock13");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(2);
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0052: Expected O, but got I
		//IL_006e: Expected O, but got I4
		//IL_079b: Expected I, but got O
		//IL_07a9: Expected I, but got O
		//IL_07b9: Expected O, but got I
		//IL_0839: Expected O, but got I4
		//IL_07f5: Expected O, but got I
		//IL_082b: Expected O, but got I4
		//IL_0560: Expected O, but got Ref
		//IL_056f: Expected O, but got I4
		//IL_057d: Expected native int or pointer, but got O
		//IL_0a19: Expected O, but got I4
		//IL_0595: Expected O, but got Ref
		//IL_05af: Expected native int or pointer, but got O
		//IL_05c9: Expected O, but got I
		//IL_05e9: Expected O, but got Ref
		//IL_0603: Expected native int or pointer, but got O
		//IL_0a36: Expected O, but got I4
		//IL_0635: Expected O, but got Ref
		//IL_064f: Expected native int or pointer, but got O
		//IL_0a70: Expected O, but got I
		//IL_0695: Expected O, but got I4
		//IL_0aaa: Expected O, but got I
		//IL_0ac7: Expected F4, but got I
		//IL_06e0: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj3 = default(object);
		float num2 = (float)obj3 * 0.7f;
		base._003CTotalTime_003Ek__BackingField = num2;
		bool flag = _initialisedParticles;
		bool flag2 = false;
		if (!flag)
		{
			_initialisedParticles = true;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("TP_items");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel01");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel02");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel03");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel04");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel05");
			}
			else
			{
				int size5 = list._size + 1;
				list._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list._version + 1;
			list._version = version6;
			string[] items6 = list._items;
			if (list._size >= items6.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel06");
			}
			else
			{
				int size6 = list._size + 1;
				list._size = size6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version7 = list._version + 1;
			list._version = version7;
			string[] items7 = list._items;
			if (list._size >= items7.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel07");
			}
			else
			{
				int size7 = list._size + 1;
				list._size = size7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version8 = list._version + 1;
			list._version = version8;
			string[] items8 = list._items;
			if (list._size >= items8.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_Jewel08");
			}
			else
			{
				int size8 = list._size + 1;
				list._size = size8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+10]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+20]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(225f, 275f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0.2f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
			particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
			num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
			_ = 0;
			_ = 257;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
			particleSystemConfig._collideBottom = (bool?)(object)0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem jewelPickupVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "JewelPickupVfx");
			_jewelPickupVfx = jewelPickupVfx;
			flag2 = true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__18_0;
		if (_003C_003Ec._003C_003E9__18_0 == null)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__18_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj8 = x._equipmentType - 1461;
				return obj8 == null;
			});
			flag2 = false;
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag3 = (object)equipment == null;
		Equipment earth1Weapon = null;
		if (flag3)
		{
			goto IL_0b37;
		}
		nint num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Earth1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Earth1_Weapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Earth1_Weapon>)+130]");
		object obj6;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rax_v49+FFFFFFF8+v837 @ rax_v45*8]");
			if (0 == (nint)typeof(TP_Earth1_Weapon))
			{
				obj6 = 1;
				goto IL_0b46;
			}
		}
		obj6 = 0;
		goto IL_0b46;
		IL_0b37:
		_earth1Weapon = (TP_Earth1_Weapon)earth1Weapon;
		TP_Earth1_Weapon earth1Weapon2 = _earth1Weapon;
		if ((object)_earth1Weapon != null && ((UnityEngine.Object)earth1Weapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj7 = default(object);
			if (obj7 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag4 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_earth1Weapon);
			}
			_earth1Weapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag5 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_earth1Weapon);
			TP_Earth1_Weapon earth1Weapon3 = _earth1Weapon;
			earth1Weapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject = _earth1Weapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_0b46:
		bool flag6 = obj6 == null;
		flag2 = (byte)num3 != 0;
		earth1Weapon = null;
		if (!flag6)
		{
			flag2 = (byte)num3 != 0;
			earth1Weapon = equipment;
		}
		goto IL_0b37;
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
				TP_Earth1_Weapon earth1Weapon = _earth1Weapon;
				if ((object)_earth1Weapon != null && ((UnityEngine.Object)earth1Weapon).m_CachedPtr != (IntPtr)0)
				{
					_earth1Weapon.Fire();
				}
			}
		}
		float num3 = base._003CTotalTime_003Ek__BackingField * 0.85f;
		float num4 = num3 / deltaTime;
		float alpha = num4 + 0.15f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		float playerFacing = PlayerFacing;
		if (((Equipment)this)._003COwner_003Ek__BackingField.flipX)
		{
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserSprite phaserSprite2 = _cursor.setPosition(position);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
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
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		//IL_0522->IL043a: Incompatible stack heights: 1 vs 0
		//IL_0571->IL043a: Incompatible stack heights: 2 vs 0
		//IL_02c3->IL043a: Incompatible stack heights: 2 vs 0
		//IL_0334->IL0439: Incompatible stack heights: 2 vs 0
		//IL_059a->IL043a: Incompatible stack heights: 2 vs 0
		//IL_0439->IL0439: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass22_0();
		int num4 = default(int);
		float num6 = default(float);
		bool flag3 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (CS_0024_003C_003E8__locals25 != null)
		{
			CS_0024_003C_003E8__locals25._003C_003E4__this = this;
			CS_0024_003C_003E8__locals25.pos = pos;
			float num = base.PAmount();
			CS_0024_003C_003E8__locals25.__amount = (float)pos;
			float num2 = base.PDuration();
			float hitBoxDelay = base.HitBoxDelay;
			float _repeatInterval = (float)pos / hitBoxDelay;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
			float num3 = base.PSpeedRepeatInterval();
			CS_0024_003C_003E8__locals25.__repeatInterval = _repeatInterval;
			float hitBoxDelay2 = base.HitBoxDelay;
			DisplayCursorVFX(num4, hitBoxDelay2);
			bool flag = num4 <= 0;
			bool flag2 = false;
			if (flag)
			{
				goto IL_01d8;
			}
			while (true)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData == null)
				{
					break;
				}
				float num5 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num6);
				Action onComplete = CS_0024_003C_003E8__locals25._003C_003E9__0;
				if (CS_0024_003C_003E8__locals25._003C_003E9__0 == null)
				{
					onComplete = (CS_0024_003C_003E8__locals25._003C_003E9__0 = delegate
					{
						//IL_0149: Invalid comparison between F4 and I4
						//IL_0042: Unknown result type (might be due to invalid IL or missing references)
						//IL_0047: Expected O, but got Unknown
						//IL_012a: Invalid comparison between F4 and I4
						if (CS_0024_003C_003E8__locals25.__amount > 0f)
						{
							bool flag9 = false;
							bool flag10 = false;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							do
							{
								_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals37 = new _003C_003Ec__DisplayClass22_1();
								CS_0024_003C_003E8__locals37.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals25;
								CS_0024_003C_003E8__locals37.localIndex = (flag10 ? 1 : 0);
								object obj4 = flag9 * CS_0024_003C_003E8__locals25.__repeatInterval;
								if ((nint)obj4 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
								}
								else
								{
									TP_Earth2_Weapon tP_Earth2_Weapon = CS_0024_003C_003E8__locals25._003C_003E4__this;
									Action onComplete3 = delegate
									{
										//IL_0160: Expected O, but got I4
										//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
										//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
										//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
										_003C_003Ec__DisplayClass22_0 obj5 = CS_0024_003C_003E8__locals37.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals37.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
										{
											GameObject gameObject = obj5._003C_003E4__this.gameObject;
											if ((object)gameObject != null)
											{
												bool flag11 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
												if (obj6 == null)
												{
													return;
												}
												_003C_003Ec__DisplayClass22_0 obj7 = CS_0024_003C_003E8__locals37.CS_0024_003C_003E8__locals1;
												if (CS_0024_003C_003E8__locals37.CS_0024_003C_003E8__locals1 != null)
												{
													TP_Earth2_Weapon tP_Earth2_Weapon2 = obj7._003C_003E4__this;
													if ((object)obj7._003C_003E4__this != null && (object)obj7._003C_003E4__this != null)
													{
														Vector2 pos2 = default(Vector2);
														Projectile projectile = obj7._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals37.localIndex, tP_Earth2_Weapon2._targetTransform);
														return;
													}
												}
											}
										}
										throw new NullReferenceException();
									};
									float num12 = (float)(flag9 ? 1 : 0) * CS_0024_003C_003E8__locals25.__repeatInterval;
									float duration3 = num12 * 0.001f;
									Timer lastShotTimer = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
									tP_Earth2_Weapon._lastShotTimer = lastShotTimer;
								}
								flag9 = (byte)((flag9 ? 1u : 0u) + 1u) != 0;
								flag10 = (byte)((flag10 ? 1u : 0u) + 2u) != 0;
							}
							while (CS_0024_003C_003E8__locals25.__amount > (float)(flag9 ? 1 : 0));
						}
					});
				}
				float num7 = (float)(flag2 ? 1 : 0) * num5;
				float num8 = num7 + 1f;
				float duration = num8 * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				bool flag4 = (flag2 ? 1 : 0) < num4;
				flag3 = flag3;
				if (!flag4)
				{
					goto IL_01d8;
				}
			}
		}
		goto IL_043a;
		IL_043a:
		throw new NullReferenceException();
		IL_01d8:
		if (!_hasGemini)
		{
			return;
		}
		_003C_003Ec__DisplayClass22_2 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass22_2();
		if (CS_0024_003C_003E8__locals32 != null)
		{
			CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals25;
			if ((object)_cursor != null)
			{
				float2 position = _cursor.position;
				object obj = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v13 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v13 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform != null)
					{
						bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						if ((object)_cursor != null)
						{
							float2 position2 = _cursor.position;
							if ((object)_cursor != null)
							{
								float2 position3 = _cursor.position;
								object obj2 = (object)ret - (object)position2;
								object obj3 = obj2 + obj2;
								Vector2 mirrorPos = (Vector2)(obj3 + (object)position);
								CS_0024_003C_003E8__locals32.mirrorPos = mirrorPos;
								bool flag7 = num4 <= 0;
								bool flag8 = false;
								if (flag7)
								{
									return;
								}
								while (true)
								{
									WeaponData currentWeaponData2 = _currentWeaponData;
									if (_currentWeaponData == null)
									{
										break;
									}
									float num9 = (((object)currentWeaponData2._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num6);
									Transform onComplete2 = (Transform)(object)CS_0024_003C_003E8__locals32._003C_003E9__2;
									if (CS_0024_003C_003E8__locals32._003C_003E9__2 == null)
									{
										onComplete2 = (Transform)(object)(CS_0024_003C_003E8__locals32._003C_003E9__2 = delegate
										{
											//IL_0188: Invalid comparison between F4 and I4
											//IL_006b: Unknown result type (might be due to invalid IL or missing references)
											//IL_0070: Expected O, but got Unknown
											_003C_003Ec__DisplayClass22_0 obj4 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
											bool flag9 = false;
											bool flag10 = false;
											bool flag11 = false;
											bool useRealTime = default(bool);
											MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
											int repeat2 = default(int);
											TimerType type2 = default(TimerType);
											while (obj4.__amount > (float)(flag11 ? 1 : 0))
											{
												_003C_003Ec__DisplayClass22_3 CS_0024_003C_003E8__locals43 = new _003C_003Ec__DisplayClass22_3();
												CS_0024_003C_003E8__locals43.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals32;
												CS_0024_003C_003E8__locals43.localIndex = (flag10 ? 1 : 0);
												_003C_003Ec__DisplayClass22_0 obj5 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
												object obj6 = flag9 * obj5.__repeatInterval;
												if ((nint)obj6 <= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
												}
												else
												{
													TP_Earth2_Weapon tP_Earth2_Weapon = obj5._003C_003E4__this;
													Action onComplete3 = delegate
													{
														//IL_01ff: Expected O, but got I4
														//IL_00d7->IL01c8: Incompatible stack heights: 1 vs 0
														//IL_0106->IL01c8: Incompatible stack heights: 1 vs 0
														//IL_0125->IL01c8: Incompatible stack heights: 1 vs 0
														//IL_0147->IL01c8: Incompatible stack heights: 1 vs 0
														//IL_0176->IL01c8: Incompatible stack heights: 1 vs 0
														//IL_0198->IL01c8: Incompatible stack heights: 1 vs 0
														_003C_003Ec__DisplayClass22_2 obj7 = CS_0024_003C_003E8__locals43.CS_0024_003C_003E8__locals3;
														if (CS_0024_003C_003E8__locals43.CS_0024_003C_003E8__locals3 != null)
														{
															_003C_003Ec__DisplayClass22_0 obj8 = obj7.CS_0024_003C_003E8__locals2;
															if (obj7.CS_0024_003C_003E8__locals2 != null && (object)obj8._003C_003E4__this != null)
															{
																GameObject gameObject = obj8._003C_003E4__this.gameObject;
																if ((object)gameObject != null)
																{
																	bool flag12 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
																	object obj9 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
																	if (obj9 == null)
																	{
																		return;
																	}
																	_003C_003Ec__DisplayClass22_2 obj10 = CS_0024_003C_003E8__locals43.CS_0024_003C_003E8__locals3;
																	if (CS_0024_003C_003E8__locals43.CS_0024_003C_003E8__locals3 != null)
																	{
																		_003C_003Ec__DisplayClass22_0 obj11 = obj10.CS_0024_003C_003E8__locals2;
																		if (obj10.CS_0024_003C_003E8__locals2 != null && CS_0024_003C_003E8__locals43.CS_0024_003C_003E8__locals3 != null && obj10.CS_0024_003C_003E8__locals2 != null)
																		{
																			TP_Earth2_Weapon tP_Earth2_Weapon2 = obj11._003C_003E4__this;
																			if ((object)obj11._003C_003E4__this != null && (object)obj11._003C_003E4__this != null)
																			{
																				Vector2 pos2 = default(Vector2);
																				Projectile projectile = obj11._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals43.localIndex, tP_Earth2_Weapon2._targetTransform);
																				return;
																			}
																		}
																	}
																}
															}
														}
														throw new NullReferenceException();
													};
													float num12 = (float)(flag9 ? 1 : 0) * obj5.__repeatInterval;
													float duration3 = num12 * 0.001f;
													Timer lastShotTimer = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
													tP_Earth2_Weapon._lastShotTimer = lastShotTimer;
												}
												obj4 = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals2;
												flag9 = (byte)((flag9 ? 1u : 0u) + 1u) != 0;
												flag10 = (byte)((flag10 ? 1u : 0u) + 2u) != 0;
												flag11 = flag9;
											}
										});
									}
									float num10 = (float)(flag8 ? 1 : 0) * num9;
									float num11 = num10 + 1f;
									float duration2 = num11 * 0.001f;
									Timer timer2 = Timers.Register(duration2, (Action)(object)onComplete2, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									flag8 = (byte)((flag8 ? 1u : 0u) + 1u) != 0;
									if ((flag8 ? 1 : 0) < num4)
									{
										continue;
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_043a;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 3;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_hasGemini = true;
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_023c: Expected I4, but got O
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass24_0();
		if (CS_0024_003C_003E8__locals12 != null)
		{
			CS_0024_003C_003E8__locals12._003C_003E4__this = this;
			if (first != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					EnemyController component = gameObject.GetComponent<EnemyController>();
					CS_0024_003C_003E8__locals12.target = component;
					EnemyController target = CS_0024_003C_003E8__locals12.target;
					if ((object)CS_0024_003C_003E8__locals12.target != null)
					{
						if (target._003CIsDead_003Ek__BackingField)
						{
							goto IL_0228;
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
									if (!component2.HasAlreadyHitObject(CS_0024_003C_003E8__locals12.target))
									{
										base.DealDamage(CS_0024_003C_003E8__locals12.target);
									}
									ArcadeSprite target2 = CS_0024_003C_003E8__locals12.target;
									if ((object)CS_0024_003C_003E8__locals12.target != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v16 (ArcadeSprite)+260]");
										if ((nint)0 != 0)
										{
											float2 position = CS_0024_003C_003E8__locals12.target.position;
											float num = UnityEngine.Random.Range(-0.1f, 0.1f);
											float num2 = UnityEngine.Random.Range(0f, 0.1f);
											Action<Pickup> callback = delegate(Pickup pickup)
											{
												//IL_0044: Expected I, but got O
												//IL_004c: Expected I, but got O
												//IL_005c: Expected O, but got I
												//IL_0098: Expected O, but got I
												//IL_00d5: Expected O, but got I
												//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
												//IL_00f0: Expected O, but got Unknown
												//IL_01e1: Expected O, but got F4
												//IL_0188: Expected F4, but got I4
												if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
												{
													nint num3 = (nint)typeof(Coin);
													nint num4 = (nint)pickup;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
													object obj = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
													nint num5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
													if (num5 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
														object obj2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v14+FFFFFFF8+v298 @ rax_v8*8]");
														if (0 == (nint)typeof(Coin))
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
															object obj3 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v14+FFFFFFF8+v364 @ rcx_v13*8]");
															object obj4 = 0 - typeof(Coin);
															bool flag = obj4 == null;
															bool flag2 = !flag;
															Coin coin = null;
															if (!flag2)
															{
																coin = (Coin)pickup;
															}
															coin.Bejewel();
															TP_Earth2_Weapon tP_Earth2_Weapon = CS_0024_003C_003E8__locals12._003C_003E4__this;
															float2 position2 = CS_0024_003C_003E8__locals12.target.position;
															Vector2 pos2 = default(Vector2);
															RenderingExtensions.EmitParticleAt(tP_Earth2_Weapon._jewelPickupVfx, pos2, 20);
															object obj5 = UnityEngine.Random.value;
															float? volume = default(float?);
															float rate = default(float);
															float detune = default(float);
															bool loop = default(bool);
															PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupGold, 100f, 1, 0f, volume, rate, detune, loop, 1f);
															return;
														}
													}
													throw new NullReferenceException();
												}
											};
											if ((object)GM.Core == null)
											{
												goto IL_022e;
											}
											Vector2 pos = default(Vector2);
											GM.Core.MakeCoin(pos, 1f, callback);
										}
										goto IL_0228;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_022e;
		IL_0228:
		return false;
		IL_022e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
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
		TP_Earth1_Weapon earth1Weapon = _earth1Weapon;
		if ((object)_earth1Weapon != null && ((UnityEngine.Object)earth1Weapon).m_CachedPtr != (IntPtr)0)
		{
			_earth1Weapon.SetVisible(visible);
		}
	}

	public TP_Earth2_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_05a5: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_05cd: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_05f5: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_061d: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0271: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_0654: Expected O, but got I
		//IL_0335: Expected O, but got I
		//IL_067c: Expected O, but got I
		//IL_039f: Expected O, but got I
		//IL_06a4: Expected O, but got I
		//IL_0409: Expected O, but got I
		//IL_06cc: Expected O, but got I
		//IL_0473: Expected O, but got I
		//IL_06f4: Expected O, but got I
		//IL_04dd: Expected O, but got I
		//IL_071c: Expected O, but got I
		//IL_0547: Expected O, but got I
		_topBarHeight = 0.2f;
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16744319u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16744319;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(16760703u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 16760703;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16777087u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16777087;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(12582783u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 12582783;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(8388479u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 8388479;
		}
		_baseTints = list;
		List<uint> list2 = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v16+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize(8388543u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 8388543;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v18+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize(8388607u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 8388607;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v20+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize(8372223u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 8372223;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v22+18]");
		if (num9 >= 0)
		{
			list2.AddWithResize(8355839u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 8355839;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v24+18]");
		if (num10 >= 0)
		{
			list2.AddWithResize(12550143u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 12550143;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v26+18]");
		if (num11 >= 0)
		{
			list2.AddWithResize(16744447u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 16744447;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v28+18]");
		if (num12 >= 0)
		{
			list2.AddWithResize(16744383u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 16744383;
		}
		_rainbowTints = list2;
		base._002Ector();
	}
}
