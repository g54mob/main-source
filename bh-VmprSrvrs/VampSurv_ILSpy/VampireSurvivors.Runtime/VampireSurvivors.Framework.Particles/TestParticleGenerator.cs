using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Framework.Particles;

public class TestParticleGenerator : GameMonoBehaviour
{
	private RectTransform _Canvas;

	private ParticleSystem _playerDamageVfx;

	private ParticleSystem _pickupVfx;

	private ParticleEmitterManager _explosionManager;

	private ParticleSystem _explosion1Pfx;

	private ParticleSystem _explosion2Pfx;

	private GravityWell _explosionGravWell;

	private ParticleEmitterManager _fireworksManager;

	protected override void OnUpdate()
	{
		ParticleSystem playerDamageVfx = _playerDamageVfx;
		if ((object)_playerDamageVfx != null && ((UnityEngine.Object)playerDamageVfx).m_CachedPtr != (IntPtr)0)
		{
			_playerDamageVfx.Emit(1);
		}
	}

	private unsafe void TestFireworksVfx(int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_010c: Expected O, but got I
		//IL_01fd: Expected O, but got I4
		//IL_0222: Expected O, but got Ref
		//IL_0237: Expected native int or pointer, but got O
		//IL_0251: Expected O, but got I
		//IL_0271: Expected O, but got Ref
		//IL_028b: Expected native int or pointer, but got O
		//IL_02a5: Expected O, but got I
		//IL_02c5: Expected O, but got Ref
		//IL_02d4: Expected O, but got I4
		//IL_02e2: Expected native int or pointer, but got O
		//IL_02fc: Expected O, but got I
		//IL_0314: Expected O, but got Ref
		//IL_036d: Expected native int or pointer, but got O
		//IL_068e: Expected O, but got I4
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03f5: Expected O, but got Ref
		//IL_040a: Expected O, but got I
		//IL_0442: Expected native int or pointer, but got O
		//IL_06c0: Expected O, but got I
		//IL_0499: Expected O, but got I
		//IL_04ba: Expected O, but got I
		//IL_0525: Expected O, but got I
		//IL_059e: Expected F4, but got I
		//IL_0608: Expected F4, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager fireworksManager = _fireworksManager;
		if ((object)_fireworksManager != null && ((UnityEngine.Object)fireworksManager).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj3 = _fireworksManager.gameObject;
			UnityEngine.Object.Destroy(obj3, 0f);
		}
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "FireworksVfx");
		Transform transform = gameObject.transform;
		Transform parent = base.transform;
		transform.SetParent(parent, worldPositionStays: false);
		ref ParticleEmitterManager component = ref System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		ParticleEmitterManager fireworksManager2;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out component))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
			fireworksManager2 = (ParticleEmitterManager)0;
		}
		else
		{
			fireworksManager2 = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_fireworksManager = fireworksManager2;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		object obj4;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
			obj4 = "PfxBlue.png";
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			obj4 = list._size;
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(3000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
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
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		float num = (float)index / 5f;
		_ = 0;
		float num2 = num * 300f;
		float num3 = num2 * 0.5f;
		float max = num3 + 150f;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, max));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r14d\"");
		float num4 = (float)index / 5f;
		object obj5 = obj4 >> 1;
		object obj6 = obj5 + 1;
		object obj7 = obj5 >> 31;
		object obj8 = obj7 + obj6;
		object obj9 = obj8 << 5;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		particleSystemConfig._quantity = (int?)(object)0;
		float num5 = num4 + num4;
		_ = 0;
		_ = 0;
		float min = num5 + 2f;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		_ = 0;
		_ = 1115684864;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _fireworksManager.CreateEmitter(particleSystemConfig, null, "Fireworks");
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		_ = 3212836864L;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		gravityWellConfig._y = (float?)(object)0;
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 25f;
		gravityWellConfig._gravity = 150f;
		GravityWell gravityWell = _fireworksManager.CreateGravityWell(gravityWellConfig);
		Action onComplete = delegate
		{
			_fireworksManager.StopAllEmitters();
		};
		Action<float> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		((TestParticleGenerator)(object)action)._003CTestFireworksVfx_003Eb__9_1(0f);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.030000001f, onComplete, action, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			_fireworksManager.StopAllEmitters();
		};
		Action<float> action2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		((TestParticleGenerator)(object)action2)._003CTestFireworksVfx_003Eb__9_3(0f);
		Timer timer2 = Timers.Register(0.030000001f, onComplete2, action2, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void TestPlayerDamageVfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00eb: Expected O, but got I
		//IL_0107: Expected O, but got I4
		//IL_0120: Expected O, but got Ref
		//IL_012f: Expected O, but got I4
		//IL_013d: Expected native int or pointer, but got O
		//IL_03ac: Expected O, but got I4
		//IL_0155: Expected O, but got Ref
		//IL_016f: Expected native int or pointer, but got O
		//IL_0189: Expected O, but got I
		//IL_01a9: Expected O, but got Ref
		//IL_01c3: Expected native int or pointer, but got O
		//IL_03c9: Expected O, but got I4
		//IL_01f5: Expected O, but got Ref
		//IL_020f: Expected native int or pointer, but got O
		//IL_0403: Expected O, but got I
		//IL_0255: Expected O, but got I4
		//IL_0287: Expected O, but got I
		//IL_043d: Expected O, but got I
		//IL_02c7: Expected O, but got I
		//IL_02e2: Expected O, but got I
		//IL_02fd: Expected O, but got I
		//IL_031b: Expected O, but got I4
		//IL_0330: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"WhiteDot");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		_ = 0;
		_ = 10;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(75f, 125f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 16711680;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._tint = (uint?)(object)0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		_ = 257;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		_ = 1;
		particleSystemConfig._bounds = (Rect?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12010]");
		_ = 0;
		particleSystemConfig._on = false;
		Transform parent = base.transform;
		ParticleSystem playerDamageVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
		_playerDamageVfx = playerDamageVfx;
	}

	private unsafe void TestPickupVfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04ac: Expected I, but got O
		//IL_01b2: Expected O, but got Ref
		//IL_01cc: Expected native int or pointer, but got O
		//IL_01e6: Expected O, but got I
		//IL_0206: Expected O, but got Ref
		//IL_0220: Expected native int or pointer, but got O
		//IL_0415: Expected O, but got I4
		//IL_0238: Expected O, but got Ref
		//IL_025f: Expected O, but got I
		//IL_0279: Expected native int or pointer, but got O
		//IL_0293: Expected O, but got I
		//IL_02b3: Expected O, but got Ref
		//IL_02cd: Expected native int or pointer, but got O
		//IL_0432: Expected O, but got I4
		//IL_02e5: Expected O, but got Ref
		//IL_02ff: Expected native int or pointer, but got O
		//IL_045c: Expected O, but got I
		//IL_0337: Expected O, but got Ref
		//IL_034c: Expected native int or pointer, but got O
		//IL_0366: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pickupVfx = _pickupVfx;
		if ((object)_pickupVfx == null || ((UnityEngine.Object)pickupVfx).m_CachedPtr == (IntPtr)0)
		{
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxColor1");
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
				((List<object>)(object)list).AddWithResize((object)"PfxColor2");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(25f, 50f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-1000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
			_ = 0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pickupVfx2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			_pickupVfx = pickupVfx2;
		}
		List<string> pickupVfx3 = (List<string>)(object)_pickupVfx;
		bool flag = pickupVfx3._items == null;
		ParticleSystem.Emit_Internal_Injected((IntPtr)pickupVfx3._items, 10);
	}

	private unsafe void TestExplosion()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0160: Expected O, but got I
		//IL_0382: Expected O, but got Ref
		//IL_039c: Expected native int or pointer, but got O
		//IL_03ce: Expected O, but got Ref
		//IL_03e8: Expected native int or pointer, but got O
		//IL_041a: Expected O, but got Ref
		//IL_0434: Expected native int or pointer, but got O
		//IL_0459: Expected O, but got Ref
		//IL_0492: Expected native int or pointer, but got O
		//IL_04ca: Expected O, but got Ref
		//IL_0503: Expected native int or pointer, but got O
		//IL_0776: Expected O, but got Ref
		//IL_0790: Expected native int or pointer, but got O
		//IL_07c2: Expected O, but got Ref
		//IL_07dc: Expected native int or pointer, but got O
		//IL_080e: Expected O, but got Ref
		//IL_0828: Expected native int or pointer, but got O
		//IL_0850: Expected O, but got I
		//IL_0863: Expected O, but got Ref
		//IL_089c: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager explosionManager = _explosionManager;
		if ((object)_explosionManager != null && ((UnityEngine.Object)explosionManager).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_explosionManager == null)
			{
				throw new NullReferenceException();
			}
			GameObject obj3 = _explosionManager.gameObject;
			UnityEngine.Object.Destroy(obj3, 0f);
		}
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "ExplosionManager");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: false);
				ref ParticleEmitterManager component = ref System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 400));
				_ = 0;
				ParticleEmitterManager explosionManager2;
				if (gameObject.TryGetComponent<ParticleEmitterManager>(out component))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
					explosionManager2 = (ParticleEmitterManager)0;
				}
				else
				{
					explosionManager2 = gameObject.AddComponent<ParticleEmitterManager>();
				}
				_explosionManager = explosionManager2;
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
				List<string> list = new List<string>();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
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
						if (list._items != null)
						{
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
							if (particleSystemConfig != null)
							{
								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
								_ = 0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
								_ = 0;
								_ = 4;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
								_ = 0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
								_ = 0;
								_ = 1082130432;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
								_ = 0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C8]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
								_ = 0;
								_ = 0;
								if ((object)_explosionManager != null)
								{
									ParticleSystem explosion1Pfx = _explosionManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter1");
									_explosion1Pfx = explosion1Pfx;
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
									List<string> list2 = new List<string>();
									if (list2 != null)
									{
										int version3 = list2._version + 1;
										list2._version = version3;
										string[] items3 = list2._items;
										if (list2._items != null)
										{
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
											if (list2._items != null)
											{
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
												if (particleSystemConfig2 != null)
												{
													minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
													_ = 0;
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D8]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E8]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F8]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+108]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+118]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+128]");
													obj = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
													_ = 0;
													_ = 4;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
													_ = 0;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+138]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+148]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
													_ = 0;
													_ = 0;
													_ = 1073741824;
													_ = 1;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
													_ = 0;
													_ = 1;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
													_ = 0;
													_ = 0;
													if ((object)_explosionManager != null)
													{
														ParticleSystem explosion2Pfx = _explosionManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
														_explosion2Pfx = explosion2Pfx;
														GravityWellConfig gravityWellConfig = new GravityWellConfig();
														if (gravityWellConfig != null)
														{
															_ = 1077936128;
															_ = 1120403456;
															_ = 1120403456;
															if ((object)_explosionManager != null)
															{
																GravityWell explosionGravWell = _explosionManager.CreateGravityWell(gravityWellConfig);
																_explosionGravWell = explosionGravWell;
																if ((object)_explosionGravWell != null)
																{
																	Transform transform2 = _explosionGravWell.transform;
																	if ((object)transform2 != null)
																	{
																		bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
																		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																		Vector3 value = default(Vector3);
																		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
																		RenderingExtensions.Start(_explosion1Pfx);
																		RenderingExtensions.Start(_explosion2Pfx);
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
		throw new NullReferenceException();
	}

	private unsafe void TestArcanaParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00fd: Expected O, but got Ref
		//IL_0116: Expected native int or pointer, but got O
		//IL_0135: Expected O, but got I
		//IL_0155: Expected O, but got Ref
		//IL_016f: Expected native int or pointer, but got O
		//IL_0189: Expected O, but got I
		//IL_01b7: Expected O, but got I4
		//IL_01d0: Expected O, but got Ref
		//IL_01ea: Expected native int or pointer, but got O
		//IL_063e: Expected O, but got I4
		//IL_020f: Expected O, but got Ref
		//IL_0229: Expected native int or pointer, but got O
		//IL_0670: Expected O, but got I
		//IL_0280: Expected O, but got I
		//IL_02a1: Expected O, but got I
		//IL_03cc: Expected O, but got Ref
		//IL_03e5: Expected native int or pointer, but got O
		//IL_03ff: Expected O, but got I
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected F4, but got Unknown
		//IL_0474: Expected O, but got I4
		//IL_048d: Expected O, but got Ref
		//IL_04a7: Expected native int or pointer, but got O
		//IL_04c1: Expected O, but got I
		//IL_04ef: Expected O, but got I4
		//IL_0508: Expected O, but got Ref
		//IL_0522: Expected native int or pointer, but got O
		//IL_06aa: Expected O, but got I
		//IL_055a: Expected O, but got Ref
		//IL_0574: Expected native int or pointer, but got O
		//IL_06e4: Expected O, but got I
		//IL_05cb: Expected O, but got I
		//IL_05ec: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("randomazzo");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"back");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj3 = default(object);
		float max = (float)obj3 * 2f;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 4473924;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		particleSystemConfig._tint = (uint?)(object)0;
		Transform parent = base.transform;
		ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("randomazzo");
		List<string> list2 = new List<string>();
		int version2 = list2._version + 1;
		list2._version = version2;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"back");
		}
		else
		{
			int size2 = list2._size + 1;
			list2._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		Camera main2 = Camera.main;
		Bounds bounds2 = CameraExtensions.OrthographicBounds(main2);
		float max2 = (float)obj3 * 2f;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, max2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
		particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+98]");
		_ = 0;
		Camera main3 = Camera.main;
		Bounds bounds3 = CameraExtensions.OrthographicBounds(main3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rax_v44 (UnityEngine.Bounds)+10]");
		float num = 0f * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float constant = num ^ 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(constant);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B8]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(-100f, -200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 4473924;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		particleSystemConfig2._tint = (uint?)(object)0;
		Transform parent2 = base.transform;
		ParticleSystem particleSystem2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2);
	}

	private unsafe void TestEnemyEye()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03c6: Expected O, but got Ref
		//IL_03e0: Expected native int or pointer, but got O
		//IL_03fa: Expected O, but got I
		//IL_041a: Expected O, but got Ref
		//IL_0434: Expected native int or pointer, but got O
		//IL_05cf: Expected O, but got I4
		//IL_044c: Expected O, but got Ref
		//IL_0473: Expected O, but got I
		//IL_0488: Expected native int or pointer, but got O
		//IL_04a2: Expected O, but got I
		//IL_04c2: Expected O, but got Ref
		//IL_04dc: Expected native int or pointer, but got O
		//IL_05ec: Expected O, but got I4
		//IL_04f4: Expected O, but got Ref
		//IL_050e: Expected native int or pointer, but got O
		//IL_0616: Expected O, but got I
		//IL_065c: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood1");
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
			((List<object>)(object)list).AddWithResize((object)"Blood2");
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
			((List<object>)(object)list).AddWithResize((object)"Blood3");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"t");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"u");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"r");
		}
		else
		{
			int size6 = list._size + 1;
			list._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-58]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(15f, 30f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(550f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Edge;
		emitZone._source = circle;
		_ = 0;
		_ = 48;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		emitZone._quantity = (int?)(object)0;
		emitZone._yoyo = false;
		particleSystemConfig._emitZone = emitZone;
		Transform parent = base.transform;
		ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
	}

	private void TestGoldFever()
	{
		//IL_02cf: Expected O, but got I4
		//IL_021f: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
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
			int size = list._size + 1;
			list._size = size;
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
			int size2 = list._size + 1;
			list._size = size2;
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
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1f, 0f);
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(1500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		particleSystemConfig._blendMode = (BlendMode?)(object)1;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Edge;
		emitZone._source = circle;
		emitZone._quantity = (int?)(object)1;
		emitZone._yoyo = false;
		particleSystemConfig._emitZone = emitZone;
		Transform parent = base.transform;
		ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
	}

	private unsafe void TestBackground4Particles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_033c: Expected O, but got I4
		//IL_0363: Expected O, but got I4
		//IL_038a: Expected O, but got I4
		//IL_03a3: Expected O, but got Ref
		//IL_03bd: Expected native int or pointer, but got O
		//IL_03d7: Expected O, but got I
		//IL_03f7: Expected O, but got Ref
		//IL_0411: Expected native int or pointer, but got O
		//IL_042b: Expected O, but got I
		//IL_044b: Expected O, but got Ref
		//IL_0465: Expected native int or pointer, but got O
		//IL_05fb: Expected O, but got I4
		//IL_047d: Expected O, but got Ref
		//IL_04a4: Expected O, but got I
		//IL_04be: Expected native int or pointer, but got O
		//IL_0618: Expected O, but got I4
		//IL_04f0: Expected O, but got Ref
		//IL_050a: Expected native int or pointer, but got O
		//IL_0652: Expected O, but got I
		//IL_0561: Expected O, but got I
		//IL_0588: Expected O, but got I
		//IL_05a9: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_02.png");
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
			((List<object>)(object)list).AddWithResize((object)"_runes_03.png");
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
			((List<object>)(object)list).AddWithResize((object)"_runes_04.png");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_05.png");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_06.png");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(3000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 300f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 64;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		_ = 0;
		_ = 1115684864;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 11206655;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._tint = (uint?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		Transform parent = base.transform;
		ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
	}

	private unsafe void TestUiFireworks()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d6: Expected O, but got I
		//IL_0206: Expected O, but got Ref
		//IL_021b: Expected native int or pointer, but got O
		//IL_024d: Expected O, but got Ref
		//IL_0267: Expected native int or pointer, but got O
		//IL_0299: Expected O, but got Ref
		//IL_02b3: Expected native int or pointer, but got O
		//IL_02e5: Expected O, but got Ref
		//IL_02f4: Expected O, but got I4
		//IL_0302: Expected native int or pointer, but got O
		//IL_0337: Expected O, but got Ref
		//IL_035b: Expected O, but got F8
		//IL_0387: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "UiFireworks");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: false);
				ref ParticleEmitterManager component = ref System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
				_ = 0;
				ParticleEmitterManager particleEmitterManager;
				if (gameObject.TryGetComponent<ParticleEmitterManager>(out component))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
					particleEmitterManager = (ParticleEmitterManager)0;
				}
				else
				{
					ParticleEmitterManager particleEmitterManager2 = gameObject.AddComponent<ParticleEmitterManager>();
					particleEmitterManager = particleEmitterManager2;
				}
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
				List<string> list = new List<string>();
				list._002Ector();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxYellow");
						}
						else
						{
							int size = list._size + 1;
							list._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						if (particleSystemConfig != null)
						{
							ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(3000f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
							_ = 0;
							obj = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 180f));
							_ = 1;
							_ = 0;
							double num = Math.Round(0.20000000298023224);
							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
							_ = 1;
							double num2 = num + 1.0;
							object obj3 = num2 << 5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
							_ = 0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2.4f, 0f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
							_ = 0;
							_ = 0;
							_ = 1115684864;
							_ = 1;
							_ = 0;
							_ = 1;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
							_ = 0;
							if ((object)particleEmitterManager != null)
							{
								ParticleSystem particleSystem = particleEmitterManager.CreateEmitter(particleSystemConfig);
								GravityWellConfig gravityWellConfig = new GravityWellConfig();
								if (gravityWellConfig != null)
								{
									_ = 1065353216;
									_ = 1103626240;
									_ = 1125515264;
									GravityWell gravityWell = particleEmitterManager.CreateGravityWell(gravityWellConfig);
									if ((object)gravityWell != null)
									{
										Transform transform2 = gravityWell.transform;
										bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public TestParticleGenerator()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CTestFireworksVfx_003Eb__9_0()
	{
		_fireworksManager.StopAllEmitters();
	}

	private void _003CTestFireworksVfx_003Eb__9_1(float f)
	{
		_fireworksManager.StartAllEmitters();
	}

	private void _003CTestFireworksVfx_003Eb__9_2()
	{
		_fireworksManager.StopAllEmitters();
	}

	private void _003CTestFireworksVfx_003Eb__9_3(float f)
	{
		_fireworksManager.StartAllEmitters();
	}
}
