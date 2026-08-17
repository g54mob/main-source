using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class CherryProjectile : Projectile
{
	private SpriteRenderer _ringRenderer;

	private SpriteRenderer _rainbowRenderer;

	private SpriteRenderer _raysRenderer;

	private Tween _angleTween;

	private Tween _speedTween;

	private Tween _scaleTween;

	private Tween _bodyScaleTween;

	private Sequence _tween1;

	private Sequence _tween2;

	private Tween _tween3;

	private Sequence _tween4;

	private Sequence _tween5;

	private Tween _tween6;

	private Timer _bounceTimer;

	private float _save_vel_x;

	private float _save_vel_y;

	private Vector2 _aimVector;

	private bool _canBounce;

	private float _bombDeceleration;

	private uint[] _onEmitCustomTints;

	private uint[] _onEmitcustomTint2;

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _fwEmitter;

	private ParticleSystem _fwEmitter2;

	private Circle _a;

	private bool _particlesGenerated;

	private CherryWeapon _trueWeapon;

	protected override void Awake()
	{
		base.Awake();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_0aa9: Expected I, but got O
		//IL_01a8: Expected O, but got Ref
		//IL_01d3: Expected O, but got I4
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected Ref, but got Unknown
		//IL_0215: Expected O, but got I4
		//IL_0294: Expected O, but got I4
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected I4, but got Unknown
		//IL_02f6: Expected O, but got I4
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected I4, but got Unknown
		//IL_0558: Expected O, but got Ref
		//IL_067a: Expected I4, but got I8
		//IL_0824: Expected O, but got I4
		//IL_08b6: Expected O, but got I4
		//IL_09b2: Expected I4, but got F4
		//IL_09de: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_0a6a;
		}
		nint num = (nint)typeof(CherryWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v76 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v76 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v123+FFFFFFF8+v71 @ rax_v118*8]");
			if (0 == (nint)typeof(CherryWeapon))
			{
				obj3 = 1;
				goto IL_0a79;
			}
		}
		obj3 = 0;
		goto IL_0a79;
		IL_0a79:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_0a6a;
		IL_0a6a:
		_trueWeapon = (CherryWeapon)trueWeapon;
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		BaseBody baseBody3 = body;
		_canBounce = true;
		baseBody3._bounce = (float2)1065353216;
		_ = 1065353216;
		ResetRenderers();
		_isCullable = false;
		_save_vel_x = 1f;
		_save_vel_y = 1f;
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num5 = 0;
		float num6 = _weapon.PArea();
		object obj4 = default(object);
		float num7 = (float)obj4 * 0.5f;
		float num8 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rbx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num9 = num8 * 0f;
		Vector3 vector = default(Vector3);
		_cachedTransform.localScale = (Vector3)(&vector);
		GameManager core = GM.Core;
		bool flag2 = !core._003CIsHalloween_003Ek__BackingField;
		float? num10 = (float?)(object)1;
		if (!flag2)
		{
			Sprite sprite = SpriteManager.GetSprite("pumpkin", "vfx");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			num10 = (float?)(object)0;
		}
		Transform transform = SetForNearestEnemy(ref *(Vector2*)(this + 328));
		ArcadeSprite sprite2 = _sprite;
		BaseBody baseBody4 = sprite2.body;
		baseBody4._velocity = _aimVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CherryProjectile)+14C]");
		_ = 0;
		GenerateParticleSystems();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
		object obj5 = 0 * 2;
		int num11 = index - obj5;
		RenderingExtensions.SetFrame(_fwEmitter, num11);
		Weapon weapon2 = _weapon;
		float num12 = (float)((Equipment)weapon2)._003CLevel_003Ek__BackingField / 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		object obj6 = num11 * 4;
		int quantity = obj6 + 8;
		RenderingExtensions.SetQuantity(_fwEmitter, quantity);
		float num13 = _weapon.PArea();
		float num14 = _weapon.PArea();
		float max = num12 * 100f;
		float min = num12 * 50f;
		RenderingExtensions.SetSpeed(_fwEmitter, min, max);
		_fwEmitter.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		Weapon weapon3 = _weapon;
		float num15 = (float)((Equipment)weapon3)._003CLevel_003Ek__BackingField / 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int quantity2 = 8 + 8;
		RenderingExtensions.SetQuantity(_fwEmitter2, quantity2);
		float num16 = _weapon.PArea();
		float num17 = _weapon.PArea();
		float num18 = num15 * 10f;
		float min2 = num15 * 5f;
		RenderingExtensions.SetSpeed(_fwEmitter2, min2, num18);
		Circle a = _a;
		float num19 = _weapon.PArea();
		float num20 = num18 * 8f;
		float num21 = (a._radius = num20 * 8f);
		float diameter = num21 + num21;
		a._diameter = diameter;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _a;
		RenderingExtensions.SetEmitZone(_fwEmitter2, emitZone);
		_fwEmitter2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		bool flag3 = _angleTween == null;
		ParticleSystemStopBehavior particleSystemStopBehavior = ParticleSystemStopBehavior.StopEmittingAndClear;
		if (!flag3)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
			particleSystemStopBehavior = ParticleSystemStopBehavior.StopEmittingAndClear;
		}
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&vector), 1f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1113 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1113 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1113 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1113 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
		Tween tween = default(Tween);
		if (tween != null && tween._003Cactive_003Ek__BackingField && !tween.creationLocked)
		{
			tween.loops = -1;
			tween.loopType = LoopType.Restart;
			if (((ABSSequentiable)tween).tweenType == TweenType.Tweener)
			{
				tween.fullDuration = 1f / 0f;
			}
		}
		_angleTween = tween;
		Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(_angleTween);
		_bombDeceleration = 1f;
		if (_speedTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_speedTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((CherryProjectile)(object)dOSetter)._003CInitProjectile_003Eb__28_1(-360f);
		float num22 = _weapon.PDuration();
		object obj7 = default(object);
		float num23 = (float)obj7 * 0.75f;
		float duration = num23 * 0.001f;
		TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, duration);
		float num24 = _weapon.PDuration();
		float num25 = (float)obj7 * 0.25f;
		float delay = num25 * 0.001f;
		TweenerCore<float, float, FloatOptions> t2 = TweenSettingsExtensions.SetDelay(t, delay);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, delay);
		TweenCallback tweenCallback = TryDetonate;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
		Tween speedTween = default(Tween);
		_speedTween = speedTween;
		Tween tween3 = VampireSurvivors.Tools.TweenExtensions.SetGameId(_speedTween);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float num26 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, num26);
		CherryWeapon trueWeapon2 = _trueWeapon;
		if (!trueWeapon2.isStars)
		{
			return;
		}
		bool flag4 = _indexInWeapon == 0;
		ParticleSystem fwEmitter;
		string item;
		List<string> list2;
		if (!flag4)
		{
			object obj8 = _indexInWeapon - 1;
			if (!flag4)
			{
				if ((nint)obj8 != 1)
				{
					goto IL_09b7;
				}
				fwEmitter = _fwEmitter;
				List<string> list = new List<string>();
				list.Add("2Spell3Red");
				item = "2Spell4Red";
				list2 = list;
			}
			else
			{
				fwEmitter = _fwEmitter;
				List<string> list3 = new List<string>();
				list3.Add("2Spell3Purple");
				item = "2Spell4Purple";
				list2 = list3;
			}
		}
		else
		{
			fwEmitter = _fwEmitter;
			List<string> list4 = new List<string>();
			list4.Add("2Spell3Blue");
			item = "2Spell4Blue";
			list2 = list4;
		}
		list2.Add(item);
		RenderingExtensions.SetFrames(fwEmitter, list2, null, clearExistingFrames: false, (int)num26);
		goto IL_09b7;
		IL_09b7:
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(3f, 0f);
		object obj9 = default(object);
		RenderingExtensions.SetScale(_fwEmitter, (ParticleSystem.MinMaxCurve)(&obj9));
		uint[] onEmitcustomTint = _onEmitcustomTint2;
		int num27 = UnityEngine.Random.Range(0, onEmitcustomTint.Length);
		uint[] onEmitcustomTint2 = _onEmitcustomTint2;
		ParticleSystem particleSystem = RenderingExtensions.SetTint(_fwEmitter2, onEmitcustomTint2[num27]);
		SetIsStar();
	}

	private void ResetRenderers()
	{
		if ((object)_renderer != null)
		{
			_renderer.enabled = true;
			Sprite sprite = SpriteManager.GetSprite("Cherry", "items");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
			if ((object)_renderer != null)
			{
				Transform transform = _renderer.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				_ringRenderer.enabled = false;
				_rainbowRenderer.enabled = false;
				_raysRenderer.enabled = false;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006f: Expected O, but got I
		//IL_02ab: Expected O, but got I4
		//IL_02c4: Expected O, but got Ref
		//IL_02de: Expected native int or pointer, but got O
		//IL_02f8: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_0332: Expected native int or pointer, but got O
		//IL_1485: Expected O, but got I4
		//IL_0365: Expected O, but got Ref
		//IL_037f: Expected native int or pointer, but got O
		//IL_0399: Expected O, but got I
		//IL_03b9: Expected O, but got Ref
		//IL_03d3: Expected native int or pointer, but got O
		//IL_14bf: Expected O, but got I
		//IL_040b: Expected O, but got Ref
		//IL_0432: Expected O, but got I
		//IL_044c: Expected native int or pointer, but got O
		//IL_14f9: Expected O, but got I
		//IL_04a3: Expected O, but got I
		//IL_04c4: Expected O, but got I
		//IL_05d6: Expected O, but got I
		//IL_0664: Expected O, but got I
		//IL_06f2: Expected O, but got I
		//IL_0780: Expected O, but got I
		//IL_080e: Expected O, but got I
		//IL_089c: Expected O, but got I
		//IL_092a: Expected O, but got I
		//IL_09b8: Expected O, but got I
		//IL_0a46: Expected O, but got I
		//IL_0ad4: Expected O, but got I
		//IL_0b62: Expected O, but got I
		//IL_0bf0: Expected O, but got I
		//IL_0c7e: Expected O, but got I
		//IL_0d0c: Expected O, but got I
		//IL_0d9a: Expected O, but got I
		//IL_0e28: Expected O, but got I
		//IL_0eb6: Expected O, but got I
		//IL_0f44: Expected O, but got I
		//IL_0fd2: Expected O, but got I
		//IL_1060: Expected O, but got I
		//IL_10b0: Expected O, but got I4
		//IL_10c9: Expected O, but got Ref
		//IL_10e3: Expected native int or pointer, but got O
		//IL_10fd: Expected O, but got I
		//IL_111d: Expected O, but got Ref
		//IL_1137: Expected native int or pointer, but got O
		//IL_115f: Expected O, but got I
		//IL_117f: Expected O, but got I
		//IL_11b5: Expected O, but got Ref
		//IL_11cf: Expected native int or pointer, but got O
		//IL_11ee: Expected O, but got I
		//IL_1209: Expected O, but got Ref
		//IL_1223: Expected native int or pointer, but got O
		//IL_1268: Expected O, but got I
		//IL_12a7: Expected O, but got Ref
		//IL_12bc: Expected O, but got I
		//IL_12d6: Expected native int or pointer, but got O
		//IL_131b: Expected O, but got I
		//IL_135c: Expected O, but got I
		//IL_1397: Expected O, but got I
		//IL_1445: Expected O, but got Ref
		//IL_1455->IL1573: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_particlesGenerated)
		{
			GameObject gameObject = base.gameObject;
			_ = 0;
			ParticleEmitterManager particleEmitterManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 496))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
				particleEmitterManager = (ParticleEmitterManager)0;
			}
			else
			{
				particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_particleEmitterManager = particleEmitterManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_blur");
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
				((List<object>)(object)list).AddWithResize((object)"_blur2");
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
				((List<object>)(object)list).AddWithResize((object)"_blur3");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 1f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			_ = 0;
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
			_ = 0;
			particleSystemConfig._alphaEase = Easing.OutExpo;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			_ = 0;
			_ = 64;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
			_ = 0;
			_ = 0;
			_ = 1115684864;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			particleSystemConfig._on = false;
			ParticleSystem fwEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig, null, "_fwEmitter");
			_fwEmitter = fwEmitter;
			Transform transform = _fwEmitter.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = _a;
			emitZone._type = EmitZoneType.Random;
			emitZone._yoyo = false;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			List<string> list2 = new List<string>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v855 @ rcx_v56 (System.IntPtr)+18]");
			if (num4 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0000");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj3 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v856 @ rcx_v58 (System.IntPtr)+18]");
			if (num5 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0001");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr3 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v857 @ rcx_v60 (System.IntPtr)+18]");
			if (num6 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0002");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj5 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr4 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rcx_v62 (System.IntPtr)+18]");
			if (num7 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0003");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr5 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ rcx_v64 (System.IntPtr)+18]");
			if (num8 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0004");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj7 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr6 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rcx_v66 (System.IntPtr)+18]");
			if (num9 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0005");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj8 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr7 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rcx_v68 (System.IntPtr)+18]");
			if (num10 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0006");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj9 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr8 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v70 (System.IntPtr)+18]");
			if (num11 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0007");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj10 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr9 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rcx_v72 (System.IntPtr)+18]");
			if (num12 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0008");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj11 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr10 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v864 @ rcx_v74 (System.IntPtr)+18]");
			if (num13 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0009");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj12 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr11 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ rcx_v76 (System.IntPtr)+18]");
			if (num14 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0010");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj13 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr12 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ rcx_v78 (System.IntPtr)+18]");
			if (num15 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0011");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj14 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr13 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rcx_v80 (System.IntPtr)+18]");
			if (num16 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0012");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj15 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr14 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v868 @ rcx_v82 (System.IntPtr)+18]");
			if (num17 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0013");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj16 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr15 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rcx_v84 (System.IntPtr)+18]");
			if (num18 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0014");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj17 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr16 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rcx_v86 (System.IntPtr)+18]");
			if (num19 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0015");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj18 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr17 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ rcx_v88 (System.IntPtr)+18]");
			if (num20 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0016");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj19 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr18 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rcx_v90 (System.IntPtr)+18]");
			if (num21 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0017");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj20 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr19 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ rcx_v92 (System.IntPtr)+18]");
			if (num22 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0018");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj21 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
			_ = (nint)0 + (nint)1;
			IntPtr cachedPtr20 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
			nint num23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rcx_v94 (System.IntPtr)+18]");
			if (num23 >= 0)
			{
				((List<object>)(object)list2).AddWithResize((object)"leaf0019");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
				object obj22 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			particleSystemConfig2._fps = 30;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1200f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
			obj = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
			_ = 0;
			particleSystemConfig2._alphaEase = Easing.OutExpo;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(50f, 100f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
			_ = 0;
			_ = 0;
			_ = 64;
			_ = 1;
			ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(2f, 0.1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
			_ = 0;
			_ = 0;
			_ = 1115684864;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			particleSystemConfig2._tintRandom = _onEmitCustomTints;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			particleSystemConfig2._blendMode = (BlendMode?)(object)0;
			particleSystemConfig2._emitZone = emitZone;
			particleSystemConfig2._on = false;
			bool flag2 = (object)_particleEmitterManager == null;
			ParticleSystem fwEmitter2 = _particleEmitterManager.CreateEmitter(particleSystemConfig2, null, "_fwEmitter2");
			_fwEmitter2 = fwEmitter2;
			bool flag3 = (object)_fwEmitter2 == null;
			Transform transform2 = _fwEmitter2.transform;
			bool flag4 = (object)transform2 == null;
			object obj23 = default(object);
			transform2.localPosition = (Vector3)(&obj23);
			_particlesGenerated = true;
		}
	}

	private unsafe void TryDetonate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1844: Expected O, but got F4
		//IL_008c: Invalid comparison between F4 and O
		//IL_12a3: Expected I, but got O
		//IL_135c: Expected I, but got O
		//IL_139d: Expected O, but got Ref
		//IL_1410: Expected O, but got Ref
		//IL_1481: Expected I, but got O
		//IL_04d6: Expected O, but got I8
		//IL_14d9: Expected O, but got Ref
		//IL_05c8: Expected O, but got Ref
		//IL_153b: Expected O, but got Ref
		//IL_1579: Expected I, but got O
		//IL_15d1: Expected O, but got Ref
		//IL_165d: Expected O, but got Ref
		//IL_0ab0: Expected O, but got Ref
		//IL_0d12: Expected F4, but got I4
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffa: Expected O, but got Unknown
		//IL_1011: Unknown result type (might be due to invalid IL or missing references)
		//IL_1016: Expected O, but got Unknown
		//IL_102d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1032: Expected O, but got Unknown
		//IL_187b: Expected O, but got I4
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1890: Expected O, but got Unknown
		//IL_17e7: Expected O, but got I4
		//IL_180c: Expected O, but got I
		//IL_11b5: Expected O, but got I
		//IL_032e->IL1342: Incompatible stack heights: 6 vs 0
		//IL_035d->IL1342: Incompatible stack heights: 6 vs 0
		//IL_146e->IL1342: Incompatible stack heights: 6 vs 0
		//IL_04ff->IL1342: Incompatible stack heights: 6 vs 0
		//IL_05a6->IL1342: Incompatible stack heights: 6 vs 0
		//IL_16c0->IL1342: Incompatible stack heights: 6 vs 0
		//IL_1677->IL144a: Incompatible stack heights: 18 vs 6
		//IL_16df->IL1342: Incompatible stack heights: 6 vs 0
		//IL_086c->IL1342: Incompatible stack heights: 6 vs 0
		//IL_16fe->IL1342: Incompatible stack heights: 6 vs 0
		//IL_0975->IL1342: Incompatible stack heights: 6 vs 0
		//IL_0a88->IL1342: Incompatible stack heights: 6 vs 0
		//IL_171d->IL1342: Incompatible stack heights: 6 vs 0
		//IL_0bde->IL1342: Incompatible stack heights: 6 vs 0
		//IL_0c0c->IL1342: Incompatible stack heights: 6 vs 0
		//IL_173c->IL1342: Incompatible stack heights: 6 vs 0
		//IL_0e54->IL1342: Incompatible stack heights: 6 vs 0
		//IL_175b->IL1342: Incompatible stack heights: 6 vs 0
		//IL_17a9->IL1342: Incompatible stack heights: 6 vs 0
		//IL_11e7->IL11e7: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = UnityEngine.Random.value;
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			WeaponData currentWeaponData = weapon._currentWeaponData;
			if (weapon._currentWeaponData != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PLuck();
				object obj4 = default(object);
				float num2 = (float)obj4 * currentWeaponData._003Cchance_003Ek__BackingField;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
				{
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null && weapon2._playerOptions != null)
					{
						PlayerOptionsData config = weapon2._playerOptions.Config;
						if (config != null)
						{
							if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
							{
								if ((object)_renderer != null)
								{
									_renderer.enabled = false;
									goto IL_01da;
								}
							}
							else if ((object)_renderer != null)
							{
								_renderer.enabled = true;
								Sprite sprite = SpriteManager.GetSprite("blurBlack", "items");
								ArcadeSprite arcadeSprite = setFrame(sprite);
								goto IL_01da;
							}
						}
					}
				}
				else
				{
					if (_scaleTween != null)
					{
						DG.Tweening.TweenExtensions.Kill(_scaleTween);
					}
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 0.3f);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 1;
							_ = 0;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v965 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+370]");
					TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
						return;
					}
				}
			}
		}
		goto IL_1342;
		IL_144a:
		Weapon weapon3 = _weapon;
		TweenerCore<Color, Color, ColorOptions> tweenerCore2;
		if ((object)_weapon != null)
		{
			int num4 = ((Equipment)weapon3)._003CLevel_003Ek__BackingField;
			if (((Equipment)weapon3)._003CLevel_003Ek__BackingField < 3)
			{
				num4 = 3;
			}
			float num5 = (float)num4 * 0.125f;
			if (_tween1 != null)
			{
				DG.Tweening.TweenExtensions.Kill(_tween1);
			}
			Sequence tween = DOTween.Sequence();
			ParticleSystem particleSystem = (ParticleSystem)6603577472L;
			_tween1 = tween;
			if ((object)_ringRenderer != null)
			{
				Transform target = _ringRenderer.transform;
				float endValue = num5 * 4f;
				TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, endValue, 0.1f);
				if (TweenSettingsExtensions.ValidateAddToSequence(_tween1, (Tween)t, false))
				{
					Sequence sequence = Sequence.DoInsert(_tween1, (Tween)t, 0f);
				}
				if ((object)_ringRenderer != null)
				{
					Transform target2 = _ringRenderer.transform;
					Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					_ = 360f;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DORotate(target2, endValue2, 0.1f, RotateMode.FastBeyond360);
					if (TweenSettingsExtensions.ValidateAddToSequence(_tween1, (Tween)t2, false))
					{
						Sequence sequence2 = Sequence.DoInsert(_tween1, (Tween)t2, 0f);
					}
					Sequence tween2 = _tween1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (_tween1 != null)
					{
						tween2.stringId = "DefaultGameTweenId";
						if (_tween2 != null)
						{
							DG.Tweening.TweenExtensions.Kill(_tween2);
						}
						Sequence tween3 = DOTween.Sequence();
						_tween2 = tween3;
						TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleSprite.DOFade(_ringRenderer, 0f, 0.1f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_tween2, (Tween)t3, false))
						{
							Sequence sequence3 = Sequence.DoInsert(_tween2, (Tween)t3, 0f);
						}
						TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(_raysRenderer, 0f, 0.1f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_tween2, (Tween)t4, false))
						{
							Sequence sequence4 = Sequence.DoInsert(_tween2, (Tween)t4, 0f);
						}
						Sequence sequence5 = TweenSettingsExtensions.SetDelay(_tween2, 0.1f);
						Sequence tween4 = _tween2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (_tween2 != null)
						{
							tween4.stringId = "DefaultGameTweenId";
							if (_tween3 != null)
							{
								DG.Tweening.TweenExtensions.Kill(_tween3);
							}
							if ((object)_raysRenderer != null)
							{
								Transform target3 = _raysRenderer.transform;
								float endValue3 = num5 * 3f;
								TweenerCore<Vector3, Vector3, VectorOptions> tween5 = ShortcutExtensions.DOScale(target3, endValue3, 0.1f);
								_tween3 = tween5;
								Tween tween6 = _tween3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (_tween3 != null)
								{
									tween6.stringId = "DefaultGameTweenId";
									if (_tween4 != null)
									{
										DG.Tweening.TweenExtensions.Kill(_tween4);
									}
									Sequence tween7 = DOTween.Sequence();
									_tween4 = tween7;
									if ((object)_rainbowRenderer != null)
									{
										Transform target4 = _rainbowRenderer.transform;
										float endValue4 = num5 * 5f;
										TweenerCore<Vector3, Vector3, VectorOptions> t5 = ShortcutExtensions.DOScale(target4, endValue4, 0.5f);
										if (TweenSettingsExtensions.ValidateAddToSequence(_tween4, (Tween)t5, false))
										{
											Sequence sequence6 = Sequence.DoInsert(_tween4, (Tween)t5, 0f);
										}
										TweenerCore<Color, Color, ColorOptions> t6 = DOTweenModuleSprite.DOFade(_rainbowRenderer, 0f, 0.5f);
										if (TweenSettingsExtensions.ValidateAddToSequence(_tween4, (Tween)t6, false))
										{
											Sequence sequence7 = Sequence.DoInsert(_tween4, (Tween)t6, 0f);
										}
										if ((object)_rainbowRenderer != null)
										{
											Transform target5 = _rainbowRenderer.transform;
											_ = 360f;
											Vector3 endValue5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
											TweenerCore<Quaternion, Vector3, QuaternionOptions> t7 = ShortcutExtensions.DORotate(target5, endValue5, 0.5f);
											if (TweenSettingsExtensions.ValidateAddToSequence(_tween4, (Tween)t7, false))
											{
												Sequence sequence8 = Sequence.DoInsert(_tween4, (Tween)t7, 0f);
											}
											Sequence tween8 = _tween4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											if (_tween4 != null)
											{
												tween8.stringId = "DefaultGameTweenId";
												if (_tween5 != null)
												{
													DG.Tweening.TweenExtensions.Kill(_tween5);
												}
												Sequence tween9 = DOTween.Sequence();
												_tween5 = tween9;
												if ((object)_renderer != null)
												{
													Transform target6 = _renderer.transform;
													if ((object)_weapon != null)
													{
														float num6 = _weapon.PArea();
														object obj5 = default(object);
														float num7 = (float)obj5 * 8f;
														TweenerCore<Vector3, Vector3, VectorOptions> t8 = ShortcutExtensions.DOScale(target6, num7, 0.120000005f);
														if (TweenSettingsExtensions.ValidateAddToSequence(_tween5, (Tween)t8, false))
														{
															Sequence sequence9 = Sequence.DoInsert(_tween5, (Tween)t8, 0f);
														}
														TweenerCore<Color, Color, ColorOptions> t9 = DOTweenModuleSprite.DOFade(_renderer, 0.1f, 0.120000005f);
														bool flag = TweenSettingsExtensions.ValidateAddToSequence(_tween5, (Tween)t9, false);
														bool flag2 = !flag;
														float num8 = 0.120000005f;
														if (!flag2)
														{
															Sequence sequence10 = Sequence.DoInsert(_tween5, (Tween)t9, 0f);
															num8 = 0f;
														}
														Sequence tween10 = _tween5;
														TweenCallback onComplete = delegate
														{
															//IL_00ad->IL004c: Incompatible stack heights: 1 vs 0
															//IL_010c->IL004c: Incompatible stack heights: 2 vs 0
															ParticleSystem fwEmitter = _fwEmitter;
															if ((object)_fwEmitter != null)
															{
																bool flag22 = ((UnityEngine.Object)fwEmitter).m_CachedPtr == (IntPtr)0;
																ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
																ParticleSystem fwEmitter2 = _fwEmitter2;
																if ((object)_fwEmitter2 != null)
																{
																	bool flag23 = ((UnityEngine.Object)fwEmitter2).m_CachedPtr == (IntPtr)0;
																	ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
																	BaseBody baseBody = body;
																	if (body != null)
																	{
																		baseBody._enable = false;
																		return;
																	}
																}
															}
															throw new NullReferenceException();
														};
														if (_tween5 != null && ((Tween)tween10)._003Cactive_003Ek__BackingField)
														{
															tween10.onComplete = onComplete;
														}
														Sequence tween11 = _tween5;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														if (_tween5 != null)
														{
															tween11.stringId = "DefaultGameTweenId";
															if (_bodyScaleTween != null)
															{
																DG.Tweening.TweenExtensions.Kill(_bodyScaleTween);
															}
															DOGetter<float> getter = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
															DOSetter<float> dOSetter = null;
															((CherryProjectile)(object)dOSetter)._003CTryDetonate_003Eb__31_2(0.1f);
															if ((object)_weapon != null)
															{
																float num9 = _weapon.PArea();
																float num10 = num7 * 0.08f;
																float endValue6 = num10 * 8f;
																TweenerCore<float, float, FloatOptions> bodyScaleTween = DOTween.To(getter, dOSetter, endValue6, 0.120000005f);
																_bodyScaleTween = bodyScaleTween;
																Tween bodyScaleTween2 = _bodyScaleTween;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
																if (_bodyScaleTween != null)
																{
																	bodyScaleTween2.stringId = "DefaultGameTweenId";
																	if (_tween6 != null)
																	{
																		DG.Tweening.TweenExtensions.Kill(_tween6);
																	}
																	TweenerCore<Color, Color, ColorOptions> t10 = DOTweenModuleSprite.DOFade(_renderer, 0.1f, 0.1f);
																	tweenerCore2 = TweenSettingsExtensions.SetDelay(t10, 0.2f);
																	TweenCallback tweenCallback2 = delegate
																	{
																		Weapon weapon5 = _weapon;
																		PlayerOptionsData config3 = weapon5._playerOptions.Config;
																		if (config3._003CFlashingVFXEnabled_003Ek__BackingField)
																		{
																			RenderingExtensions.Start(_fwEmitter);
																		}
																	};
																	TweenCallback tweenCallback4;
																	if (tweenerCore2 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4353 @ rax_v165 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																			if ((nint)0 != 0)
																			{
																				object obj6 = tweenerCore2 + 32;
																				object obj7 = obj6 >> 12;
																				object obj8 = obj7 & 0x1FFFFF;
																				object obj9 = obj8 >> 6;
																				object obj10 = obj8 & 0x3F;
																				nint num12;
																				do
																				{
																					object obj11 = 1 << (int)obj10;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v16 (UnityEngine.ParticleSystem)+462E0+v4413 @ rdx_v112*8]");
																					object obj12 = 0 | obj11;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v16 (UnityEngine.ParticleSystem)+462E0+v4413 @ rdx_v112*8]");
																					nint num11 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v16 (UnityEngine.ParticleSystem)+462E0+v4413 @ rdx_v112*8]");
																					if (num11 == 0)
																					{
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v16 (UnityEngine.ParticleSystem)+462E0+v4413 @ rdx_v112*8]");
																					num12 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v16 (UnityEngine.ParticleSystem)+462E0+v4413 @ rdx_v112*8]");
																				}
																				while (num12 != 0);
																				TweenCallback tweenCallback3 = delegate
																				{
																					//IL_0199: Expected I, but got O
																					//IL_013e->IL00b4: Incompatible stack heights: 1 vs 0
																					//IL_01cd->IL00b4: Incompatible stack heights: 2 vs 0
																					ParticleSystem fwEmitter = _fwEmitter;
																					if ((object)_fwEmitter != null)
																					{
																						bool flag22 = ((UnityEngine.Object)fwEmitter).m_CachedPtr == (IntPtr)0;
																						ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
																						ParticleSystem fwEmitter2 = _fwEmitter2;
																						if ((object)_fwEmitter2 != null)
																						{
																							bool flag23 = ((UnityEngine.Object)fwEmitter2).m_CachedPtr == (IntPtr)0;
																							ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
																							float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_fwEmitter);
																							float remainingLifetime2 = RenderingExtensions.GetRemainingLifetime(_fwEmitter2);
																							bool flag24 = remainingLifetime > remainingLifetime2;
																							float delay = remainingLifetime;
																							if (!flag24)
																							{
																								delay = remainingLifetime2;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+370]");
																							TweenCallback callback = new TweenCallback(this, (IntPtr)0);
																							nint num19 = (nint)this;
																							Tween tween13 = DOVirtual.DelayedCall(delay, callback, ignoreTimeScale: false);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																							if ((nint)0 == 0)
																							{
																								_ = 1;
																							}
																							if (tween13 != null)
																							{
																								tween13.stringId = "DefaultGameTweenId";
																								return;
																							}
																						}
																					}
																					throw new NullReferenceException();
																				};
																				tweenCallback4 = tweenCallback3;
																				goto IL_109f;
																			}
																		}
																	}
																	TweenCallback tweenCallback5 = delegate
																	{
																		//IL_0199: Expected I, but got O
																		//IL_013e->IL00b4: Incompatible stack heights: 1 vs 0
																		//IL_01cd->IL00b4: Incompatible stack heights: 2 vs 0
																		ParticleSystem fwEmitter = _fwEmitter;
																		if ((object)_fwEmitter != null)
																		{
																			bool flag22 = ((UnityEngine.Object)fwEmitter).m_CachedPtr == (IntPtr)0;
																			ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
																			ParticleSystem fwEmitter2 = _fwEmitter2;
																			if ((object)_fwEmitter2 != null)
																			{
																				bool flag23 = ((UnityEngine.Object)fwEmitter2).m_CachedPtr == (IntPtr)0;
																				ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
																				float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_fwEmitter);
																				float remainingLifetime2 = RenderingExtensions.GetRemainingLifetime(_fwEmitter2);
																				bool flag24 = remainingLifetime > remainingLifetime2;
																				float delay = remainingLifetime;
																				if (!flag24)
																				{
																					delay = remainingLifetime2;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+370]");
																				TweenCallback callback = new TweenCallback(this, (IntPtr)0);
																				nint num19 = (nint)this;
																				Tween tween13 = DOVirtual.DelayedCall(delay, callback, ignoreTimeScale: false);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																				if ((nint)0 == 0)
																				{
																					_ = 1;
																				}
																				if (tween13 != null)
																				{
																					tween13.stringId = "DefaultGameTweenId";
																					return;
																				}
																			}
																		}
																		throw new NullReferenceException();
																	};
																	bool flag3 = tweenerCore2 == null;
																	tweenCallback4 = tweenCallback5;
																	if (!flag3)
																	{
																		goto IL_109f;
																	}
																	goto IL_10ce;
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
		goto IL_1342;
		IL_109f:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4353 @ rax_v165 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_10ce;
		IL_1342:
		throw new NullReferenceException();
		IL_10ce:
		_tween6 = tweenerCore2;
		Tween tween12 = _tween6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_tween6 != null)
		{
			tween12.stringId = "DefaultGameTweenId";
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			_ = 0;
			_ = 1056964608;
			_ = 1;
			soundConfig.Rate = 1f;
			object obj13 = _indexInWeapon - 5;
			float detune = (float)obj13 * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
			soundConfig.Volume = (float?)(object)0;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion2, soundConfig, 150f, 3, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			_ = 0;
			_ = 1036831949;
			_ = 1;
			soundConfig2.Rate = 1f;
			float detune2 = (float)_indexInWeapon * 100f;
			soundConfig2.Rate = 1.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
			soundConfig2.Volume = (float?)(object)0;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Whistle, soundConfig2, 150f, 13, time);
			return;
		}
		goto IL_1342;
		IL_01da:
		RenderingExtensions.Start(_fwEmitter2);
		if ((object)_ringRenderer != null)
		{
			_ringRenderer.enabled = true;
			if ((object)_ringRenderer != null)
			{
				Transform transform = _ringRenderer.transform;
				nint num13 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ rcx_v49 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num14 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1689 @ rax_v60 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj14);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringRenderer, 1f);
				Transform transform2 = _ringRenderer.transform;
				bool flag5 = (object)transform2 == null;
				_ = Quaternion.identityQuaternion;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2056 @ rax_v67 (UnityEngine.Transform)+10]");
				bool flag6 = (nint)0 == 0;
				object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2056 @ rax_v67 (UnityEngine.Transform)+10]");
				Transform.set_localRotation_Injected((IntPtr)0, ref *(Quaternion*)obj15);
				Weapon weapon4 = _weapon;
				bool flag7 = (object)_weapon == null;
				bool flag8 = weapon4._playerOptions == null;
				PlayerOptionsData config2 = weapon4._playerOptions.Config;
				bool flag9 = config2 == null;
				if (!config2._003CFlashingVFXEnabled_003Ek__BackingField)
				{
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringRenderer, 0.5f);
					goto IL_144a;
				}
				if ((object)_rainbowRenderer != null)
				{
					_rainbowRenderer.enabled = true;
					if ((object)_rainbowRenderer != null)
					{
						Transform transform3 = _rainbowRenderer.transform;
						nint num15 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2643 @ rcx_v236 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num16 = 0;
						bool flag10 = (object)transform3 == null;
						_ = Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2641 @ rax_v288 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2696 @ rax_v286 (UnityEngine.Transform)+10]");
						bool flag11 = (nint)0 == 0;
						object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2696 @ rax_v286 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj16);
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_rainbowRenderer, 0.75f);
						bool flag12 = (object)_rainbowRenderer == null;
						Transform transform4 = _rainbowRenderer.transform;
						bool flag13 = (object)transform4 == null;
						_ = Quaternion.identityQuaternion;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2885 @ rax_v296 (UnityEngine.Transform)+10]");
						bool flag14 = (nint)0 == 0;
						object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2885 @ rax_v296 (UnityEngine.Transform)+10]");
						Transform.set_localRotation_Injected((IntPtr)0, ref *(Quaternion*)obj17);
						bool flag15 = (object)_raysRenderer == null;
						_raysRenderer.enabled = true;
						bool flag16 = (object)_raysRenderer == null;
						Transform transform5 = _raysRenderer.transform;
						nint num17 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ rcx_v251 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num18 = 0;
						bool flag17 = (object)transform5 == null;
						_ = Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v306 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3012 @ rax_v304 (UnityEngine.Transform)+10]");
						bool flag18 = (nint)0 == 0;
						object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3012 @ rax_v304 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj18);
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_raysRenderer, 1f);
						bool flag19 = (object)_raysRenderer == null;
						Transform transform6 = _raysRenderer.transform;
						bool flag20 = (object)transform6 == null;
						_ = Quaternion.identityQuaternion;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3258 @ rax_v313 (UnityEngine.Transform)+10]");
						bool flag21 = (nint)0 == 0;
						object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3258 @ rax_v313 (UnityEngine.Transform)+10]");
						Transform.set_localRotation_Injected((IntPtr)0, ref *(Quaternion*)obj19);
						goto IL_144a;
					}
				}
			}
		}
		goto IL_1342;
	}

	public override void Despawn()
	{
		if (_bounceTimer != null)
		{
			_bounceTimer.Cancel();
		}
		Tween speedTween = _speedTween;
		if (_speedTween != null && speedTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_speedTween);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void PlayAudio()
	{
		//IL_00c4: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = _indexInWeapon - 5;
		float detune = (float)obj * 100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion2, soundConfig, 150f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		float detune2 = (float)_indexInWeapon * 100f;
		soundConfig2.Rate = 1.5f;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = detune2;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Whistle, soundConfig2, 150f, 13, time);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && (_canBounce ? 1 : 0) != (nint)obj)
		{
			float save_vel_x = _save_vel_x * -1f;
			_save_vel_x = save_vel_x;
			float save_vel_y = _save_vel_y * -1f;
			_save_vel_y = save_vel_y;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			_canBounce = false;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canBounce = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_01de: Expected O, but got I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
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
				goto IL_0178;
			}
		}
		obj5 = 4294967295L;
		goto IL_0178;
		IL_01f9:
		object obj6;
		float save_vel_y = (float)obj6 * _save_vel_y;
		_save_vel_y = save_vel_y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_0178:
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
				goto IL_01f9;
			}
		}
		obj6 = 4294967295L;
		goto IL_01f9;
	}

	public override void InternalUpdate()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0078: Expected O, but got F4
		object obj = _aimVector * _save_vel_x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CherryProjectile)+14C]");
		object obj2 = 0 * _save_vel_y;
		float num = (float)obj * _bombDeceleration;
		float num2 = (float)obj2 * _bombDeceleration;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
	}

	public void SetIsStar()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0000");
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
			((List<object>)(object)list).AddWithResize((object)"image_004_0001");
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
			((List<object>)(object)list).AddWithResize((object)"image_004_0002");
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
			((List<object>)(object)list).AddWithResize((object)"image_004_0003");
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
			((List<object>)(object)list).AddWithResize((object)"image_004_0004");
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
			((List<object>)(object)list).AddWithResize((object)"image_004_0005");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0006");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0007");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0008");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0009");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0010");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list._version + 1;
		list._version = version12;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0011");
		}
		else
		{
			int num12 = list._size + 1;
			list._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version13 = list._version + 1;
		list._version = version13;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0012");
		}
		else
		{
			int num13 = list._size + 1;
			list._size = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version14 = list._version + 1;
		list._version = version14;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0013");
		}
		else
		{
			int num14 = list._size + 1;
			list._size = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version15 = list._version + 1;
		list._version = version15;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0014");
		}
		else
		{
			int num15 = list._size + 1;
			list._size = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version16 = list._version + 1;
		list._version = version16;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0015");
		}
		else
		{
			int num16 = list._size + 1;
			list._size = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version17 = list._version + 1;
		list._version = version17;
		string[] items17 = list._items;
		if (list._size >= items17.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0016");
		}
		else
		{
			int num17 = list._size + 1;
			list._size = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version18 = list._version + 1;
		list._version = version18;
		string[] items18 = list._items;
		if (list._size >= items18.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0017");
		}
		else
		{
			int num18 = list._size + 1;
			list._size = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version19 = list._version + 1;
		list._version = version19;
		string[] items19 = list._items;
		if (list._size >= items19.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0018");
		}
		else
		{
			int num19 = list._size + 1;
			list._size = num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version20 = list._version + 1;
		list._version = version20;
		string[] items20 = list._items;
		if (list._size >= items20.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0019");
		}
		else
		{
			int num20 = list._size + 1;
			list._size = num20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version21 = list._version + 1;
		list._version = version21;
		string[] items21 = list._items;
		if (list._size >= items21.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0020");
		}
		else
		{
			int num21 = list._size + 1;
			list._size = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version22 = list._version + 1;
		list._version = version22;
		string[] items22 = list._items;
		if (list._size >= items22.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0021");
		}
		else
		{
			int num22 = list._size + 1;
			list._size = num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version23 = list._version + 1;
		list._version = version23;
		string[] items23 = list._items;
		if (list._size >= items23.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"image_004_0022");
		}
		else
		{
			int num23 = list._size + 1;
			list._size = num23;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int cycleCount = default(int);
		RenderingExtensions.SetFrames(_fwEmitter2, list, null, clearExistingFrames: false, cycleCount);
		ParticleSystem particleSystem = RenderingExtensions.SetScale(_fwEmitter2, 0.5f);
	}

	public CherryProjectile()
	{
		//IL_0082: Expected I, but got O
		_save_vel_x = -1f;
		_save_vel_y = -1f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_aimVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_canBounce = true;
		_bombDeceleration = 1f;
		_onEmitCustomTints = new uint[4] { 16746632u, 16746751u, 16746751u, 16777096u };
		_onEmitcustomTint2 = new uint[4] { 4474111u, 16729343u, 16729343u, 16729156u };
		_a = new Circle();
		base._002Ector();
	}

	private float _003CInitProjectile_003Eb__28_0()
	{
		return _bombDeceleration;
	}

	private void _003CInitProjectile_003Eb__28_1(float x)
	{
		_bombDeceleration = x;
	}

	private void _003CTryDetonate_003Eb__31_0()
	{
		//IL_00ad->IL004c: Incompatible stack heights: 1 vs 0
		//IL_010c->IL004c: Incompatible stack heights: 2 vs 0
		ParticleSystem fwEmitter = _fwEmitter;
		if ((object)_fwEmitter != null)
		{
			bool flag = ((UnityEngine.Object)fwEmitter).m_CachedPtr == (IntPtr)0;
			ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
			ParticleSystem fwEmitter2 = _fwEmitter2;
			if ((object)_fwEmitter2 != null)
			{
				bool flag2 = ((UnityEngine.Object)fwEmitter2).m_CachedPtr == (IntPtr)0;
				ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
				BaseBody baseBody = body;
				if (body != null)
				{
					baseBody._enable = false;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private float _003CTryDetonate_003Eb__31_1()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CTryDetonate_003Eb__31_2(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}

	private void _003CTryDetonate_003Eb__31_3()
	{
		Weapon weapon = _weapon;
		PlayerOptionsData config = weapon._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			RenderingExtensions.Start(_fwEmitter);
		}
	}

	private void _003CTryDetonate_003Eb__31_4()
	{
		//IL_0199: Expected I, but got O
		//IL_013e->IL00b4: Incompatible stack heights: 1 vs 0
		//IL_01cd->IL00b4: Incompatible stack heights: 2 vs 0
		ParticleSystem fwEmitter = _fwEmitter;
		if ((object)_fwEmitter != null)
		{
			bool flag = ((UnityEngine.Object)fwEmitter).m_CachedPtr == (IntPtr)0;
			ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
			ParticleSystem fwEmitter2 = _fwEmitter2;
			if ((object)_fwEmitter2 != null)
			{
				bool flag2 = ((UnityEngine.Object)fwEmitter2).m_CachedPtr == (IntPtr)0;
				ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
				float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_fwEmitter);
				float remainingLifetime2 = RenderingExtensions.GetRemainingLifetime(_fwEmitter2);
				bool flag3 = remainingLifetime > remainingLifetime2;
				float delay = remainingLifetime;
				if (!flag3)
				{
					delay = remainingLifetime2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+370]");
				TweenCallback callback = new TweenCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Tween tween = DOVirtual.DelayedCall(delay, callback, ignoreTimeScale: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tween != null)
				{
					tween.stringId = "DefaultGameTweenId";
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003COnHasHitAnObject_003Eb__34_0()
	{
		_canBounce = true;
	}
}
