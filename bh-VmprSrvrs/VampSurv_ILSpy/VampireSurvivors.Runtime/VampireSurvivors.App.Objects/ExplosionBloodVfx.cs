using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.App.Objects;

public class ExplosionBloodVfx : PoolablePhaserSprite
{
	private PhaserSprite _RingSprite;

	private PhaserSprite _GroundFx;

	private float _radius;

	private Circle _circleArea;

	private MultiTargetTween _despawnTimer;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	protected override void Awake()
	{
		//IL_0034: Expected O, but got I4
		EnsureSpriteRenderer();
		Circle circleArea = new Circle();
		_circleArea = circleArea;
		PhaserSprite phaserSprite = setVisible(visible: false);
		GenerateParticles();
		PhaserSprite phaserSprite2 = _GroundFx.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.4f);
		PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
		PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
		PhaserSprite phaserSprite6 = _RingSprite.setAlpha(1f);
		PhaserSprite phaserSprite7 = phaserSprite6.setVisible(visible: false);
		PhaserSprite phaserSprite8 = phaserSprite7.setBlendMode(BlendMode.Add);
	}

	public void OnRecycle(float radius)
	{
		//IL_002f: Expected O, but got I4
		//IL_00a5: Expected O, but got I4
		//IL_00f2: Expected I, but got O
		//IL_0156: Expected O, but got I4
		_particlesManager.AddGravityWellParticleSystems(_well);
		_radius = radius;
		PhaserSprite phaserSprite = setScale(radius, (float?)(object)0);
		float x = base.X;
		_RingSprite.X = x;
		float y = base.Y;
		_RingSprite.Y = y;
		PhaserSprite phaserSprite2 = _RingSprite.setVisible(visible: true);
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(4f, (float?)(object)0);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_RingSprite != null)
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
		tweenConfig.duration = 120f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite4 = _RingSprite.setVisible(visible: false);
			Explode();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void SetDepthPlease(float depth)
	{
		PhaserSprite groundFx = _GroundFx;
		float num = depth * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		groundFx._spriteRenderer.sortingOrder = sortingOrder;
		_particlesManager.SetDepthMultiplied(depth);
	}

	private unsafe void GenerateParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0213: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_026f: Expected O, but got I4
		//IL_0288: Expected O, but got Ref
		//IL_02a2: Expected native int or pointer, but got O
		//IL_02bc: Expected O, but got I
		//IL_02dc: Expected O, but got Ref
		//IL_02f6: Expected native int or pointer, but got O
		//IL_0310: Expected O, but got I
		//IL_0330: Expected O, but got Ref
		//IL_034a: Expected native int or pointer, but got O
		//IL_09d4: Expected O, but got I4
		//IL_0362: Expected O, but got Ref
		//IL_0389: Expected O, but got I
		//IL_03a3: Expected native int or pointer, but got O
		//IL_09f1: Expected O, but got I4
		//IL_03d5: Expected O, but got Ref
		//IL_03fc: Expected O, but got I
		//IL_0416: Expected native int or pointer, but got O
		//IL_0a2b: Expected O, but got I
		//IL_059f: Expected O, but got I4
		//IL_05d4: Expected O, but got I4
		//IL_05fb: Expected O, but got I4
		//IL_0614: Expected O, but got Ref
		//IL_062e: Expected native int or pointer, but got O
		//IL_0648: Expected O, but got I
		//IL_0668: Expected O, but got Ref
		//IL_0682: Expected native int or pointer, but got O
		//IL_069c: Expected O, but got I
		//IL_06bc: Expected O, but got Ref
		//IL_06d6: Expected native int or pointer, but got O
		//IL_0a65: Expected O, but got I
		//IL_070e: Expected O, but got Ref
		//IL_0735: Expected O, but got I
		//IL_074f: Expected native int or pointer, but got O
		//IL_0a9f: Expected O, but got I
		//IL_0787: Expected O, but got Ref
		//IL_07a1: Expected native int or pointer, but got O
		//IL_0ad1: Expected O, but got I
		//IL_07d9: Expected O, but got Ref
		//IL_07f3: Expected native int or pointer, but got O
		//IL_0b0b: Expected O, but got I
		//IL_084a: Expected O, but got I
		//IL_0871: Expected O, but got I
		//IL_0892: Expected O, but got I
		//IL_0911: Expected O, but got I
		//IL_097b: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
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
		float x = base.X;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(x);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float y = base.Y;
		minMaxCurve = new ParticleSystem.MinMaxCurve(y);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		particleSystemConfig._tintRandom = new uint[3] { 16711680u, 16746496u, 8912896u };
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
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
		float x2 = base.X;
		minMaxCurve = new ParticleSystem.MinMaxCurve(x2);
		particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float y2 = base.Y;
		minMaxCurve = new ParticleSystem.MinMaxCurve(y2);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(80f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 360));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+168]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+178]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 392));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+188]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+198]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 424));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		_ = 14483456;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		particleSystemConfig2._tint = (uint?)(object)0;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		float x3 = base.X;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		gravityWellConfig._x = (float?)(object)0;
		_ = 0;
		float y3 = base.Y;
		float num = y3 + 0.19999999f;
		_ = 1;
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 50f;
		gravityWellConfig._gravity = 20f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
		gravityWellConfig._y = (float?)(object)0;
		gravityWellConfig.preCacheParticles = false;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig, null, "Well");
		_well = well;
	}

	private void InitGravityWell()
	{
		_particlesManager.AddGravityWellParticleSystems(_well);
	}

	private void ReleaseGravityWell()
	{
		GravityWell well = _well;
		if ((object)_well != null && ((UnityEngine.Object)well).m_CachedPtr != (IntPtr)0)
		{
			_well.Clear();
		}
	}

	private unsafe void Explode()
	{
		//IL_0204: Expected O, but got I4
		//IL_0401: Expected O, but got F4
		//IL_02c7: Expected I, but got O
		//IL_033f: Expected O, but got I4
		//IL_019d->IL0389: Incompatible stack heights: 1 vs 0
		//IL_029b->IL0389: Incompatible stack heights: 1 vs 0
		//IL_01d1->IL0389: Incompatible stack heights: 1 vs 0
		//IL_030c->IL0389: Incompatible stack heights: 1 vs 0
		//IL_02ea->IL02ea: Incompatible stack heights: 2 vs 1
		Circle circleArea = _circleArea;
		float x = base.X;
		float num;
		if (_circleArea != null)
		{
			circleArea._x = x;
			Circle circleArea2 = _circleArea;
			float y = base.Y;
			if (_circleArea != null)
			{
				circleArea2._y = y;
				Circle circleArea3 = _circleArea;
				if (_circleArea != null)
				{
					circleArea3._radius = _radius;
					float diameter = _radius + _radius;
					circleArea3._diameter = diameter;
					float x2 = base.X;
					float y2 = base.Y;
					if ((object)_well != null)
					{
						Transform transform = _well.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						float value = default(float);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
						RenderingExtensions.Start(_pfxEmitter);
						RenderingExtensions.Start(_pfxEmitter2);
						GameManager core = GM.Core;
						PlayerOptionsData config = core._playerOptions.Config;
						bool flag2 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
						float num2 = default(float);
						num = num2;
						if (flag2)
						{
							goto IL_01ed;
						}
						float x3 = base.X;
						num = base.Y;
						if ((object)_GroundFx != null)
						{
							PhaserSprite phaserSprite = _GroundFx.setPosition(x3, num);
							if ((object)phaserSprite != null)
							{
								PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: true);
								goto IL_01ed;
							}
						}
					}
				}
			}
		}
		goto IL_0389;
		IL_0389:
		throw new NullReferenceException();
		IL_01ed:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1f
		};
		object obj = UnityEngine.Random.value;
		float num3 = num - 0.5f;
		float detune = num3 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, time);
		if (_despawnTimer != null)
		{
			_despawnTimer.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			if ((object)_GroundFx != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				bool flag3 = obj2 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				tweenConfig.duration = 120f;
				tweenConfig.scale = (float?)(object)1;
				TweenCallback onComplete = Despawn;
				tweenConfig.onComplete = onComplete;
				MultiTargetTween despawnTimer = Tweens.Add(tweenConfig);
				_despawnTimer = despawnTimer;
				return;
			}
		}
		goto IL_0389;
	}

	private void Despawn()
	{
		RenderingExtensions.StopEmitting(_pfxEmitter);
		RenderingExtensions.StopEmitting(_pfxEmitter2);
		if (_despawnTimer != null)
		{
			_despawnTimer.Kill();
		}
		PhaserSprite phaserSprite = _GroundFx.setVisible(visible: false);
		GravityWell well = _well;
		if ((object)_well != null && ((UnityEngine.Object)well).m_CachedPtr != (IntPtr)0)
		{
			_well.Clear();
		}
		GameObject obj = base.gameObject;
		base._ParentPool.Release(obj);
	}

	private void Die()
	{
		PhaserSprite phaserSprite = setVisible(visible: false);
	}

	public ExplosionBloodVfx()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003COnRecycle_003Eb__10_0()
	{
		PhaserSprite phaserSprite = _RingSprite.setVisible(visible: false);
		Explode();
	}
}
