using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundBazaar : BackgroundManager
{
	private float _colorBgValue;

	private Transform _spritesRootTransform;

	private List<PhaserSprite> _windows;

	private Timer _colorBgTimer;

	private ParticleEmitterManager _pfxEmitter;

	private ParticleSystem _pfxFire1;

	private ParticleSystem _pfxFire2;

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (_colorBgTimer != null)
		{
			_colorBgTimer.Cancel();
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._003CStopCheckingMinutes_003Ek__BackingField = false;
	}

	protected override void OnUpdate()
	{
		//IL_01fa: Expected O, but got I4
		//IL_0203: Expected O, but got I4
		//IL_02c6: Expected O, but got I4
		//IL_0344: Expected O, but got I4
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected O, but got Unknown
		//IL_03c2: Expected O, but got I4
		//IL_0440: Expected O, but got I4
		base.OnUpdate();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width / 1.28f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num2 = num + 1f;
		float num3 = num2 * 1.28f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num4 = renderer2.height / 3.58f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num5 = num4 + 1f;
		float num6 = num5 * 3.58f;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		float num7 = renderer4.width * 0.5f;
		float num8 = (float)renderer3.screenCenter - num7;
		PhaserScene s_scene5 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer5 = s_scene5._renderer;
		float num9 = renderer5.width * 0.5f;
		float num10 = num9 + (float)renderer3.screenCenter;
		PhaserScene s_scene6 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer6 = s_scene6._renderer;
		float num11 = renderer6.height * 0.5f;
		float num12 = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v23 (PhaserScene+Renderer)+38]");
		float num13 = num12 + 0f;
		PhaserScene s_scene7 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer7 = s_scene7._renderer;
		List<PhaserSprite> windows = _windows;
		float num14 = renderer7.height * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v23 (PhaserScene+Renderer)+38]");
		float num15 = 0f - num14;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < windows._size)
			{
				List<PhaserSprite> windows2 = _windows;
				if ((nint)obj >= windows2._size)
				{
					break;
				}
				PhaserSprite[] items = windows2._items;
				float x = items[obj].X;
				if (num8 > x)
				{
					float x2 = items[obj].X;
					float x3 = x2 + num3;
					items[obj].X = x3;
					object obj3 = 0;
				}
				float x4 = items[obj].X;
				if (x4 > num10)
				{
					float x5 = items[obj].X;
					float x6 = x5 - num3;
					items[obj].X = x6;
					object obj3 = 0;
				}
				float y = items[obj].Y;
				if (y > num13)
				{
					float y2 = items[obj].Y;
					float y3 = y2 - num6;
					items[obj].Y = y3;
					object obj3 = 0;
				}
				float y4 = items[obj].Y;
				if (num15 > y4)
				{
					float y5 = items[obj].Y;
					float y6 = y5 + num6;
					items[obj].Y = y6;
					object obj3 = 0;
				}
				windows = _windows;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Create()
	{
		//IL_0463->IL0463: Incompatible stack heights: 27 vs 25
		base.Create();
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "Background6SpritesRoot");
		if ((object)gameObject != null)
		{
			Transform spritesRootTransform = gameObject.transform;
			_spritesRootTransform = spritesRootTransform;
			if ((object)_mainCamera != null)
			{
				Transform transform = _mainCamera.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					string spritesRootTransform2 = (string)(object)_spritesRootTransform;
					bool flag2 = (object)_spritesRootTransform == null;
					bool flag3 = spritesRootTransform2._stringLength == 0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)spritesRootTransform2._stringLength, ref value);
					bool flag4 = (object)_spritesRootTransform == null;
					_spritesRootTransform.SetParent(transform, worldPositionStays: true);
					GameManager core = GM.Core;
					bool flag5 = (object)GM.Core == null;
					bool flag6 = core._playerOptions == null;
					PlayerOptionsData config = core._playerOptions.Config;
					bool flag7 = config == null;
					config._003CSelectedHurry_003Ek__BackingField = false;
					GameManager core2 = GM.Core;
					bool flag8 = (object)GM.Core == null;
					bool flag9 = core2._playerOptions == null;
					PlayerOptionsData config2 = core2._playerOptions.Config;
					bool flag10 = config2 == null;
					config2._003CSelectedMazzo_003Ek__BackingField = false;
					GameManager core3 = GM.Core;
					bool flag11 = (object)GM.Core == null;
					bool flag12 = core3._playerOptions == null;
					PlayerOptionsData config3 = core3._playerOptions.Config;
					bool flag13 = config3 == null;
					config3._003CSelectedHyper_003Ek__BackingField = false;
					GameManager core4 = GM.Core;
					bool flag14 = (object)GM.Core == null;
					bool flag15 = core4._playerOptions == null;
					PlayerOptionsData config4 = core4._playerOptions.Config;
					bool flag16 = config4 == null;
					config4._003CSelectedInverse_003Ek__BackingField = false;
					GameManager core5 = GM.Core;
					bool flag17 = (object)GM.Core == null;
					bool flag18 = core5._playerOptions == null;
					PlayerOptionsData config5 = core5._playerOptions.Config;
					bool flag19 = config5 == null;
					config5._003CSelectedReapers_003Ek__BackingField = false;
					GameManager core6 = GM.Core;
					bool flag20 = (object)GM.Core == null;
					bool flag21 = core6._playerOptions == null;
					PlayerOptionsData config6 = core6._playerOptions.Config;
					bool flag22 = config6 == null;
					config6._003CSelectedRandomEvents_003Ek__BackingField = false;
					GameManager core7 = GM.Core;
					bool flag23 = (object)GM.Core == null;
					bool flag24 = core7._playerOptions == null;
					PlayerOptionsData config7 = core7._playerOptions.Config;
					bool flag25 = config7 == null;
					if (config7._003CSelectedGoldenEggs_003Ek__BackingField)
					{
						GameManager core8 = GM.Core;
						bool flag26 = (object)GM.Core == null;
						bool flag27 = core8._eggManager == null;
						float num = core8._eggManager.RemoveBonuses();
					}
					MakeFireEmitters();
					MakeWindows();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void OnInitCompleted()
	{
		base.OnInitCompleted();
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		if (stage._spawnTimer != null)
		{
			stage._spawnTimer.Cancel();
		}
	}

	private void SnapEggs()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			float num = core2._eggManager.RemoveBonuses();
		}
	}

	private unsafe void MakeFireEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0862: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected O, but got Unknown
		//IL_01f5: Expected O, but got I4
		//IL_0225: Expected O, but got Ref
		//IL_0243: Expected native int or pointer, but got O
		//IL_025d: Expected O, but got I
		//IL_028b: Expected O, but got I4
		//IL_02a4: Expected O, but got Ref
		//IL_02be: Expected native int or pointer, but got O
		//IL_0896: Expected O, but got I4
		//IL_02d6: Expected O, but got Ref
		//IL_02f0: Expected native int or pointer, but got O
		//IL_08c8: Expected O, but got I
		//IL_0328: Expected O, but got Ref
		//IL_0342: Expected native int or pointer, but got O
		//IL_0902: Expected O, but got I
		//IL_0393: Expected O, but got I
		//IL_0938: Expected O, but got I
		//IL_0a87: Expected O, but got Ref
		//IL_0576: Expected O, but got I4
		//IL_05c4: Expected O, but got Ref
		//IL_05e2: Expected native int or pointer, but got O
		//IL_05fc: Expected O, but got I
		//IL_062a: Expected O, but got I4
		//IL_0643: Expected O, but got Ref
		//IL_065d: Expected native int or pointer, but got O
		//IL_099d: Expected O, but got I
		//IL_0695: Expected O, but got Ref
		//IL_06af: Expected native int or pointer, but got O
		//IL_06bd: Expected O, but got I4
		//IL_09c5: Expected O, but got I4
		//IL_06ea: Expected O, but got Ref
		//IL_0704: Expected native int or pointer, but got O
		//IL_0a0c: Expected O, but got I
		//IL_075b: Expected O, but got I
		//IL_0782: Expected O, but got I
		//IL_07a3: Expected O, but got I
		//IL_0a42: Expected O, but got I
		//IL_0abc: Expected O, but got Ref
		//IL_0821: Expected I4, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundBazaar)+40]");
		object obj4 = default(object);
		object obj3 = obj4 - 0;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PfxEmitter");
		Transform transform = gameObject.transform;
		transform.SetParent(_spritesRootTransform, worldPositionStays: false);
		ParticleEmitterManager pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("shop");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"colours9");
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
			((List<object>)(object)list).AddWithResize((object)"colours10");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		float constant = (float)obj3 - 3.36f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, renderer.width));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(5000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, -300f));
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem pfxFire = _pfxEmitter.CreateEmitter(particleSystemConfig, null, "PfxFire1");
		_pfxFire1 = pfxFire;
		_ = _pfxFire1;
		_ = _pfxFire1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1645 @ rax_v54 (should have been resolved before IL gen)");
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("shop");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"colours9");
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
			((List<object>)(object)list2).AddWithResize((object)"colours10");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		float constant2 = (float)obj3 - 3.36f;
		minMaxCurve = new ParticleSystem.MinMaxCurve(constant2);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, renderer2.width));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(5000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(-100f, -300f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
			particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
			_ = 0;
			obj = 1;
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 2f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+140]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
			particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 1133903872;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
			particleSystemConfig2._blendMode = (BlendMode?)(object)0;
			ParticleSystem pfxFire2 = _pfxEmitter.CreateEmitter(particleSystemConfig2, null, "PfxFire2");
			_pfxFire2 = pfxFire2;
			_ = _pfxFire2;
			_ = _pfxFire2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj7 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 440));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2554 @ rax_v94 (should have been resolved before IL gen)");
			ParticleEmitterManager particleEmitterManager = _pfxEmitter.SetDepth(-5000);
			RenderingExtensions.Start(_pfxFire1);
			RenderingExtensions.Start(_pfxFire2);
			return;
		}
		throw new NullReferenceException();
	}

	private void MakeWindows()
	{
		//IL_027f: Invalid comparison between F4 and I4
		//IL_029f: Expected O, but got I4
		//IL_053b: Invalid comparison between F4 and I4
		//IL_04e2: Expected O, but got I4
		//IL_04fe: Expected O, but got I4
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_048b: Invalid comparison between F4 and O
		//IL_03a5: Expected O, but got I4
		//IL_03c0: Expected I4, but got I8
		//IL_03dc: Expected O, but got I4
		//IL_040b: Expected O, but got I
		//IL_0443: Expected O, but got I4
		//IL_044b: Invalid comparison between F4 and O
		//IL_045b: Expected O, but got I4
		//IL_0464: Expected F4, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width / 1.28f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num2 = num + 1f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num3 = renderer2.height / 3.58f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num4 = num3 + 1f;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"window2.png");
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
			((List<object>)(object)list).AddWithResize((object)"window4.png");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		List<object> items3 = (List<object>)(object)list._items;
		if (list._size >= items3._size)
		{
			((List<object>)(object)list).AddWithResize((object)"window5.png");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		if (num2 > 0f)
		{
			float? num5 = (float?)(object)0;
			Vector2 pos = default(Vector2);
			IntPtr intPtr = default(IntPtr);
			object arg = default(object);
			do
			{
				if (num4 > 0f)
				{
					bool flag3;
					do
					{
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(this, pos, "shop", "window2");
						PhaserSprite phaserSprite2 = phaserSprite.setTint(0u);
						string spriteName = Extensions.PickRnd(list);
						PhaserSprite phaserSprite3 = phaserSprite2.setFrame(spriteName, "shop");
						float value = UnityEngine.Random.value;
						bool flag = value < 0.5f;
						bool flipX = !flag;
						PhaserSprite phaserSprite4 = phaserSprite3.setFlipX(flipX);
						float value2 = UnityEngine.Random.value;
						bool flag2 = value2 < 0.5f;
						bool flipY = !flag2;
						PhaserSprite phaserSprite5 = phaserSprite4.setFlipY(flipY);
						PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
						PhaserSprite phaserSprite7 = phaserSprite6.setScale(-0.1f, (float?)(object)1);
						PhaserSprite phaserSprite8 = phaserSprite7.setDepth(-4900);
						PhaserSprite phaserSprite9 = phaserSprite8.setOrigin(0f, (float?)(object)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						string text = $"Window[{(nint)intPtr}][{arg}]";
						object obj = phaserSprite9.setName(text);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
						float? num6 = (float?)(object)(0 + 1);
						flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num6);
						float? num7 = (float?)(object)0;
						float num8 = 0f;
					}
					while (flag3);
				}
				num5 = (float?)(object)((_003F?)num5 + 1);
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num5));
		}
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = _windows.ToArray();
		tweenConfig.targets = targets;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 1000f;
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public BackgroundBazaar()
	{
		List<PhaserSprite> windows = new List<PhaserSprite>();
		_windows = windows;
		base._002Ector();
	}
}
