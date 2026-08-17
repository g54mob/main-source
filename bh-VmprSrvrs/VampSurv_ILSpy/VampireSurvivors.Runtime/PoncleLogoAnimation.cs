using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.UI;

public class PoncleLogoAnimation : MonoBehaviour
{
	private ParticleEmitterManager _backParticles;

	private ParticleEmitterManager _frontParticles;

	private UISpriteAnimation _LogoAnim;

	private void Start()
	{
		AddBackParticles();
		AddFrontParticles();
	}

	private void Update()
	{
	}

	private unsafe void AddBackParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04fc: Expected O, but got I
		//IL_076d: Expected O, but got Ref
		//IL_0787: Expected O, but got I
		//IL_0546: Expected O, but got Ref
		//IL_056c: Expected O, but got Ref
		//IL_057a: Expected O, but got Ref
		//IL_0188: Expected O, but got Ref
		//IL_0196: Expected O, but got Ref
		//IL_01d0: Expected O, but got Ref
		//IL_01de: Expected O, but got Ref
		//IL_0221: Expected O, but got I4
		//IL_024c: Expected O, but got Ref
		//IL_0264: Expected O, but got Ref
		//IL_05da: Expected O, but got I
		//IL_07bd: Expected O, but got Ref
		//IL_07d7: Expected O, but got I
		//IL_0624: Expected O, but got Ref
		//IL_0814: Expected O, but got I
		//IL_0655: Expected O, but got Ref
		//IL_066f: Expected O, but got I
		//IL_084a: Expected O, but got Ref
		//IL_0870: Expected O, but got Ref
		//IL_087e: Expected O, but got Ref
		//IL_0385: Expected O, but got Ref
		//IL_0393: Expected O, but got Ref
		//IL_03ba: Expected O, but got Ref
		//IL_03d4: Expected native int or pointer, but got O
		//IL_03ec: Expected O, but got Ref
		//IL_03fa: Expected O, but got Ref
		//IL_0704: Expected O, but got Ref
		//IL_0724: Expected native int or pointer, but got O
		//IL_0737: Expected O, but got Ref
		//IL_075e: Expected O, but got Ref
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
			((List<object>)(object)list).AddWithResize((object)"PfxLine");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		Transform transform = _backParticles.transform;
		Transform parent = default(Transform);
		string psName = default(string);
		bool isAdditive = default(bool);
		bool requiresMasking = default(bool);
		ParticleSystem particleSystem = _backParticles.CreateUIEmitter(particleSystemConfig, "UI", 11002, parent, psName, isAdditive, requiresMasking);
		particleSystem.Play(withChildren: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9A8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9A8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v687 @ rax_v40 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B908]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B908]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v716 @ rax_v43 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0.02f);
		ParticleSystem.MinMaxCurve startSizeX = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startSizeX = startSizeX;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.001f);
		ParticleSystem.MinMaxCurve startSizeY = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startSizeY = startSizeY;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.001f);
		ParticleSystem.MinMaxCurve startSizeZ = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule3)->startSizeZ = startSizeZ;
		Color color = ColourHelper.HexToColor("002b0c");
		Color color2 = ColourHelper.HexToColor("092611");
		obj = 2;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxGradient startColor = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		_ = color.r;
		ParticleSystem.MainModule mainModule4 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = color2.r;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		_ = 0;
		_ = color2.r;
		((ParticleSystem.MainModule*)mainModule4)->startColor = startColor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj7 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1339 @ rax_v60 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj9 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
		}
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1371 @ rax_v63 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCC8]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCC8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj11 == null)
			{
				MissingMethodException ex5 = new MissingMethodException();
				throw ex5;
			}
		}
		object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1462 @ rax_v68 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCD0]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj13 == null)
			{
				MissingMethodException ex6 = new MissingMethodException();
				throw ex6;
			}
		}
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1488 @ rax_v71 (should have been resolved before IL gen)");
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.MinMaxCurve strengthX = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		ParticleSystem.NoiseModule noiseModule = (ParticleSystem.NoiseModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 0;
		((ParticleSystem.NoiseModule*)noiseModule)->strengthX = strengthX;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.MinMaxCurve strengthZ = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		ParticleSystem.NoiseModule noiseModule2 = (ParticleSystem.NoiseModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 0;
		((ParticleSystem.NoiseModule*)noiseModule2)->strengthZ = strengthZ;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-0.03f, 0.03f));
		ParticleSystem.MinMaxCurve strengthY = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		ParticleSystem.NoiseModule noiseModule3 = (ParticleSystem.NoiseModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
		_ = 0;
		((ParticleSystem.NoiseModule*)noiseModule3)->strengthY = strengthY;
		Gradient gradient = new Gradient();
		IntPtr ptr = Gradient.Init();
		gradient.m_Ptr = ptr;
		gradient.m_RequiresNativeCleanup = true;
		GradientAlphaKey[] alphaKeys = new GradientAlphaKey[4];
		_ = 0;
		_ = 1065353216;
		_ = 1048576000;
		_ = 1065353216;
		_ = 1061158912;
		_ = 0;
		_ = 1065353216;
		gradient.alphaKeys = alphaKeys;
		GradientColorKey[] colorKeys = new GradientColorKey[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_ = 0;
		gradient.colorKeys = colorKeys;
		ParticleSystem.MinMaxGradient minMaxGradient = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxGradient, new ParticleSystem.MinMaxGradient(gradient));
		ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		((ParticleSystem.ColorOverLifetimeModule*)colorOverLifetimeModule)->color = (ParticleSystem.MinMaxGradient)(&minMaxCurve);
	}

	private unsafe void AddFrontParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0535: Expected O, but got I
		//IL_07d7: Expected O, but got Ref
		//IL_07f1: Expected O, but got I
		//IL_057f: Expected O, but got Ref
		//IL_05a5: Expected O, but got Ref
		//IL_05b3: Expected O, but got Ref
		//IL_0188: Expected O, but got Ref
		//IL_0196: Expected O, but got Ref
		//IL_01d0: Expected O, but got Ref
		//IL_01de: Expected O, but got Ref
		//IL_022d: Expected O, but got I4
		//IL_024c: Expected O, but got Ref
		//IL_0264: Expected O, but got Ref
		//IL_0613: Expected O, but got I
		//IL_0827: Expected O, but got Ref
		//IL_0841: Expected O, but got I
		//IL_065d: Expected O, but got Ref
		//IL_088a: Expected O, but got Ref
		//IL_0898: Expected O, but got Ref
		//IL_08c1: Expected O, but got I
		//IL_068e: Expected O, but got Ref
		//IL_08fe: Expected O, but got I
		//IL_06bf: Expected O, but got Ref
		//IL_06d9: Expected O, but got I
		//IL_0934: Expected O, but got Ref
		//IL_095a: Expected O, but got Ref
		//IL_0968: Expected O, but got Ref
		//IL_03be: Expected O, but got Ref
		//IL_03cc: Expected O, but got Ref
		//IL_03f3: Expected O, but got Ref
		//IL_040d: Expected native int or pointer, but got O
		//IL_0425: Expected O, but got Ref
		//IL_0433: Expected O, but got Ref
		//IL_076e: Expected O, but got Ref
		//IL_078e: Expected native int or pointer, but got O
		//IL_07a1: Expected O, but got Ref
		//IL_07c8: Expected O, but got Ref
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
			((List<object>)(object)list).AddWithResize((object)"PfxLine");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		Transform transform = _frontParticles.transform;
		Transform parent = default(Transform);
		string psName = default(string);
		bool isAdditive = default(bool);
		bool requiresMasking = default(bool);
		ParticleSystem particleSystem = _frontParticles.CreateUIEmitter(particleSystemConfig, "UI", 11004, parent, psName, isAdditive, requiresMasking);
		particleSystem.Play(withChildren: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9A8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9A8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v687 @ rax_v43 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B908]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B908]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v716 @ rax_v46 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0.02f);
		ParticleSystem.MinMaxCurve startSizeX = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startSizeX = startSizeX;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.001f);
		ParticleSystem.MinMaxCurve startSizeY = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startSizeY = startSizeY;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.001f);
		ParticleSystem.MinMaxCurve startSizeZ = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule3)->startSizeZ = startSizeZ;
		Color color = ColourHelper.HexToColor("189116");
		Color color2 = ColourHelper.HexToColor("3b9c3a");
		_ = 2;
		_ = 0;
		obj = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxGradient startColor = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		_ = color.r;
		ParticleSystem.MainModule mainModule4 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = color2.r;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		_ = 0;
		_ = color2.r;
		((ParticleSystem.MainModule*)mainModule4)->startColor = startColor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj7 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1221 @ rax_v63 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj9 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
		}
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1369 @ rax_v66 (should have been resolved before IL gen)");
		minMaxCurve = new ParticleSystem.MinMaxCurve(5f);
		ParticleSystem.MinMaxCurve rateOverTime = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = rateOverTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA78]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA78]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj11 == null)
			{
				MissingMethodException ex5 = new MissingMethodException();
				throw ex5;
			}
		}
		object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1534 @ rax_v73 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCC8]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCC8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj13 == null)
			{
				MissingMethodException ex6 = new MissingMethodException();
				throw ex6;
			}
		}
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1625 @ rax_v78 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCD0]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj15 == null)
			{
				MissingMethodException ex7 = new MissingMethodException();
				throw ex7;
			}
		}
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1651 @ rax_v81 (should have been resolved before IL gen)");
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.MinMaxCurve strengthX = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.NoiseModule noiseModule = (ParticleSystem.NoiseModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		((ParticleSystem.NoiseModule*)noiseModule)->strengthX = strengthX;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.MinMaxCurve strengthZ = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.NoiseModule noiseModule2 = (ParticleSystem.NoiseModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		((ParticleSystem.NoiseModule*)noiseModule2)->strengthZ = strengthZ;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-0.03f, 0.03f));
		ParticleSystem.MinMaxCurve strengthY = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		ParticleSystem.NoiseModule noiseModule3 = (ParticleSystem.NoiseModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		((ParticleSystem.NoiseModule*)noiseModule3)->strengthY = strengthY;
		Gradient gradient = new Gradient();
		IntPtr ptr = Gradient.Init();
		gradient.m_Ptr = ptr;
		gradient.m_RequiresNativeCleanup = true;
		GradientAlphaKey[] alphaKeys = new GradientAlphaKey[4];
		_ = 0;
		_ = 1065353216;
		_ = 1048576000;
		_ = 1065353216;
		_ = 1061158912;
		_ = 0;
		_ = 1065353216;
		gradient.alphaKeys = alphaKeys;
		GradientColorKey[] colorKeys = new GradientColorKey[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_ = 0;
		gradient.colorKeys = colorKeys;
		ParticleSystem.MinMaxGradient minMaxGradient = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxGradient, new ParticleSystem.MinMaxGradient(gradient));
		ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		((ParticleSystem.ColorOverLifetimeModule*)colorOverLifetimeModule)->color = (ParticleSystem.MinMaxGradient)(&minMaxCurve);
	}

	public PoncleLogoAnimation()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
