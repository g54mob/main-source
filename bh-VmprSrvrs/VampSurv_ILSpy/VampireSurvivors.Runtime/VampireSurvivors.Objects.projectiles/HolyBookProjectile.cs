using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class HolyBookProjectile : Projectile
{
	private ParticleSystem _pfx;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Tween _scaleTween;

	private Tween _radiusTweenX;

	private float[] _requiemRandomOffsets;

	private int _requiemRandomIndex;

	private float _deltaTime;

	private const float Percentage = 0.0625f;

	private const float Radius = 0.5f;

	private const float SpeedModifier = 35f;

	protected override void Awake()
	{
		//IL_001a: Expected O, but got I4
		//IL_0086: Expected O, but got F4
		//IL_002e: Expected O, but got I4
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
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_002e: Expected I4, but got O
		//IL_0081: Expected O, but got Ref
		//IL_01a6: Expected O, but got Ref
		//IL_0411->IL0332: Incompatible stack heights: 1 vs 0
		//IL_03d3->IL0332: Incompatible stack heights: 1 vs 0
		//IL_014e->IL0332: Incompatible stack heights: 1 vs 0
		//IL_03f2->IL0332: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL0332: Incompatible stack heights: 1 vs 0
		//IL_025e->IL0332: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL0332: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_speed = 0f;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			int num = (int)_cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v6 (System.Int32)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v6 (System.Int32)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				float num3 = (float)Vector3.zeroVector * 0.3f;
				float num4 = num3 + 1f;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.5f);
				TweenCallback tweenCallback = delegate
				{
					_pfx.Play(withChildren: true);
				};
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore != null)
				{
					_scaleTween = tweenerCore;
					if ((object)_pfx != null && (object)_weapon != null)
					{
						float num5 = _weapon.PArea();
						float num6 = num4 * 0.3f;
						float min = num6 + 1f;
						ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
						ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
						object obj = default(object);
						sizeOverLifetimeModule.size = (ParticleSystem.MinMaxCurve)(&obj);
						if ((object)_weapon != null)
						{
							float hitBoxDelay = _weapon.HitBoxDelay;
							Action onComplete = delegate
							{
								if (_objectsHit != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
								}
							};
							float num7 = hitBoxDelay * 0.001f;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer hitboxTimer = Timers.Register(num7, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_hitboxTimer = hitboxTimer;
							if ((object)_weapon != null)
							{
								float num8 = _weapon.PDuration();
								Action onComplete2 = Expire;
								float num9 = num7 * 0.001f;
								Timer expireTimer = Timers.Register(num9, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_expireTimer = expireTimer;
								if ((object)_weapon != null)
								{
									float num10 = _weapon.PAmount();
									float num11 = (float)Math.PI * 2f / num9;
									float deltaTime = num11 * (float)_indexInWeapon;
									_deltaTime = deltaTime;
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
					HolyBookProjectile cachedTransform = (HolyBookProjectile)(object)_cachedTransform;
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
		//IL_019b: Expected O, but got I4
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		Tween radiusTweenX = _radiusTweenX;
		if (_radiusTweenX != null && radiusTweenX._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_radiusTweenX);
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
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float num = weapon.SecondaryPAmount();
			float2 float5 = base.position;
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

	private void Expire()
	{
		//IL_00e8: Expected I, but got O
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_pfx.Stop();
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.HolyBookProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
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
			((List<object>)(object)list).AddWithResize((object)"Page");
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
		_ = 1;
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
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.7f, 0f));
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
		_ = 1128792064;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._frequency = (float?)(object)0;
		ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfx = pfx;
	}

	public HolyBookProjectile()
	{
		float[] requiemRandomOffsets = new float[500];
		_requiemRandomOffsets = requiemRandomOffsets;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__12_0()
	{
		_pfx.Play(withChildren: true);
	}

	private void _003CInitProjectile_003Eb__12_1()
	{
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
