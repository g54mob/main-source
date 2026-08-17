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

public class Flower2Projectile : Projectile
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

	private PhaserSprite sprSplash;

	private PhaserSprite sprFlower;

	private MultiTargetTween splashTweenIn;

	private MultiTargetTween splashTweenOut;

	private bool ExplosionTriggered;

	private Flower2Weapon trueWeapon;

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
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_125c: Expected O, but got Unknown
		//IL_1269: Expected I, but got O
		//IL_1272: Unknown result type (might be due to invalid IL or missing references)
		//IL_1277: Expected I, but got Unknown
		//IL_1284: Expected O, but got I
		//IL_0ea4: Expected O, but got I4
		//IL_0e46: Expected O, but got I
		//IL_0e84: Expected O, but got I4
		//IL_12e2: Expected O, but got I4
		//IL_133d: Expected I, but got O
		//IL_10a8: Expected O, but got Ref
		//IL_1132: Expected I, but got O
		//IL_11ab: Expected O, but got I
		//IL_11f1: Expected I4, but got I8
		//IL_0f7d->IL12b7: Incompatible stack heights: 2 vs 0
		//IL_1155->IL1155: Incompatible stack heights: 15 vs 14
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Transform cachedRendererTransform = _renderer.transform;
		_cachedRendererTransform = cachedRendererTransform;
		Vector3 value = default(Vector3);
		_GroundFx.color = (Color)(&value);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.1f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetBlendMode(_GroundFx, BlendMode.Add);
		_GroundFx.enabled = false;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2717 @ rdi_v32+10]");
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
						goto IL_12a0;
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
			goto IL_12a0;
			IL_12a0:
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rdi_v42 (System.Object)+10]");
		bool flag6 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rdi_v42 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&value2));
		object cachedTransform2 = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rdi_v43 (System.Object)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rdi_v43 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out value);
		bool flag8 = (object)_cachedFlowerTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rsi_v30 (System.Object)+10]");
		bool flag9 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rsi_v30 (System.Object)+10]");
		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
		object cachedFlowerTransform3 = _cachedFlowerTransform;
		bool flag10 = (object)_cachedFlowerTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1342 @ rdi_v45 (System.Object)+10]");
		bool flag11 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1342 @ rdi_v45 (System.Object)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		bool flag12 = (object)_FlowerSprite == null;
		Transform transform2 = _FlowerSprite.transform;
		bool flag13 = (object)transform2 == null;
		transform2.localEulerAngles = (Vector3)(&value2);
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		string flowerSprite3 = (string)(object)_FlowerSprite;
		bool flag14 = flowerSprite3._stringLength == 0;
		IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)flowerSprite3._stringLength);
		Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
		if ((object)transform3 != null)
		{
			nint num19 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag15 = obj10 == null;
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
		//IL_0f1c: Expected O, but got I4
		//IL_0f6c: Expected I, but got O
		//IL_00cf: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_0242: Expected O, but got I4
		//IL_02eb: Expected O, but got F4
		//IL_0413: Expected O, but got F4
		//IL_0494: Expected I, but got O
		//IL_06a9: Expected I4, but got I8
		//IL_073f: Expected O, but got I4
		//IL_06d9: Expected O, but got I4
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected O, but got Unknown
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Expected I4, but got Unknown
		//IL_082b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected O, but got Unknown
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Expected O, but got Unknown
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected O, but got Unknown
		//IL_0988: Expected I, but got O
		//IL_0a09: Expected O, but got I4
		//IL_0b0e: Expected I, but got O
		//IL_0b94: Expected O, but got I4
		//IL_0cfc: Expected I4, but got F4
		//IL_0d18: Expected I4, but got F4
		//IL_1119: Expected O, but got I4
		//IL_0e0d: Expected I, but got O
		//IL_0e15: Expected I, but got O
		//IL_0e25: Expected O, but got I
		//IL_0ea5: Expected O, but got I4
		//IL_0e61: Expected O, but got I
		//IL_0eb2: Expected I4, but got O
		//IL_0e97: Expected O, but got I4
		//IL_0034->IL0ec3: Incompatible stack heights: 1 vs 0
		//IL_0078->IL0ec3: Incompatible stack heights: 1 vs 0
		//IL_022f->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_0298->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_02c7->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_030f->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_033e->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_037a->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_03d2->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_0401->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_0487->IL0ec3: Incompatible stack heights: 2 vs 0
		//IL_04d9->IL0ec3: Incompatible stack heights: 3 vs 0
		//IL_0521->IL0ec3: Incompatible stack heights: 3 vs 0
		//IL_056d->IL0ec3: Incompatible stack heights: 3 vs 0
		//IL_05b8->IL0ec3: Incompatible stack heights: 3 vs 0
		//IL_0690->IL0ec3: Incompatible stack heights: 3 vs 0
		//IL_0932->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_095e->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_09cd->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_09ab->IL09ab: Incompatible stack heights: 15 vs 14
		//IL_0ab8->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_0ae4->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_0b53->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_0b31->IL0b31: Incompatible stack heights: 15 vs 14
		//IL_10be->IL0ec3: Incompatible stack heights: 14 vs 0
		//IL_0d80->IL0ec3: Incompatible stack heights: 14 vs 0
		base.InitProjectile(pool, weapon, index);
		List<string> flowerNames = _flowerNames;
		bool flag21;
		object obj13;
		if (_flowerNames != null)
		{
			object obj = UnityEngine.Random.RandomRangeInt(0, flowerNames._size);
			bool flag = (nint)obj >= flowerNames._size;
			string[] items = flowerNames._items;
			if (flowerNames._items != null)
			{
				Sprite sprite = SpriteManager.GetSprite(items[obj], "vfx");
				if ((object)_FlowerSprite != null)
				{
					PhaserSprite phaserSprite = _FlowerSprite.setFrame(sprite);
					List<string> cachedTransform = (List<string>)(object)_cachedTransform;
					_isCullable = false;
					bool flag2 = cachedTransform._items == null;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)cachedTransform._items, ref value);
					BaseBody baseBody = body;
					BaseBody baseBody2 = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
					BaseBody baseBody3 = body;
					baseBody3._enable = true;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					Circle a = _a;
					float num = _weapon.PArea();
					float num2 = (a._radius = (float)Vector3.oneVector * 8f);
					float diameter = num2 + num2;
					a._diameter = diameter;
					RenderingExtensions.SetEmitZone(emitZone: new EmitZone
					{
						_type = EmitZoneType.Random,
						_source = _a,
						_yoyo = false
					}, pfx: _fwEmitter2);
					_FlowerSprite.enabled = true;
					_renderer.enabled = false;
					_bounceAreaMod = 1f;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 0.65f);
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_GroundFx, 0.1f);
					BaseBody baseBody4 = body;
					if (body != null)
					{
						baseBody4._bounce = (float2)1066192077;
						_ = 1066192077;
						Weapon weapon2 = _weapon;
						_canBounce = false;
						_isCullable = true;
						_saveVelX = 1f;
						_saveVelY = 1f;
						if ((object)_weapon != null)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
							{
								float num3 = (float)characterController._lastMovementDirection * -1f;
								_aimVec = (Vector2)num3;
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v61 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
										float num4 = 0f * -1f;
										if ((object)_weapon != null)
										{
											float num5 = _weapon.PSpeed();
											float num6 = (float)_aimVec * num4;
											float num7 = num4 * num4;
											ArcadeSprite sprite2 = _sprite;
											if ((object)_sprite != null)
											{
												BaseBody baseBody5 = sprite2.body;
												if (sprite2.body != null)
												{
													baseBody5._velocity = (float2)num6;
													if (_speedTween != null)
													{
														_speedTween.Kill();
													}
													_BombDeceleration = 1f;
													TweenConfig tweenConfig = new TweenConfig();
													object[] array = new object[1];
													if (array != null)
													{
														nint num8 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj2 = default(object);
														bool flag3 = obj2 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig != null)
														{
															tweenConfig.targets = array;
															Dictionary<string, object> dictionary = new Dictionary<string, object>();
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
															if (dictionary != null)
															{
																object value2 = default(object);
																bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_BombDeceleration", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																tweenConfig.custom = dictionary;
																if ((object)_weapon != null)
																{
																	float num9 = _weapon.PDuration();
																	float num10 = (tweenConfig.delay = num4 * 0.25f);
																	if ((object)_weapon != null)
																	{
																		float num11 = _weapon.PDuration();
																		float duration = num10 * 0.75f;
																		tweenConfig.ease = Ease.Linear;
																		tweenConfig.duration = duration;
																		TweenCallback onComplete = delegate
																		{
																			FadeOut();
																		};
																		tweenConfig.onComplete = onComplete;
																		MultiTargetTween speedTween = Tweens.Add(tweenConfig);
																		_speedTween = speedTween;
																		bool flag5 = _indexInWeapon >= 4;
																		int num12 = 0;
																		float num14 = default(float);
																		if (!flag5)
																		{
																			SfxType[] soundArray = _soundArray;
																			if (_soundArray == null)
																			{
																				goto IL_0ec3;
																			}
																			int num13 = (int)(_indexInWeapon & 0x80000003L);
																			if ((nint)_soundArray < 0)
																			{
																				object obj3 = num13 - 1;
																				object obj4 = obj3 | -4;
																				num13 = obj4 + 1;
																			}
																			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																			{
																				Rate = 1f
																			};
																			float detune = (float)_indexInWeapon * 200f;
																			soundConfig.Detune = detune;
																			soundConfig.Volume = (float?)(object)1;
																			PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref soundArray[num13]), soundConfig, 200f, 10, num14);
																			num12 = 10;
																		}
																		object cachedFlowerTransform = _cachedFlowerTransform;
																		bool flag6 = (object)_cachedFlowerTransform == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ rbx_v29 (System.Object)+10]");
																		bool flag7 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ rbx_v29 (System.Object)+10]");
																		Transform.set_localScale_Injected((IntPtr)0, ref value);
																		bool flag8 = (object)_FlowerSprite == null;
																		PhaserSprite phaserSprite2 = _FlowerSprite.setAlpha(0.65f);
																		bool flag9 = (object)_FlowerSprite == null;
																		PhaserSprite phaserSprite3 = _FlowerSprite.setVisible(visible: true);
																		object cachedFlowerTransform2 = _cachedFlowerTransform;
																		_ScaleAfterBounceMod = 1f;
																		bool flag10 = (object)_weapon == null;
																		float num15 = _weapon.PArea();
																		int num16 = -_radius;
																		object obj5 = Vector3.zeroVector * _bounceAreaMod;
																		object obj6 = obj5 * _ScaleAfterBounceMod;
																		float num17 = (float)num16 * 0.01f;
																		float num18 = (float)obj6 * num17;
																		bool flag11 = (object)_cachedFlowerTransform == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rbx_v30 (System.Object)+10]");
																		bool flag12 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rbx_v30 (System.Object)+10]");
																		Vector3 value3 = default(Vector3);
																		Transform.set_position_Injected((IntPtr)0, ref value3);
																		bool flag13 = (object)_weapon == null;
																		float num19 = _weapon.PArea();
																		object obj8 = default(object);
																		object obj7 = obj8 * _bounceAreaMod;
																		float endValue = (float)obj7 * _ScaleAfterBounceMod;
																		bool flag14 = (object)_renderer == null;
																		Transform transform = _renderer.transform;
																		bool flag15 = (object)transform == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2603 @ rax_v125 (UnityEngine.Transform)+10]");
																		bool flag16 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2603 @ rax_v125 (UnityEngine.Transform)+10]");
																		Vector3 value4 = default(Vector3);
																		Transform.set_localScale_Injected((IntPtr)0, ref value4);
																		if (_tween1 != null)
																		{
																			_tween1.Kill();
																		}
																		TweenConfig tweenConfig2 = new TweenConfig();
																		object[] array2 = new object[1];
																		if ((object)_renderer != null)
																		{
																			Transform transform2 = _renderer.transform;
																			if (array2 != null)
																			{
																				if ((object)transform2 != null)
																				{
																					nint num20 = (nint)array2;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																					object obj9 = default(object);
																					bool flag17 = obj9 == null;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				if (tweenConfig2 != null)
																				{
																					tweenConfig2.targets = array2;
																					tweenConfig2.duration = 500f;
																					tweenConfig2.ease = Ease.OutBack;
																					tweenConfig2.scaleY = (float?)(object)1;
																					TweenCallback onStart = delegate
																					{
																						Transform cachedRendererTransform = _cachedRendererTransform;
																						bool flag23 = ((UnityEngine.Object)cachedRendererTransform).m_CachedPtr == (IntPtr)0;
																						Vector3 value5 = default(Vector3);
																						Transform.set_localScale_Injected(((UnityEngine.Object)cachedRendererTransform).m_CachedPtr, ref value5);
																						Transform cachedFlowerTransform3 = _cachedFlowerTransform;
																						bool flag24 = (object)_cachedFlowerTransform == null;
																						bool flag25 = ((UnityEngine.Object)cachedFlowerTransform3).m_CachedPtr == (IntPtr)0;
																						Vector3 value6 = default(Vector3);
																						Transform.set_localScale_Injected(((UnityEngine.Object)cachedFlowerTransform3).m_CachedPtr, ref value6);
																					};
																					tweenConfig2.onStart = onStart;
																					MultiTargetTween tween = Tweens.Add(tweenConfig2);
																					_tween1 = tween;
																					if (_tween2 != null)
																					{
																						_tween2.Kill();
																					}
																					TweenConfig tweenConfig3 = new TweenConfig();
																					object[] array3 = new object[1];
																					if ((object)_renderer != null)
																					{
																						Transform transform3 = _renderer.transform;
																						if (array3 != null)
																						{
																							if ((object)transform3 != null)
																							{
																								nint num21 = (nint)array3;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																								object obj10 = default(object);
																								bool flag18 = obj10 == null;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							if (tweenConfig3 != null)
																							{
																								tweenConfig3.targets = array3;
																								tweenConfig3.duration = 600f;
																								tweenConfig3.ease = Ease.OutBack;
																								tweenConfig3.scaleX = (float?)(object)1;
																								TweenCallback onComplete2 = delegate
																								{
																									//IL_000d: Expected I, but got O
																									//IL_00fc: Invalid comparison between F4 and I4
																									//IL_011c: Expected F4, but got I4
																									_canBounce = true;
																									TweenConfig tweenConfig4 = new TweenConfig();
																									object[] array4 = new object[1];
																									nint num25 = (nint)array4;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																									object obj14 = default(object);
																									if (obj14 != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										tweenConfig4.targets = array4;
																										Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
																										Weapon weapon4 = _weapon;
																										float num26 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.PMoveSpeed();
																										float num27 = default(float);
																										if (1f > num27)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																										}
																										object value5 = default(object);
																										bool flag23 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_ScaleAfterBounceMod", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																										tweenConfig4.custom = dictionary2;
																										float num28 = _weapon.PDuration();
																										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																										float num29 = num28 - 600f;
																										if (num29 < 500f)
																										{
																											num29 = 500f;
																										}
																										tweenConfig4.duration = num29;
																										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig4);
																										return;
																									}
																									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																									throw ex;
																								};
																								tweenConfig3.onComplete = onComplete2;
																								MultiTargetTween tween2 = Tweens.Add(tweenConfig3);
																								_tween2 = tween2;
																								Tween colliderTween = _colliderTween;
																								if (_colliderTween != null && colliderTween._003Cactive_003Ek__BackingField)
																								{
																									TweenExtensions.Kill(_colliderTween);
																								}
																								DOGetter<float> getter = null;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																								DOSetter<float> dOSetter = null;
																								((Flower2Projectile)(object)dOSetter)._003CInitProjectile_003Eb__41_1(num17);
																								TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, endValue, 0.6f);
																								if (tweenerCore != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3059 @ rax_v169 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																									if ((nint)0 != 0)
																									{
																										_ = 27;
																										_ = 0;
																									}
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																								bool flag19 = (nint)0 != 0;
																								bool useRealTime = (byte)(int)num14 != 0;
																								if (!flag19)
																								{
																									_ = 1;
																									useRealTime = (byte)(int)num14 != 0;
																								}
																								if (tweenerCore != null)
																								{
																									_colliderTween = tweenerCore;
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
																										MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																										int repeat = default(int);
																										TimerType type = default(TimerType);
																										Timer hitboxTimer = Timers.Register(duration2, onComplete3, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																										_hitboxTimer = hitboxTimer;
																										bool flag20 = (object)weapon == null;
																										flag21 = false;
																										if (!flag20)
																										{
																											nint num22 = (nint)typeof(Flower2Weapon);
																											nint num23 = (nint)weapon;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3387 @ rdx_v111 (Il2CppClass<VampireSurvivors.Objects.Weapons.Flower2Weapon>)+130]");
																											object obj11 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3388 @ r8_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
																											nint num24 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3387 @ rdx_v111 (Il2CppClass<VampireSurvivors.Objects.Weapons.Flower2Weapon>)+130]");
																											if (num24 >= 0)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3388 @ r8_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
																												object obj12 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3444 @ rax_v190+FFFFFFF8+v3389 @ rax_v186*8]");
																												if (0 == (nint)typeof(Flower2Weapon))
																												{
																													obj13 = 1;
																													goto IL_10e9;
																												}
																											}
																											obj13 = 0;
																											goto IL_10e9;
																										}
																										goto IL_110f;
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
								}
							}
						}
					}
				}
			}
		}
		goto IL_0ec3;
		IL_10e9:
		bool flag22 = obj13 == null;
		flag21 = false;
		if (!flag22)
		{
			flag21 = (byte)(int)weapon != 0;
		}
		goto IL_110f;
		IL_110f:
		trueWeapon = (Flower2Weapon)flag21;
		ExplosionTriggered = false;
		return;
		IL_0ec3:
		throw new NullReferenceException();
	}

	private void MakeProfusionSprites()
	{
		PhaserSprite phaserSprite = sprSplash;
		Vector2 pos = default(Vector2);
		int num = default(int);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		if ((object)sprSplash == null || ((UnityEngine.Object)phaserSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			float2 float5 = base.position;
			PhaserSprite phaserSprite2 = RenderingExtensions.sprite(s_scene.add, pos, "anima", "FlexSplash_01.png");
			PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
			sprSplash = phaserSprite3;
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("FlexSplash_", 1, 8, "anima", num);
			PhaserSprite phaserSprite4 = sprSplash;
			phaserSprite4._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite phaserSprite5 = sprSplash;
			phaserSprite5._spriteAnimation.SetAnimation("idle");
		}
		PhaserSprite phaserSprite6 = sprFlower;
		if ((object)sprFlower == null || ((UnityEngine.Object)phaserSprite6).m_CachedPtr == (IntPtr)0)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			float2 float6 = base.position;
			PhaserSprite phaserSprite7 = RenderingExtensions.sprite(s_scene2.add, pos, "anima", "FlexFlower_01.png");
			PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0f);
			sprFlower = phaserSprite8;
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("FlexFlower_", 1, 8, "anima", num);
			PhaserSprite phaserSprite9 = sprFlower;
			phaserSprite9._spriteAnimation.AddAnimation("idle", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite phaserSprite10 = sprFlower;
			phaserSprite10._spriteAnimation.SetAnimation("idle");
		}
	}

	public void SizeUp()
	{
		if (_canBounce)
		{
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
			Timer bounceTimer = Timers.Register(0.6f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
		}
	}

	public void Explode()
	{
		//IL_00e9: Expected I, but got O
		//IL_014e: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_01d4: Expected I, but got O
		//IL_022c: Expected I, but got O
		//IL_0282: Expected O, but got I4
		if (ExplosionTriggered)
		{
			return;
		}
		ExplosionTriggered = true;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		if (splashTweenIn != null)
		{
			splashTweenIn.Kill();
		}
		if (splashTweenOut != null)
		{
			splashTweenOut.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)sprSplash != null)
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
		float num2 = trueWeapon.PArea();
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		splashTweenIn = multiTargetTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)sprFlower != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)sprSplash != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.delay = 500f;
		tweenConfig2.duration = 200f;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		splashTweenOut = multiTargetTween2;
		FadeOut();
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
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0105: Expected I4, but got O
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_0354: Expected I, but got O
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_044c: Expected O, but got I4
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Expected O, but got Unknown
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected O, but got Unknown
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Expected O, but got Unknown
		//IL_06b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Expected O, but got Unknown
		//IL_03f1->IL0341: Incompatible stack heights: 2 vs 0
		//IL_056e->IL02cb: Incompatible stack heights: 5 vs 0
		object obj = _aimVec * _saveVelX;
		ArcadeSprite sprite = _sprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Flower2Projectile)+134]");
		object obj2 = 0 * _saveVelY;
		Vector3 vector = (Vector3)(obj * _BombDeceleration);
		object obj3 = obj2 * _BombDeceleration;
		object obj9 = default(object);
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = (float2)vector;
				if (!_canBounce)
				{
					goto IL_06cd;
				}
				if ((object)_weapon != null)
				{
					float num = _weapon.PArea();
					object obj4 = vector * _bounceAreaMod;
					object obj5 = obj4 * _ScaleAfterBounceMod;
					if ((object)_renderer != null)
					{
						Transform transform = _renderer.transform;
						nint num2 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v96 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num3 = 0;
						vector = Vector3.oneVector;
						object obj6 = default(object);
						obj3 = obj6 * obj5;
						_ = Vector3.oneVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v55 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
						object obj7 = 0 * obj5;
						bool flag = (object)transform == null;
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj8 = obj9 - 48;
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj8);
						goto IL_06cd;
					}
				}
			}
		}
		goto IL_02cb;
		IL_02cb:
		throw new NullReferenceException();
		IL_06cd:
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			int num4 = (int)s_scene._renderer;
			if (s_scene._renderer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdi_v22 (System.Int32)+1C]");
				int num5 = (int)(-0);
				if ((object)_GroundFx != null)
				{
					_GroundFx.sortingOrder = num5;
					if ((object)_renderer != null)
					{
						_renderer.sortingOrder = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
						if ((object)_FlowerSprite != null)
						{
							int num6 = default(int);
							PhaserSprite phaserSprite = _FlowerSprite.setDepth(num6);
							int num7 = num5 - 1;
							RenderingExtensions.SetDepth(_fwEmitter2, num7);
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
										bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										object obj10 = obj9 - 64;
										Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj10);
										object obj11 = _radius + _radius;
										float num8 = (float)obj11 * 0.01f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-38]");
										float num9 = 0f * num8;
										bool flag4 = (object)transform2 == null;
										bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										object obj12 = obj9 - 32;
										Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj12);
										object cachedRendererTransform = _cachedRendererTransform;
										object cachedFlowerTransform = _cachedFlowerTransform;
										bool flag6 = (object)_cachedRendererTransform == null;
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rdi_v27 (System.Object)+10]");
										bool flag7 = (nint)0 == 0;
										object obj13 = obj9 - 64;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rdi_v27 (System.Object)+10]");
										Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj13);
										object cachedRendererTransform2 = _cachedRendererTransform;
										if ((object)_cachedRendererTransform != null)
										{
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v28 (System.Object)+10]");
											bool flag8 = (nint)0 == 0;
											object obj14 = obj9 - 48;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v28 (System.Object)+10]");
											Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj14);
											bool flag9 = (object)_cachedFlowerTransform == null;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rsi_v25 (System.Object)+10]");
											bool flag10 = (nint)0 == 0;
											object obj15 = obj9 - 64;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rsi_v25 (System.Object)+10]");
											Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj15);
											object cachedFlowerTransform2 = _cachedFlowerTransform;
											bool flag11 = (object)_cachedFlowerTransform == null;
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v30 (System.Object)+10]");
											bool flag12 = (nint)0 == 0;
											object obj16 = obj9 - 48;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v30 (System.Object)+10]");
											Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj16);
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v30 (System.Object)+10]");
											bool flag13 = (nint)0 == 0;
											object obj17 = obj9 - 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v30 (System.Object)+10]");
											Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj17);
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
		goto IL_02cb;
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

	public Flower2Projectile()
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

	private void _003CInitProjectile_003Eb__41_3()
	{
		FadeOut();
	}

	private void _003CInitProjectile_003Eb__41_4()
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

	private void _003CInitProjectile_003Eb__41_5()
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

	private float _003CInitProjectile_003Eb__41_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CInitProjectile_003Eb__41_1(float x)
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

	private void _003CInitProjectile_003Eb__41_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CSizeUp_003Eb__43_0()
	{
		_canBounce = true;
	}

	private void _003CFadeOut_003Eb__47_0()
	{
		Despawn();
	}
}
