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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SpellstromWeapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__36_0;

		public static TweenCallback _003C_003E9__39_0;

		public static TweenCallback _003C_003E9__39_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoSingularity_003Eb__36_0()
		{
		}

		internal void _003CScreenShake_003Eb__39_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__39_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public Rectangle rect;

		public float halfWidth;

		public SpellstromWeapon _003C_003E4__this;

		internal void _003CExplodeSingularity_003Eb__0()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			SpellstromWeapon spellstromWeapon = _003C_003E4__this;
			Rectangle rectangle = rect;
			float num = halfWidth;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			float x = (float)obj * spellstromWeapon.SingularityExplosionValue;
			rectangle._x = x;
			Rectangle rectangle2 = rect;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			SpellstromWeapon spellstromWeapon2 = _003C_003E4__this;
			float width = (float)renderer.pixelWidth * spellstromWeapon2.SingularityExplosionValue;
			rectangle2._width = width;
			SpellstromWeapon spellstromWeapon3 = _003C_003E4__this;
			float2 position = ((Equipment)spellstromWeapon3)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(spellstromWeapon3._emitter1, pos, 160);
			SpellstromWeapon spellstromWeapon4 = _003C_003E4__this;
			float2 position2 = ((Equipment)spellstromWeapon4)._003COwner_003Ek__BackingField.position;
			RenderingExtensions.EmitParticleAt(spellstromWeapon4._emitter2, pos, 160);
		}

		internal void _003CExplodeSingularity_003Eb__1()
		{
			SpellstromWeapon spellstromWeapon = _003C_003E4__this;
			spellstromWeapon._skipEmitUpdate = false;
		}
	}

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	private Circle _emitZone;

	private GravityWell _well1;

	private GravityWell _well2;

	private float _angleValue;

	private ParticleEmitterManager _fixedCircleManager;

	private ParticleSystem _fixedCircleEmitter;

	private Circle _circleEmitZone;

	private SpellstringWeapon _weaponString;

	private SpellstreamWeapon _weaponStream;

	private SpellstrikeWeapon _weaponStrike;

	private MultiTargetTween _singularityTween;

	private float _singularityTime;

	private bool _doingSingularity;

	private MultiTargetTween _restoreTween;

	private float _singularityTimes;

	private bool _skipEmitUpdate;

	private bool _hasBullets;

	private MultiTargetTween _singularityExplosionTween;

	private MultiTargetTween _screenShakeTween;

	private SpellstromProjectile _bulletA;

	private SpellstromProjectile _bulletB;

	private bool _totalDamageCalculated;

	[NonSerialized]
	public float Radius;

	[NonSerialized]
	public float SingularityExplosionValue;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b5: Expected O, but got I
		//IL_0948: Expected O, but got I4
		//IL_0286: Expected O, but got Ref
		//IL_02ad: Expected O, but got I
		//IL_02c7: Expected native int or pointer, but got O
		//IL_02e1: Expected O, but got I
		//IL_0301: Expected O, but got Ref
		//IL_031b: Expected native int or pointer, but got O
		//IL_0965: Expected O, but got I4
		//IL_034d: Expected O, but got Ref
		//IL_0367: Expected native int or pointer, but got O
		//IL_099f: Expected O, but got I
		//IL_03c6: Expected O, but got I
		//IL_09eb: Expected O, but got I
		//IL_05af: Expected O, but got Ref
		//IL_05d6: Expected O, but got I
		//IL_05f0: Expected native int or pointer, but got O
		//IL_060a: Expected O, but got I
		//IL_062a: Expected O, but got Ref
		//IL_0644: Expected native int or pointer, but got O
		//IL_0a25: Expected O, but got I
		//IL_067c: Expected O, but got Ref
		//IL_0696: Expected native int or pointer, but got O
		//IL_0a57: Expected O, but got I
		//IL_077c: Expected O, but got I
		//IL_0791: Expected O, but got I
		//IL_0831: Expected O, but got I
		//IL_0846: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		_hasBullets = false;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		_emitZone = circle;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rbx_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager pfxManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
			pfxManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxManager = pfxManager;
		GameObject gameObject2 = _pfxManager.gameObject;
		((UnityEngine.Object)gameObject2).SetName("PfxManager (Spellstrom)");
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell1");
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
			((List<object>)(object)list).AddWithResize((object)"2Spell2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(3000f, 7000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = false;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _emitZone;
		particleSystemConfig._emitZone = emitZone;
		ParticleSystem emitter = _pfxManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter1");
		_emitter1 = emitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"2Spell3");
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
			((List<object>)(object)list2).AddWithResize((object)"2Spell4");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1000f, 2000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._scaleEase = Easing.OutQuint;
		particleSystemConfig2._on = false;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _emitZone;
		particleSystemConfig2._emitZone = emitZone2;
		ParticleSystem emitter2 = _pfxManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
		_emitter2 = emitter2;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		gravityWellConfig._y = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		gravityWellConfig._x = (float?)(object)0;
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 200f;
		gravityWellConfig._gravity = 400f;
		GravityWell well = _pfxManager.CreateGravityWell(gravityWellConfig);
		_well1 = well;
		GravityWellConfig gravityWellConfig2 = new GravityWellConfig();
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		gravityWellConfig2._y = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		gravityWellConfig2._x = (float?)(object)0;
		gravityWellConfig2._power = 1f;
		gravityWellConfig2._epsilon = 200f;
		gravityWellConfig2._gravity = 400f;
		GravityWell well2 = _pfxManager.CreateGravityWell(gravityWellConfig2);
		_well2 = well2;
		RenderingExtensions.SetMaxParticles(_emitter1, 5000);
		RenderingExtensions.SetMaxParticles(_emitter2, 5000);
		_singularityTime = 0f;
		_doingSingularity = false;
		_skipEmitUpdate = false;
		_totalDamageCalculated = false;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a7: Expected O, but got I
		//IL_02eb: Expected O, but got Ref
		//IL_030c: Expected F4, but got I
		//IL_0307: Expected native int or pointer, but got O
		//IL_0326: Expected O, but got I
		//IL_035a: Expected O, but got Ref
		//IL_037b: Expected F4, but got I
		//IL_0376: Expected native int or pointer, but got O
		//IL_0395: Expected O, but got I
		//IL_03b5: Expected O, but got Ref
		//IL_03cf: Expected native int or pointer, but got O
		//IL_0582: Expected O, but got I
		//IL_0407: Expected O, but got Ref
		//IL_041c: Expected native int or pointer, but got O
		//IL_0436: Expected O, but got I
		//IL_046f: Expected O, but got I
		//IL_05c8: Expected O, but got I
		//IL_05ff: Expected O, but got I
		//IL_0649: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 200f;
		_circleEmitZone = circle;
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v2 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager fixedCircleManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			fixedCircleManager = (ParticleEmitterManager)0;
		}
		else
		{
			fixedCircleManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_fixedCircleManager = fixedCircleManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell1");
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
			((List<object>)(object)list).AddWithResize((object)"2Spell2");
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
			((List<object>)(object)list).AddWithResize((object)"2Spell3");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
		_ = 0;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6B]");
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-1]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+2F]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1500f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Edge;
		emitZone._source = _circleEmitZone;
		_ = 0;
		_ = 120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		emitZone._quantity = (int?)(object)0;
		emitZone._yoyo = false;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = true;
		ParticleSystem fixedCircleEmitter = _fixedCircleManager.CreateEmitter(particleSystemConfig, null, "FixedCircleEmitter");
		_fixedCircleEmitter = fixedCircleEmitter;
		_ = _fixedCircleEmitter;
		_ = _fixedCircleEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1297 @ rax_v47 (should have been resolved before IL gen)");
		RenderingExtensions.Start(_fixedCircleEmitter);
	}

	public override void Fire(bool skipTriggers = false)
	{
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			SpellstringWeapon weaponString = _weaponString;
			SpellstreamWeapon weaponStream = _weaponStream;
			SpellstrikeWeapon weaponStrike = _weaponStrike;
			float num = ((Weapon)weaponStream)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)weaponString)._003CStatsInflictedDamage_003Ek__BackingField;
			float num2 = num + ((Weapon)weaponStrike)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num3;
		}
		return base._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0a4f: Expected O, but got F4
		//IL_0a54: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_0802: Expected I, but got O
		//IL_082c: Expected O, but got I
		//IL_0124: Expected I, but got O
		//IL_08eb: Expected O, but got F4
		//IL_0178: Expected I, but got O
		//IL_0190: Expected I, but got O
		//IL_01b7: Expected O, but got I
		//IL_04d8->IL0735: Incompatible stack heights: 1 vs 0
		//IL_06c2->IL0735: Incompatible stack heights: 5 vs 0
		//IL_06f0->IL0735: Incompatible stack heights: 5 vs 0
		//IL_071c->IL0735: Incompatible stack heights: 5 vs 0
		//IL_062c->IL0735: Incompatible stack heights: 5 vs 0
		//IL_0673->IL0735: Incompatible stack heights: 5 vs 0
		base.InternalUpdate();
		if (!_hasBullets)
		{
			InitBullets();
			_hasBullets = true;
		}
		object obj = Time.deltaTime;
		nint num = (nint)this;
		float num3 = default(float);
		float num2 = num3 * 1000f;
		float num4 = (_singularityTime = num2 + _singularityTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstromWeapon>)+5D0]");
		int num5 = 0;
		float num6 = SingularityDelay();
		if (num4 > num3)
		{
			DoSingularity();
			_singularityTime = 0f;
			num5 = 0;
		}
		object weaponString = _weaponString;
		if ((object)_weaponString != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdi_v6 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				SpellstringWeapon weaponString2 = _weaponString;
				if ((object)_weaponString == null)
				{
					goto IL_0735;
				}
				nint num7 = (nint)weaponString2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v138 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstringWeapon>)+230]");
				num5 = 0;
				_weaponString.InternalUpdate();
			}
		}
		object weaponStream = _weaponStream;
		if ((object)_weaponStream != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdi_v7 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				SpellstreamWeapon weaponStream2 = _weaponStream;
				if ((object)_weaponStream == null)
				{
					goto IL_0735;
				}
				nint num8 = (nint)weaponStream2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rax_v128 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstreamWeapon>)+230]");
				num5 = 0;
				_weaponStream.InternalUpdate();
			}
		}
		object weaponStrike = _weaponStrike;
		bool flag = (object)_weaponStrike == null;
		nint num9 = (nint)typeof(UnityEngine.Object);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rdi_v8 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			num9 = (nint)typeof(UnityEngine.Object);
			if (!flag2)
			{
				num9 = (nint)_weaponStrike;
				if ((object)_weaponStrike == null)
				{
					goto IL_0735;
				}
				object obj2 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1318 @ rax_v120+230]");
				num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1318 @ rax_v120+228] (should have been resolved before IL gen)");
			}
		}
		bool flag3 = _doingSingularity;
		ParticleEmitterManager particleEmitterManager = (ParticleEmitterManager)num9;
		if (!flag3)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null && (object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								float num10 = renderer2.height * 0.4f;
								float num11 = renderer.width * 0.4f;
								if (!(num10 > num11))
								{
									num11 = num10;
								}
								Circle emitZone = _emitZone;
								Radius = num11;
								if (_emitZone != null)
								{
									float num12 = num11 * 0.8f;
									float num13 = (emitZone._radius = num12 * 100f);
									float diameter = num13 + num13;
									emitZone._diameter = diameter;
									Circle circleEmitZone = _circleEmitZone;
									if (_circleEmitZone != null)
									{
										float num14 = (circleEmitZone._radius = Radius * 100f);
										num3 = (circleEmitZone._diameter = num14 + num14);
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer3 = s_scene3._renderer;
												if (s_scene3._renderer != null && (object)_pfxManager != null)
												{
													num5 = -renderer3.pixelHeight;
													ParticleEmitterManager particleEmitterManager2 = _pfxManager.SetDepth(num5);
													particleEmitterManager = _pfxManager;
													goto IL_08e2;
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
			goto IL_0735;
		}
		goto IL_08e2;
		IL_08e2:
		object obj3 = Time.deltaTime;
		float angleValue = num3 + _angleValue;
		_angleValue = angleValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 value = default(Vector2);
		Vector2 value2 = default(Vector2);
		if ((object)_well1 != null)
		{
			Transform transform = _well1.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rax_v41 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rax_v41 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
					Transform transform2 = _well2.transform;
					float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						bool flag5 = (object)transform2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1666 @ rax_v48 (UnityEngine.Transform)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1666 @ rax_v48 (UnityEngine.Transform)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
						bool flag7 = (object)_well1 == null;
						((UnityEngine.Object)_well1).SetName("WELL UNO");
						bool flag8 = (object)_well2 == null;
						((UnityEngine.Object)_well2).SetName("DUE DUE");
						if (_skipEmitUpdate)
						{
							goto IL_06a8;
						}
						RenderingExtensions.SetBlendMode(_emitter1, BlendMode.Normal);
						RenderingExtensions.SetBlendMode(_emitter2, BlendMode.Normal);
						RenderingExtensions.SetEmitZone(emitZone: new EmitZone
						{
							_type = EmitZoneType.Random,
							_source = _emitZone
						}, pfx: _emitter1);
						RenderingExtensions.SetEmitZone(emitZone: new EmitZone
						{
							_type = EmitZoneType.Random,
							_source = _emitZone
						}, pfx: _emitter2);
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
							Vector2 pos = default(Vector2);
							RenderingExtensions.EmitParticleAt(_emitter1, pos, 8);
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
								RenderingExtensions.EmitParticleAt(_emitter2, pos, 8);
								PhaserScene s_scene = null;
								goto IL_06a8;
							}
						}
					}
				}
			}
		}
		goto IL_0735;
		IL_06a8:
		if ((object)_fixedCircleEmitter != null)
		{
			Transform transform3 = _fixedCircleEmitter.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform4 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform4 != null)
				{
					bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)(&value));
					bool flag10 = (object)transform3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v58 (UnityEngine.Transform)+10]");
					bool flag11 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v58 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
					return;
				}
			}
		}
		goto IL_0735;
		IL_0735:
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Cleanup();
		}
		if (_secondaryPool != null)
		{
			_secondaryPool.Cleanup();
		}
		_weaponStream.Cleanup();
		_weaponStrike.Cleanup();
		_weaponString.Cleanup();
		if (_restoreTween != null)
		{
			_restoreTween.Kill();
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		if (_singularityTween != null)
		{
			_singularityTween.Kill();
		}
		if (_singularityExplosionTween != null)
		{
			_singularityExplosionTween.Kill();
		}
		_emitter1.Stop();
		_emitter2.Stop();
		_fixedCircleEmitter.Stop();
		SpellstromProjectile bulletA = _bulletA;
		if ((object)_bulletA != null && ((UnityEngine.Object)bulletA).m_CachedPtr != (IntPtr)0)
		{
			_bulletA.Despawn();
		}
		SpellstromProjectile bulletB = _bulletB;
		if ((object)_bulletB != null && ((UnityEngine.Object)bulletB).m_CachedPtr != (IntPtr)0)
		{
			_bulletB.Despawn();
		}
		base.Cleanup();
	}

	protected virtual float SingularityPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			float num = base.PDuration();
			float num2 = base.PSpeed();
			float num3 = base.PArea();
			float num4 = base.PAmount();
			float num6 = default(float);
			float num5 = num6 * 0.001f;
			float num7 = num5 + currentWeaponData._003Cpower_003Ek__BackingField;
			float num8 = num7 + num6;
			float num9 = num8 + num6;
			float num10 = _singularityTimes * 0.5f;
			float num11 = num6 * num9;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num12 = num10 + num11;
					float num13 = num12 * num6;
					return num6 + num13;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual float SingularityDelay()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		object obj = default(object);
		float num2 = (float)obj + characterController._003CSilentCooldown_003Ek__BackingField;
		bool flag = !(0.1f < num2);
		float num3 = 0.1f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = num3 * 20000f;
		return num4 + 20000f;
	}

	private void InitBullets()
	{
		//IL_00bd: Expected I, but got O
		//IL_00cb: Expected I, but got O
		//IL_00db: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_014d: Expected O, but got I4
		//IL_0293: Expected I, but got O
		//IL_02a1: Expected I, but got O
		//IL_02b1: Expected O, but got I
		//IL_0331: Expected O, but got I4
		//IL_02ed: Expected O, but got I
		//IL_0323: Expected O, but got I4
		//IL_040b->IL039b: Incompatible stack heights: 1 vs 0
		//IL_0062->IL039b: Incompatible stack heights: 1 vs 0
		//IL_045a->IL039b: Incompatible stack heights: 2 vs 0
		//IL_0188->IL039b: Incompatible stack heights: 2 vs 0
		//IL_01b6->IL039b: Incompatible stack heights: 2 vs 0
		//IL_01df->IL039b: Incompatible stack heights: 2 vs 0
		//IL_020b->IL039b: Incompatible stack heights: 2 vs 0
		//IL_04e1->IL039b: Incompatible stack heights: 3 vs 0
		//IL_0241->IL039b: Incompatible stack heights: 3 vs 0
		//IL_0530->IL039b: Incompatible stack heights: 4 vs 0
		//IL_035d->IL039b: Incompatible stack heights: 4 vs 0
		//IL_038b->IL039b: Incompatible stack heights: 4 vs 0
		Vector3 ret;
		Vector3 ret2;
		Projectile projectile;
		float2 pos = default(float2);
		Transform bulletA;
		object obj3;
		if ((object)_well1 != null)
		{
			Transform transform = _well1.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_well1 != null)
				{
					Transform transform2 = _well1.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret2);
						if (_projectilePool != null)
						{
							projectile = _projectilePool.SpawnAt(pos, this);
							if ((object)projectile == null)
							{
								bulletA = null;
								goto IL_045f;
							}
							nint num = (nint)projectile;
							nint num2 = (nint)typeof(SpellstromProjectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SpellstromProjectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SpellstromProjectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v89+FFFFFFF8+v798 @ rax_v84*8]");
								if (0 == (nint)typeof(SpellstromProjectile))
								{
									obj3 = 1;
									goto IL_046e;
								}
							}
							obj3 = 0;
							goto IL_046e;
						}
					}
				}
			}
		}
		goto IL_039b;
		IL_039b:
		throw new NullReferenceException();
		IL_0544:
		object obj4;
		bool flag3 = obj4 == null;
		Transform bulletB = null;
		Projectile projectile2;
		if (!flag3)
		{
			bulletB = (Transform)(object)projectile2;
		}
		goto IL_0535;
		IL_045f:
		_bulletA = (SpellstromProjectile)(object)bulletA;
		if ((object)_well1 != null)
		{
			Transform transform3 = _well1.transform;
			if ((object)_bulletA != null && (object)_well2 != null)
			{
				Transform transform4 = _well2.transform;
				if ((object)transform4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v41 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v41 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret2);
					if ((object)_well2 != null)
					{
						Transform transform5 = _well2.transform;
						if ((object)transform5 != null)
						{
							bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
							if (_projectilePool != null)
							{
								projectile2 = _projectilePool.SpawnAt(pos, this, 1);
								bool flag6 = (object)projectile2 == null;
								bulletB = null;
								if (flag6)
								{
									goto IL_0535;
								}
								nint num4 = (nint)projectile2;
								nint num5 = (nint)typeof(SpellstromProjectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SpellstromProjectile>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1156 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SpellstromProjectile>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1156 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v70+FFFFFFF8+v1158 @ rax_v66*8]");
									if (0 == (nint)typeof(SpellstromProjectile))
									{
										obj4 = 1;
										goto IL_0544;
									}
								}
								obj4 = 0;
								goto IL_0544;
							}
						}
					}
				}
			}
		}
		goto IL_039b;
		IL_0535:
		_bulletB = (SpellstromProjectile)(object)bulletB;
		if ((object)_well2 != null)
		{
			Transform transform6 = _well2.transform;
			if ((object)_bulletB != null)
			{
				return;
			}
		}
		goto IL_039b;
		IL_046e:
		bool flag7 = obj3 == null;
		bulletA = null;
		if (!flag7)
		{
			bulletA = (Transform)(object)projectile;
		}
		goto IL_045f;
	}

	private void DoSingularity()
	{
		//IL_0440: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_0112: Expected I, but got O
		//IL_02c1: Expected I, but got O
		_doingSingularity = true;
		ScreenShake();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SpellStrom, soundConfig, 400f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 0.6f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.SpellStrom, soundConfig2, 400f, 3, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 0.2f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.SpellStrom, soundConfig3, 400f, 3, time);
		if (_singularityTween != null)
		{
			_singularityTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Radius", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 5000f;
			TweenCallback onUpdate = _003C_003Ec._003C_003E9__36_0;
			if (_003C_003Ec._003C_003E9__36_0 == null)
			{
				onUpdate = (_003C_003Ec._003C_003E9__36_0 = delegate
				{
				});
			}
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onComplete = delegate
			{
				ExplodeSingularity();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween singularityTween = Tweens.Add(tweenConfig);
			_singularityTween = singularityTween;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			float num2 = renderer2.height * 0.4f;
			float num3 = renderer.width * 0.4f;
			if (!(num2 > num3) || _restoreTween != null)
			{
				_restoreTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value2 = default(object);
				bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"Radius", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary2;
				tweenConfig2.duration = 200f;
				tweenConfig2.delay = 5000f;
				TweenCallback onStart = delegate
				{
					//IL_00b7: Expected O, but got I4
					//IL_0041: Expected O, but got I4
					ScreenShake();
					SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
					soundConfig4.Rate = 0.5f;
					soundConfig4.Volume = (float?)(object)1;
					float time2 = default(float);
					PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.SpellStrike, soundConfig4, 200f, 4, time2);
					SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
					soundConfig5.Volume = (float?)(object)1;
					soundConfig5.Rate = 0.45f;
					PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.SpellStrike, soundConfig5, 200f, 4, time2);
					float singularityTimes = _singularityTimes + 1f;
					_singularityTimes = singularityTimes;
				};
				tweenConfig2.onStart = onStart;
				TweenCallback onComplete2 = delegate
				{
					float num5 = SingularityPower();
					float value3 = default(float);
					DamageAllEnemies(value3);
					_doingSingularity = false;
				};
				tweenConfig2.onComplete = onComplete2;
				TweenCallback onUpdate2 = delegate
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					ParticleEmitterManager particleEmitterManager = _pfxManager.SetDepth(renderer3.pixelHeight);
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					Vector2 pos = default(Vector2);
					RenderingExtensions.EmitParticleAt(_emitter1, pos, 80);
					float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					RenderingExtensions.EmitParticleAt(_emitter2, pos, 80);
				};
				tweenConfig2.onUpdate = onUpdate2;
				MultiTargetTween restoreTween = Tweens.Add(tweenConfig2);
				_restoreTween = restoreTween;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void ExplodeSingularity()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_02b2: Expected I, but got O
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass37_0();
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		_skipEmitUpdate = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Rectangle rectangle = new Rectangle();
		float width = renderer.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = width ^ 0;
		float x = (float)obj * 0.5f;
		rectangle._y = -0.049999997f;
		rectangle._width = renderer2.width;
		rectangle._x = x;
		rectangle._height = 0.099999994f;
		CS_0024_003C_003E8__locals13.rect = rectangle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = CS_0024_003C_003E8__locals13.rect;
		RenderingExtensions.SetEmitZone(_emitter1, emitZone);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = CS_0024_003C_003E8__locals13.rect;
		RenderingExtensions.SetEmitZone(_emitter2, emitZone2);
		Material material = MaterialManager.GetMaterial(MaterialType.ParticlesAdditive);
		ParticleSystemRenderer component = _emitter1.GetComponent<ParticleSystemRenderer>();
		Material material2 = ((Renderer)component).GetMaterial();
		Shader shader = material.shader;
		material2.shader = shader;
		Material material3 = MaterialManager.GetMaterial(MaterialType.ParticlesAdditive);
		ParticleSystemRenderer component2 = _emitter2.GetComponent<ParticleSystemRenderer>();
		Material material4 = ((Renderer)component2).GetMaterial();
		Shader shader2 = material3.shader;
		material4.shader = shader2;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float halfWidth = (float)renderer3.pixelWidth * 0.5f;
		CS_0024_003C_003E8__locals13.halfWidth = halfWidth;
		SingularityExplosionValue = 0f;
		if (_singularityExplosionTween != null)
		{
			_singularityExplosionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"SingularityExplosionValue", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 200f;
			TweenCallback onUpdate = delegate
			{
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				//IL_002b: Expected O, but got Unknown
				SpellstromWeapon spellstromWeapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
				Rectangle rect = CS_0024_003C_003E8__locals13.rect;
				float halfWidth2 = CS_0024_003C_003E8__locals13.halfWidth;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj3 = halfWidth2 ^ 0;
				float x2 = (float)obj3 * spellstromWeapon.SingularityExplosionValue;
				rect._x = x2;
				Rectangle rect2 = CS_0024_003C_003E8__locals13.rect;
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer4 = s_scene4._renderer;
				SpellstromWeapon spellstromWeapon2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float width2 = (float)renderer4.pixelWidth * spellstromWeapon2.SingularityExplosionValue;
				rect2._width = width2;
				SpellstromWeapon spellstromWeapon3 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float2 position = ((Equipment)spellstromWeapon3)._003COwner_003Ek__BackingField.position;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(spellstromWeapon3._emitter1, pos, 160);
				SpellstromWeapon spellstromWeapon4 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float2 position2 = ((Equipment)spellstromWeapon4)._003COwner_003Ek__BackingField.position;
				RenderingExtensions.EmitParticleAt(spellstromWeapon4._emitter2, pos, 160);
			};
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onComplete = delegate
			{
				SpellstromWeapon spellstromWeapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
				spellstromWeapon._skipEmitUpdate = false;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween singularityExplosionTween = Tweens.Add(tweenConfig);
			_singularityExplosionTween = singularityExplosionTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected override void OnStart()
	{
		//IL_0058: Expected I, but got O
		//IL_0076: Expected I, but got O
		//IL_0084: Expected I, but got O
		//IL_0094: Expected O, but got I
		//IL_0114: Expected O, but got I4
		//IL_00d0: Expected O, but got I
		//IL_0106: Expected O, but got I4
		//IL_03a3: Expected I, but got O
		//IL_03b1: Expected I, but got O
		//IL_03c1: Expected O, but got I
		//IL_0441: Expected O, but got I4
		//IL_03fd: Expected O, but got I
		//IL_0433: Expected O, but got I4
		//IL_071a: Expected I, but got O
		//IL_0728: Expected I, but got O
		//IL_0738: Expected O, but got I
		//IL_07b8: Expected O, but got I4
		//IL_0774: Expected O, but got I
		//IL_07aa: Expected O, but got I4
		//IL_02b8: Expected F4, but got I4
		//IL_09a7: Expected I, but got O
		//IL_09b5: Expected I, but got O
		//IL_09c5: Expected O, but got I
		//IL_0a45: Expected O, but got I4
		//IL_0a01: Expected O, but got I
		//IL_0653: Expected O, but got I4
		//IL_0645: Expected O, but got I4
		//IL_0a37: Expected O, but got I4
		//IL_0ac2: Expected I, but got O
		//IL_0ad0: Expected I, but got O
		//IL_0ae0: Expected O, but got I
		//IL_0b60: Expected O, but got I4
		//IL_0b1c: Expected O, but got I
		//IL_0b52: Expected O, but got I4
		//IL_0bdd: Expected I, but got O
		//IL_0beb: Expected I, but got O
		//IL_0bfb: Expected O, but got I
		//IL_0c7b: Expected O, but got I4
		//IL_0c37: Expected O, but got I
		//IL_0c6d: Expected O, but got I4
		//IL_1220: Expected O, but got I4
		//IL_0ecb->IL0dbe: Incompatible stack heights: 1 vs 0
		//IL_0292->IL0dbe: Incompatible stack heights: 1 vs 0
		//IL_0f37->IL0dbe: Incompatible stack heights: 2 vs 0
		//IL_02dc->IL0dbe: Incompatible stack heights: 2 vs 0
		//IL_030b->IL0dbe: Incompatible stack heights: 2 vs 0
		//IL_0337->IL0e1a: Incompatible stack heights: 2 vs 0
		base.OnStart();
		GameManager core = GM.Core;
		if ((object)GM.Core == null || core._weaponsFacade == null)
		{
			goto IL_0dbe;
		}
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.SPELL_STRING, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag = (object)weapon == null;
		nint num = unchecked((nint)null);
		Weapon weaponString = weapon;
		if (flag)
		{
			goto IL_0dc5;
		}
		num = (nint)weapon;
		nint num2 = (nint)typeof(SpellstringWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v62 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstringWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v62 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstringWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v216+FFFFFFF8+v702 @ rax_v211*8]");
			if (0 == (nint)typeof(SpellstringWeapon))
			{
				obj3 = 1;
				goto IL_0dd4;
			}
		}
		obj3 = 0;
		goto IL_0dd4;
		IL_1105:
		object obj4;
		bool flag2 = obj4 == null;
		Equipment equipment = null;
		Equipment removedEquipment;
		if (!flag2)
		{
			equipment = removedEquipment;
		}
		goto IL_10dc;
		IL_102f:
		Weapon weaponStrike;
		_weaponStrike = (SpellstrikeWeapon)weaponStrike;
		SpellstrikeWeapon weaponStrike2 = _weaponStrike;
		if ((object)_weaponStrike != null && ((UnityEngine.Object)weaponStrike2).m_CachedPtr != (IntPtr)0)
		{
			SpellstrikeWeapon weaponStrike3 = _weaponStrike;
			if ((object)_weaponStrike != null)
			{
				((Weapon)weaponStrike3)._skipAddingEvolution = true;
				SpellstrikeWeapon weaponStrike4 = _weaponStrike;
				if ((object)_weaponStrike != null)
				{
					SpellstrikeWeapon weaponStrike5;
					while (true)
					{
						weaponStrike5 = _weaponStrike;
						if (((Equipment)weaponStrike4)._003CLevel_003Ek__BackingField >= 6)
						{
							break;
						}
						if ((object)_weaponStrike != null)
						{
							bool flag3 = _weaponStrike.LevelUp();
							weaponStrike4 = _weaponStrike;
							if ((object)_weaponStrike != null)
							{
								continue;
							}
						}
						goto IL_0dbe;
					}
					if ((object)_weaponStrike != null)
					{
						WeaponData currentWeaponData = ((Weapon)weaponStrike5)._currentWeaponData;
						if (((Weapon)weaponStrike5)._currentWeaponData != null)
						{
							int num4 = currentWeaponData._003Camount_003Ek__BackingField + 2;
							currentWeaponData._003Camount_003Ek__BackingField = num4;
							goto IL_1084;
						}
					}
				}
			}
			goto IL_0dbe;
		}
		goto IL_1084;
		IL_1127:
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || (object)characterController._weaponsManager == null)
		{
			goto IL_0dbe;
		}
		Equipment removedEquipment2 = characterController._weaponsManager.GetRemovedEquipment(WeaponType.SPELL_STRIKE);
		Equipment equipment2;
		if ((object)removedEquipment2 == null)
		{
			equipment2 = null;
			goto IL_119e;
		}
		nint num5 = (nint)removedEquipment2;
		nint num6 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2107 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2107 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj7;
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2165 @ rax_v101+FFFFFFF8+v2108 @ rax_v97*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj7 = 1;
				goto IL_1177;
			}
		}
		obj7 = 0;
		goto IL_1177;
		IL_0e1a:
		GameManager core2 = GM.Core;
		if ((object)GM.Core == null || core2._weaponsFacade == null)
		{
			goto IL_0dbe;
		}
		Weapon weapon2 = core2._weaponsFacade.CreateDetachedWeapon(WeaponType.SPELL_STREAM, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag4 = (object)weapon2 == null;
		Weapon weaponStream = weapon2;
		if (flag4)
		{
			goto IL_0f4e;
		}
		nint num8 = (nint)weapon2;
		nint num9 = (nint)typeof(SpellstreamWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstreamWeapon>)+130]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstreamWeapon>)+130]");
		object obj10;
		if (num10 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1207 @ rax_v165+FFFFFFF8+v1153 @ rax_v160*8]");
			if (0 == (nint)typeof(SpellstreamWeapon))
			{
				obj10 = 1;
				goto IL_0f5d;
			}
		}
		obj10 = 0;
		goto IL_0f5d;
		IL_0fa3:
		GameManager core3 = GM.Core;
		if ((object)GM.Core == null || core3._weaponsFacade == null)
		{
			goto IL_0dbe;
		}
		Weapon weapon3 = core3._weaponsFacade.CreateDetachedWeapon(WeaponType.SPELL_STRIKE, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag5 = (object)weapon3 == null;
		weaponStrike = weapon3;
		if (flag5)
		{
			goto IL_102f;
		}
		nint num11 = (nint)weapon3;
		nint num12 = (nint)typeof(SpellstrikeWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1485 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstrikeWeapon>)+130]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1484 @ r9_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1485 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.SpellstrikeWeapon>)+130]");
		object obj13;
		if (num13 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1484 @ r9_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1548 @ rax_v136+FFFFFFF8+v1486 @ rax_v131*8]");
			if (0 == (nint)typeof(SpellstrikeWeapon))
			{
				obj13 = 1;
				goto IL_103e;
			}
		}
		obj13 = 0;
		goto IL_103e;
		IL_10dc:
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || (object)characterController2._weaponsManager == null)
		{
			goto IL_0dbe;
		}
		Equipment removedEquipment3 = characterController2._weaponsManager.GetRemovedEquipment(WeaponType.SPELL_STREAM);
		object obj14;
		if ((object)removedEquipment3 == null)
		{
			obj14 = null;
			goto IL_1127;
		}
		nint num14 = (nint)removedEquipment3;
		nint num15 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ r9_v23 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj17;
		if (num16 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ r9_v23 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2053 @ rax_v107+FFFFFFF8+v2013 @ rax_v103*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj17 = 1;
				goto IL_1150;
			}
		}
		obj17 = 0;
		goto IL_1150;
		IL_0dd4:
		bool flag6 = obj3 == null;
		weaponString = null;
		if (!flag6)
		{
			weaponString = weapon;
		}
		goto IL_0dc5;
		IL_0dbe:
		throw new NullReferenceException();
		IL_0dc5:
		_weaponString = (SpellstringWeapon)weaponString;
		SpellstringWeapon weaponString2 = _weaponString;
		if ((object)_weaponString != null && ((UnityEngine.Object)weaponString2).m_CachedPtr != (IntPtr)0)
		{
			SpellstringWeapon weaponString3 = _weaponString;
			if ((object)_weaponString != null)
			{
				((Weapon)weaponString3)._skipAddingEvolution = true;
				SpellstringWeapon weaponString4 = _weaponString;
				if ((object)_weaponString != null)
				{
					SpellstringWeapon weaponString5;
					while (true)
					{
						weaponString5 = _weaponString;
						if (((Equipment)weaponString4)._003CLevel_003Ek__BackingField >= 6)
						{
							break;
						}
						if ((object)_weaponString != null)
						{
							bool flag7 = _weaponString.LevelUp();
							weaponString4 = _weaponString;
							if ((object)_weaponString != null)
							{
								continue;
							}
						}
						goto IL_0dbe;
					}
					List<Transform> list = new List<Transform>();
					object well = _well1;
					if ((object)_well1 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rsi_v12 (System.Object)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rsi_v12 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
							object well2 = _well2;
							if ((object)_well2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rsi_v13 (System.Object)+10]");
								bool flag9 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rsi_v13 (System.Object)+10]");
								IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
								Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
								if ((object)_weaponString != null)
								{
									weaponString5._sources = list;
									weaponString5._maxSources = list._size;
									SpellstringWeapon weaponString6 = _weaponString;
									if ((object)_weaponString != null)
									{
										WeaponData currentWeaponData2 = ((Weapon)weaponString6)._currentWeaponData;
										if (((Weapon)weaponString6)._currentWeaponData != null)
										{
											float num17 = currentWeaponData2._003Cpower_003Ek__BackingField + 1f;
											currentWeaponData2._003Cpower_003Ek__BackingField = num17;
											goto IL_0e1a;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0dbe;
		}
		goto IL_0e1a;
		IL_1177:
		bool flag10 = obj7 == null;
		equipment2 = null;
		if (!flag10)
		{
			equipment2 = removedEquipment2;
		}
		goto IL_119e;
		IL_1150:
		bool flag11 = obj17 == null;
		obj14 = null;
		if (!flag11)
		{
			obj14 = removedEquipment3;
		}
		goto IL_1127;
		IL_119e:
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks((Weapon)equipment, _weaponString);
		}
		if (obj14 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rsi_v7 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				base.CopyAccumulatedLimitBreaks((Weapon)obj14, _weaponStream);
			}
		}
		if ((object)equipment2 != null && ((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks((Weapon)equipment2, _weaponStrike);
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SpellStrom, soundConfig, 400f, 1, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1971 Invalid \"Jump target not found in method: 0x1873B9DD0\"");
		goto IL_0dbe;
		IL_1084:
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || (object)characterController3._weaponsManager == null)
		{
			goto IL_0dbe;
		}
		removedEquipment = characterController3._weaponsManager.GetRemovedEquipment(WeaponType.SPELL_STRING);
		if ((object)removedEquipment == null)
		{
			equipment = null;
			goto IL_10dc;
		}
		nint num18 = (nint)removedEquipment;
		nint num19 = (nint)typeof(Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1914 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1913 @ r9_v24 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1914 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		if (num20 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1913 @ r9_v24 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1957 @ rax_v113+FFFFFFF8+v1915 @ rax_v109*8]");
			if (0 == (nint)typeof(Weapon))
			{
				obj4 = 1;
				goto IL_1105;
			}
		}
		obj4 = 0;
		goto IL_1105;
		IL_0f5d:
		bool flag12 = obj10 == null;
		weaponStream = null;
		if (!flag12)
		{
			weaponStream = weapon2;
		}
		goto IL_0f4e;
		IL_103e:
		bool flag13 = obj13 == null;
		weaponStrike = null;
		if (!flag13)
		{
			weaponStrike = weapon3;
		}
		goto IL_102f;
		IL_0f4e:
		_weaponStream = (SpellstreamWeapon)weaponStream;
		SpellstreamWeapon weaponStream2 = _weaponStream;
		if ((object)_weaponStream != null && ((UnityEngine.Object)weaponStream2).m_CachedPtr != (IntPtr)0)
		{
			SpellstreamWeapon weaponStream3 = _weaponStream;
			if ((object)_weaponStream != null)
			{
				((Weapon)weaponStream3)._skipAddingEvolution = true;
				SpellstreamWeapon weaponStream4 = _weaponStream;
				if ((object)_weaponStream != null)
				{
					SpellstreamWeapon weaponStream5;
					while (true)
					{
						weaponStream5 = _weaponStream;
						if (((Equipment)weaponStream4)._003CLevel_003Ek__BackingField >= 6)
						{
							break;
						}
						if ((object)_weaponStream != null)
						{
							bool flag14 = _weaponStream.LevelUp();
							weaponStream4 = _weaponStream;
							if ((object)_weaponStream != null)
							{
								continue;
							}
						}
						goto IL_0dbe;
					}
					if ((object)_weaponStream != null)
					{
						WeaponData currentWeaponData3 = ((Weapon)weaponStream5)._currentWeaponData;
						if (((Weapon)weaponStream5)._currentWeaponData != null)
						{
							float num21 = currentWeaponData3._003Cspeed_003Ek__BackingField + 1f;
							currentWeaponData3._003Cspeed_003Ek__BackingField = num21;
							SpellstreamWeapon weaponStream6 = _weaponStream;
							if ((object)_weaponStream != null)
							{
								WeaponData currentWeaponData4 = ((Weapon)weaponStream6)._currentWeaponData;
								if (((Weapon)weaponStream6)._currentWeaponData != null)
								{
									float? num22 = (float?)(((object)currentWeaponData4._003Cduration_003Ek__BackingField == null) ? ((object)0) : ((object)1));
									currentWeaponData4._003Cduration_003Ek__BackingField = num22;
									SpellstreamWeapon weaponStream7 = _weaponStream;
									if ((object)_weaponStream != null)
									{
										WeaponData currentWeaponData5 = ((Weapon)weaponStream7)._currentWeaponData;
										if (((Weapon)weaponStream7)._currentWeaponData != null)
										{
											float num23 = currentWeaponData5._003Carea_003Ek__BackingField + 0.5f;
											currentWeaponData5._003Carea_003Ek__BackingField = num23;
											goto IL_0fa3;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0dbe;
		}
		goto IL_0fa3;
	}

	private void ScreenShake()
	{
		//IL_00e2: Expected I, but got O
		//IL_0162: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
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
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__39_0;
		if (_003C_003Ec._003C_003E9__39_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__39_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__39_1;
		if (_003C_003Ec._003C_003E9__39_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__39_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}

	public override void SetVisible(bool visible)
	{
		SpellstringWeapon weaponString = _weaponString;
		_isVisible = visible;
		if (visible)
		{
			if ((object)_weaponString != null && ((UnityEngine.Object)weaponString).m_CachedPtr != (IntPtr)0)
			{
				_weaponString.ResetFiringTimer();
				_weaponString.SetVisible(visible: true);
			}
			SpellstreamWeapon weaponStream = _weaponStream;
			if ((object)_weaponStream != null && ((UnityEngine.Object)weaponStream).m_CachedPtr != (IntPtr)0)
			{
				_weaponStream.ResetFiringTimer();
				_weaponStream.SetVisible(visible: true);
			}
			SpellstrikeWeapon weaponStrike = _weaponStrike;
			if ((object)_weaponStrike != null && ((UnityEngine.Object)weaponStrike).m_CachedPtr != (IntPtr)0)
			{
				_weaponStrike.ResetFiringTimer();
				_weaponStrike.SetVisible(visible: true);
			}
			RenderingExtensions.Start(_fixedCircleEmitter);
			SpellstromProjectile bulletA = _bulletA;
			if ((object)_bulletA == null || ((UnityEngine.Object)bulletA).m_CachedPtr == (IntPtr)0)
			{
				InitBullets();
			}
			return;
		}
		if ((object)_weaponString != null && ((UnityEngine.Object)weaponString).m_CachedPtr != (IntPtr)0)
		{
			SpellstringWeapon weaponString2 = _weaponString;
			if (((Weapon)weaponString2)._firingTimer != null)
			{
				((Weapon)weaponString2)._firingTimer.Cancel();
			}
			if (((Weapon)weaponString2)._firingAnimEvent != null)
			{
				((Weapon)weaponString2)._firingAnimEvent.Cancel();
			}
			_weaponString.SetVisible(visible: false);
		}
		SpellstreamWeapon weaponStream2 = _weaponStream;
		if ((object)_weaponStream != null && ((UnityEngine.Object)weaponStream2).m_CachedPtr != (IntPtr)0)
		{
			SpellstreamWeapon weaponStream3 = _weaponStream;
			if (((Weapon)weaponStream3)._firingTimer != null)
			{
				((Weapon)weaponStream3)._firingTimer.Cancel();
			}
			if (((Weapon)weaponStream3)._firingAnimEvent != null)
			{
				((Weapon)weaponStream3)._firingAnimEvent.Cancel();
			}
			_weaponStream.SetVisible(visible: false);
		}
		SpellstrikeWeapon weaponStrike2 = _weaponStrike;
		if ((object)_weaponStrike != null && ((UnityEngine.Object)weaponStrike2).m_CachedPtr != (IntPtr)0)
		{
			SpellstrikeWeapon weaponStrike3 = _weaponStrike;
			if (((Weapon)weaponStrike3)._firingTimer != null)
			{
				((Weapon)weaponStrike3)._firingTimer.Cancel();
			}
			if (((Weapon)weaponStrike3)._firingAnimEvent != null)
			{
				((Weapon)weaponStrike3)._firingAnimEvent.Cancel();
			}
			_weaponStrike.SetVisible(visible: false);
		}
		_fixedCircleEmitter.Stop();
		SpellstromProjectile bulletA2 = _bulletA;
		if ((object)_bulletA != null && ((UnityEngine.Object)bulletA2).m_CachedPtr != (IntPtr)0)
		{
			_bulletA.Despawn();
			_bulletA = null;
		}
		SpellstromProjectile bulletB = _bulletB;
		if ((object)_bulletB != null && ((UnityEngine.Object)bulletB).m_CachedPtr != (IntPtr)0)
		{
			_bulletB.Despawn();
			_bulletB = null;
		}
	}

	private void _003CDoSingularity_003Eb__36_1()
	{
		ExplodeSingularity();
	}

	private void _003CDoSingularity_003Eb__36_2()
	{
		//IL_00b7: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		ScreenShake();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SpellStrike, soundConfig, 200f, 4, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 0.45f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.SpellStrike, soundConfig2, 200f, 4, time);
		float singularityTimes = _singularityTimes + 1f;
		_singularityTimes = singularityTimes;
	}

	private void _003CDoSingularity_003Eb__36_3()
	{
		float num = SingularityPower();
		float value = default(float);
		DamageAllEnemies(value);
		_doingSingularity = false;
	}

	private void _003CDoSingularity_003Eb__36_4()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ParticleEmitterManager particleEmitterManager = _pfxManager.SetDepth(renderer.pixelHeight);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_emitter1, pos, 80);
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		RenderingExtensions.EmitParticleAt(_emitter2, pos, 80);
	}
}
