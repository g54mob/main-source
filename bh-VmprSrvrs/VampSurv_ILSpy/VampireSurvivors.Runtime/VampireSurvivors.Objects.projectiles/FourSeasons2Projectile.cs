using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FourSeasons2Projectile : Projectile
{
	private FourSeasons2Weapon _trueWeapon;

	private Timer _expireTimer;

	private ParticleEmitterManager _particles;

	private ParticleSystem _fwEmitter;

	private SpriteRenderer _ringRenderer;

	private SpriteRenderer _rainbowRenderer;

	private SpriteRenderer _raysRenderer;

	private MultiTargetTween _tween5;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween1;

	private int _season;

	private List<ParticleEmitterManager> _seasonParticles;

	private List<ParticleSystem> _seasonEmitters;

	private List<GravityWell> _seasonWells;

	private PhaserSprite _kanji;

	private List<Sprite> _kanjiFrames;

	private PhaserSprite _lightning;

	private MultiTargetTween _tweenLightning;

	private MultiTargetTween _tweenLightningReturn;

	private bool _initalized;

	public uint[] getEmitCustomTint(int season)
	{
		//IL_0013: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		bool flag = season == 0;
		uint[] array;
		RuntimeFieldHandle fldHandle;
		if (!flag)
		{
			object obj = season - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 != 1)
						{
							return null;
						}
						array = new uint[4];
						fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						array = new uint[4];
						fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
					}
				}
				else
				{
					array = new uint[4];
					fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				array = new uint[4];
				fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
			}
		}
		else
		{
			array = new uint[4];
			fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
		}
		RuntimeHelpers.InitializeArray(array, fldHandle);
		return array;
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("blurBlack2", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Sprite sprite2 = SpriteManager.GetSprite("sPFX_ring_64", "vfx");
		_ringRenderer.sprite = sprite2;
		Sprite sprite3 = SpriteManager.GetSprite("s_pfx_rainbow_64u", "vfx");
		_ringRenderer.sprite = sprite3;
		Sprite sprite4 = SpriteManager.GetSprite("fuzzA", "vfx");
		_ringRenderer.sprite = sprite4;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_038c: Expected I, but got O
		//IL_0394: Expected I, but got O
		//IL_03a4: Expected O, but got I
		//IL_0424: Expected O, but got I4
		//IL_03e0: Expected O, but got I
		//IL_0416: Expected O, but got I4
		//IL_054a: Expected O, but got I4
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected I4, but got Unknown
		base.InitProjectile(pool, weapon, index);
		if (_kanjiFrames != null)
		{
			List<Sprite> kanjiFrames = _kanjiFrames;
			if (kanjiFrames._size != 0)
			{
				goto IL_035c;
			}
		}
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"k_earth");
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
			((List<object>)(object)list).AddWithResize((object)"k_wind");
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
			((List<object>)(object)list).AddWithResize((object)"k_fire");
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
			((List<object>)(object)list).AddWithResize((object)"k_water");
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
			((List<object>)(object)list).AddWithResize((object)"k_void");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(list, "vfx");
		_kanjiFrames = animationFrames;
		goto IL_035c;
		IL_035c:
		bool flag = (object)weapon == null;
		Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_05a3;
		}
		nint num6 = (nint)typeof(FourSeasons2Weapon);
		nint num7 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.FourSeasons2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.FourSeasons2Weapon>)+130]");
		object obj3;
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v49+FFFFFFF8+v164 @ rax_v45*8]");
			if (0 == (nint)typeof(FourSeasons2Weapon))
			{
				obj3 = 1;
				goto IL_05b2;
			}
		}
		obj3 = 0;
		goto IL_05b2;
		IL_05a3:
		_trueWeapon = (FourSeasons2Weapon)trueWeapon;
		_ringRenderer.enabled = false;
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_ringRenderer).SetMaterial(material);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringRenderer, 0.65f);
		_rainbowRenderer.enabled = false;
		Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_rainbowRenderer).SetMaterial(material2);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_rainbowRenderer, 0.65f);
		_raysRenderer.enabled = false;
		Material material3 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_raysRenderer).SetMaterial(material3);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_raysRenderer, 0.65f);
		Initialize();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
		object obj4 = 0 * 2;
		int num9 = index - obj4;
		RenderingExtensions.SetFrame(_fwEmitter, num9);
		OnRecycle();
		return;
		IL_05b2:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = weapon;
		}
		goto IL_05a3;
	}

	private unsafe void Initialize()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected F4, but got Unknown
		//IL_0c3a: Expected O, but got I4
		//IL_0612: Expected O, but got I4
		//IL_0639: Expected O, but got I4
		//IL_0660: Expected O, but got I4
		//IL_0679: Expected O, but got Ref
		//IL_0693: Expected native int or pointer, but got O
		//IL_06ad: Expected O, but got I
		//IL_06cd: Expected O, but got Ref
		//IL_06e7: Expected native int or pointer, but got O
		//IL_0c4d: Expected O, but got I4
		//IL_071a: Expected O, but got Ref
		//IL_0734: Expected native int or pointer, but got O
		//IL_074e: Expected O, but got I
		//IL_076e: Expected O, but got Ref
		//IL_0796: Expected native int or pointer, but got O
		//IL_0c87: Expected O, but got I
		//IL_07ce: Expected O, but got Ref
		//IL_07f5: Expected O, but got I
		//IL_080f: Expected native int or pointer, but got O
		//IL_0cc1: Expected O, but got I
		//IL_0cdf: Expected O, but got I
		//IL_0866: Expected O, but got I
		//IL_0887: Expected O, but got I
		//IL_0d1e: Expected O, but got I
		//IL_0d3f: Expected O, but got I
		//IL_0e65: Expected O, but got I
		//IL_0eae: Expected O, but got I
		//IL_0928->IL0e3e: Incompatible stack heights: 1 vs 0
		//IL_0a09->IL0e3f: Incompatible stack heights: 7 vs 6
		//IL_0a67->IL0e88: Incompatible stack heights: 9 vs 8
		//IL_0ba2->IL0909: Incompatible stack heights: 12 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_initalized)
		{
			return;
		}
		_initalized = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "k_spring");
		PhaserSprite kanji = phaserSprite.setVisible(visible: false);
		_kanji = kanji;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserSprite phaserSprite2 = RenderingExtensions.sprite(s_scene2.add, pos, "vfx", "Lightning3");
		PhaserSprite lightning = phaserSprite2.setVisible(visible: false);
		_lightning = lightning;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene3._renderer;
		int num = -renderer.pixelHeight;
		PhaserSprite phaserSprite3 = _lightning.setDepth(num);
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager particles = gameObject.AddComponent<ParticleEmitterManager>();
		_particles = particles;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene4._renderer;
		float height = renderer2.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num2 = height ^ 0;
		_particles.SetDepthMultiplied(num2);
		int[] array = new int[10] { 0, 1, 2, 3, 0, 1, 3, 0, 1, 3 };
		object obj3 = UnityEngine.Random.RandomRangeInt(0, array.Length);
		_season = array[obj3];
		List<ParticleEmitterManager> seasonParticles = _seasonParticles;
		int version = seasonParticles._version + 1;
		seasonParticles._version = version;
		seasonParticles._size = 0;
		if (seasonParticles._size > 0)
		{
			Array.Clear(seasonParticles._items, 0, seasonParticles._size);
		}
		List<GravityWell> seasonWells = _seasonWells;
		int version2 = seasonWells._version + 1;
		seasonWells._version = version2;
		seasonWells._size = 0;
		if (seasonWells._size > 0)
		{
			Array.Clear(seasonWells._items, 0, seasonWells._size);
		}
		List<ParticleSystem> seasonEmitters = _seasonEmitters;
		int version3 = seasonEmitters._version + 1;
		seasonEmitters._version = version3;
		seasonEmitters._size = 0;
		if (seasonEmitters._size > 0)
		{
			Array.Clear(seasonEmitters._items, 0, seasonEmitters._size);
		}
		List<string> frames = SpriteManager.GenerateFrameNames(0, 47, 4, "rock");
		MakeEmitter_Frames(frames, 0);
		List<string> frames2 = SpriteManager.GenerateFrameNames(0, 43, 4, "spinThick");
		MakeEmitter_Frames(frames2, 1);
		List<string> frames3 = SpriteManager.GenerateFrameNames(0, 24, 4, "fiamma");
		MakeEmitter_Frames(frames3, 2);
		List<string> frames4 = SpriteManager.GenerateFrameNames(0, 23, 4, "icicle");
		MakeEmitter_Frames(frames4, 3);
		List<string> frames5 = SpriteManager.GenerateFrameNames(0, 3, 4, "lightning");
		MakeEmitter_Frames(frames5, 4);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version4 = list._version + 1;
		list._version = version4;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur2");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur3");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 1f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
		_ = 0;
		particleSystemConfig._alphaEase = Easing.OutExpo;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		particleSystemConfig._angleSteps = 8;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 16;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		float2 float5 = (float2)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		_ = 0;
		_ = 0;
		_ = 1098907648;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._fps = 0;
		particleSystemConfig._on = false;
		ParticleSystem fwEmitter = _particles.CreateEmitter(particleSystemConfig);
		_fwEmitter = fwEmitter;
		List<ParticleEmitterManager> seasonParticles2 = _seasonParticles;
		bool flag = _seasonParticles == null;
		int num6 = 0;
		string text = null;
		float2 float6 = default(float2);
		for (int num7 = 0; num7 < seasonParticles2._size; num7 = num6)
		{
			List<ParticleEmitterManager> seasonParticles3 = _seasonParticles;
			bool flag2 = _seasonParticles == null;
			bool flag3 = num6 >= seasonParticles3._size;
			ParticleEmitterManager[] items4 = seasonParticles3._items;
			bool flag4 = seasonParticles3._items == null;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._x = (float?)(object)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._y = (float?)(object)0;
			gravityWellConfig._epsilon = 100f;
			gravityWellConfig._gravity = 50f;
			gravityWellConfig._usePauseSystem = true;
			gravityWellConfig.preCacheParticles = true;
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			bool flag5 = (object)cachedTrans == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ rax_v114 (UnityEngine.Transform)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ rax_v114 (UnityEngine.Transform)+10]");
			float2 ret;
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
			if (body != null)
			{
				BaseBody baseBody = body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				bool flag7 = baseBody._transform == null;
				arcadeTransform.position = ret;
				float5 = float6;
			}
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._x = (float?)(object)0;
			Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
			bool flag8 = (object)cachedTrans2 == null;
			bool flag9 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
			float2 ret2;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
			if (body != null)
			{
				BaseBody baseBody2 = body;
				ArcadeTransform arcadeTransform2 = baseBody2._transform;
				bool flag10 = baseBody2._transform == null;
				arcadeTransform2.position = ret2;
				float5 = ret2;
			}
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			gravityWellConfig._y = (float?)(object)0;
			gravityWellConfig._power = 0.5f;
			gravityWellConfig._epsilon = 40f;
			gravityWellConfig._gravity = 200f;
			bool flag11 = (object)items4[num6] == null;
			GravityWell item = items4[num6].CreateGravityWell(gravityWellConfig);
			List<object> seasonWells2 = (List<object>)(object)_seasonWells;
			bool flag12 = _seasonWells == null;
			int version7 = seasonWells2._version + 1;
			seasonWells2._version = version7;
			text = (string)(object)seasonWells2._items;
			bool flag13 = seasonWells2._items == null;
			int num8 = seasonWells2._size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r9_v36 (System.String)+18]");
			if ((nint)num8 >= (nint)0)
			{
				((List<object>)(object)_seasonWells).AddWithResize((object)item);
			}
			else
			{
				int num9 = seasonWells2._size + 1;
				seasonWells2._size = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			seasonParticles2 = _seasonParticles;
			num6++;
			bool flag14 = _seasonParticles == null;
		}
	}

	private unsafe void MakeEmitter_Frames(List<string> frames, int season)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected F4, but got Unknown
		//IL_00a4: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_0119: Expected O, but got Ref
		//IL_0133: Expected native int or pointer, but got O
		//IL_014d: Expected O, but got I
		//IL_016d: Expected O, but got Ref
		//IL_017c: Expected O, but got I4
		//IL_018a: Expected native int or pointer, but got O
		//IL_0487: Expected O, but got I4
		//IL_01a2: Expected O, but got Ref
		//IL_01ca: Expected native int or pointer, but got O
		//IL_01e4: Expected O, but got I
		//IL_0204: Expected O, but got Ref
		//IL_022c: Expected native int or pointer, but got O
		//IL_04b1: Expected O, but got I
		//IL_0264: Expected O, but got Ref
		//IL_0272: Expected O, but got I4
		//IL_028c: Expected native int or pointer, but got O
		//IL_02d1: Expected O, but got I
		//IL_02fe: Expected O, but got I4
		//IL_0311: Expected O, but got I4
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num = height ^ 0;
		particleEmitterManager.SetDepthMultiplied(num);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		particleSystemConfig._frame = frames;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		particleSystemConfig._fps = 30;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		particleSystemConfig._alphaEase = Easing.InExpo;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		particleSystemConfig._angleSteps = 31;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		particleSystemConfig._quantity = (int?)(object)1;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		_ = 0;
		particleSystemConfig._frequency = (float?)(object)1;
		bool flag = season == 0;
		Array tintRandom;
		uint[] array;
		RuntimeFieldHandle fldHandle;
		if (!flag)
		{
			object obj3 = season - 1;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (!flag)
				{
					object obj5 = obj4 - 1;
					if (!flag)
					{
						if ((nint)obj5 != 1)
						{
							tintRandom = null;
							goto IL_040a;
						}
						array = new uint[4];
						fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						array = new uint[4];
						fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
					}
				}
				else
				{
					array = new uint[4];
					fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				array = new uint[4];
				fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
			}
		}
		else
		{
			array = new uint[4];
			fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
		}
		RuntimeHelpers.InitializeArray(array, fldHandle);
		tintRandom = array;
		goto IL_040a;
		IL_040a:
		particleSystemConfig._tintRandom = (uint[])tintRandom;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = particleEmitterManager.CreateEmitter(particleSystemConfig);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD230");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
	}

	private unsafe void OnRecycle()
	{
		//IL_0023: Expected I, but got O
		//IL_009d: Expected O, but got I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b6: Expected I4, but got O
		//IL_0210: Expected O, but got Ref
		//IL_0167: Expected O, but got I4
		//IL_0991: Expected F4, but got I4
		//IL_03b1: Expected O, but got I
		//IL_0407: Expected I, but got O
		//IL_0445: Expected O, but got I
		//IL_048a: Expected I, but got O
		//IL_04a3: Expected O, but got I4
		//IL_04d8: Expected I, but got O
		//IL_0513: Expected I, but got O
		//IL_05bc: Expected O, but got I
		//IL_0612: Expected I, but got O
		//IL_064d: Expected I, but got O
		//IL_0690: Expected O, but got I
		//IL_06c1: Expected I, but got O
		//IL_0747: Expected O, but got I
		//IL_07aa: Expected O, but got I
		//IL_0820: Expected I, but got O
		//IL_0836: Expected O, but got I
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Expected O, but got Unknown
		//IL_08ba: Expected I, but got O
		//IL_0a63: Expected O, but got I4
		//IL_0a7a: Expected I, but got I8
		//IL_0800: Expected O, but got I4
		//IL_080e: Expected O, but got I4
		//IL_0896: Expected I, but got I8
		object obj = body;
		List<Sprite>.Enumerator enumerator;
		if (body != null)
		{
			nint num = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ rax_v13 (Il2CppClass<System.Object>)+218] (should have been resolved before IL gen)");
			BaseBody baseBody = body;
			bool flag = (nint)body < 0;
			if (body != null)
			{
				baseBody._enable = true;
				ArcadeSprite arcadeSprite = setVisible(visible: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				object obj2 = 0 * 4;
				obj = _indexInWeapon - obj2;
				_season = (int)obj;
				if (!flag)
				{
					List<Sprite> kanjiFrames = _kanjiFrames;
					if (_kanjiFrames == null)
					{
						goto IL_08c6;
					}
					if ((nint)obj < kanjiFrames._size)
					{
						List<ParticleSystem> seasonEmitters = _seasonEmitters;
						if (_seasonEmitters == null)
						{
							goto IL_08c6;
						}
						if ((nint)obj < seasonEmitters._size)
						{
							enumerator = (List<Sprite>.Enumerator)0;
							float num2 = 16f;
							goto IL_0900;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				obj = _kanjiFrames;
				if (_kanjiFrames != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					obj = _seasonEmitters;
					if (_seasonEmitters != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object arg = default(object);
						object arg2 = default(object);
						object arg3 = default(object);
						System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2, arg3);
						System.ParamsArray paramsArray2 = default(System.ParamsArray);
						string message = string.FormatHelper((IFormatProvider)null, "_season ({0}) is an invalid index for either _kanjiFrames (Count = {1}) or _seasonEmitters ({2}) lists.", (System.ParamsArray)(&paramsArray2));
						Debug.LogError(message);
						Debug.Log("[DEBUG] Kanji Frames:");
						bool flag2 = _kanjiFrames == null;
						obj = "[DEBUG] Kanji Frames:";
						if (!flag2)
						{
							List<Sprite>.Enumerator enumerator2 = default(List<Sprite>.Enumerator);
							if (enumerator2.MoveNext())
							{
								UnityEngine.Object obj3 = null;
								throw new NullReferenceException();
							}
							_season = 0;
							enumerator = (List<Sprite>.Enumerator)_kanjiFrames;
							float num2 = 0f;
							goto IL_0900;
						}
					}
				}
			}
		}
		goto IL_08c6;
		IL_0996:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0a5a:
		object obj4 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.5f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		TryDetonate();
		return;
		IL_08c6:
		throw new NullReferenceException();
		IL_0900:
		List<Sprite> kanjiFrames2 = _kanjiFrames;
		int season = _season;
		bool flag3 = _kanjiFrames == null;
		obj = _kanji;
		if (!flag3)
		{
			if (_season >= kanjiFrames2._size)
			{
				goto IL_0996;
			}
			Sprite[] items = kanjiFrames2._items;
			bool flag4 = kanjiFrames2._items == null;
			obj = _kanji;
			if (!flag4)
			{
				bool flag5 = (object)_kanji == null;
				obj = _kanji;
				if (!flag5)
				{
					PhaserSprite phaserSprite = _kanji.setFrame(items[season]);
					obj = _seasonEmitters;
					int season2 = _season;
					if (_seasonEmitters != null)
					{
						int season3 = _season;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+18]");
						if ((nint)season3 >= (nint)0)
						{
							goto IL_0996;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+10]");
						obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							obj = _trueWeapon;
							if ((object)_trueWeapon != null)
							{
								nint num3 = (nint)obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1010 @ rdx_v11 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
								float num4 = (float)enumerator * 16f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+20+v446 @ rax_v25 (System.Int32)*8]");
								int quantity = default(int);
								RenderingExtensions.SetQuantity((ParticleSystem)0, quantity);
								ArcadeSprite arcadeSprite2 = setAlpha(1f);
								obj = _weapon;
								if ((object)_weapon != null)
								{
									nint num5 = (nint)obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1039 @ rdx_v14 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
									ArcadeSprite arcadeSprite3 = setScale(num4, (float?)(object)0);
									obj = _weapon;
									if ((object)_weapon != null)
									{
										nint num6 = (nint)obj;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1043 @ rdx_v16 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
										obj = _weapon;
										if ((object)_weapon != null)
										{
											nint num7 = (nint)obj;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1045 @ rdx_v18 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
											float num8 = num4 * 100f;
											float min = num4 * 50f;
											RenderingExtensions.SetSpeed(_fwEmitter, min, num8);
											obj = _seasonEmitters;
											int season4 = _season;
											if (_seasonEmitters != null)
											{
												int season5 = _season;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+18]");
												if ((nint)season5 >= (nint)0)
												{
													goto IL_0996;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+10]");
												obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+10]");
												if ((nint)0 != 0)
												{
													obj = _weapon;
													if ((object)_weapon != null)
													{
														nint num9 = (nint)obj;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1049 @ rdx_v20 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
														obj = _weapon;
														if ((object)_weapon != null)
														{
															nint num10 = (nint)obj;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1051 @ rdx_v22 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
															float num11 = num8 * 10f;
															float min2 = num8 * 5f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+20+v450 @ rax_v40 (System.Int32)*8]");
															RenderingExtensions.SetSpeed((ParticleSystem)0, min2, num11);
															obj = _weapon;
															if ((object)_weapon != null)
															{
																nint num12 = (nint)obj;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1055 @ rdx_v24 (Il2CppClass<System.Object>)+3E8] (should have been resolved before IL gen)");
																float num13 = num11 * 16f;
																bool flag6 = 32f > num13;
																float radius = 32f;
																if (!flag6)
																{
																	radius = num13;
																}
																Circle circle = new Circle();
																circle._x = 0f;
																circle._radius = radius;
																obj = _seasonEmitters;
																int season6 = _season;
																if (_seasonEmitters != null)
																{
																	int season7 = _season;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+18]");
																	if ((nint)season7 >= (nint)0)
																	{
																		goto IL_0996;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+10]");
																	obj = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+10]");
																	if ((nint)0 != 0)
																	{
																		EmitZone emitZone = new EmitZone();
																		emitZone._type = EmitZoneType.Random;
																		emitZone._source = circle;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v7 (System.Object)+20+v453 @ rax_v49 (System.Int32)*8]");
																		RenderingExtensions.SetEmitZone((ParticleSystem)0, emitZone);
																		_isCullable = false;
																		Timer expireTimer2 = _expireTimer;
																		if (_expireTimer != null && !_expireTimer.IsDone)
																		{
																			float timeElapsed = _expireTimer.GetTimeElapsed();
																			expireTimer2._timeElapsedBeforeCancel = (float?)(object)1;
																			expireTimer2._timeElapsedBeforePause = (float?)(object)0;
																		}
																		action = null;
																		nint num14 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ r10_v2 (Il2CppMethodInfo)+8]");
																		((Delegate)action).method_ptr = (IntPtr)0;
																		((Delegate)action).method = (nint)__ldftn(FourSeasons2Projectile._003COnRecycle_003Eb__27_0);
																		((Delegate)action).m_target = this;
																		((Delegate)action).method_code = (IntPtr)action;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ r10_v2 (Il2CppMethodInfo)+4C]");
																		object obj5 = (nint)0 >> 4;
																		object obj6 = obj5 & 1;
																		nint num15;
																		if (obj6 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ r10_v2 (Il2CppMethodInfo)+52]");
																			if ((nint)0 == 0)
																			{
																				num15 = unchecked((nint)6447293664L);
																				goto IL_0a5a;
																			}
																		}
																		num15 = ((Delegate)action).method_ptr;
																		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
																		goto IL_0a5a;
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
						}
					}
				}
			}
		}
		goto IL_08c6;
	}

	private unsafe void TryDetonate()
	{
		//IL_006b: Expected I4, but got I8
		//IL_0979: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_01d2: Expected I4, but got I8
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_069b: Expected I, but got O
		//IL_06ff: Expected O, but got I4
		//IL_0273: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_03d2: Expected I, but got O
		//IL_0832: Expected I, but got O
		//IL_0428: Expected O, but got I4
		//IL_0444: Expected O, but got I4
		//IL_089b: Expected O, but got I4
		//IL_053f: Expected I, but got O
		//IL_05a3: Expected O, but got I4
		List<ParticleSystem> seasonEmitters = _seasonEmitters;
		int season = _season;
		float durationMillis;
		SfxType sfxType;
		if (_season < seasonEmitters._size)
		{
			ParticleSystem[] items = seasonEmitters._items;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(items[season], pos, -1);
			bool flag = _season == 0;
			durationMillis = 500f;
			sfxType = SfxType.Seasons2;
			if (!flag)
			{
				object obj = _season - 1;
				if (flag)
				{
					sfxType = SfxType.Seasons3;
					goto IL_097e;
				}
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						bool flag2 = (nint)obj3 != 1;
						durationMillis = 500f;
						sfxType = SfxType.Seasons2;
						if (!flag2)
						{
							sfxType = SfxType.Seasons6;
							goto IL_097e;
						}
					}
					else
					{
						durationMillis = 500f;
						sfxType = SfxType.Seasons5;
					}
				}
				else
				{
					durationMillis = 500f;
					sfxType = SfxType.Seasons4;
				}
			}
			goto IL_0954;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_097e:
		durationMillis = 6000f;
		goto IL_0954;
		IL_0954:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, durationMillis, 1, time);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag3 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
		int num = -1;
		int num2 = 1;
		if (!flag3)
		{
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = _ringRenderer.transform;
			if ((object)transform != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				_ringRenderer.enabled = true;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				_ringRenderer.enabled = false;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
			if (_tween2 != null)
			{
				_tween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Transform transform2 = _rainbowRenderer.transform;
			if ((object)transform2 != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.scale = (float?)(object)1;
			tweenConfig2.duration = 250f;
			tweenConfig2.angle = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				//IL_004f: Expected O, but got Ref
				_rainbowRenderer.enabled = true;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
				Transform transform4 = _rainbowRenderer.transform;
				object obj9 = default(object);
				transform4.localEulerAngles = (Vector3)(&obj9);
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete2 = delegate
			{
				_rainbowRenderer.enabled = false;
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
			_tween2 = tween2;
			if (_tween3 != null)
			{
				_tween3.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			Transform transform3 = _raysRenderer.transform;
			if ((object)transform3 != null)
			{
				nint num5 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 60f;
			tweenConfig3.scale = (float?)(object)1;
			TweenCallback onStart3 = delegate
			{
				//IL_004f: Expected O, but got Ref
				_raysRenderer.enabled = true;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_raysRenderer, 0f);
				Transform transform4 = _raysRenderer.transform;
				object obj9 = default(object);
				transform4.localEulerAngles = (Vector3)(&obj9);
			};
			tweenConfig3.onStart = onStart3;
			TweenCallback onComplete3 = delegate
			{
				_raysRenderer.enabled = false;
			};
			tweenConfig3.onComplete = onComplete3;
			num = 0;
			MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
			_tween3 = tween3;
			num2 = 0;
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)_kanji != null)
		{
			nint num6 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.duration = 200f;
		tweenConfig4.scale = (float?)(object)1;
		TweenCallback onStart4 = delegate
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite = _kanji.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _kanji.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _kanji.setAlpha(1f);
			PhaserSprite phaserSprite4 = _kanji.setTint(16777215u);
		};
		tweenConfig4.onStart = onStart4;
		TweenCallback onComplete4 = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00c2: Expected O, but got I4
			//IL_00d0: Expected O, but got I4
			//IL_00de: Expected O, but got I4
			if (_tween5 != null)
			{
				_tween5.Kill();
			}
			TweenConfig tweenConfig6 = new TweenConfig();
			object[] array6 = new object[1];
			if ((object)_kanji != null)
			{
				nint num8 = (nint)array6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 == null)
				{
					ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
					throw ex6;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig6.targets = array6;
			tweenConfig6.duration = 200f;
			tweenConfig6.scale = (float?)(object)1;
			tweenConfig6.alpha = (float?)(object)1;
			tweenConfig6.tint = (uint?)(object)1;
			MultiTargetTween tween5 = Tweens.Add(tweenConfig6);
			_tween5 = tween5;
		};
		tweenConfig4.onComplete = onComplete4;
		TweenCallback onUpdate = delegate
		{
			float2 float6 = base.position;
			PhaserSprite phaserSprite = _kanji.setPosition(float6);
		};
		tweenConfig4.onUpdate = onUpdate;
		MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
		_tween4 = tween4;
		if (_season != 4)
		{
			return;
		}
		if (_tweenLightning != null)
		{
			_tweenLightning.Kill();
		}
		TweenConfig tweenConfig5 = new TweenConfig();
		object[] array5 = new object[1];
		if ((object)_lightning != null)
		{
			nint num7 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig5.targets = array5;
		tweenConfig5.duration = 100f;
		tweenConfig5.scale = (float?)(object)1;
		TweenCallback onStart5 = delegate
		{
			//IL_0047: Expected O, but got I4
			PhaserSprite phaserSprite = _lightning.setTint(16777215u);
			PhaserSprite phaserSprite2 = _lightning.setVisible(visible: true);
			PhaserSprite phaserSprite3 = _lightning.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = _lightning.setAlpha(1f);
		};
		tweenConfig5.onStart = onStart5;
		TweenCallback onComplete5 = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00c2: Expected O, but got I4
			//IL_00d0: Expected O, but got I4
			if (_tweenLightningReturn != null)
			{
				_tweenLightningReturn.Kill();
			}
			TweenConfig tweenConfig6 = new TweenConfig();
			object[] array6 = new object[1];
			if ((object)_lightning != null)
			{
				nint num8 = (nint)array6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 == null)
				{
					ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
					throw ex6;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig6.targets = array6;
			tweenConfig6.duration = 100f;
			tweenConfig6.alpha = (float?)(object)1;
			tweenConfig6.tint = (uint?)(object)1;
			MultiTargetTween tweenLightningReturn = Tweens.Add(tweenConfig6);
			_tweenLightningReturn = tweenLightningReturn;
		};
		tweenConfig5.onComplete = onComplete5;
		TweenCallback onUpdate2 = delegate
		{
			float2 float6 = base.position;
			PhaserSprite phaserSprite = _lightning.setPosition(float6);
		};
		tweenConfig5.onUpdate = onUpdate2;
		MultiTargetTween tweenLightning = Tweens.Add(tweenConfig5);
		_tweenLightning = tweenLightning;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_0114: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_019f->IL020e: Incompatible stack heights: 1 vs 0
		//IL_01d6->IL020e: Incompatible stack heights: 1 vs 0
		//IL_02fc->IL020e: Incompatible stack heights: 3 vs 0
		//IL_03ac->IL020e: Incompatible stack heights: 6 vs 0
		//IL_020d->IL03b1: Incompatible stack heights: 6 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			if (!baseBody._enable)
			{
				return;
			}
			FourSeasons2Weapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon != null && trueWeapon._positions != null)
			{
				float2 float5 = default(float2);
				base.position = float5;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						float height = renderer.height;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj = height ^ 0;
						float num = (float)obj * 100f;
						ArcadeSprite arcadeSprite = setDepth(num);
						List<GravityWell> seasonWells = _seasonWells;
						bool flag = _seasonWells == null;
						object obj2 = 0;
						object obj3 = 0;
						if (!flag)
						{
							float2 value = default(float2);
							while (true)
							{
								if ((nint)obj3 < seasonWells._size)
								{
									List<GravityWell> seasonWells2 = _seasonWells;
									if (_seasonWells == null)
									{
										break;
									}
									bool flag2 = (nint)obj2 >= seasonWells2._size;
									GravityWell[] items = seasonWells2._items;
									if (seasonWells2._items == null)
									{
										break;
									}
									object obj4 = items[obj2];
									if ((object)items[obj2] == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbx_v16 (System.Object)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbx_v16 (System.Object)+10]");
									IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
									Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
									if ((object)transform2 == null)
									{
										break;
									}
									bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									float2 ret;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
									bool flag6 = (object)transform == null;
									bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
									seasonWells = _seasonWells;
									obj2++;
									if (_seasonWells == null)
									{
										break;
									}
									obj3 = obj2;
									continue;
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

	public override void Despawn()
	{
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			baseBody._enable = false;
			Action onComplete = delegate
			{
				_isCullable = true;
				base.Despawn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public FourSeasons2Projectile()
	{
		List<ParticleEmitterManager> seasonParticles = new List<ParticleEmitterManager>();
		_seasonParticles = seasonParticles;
		_seasonEmitters = new List<ParticleSystem>();
		_seasonWells = new List<GravityWell>();
		base._002Ector();
	}

	private void _003COnRecycle_003Eb__27_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Despawn();
	}

	private void _003CTryDetonate_003Eb__28_0()
	{
		_ringRenderer.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
	}

	private void _003CTryDetonate_003Eb__28_1()
	{
		_ringRenderer.enabled = false;
	}

	private unsafe void _003CTryDetonate_003Eb__28_2()
	{
		//IL_004f: Expected O, but got Ref
		_rainbowRenderer.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
		Transform transform = _rainbowRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CTryDetonate_003Eb__28_3()
	{
		_rainbowRenderer.enabled = false;
	}

	private unsafe void _003CTryDetonate_003Eb__28_4()
	{
		//IL_004f: Expected O, but got Ref
		_raysRenderer.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_raysRenderer, 0f);
		Transform transform = _raysRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CTryDetonate_003Eb__28_5()
	{
		_raysRenderer.enabled = false;
	}

	private void _003CTryDetonate_003Eb__28_6()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _kanji.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _kanji.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _kanji.setAlpha(1f);
		PhaserSprite phaserSprite4 = _kanji.setTint(16777215u);
	}

	private void _003CTryDetonate_003Eb__28_7()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		if (_tween5 != null)
		{
			_tween5.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_kanji != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.tint = (uint?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween5 = tween;
	}

	private void _003CTryDetonate_003Eb__28_8()
	{
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _kanji.setPosition(float5);
	}

	private void _003CTryDetonate_003Eb__28_9()
	{
		//IL_0047: Expected O, but got I4
		PhaserSprite phaserSprite = _lightning.setTint(16777215u);
		PhaserSprite phaserSprite2 = _lightning.setVisible(visible: true);
		PhaserSprite phaserSprite3 = _lightning.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite4 = _lightning.setAlpha(1f);
	}

	private void _003CTryDetonate_003Eb__28_10()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		if (_tweenLightningReturn != null)
		{
			_tweenLightningReturn.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_lightning != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.tint = (uint?)(object)1;
		MultiTargetTween tweenLightningReturn = Tweens.Add(tweenConfig);
		_tweenLightningReturn = tweenLightningReturn;
	}

	private void _003CTryDetonate_003Eb__28_11()
	{
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _lightning.setPosition(float5);
	}

	private void _003CDespawn_003Eb__30_0()
	{
		_isCullable = true;
		base.Despawn();
	}
}
