using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundWhiteout : BackgroundManager
{
	private ParticleSystem _pfxSnowEmitter;

	public override void Awake()
	{
		base.Awake();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		ParticleSystem pfxSnowEmitter = _pfxSnowEmitter;
		if ((object)_pfxSnowEmitter != null && ((UnityEngine.Object)pfxSnowEmitter).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _pfxSnowEmitter.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
	}

	public override void Create()
	{
		base.Create();
		GenerateParticleSystems();
		_pfxSnowEmitter.Play(withChildren: true);
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_0099: Expected native int or pointer, but got O
		//IL_0149: Expected F4, but got I4
		//IL_01d3: Expected F4, but got I4
		//IL_0203: Invalid comparison between F4 and I4
		//IL_0212: Expected O, but got I4
		//IL_0223: Expected F4, but got I4
		//IL_04b8: Expected O, but got Ref
		//IL_04d2: Expected native int or pointer, but got O
		//IL_04ec: Expected O, but got I
		//IL_050c: Expected O, but got Ref
		//IL_0526: Expected native int or pointer, but got O
		//IL_0821: Expected O, but got I4
		//IL_098c: Expected O, but got I
		//IL_053e: Expected O, but got Ref
		//IL_0565: Expected O, but got I
		//IL_057f: Expected native int or pointer, but got O
		//IL_0853: Expected O, but got I
		//IL_05b7: Expected O, but got Ref
		//IL_05d1: Expected native int or pointer, but got O
		//IL_088d: Expected O, but got I
		//IL_0379: Expected O, but got Ref
		//IL_03c1: Expected native int or pointer, but got O
		//IL_03d4: Expected O, but got I4
		//IL_0651: Expected O, but got I
		//IL_0678: Expected O, but got I
		//IL_0698: Expected O, but got I
		//IL_0917: Expected O, but got I
		//IL_09ac: Expected O, but got Ref
		//IL_094f: Expected O, but got I
		//IL_075c->IL099e: Incompatible stack heights: 2 vs 1
		//IL_0795->IL09d1: Incompatible stack heights: 3 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		PhaserScene phaserScene = base.scene;
		Line line;
		float num;
		if (phaserScene != null)
		{
			PhaserScene.Renderer renderer = phaserScene._renderer;
			if (phaserScene._renderer != null)
			{
				line = null;
				ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
				line._x2 = renderer.screenWidth;
				line._x1 = 0f;
				line._y1 = 120f;
				line._y2 = 120f;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null)
					{
						if (!config._003CSelectedInverse_003Ek__BackingField)
						{
							num = 0f;
							goto IL_07cf;
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._playerOptions != null)
						{
							PlayerOptionsData config2 = core2._playerOptions.Config;
							if (config2 != null)
							{
								num = (config2._003CVisuallyInvertStages_003Ek__BackingField ? 1 : 0);
								goto IL_07cf;
							}
						}
					}
				}
			}
		}
		goto IL_0795;
		IL_07cf:
		PhaserScene phaserScene2 = base.scene;
		Line source;
		if (phaserScene2 != null && phaserScene2._renderer != null)
		{
			bool flag = num == 0f;
			object obj3 = 16777215;
			source = line;
			float num2 = 0f;
			float num3 = 180f;
			if (flag)
			{
				goto IL_07f6;
			}
			PhaserScene phaserScene3 = base.scene;
			if (phaserScene3 != null)
			{
				PhaserScene.Renderer renderer2 = phaserScene3._renderer;
				if (phaserScene3._renderer != null)
				{
					PhaserScene phaserScene4 = base.scene;
					if (phaserScene4 != null)
					{
						PhaserScene.Renderer renderer3 = phaserScene4._renderer;
						if (phaserScene4._renderer != null)
						{
							PhaserScene phaserScene5 = base.scene;
							if (phaserScene5 != null)
							{
								PhaserScene.Renderer renderer4 = phaserScene5._renderer;
								if (phaserScene5._renderer != null)
								{
									Line line2 = null;
									float y = renderer2.screenHeight - 120f;
									float y2 = renderer4.screenHeight - 120f;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
									line2._x2 = renderer3.screenWidth;
									line2._y1 = y;
									line2._y2 = y2;
									line2._x1 = 0f;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(180f, 360f));
									obj3 = 16732497;
									source = line2;
									num2 = 180f;
									num3 = 360f;
									goto IL_07f6;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0795;
		IL_0795:
		throw new NullReferenceException();
		IL_07f6:
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur3");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1000f, 5000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 150f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 100;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.1f, 0.05f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = source;
		Vector3? overrideRotation = default(Vector3?);
		emitZone._overrideRotation = overrideRotation;
		particleSystemConfig._emitZone = emitZone;
		_ = 0;
		_ = 1120403456;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = true;
		Camera main = Camera.main;
		Transform parent = main.transform;
		ParticleSystem pfxSnowEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "PfxSnowEmitter - BackgroundWhiteout");
		_pfxSnowEmitter = pfxSnowEmitter;
		Transform transform = _pfxSnowEmitter.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3? value = default(Vector3?);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		RenderingExtensions.SetDepth(_pfxSnowEmitter, 2000);
		_ = _pfxSnowEmitter;
		_ = _pfxSnowEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag3 = obj4 == null;
		}
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1986 @ rax_v71 (should have been resolved before IL gen)");
		bool flag4 = (object)_pfxSnowEmitter == null;
		_ = _pfxSnowEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC0]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag5 = obj6 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2073 @ rax_v76 (should have been resolved before IL gen)");
	}
}
