using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyViciousHunger : EnemyController
{
	protected MeshRenderer eyeMesh;

	protected Transform eyeModel;

	private float _sineF = 1f;

	private MultiTargetTween _spritesDeathTween;

	private MultiTargetTween _wingsAngleTween;

	private bool _isFirstUpdate = true;

	private float _eyeRotationX;

	private float _eyeRotationY;

	private TweenerCore<float, float, FloatOptions> SineTween;

	private MultiTargetTween _disappearTween;

	private TweenerCore<Vector3, Vector3, VectorOptions> _eyeScaleTween;

	private List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> rotationTweens;

	private Circle _explosionCircle;

	private ParticleEmitterManager _pfxEmitter2;

	private ParticleEmitterManager _pfxEmitter;

	protected override void Awake()
	{
		base.Awake();
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		_eyeRotationY = 180f;
		_eyeRotationX = 180f;
	}

	protected void RandomEyeAngle()
	{
		//IL_0228: Expected O, but got F4
		//IL_0231: Invalid comparison between O and F4
		//IL_0240: Expected O, but got I4
		//IL_0257: Expected O, but got F4
		//IL_0013: Expected O, but got I4
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		object obj3 = 300;
		if (!flag)
		{
			obj3 = 200;
		}
		object obj4 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		double num = Math.Sin(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm8,xmm0\"");
		float num2 = 0f * 35f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((EnemyViciousHunger)(object)dOSetter)._003CRandomEyeAngle_003Eb__16_1(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		double num3 = Math.Cos(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm9,xmm0\"");
		float num4 = 0f * 35f;
		float endValue = num4 + 180f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, endValue, 0.2f);
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((EnemyViciousHunger)(object)dOSetter2)._003CRandomEyeAngle_003Eb__16_3(x);
		float endValue2 = num2 + 180f;
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, endValue2, 0.2f);
		TweenCallback tweenCallback = delegate
		{
			Transform transform = eyeModel.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		};
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Action onComplete = RandomEyeAngle;
		float duration = (float)obj3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected unsafe override void OnRecycleEnemy()
	{
		//IL_0063: Expected O, but got I4
		//IL_0501->IL0410: Incompatible stack heights: 2 vs 0
		//IL_0550->IL0410: Incompatible stack heights: 2 vs 0
		//IL_03c8->IL0410: Incompatible stack heights: 2 vs 0
		//IL_0401->IL0410: Incompatible stack heights: 2 vs 0
		base.OnRecycleEnemy();
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			base._003CIsCullable_003Ek__BackingField = false;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
			Tween sineTween = SineTween;
			if (SineTween != null && sineTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(SineTween);
			}
			_sineF = 1f;
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyViciousHunger)(object)dOSetter)._003COnRecycleEnemy_003Eb__17_1(0.5f);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, 2f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+98]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+99]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
							}
						}
					}
				}
			}
			SineTween = tweenerCore;
			GenerateSpritesAndAnimations();
			UpdateSprites();
			_isFirstUpdate = true;
			Tween eyeScaleTween = _eyeScaleTween;
			if (_eyeScaleTween != null && eyeScaleTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(_eyeScaleTween);
			}
			Transform transform = eyeModel.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rax_v38 (UnityEngine.Transform)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rax_v38 (UnityEngine.Transform)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			object cachedTransform2 = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rsi_v11 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rsi_v11 (System.Object)+10]");
			List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> ret;
			Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret));
			if (rotationTweens != null)
			{
				List<TweenerCore<Quaternion, Vector3, QuaternionOptions>>.Enumerator enumerator = default(List<TweenerCore<Quaternion, Vector3, QuaternionOptions>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Tween tween = null;
				}
				List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> list = rotationTweens;
				if (rotationTweens != null)
				{
					int version = list._version + 1;
					list._version = version;
					list._size = 0;
					if (list._size > 0)
					{
						Array.Clear(list._items, 0, list._size);
					}
					if ((object)eyeMesh != null)
					{
						eyeMesh.sortingLayerName = "Default";
						object obj = eyeMesh;
						if ((object)eyeMesh != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v10 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rbx_v10 (System.Object)+10]");
							Renderer.set_sortingOrder_Injected((IntPtr)0, 2001);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateSpritesAndAnimations()
	{
		//IL_0008: Expected O, but got Ref
		//IL_046d: Expected O, but got Ref
		//IL_0487: Expected native int or pointer, but got O
		//IL_04a1: Expected O, but got I
		//IL_04c1: Expected O, but got Ref
		//IL_04db: Expected native int or pointer, but got O
		//IL_0c40: Expected O, but got I4
		//IL_050c: Expected O, but got I
		//IL_0528: Expected O, but got I4
		//IL_0541: Expected O, but got Ref
		//IL_055b: Expected native int or pointer, but got O
		//IL_0c5d: Expected O, but got I4
		//IL_058d: Expected O, but got Ref
		//IL_05a7: Expected native int or pointer, but got O
		//IL_0c97: Expected O, but got I
		//IL_0a1c: Expected O, but got Ref
		//IL_0a36: Expected native int or pointer, but got O
		//IL_0a50: Expected O, but got I
		//IL_0a70: Expected O, but got Ref
		//IL_0a8a: Expected native int or pointer, but got O
		//IL_0ce3: Expected O, but got I
		//IL_0adb: Expected O, but got I
		//IL_0af7: Expected O, but got I4
		//IL_0b10: Expected O, but got Ref
		//IL_0b2a: Expected native int or pointer, but got O
		//IL_0d1d: Expected O, but got I
		//IL_0b62: Expected O, but got Ref
		//IL_0b7c: Expected native int or pointer, but got O
		//IL_0d4f: Expected O, but got I
		//IL_0d95: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter == null || ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0)
		{
			Circle circle = (_explosionCircle = new Circle());
			circle._x = 0f;
			circle._radius = 24f;
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxEmitter2 = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxEmitter = pfxEmitter2;
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
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(15f, 30f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(750f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
			_ = 0;
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			_ = 0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = _explosionCircle;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			ParticleSystem particleSystem = _pfxEmitter.CreateEmitter(particleSystemConfig);
			GameObject gameObject2 = base.gameObject;
			ParticleEmitterManager pfxEmitter3 = gameObject2.AddComponent<ParticleEmitterManager>();
			_pfxEmitter2 = pfxEmitter3;
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
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(15f, 30f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
			particleSystemConfig2._quantity = (int?)(object)0;
			minMaxCurve3 = new ParticleSystem.MinMaxCurve(750f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
			_ = 0;
			EmitZone emitZone2 = new EmitZone();
			emitZone2._type = EmitZoneType.Edge;
			emitZone2._source = _explosionCircle;
			_ = 0;
			_ = 48;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
			emitZone2._quantity = (int?)(object)0;
			emitZone2._yoyo = false;
			particleSystemConfig2._emitZone = emitZone2;
			particleSystemConfig2._on = false;
			ParticleSystem particleSystem2 = _pfxEmitter2.CreateEmitter(particleSystemConfig2);
		}
	}

	private void UpdateSprites()
	{
		//IL_00e1->IL008f: Incompatible stack heights: 1 vs 0
		if ((object)_pfxEmitter != null)
		{
			ParticleEmitterManager particleEmitterManager = _pfxEmitter.SetDepth(2000);
			ArcadeSprite arcadeSprite = setDepth(2001);
			MeshRenderer meshRenderer = eyeMesh;
			if ((object)eyeMesh != null)
			{
				bool flag = ((UnityEngine.Object)meshRenderer).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)meshRenderer).m_CachedPtr, 2001);
				if ((object)_pfxEmitter2 != null)
				{
					ParticleEmitterManager particleEmitterManager2 = _pfxEmitter2.SetDepth(2002);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_isFirstUpdate)
			{
				_isFirstUpdate = false;
				RandomEyeAngle();
			}
			UpdateSprites();
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			_pfxEmitter.EmitParticleAt(pos);
			float2 float6 = base.position;
			_pfxEmitter2.EmitParticleAt(pos);
		}
	}

	protected override void Die()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		GameObject gameObject = eyeModel.gameObject;
		gameObject.SetActive(value: false);
		base.Die();
	}

	private void LateUpdate()
	{
		//IL_0088->IL0088: Incompatible stack heights: 1 vs 0
		if (PauseSystem._paused)
		{
			Transform transform = eyeModel.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public unsafe override void Disappear()
	{
		//IL_0093: Expected O, but got Ref
		base.Disappear();
		Tween eyeScaleTween = _eyeScaleTween;
		if (_eyeScaleTween != null && eyeScaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_eyeScaleTween);
		}
		Transform target = eyeModel.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> eyeScaleTween2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 0.4f);
		_eyeScaleTween = eyeScaleTween2;
		base.Disappear();
	}

	public override void Despawn()
	{
		base.Despawn();
		GameObject gameObject = eyeModel.gameObject;
		gameObject.SetActive(value: false);
	}

	public EnemyViciousHunger()
	{
		List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> list = new List<TweenerCore<Quaternion, Vector3, QuaternionOptions>>();
		rotationTweens = list;
		base._002Ector();
	}

	private float _003CRandomEyeAngle_003Eb__16_0()
	{
		return _eyeRotationX;
	}

	private void _003CRandomEyeAngle_003Eb__16_1(float x)
	{
		_eyeRotationX = x;
	}

	private float _003CRandomEyeAngle_003Eb__16_2()
	{
		return _eyeRotationY;
	}

	private void _003CRandomEyeAngle_003Eb__16_3(float x)
	{
		_eyeRotationY = x;
	}

	private void _003CRandomEyeAngle_003Eb__16_4()
	{
		Transform transform = eyeModel.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private float _003COnRecycleEnemy_003Eb__17_0()
	{
		return _sineF;
	}

	private void _003COnRecycleEnemy_003Eb__17_1(float x)
	{
		_sineF = x;
	}
}
