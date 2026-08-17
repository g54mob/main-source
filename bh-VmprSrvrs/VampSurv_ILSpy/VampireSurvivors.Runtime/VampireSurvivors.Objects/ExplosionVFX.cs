using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects;

public class ExplosionVFX : PoolableMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public ExplosionVFX _003C_003E4__this;

		public bool flashingVFX;

		internal void _003CSpawnAt_003Eb__0()
		{
			ExplosionVFX explosionVFX = _003C_003E4__this;
			explosionVFX._RingSprite.enabled = false;
			_003C_003E4__this.Explode(flashingVFX);
		}
	}

	private SpriteRenderer _GroundFx;

	private SpriteRenderer _RingSprite;

	private Transform _cachedTransform;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	private Tween _scaleTween;

	private Tween _scaleRingTween;

	private Timer _despawnTimer;

	private Circle _circleArea;

	private float _damage;

	private float _radius = 1f;

	private uint[] _tints = new uint[4] { 16746632u, 16746751u, 16746751u, 16777096u };

	private void Awake()
	{
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		GenerateParticleSystems();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("sPFX_ring_64", "vfx");
		_RingSprite.sprite = sprite;
	}

	private void OnDrawGizmosSelected()
	{
		//IL_0046: Expected F4, but got I
		if (_circleArea != null)
		{
			Color value = default(Color);
			Gizmos.set_color_Injected(ref value);
			Vector3 center = default(Vector3);
			IntPtr intPtr = default(IntPtr);
			Gizmos.DrawWireSphere_Injected(ref center, (float)(nint)intPtr);
		}
	}

	public unsafe void SpawnAt(float damage, float radius, bool flashingVFX)
	{
		//IL_0197: Expected I4, but got O
		//IL_0320: Expected I4, but got O
		//IL_0145->IL0222: Incompatible stack heights: 5 vs 0
		//IL_0329->IL0222: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass16_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6._003C_003E4__this = this;
			float radius2 = radius / 100f;
			CS_0024_003C_003E8__locals6.flashingVFX = flashingVFX;
			_damage = damage;
			_radius = radius2;
			if ((object)_cachedTransform != null)
			{
				Transform transform = _cachedTransform.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v18 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v18 (UnityEngine.Transform)+10]");
					float ret;
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
					float y = default(float);
					_circleArea = new Circle
					{
						_x = ret,
						_y = y,
						_radius = _radius
					};
					bool flag2 = (object)_RingSprite == null;
					Transform transform2 = _RingSprite.transform;
					bool flag3 = (object)transform2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rax_v26 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rax_v26 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					bool flag5 = (object)_RingSprite == null;
					_RingSprite.enabled = true;
					if (_scaleRingTween != null)
					{
						TweenExtensions.Kill(_scaleRingTween);
					}
					if ((object)_RingSprite != null)
					{
						Transform target = _RingSprite.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.120000005f);
						TweenCallback tweenCallback = delegate
						{
							ExplosionVFX explosionVFX = CS_0024_003C_003E8__locals6._003C_003E4__this;
							explosionVFX._RingSprite.enabled = false;
							CS_0024_003C_003E8__locals6._003C_003E4__this.Explode(CS_0024_003C_003E8__locals6.flashingVFX);
						};
						if ((int)(~tweenerCore) == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if ((int)(~tweenerCore) == 0)
						{
							_scaleRingTween = tweenerCore;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetDepthPlease(float depth)
	{
		float num = depth * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		_GroundFx.sortingOrder = sortingOrder;
		_particlesManager.SetDepthMultiplied(depth);
	}

	private unsafe void Explode(bool flashingVFX)
	{
		//IL_017a: Expected O, but got I4
		//IL_028f: Expected O, but got F4
		//IL_025e->IL01e8: Incompatible stack heights: 5 vs 1
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.4f);
		SpriteRenderer groundFx = _GroundFx;
		bool flag = ((UnityEngine.Object)groundFx).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)groundFx).m_CachedPtr, ref value);
		_GroundFx.enabled = false;
		RenderingExtensions.Start(_pfxEmitter);
		RenderingExtensions.Start(_pfxEmitter2);
		if (flashingVFX)
		{
			bool flag2 = (object)_GroundFx == null;
			_GroundFx.enabled = true;
			bool flag3 = (object)_GroundFx == null;
			Transform transform = _GroundFx.transform;
			bool flag4 = (object)transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rax_v59 (UnityEngine.Transform)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rax_v59 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenCallback callback = TriggerDespawnTimer;
		Tween tween = DOVirtual.DelayedCall(0.120000005f, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag6 = tween == null;
		tween.stringId = "DefaultGameTweenId";
		_scaleTween = tween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1f
		};
		object obj = UnityEngine.Random.value;
		float num = 0.120000005f - 0.5f;
		float detune = num * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, time);
	}

	private void TriggerDespawnTimer()
	{
		//IL_01a0->IL0116: Incompatible stack heights: 1 vs 0
		//IL_0048->IL0116: Incompatible stack heights: 2 vs 0
		//IL_00a6->IL0116: Incompatible stack heights: 2 vs 0
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null)
		{
			bool flag = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
			ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
			ParticleSystem pfxEmitter2 = _pfxEmitter2;
			if ((object)_pfxEmitter2 != null)
			{
				bool flag2 = ((UnityEngine.Object)pfxEmitter2).m_CachedPtr == (IntPtr)0;
				ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
				if (_scaleTween != null)
				{
					TweenExtensions.Kill(_scaleTween);
				}
				if ((object)_GroundFx != null)
				{
					_GroundFx.enabled = false;
					if (_despawnTimer != null)
					{
						_despawnTimer.Cancel();
					}
					if ((object)_particlesManager != null)
					{
						float remainingLifetime = _particlesManager.GetRemainingLifetime();
						Action onComplete = Despawn;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer despawnTimer = Timers.Register(remainingLifetime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_despawnTimer = despawnTimer;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Despawn()
	{
		GameObject obj = base.gameObject;
		if ((object)base._parentPool != null)
		{
			base._parentPool.Release(obj);
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0205: Expected O, but got I4
		//IL_021e: Expected O, but got Ref
		//IL_0238: Expected native int or pointer, but got O
		//IL_0252: Expected O, but got I
		//IL_0272: Expected O, but got Ref
		//IL_028c: Expected native int or pointer, but got O
		//IL_02a6: Expected O, but got I
		//IL_02c6: Expected O, but got Ref
		//IL_02e0: Expected native int or pointer, but got O
		//IL_08ee: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_033f: Expected O, but got I
		//IL_0359: Expected native int or pointer, but got O
		//IL_0928: Expected O, but got I
		//IL_0391: Expected O, but got Ref
		//IL_03b8: Expected O, but got I
		//IL_03d2: Expected native int or pointer, but got O
		//IL_0962: Expected O, but got I
		//IL_0515: Expected O, but got I4
		//IL_052e: Expected O, but got Ref
		//IL_0548: Expected native int or pointer, but got O
		//IL_0562: Expected O, but got I
		//IL_0582: Expected O, but got Ref
		//IL_059c: Expected native int or pointer, but got O
		//IL_05b6: Expected O, but got I
		//IL_05d6: Expected O, but got Ref
		//IL_05f0: Expected native int or pointer, but got O
		//IL_060b: Expected O, but got I
		//IL_09e9: Expected O, but got I
		//IL_062b: Expected O, but got Ref
		//IL_0652: Expected O, but got I
		//IL_066c: Expected native int or pointer, but got O
		//IL_0a23: Expected O, but got I
		//IL_06a4: Expected O, but got Ref
		//IL_06be: Expected native int or pointer, but got O
		//IL_0a5d: Expected O, but got I
		//IL_06f6: Expected O, but got Ref
		//IL_0710: Expected native int or pointer, but got O
		//IL_0a97: Expected O, but got I
		//IL_0767: Expected O, but got I
		//IL_0788: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+240]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitCloud1");
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
			((List<object>)(object)list).AddWithResize((object)"HitCloud2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+240]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+240]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		_ = 0;
		particleSystemConfig._on = false;
		particleSystemConfig._tintRandom = _tints;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		Transform transform = _pfxEmitter2.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxLine2");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 344));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+168]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(80f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+178]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+188]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 408));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+240]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+198]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 440));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 472));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+240]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+240]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._on = false;
		bool flag2 = (object)_particlesManager == null;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		bool flag3 = (object)_pfxEmitter == null;
		Transform transform2 = _pfxEmitter.transform;
		bool flag4 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rax_v99 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rax_v99 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		bool flag6 = gravityWellConfig == null;
		_ = 1065353216;
		_ = 1112014848;
		_ = 1101004800;
		bool flag7 = (object)_particlesManager == null;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
		_well = well;
		bool flag8 = (object)_well == null;
		Transform transform3 = _well.transform;
		bool flag9 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rax_v108 (UnityEngine.Transform)+10]");
		bool flag10 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rax_v108 (UnityEngine.Transform)+10]");
		Vector3 value3 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value3);
	}

	public ExplosionVFX()
	{
		((GameMonoBehaviour)this)._onResumeSent = true;
	}
}
