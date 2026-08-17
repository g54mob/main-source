using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class VespersProjectile : Projectile
{
	private SpriteAnimation _animation;

	private ParticleSystem _pfx;

	protected MaterialPropertyBlock _propBlock;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private MultiTargetTween _scaleTween;

	private float[] _requiemRandomOffsets;

	private int _requiemRandomIndex;

	private float _deltaTime;

	private const float Percentage = 0.0625f;

	private const float Radius = 0.5f;

	private const float SpeedModifier = 35f;

	protected override void Awake()
	{
		//IL_0086: Expected O, but got I4
		//IL_0094: Expected O, but got F4
		//IL_0014: Expected O, but got I4
		base.Awake();
		GenerateParticleSystem();
		object obj = 0;
		object obj3;
		float num2 = default(float);
		do
		{
			float[] requiemRandomOffsets = _requiemRandomOffsets;
			object obj2 = UnityEngine.Random.value;
			obj3 = 0 + 1;
			float num = num2 * 0.5f;
			num2 = (requiemRandomOffsets[obj] = num * 32f);
		}
		while ((nint)obj3 < 500);
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		IntPtr ptr = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock.m_Ptr = ptr;
		_propBlock = materialPropertyBlock;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_01b7: Expected O, but got I
		//IL_038a: Expected I, but got O
		//IL_0419: Expected O, but got Ref
		//IL_0442: Expected native int or pointer, but got O
		//IL_0455: Expected O, but got Ref
		//IL_0463: Expected O, but got Ref
		//IL_04ac: Expected I, but got O
		//IL_04b4: Expected I, but got O
		//IL_04c4: Expected O, but got I
		//IL_04fc: Expected O, but got I
		//IL_0535: Expected O, but got I
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_0573: Expected O, but got I4
		//IL_0598: Expected I4, but got O
		//IL_07b8: Expected O, but got Ref
		//IL_069b: Expected O, but got Ref
		//IL_06b5: Expected native int or pointer, but got O
		//IL_06cd: Expected O, but got Ref
		//IL_0700->IL0700: Incompatible stack heights: 3 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_cachedTransform != null)
				{
					int value = ((int*)(&array))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					if ((object)_weapon != null)
					{
						_ = 0;
						float num = _weapon.PArea();
						object obj4 = default(object);
						float num2 = (float)obj4 * 0.3f;
						tweenConfig.duration = 500f;
						_ = 1;
						float num3 = num2 + 1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
						tweenConfig.scale = (float?)(object)0;
						TweenCallback onComplete = delegate
						{
							_pfx.Play(withChildren: true);
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						if (multiTargetTween != null)
						{
							MultiTargetTween scaleTween = multiTargetTween.SetAutoKill(autoKill: false);
							_scaleTween = scaleTween;
							if ((object)_weapon != null)
							{
								float num4 = _weapon.PAmount();
								float num5 = (float)Math.PI * 2f / num3;
								float deltaTime = num5 * (float)_indexInWeapon;
								_deltaTime = deltaTime;
								if (_hitboxTimer != null)
								{
									_hitboxTimer.Cancel();
								}
								if (_expireTimer != null)
								{
									_expireTimer.Cancel();
								}
								float hitBoxDelay = _weapon.HitBoxDelay;
								Action onComplete2 = delegate
								{
									if (_objectsHit != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
									}
								};
								float num6 = hitBoxDelay * 0.001f;
								bool flag = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer hitboxTimer = Timers.Register(num6, onComplete2, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_hitboxTimer = hitboxTimer;
								float num7 = _weapon.PDuration();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VespersProjectile>)+440]");
								Action onComplete3 = new Action(this, (IntPtr)0);
								nint num8 = (nint)this;
								float num9 = num6 * 0.001f;
								Timer expireTimer = Timers.Register(num9, onComplete3, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_expireTimer = expireTimer;
								_ = _pfx;
								_ = _pfx;
								float num10 = _weapon.PArea();
								float num11 = num9 * 0.3f;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
								_ = 0;
								float min = num11 + 1f;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(min, 0f));
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
								ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = (ParticleSystem.SizeOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
								_ = 0;
								((ParticleSystem.SizeOverLifetimeModule*)sizeOverLifetimeModule)->size = minMaxCurve2;
								Weapon weapon2 = _weapon;
								nint num12 = (nint)typeof(VespersWeapon);
								nint num13 = (nint)weapon2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.VespersWeapon>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
								nint num14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.VespersWeapon>)+130]");
								bool flag2 = num14 < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v58+FFFFFFF8+v631 @ rax_v57*8]");
								bool flag3 = 0 != (nint)typeof(VespersWeapon);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.VespersWeapon>)+130]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v58+FFFFFFF8+v1197 @ rcx_v47*8]");
								object obj8 = 0 - typeof(VespersWeapon);
								bool flag4 = obj8 == null;
								bool flag5 = !flag4;
								float? num15 = (float?)(object)0;
								if (!flag5)
								{
									num15 = (float?)weapon2;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rcx_v49 (System.Nullable`1<System.Single>)+158]");
								if ((nint)0 != 0)
								{
									int num16 = (int)_renderer;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12370]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rdi_v14 (System.Int32)+10]");
									bool flag6 = (nint)0 == 0;
									object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rdi_v14 (System.Int32)+10]");
									SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)obj9);
									_animation.SetAnimation("holy");
									List<string> list = new List<string>();
									int version = list._version + 1;
									list._version = version;
									string[] items = list._items;
									if (list._size >= items.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"Page");
									}
									else
									{
										int num17 = list._size + 1;
										list._size = num17;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									RenderingExtensions.SetFrames(_pfx, list, null, clearExistingFrames: false, flag ? 1 : 0);
									ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.65f, 0f));
									ParticleSystem.MinMaxCurve value2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-1]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F]");
									_ = 0;
									RenderingExtensions.SetAlpha(_pfx, value2);
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_010d: Expected I, but got O
		if ((object)_weapon != null)
		{
			float num = _weapon.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float num2 = (float)obj * 35f;
			Weapon weapon = _weapon;
			float num3 = deltaTime * num2;
			float num4 = num3 * 0.0625f;
			float deltaTime2 = num4 + _deltaTime;
			_deltaTime = deltaTime2;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					Weapon weapon2 = _weapon;
					bool flag2 = (object)_weapon == null;
					nint num5 = (nint)weapon2;
					float num6 = _weapon.PArea();
					if (4.5f > ret)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					bool flag3 = (object)_pfx == null;
					Transform transform2 = _pfx.transform;
					bool flag4 = (object)transform2 == null;
					bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					VespersProjectile cachedTransform = (VespersProjectile)(object)_cachedTransform;
					bool flag6 = (object)_cachedTransform == null;
					bool flag7 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_010e: Expected O, but got I4
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		_pfx.Stop();
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float num = weapon.SecondaryPAmount();
			object obj = default(object);
			if ((nint)obj > 0)
			{
				object obj2 = 0;
				float2 pos = default(float2);
				do
				{
					int requiemRandomIndex = _requiemRandomIndex + 1;
					_requiemRandomIndex = requiemRandomIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
					float num2 = _weapon.PArea();
					int requiemRandomIndex2 = _requiemRandomIndex + 1;
					_requiemRandomIndex = requiemRandomIndex2;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
					float num3 = _weapon.PArea();
					Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
					obj2++;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
			}
		}
		base.Despawn();
	}

	protected virtual void Expire()
	{
		//IL_00c7: Expected I, but got O
		//IL_012b: Expected O, but got I4
		//IL_0146: Expected I, but got O
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_pfx.Stop();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.scale = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VespersProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00e7: Expected native int or pointer, but got O
		//IL_026f: Expected O, but got I
		//IL_011f: Expected O, but got Ref
		//IL_0146: Expected O, but got I
		//IL_015b: Expected native int or pointer, but got O
		//IL_0175: Expected O, but got I
		//IL_0195: Expected O, but got Ref
		//IL_01af: Expected native int or pointer, but got O
		//IL_02a9: Expected O, but got I
		//IL_020e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Page2");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(50f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = true;
		_ = 1120403456;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._frequency = (float?)(object)0;
		ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfx = pfx;
	}

	public VespersProjectile()
	{
		float[] requiemRandomOffsets = new float[500];
		_requiemRandomOffsets = requiemRandomOffsets;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__13_1()
	{
		_pfx.Play(withChildren: true);
	}

	private void _003CInitProjectile_003Eb__13_0()
	{
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
