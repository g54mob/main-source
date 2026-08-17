using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_SpellFirerProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public EME_SpellFirerProjectile _003C_003E4__this;

		public float fadeDuration;

		internal void _003COnRecycle_003Eb__0()
		{
			EME_SpellFirerProjectile eME_SpellFirerProjectile = _003C_003E4__this;
			RenderingExtensions.Start(eME_SpellFirerProjectile._pfxEmitter);
			EME_SpellFirerProjectile eME_SpellFirerProjectile2 = _003C_003E4__this;
			RenderingExtensions.Start(eME_SpellFirerProjectile2._pfxEmitter2);
			EME_SpellFirerProjectile eME_SpellFirerProjectile3 = _003C_003E4__this;
			RenderingExtensions.Start(eME_SpellFirerProjectile3._pfxEmitter3);
		}

		internal void _003COnRecycle_003Eb__1()
		{
			EME_SpellFirerProjectile eME_SpellFirerProjectile = _003C_003E4__this;
			eME_SpellFirerProjectile._pfxEmitter.Stop();
			EME_SpellFirerProjectile eME_SpellFirerProjectile2 = _003C_003E4__this;
			eME_SpellFirerProjectile2._pfxEmitter2.Stop();
			EME_SpellFirerProjectile eME_SpellFirerProjectile3 = _003C_003E4__this;
			eME_SpellFirerProjectile3._pfxEmitter3.Stop();
		}

		internal void _003COnRecycle_003Eb__2()
		{
			//IL_0080: Expected I, but got O
			EME_SpellFirerProjectile eME_SpellFirerProjectile = _003C_003E4__this;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(eME_SpellFirerProjectile._M1CachedT, 0f, fadeDuration);
			Material material = ((Renderer)eME_SpellFirerProjectile._Model2).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material, 1f, _AlphaMul, fadeDuration);
			Material material2 = ((Renderer)eME_SpellFirerProjectile._Model3).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore3 = ShortcutExtensions.DOFloat(material2, 1f, _AlphaMul, fadeDuration);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpellFirerProjectile>)+370]");
			Action onComplete = new Action(eME_SpellFirerProjectile, (IntPtr)0);
			nint num = (nint)eME_SpellFirerProjectile;
			float duration = fadeDuration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			eME_SpellFirerProjectile._DespawnTimer = despawnTimer;
		}
	}

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_RapierWeapon _trueWeapon;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private ParticleSystem _pfxEmitter3;

	private bool _initialisedParticles;

	private MeshRenderer _Model1;

	private MeshRenderer _Model2;

	private MeshRenderer _Model3;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private Timer _DespawnTimer;

	private PhaserSprite _displayImage;

	private Transform _M1CachedT;

	private Transform _M2CachedT;

	private Transform _M3CachedT;

	protected override void Awake()
	{
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002b: Expected O, but got I4
		//IL_01d6: Expected O, but got I
		//IL_01f2: Expected O, but got I4
		//IL_020b: Expected O, but got Ref
		//IL_0225: Expected native int or pointer, but got O
		//IL_070c: Expected O, but got I4
		//IL_023d: Expected O, but got Ref
		//IL_0257: Expected native int or pointer, but got O
		//IL_0271: Expected O, but got I
		//IL_0291: Expected O, but got Ref
		//IL_02b8: Expected O, but got I
		//IL_02d2: Expected native int or pointer, but got O
		//IL_0729: Expected O, but got I4
		//IL_0304: Expected O, but got Ref
		//IL_031e: Expected native int or pointer, but got O
		//IL_0763: Expected O, but got I
		//IL_0364: Expected O, but got I4
		//IL_0396: Expected O, but got I
		//IL_0429: Expected O, but got I
		//IL_0485: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = true;
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (!_initialisedParticles)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite displayImage = instance.AddPhaserSprite(pos, "vfx", "desatSlash");
			_displayImage = displayImage;
			PhaserSprite phaserSprite = _displayImage.setAlpha(0f);
			Rectangle rectangle = new Rectangle();
			rectangle._x = -0.16f;
			rectangle._y = 1.28f;
			rectangle._width = 0.32f;
			rectangle._height = 2.56f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(75f, 125f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(-600f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 0;
			_ = 16711680;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
			particleSystemConfig._tint = (uint?)(object)0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = rectangle;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			_pfxEmitter = pfxEmitter;
			_ = 0;
			_ = 16776960;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
			particleSystemConfig._tint = (uint?)(object)0;
			Transform parent2 = base.transform;
			ParticleSystem pfxEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent2);
			_pfxEmitter2 = pfxEmitter2;
			_ = 0;
			_ = 16746496;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
			particleSystemConfig._tint = (uint?)(object)0;
			Transform parent3 = base.transform;
			ParticleSystem pfxEmitter3 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent3);
			_pfxEmitter3 = pfxEmitter3;
			_initialisedParticles = true;
			Transform m1CachedT = _Model1.transform;
			_M1CachedT = m1CachedT;
			Transform m2CachedT = _Model2.transform;
			_M2CachedT = m2CachedT;
			Transform m3CachedT = _Model3.transform;
			_M3CachedT = m3CachedT;
		}
		_pfxEmitter.Stop();
		_pfxEmitter2.Stop();
		_pfxEmitter3.Stop();
		Material material = ((Renderer)_Model1).GetMaterial();
		material.SetFloatImpl(_AlphaMul, 0f);
		Material material2 = ((Renderer)_Model2).GetMaterial();
		material2.SetFloatImpl(_AlphaMul, 0f);
		Material material3 = ((Renderer)_Model3).GetMaterial();
		material3.SetFloatImpl(_AlphaMul, 0f);
		float2 float5 = base.position;
		PhaserSprite phaserSprite2 = _displayImage.setPosition(float5);
		PhaserSprite phaserSprite3 = _displayImage.setBlendMode(BlendMode.Add);
		Transform transform = RenderingExtensions.SetScale(_M1CachedT, 0f);
		Transform transform2 = RenderingExtensions.SetScale(_M2CachedT, 0f);
		Transform transform3 = RenderingExtensions.SetScale(_M3CachedT, 0f);
		Material material4 = ((Renderer)_Model2).GetMaterial();
		material4.SetFloatImpl(_AlphaMul, 0f);
		Material material5 = ((Renderer)_Model3).GetMaterial();
		material5.SetFloatImpl(_AlphaMul, 0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1573 Invalid \"Jump target not found in method: 0x187244240\"");
		throw new NullReferenceException();
	}

	private unsafe void OnRecycle()
	{
		//IL_004a: Expected O, but got Ref
		//IL_0062: Expected O, but got Ref
		//IL_007f: Expected O, but got Ref
		//IL_009c: Expected O, but got Ref
		//IL_00be: Expected O, but got Ref
		//IL_00db: Expected O, but got Ref
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		CS_0024_003C_003E8__locals17.fadeDuration = 0.1f;
		float num = _weapon.PArea();
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_M1CachedT, (Vector3)(&obj), 0.65f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_M2CachedT, (Vector3)(&obj), 0.65f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_M3CachedT, (Vector3)(&obj), 0.65f);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(_M1CachedT, (Vector3)(&obj), 0.65f);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore5 = ShortcutExtensions.DOLocalRotate(_M2CachedT, (Vector3)(&obj), 0.65f);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DOLocalRotate(_M3CachedT, (Vector3)(&obj), 0.65f);
		Material material = ((Renderer)_Model2).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore7 = ShortcutExtensions.DOFloat(material, 1f, _AlphaMul, CS_0024_003C_003E8__locals17.fadeDuration);
		Material material2 = ((Renderer)_Model3).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore8 = ShortcutExtensions.DOFloat(material2, 1f, _AlphaMul, CS_0024_003C_003E8__locals17.fadeDuration);
		Action onComplete = delegate
		{
			EME_SpellFirerProjectile eME_SpellFirerProjectile = CS_0024_003C_003E8__locals17._003C_003E4__this;
			RenderingExtensions.Start(eME_SpellFirerProjectile._pfxEmitter);
			EME_SpellFirerProjectile eME_SpellFirerProjectile2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			RenderingExtensions.Start(eME_SpellFirerProjectile2._pfxEmitter2);
			EME_SpellFirerProjectile eME_SpellFirerProjectile3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			RenderingExtensions.Start(eME_SpellFirerProjectile3._pfxEmitter3);
		};
		float duration = CS_0024_003C_003E8__locals17.fadeDuration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			EME_SpellFirerProjectile eME_SpellFirerProjectile = CS_0024_003C_003E8__locals17._003C_003E4__this;
			eME_SpellFirerProjectile._pfxEmitter.Stop();
			EME_SpellFirerProjectile eME_SpellFirerProjectile2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			eME_SpellFirerProjectile2._pfxEmitter2.Stop();
			EME_SpellFirerProjectile eME_SpellFirerProjectile3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			eME_SpellFirerProjectile3._pfxEmitter3.Stop();
		};
		float num2 = 0.65f - CS_0024_003C_003E8__locals17.fadeDuration;
		float duration2 = num2 * 0.001f;
		Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			//IL_0080: Expected I, but got O
			EME_SpellFirerProjectile eME_SpellFirerProjectile = CS_0024_003C_003E8__locals17._003C_003E4__this;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore9 = ShortcutExtensions.DOScale(eME_SpellFirerProjectile._M1CachedT, 0f, CS_0024_003C_003E8__locals17.fadeDuration);
			Material material3 = ((Renderer)eME_SpellFirerProjectile._Model2).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore10 = ShortcutExtensions.DOFloat(material3, 1f, _AlphaMul, CS_0024_003C_003E8__locals17.fadeDuration);
			Material material4 = ((Renderer)eME_SpellFirerProjectile._Model3).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore11 = ShortcutExtensions.DOFloat(material4, 1f, _AlphaMul, CS_0024_003C_003E8__locals17.fadeDuration);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpellFirerProjectile>)+370]");
			Action onComplete4 = new Action(eME_SpellFirerProjectile, (IntPtr)0);
			nint num3 = (nint)eME_SpellFirerProjectile;
			float duration3 = CS_0024_003C_003E8__locals17.fadeDuration * 0.001f;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer despawnTimer = Timers.Register(duration3, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			eME_SpellFirerProjectile._DespawnTimer = despawnTimer;
		};
		Timer timer3 = Timers.Register(0.00065f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void FadeOut(float fadeDuration)
	{
		//IL_0063: Expected I, but got O
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_M1CachedT, 0f, fadeDuration);
		Material material = ((Renderer)_Model2).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material, 1f, _AlphaMul, fadeDuration);
		Material material2 = ((Renderer)_Model3).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore3 = ShortcutExtensions.DOFloat(material2, 1f, _AlphaMul, fadeDuration);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpellFirerProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		float duration = fadeDuration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_DespawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		_pfxEmitter.Stop();
		_pfxEmitter2.Stop();
		_pfxEmitter3.Stop();
		if (_DespawnTimer != null)
		{
			_DespawnTimer.Cancel();
		}
		base.Despawn();
	}

	static EME_SpellFirerProjectile()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}
}
