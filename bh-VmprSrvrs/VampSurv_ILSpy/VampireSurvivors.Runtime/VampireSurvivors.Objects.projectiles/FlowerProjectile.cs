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
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FlowerProjectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private PhaserSprite _FlowerSprite;

	private Circle _a;

	private bool _particlesGenerated;

	private Timer _bounceTimer;

	private MultiTargetTween _angleTween;

	private MultiTargetTween _scaleTween;

	private float _saveVelX;

	private float _saveVelY;

	private MultiTargetTween _speedTween;

	private float _initialVelocityX;

	private float _initialVelocityY;

	public float _BombDeceleration;

	private GravityWell _well;

	private Vector2 _aimVec;

	private bool _canBounce;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween1;

	private float _bounceAreaMod;

	private int _radius;

	private List<string> _flowerNames;

	private ParticleEmitterManager _particles;

	private ParticleSystem _fwEmitter2;

	private Vector2 _previousVector;

	private Vector2 _newAim;

	public float _ScaleAfterBounceMod;

	private Timer _hitboxTimer;

	private uint[] _onEmitCustomTint;

	private SfxType[] _soundArray;

	private Transform _cachedRendererTransform;

	private Transform _cachedFlowerTransform;

	private Tween _colliderTween;

	public HashSet<IDamageable> objectsHit => _objectsHit;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_003a: Expected O, but got Ref
		//IL_09e6: Expected O, but got Ref
		//IL_0a09: Expected native int or pointer, but got O
		//IL_0a28: Expected O, but got I
		//IL_0a43: Expected O, but got Ref
		//IL_0a5d: Expected native int or pointer, but got O
		//IL_0a7c: Expected O, but got I
		//IL_0a97: Expected O, but got Ref
		//IL_0ab1: Expected native int or pointer, but got O
		//IL_0ac9: Expected O, but got I4
		//IL_0af4: Expected O, but got Ref
		//IL_0b0e: Expected native int or pointer, but got O
		//IL_0b28: Expected O, but got I
		//IL_0b48: Expected O, but got Ref
		//IL_0b62: Expected native int or pointer, but got O
		//IL_0b94: Expected O, but got I4
		//IL_0bbc: Expected O, but got Ref
		//IL_0be3: Expected O, but got I
		//IL_0bfd: Expected native int or pointer, but got O
		//IL_0c42: Expected O, but got I
		//IL_0c88: Expected O, but got I
		//IL_0cbe: Expected O, but got I
		//IL_0d2c: Expected O, but got Ref
		//IL_0d4d: Expected O, but got Ref
		//IL_0dbf: Expected O, but got I4
		//IL_0eba: Expected O, but got I4
		//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0a: Expected O, but got Unknown
		//IL_1286: Unknown result type (might be due to invalid IL or missing references)
		//IL_128b: Expected O, but got Unknown
		//IL_1298: Expected I, but got O
		//IL_12a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Expected I, but got Unknown
		//IL_12b3: Expected O, but got I
		//IL_0ea4: Expected O, but got I4
		//IL_0e46: Expected O, but got I
		//IL_0e84: Expected O, but got I4
		//IL_1311: Expected O, but got I4
		//IL_136c: Expected I, but got O
		//IL_10a8: Expected O, but got Ref
		//IL_1161: Expected I, but got O
		//IL_11da: Expected O, but got I
		//IL_1220: Expected I4, but got I8
		//IL_0f7d->IL12e6: Incompatible stack heights: 2 vs 0
		//IL_1184->IL1184: Incompatible stack heights: 16 vs 15
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Transform cachedRendererTransform = _renderer.transform;
		_cachedRendererTransform = cachedRendererTransform;
		Vector3 value = default(Vector3);
		_GroundFx.color = (Color)(&value);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.1f);
		_GroundFx.enabled = false;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetBlendMode(_GroundFx, BlendMode.Add);
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager particles = gameObject.AddComponent<ParticleEmitterManager>();
		_particles = particles;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _a;
		emitZone._type = EmitZoneType.Random;
		emitZone._yoyo = false;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0000");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0001");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0002");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0003");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0004");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0005");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0006");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0007");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0008");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0009");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0010");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0011");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0012");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0013");
		}
		else
		{
			int num14 = list._size + 1;
			list._size = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list.Add("leaf0014");
		list.Add("leaf0015");
		list.Add("leaf0016");
		list.Add("leaf0017");
		list.Add("leaf0018");
		list.Add("leaf0019");
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		particleSystemConfig._fps = 30;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
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
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
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
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 64;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(2f, 0.1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		_ = 0;
		_ = 1115684864;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		particleSystemConfig._frequency = (float?)(object)0;
		particleSystemConfig._tintRandom = _onEmitCustomTint;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem fwEmitter = _particles.CreateEmitter(particleSystemConfig, null, "_fwEmitter2");
		_fwEmitter2 = fwEmitter;
		Transform transform = _fwEmitter2.transform;
		Vector2 value2 = default(Vector2);
		transform.localPosition = (Vector3)(&value2);
		int num15 = 0;
		do
		{
			string text = System.Number.FormatInt32(num15, (ReadOnlySpan<char>)(&value), null);
			List<object> flowerNames = (List<object>)(object)_flowerNames;
			object obj3 = "0";
			bool flag = "0" == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2730 @ rdi_v32+10]");
			bool flag2 = (nint)0 != 1;
			string text2 = (string)(2 - text._stringLength);
			_ = text._stringLength;
			string text4;
			if ((nint)text2 > 0)
			{
				string text3 = string.FastAllocateString(2);
				object obj4 = text3 + 20;
				if ((nint)text2 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"rep stosw\"");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
				int num17 = (int)(num16 + 0);
				object obj5 = text2 * 2;
				byte* ptr = (byte*)(nint)(obj4 + obj5);
				byte* ptr2 = (byte*)(nint)(text + 20);
				object obj6 = (object)(ptr - (nuint)ptr2);
				object obj8;
				if ((nint)obj6 >= num17)
				{
					object obj7 = (object)(ptr2 - (nuint)ptr);
					if ((nint)obj7 >= num17)
					{
						Buffer.Memcpy(ptr, ptr2, num17);
						text4 = text3;
						obj8 = 0;
						goto IL_12cf;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				text4 = text3;
				obj8 = 0;
			}
			else
			{
				text4 = text;
				object obj8 = 0;
			}
			goto IL_12cf;
			IL_12cf:
			string item = "fl" + text4;
			int version15 = flowerNames._version + 1;
			flowerNames._version = version15;
			object[] items15 = flowerNames._items;
			if (flowerNames._size >= items15.Length)
			{
				flowerNames.AddWithResize((object)item);
			}
			else
			{
				int num18 = flowerNames._size + 1;
				flowerNames._size = num18;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num15++;
		}
		while (num15 < 88);
		List<string> flowerNames2 = _flowerNames;
		object obj9 = UnityEngine.Random.RandomRangeInt(0, flowerNames2._size);
		bool flag3 = (nint)obj9 >= flowerNames2._size;
		string[] items16 = flowerNames2._items;
		bool flag4 = (nint)obj9 >= items16.Length;
		GameObject gameObject2 = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite flowerSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", items16[obj9]);
		_FlowerSprite = flowerSprite;
		GameObject gameObject3 = _FlowerSprite.gameObject;
		((UnityEngine.Object)gameObject3).SetName("FlowerSprite");
		List<string> flowerSprite2 = (List<string>)(object)_FlowerSprite;
		bool flag5 = flowerSprite2._items == null;
		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)flowerSprite2._items);
		Transform cachedFlowerTransform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		_cachedFlowerTransform = cachedFlowerTransform;
		object cachedTransform = _cachedTransform;
		object cachedFlowerTransform2 = _cachedFlowerTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rdi_v42 (System.Object)+10]");
		bool flag6 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rdi_v42 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&value2));
		object cachedTransform2 = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rdi_v43 (System.Object)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rdi_v43 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out value);
		bool flag8 = (object)_cachedFlowerTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rsi_v30 (System.Object)+10]");
		bool flag9 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rsi_v30 (System.Object)+10]");
		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
		object cachedFlowerTransform3 = _cachedFlowerTransform;
		bool flag10 = (object)_cachedFlowerTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1341 @ rdi_v45 (System.Object)+10]");
		bool flag11 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1341 @ rdi_v45 (System.Object)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		bool flag12 = (object)_FlowerSprite == null;
		Transform transform2 = _FlowerSprite.transform;
		bool flag13 = (object)transform2 == null;
		transform2.localEulerAngles = (Vector3)(&value2);
		bool flag14 = (object)_FlowerSprite == null;
		PhaserSprite phaserSprite = _FlowerSprite.setVisible(visible: true);
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		string flowerSprite3 = (string)(object)_FlowerSprite;
		bool flag15 = flowerSprite3._stringLength == 0;
		IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)flowerSprite3._stringLength);
		Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
		if ((object)transform3 != null)
		{
			nint num19 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag16 = obj10 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		_ = 0;
		tweenConfig.duration = 1000f;
		_ = 1110704128;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		tweenConfig.angle = (float?)(object)0;
		Func<int, float> staggerDelay = Tweens.Stagger(100f);
		tweenConfig.staggerDelay = staggerDelay;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00b9: Expected I4, but got O
		//IL_1070: Expected O, but got I4
		//IL_009a: Expected I4, but got O
		//IL_015b: Expected O, but got I4
		//IL_0169: Expected I4, but got O
		//IL_019e: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_02b4: Expected I4, but got O
		//IL_1116: Expected I4, but got O
		//IL_02db: Expected O, but got I4
		//IL_0384: Expected O, but got F4
		//IL_04fb: Expected I, but got O
		//IL_0516: Expected O, but got I
		//IL_04db: Expected O, but got F4
		//IL_04f1: Expected O, but got I4
		//IL_0890: Expected I4, but got O
		//IL_07a4: Expected I4, but got I8
		//IL_084b: Expected O, but got I4
		//IL_07d4: Expected O, but got I4
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Expected O, but got Unknown
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f0: Expected I4, but got Unknown
		//IL_08bd: Expected I4, but got O
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Expected O, but got Unknown
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Expected O, but got Unknown
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_097e: Expected O, but got Unknown
		//IL_1305: Expected I, but got O
		//IL_131b: Expected O, but got I
		//IL_1324: Unknown result type (might be due to invalid IL or missing references)
		//IL_1329: Expected O, but got Unknown
		//IL_0b55: Expected I, but got O
		//IL_134f: Expected O, but got I4
		//IL_1366: Expected I, but got I8
		//IL_0b3e: Expected I, but got I8
		//IL_139c: Expected I, but got O
		//IL_13d7: Expected I, but got O
		//IL_13ed: Expected O, but got I
		//IL_13f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fb: Expected O, but got Unknown
		//IL_0d21: Expected I, but got O
		//IL_142f: Expected I, but got I8
		//IL_0cf4: Expected I, but got I8
		//IL_0eca: Expected I4, but got O
		//IL_1466: Expected O, but got I
		//IL_0f33: Expected I, but got O
		//IL_0f49: Expected O, but got I
		//IL_0f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f57: Expected O, but got Unknown
		//IL_0fc0: Expected I, but got O
		//IL_14f0: Expected I, but got I8
		//IL_151d: Expected I4, but got F4
		//IL_0fa9: Expected I, but got I8
		//IL_0107->IL0fd3: Incompatible stack heights: 1 vs 0
		//IL_0149->IL0fd3: Incompatible stack heights: 1 vs 0
		//IL_11a9->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_0331->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_0360->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_03a8->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_03d7->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_041d->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_049a->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_0583->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_04c9->IL0fd3: Incompatible stack heights: 4 vs 0
		//IL_05da->IL0fd3: Incompatible stack heights: 5 vs 0
		//IL_0622->IL0fd3: Incompatible stack heights: 5 vs 0
		//IL_066e->IL0fd3: Incompatible stack heights: 5 vs 0
		//IL_06b9->IL0fd3: Incompatible stack heights: 5 vs 0
		//IL_078b->IL0fd3: Incompatible stack heights: 5 vs 0
		//IL_0a0f->IL0fd3: Incompatible stack heights: 15 vs 0
		//IL_0a3b->IL0fd3: Incompatible stack heights: 15 vs 0
		//IL_0aaa->IL0fd3: Incompatible stack heights: 15 vs 0
		//IL_0a88->IL0a88: Incompatible stack heights: 16 vs 15
		//IL_0bf8->IL0fd3: Incompatible stack heights: 15 vs 0
		//IL_13c5->IL0fd3: Incompatible stack heights: 16 vs 0
		//IL_0c71->IL0fd3: Incompatible stack heights: 16 vs 0
		//IL_0c4f->IL0c4f: Incompatible stack heights: 17 vs 16
		//IL_1451->IL0fd3: Incompatible stack heights: 16 vs 0
		//IL_0ee4->IL0fd3: Incompatible stack heights: 16 vs 0
		//IL_1486->IL0fd3: Incompatible stack heights: 16 vs 0
		Weapon weapon2 = default(Weapon);
		base.InitProjectile(pool, weapon2, index);
		List<string> list = _flowerNames;
		GameManager core = GM.Core;
		List<string> list2;
		int num2;
		int num3;
		int num;
		if ((object)GM.Core != null)
		{
			if (core._003CIsHalloween_003Ek__BackingField)
			{
				list2 = new List<string>();
				num = 1;
				num2 = 1;
				while (true)
				{
					string text = num.ToString();
					string item = "Ecto" + text;
					if (list2 == null)
					{
						break;
					}
					((List<object>)(object)list2).Add((object)item);
					num2++;
					bool flag = num2 <= 6;
					num = num2;
					if (flag)
					{
						continue;
					}
					goto IL_0090;
				}
			}
			else
			{
				num3 = (int)_FlowerSprite;
				if (_flowerNames != null)
				{
					goto IL_1059;
				}
			}
		}
		goto IL_0fd3;
		IL_0fd3:
		throw new NullReferenceException();
		IL_1418:
		TweenCallback tweenCallback;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		TweenConfig tweenConfig;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
		Tween colliderTween = _colliderTween;
		if (_colliderTween != null && colliderTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_colliderTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float num4;
		((FlowerProjectile)(object)dOSetter)._003CInitProjectile_003Eb__35_1(num4);
		float num5;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, num5, 0.6f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4058 @ rax_v206 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 27;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action action;
		if (tweenerCore != null)
		{
			_colliderTween = tweenerCore;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			int num6 = (int)_weapon;
			if ((object)_weapon != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rbx_v43 (System.Int32)+88]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rbx_v43 (System.Int32)+88]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v214+C0]");
					if ((nint)0 == 0)
					{
						num5 = 1000f;
					}
					action = null;
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ r10_v27 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(FlowerProjectile._003CInitProjectile_003Eb__35_2);
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ r10_v27 (Il2CppMethodInfo)+4C]");
					object obj2 = (nint)0 >> 4;
					object obj3 = obj2 & 1;
					nint num8;
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ r10_v27 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num8 = unchecked((nint)6447293664L);
							goto IL_14c9;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num8 = ((Delegate)action).method_ptr;
					goto IL_14c9;
				}
			}
		}
		goto IL_0fd3;
		IL_11ae:
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		_BombDeceleration = 1f;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array = new object[1];
		float num11;
		float num16 = default(float);
		Vector3 value3 = default(Vector3);
		TweenConfig tweenConfig3;
		TweenCallback tweenCallback2;
		if (array != null)
		{
			int value = ((int*)(&array))->m_value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig2 != null)
			{
				tweenConfig2.targets = array;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				if (dictionary != null)
				{
					object value2 = default(object);
					bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_BombDeceleration", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig2.custom = dictionary;
					if ((object)_weapon != null)
					{
						float num9 = _weapon.PDuration();
						float num10 = (tweenConfig2.delay = num11 * 0.25f);
						if ((object)_weapon != null)
						{
							float num12 = _weapon.PDuration();
							float duration = num10 * 0.75f;
							tweenConfig2.ease = Ease.Linear;
							tweenConfig2.duration = duration;
							TweenCallback onComplete = delegate
							{
								FadeOut();
							};
							tweenConfig2.onComplete = onComplete;
							MultiTargetTween speedTween = Tweens.Add(tweenConfig2);
							_speedTween = speedTween;
							bool flag4 = _indexInWeapon >= 4;
							int num13 = 0;
							if (!flag4)
							{
								SfxType[] soundArray = _soundArray;
								if (_soundArray == null)
								{
									goto IL_0fd3;
								}
								int num14 = (int)(_indexInWeapon & 0x80000003L);
								if ((nint)_soundArray < 0)
								{
									object obj5 = num14 - 1;
									object obj6 = obj5 | -4;
									num14 = obj6 + 1;
								}
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
								{
									Rate = 1f
								};
								float detune = (float)_indexInWeapon * 200f;
								soundConfig.Detune = detune;
								float num15 = (float)_indexInWeapon * 0.01f;
								soundConfig.Volume = (float?)(object)1;
								PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref soundArray[num14]), soundConfig, 200f, 10, num16);
								num13 = 10;
							}
							int num17 = (int)_cachedFlowerTransform;
							bool flag5 = (object)_cachedFlowerTransform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1728 @ rbx_v36 (System.Int32)+10]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1728 @ rbx_v36 (System.Int32)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref value3);
							bool flag7 = (object)_FlowerSprite == null;
							PhaserSprite phaserSprite = _FlowerSprite.setVisible(visible: true);
							int num18 = (int)_cachedFlowerTransform;
							_ScaleAfterBounceMod = 1f;
							bool flag8 = (object)_weapon == null;
							float num19 = _weapon.PArea();
							int num20 = -_radius;
							object obj7 = Vector3.zeroVector * _bounceAreaMod;
							object obj8 = obj7 * _ScaleAfterBounceMod;
							num4 = (float)num20 * 0.01f;
							float num21 = (float)obj8 * num4;
							bool flag9 = (object)_cachedFlowerTransform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1810 @ rbx_v37 (System.Int32)+10]");
							bool flag10 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1810 @ rbx_v37 (System.Int32)+10]");
							Vector3 value4 = default(Vector3);
							Transform.set_position_Injected((IntPtr)0, ref value4);
							bool flag11 = (object)_weapon == null;
							float num22 = _weapon.PArea();
							object obj10 = default(object);
							object obj9 = obj10 * _bounceAreaMod;
							num5 = (float)obj9 * _ScaleAfterBounceMod;
							bool flag12 = (object)_renderer == null;
							Transform transform = _renderer.transform;
							bool flag13 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3153 @ rax_v149 (UnityEngine.Transform)+10]");
							bool flag14 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3153 @ rax_v149 (UnityEngine.Transform)+10]");
							Vector3 value5 = default(Vector3);
							Transform.set_localScale_Injected((IntPtr)0, ref value5);
							if (_tween1 != null)
							{
								_tween1.Kill();
							}
							tweenConfig3 = new TweenConfig();
							object[] array2 = new object[1];
							if ((object)_renderer != null)
							{
								Transform transform2 = _renderer.transform;
								if (array2 != null)
								{
									if ((object)transform2 != null)
									{
										object obj11 = array2;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj12 = default(object);
										bool flag15 = obj12 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig3 != null)
									{
										_ = 1140457472;
										_ = 27;
										_ = 1;
										tweenCallback2 = null;
										nint num23 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r10_v25 (Il2CppMethodInfo)+8]");
										((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
										((Delegate)tweenCallback2).method = (nint)__ldftn(FlowerProjectile._003CInitProjectile_003Eb__35_4);
										((Delegate)tweenCallback2).m_target = this;
										((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r10_v25 (Il2CppMethodInfo)+4C]");
										object obj13 = (nint)0 >> 4;
										object obj14 = obj13 & 1;
										nint num24;
										if (obj14 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r10_v25 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num24 = unchecked((nint)6447293664L);
												goto IL_1346;
											}
										}
										((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
										num24 = ((Delegate)tweenCallback2).method_ptr;
										goto IL_1346;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0fd3;
		IL_1346:
		object obj15 = 24;
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		MultiTargetTween tween2 = Tweens.Add(tweenConfig3);
		_tween1 = tween2;
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		tweenConfig = new TweenConfig();
		object[] array3 = new object[1];
		BulletPool renderer = (BulletPool)(object)_renderer;
		if ((object)_renderer != null)
		{
			bool flag16 = ((EventEmitter)renderer).callbacks == null;
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)((EventEmitter)renderer).callbacks);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if (array3 != null)
			{
				if ((object)transform3 != null)
				{
					object obj16 = array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj17 = default(object);
					bool flag17 = obj17 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					_ = 1142292480;
					_ = 27;
					_ = 1;
					tweenCallback = null;
					nint num25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v26 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback).method = (nint)__ldftn(FlowerProjectile._003CInitProjectile_003Eb__35_5);
					((Delegate)tweenCallback).m_target = this;
					((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v26 (Il2CppMethodInfo)+4C]");
					object obj18 = (nint)0 >> 4;
					object obj19 = obj18 & 1;
					nint num26;
					if (obj19 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v26 (Il2CppMethodInfo)+52]");
						bool flag18 = (nint)0 == 0;
						num26 = unchecked((nint)6447293664L);
						if (flag18)
						{
							goto IL_1418;
						}
					}
					num26 = ((Delegate)tweenCallback).method_ptr;
					((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
					goto IL_1418;
				}
			}
		}
		goto IL_0fd3;
		IL_14c9:
		float duration2 = num5 * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration2, action, null, isLooped: true, (byte)(int)num16 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		return;
		IL_0090:
		num3 = (int)_FlowerSprite;
		num = num2;
		list = list2;
		goto IL_1059;
		IL_1059:
		object obj20 = UnityEngine.Random.RandomRangeInt(0, list._size);
		bool flag19 = (nint)obj20 >= list._size;
		string[] items = list._items;
		if (list._items != null)
		{
			Sprite sprite = SpriteManager.GetSprite(items[obj20], "vfx");
			if (num3 != 0)
			{
				PhaserSprite phaserSprite2 = ((PhaserSprite)num3).setFrame(sprite);
				int num27 = (int)_cachedTransform;
				_isCullable = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rbx_v27 (System.Int32)+10]");
				bool flag20 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rbx_v27 (System.Int32)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value3);
				BaseBody baseBody = body;
				BaseBody baseBody2 = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
				BaseBody baseBody3 = body;
				baseBody3._enable = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				Circle a = _a;
				float num28 = _weapon.PArea();
				float num29 = (a._radius = (float)Vector3.oneVector * 8f);
				float diameter = num29 + num29;
				a._diameter = diameter;
				RenderingExtensions.SetEmitZone(emitZone: new EmitZone
				{
					_type = EmitZoneType.Random,
					_source = _a,
					_yoyo = false
				}, pfx: _fwEmitter2);
				PhaserSprite phaserSprite3 = _FlowerSprite.setAlpha(1f);
				PhaserSprite phaserSprite4 = _FlowerSprite.setVisible(visible: true);
				int num30 = (int)_GroundFx;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rbx_v30 (System.Int32)+10]");
				bool flag21 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rbx_v30 (System.Int32)+10]");
				Renderer.set_enabled_Injected((IntPtr)0, true);
				int num31 = (int)_renderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v31 (System.Int32)+10]");
				bool flag22 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v31 (System.Int32)+10]");
				Renderer.set_enabled_Injected((IntPtr)0, false);
				_bounceAreaMod = 1f;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_GroundFx, 0.1f);
				BaseBody baseBody4 = body;
				if (body != null)
				{
					baseBody4._bounce = (float2)1066192077;
					_ = 1066192077;
					Weapon weapon3 = _weapon;
					_canBounce = false;
					_isCullable = true;
					_saveVelX = 1f;
					_saveVelY = 1f;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
						{
							float num32 = (float)characterController._lastMovementDirection * -1f;
							_aimVec = (Vector2)num32;
							Weapon weapon4 = _weapon;
							if ((object)_weapon != null)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v106 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
									num11 = 0f * -1f;
									Weapon weapon5 = _weapon;
									if ((object)_weapon != null)
									{
										float num15;
										if (weapon5.IsHoming)
										{
											nint num33 = (nint)this;
											_speed = 0.25f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2836 @ rax_v324 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FlowerProjectile>)+3B0]");
											object obj21 = 0;
											Transform transform4 = base.AimForNearestEnemy();
											num15 = -1f;
											goto IL_11ae;
										}
										float num34 = _weapon.PSpeed();
										float num35 = num11 * num11;
										num15 = num11 * (float)_aimVec;
										ArcadeSprite sprite2 = _sprite;
										if ((object)_sprite != null)
										{
											BaseBody baseBody5 = sprite2.body;
											if (sprite2.body != null)
											{
												baseBody5._velocity = (float2)num15;
												num11 = num35;
												object obj21 = 0;
												goto IL_11ae;
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
		goto IL_0fd3;
	}

	public void SizeUp()
	{
		//IL_00d6->IL01ab: Incompatible stack heights: 3 vs 0
		if (!_canBounce)
		{
			return;
		}
		_canBounce = false;
		if ((object)_fwEmitter2 != null)
		{
			Transform transform = _fwEmitter2.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object fwEmitter = _fwEmitter2;
				bool flag2 = (object)_fwEmitter2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rsi_v8 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rsi_v8 (System.Object)+10]");
				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
				ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 1);
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
				Timer bounceTimer = Timers.Register(0.6f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_bounceTimer = bounceTimer;
				return;
			}
		}
		throw new NullReferenceException();
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
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_0178:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
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

	public unsafe override void InternalUpdate()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_019c: Expected I4, but got O
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_03bf: Expected I, but got O
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_04bd: Expected O, but got I4
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Expected O, but got Unknown
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Expected O, but got Unknown
		//IL_0462->IL073e: Incompatible stack heights: 2 vs 0
		//IL_05df->IL0362: Incompatible stack heights: 5 vs 0
		Weapon weapon = _weapon;
		Vector3 vector = default(Vector3);
		if ((object)_weapon != null)
		{
			if (weapon.IsHoming)
			{
				_speed = 0.25f;
				Transform transform = base.AimForNearestEnemy();
				goto IL_0392;
			}
			object obj = _aimVec * _saveVelX;
			ArcadeSprite sprite = _sprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FlowerProjectile)+134]");
			object obj2 = 0 * _saveVelY;
			vector = (Vector3)(obj * _BombDeceleration);
			object obj3 = obj2 * _BombDeceleration;
			if ((object)_sprite != null)
			{
				BaseBody baseBody = sprite.body;
				if (sprite.body != null)
				{
					baseBody._velocity = (float2)vector;
					goto IL_0392;
				}
			}
		}
		goto IL_0362;
		IL_0764:
		PhaserScene s_scene = ArcadePhysics.s_scene;
		object obj5 = default(object);
		if (ArcadePhysics.s_scene != null)
		{
			int num = (int)s_scene._renderer;
			if (s_scene._renderer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdi_v22 (System.Int32)+1C]");
				int num2 = (int)(-0);
				if ((object)_GroundFx != null)
				{
					_GroundFx.sortingOrder = num2;
					if ((object)_renderer != null)
					{
						_renderer.sortingOrder = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
						if ((object)_FlowerSprite != null)
						{
							int num3 = default(int);
							PhaserSprite phaserSprite = _FlowerSprite.setDepth(num3);
							int num4 = num2 - 1;
							RenderingExtensions.SetDepth(_fwEmitter2, num4);
							if ((object)_GroundFx != null)
							{
								Transform transform2 = _GroundFx.transform;
								if ((object)_renderer != null)
								{
									Transform transform3 = _renderer.transform;
									if ((object)transform3 != null)
									{
										_ = 0;
										_ = 0;
										bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										object obj4 = obj5 - 64;
										Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj4);
										object obj6 = _radius + _radius;
										float num5 = (float)obj6 * 0.01f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-38]");
										float num6 = 0f * num5;
										bool flag2 = (object)transform2 == null;
										bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										object obj7 = obj5 - 32;
										Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj7);
										object cachedRendererTransform = _cachedRendererTransform;
										object cachedFlowerTransform = _cachedFlowerTransform;
										bool flag4 = (object)_cachedRendererTransform == null;
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdi_v27 (System.Object)+10]");
										bool flag5 = (nint)0 == 0;
										object obj8 = obj5 - 64;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdi_v27 (System.Object)+10]");
										Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj8);
										object cachedRendererTransform2 = _cachedRendererTransform;
										if ((object)_cachedRendererTransform != null)
										{
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdi_v28 (System.Object)+10]");
											bool flag6 = (nint)0 == 0;
											object obj9 = obj5 - 48;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdi_v28 (System.Object)+10]");
											Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj9);
											bool flag7 = (object)_cachedFlowerTransform == null;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rsi_v25 (System.Object)+10]");
											bool flag8 = (nint)0 == 0;
											object obj10 = obj5 - 64;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rsi_v25 (System.Object)+10]");
											Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj10);
											object cachedFlowerTransform2 = _cachedFlowerTransform;
											bool flag9 = (object)_cachedFlowerTransform == null;
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ rdi_v30 (System.Object)+10]");
											bool flag10 = (nint)0 == 0;
											object obj11 = obj5 - 48;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ rdi_v30 (System.Object)+10]");
											Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj11);
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ rdi_v30 (System.Object)+10]");
											bool flag11 = (nint)0 == 0;
											object obj12 = obj5 - 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ rdi_v30 (System.Object)+10]");
											Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj12);
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
		goto IL_0362;
		IL_0392:
		if (_canBounce)
		{
			if ((object)_weapon != null)
			{
				float num7 = _weapon.PArea();
				object obj13 = vector * _bounceAreaMod;
				object obj14 = obj13 * _ScaleAfterBounceMod;
				if ((object)_renderer != null)
				{
					Transform transform4 = _renderer.transform;
					nint num8 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rcx_v97 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num9 = 0;
					vector = Vector3.oneVector;
					object obj15 = default(object);
					object obj3 = obj15 * obj14;
					_ = Vector3.oneVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v56 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
					object obj16 = 0 * obj14;
					bool flag12 = (object)transform4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v116 (UnityEngine.Transform)+10]");
					bool flag13 = (nint)0 == 0;
					object obj17 = obj5 - 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v116 (UnityEngine.Transform)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj17);
					goto IL_0764;
				}
			}
			goto IL_0362;
		}
		goto IL_0764;
		IL_0362:
		throw new NullReferenceException();
	}

	private void FadeOut()
	{
		//IL_002c: Expected I, but got O
		//IL_0084: Expected I, but got O
		//IL_00dc: Expected I, but got O
		//IL_0140: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)_FlowerSprite != null)
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
		if ((object)_renderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_GroundFx != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private float MyScale()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		float num = _weapon.PArea();
		object obj2 = default(object);
		object obj = obj2 * _bounceAreaMod;
		return (float)obj * _ScaleAfterBounceMod;
	}

	public override void Despawn()
	{
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		ParticleSystem fwEmitter = _fwEmitter2;
		bool flag = ((UnityEngine.Object)fwEmitter).m_CachedPtr == (IntPtr)0;
		ParticleSystem.Stop_Injected(((UnityEngine.Object)fwEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
		_tween1.Kill();
		_tween2.Kill();
		PhaserSprite phaserSprite = _FlowerSprite.setVisible(visible: false);
		object cachedRendererTransform = _cachedRendererTransform;
		bool flag2 = (object)_cachedRendererTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rbx_v6 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rbx_v6 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		bool flag4 = (object)_GroundFx == null;
		_GroundFx.enabled = false;
		bool flag5 = (object)_renderer == null;
		_renderer.enabled = false;
		BaseBody baseBody = body;
		bool flag6 = body == null;
		baseBody._enable = false;
		Weapon weapon = _weapon;
		bool flag7 = (object)_weapon == null;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
		base.Despawn();
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		VampireSurvivors.Objects.Characters.CharacterController component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		component.RecoverHp(1f, showRecovery: true, mulByRegen: true);
	}

	public FlowerProjectile()
	{
		Circle a = new Circle();
		_a = a;
		_saveVelX = -1f;
		_saveVelY = -1f;
		_BombDeceleration = 1f;
		_canBounce = true;
		_bounceAreaMod = 1f;
		_radius = 8;
		_flowerNames = new List<string>();
		_onEmitCustomTint = new uint[4] { 16746632u, 8978312u, 8978312u, 16777096u };
		_soundArray = new SfxType[4]
		{
			SfxType.STEP1,
			SfxType.STEP2,
			SfxType.STEP3,
			SfxType.STEP4
		};
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__35_3()
	{
		FadeOut();
	}

	private void _003CInitProjectile_003Eb__35_4()
	{
		Transform cachedRendererTransform = _cachedRendererTransform;
		bool flag = ((UnityEngine.Object)cachedRendererTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedRendererTransform).m_CachedPtr, ref value);
		Transform cachedFlowerTransform = _cachedFlowerTransform;
		bool flag2 = (object)_cachedFlowerTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedFlowerTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedFlowerTransform).m_CachedPtr, ref value2);
	}

	private void _003CInitProjectile_003Eb__35_5()
	{
		//IL_000d: Expected I, but got O
		//IL_00fc: Invalid comparison between F4 and I4
		//IL_011c: Expected F4, but got I4
		_canBounce = true;
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
			Weapon weapon = _weapon;
			float num2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
			float num3 = default(float);
			if (1f > num3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			}
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_ScaleAfterBounceMod", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			float num4 = _weapon.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			float num5 = num4 - 600f;
			if (num5 < 500f)
			{
				num5 = 500f;
			}
			tweenConfig.duration = num5;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private float _003CInitProjectile_003Eb__35_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CInitProjectile_003Eb__35_1(float x)
	{
		//IL_003a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		object cachedRendererTransform = _cachedRendererTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2 (System.Object)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
		float radius = (float)_radius * (float)ret;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
	}

	private void _003CInitProjectile_003Eb__35_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CSizeUp_003Eb__36_0()
	{
		_canBounce = true;
	}

	private void _003CFadeOut_003Eb__39_0()
	{
		Despawn();
	}
}
