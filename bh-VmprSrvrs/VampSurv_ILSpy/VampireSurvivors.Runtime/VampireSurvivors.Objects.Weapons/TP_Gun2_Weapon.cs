using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Gun2_Weapon : TP_Gun1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int localIndex;

		public TP_Gun2_Weapon _003C_003E4__this;

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
							TP_Gun2_Weapon tP_Gun2_Weapon = _003C_003E4__this;
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

	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public TP_Gun2_Weapon _003C_003E4__this;

		public EnemyController target;

		internal void _003COnBulletOverlapsEnemy_003Eb__0(Pickup pickup)
		{
			//IL_0044: Expected I, but got O
			//IL_004c: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_017d: Expected O, but got F4
			//IL_0143: Expected F4, but got I4
			if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			nint num = (nint)typeof(Coin);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v8 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			Pickup pickup2 = (Pickup)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v8 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v27+FFFFFFF8+v298 @ rax_v8 (VampireSurvivors.Objects.Pickups.Pickup)*8]");
				if (0 == (nint)typeof(Coin))
				{
					((Coin)pickup).Bejewel();
				}
			}
			TP_Gun2_Weapon tP_Gun2_Weapon = _003C_003E4__this;
			float2 position = target.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(tP_Gun2_Weapon._jewelPickupVfx, pos, 20);
			object obj2 = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupGold, 100f, 1, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private ParticleSystem _jewelPickupVfx;

	private List<Color32> _colors;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0033: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_0541: Expected O, but got Ref
		//IL_0550: Expected O, but got I4
		//IL_055e: Expected native int or pointer, but got O
		//IL_073c: Expected O, but got I4
		//IL_0576: Expected O, but got Ref
		//IL_0590: Expected native int or pointer, but got O
		//IL_05aa: Expected O, but got I
		//IL_05ca: Expected O, but got Ref
		//IL_05e4: Expected native int or pointer, but got O
		//IL_0759: Expected O, but got I4
		//IL_0616: Expected O, but got Ref
		//IL_0630: Expected native int or pointer, but got O
		//IL_0793: Expected O, but got I
		//IL_0676: Expected O, but got I4
		//IL_07cd: Expected O, but got I
		//IL_06c1: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("TP_items");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(225f, 275f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.2f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		_ = 257;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		particleSystemConfig._on = false;
		Transform parent = base.transform;
		ParticleSystem jewelPickupVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "JewelPickupVfx");
		_jewelPickupVfx = jewelPickupVfx;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01f2: Invalid comparison between O and F4
		//IL_021d: Expected F4, but got O
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_019d: Invalid comparison between F4 and I4
		//IL_01ab: Expected O, but got I4
		int num = ++_bulletCounter;
		float num2 = base.PAmount();
		float num3 = (float)num * 0.125f;
		object obj = default(object);
		float num4 = (float)obj * num3;
		float num5 = num4 + 1f;
		if (_bulletCounter == 8)
		{
			_bulletCounter = 0;
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		bool flag = !(num5 > 1f);
		Vector2 vector2 = vector;
		if (!flag)
		{
			bool flag2 = true;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag3;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj2 = flag2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj2 <= 0)
				{
					Vector2 playerPos = base.PlayerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass2_0();
					CS_0024_003C_003E8__locals8._003C_003E4__this = this;
					CS_0024_003C_003E8__locals8.localIndex = (flag2 ? 1 : 0);
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
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
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
										TP_Gun2_Weapon tP_Gun2_Weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
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
					float num6 = (float)(flag2 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num6 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag3 = num5 > (float)(flag2 ? 1 : 0);
				vector2 = (Vector2)flag2;
			}
			while (flag3);
		}
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected unsafe override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_043c: Expected I4, but got O
		//IL_04c9: Expected O, but got I
		//IL_01ed: Expected I, but got O
		//IL_02bd: Expected O, but got Ref
		//IL_0301: Expected F4, but got I
		//IL_0429: Expected O, but got I4
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass3_0();
		float num5;
		ArcadeSprite target4;
		if (CS_0024_003C_003E8__locals20 != null)
		{
			CS_0024_003C_003E8__locals20._003C_003E4__this = this;
			if (first != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					EnemyController component = gameObject.GetComponent<EnemyController>();
					CS_0024_003C_003E8__locals20.target = component;
					EnemyController target = CS_0024_003C_003E8__locals20.target;
					if ((object)CS_0024_003C_003E8__locals20.target != null)
					{
						if (target._003CIsDead_003Ek__BackingField)
						{
							goto IL_0462;
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
									if (component2.HasAlreadyHitObject(CS_0024_003C_003E8__locals20.target))
									{
										goto IL_0462;
									}
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									ArcadeSprite target2 = CS_0024_003C_003E8__locals20.target;
									float num3 = default(float);
									if (!(num3 > 1f))
									{
										WeaponData currentWeaponData = _currentWeaponData;
										if (_currentWeaponData != null)
										{
											HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
										}
										else
										{
											HitVfxType hitVfxType = HitVfxType.Default;
										}
										float knockback = base.Knockback;
										if ((object)CS_0024_003C_003E8__locals20.target != null)
										{
											nint num4 = (nint)target2;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v677 @ rdx_v20 (Il2CppClass<ArcadeSprite>)+3E8] (should have been resolved before IL gen)");
											num5 = num3;
											goto IL_0494;
										}
									}
									else
									{
										num5 = num3 * num3;
										if ((object)CS_0024_003C_003E8__locals20.target != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018743DDD8h\"");
											object obj = default(object);
											HitVfxType hitVfxType2 = ((obj == null) ? HitVfxType.Default : HitVfxType.None);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r14_v5 (ArcadeSprite)+20C]");
											object obj2 = (nint)hitVfxType2 & (nint)0;
											if (obj2 != null)
											{
												if ((object)CS_0024_003C_003E8__locals20.target != null)
												{
													float2 position = CS_0024_003C_003E8__locals20.target.position;
													object obj3 = default(object);
													ShowBigDamage(num5, (Vector3)(&obj3));
													ArcadeSprite target3 = CS_0024_003C_003E8__locals20.target;
													if ((object)CS_0024_003C_003E8__locals20.target != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v34 (ArcadeSprite)+1E8]");
														num5 = 0f;
														target4 = CS_0024_003C_003E8__locals20.target;
														goto IL_0342;
													}
												}
											}
											else
											{
												bool flag = (object)CS_0024_003C_003E8__locals20.target == null;
												target4 = CS_0024_003C_003E8__locals20.target;
												if (!flag)
												{
													goto IL_0342;
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
		goto IL_042e;
		IL_0342:
		float2 position2 = target4.position;
		float num6 = UnityEngine.Random.Range(-0.1f, 0.1f);
		float num7 = UnityEngine.Random.Range(0f, 0.1f);
		Action<Pickup> callback = delegate(Pickup pickup)
		{
			//IL_0044: Expected I, but got O
			//IL_004c: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_017d: Expected O, but got F4
			//IL_0143: Expected F4, but got I4
			if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
			{
				nint num9 = (nint)typeof(Coin);
				nint num10 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v8 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
				Pickup pickup2 = (Pickup)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v8 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
				if (num11 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v27+FFFFFFF8+v298 @ rax_v8 (VampireSurvivors.Objects.Pickups.Pickup)*8]");
					if (0 == (nint)typeof(Coin))
					{
						((Coin)pickup).Bejewel();
					}
				}
				TP_Gun2_Weapon tP_Gun2_Weapon = CS_0024_003C_003E8__locals20._003C_003E4__this;
				float2 position3 = CS_0024_003C_003E8__locals20.target.position;
				Vector2 pos2 = default(Vector2);
				RenderingExtensions.EmitParticleAt(tP_Gun2_Weapon._jewelPickupVfx, pos2, 20);
				object obj5 = UnityEngine.Random.value;
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupGold, 100f, 1, 0f, volume, rate, detune, loop, 1f);
			}
		};
		if ((object)GM.Core != null)
		{
			Vector2 pos = default(Vector2);
			GM.Core.MakeCoin(pos, 1f, callback);
			WeaponData currentWeaponData2 = _currentWeaponData;
			bool flag2 = _currentWeaponData == null;
			HitVfxType showHitVfx = HitVfxType.Default;
			if (!flag2)
			{
				showHitVfx = currentWeaponData2._003ChitVFX_003Ek__BackingField;
			}
			float knockback2 = base.Knockback;
			if ((object)CS_0024_003C_003E8__locals20.target != null)
			{
				CS_0024_003C_003E8__locals20.target.GetDamagedSpecial(num5, showHitVfx, knockback2, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
				goto IL_0494;
			}
		}
		goto IL_042e;
		IL_0494:
		float num8 = num5 + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
		((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num8;
		goto IL_0462;
		IL_042e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0462:
		return false;
	}

	public void ShowBigDamage(float value, Vector3 position)
	{
		//IL_008b: Expected I4, but got O
		//IL_008f: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CDamageNumbersEnabled_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			object obj = UnityEngine.Random.RandomRangeInt(0, (int)obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BAD0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
		}
	}

	public TP_Gun2_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0086: Expected O, but got I
		//IL_006b: Expected O, but got I8
		//IL_0317: Expected O, but got I
		//IL_00f8: Expected O, but got I
		//IL_00dd: Expected O, but got I8
		//IL_033f: Expected O, but got I
		//IL_016a: Expected O, but got I
		//IL_014f: Expected O, but got I8
		//IL_0367: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_01c1: Expected O, but got I8
		//IL_038f: Expected O, but got I
		//IL_024e: Expected O, but got I
		//IL_0233: Expected O, but got I8
		//IL_03b7: Expected O, but got I
		//IL_02c0: Expected O, but got I
		//IL_02a5: Expected O, but got I8
		List<Color32> list = new List<Color32>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize((Color32)4286611711L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 4286611711L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((Color32)4286644096L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 4286644096L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize((Color32)4294934656L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 4294934656L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((Color32)4286644223L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 4286644223L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize((Color32)4294967168L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4294967168L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize((Color32)4294934783L);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 4294934783L;
		}
		_colors = list;
		((Weapon)this)._002Ector();
	}
}
