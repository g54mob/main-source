using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SummonSpirit_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public TP_SummonSpirit_Projectile _003C_003E4__this;

		public Weapon weapon;

		public Action _003C_003E9__2;

		internal void _003CInitProjectile_003Eb__0()
		{
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile = _003C_003E4__this;
			Weapon weapon = tP_SummonSpirit_Projectile._weapon;
			WeaponData currentWeaponData = weapon._currentWeaponData;
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile2 = _003C_003E4__this;
			tP_SummonSpirit_Projectile2._penetrating = currentWeaponData._003Cpenetrating_003Ek__BackingField;
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile3 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile = _003C_003E4__this;
			if (tP_SummonSpirit_Projectile._expireTimer != null)
			{
				tP_SummonSpirit_Projectile._expireTimer.Cancel();
			}
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile2 = _003C_003E4__this;
			float num = weapon.PDuration();
			Action onComplete = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onComplete = (_003C_003E9__2 = delegate
				{
					_003C_003E4__this.StartDespawn();
				});
			}
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			tP_SummonSpirit_Projectile2._expireTimer = expireTimer;
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			_003C_003E4__this.StartDespawn();
		}
	}

	private Timer _expireTimer;

	private float _radius = 10f;

	private MultiTargetTween _scaleTween;

	private float _IndexOffsetScaleFactor = 0.1f;

	private MultiTargetTween _alphaTween;

	public float2 _targetPosition;

	public float _timeSinceChangedTarget;

	protected ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	protected bool _emitParticles;

	private Timer _hitboxTimer;

	private bool _isDespawning;

	protected virtual uint[] Tints
	{
		get
		{
			uint[] array = new uint[1];
			if (array.Length > 0)
			{
				array[0] = 16777215u;
				return array;
			}
			return (uint[])(object)new IndexOutOfRangeException();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GenerateParticleSystem();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0087: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_0160: Expected I4, but got O
		//IL_041e: Expected O, but got F4
		//IL_0346: Expected O, but got F4
		//IL_0360: Expected I4, but got O
		//IL_03f2: Expected O, but got I4
		//IL_01e3->IL02c3: Incompatible stack heights: 3 vs 0
		//IL_0235->IL02c3: Incompatible stack heights: 4 vs 0
		//IL_025e->IL02c3: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass15_0();
		if (CS_0024_003C_003E8__locals14 != null)
		{
			CS_0024_003C_003E8__locals14._003C_003E4__this = this;
			CS_0024_003C_003E8__locals14.weapon = weapon;
			base.InitProjectile(pool, CS_0024_003C_003E8__locals14.weapon, index);
			_isCullable = false;
			_emitParticles = true;
			_isDespawning = false;
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
				if (_hitboxTimer != null)
				{
					_hitboxTimer.Cancel();
				}
				if ((object)_weapon != null)
				{
					float hitBoxDelay = _weapon.HitBoxDelay;
					Action onComplete = delegate
					{
						TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile = CS_0024_003C_003E8__locals14._003C_003E4__this;
						Weapon weapon2 = tP_SummonSpirit_Projectile._weapon;
						WeaponData currentWeaponData = weapon2._currentWeaponData;
						TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile2 = CS_0024_003C_003E8__locals14._003C_003E4__this;
						tP_SummonSpirit_Projectile2._penetrating = currentWeaponData._003Cpenetrating_003Ek__BackingField;
						TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile3 = CS_0024_003C_003E8__locals14._003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					};
					float duration = hitBoxDelay * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_hitboxTimer = hitboxTimer;
					int num = (int)_cachedTransform;
					_IndexOffsetScaleFactor = 0.1f;
					if ((object)_cachedTransform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v12 (System.Int32)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v12 (System.Int32)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
						object obj = UnityEngine.Random.value;
						object obj2 = UnityEngine.Random.value;
						float num2 = (float)ret - 0.5f;
						int num3 = (int)_cachedTransform;
						float num4 = num2 * (float)_indexInWeapon;
						float num5 = num4 * _IndexOffsetScaleFactor;
						object obj3 = default(object);
						float num6 = num5 + (float)obj3;
						bool flag2 = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rdi_v13 (System.Int32)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rdi_v13 (System.Int32)+10]");
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)0, ref value);
						ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
						if (_scaleTween != null)
						{
							_scaleTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							object obj4 = array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							bool flag4 = obj5 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null && (object)_weapon != null)
							{
								float num7 = _weapon.PArea();
								_ = 1128792064;
								_ = 1;
								TweenCallback tweenCallback = delegate
								{
									TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile = CS_0024_003C_003E8__locals14._003C_003E4__this;
									if (tP_SummonSpirit_Projectile._expireTimer != null)
									{
										tP_SummonSpirit_Projectile._expireTimer.Cancel();
									}
									TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile2 = CS_0024_003C_003E8__locals14._003C_003E4__this;
									float num8 = CS_0024_003C_003E8__locals14.weapon.PDuration();
									Action onComplete2 = CS_0024_003C_003E8__locals14._003C_003E9__2;
									if (CS_0024_003C_003E8__locals14._003C_003E9__2 == null)
									{
										onComplete2 = (CS_0024_003C_003E8__locals14._003C_003E9__2 = delegate
										{
											CS_0024_003C_003E8__locals14._003C_003E4__this.StartDespawn();
										});
									}
									object obj6 = default(object);
									float duration2 = (float)obj6 * 0.001f;
									bool useRealTime2 = default(bool);
									MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
									int repeat2 = default(int);
									TimerType type2 = default(TimerType);
									Timer expireTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
									tP_SummonSpirit_Projectile2._expireTimer = expireTimer;
								};
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00dc: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (--_penetrating <= 0)
			{
				StartDespawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		BaseBody baseBody = body;
		float num = (float)baseBody._velocity * -1f;
		baseBody._velocity = (float2)num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void StartDespawn()
	{
		//IL_0074: Expected I, but got O
		//IL_00d8: Expected O, but got I4
		if (!_isDespawning)
		{
			_isDespawning = true;
			_emitParticles = false;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 600f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0439: Expected O, but got Ref
		//IL_0460: Expected O, but got I
		//IL_0475: Expected native int or pointer, but got O
		//IL_048f: Expected O, but got I
		//IL_0628: Expected O, but got I4
		//IL_04dd: Expected O, but got Ref
		//IL_04f2: Expected O, but got I
		//IL_050c: Expected native int or pointer, but got O
		//IL_063b: Expected O, but got I4
		//IL_0524: Expected O, but got Ref
		//IL_053e: Expected native int or pointer, but got O
		//IL_0658: Expected O, but got I4
		//IL_0556: Expected O, but got Ref
		//IL_0570: Expected native int or pointer, but got O
		//IL_058a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat19.png");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat20.png");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat21.png");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat22.png");
			}
			else
			{
				int num4 = list._size + 1;
				list._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat23.png");
			}
			else
			{
				int num5 = list._size + 1;
				list._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list._version + 1;
			list._version = version6;
			string[] items6 = list._items;
			if (list._size >= items6.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat24.png");
			}
			else
			{
				int num6 = list._size + 1;
				list._size = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(600f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			uint[] tints = Tints;
			object obj3 = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			_ = 0;
			_ = 1;
			_ = tints[obj3];
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			particleSystemConfig._tint = (uint?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.25f, 0.05f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
			_ = 0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
	}

	public override void InternalUpdate()
	{
		UpdatePfx();
	}

	protected unsafe virtual void UpdatePfx()
	{
		//IL_00aa: Expected O, but got Ref
		//IL_017b->IL00f6: Incompatible stack heights: 1 vs 0
		//IL_00f6->IL0130: Incompatible stack heights: 1 vs 0
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0 || !_emitParticles)
		{
			return;
		}
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, 0f);
			ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
			RenderingExtensions.SetScale(_pfx, (ParticleSystem.MinMaxCurve)(&minMaxCurve2));
			TP_SummonSpirit_Projectile cachedTransform = (TP_SummonSpirit_Projectile)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				if ((object)_pfxManager != null)
				{
					Vector2 pos = default(Vector2);
					_pfxManager.EmitParticleAt(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CStartDespawn_003Eb__17_0()
	{
		Despawn();
	}
}
