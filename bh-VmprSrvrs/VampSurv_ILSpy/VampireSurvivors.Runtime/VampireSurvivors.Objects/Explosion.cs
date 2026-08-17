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

namespace VampireSurvivors.Objects;

public class Explosion : PoolableMonoBehaviour
{
	private SpriteRenderer _GroundFx;

	private Transform _cachedTransform;

	private PlayerOptions _playerOptions;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter1;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _gravityWell;

	private Tween _scaleTween;

	private Timer _despawnTimer;

	private Circle _circleArea;

	private float _damage;

	private float _radius;

	private bool _hasHit;

	private bool _isDespawning;

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		GenerateParticleSystems();
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

	public unsafe void Init(float damage, float radius)
	{
		//IL_0479: Expected O, but got Ref
		//IL_02ad: Expected O, but got I4
		//IL_04b9: Expected O, but got F4
		//IL_01de->IL02e1: Incompatible stack heights: 6 vs 0
		//IL_015d->IL02e1: Incompatible stack heights: 6 vs 0
		//IL_018c->IL02e1: Incompatible stack heights: 6 vs 0
		//IL_04ab->IL02e1: Incompatible stack heights: 6 vs 0
		//IL_0464->IL03f2: Incompatible stack heights: 8 vs 6
		_damage = damage;
		_hasHit = false;
		float radius2 = radius / 100f;
		_radius = radius2;
		if ((object)_particlesManager != null)
		{
			_particlesManager.AddGravityWellParticleSystems(_gravityWell);
			if ((object)_cachedTransform != null)
			{
				Transform transform = _cachedTransform.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					float y = default(float);
					_circleArea = new Circle
					{
						_x = ret,
						_y = y,
						_radius = _radius
					};
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.4f);
					Transform groundFx = (Transform)(object)_GroundFx;
					bool flag2 = (object)_GroundFx == null;
					bool flag3 = ((UnityEngine.Object)groundFx).m_CachedPtr == (IntPtr)0;
					Color value = default(Color);
					SpriteRenderer.set_color_Injected(((UnityEngine.Object)groundFx).m_CachedPtr, ref value);
					bool flag4 = (object)_GroundFx == null;
					_GroundFx.enabled = false;
					RenderingExtensions.Start(_pfxEmitter1);
					RenderingExtensions.Start(_pfxEmitter2);
					bool flag5 = _playerOptions == null;
					PlayerOptionsData config = _playerOptions.Config;
					bool flag6 = config == null;
					if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
					{
						goto IL_03f2;
					}
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = true;
						if ((object)_GroundFx != null)
						{
							Transform transform2 = _GroundFx.transform;
							bool flag7 = (object)transform2 == null;
							bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&ret));
							goto IL_03f2;
						}
					}
				}
			}
		}
		goto IL_02e1;
		IL_03f2:
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if ((object)_GroundFx != null)
		{
			Transform target = _GroundFx.transform;
			Vector3 vector = default(Vector3);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector), 0.120000005f);
			TweenCallback tweenCallback = TriggerDespawnTimer;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v49 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 1f
				};
				object obj = UnityEngine.Random.value;
				float num = (float)Vector3.oneVector - 0.5f;
				float detune = num * 500f;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, time);
				return;
			}
		}
		goto IL_02e1;
		IL_02e1:
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

	public void InternalUpdate()
	{
		//IL_00bb: Expected I, but got O
		//IL_009e->IL012a: Incompatible stack heights: 2 vs 0
		//IL_00cd->IL012a: Incompatible stack heights: 2 vs 0
		if (_hasHit || _isDespawning)
		{
			return;
		}
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator point = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
			Transform transform = ((Component)null).transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if (_circleArea.Contains((Vector2)point))
			{
				_hasHit = true;
				nint num = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v633 @ r8_v9 (Il2CppClass<UnityEngine.Component>)+5F8] (should have been resolved before IL gen)");
			}
		}
	}

	private void TriggerDespawnTimer()
	{
		//IL_01ab->IL0116: Incompatible stack heights: 1 vs 0
		//IL_0048->IL0116: Incompatible stack heights: 2 vs 0
		//IL_00a6->IL0116: Incompatible stack heights: 2 vs 0
		ParticleSystem pfxEmitter = _pfxEmitter1;
		_isDespawning = true;
		if ((object)_pfxEmitter1 != null)
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
		GravityWell gravityWell = _gravityWell;
		if ((object)_gravityWell != null && ((UnityEngine.Object)gravityWell).m_CachedPtr != (IntPtr)0)
		{
			_gravityWell.Clear();
		}
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
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
		//IL_08fa: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_033f: Expected O, but got I
		//IL_0359: Expected native int or pointer, but got O
		//IL_0934: Expected O, but got I
		//IL_0391: Expected O, but got Ref
		//IL_03b8: Expected O, but got I
		//IL_03d2: Expected native int or pointer, but got O
		//IL_096e: Expected O, but got I
		//IL_05bf: Expected O, but got I4
		//IL_05d8: Expected O, but got Ref
		//IL_05f2: Expected native int or pointer, but got O
		//IL_060c: Expected O, but got I
		//IL_062c: Expected O, but got Ref
		//IL_0646: Expected native int or pointer, but got O
		//IL_0660: Expected O, but got I
		//IL_0680: Expected O, but got Ref
		//IL_069a: Expected native int or pointer, but got O
		//IL_06b5: Expected O, but got I
		//IL_09f5: Expected O, but got I
		//IL_06d5: Expected O, but got Ref
		//IL_06fc: Expected O, but got I
		//IL_0716: Expected native int or pointer, but got O
		//IL_0a2f: Expected O, but got I
		//IL_076d: Expected O, but got I
		//IL_078e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
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
			((List<object>)(object)list).AddWithResize((object)"Smoke1");
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
			((List<object>)(object)list).AddWithResize((object)"Smoke2");
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
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		_ = 0;
		particleSystemConfig._on = true;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter1");
		_pfxEmitter1 = pfxEmitter;
		Transform transform = _pfxEmitter1.transform;
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
			((List<object>)(object)list2).AddWithResize((object)"HitSmoke1");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"HitSmoke2");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		_ = 0;
		_ = 1073741824;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._on = true;
		bool flag2 = (object)_particlesManager == null;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter2;
		bool flag3 = (object)_pfxEmitter2 == null;
		Transform transform2 = _pfxEmitter2.transform;
		bool flag4 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rax_v91 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rax_v91 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		bool flag6 = gravityWellConfig == null;
		_ = 1065353216;
		_ = 1112014848;
		_ = 1101004800;
		_ = 0;
		bool flag7 = (object)_particlesManager == null;
		GravityWell gravityWell = _particlesManager.CreateGravityWell(gravityWellConfig);
		_gravityWell = gravityWell;
		bool flag8 = (object)_gravityWell == null;
		Transform transform3 = _gravityWell.transform;
		bool flag9 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v855 @ rax_v100 (UnityEngine.Transform)+10]");
		bool flag10 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v855 @ rax_v100 (UnityEngine.Transform)+10]");
		Vector3 value3 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value3);
	}

	private void InitGravityWell()
	{
		_particlesManager.AddGravityWellParticleSystems(_gravityWell);
	}

	private void ReleaseGravityWell()
	{
		GravityWell gravityWell = _gravityWell;
		if ((object)_gravityWell != null && ((UnityEngine.Object)gravityWell).m_CachedPtr != (IntPtr)0)
		{
			_gravityWell.Clear();
		}
	}

	public Explosion()
	{
		//IL_0036: Expected I, but got O
		_damage = 1f;
		_radius = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
