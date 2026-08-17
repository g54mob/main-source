using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GrangattiProjectile : Projectile
{
	private ParticleEmitterManager _pfxEmitter;

	private Weapon _trueWeapon;

	private VampireSurvivors.Framework.TimerSystem.Timer _chooseTimer;

	private float _save_vel_x;

	private float _save_vel_y;

	private Vector2 _aimVec;

	private VampireSurvivors.Framework.TimerSystem.Timer _expireTimer;

	private MultiTargetTween _onExpireAlphaTween;

	private SpriteRenderer _summon;

	private MultiTargetTween _summonTween;

	private float _defaultSpeed;

	private MultiTargetTween _entryTween;

	private Circle _explosionCircle;

	private ParticleEmitterManager _pfxEmitter2;

	private List<Vector2> _ellipsePoints;

	private VampireSurvivors.Framework.TimerSystem.Timer _hitboxTimer;

	private SpriteAnimation _anims;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0405: Expected O, but got Ref
		//IL_041f: Expected native int or pointer, but got O
		//IL_0439: Expected O, but got I
		//IL_0459: Expected O, but got Ref
		//IL_0473: Expected native int or pointer, but got O
		//IL_0d7b: Expected O, but got I4
		//IL_04b1: Expected O, but got I
		//IL_04cd: Expected O, but got I4
		//IL_04e6: Expected O, but got Ref
		//IL_0500: Expected native int or pointer, but got O
		//IL_0db5: Expected O, but got I
		//IL_0538: Expected O, but got Ref
		//IL_0552: Expected native int or pointer, but got O
		//IL_0def: Expected O, but got I
		//IL_09c7: Expected O, but got Ref
		//IL_09e1: Expected native int or pointer, but got O
		//IL_09fb: Expected O, but got I
		//IL_0a1b: Expected O, but got Ref
		//IL_0a35: Expected native int or pointer, but got O
		//IL_0a5d: Expected O, but got I
		//IL_0e3b: Expected O, but got I
		//IL_0a89: Expected O, but got I
		//IL_0aa5: Expected O, but got I4
		//IL_0abe: Expected O, but got Ref
		//IL_0ad8: Expected native int or pointer, but got O
		//IL_0e75: Expected O, but got I
		//IL_0b10: Expected O, but got Ref
		//IL_0b2a: Expected native int or pointer, but got O
		//IL_0eaf: Expected O, but got I
		//IL_0ef5: Expected O, but got I
		//IL_0bbe: Expected O, but got I4
		//IL_0c5c: Expected I4, but got O
		//IL_0c8e: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 24f;
		_explosionCircle = circle;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"SmokeB1");
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
			((List<object>)(object)list).AddWithResize((object)"SmokeB2");
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
			((List<object>)(object)list).AddWithResize((object)"SmokeB3");
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
			((List<object>)(object)list).AddWithResize((object)"SmokeB4");
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
			((List<object>)(object)list).AddWithResize((object)"SmokeB5");
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
			((List<object>)(object)list).AddWithResize((object)"SmokeB6");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(15f, 30f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(750f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _pfxEmitter.CreateEmitter(particleSystemConfig);
		GameObject gameObject2 = base.gameObject;
		ParticleEmitterManager pfxEmitter2 = gameObject2.AddComponent<ParticleEmitterManager>();
		_pfxEmitter2 = pfxEmitter2;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version7 = list2._version + 1;
		list2._version = version7;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"SmokeB1");
		}
		else
		{
			int num7 = list2._size + 1;
			list2._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list2._version + 1;
		list2._version = version8;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"SmokeB2");
		}
		else
		{
			int num8 = list2._size + 1;
			list2._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list2._version + 1;
		list2._version = version9;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"SmokeB3");
		}
		else
		{
			int num9 = list2._size + 1;
			list2._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list2._version + 1;
		list2._version = version10;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"SmokeB4");
		}
		else
		{
			int num10 = list2._size + 1;
			list2._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list2._version + 1;
		list2._version = version11;
		string[] items11 = list2._items;
		if (list2._size >= items11.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"SmokeB5");
		}
		else
		{
			int num11 = list2._size + 1;
			list2._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list2._version + 1;
		list2._version = version12;
		string[] items12 = list2._items;
		if (list2._size >= items12.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"SmokeB6");
		}
		else
		{
			int num12 = list2._size + 1;
			list2._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(15f, 30f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1C0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(750f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
		_ = 0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Edge;
		emitZone2._source = _explosionCircle;
		_ = 0;
		_ = 48;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1C0]");
		emitZone2._quantity = (int?)(object)0;
		emitZone2._yoyo = false;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem particleSystem2 = _pfxEmitter2.CreateEmitter(particleSystemConfig2);
		_defaultSpeed = _speed;
		_aimVec = (Vector2)0;
		GameObject gameObject3 = base.gameObject;
		string text = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject3, 0f, 0f, "vfx", text);
		spriteRenderer.enabled = false;
		_summon = spriteRenderer;
		GameObject gameObject4 = _renderer.gameObject;
		SpriteAnimation anims = gameObject4.AddComponent<SpriteAnimation>();
		_anims = anims;
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("eyeanim_", 0, 29, "vfx", (int)text);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anims.AddAnimation("idle", animationFrames, 16, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
		_anims.SetAnimation("idle");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Ellipse ellipse = new Ellipse();
		ellipse._width = renderer.width;
		ellipse._height = renderer2.height;
		ellipse._x = 0f;
		List<Vector2> points = ellipse.GetPoints(5);
		_ellipsePoints = points;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00be: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_024a: Expected I, but got O
		//IL_02ce: Expected I, but got O
		//IL_0486: Expected I, but got O
		//IL_04d2: Expected O, but got I4
		//IL_04ed: Expected O, but got I
		//IL_0a95: Expected O, but got F4
		//IL_0b12: Invalid comparison between F4 and I4
		//IL_0b61: Expected O, but got Ref
		//IL_0bbc: Expected O, but got Ref
		//IL_09cd: Expected I4, but got O
		//IL_06b3: Expected O, but got I
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected O, but got Unknown
		//IL_070d: Expected O, but got F4
		//IL_0c8d: Expected O, but got Ref
		//IL_0cce: Expected O, but got I
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Expected O, but got Unknown
		//IL_099d: Expected O, but got I
		//IL_09be: Expected F4, but got I4
		//IL_0666->IL0a18: Incompatible stack heights: 4 vs 0
		//IL_073c->IL0a18: Incompatible stack heights: 4 vs 0
		//IL_080f->IL0a18: Incompatible stack heights: 4 vs 0
		//IL_0d35->IL0c33: Incompatible stack heights: 5 vs 4
		//IL_08d2->IL0a18: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		if (_summonTween != null)
		{
			_summonTween.Kill();
		}
		if (_entryTween != null)
		{
			_entryTween.Kill();
		}
		if (_onExpireAlphaTween != null)
		{
			_onExpireAlphaTween.Kill();
		}
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		_ = 0;
		_ = 1056964608;
		_ = 1;
		_isCullable = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setScale(1f, (float?)(object)0);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(14f, (float?)(object)0, (float?)(object)0);
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float num2 = default(float);
				ArcadeSprite arcadeSprite4 = setScale(num2, (float?)(object)0);
				ArcadeSprite arcadeSprite5 = setAlpha(0.7f);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_summon, 0f);
				if ((object)spriteRenderer != null)
				{
					spriteRenderer.enabled = true;
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 1f);
					ArcadeSprite arcadeSprite6 = setTint(16777215u);
					_speed = _defaultSpeed;
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[2];
					if (array != null)
					{
						if ((object)_summon != null)
						{
							nint num3 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj3 = default(object);
							if (obj3 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if ((object)_summon != null)
						{
							Transform transform = _summon.transform;
							if ((object)transform != null)
							{
								nint num4 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj4 = default(object);
								if (obj4 == null)
								{
									ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
									throw ex2;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null && (object)_weapon != null)
							{
								_ = 0;
								float num5 = _weapon.PArea();
								_ = 1;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
								_ = 0;
								_ = 1148846080;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
								_ = 0;
								MultiTargetTween summonTween = Tweens.Add(tweenConfig);
								_summonTween = summonTween;
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								Transform transform2 = base.transform;
								if (array2 != null)
								{
									if ((object)transform2 != null)
									{
										int value = ((int*)(&array2))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj5 = default(object);
										if (obj5 == null)
										{
											ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
											throw ex3;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
										if ((object)_weapon != null)
										{
											_ = 0;
											float num6 = _weapon.PArea();
											((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1133903872;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
											((Weapon)(object)tweenConfig2)._gameSessionData = (GameSessionData)0;
											TweenCallback currentJsonDataObject = delegate
											{
												//IL_0015: Expected O, but got I4
												ArcadeSprite arcadeSprite7 = setScale(0f, (float?)(object)1);
											};
											((Equipment)(object)tweenConfig2)._currentJsonDataObject = (JObject)(object)currentJsonDataObject;
											MultiTargetTween entryTween = Tweens.Add(tweenConfig2);
											_entryTween = entryTween;
											object obj6 = UnityEngine.Random.value;
											float num7 = num2 * ((float)Math.PI * 2f);
											float2 float5 = base.position;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												Weapon typeFromHandle = (Weapon)(object)typeof(ArcadePhysics);
												VampireSurvivors.Framework.TimerSystem.Timer firingAnimEvent = typeFromHandle._firingAnimEvent;
												float num8 = firingAnimEvent._003CDuration_003Ek__BackingField;
												if (firingAnimEvent._003CDuration_003Ek__BackingField != 0f)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v74 (System.Single)+28]");
													if ((nint)0 != 0)
													{
														float2 float6 = default(float2);
														base.position = float6;
														if ((object)_summon != null)
														{
															Transform transform3 = _summon.transform;
															Transform transform4 = base.transform;
															if ((object)transform4 != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v97 (UnityEngine.Transform)+10]");
																bool flag = (nint)0 == 0;
																object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v97 (UnityEngine.Transform)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
																bool flag2 = (object)transform3 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
																_ = 0;
																bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj8);
																Weapon weapon2 = _weapon;
																_save_vel_x = 1f;
																_save_vel_y = 1f;
																bool flag4 = (object)_weapon == null;
																float2 float9;
																if (!weapon2.IsHoming)
																{
																	if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
																	{
																		goto IL_0a18;
																	}
																	float2 float7 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
																	float2 float8 = base.position;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
																	nint num9 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6B]");
																	object obj9 = num9 - 0;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
																	float projectileSpeed = base.ProjectileSpeed;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
																	float9 = float6 * 0;
																	float num10 = (float)float6;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																	float num11 = num10 * 0f;
																	_aimVec = (Vector2)num11;
																}
																else
																{
																	int num12 = (int)base.GetNearestEnemyTransform();
																	bool flag5 = num12 == 0;
																	float9 = float6;
																	if (!flag5)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1914 @ rax_v148 (System.Int32)+10]");
																		bool flag6 = (nint)0 == 0;
																		float9 = float6;
																		if (!flag6)
																		{
																			_ = 0;
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1914 @ rax_v148 (System.Int32)+10]");
																			bool flag7 = (nint)0 == 0;
																			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1914 @ rax_v148 (System.Int32)+10]");
																			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj10);
																			float2 float10 = base.position;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-2D]");
																			nint num13 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
																			object obj11 = num13 - 0;
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
																			float projectileSpeed2 = base.ProjectileSpeed;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																			Vector2 aimVec = (Vector2)(0 * float6);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
																			float num14 = 0f * (float)float6;
																			_aimVec = aimVec;
																			float9 = float6;
																		}
																	}
																}
																if (_chooseTimer != null)
																{
																	_chooseTimer.Cancel();
																}
																if ((object)_weapon != null)
																{
																	float num15 = _weapon.PSpeed();
																	Action onComplete = delegate
																	{
																		ChooseTarget();
																	};
																	float num16 = 1500f / (float)float9;
																	float num17 = num16 * 0.001f;
																	bool flag8 = default(bool);
																	MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																	int repeat = default(int);
																	TimerType type = default(TimerType);
																	VampireSurvivors.Framework.TimerSystem.Timer chooseTimer = Timers.Register(num17, onComplete, null, isLooped: true, flag8, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																	_chooseTimer = chooseTimer;
																	if (_expireTimer != null)
																	{
																		_expireTimer.Cancel();
																	}
																	if ((object)_weapon != null)
																	{
																		float num18 = _weapon.PDuration();
																		Action onComplete2 = delegate
																		{
																			onExpireTimer();
																		};
																		float duration = num17 * 0.001f;
																		VampireSurvivors.Framework.TimerSystem.Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, flag8, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																		_expireTimer = expireTimer;
																		if (_hitboxTimer != null)
																		{
																			_hitboxTimer.Cancel();
																		}
																		if ((object)_weapon != null)
																		{
																			float hitBoxDelay = _weapon.HitBoxDelay;
																			Action onComplete3 = delegate
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																			};
																			float duration2 = hitBoxDelay * 0.001f;
																			VampireSurvivors.Framework.TimerSystem.Timer hitboxTimer = Timers.Register(duration2, onComplete3, null, isLooped: true, flag8, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_hitboxTimer = hitboxTimer;
																			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																			_ = 0;
																			_ = 1045220557;
																			_ = 1;
																			soundConfig.Rate = 1f;
																			soundConfig.Detune = -1000f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																			soundConfig.Volume = (float?)(object)0;
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 12, flag8 ? 1 : 0);
																			return;
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
		}
		goto IL_0a18;
		IL_0a18:
		throw new NullReferenceException();
	}

	private void onExpireTimer()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween onExpireAlphaTween = Tweens.Add(tweenConfig);
		_onExpireAlphaTween = onExpireAlphaTween;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I8
		//IL_01ce: Expected O, but got I4
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_0163: Expected O, but got I8
		//IL_0132: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Expected O, but got I4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_0168;
			}
		}
		obj5 = 4294967295L;
		goto IL_0168;
		IL_01e9:
		object obj6;
		float save_vel_y = (float)obj6 * _save_vel_y;
		_save_vel_y = save_vel_y;
		return;
		IL_0168:
		float save_vel_x = (float)obj5 * _save_vel_x;
		_save_vel_x = save_vel_x;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_01e9;
			}
		}
		obj6 = 4294967295L;
		goto IL_01e9;
	}

	public void TargetPlayer()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = base.position;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float projectileSpeed = base.ProjectileSpeed;
		object obj4 = default(object);
		object obj5 = default(object);
		Vector2 aimVec = (Vector2)(obj4 * obj5);
		object obj6 = obj2 * obj5;
		_aimVec = aimVec;
	}

	public unsafe void ChooseTarget()
	{
		//IL_002c: Expected I, but got O
		//IL_0127: Expected O, but got I
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		//IL_057a: Expected O, but got I
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Expected I, but got Unknown
		//IL_067b: Expected O, but got I
		//IL_02c6: Expected O, but got I
		//IL_042e: Expected O, but got I
		//IL_0437: Expected O, but got I4
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_035c: Expected O, but got I4
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected I, but got Unknown
		//IL_0704: Expected O, but got I
		//IL_070d: Expected O, but got I4
		//IL_0788->IL0620: Incompatible stack heights: 0 vs 1
		//IL_061b->IL0620: Incompatible stack heights: 0 vs 1
		//IL_01ee->IL0620: Incompatible stack heights: 0 vs 1
		//IL_03e0->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_0402->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_043c->IL0712: Incompatible stack heights: 1 vs 0
		//IL_039e->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_0712->IL0712: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		object obj7 = default(object);
		if ((object)_weapon != null)
		{
			object obj2 = default(object);
			object obj4 = default(object);
			if (weapon.IsHoming)
			{
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v77 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GrangattiProjectile>)+3E0]");
				nint num2 = 0;
				Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
				if ((object)nearestEnemyTransform != null && ((UnityEngine.Object)nearestEnemyTransform).m_CachedPtr != (IntPtr)0)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)nearestEnemyTransform).m_CachedPtr == (IntPtr)0;
					object obj = obj2 - 56;
					Transform.get_position_Injected(((UnityEngine.Object)nearestEnemyTransform).m_CachedPtr, out *(Vector3*)obj);
					float2 float5 = base.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+1C]");
					object obj3 = num3 - 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
					float projectileSpeed = base.ProjectileSpeed;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
					Vector2 aimVec = (Vector2)(0 * obj4);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+1C]");
					object obj5 = 0 * obj4;
					_aimVec = aimVec;
					return;
				}
			}
			_ = 0;
			_ = 0;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				PhysicsManager physicsManager = core._physicsManager;
				if (core._physicsManager != null)
				{
					ICollection<PhaserGameObject> pickupGroup = (ICollection<PhaserGameObject>)physicsManager._pickupGroup;
					if (physicsManager._pickupGroup != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+18]");
						ICollection<PhaserGameObject> collection = (ICollection<PhaserGameObject>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v12 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+20]");
							if ((nint)0 <= (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
								Weapon weapon2 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
								{
									float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
									goto IL_0712;
								}
							}
							else
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
								{
									ArcadePhysics physics = s_scene.physics;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+18]");
									PhaserGameObject phaserGameObject = physics.closest(this, (ICollection<PhaserGameObject>)0);
									if ((object)phaserGameObject == null)
									{
										return;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v40 (PhaserGameObject)+10]");
									if ((nint)0 == 0)
									{
										return;
									}
									GameManager core2 = GM.Core;
									if ((object)GM.Core != null)
									{
										Stage stage = core2._stage;
										if ((object)core2._stage != null)
										{
											Transform transform = phaserGameObject.transform;
											if ((object)transform != null)
											{
												_ = 0;
												_ = 0;
												bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												nint num2 = (nint)(obj2 - 56);
												Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)num2);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-38]");
												object obj6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-38]");
												if (0 >= (nint)stage._containmentScreenRect)
												{
													obj7 = obj4 + (object)stage._containmentScreenRect;
													object obj8 = obj7;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-38]");
													if ((nint)obj8 > 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
														obj6 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
														bool flag3 = 0 < (nint)obj4;
														obj7 = obj4;
														if (!flag3)
														{
															obj7 = obj4 + obj4;
															object obj9 = obj7;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
															bool flag4 = (nint)obj9 < 0;
															object obj10 = obj7;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
															object obj11 = obj10 - 0;
															bool flag5 = obj11 == null;
															bool flag6 = !flag4;
															bool flag7 = !flag5;
															object obj12 = flag7 & flag6;
															if (obj12 != null)
															{
																Transform transform2 = phaserGameObject.transform;
																if ((object)transform2 == null)
																{
																	goto IL_04b2;
																}
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v61 (UnityEngine.Transform)+10]");
																bool flag8 = (nint)0 == 0;
																num2 = (nint)(obj2 - 56);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v61 (UnityEngine.Transform)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)num2);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+18]");
																ICollection<PhaserGameObject> collection2 = (ICollection<PhaserGameObject>)0;
																object obj13 = 0;
																goto IL_0712;
															}
														}
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
												Weapon weapon3 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
												{
													float2 float7 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.ICollection`1<PhaserGameObject>)+18]");
													ICollection<PhaserGameObject> collection2 = (ICollection<PhaserGameObject>)0;
													object obj13 = 0;
													goto IL_0712;
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
		goto IL_04b2;
		IL_04b2:
		throw new NullReferenceException();
		IL_0712:
		float2 float8 = base.position;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float projectileSpeed2 = base.ProjectileSpeed;
		object obj14 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
		Vector2 vector = (_aimVec = (Vector2)(obj14 * 0));
		float projectileSpeed3 = base.ProjectileSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+1C]");
		object obj15 = vector * 0;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_03df: Expected O, but got I
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		float2 float5 = base.position;
		bool flag = _indexInWeapon >= 6;
		IntPtr intPtr = default(IntPtr);
		Vector2 vector = (Vector2)(nint)intPtr;
		if (flag)
		{
			goto IL_0078;
		}
		if ((object)_pfxEmitter != null)
		{
			Vector2 vector2 = default(Vector2);
			_pfxEmitter.EmitParticleAt(vector2);
			if ((object)_pfxEmitter2 != null)
			{
				_pfxEmitter2.EmitParticleAt(vector2);
				vector = vector2;
				goto IL_0078;
			}
		}
		goto IL_03b2;
		IL_03b2:
		throw new NullReferenceException();
		IL_0078:
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			object obj2 = default(object);
			object obj = obj2 - obj2;
			float num = (float)obj - 0.32f;
			float num2 = num * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			if ((object)_renderer != null)
			{
				int sortingOrder = default(int);
				_renderer.sortingOrder = sortingOrder;
				float num3 = num - 0.02f;
				float num4 = num3 * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				if ((object)_summon != null)
				{
					int sortingOrder2 = default(int);
					_summon.sortingOrder = sortingOrder2;
					if ((object)_pfxEmitter != null)
					{
						float num5 = num - 0.01f;
						_pfxEmitter.SetDepthMultiplied(num5);
						if ((object)_pfxEmitter2 != null)
						{
							float num6 = num + 0.01f;
							_pfxEmitter2.SetDepthMultiplied(num6);
							float2 velocity = (float2)(_aimVec * _save_vel_x);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.GrangattiProjectile)+F4]");
							object obj3 = 0 * _save_vel_y;
							ArcadeSprite sprite = _sprite;
							if ((object)_sprite != null)
							{
								BaseBody baseBody = sprite.body;
								if (sprite.body != null)
								{
									baseBody._velocity = velocity;
									BaseBody baseBody2 = body;
									if (body != null)
									{
										bool flag2 = 0 < (nint)baseBody2._velocity;
										object obj4 = 0 - baseBody2._velocity;
										bool flag3 = obj4 == null;
										bool flag4 = !flag2;
										bool flag5 = !flag3;
										bool flag6 = flag5 & flag4;
										ArcadeSprite arcadeSprite = setFlipX(flag6);
										if ((object)_summon != null)
										{
											Transform transform = _summon.transform;
											Transform transform2 = base.transform;
											if ((object)transform2 != null)
											{
												bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
												bool flag8 = (object)transform == null;
												bool flag9 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												Vector2 value = default(Vector2);
												Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
												return;
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
		goto IL_03b2;
	}

	public override void Despawn()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__18_3()
	{
		//IL_0015: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
	}

	private void _003CInitProjectile_003Eb__18_0()
	{
		ChooseTarget();
	}

	private void _003CInitProjectile_003Eb__18_1()
	{
		onExpireTimer();
	}

	private void _003CInitProjectile_003Eb__18_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003ConExpireTimer_003Eb__19_0()
	{
		Despawn();
	}
}
