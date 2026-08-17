using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.Tools;

public static class RenderingExtensions
{
	private static ParticleSystem.Particle[] _cachedParticles;

	private static readonly int ApplyTint;

	private static readonly int TintColor;

	private static readonly int ApplyTintFill;

	private static readonly int TintFillColor;

	private static Dictionary<int, Sprite> s_circleCache;

	private static Shader s_atlasRectTrailShader;

	private static Shader s_atlasRectTrailAdditiveShader;

	private static int s_atlasRectTrailRectPropertyID;

	public unsafe static T SetAngle<T>(T component, float angle, bool phaserSpace = true) where T : Component
	{
		//IL_004b: Expected O, but got Ref
		if (phaserSpace || (object)component != null)
		{
			Transform transform = component.transform;
			if ((object)transform != null)
			{
				object obj = default(object);
				transform.localEulerAngles = (Vector3)(&obj);
				return component;
			}
		}
		return (T)(object)new NullReferenceException();
	}

	public static T SetScale<T>(T component, float scale) where T : Component
	{
		//IL_003f: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 61 Invalid \"Jump target not found in method: 0x183116430\"");
		return (T)0;
	}

	public static T SetScale<T>(T component, float xScale, float yScale) where T : Component
	{
		if ((object)component != null)
		{
			Transform transform = component.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return component;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static void SetAlpha(Image image, float alpha)
	{
		//IL_001a: Expected O, but got Ref
		Color color = image.color;
		object obj = default(object);
		image.color = (Color)(&obj);
	}

	public unsafe static TrailRenderer SetAlpha(TrailRenderer trail, float alpha)
	{
		//IL_00ca: Expected O, but got Ref
		if ((object)trail != null)
		{
			Material material = ((Renderer)trail).GetMaterial();
			if ((object)material != null)
			{
				int firstPropertyNameIdByAttribute = material.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
				int nameID = ((firstPropertyNameIdByAttribute < 0) ? Material.k_ColorId : firstPropertyNameIdByAttribute);
				Color color = material.GetColor(nameID);
				object obj = default(object);
				material.color = (Color)(&obj);
				return trail;
			}
		}
		return (TrailRenderer)(object)new NullReferenceException();
	}

	public unsafe static TrailRenderer SetTint(TrailRenderer trail, uint tint)
	{
		//IL_00e8: Expected O, but got Ref
		if ((object)trail != null)
		{
			Material material = ((Renderer)trail).GetMaterial();
			if ((object)material != null)
			{
				int firstPropertyNameIdByAttribute = material.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
				int nameID = ((firstPropertyNameIdByAttribute < 0) ? Material.k_ColorId : firstPropertyNameIdByAttribute);
				Color color = material.GetColor(nameID);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
				object obj = default(object);
				material.color = (Color)(&obj);
				return trail;
			}
		}
		return (TrailRenderer)(object)new NullReferenceException();
	}

	public unsafe static string ToHex(Color color)
	{
		//IL_002a: Expected I, but got O
		//IL_008f: Expected I, but got O
		//IL_00f4: Expected I, but got O
		//IL_01ab: Expected O, but got Ref
		//IL_0159: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
		object[] array = new object[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj = default(object);
		if (obj != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj3 = default(object);
		if (obj3 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj5 = default(object);
		if (obj5 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj7 = default(object);
		if (obj7 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj9 = default(object);
		return string.FormatHelper((IFormatProvider)null, "{0:X2}{1:X2}{2:X2}{3:X2}", (System.ParamsArray)(&obj9));
	}

	public static void SetTintEnabled(MaterialPropertyBlock propBlock, bool isEnabled)
	{
		bool flag = propBlock.m_Ptr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 61 ConditionalJump @-1, v69 @ ZF_v6 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe static void SetTintColor(MaterialPropertyBlock propBlock, Color tintColor)
	{
		bool flag = propBlock.m_Ptr == (IntPtr)0;
		float value = default(float);
		MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, TintColor, ref *(Color*)(&value));
	}

	public unsafe static void SetTintColor(Material material, Color tintColor)
	{
		bool flag = ((UnityEngine.Object)material).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Material.SetColorImpl_Injected(((UnityEngine.Object)material).m_CachedPtr, TintColor, ref *(Color*)(&value));
	}

	public static void SetTintFillEnabled(MaterialPropertyBlock propBlock, bool isEnabled)
	{
		bool flag = propBlock.m_Ptr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 61 ConditionalJump @-1, v69 @ ZF_v6 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public static void SetTintFillEnabled(Material material, bool isEnabled)
	{
		//IL_0017: Expected F4, but got I4
		material.SetFloatImpl(ApplyTintFill, (float)(isEnabled ? 1 : 0));
	}

	public unsafe static void SetTintFillColor(MaterialPropertyBlock propBlock, Color tintColor)
	{
		bool flag = propBlock.m_Ptr == (IntPtr)0;
		float value = default(float);
		MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, TintFillColor, ref *(Color*)(&value));
	}

	public unsafe static void SetTintFillColor(Material material, Color tintColor)
	{
		bool flag = ((UnityEngine.Object)material).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Material.SetColorImpl_Injected(((UnityEngine.Object)material).m_CachedPtr, TintFillColor, ref *(Color*)(&value));
	}

	public static ParticleEmitterManager particles(Factory behaviour, string texture = null)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "ParticleEmitterManager");
		if ((object)gameObject != null)
		{
			return gameObject.AddComponent<ParticleEmitterManager>();
		}
		return (ParticleEmitterManager)(object)new NullReferenceException();
	}

	public static ParticleSystem SetAngle(ParticleSystem component, ParticleSystem.MinMaxCurve angle, int angleSteps = 0)
	{
		//IL_0015: Expected O, but got I
		//IL_00ed: Expected O, but got I
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_02a6: Expected O, but got I
		//IL_0315: Expected O, but got I
		//IL_0432: Expected O, but got I
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_01cd: Expected O, but got I
		//IL_03ba: Expected O, but got I
		ParticleSystem.MinMaxCurve minMaxCurve = default(ParticleSystem.MinMaxCurve);
		if (minMaxCurve.m_Mode == ParticleSystemCurveMode.Constant)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v175 @ rax_v49 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v331 @ rax_v52 (should have been resolved before IL gen)");
		}
		else if (minMaxCurve.m_Mode == ParticleSystemCurveMode.TwoConstants)
		{
			float num = minMaxCurve.m_ConstantMax - minMaxCurve.m_ConstantMin;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj4 = num & 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v345 @ rax_v29 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj5 == null)
				{
					MissingMethodException ex4 = new MissingMethodException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v454 @ rax_v32 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			object obj6 = 0;
			float constantMin = minMaxCurve.m_ConstantMin;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj7 = constantMin ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj6 == null)
				{
					MissingMethodException ex5 = new MissingMethodException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v559 @ rax_v35 (should have been resolved before IL gen)");
			int num2 = default(int);
			if (num2 >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				object obj8 = 0;
				float num3 = 1f / (float)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj8 == null)
					{
						MissingMethodException ex6 = new MissingMethodException();
						throw ex6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v666 @ rax_v38 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj9 == null)
					{
						MissingMethodException ex7 = new MissingMethodException();
						throw ex7;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v706 @ rax_v41 (should have been resolved before IL gen)");
			}
		}
		return component;
	}

	public unsafe static ParticleSystem SetTint(ParticleSystem component, uint tint)
	{
		//IL_0017: Expected O, but got Ref
		if ((object)component != null)
		{
			ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
			ParticleSystem.MinMaxGradient startColor = mainModule.startColor;
			object obj = default(object);
			mainModule.startColor = (ParticleSystem.MinMaxGradient)(&obj);
			return component;
		}
		return (ParticleSystem)(object)new NullReferenceException();
	}

	public unsafe static ParticleSystem SetTint(ParticleSystem component, uint startTint, uint endTint)
	{
		//IL_0008: Expected O, but got Ref
		//IL_010a: Expected O, but got Ref
		//IL_0093: Expected O, but got Ref
		//IL_00a1: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)component != null)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			ParticleSystem.MinMaxGradient color = ((ParticleSystem.ColorOverLifetimeModule*)colorOverLifetimeModule)->color;
			_ = color.m_GradientMax;
			_ = 0;
			int num = (int)startTint >> 16;
			int num2 = (int)startTint >> 8;
			_ = 255;
			_ = 0;
			int num3 = (int)endTint >> 16;
			int num4 = (int)endTint >> 8;
			_ = 255;
			ParticleSystem.MinMaxGradient color2 = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule2 = (ParticleSystem.ColorOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			_ = color.m_Mode;
			((ParticleSystem.ColorOverLifetimeModule*)colorOverLifetimeModule2)->color = color2;
			return component;
		}
		return (ParticleSystem)(object)new NullReferenceException();
	}

	private static Color32 HexToColor(uint hexVal)
	{
		//IL_0013: Expected O, but got I4
		int num = (int)hexVal >> 16;
		return (Color32)num;
	}

	public unsafe static ParticleSystem SetGravity(ParticleSystem component, ParticleSystem.MinMaxCurve gravity)
	{
		//IL_009e: Expected native int or pointer, but got O
		//IL_0064: Expected native int or pointer, but got O
		//IL_00d2: Expected O, but got Ref
		if (gravity.m_Mode != ParticleSystemCurveMode.Constant)
		{
			if (gravity.m_Mode != ParticleSystemCurveMode.TwoConstants)
			{
				goto IL_00a8;
			}
			float constantMin = gravity.m_ConstantMin * 0.001f;
			((ParticleSystem.MinMaxCurve*)(nint)gravity)->m_ConstantMin = constantMin;
		}
		float constantMax = gravity.m_ConstantMax * 0.001f;
		((ParticleSystem.MinMaxCurve*)(nint)gravity)->m_ConstantMax = constantMax;
		goto IL_00a8;
		IL_00a8:
		if ((object)component == null)
		{
			return (ParticleSystem)(object)new NullReferenceException();
		}
		ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
		object obj = default(object);
		mainModule.gravityModifier = (ParticleSystem.MinMaxCurve)(&obj);
		return component;
	}

	public unsafe static ParticleSystem SetScale(ParticleSystem component, float scale)
	{
		//IL_0055: Expected O, but got I
		//IL_009e: Expected F4, but got I
		//IL_00a2: Expected O, but got I4
		//IL_00d7: Expected F4, but got I
		//IL_00db: Expected O, but got I4
		//IL_00fa: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v129 @ rax_v17 (should have been resolved before IL gen)");
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr intPtr = (animationCurve.m_Ptr = AnimationCurve.Internal_Create((Keyframe[])null));
		animationCurve.m_RequiresNativeCleanup = true;
		bool flag = intPtr == (IntPtr)0;
		IntPtr intPtr2 = default(IntPtr);
		object obj2 = AnimationCurve.AddKey_Injected(intPtr, 0f, (float)(nint)intPtr2);
		bool flag2 = animationCurve.m_Ptr == (IntPtr)0;
		object obj3 = AnimationCurve.AddKey_Injected(animationCurve.m_Ptr, 0f, (float)(nint)intPtr2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1f, animationCurve);
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
		object obj4 = default(object);
		sizeOverLifetimeModule.size = (ParticleSystem.MinMaxCurve)(&obj4);
		return component;
	}

	public unsafe static void SetScale(ParticleSystem pfx, ParticleSystem.MinMaxCurve scale)
	{
		//IL_0055: Expected O, but got I
		//IL_009e: Expected F4, but got I
		//IL_00a2: Expected O, but got I4
		//IL_00d7: Expected F4, but got I
		//IL_00db: Expected O, but got I4
		//IL_00fa: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v129 @ rax_v16 (should have been resolved before IL gen)");
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr intPtr = (animationCurve.m_Ptr = AnimationCurve.Internal_Create((Keyframe[])null));
		animationCurve.m_RequiresNativeCleanup = true;
		bool flag = intPtr == (IntPtr)0;
		IntPtr intPtr2 = default(IntPtr);
		object obj2 = AnimationCurve.AddKey_Injected(intPtr, 0f, (float)(nint)intPtr2);
		bool flag2 = animationCurve.m_Ptr == (IntPtr)0;
		object obj3 = AnimationCurve.AddKey_Injected(animationCurve.m_Ptr, 0f, (float)(nint)intPtr2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1f, animationCurve);
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
		object obj4 = default(object);
		sizeOverLifetimeModule.size = (ParticleSystem.MinMaxCurve)(&obj4);
	}

	public unsafe static void SetScaleX(ParticleSystem pfx, ParticleSystem.MinMaxCurve scale)
	{
		//IL_0055: Expected O, but got I
		//IL_009e: Expected F4, but got I
		//IL_00a2: Expected O, but got I4
		//IL_00d7: Expected F4, but got I
		//IL_00db: Expected O, but got I4
		//IL_00fa: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v129 @ rax_v16 (should have been resolved before IL gen)");
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr intPtr = (animationCurve.m_Ptr = AnimationCurve.Internal_Create((Keyframe[])null));
		animationCurve.m_RequiresNativeCleanup = true;
		bool flag = intPtr == (IntPtr)0;
		IntPtr intPtr2 = default(IntPtr);
		object obj2 = AnimationCurve.AddKey_Injected(intPtr, 0f, (float)(nint)intPtr2);
		bool flag2 = animationCurve.m_Ptr == (IntPtr)0;
		object obj3 = AnimationCurve.AddKey_Injected(animationCurve.m_Ptr, 0f, (float)(nint)intPtr2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1f, animationCurve);
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
		object obj4 = default(object);
		sizeOverLifetimeModule.x = (ParticleSystem.MinMaxCurve)(&obj4);
	}

	public unsafe static void SetScaleY(ParticleSystem pfx, ParticleSystem.MinMaxCurve scale)
	{
		//IL_0055: Expected O, but got I
		//IL_009e: Expected F4, but got I
		//IL_00a2: Expected O, but got I4
		//IL_00d7: Expected F4, but got I
		//IL_00db: Expected O, but got I4
		//IL_00fa: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v129 @ rax_v16 (should have been resolved before IL gen)");
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr intPtr = (animationCurve.m_Ptr = AnimationCurve.Internal_Create((Keyframe[])null));
		animationCurve.m_RequiresNativeCleanup = true;
		bool flag = intPtr == (IntPtr)0;
		IntPtr intPtr2 = default(IntPtr);
		object obj2 = AnimationCurve.AddKey_Injected(intPtr, 0f, (float)(nint)intPtr2);
		bool flag2 = animationCurve.m_Ptr == (IntPtr)0;
		object obj3 = AnimationCurve.AddKey_Injected(animationCurve.m_Ptr, 0f, (float)(nint)intPtr2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1f, animationCurve);
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
		object obj4 = default(object);
		sizeOverLifetimeModule.y = (ParticleSystem.MinMaxCurve)(&obj4);
	}

	public unsafe static void SetEmitZone(ParticleSystem pfx, EmitZone emitZone)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0047: Expected I, but got O
		//IL_004f: Expected I, but got O
		//IL_005f: Expected O, but got I
		//IL_00df: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00d1: Expected O, but got I4
		//IL_094a: Expected O, but got I
		//IL_00fe: Expected I, but got O
		//IL_010c: Expected I, but got O
		//IL_011c: Expected O, but got I
		//IL_126a: Expected O, but got I
		//IL_1858: Expected O, but got I
		//IL_019c: Expected O, but got I4
		//IL_12a4: Expected O, but got Ref
		//IL_12be: Expected O, but got I
		//IL_0158: Expected O, but got I
		//IL_188e: Expected O, but got Ref
		//IL_189c: Expected O, but got Ref
		//IL_18b6: Expected O, but got I
		//IL_1327: Expected O, but got Ref
		//IL_1335: Expected O, but got Ref
		//IL_0613: Expected O, but got I
		//IL_018e: Expected O, but got I4
		//IL_0fde: Expected O, but got Ref
		//IL_0ff8: Expected O, but got I
		//IL_01c1: Expected I, but got O
		//IL_01d1: Expected O, but got I
		//IL_09f2: Expected F4, but got I
		//IL_0a0f: Expected O, but got I
		//IL_16f3: Expected O, but got Ref
		//IL_170d: Expected O, but got I
		//IL_0251: Expected O, but got I4
		//IL_0a85: Expected O, but got I
		//IL_138b: Expected O, but got Ref
		//IL_1399: Expected O, but got Ref
		//IL_106e: Expected O, but got Ref
		//IL_107c: Expected O, but got Ref
		//IL_1096: Expected O, but got I
		//IL_020d: Expected O, but got I
		//IL_0be6: Expected O, but got I
		//IL_13ca: Expected O, but got Ref
		//IL_13f1: Expected F4, but got I4
		//IL_174e: Expected O, but got Ref
		//IL_175c: Expected O, but got Ref
		//IL_146e: Expected O, but got Ref
		//IL_1488: Expected O, but got I
		//IL_14b3: Expected O, but got I
		//IL_14c1: Expected I, but got O
		//IL_1930: Expected O, but got Ref
		//IL_1966: Expected O, but got I
		//IL_1988: Expected O, but got I
		//IL_1991: Expected O, but got I4
		//IL_0243: Expected O, but got I4
		//IL_16d6: Expected O, but got Ref
		//IL_0f17: Expected O, but got Ref
		//IL_0aee: Expected F4, but got I
		//IL_0afe: Expected O, but got I
		//IL_070f: Expected O, but got I
		//IL_0278: Expected O, but got I
		//IL_0c69: Expected O, but got I
		//IL_0c77: Expected I, but got O
		//IL_0b90: Expected O, but got I
		//IL_0b99: Expected O, but got I4
		//IL_1421: Expected O, but got Ref
		//IL_0870: Expected O, but got I
		//IL_10ff: Expected O, but got Ref
		//IL_1126: Expected F4, but got I4
		//IL_0d55: Expected O, but got Ref
		//IL_0d6f: Expected O, but got I
		//IL_11ab: Expected O, but got Ref
		//IL_11c5: Expected O, but got I
		//IL_17ad: Expected O, but got Ref
		//IL_17e3: Expected O, but got I
		//IL_1813: Expected O, but got I4
		//IL_155d: Expected O, but got Ref
		//IL_156b: Expected O, but got Ref
		//IL_1585: Expected O, but got I
		//IL_0778: Expected F4, but got I
		//IL_0788: Expected O, but got I
		//IL_0dd8: Expected O, but got Ref
		//IL_0de6: Expected O, but got Ref
		//IL_115e: Expected O, but got Ref
		//IL_15f7: Expected O, but got I
		//IL_19ad: Expected O, but got Ref
		//IL_19bb: Expected O, but got Ref
		//IL_0350: Expected O, but got I
		//IL_0836: Expected O, but got I4
		//IL_0e34: Expected O, but got Ref
		//IL_0e42: Expected O, but got Ref
		//IL_03f7: Expected O, but got I
		//IL_0560: Expected O, but got I
		//IL_0e87: Expected O, but got Ref
		//IL_0eae: Expected F4, but got I4
		//IL_0f48: Expected O, but got Ref
		//IL_0f62: Expected O, but got I
		//IL_164c: Expected O, but got Ref
		//IL_1682: Expected O, but got I
		//IL_16ba: Expected O, but got I4
		//IL_0460: Expected F4, but got I
		//IL_0470: Expected O, but got I
		//IL_0ede: Expected O, but got Ref
		//IL_0526: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (emitZone == null || emitZone._source == null)
		{
			return;
		}
		BaseGeom source = emitZone._source;
		if (emitZone._source == null)
		{
			return;
		}
		nint num = (nint)typeof(Line);
		nint num2 = (nint)source;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r8_v31 (Il2CppClass<VampireSurvivors.Framework.Geom.Line>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r9_v31 (Il2CppClass<VampireSurvivors.Framework.Geom.BaseGeom>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r8_v31 (Il2CppClass<VampireSurvivors.Framework.Geom.Line>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r9_v31 (Il2CppClass<VampireSurvivors.Framework.Geom.BaseGeom>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v227+FFFFFFF8+v314 @ rax_v89*8]");
			if (0 == (nint)typeof(Line))
			{
				obj5 = 1;
				goto IL_0ce1;
			}
		}
		obj5 = 0;
		goto IL_0ce1;
		IL_0ce1:
		bool flag = obj5 == null;
		BaseGeom baseGeom = null;
		if (!flag)
		{
			baseGeom = emitZone._source;
		}
		object obj8;
		nint num4;
		if (baseGeom == null)
		{
			num4 = (nint)source;
			nint num5 = (nint)typeof(Circle);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rdx_v72 (Il2CppClass<VampireSurvivors.Framework.Geom.Circle>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ r8_v35 (Il2CppClass<VampireSurvivors.Framework.Geom.Line>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rdx_v72 (Il2CppClass<VampireSurvivors.Framework.Geom.Circle>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ r8_v35 (Il2CppClass<VampireSurvivors.Framework.Geom.Line>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v223+FFFFFFF8+v492 @ rax_v137*8]");
				if (0 == (nint)typeof(Circle))
				{
					obj8 = 1;
					goto IL_0d03;
				}
			}
			obj8 = 0;
			goto IL_0d03;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+10]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+18]");
		object obj9;
		if (num7 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+10]");
			if (num8 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+14]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+1C]");
				if (num9 <= 0)
				{
					goto IL_1848;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+14]");
			obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+1C]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+14]");
			if (num10 > 0)
			{
				goto IL_1848;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v92 (VampireSurvivors.Framework.Geom.BaseGeom)+1C]");
		obj9 = 0;
		goto IL_1848;
		IL_0d03:
		bool flag2 = obj8 == null;
		BaseGeom baseGeom2 = null;
		if (!flag2)
		{
			baseGeom2 = emitZone._source;
		}
		object obj12;
		if (baseGeom2 == null)
		{
			nint num11 = (nint)typeof(Rectangle);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v77 (Il2CppClass<VampireSurvivors.Framework.Geom.Rectangle>)+130]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ r8_v35 (Il2CppClass<VampireSurvivors.Framework.Geom.Line>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v77 (Il2CppClass<VampireSurvivors.Framework.Geom.Rectangle>)+130]");
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ r8_v35 (Il2CppClass<VampireSurvivors.Framework.Geom.Line>)+C8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rax_v219+FFFFFFF8+v695 @ rax_v174*8]");
				if (0 == (nint)typeof(Rectangle))
				{
					obj12 = 1;
					goto IL_0d25;
				}
			}
			obj12 = 0;
			goto IL_0d25;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj13 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v764 @ rax_v140 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rsi_v37 (VampireSurvivors.Framework.Geom.BaseGeom)+18]");
		float num13 = 0f * 0.01f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj15 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v928 @ rax_v143 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		object obj17 = 0;
		_ = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj17 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1105 @ rax_v146 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB00]");
		object obj20 = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB00]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj20 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
		}
		object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1413 @ rax_v149 (should have been resolved before IL gen)");
		float num16 = default(float);
		float num15;
		if (emitZone._type == EmitZoneType.Edge)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj23 == null)
				{
					MissingMethodException ex5 = new MissingMethodException();
					throw ex5;
				}
			}
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1790 @ rax_v159 (should have been resolved before IL gen)");
			bool flag3 = (object)emitZone._quantity == null;
			float num14 = 0f;
			num15 = num16;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+24]");
				num15 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				object obj25 = 0;
				float num17 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+24]");
				float num18 = num17 / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj25 == null)
					{
						MissingMethodException ex6 = new MissingMethodException();
						throw ex6;
					}
				}
				object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2287 @ rax_v166 (should have been resolved before IL gen)");
				num14 = num18;
			}
			bool flag4 = !emitZone._yoyo;
			ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			bool flag5 = !flag4;
			ParticleSystemShapeMultiModeValue arcMode = (ParticleSystemShapeMultiModeValue)((flag5 ? 1 : 0) + 1);
			((ParticleSystem.ShapeModule*)shapeModule)->arcMode = arcMode;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAF0]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAF0]");
			bool flag6 = (nint)0 != 0;
			BaseGeom source2 = emitZone._source;
			object obj28 = 0;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj27 == null)
				{
					MissingMethodException ex7 = new MissingMethodException();
					throw ex7;
				}
				source2 = emitZone._source;
				obj28 = 0;
			}
			goto IL_0f09;
		}
		if (emitZone._type != EmitZoneType.Random)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj29 == null)
			{
				MissingMethodException ex8 = new MissingMethodException();
				throw ex8;
			}
		}
		object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1976 @ rax_v153 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		bool flag7 = (nint)0 != 0;
		float num19 = 1f;
		num15 = num16;
		BaseGeom source3 = emitZone._source;
		if (!flag7)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj31 == null)
			{
				MissingMethodException ex9 = new MissingMethodException();
				throw ex9;
			}
			num19 = 1f;
			num15 = num16;
			source3 = emitZone._source;
		}
		goto IL_16c8;
		IL_1848:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj32 == null)
			{
				MissingMethodException ex10 = new MissingMethodException();
				throw ex10;
			}
		}
		object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v805 @ rax_v101 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		object obj34 = 0;
		_ = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj34 == null)
			{
				MissingMethodException ex11 = new MissingMethodException();
				throw ex11;
			}
		}
		object obj35 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v976 @ rax_v104 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
		object obj37 = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj37 == null)
			{
				MissingMethodException ex12 = new MissingMethodException();
				throw ex12;
			}
		}
		object obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		object obj39 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1217 @ rax_v107 (should have been resolved before IL gen)");
		bool flag8 = (object)emitZone._overrideRotation == null;
		num15 = num16;
		if (!flag8)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+30]");
			num15 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			object obj40 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj40 == null)
				{
					MissingMethodException ex13 = new MissingMethodException();
					throw ex13;
				}
			}
			obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			object obj41 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1698 @ rax_v131 (should have been resolved before IL gen)");
		}
		if (emitZone._type == EmitZoneType.Edge)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
			object obj42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj42 == null)
				{
					MissingMethodException ex14 = new MissingMethodException();
					throw ex14;
				}
			}
			object obj43 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1842 @ rax_v118 (should have been resolved before IL gen)");
			bool flag9 = (object)emitZone._quantity == null;
			float num20 = 0f;
			if (!flag9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+24]");
				num15 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				object obj44 = 0;
				float num21 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+24]");
				float num22 = num21 / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj44 == null)
					{
						MissingMethodException ex15 = new MissingMethodException();
						throw ex15;
					}
				}
				object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2398 @ rax_v125 (should have been resolved before IL gen)");
				num20 = num22;
			}
			bool flag10 = !emitZone._yoyo;
			ParticleSystem.ShapeModule shapeModule2 = (ParticleSystem.ShapeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			bool flag11 = !flag10;
			ParticleSystemShapeMultiModeValue arcMode = (ParticleSystemShapeMultiModeValue)((flag11 ? 1 : 0) + 1);
			((ParticleSystem.ShapeModule*)shapeModule2)->arcMode = arcMode;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAF0]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAF0]");
			bool flag12 = (nint)0 != 0;
			BaseGeom source2 = (BaseGeom)num2;
			object obj28 = 0;
			if (!flag12)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag13 = obj27 == null;
				source2 = (BaseGeom)num2;
				obj28 = 0;
				if (flag13)
				{
					MissingMethodException ex16 = new MissingMethodException();
					throw ex16;
				}
			}
			goto IL_0f09;
		}
		if (emitZone._type != EmitZoneType.Random)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
		object obj46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj46 == null)
			{
				MissingMethodException ex17 = new MissingMethodException();
				throw ex17;
			}
		}
		object obj47 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2108 @ rax_v112 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		bool flag14 = (nint)0 != 0;
		num19 = 1f;
		source3 = (BaseGeom)num2;
		num4 = (nint)typeof(Line);
		if (!flag14)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag15 = obj31 == null;
			num19 = 1f;
			source3 = (BaseGeom)num2;
			num4 = (nint)typeof(Line);
			if (flag15)
			{
				MissingMethodException ex18 = new MissingMethodException();
				throw ex18;
			}
		}
		goto IL_16c8;
		IL_16c8:
		object obj48 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2330 @ rax_v93 (should have been resolved before IL gen)");
		return;
		IL_0f09:
		object obj49 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2479 @ rax_v95 (should have been resolved before IL gen)");
		return;
		IL_0d25:
		bool flag16 = obj12 == null;
		BaseGeom baseGeom3 = null;
		if (!flag16)
		{
			baseGeom3 = emitZone._source;
		}
		if (baseGeom3 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj50 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj50 == null)
			{
				MissingMethodException ex19 = new MissingMethodException();
				throw ex19;
			}
		}
		object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1583 @ rax_v177 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		object obj52 = 0;
		_ = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj52 == null)
			{
				MissingMethodException ex20 = new MissingMethodException();
				throw ex20;
			}
		}
		object obj53 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		object obj54 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1725 @ rax_v180 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
		object obj55 = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj55 == null)
			{
				MissingMethodException ex21 = new MissingMethodException();
				throw ex21;
			}
		}
		object obj56 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		object obj57 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1889 @ rax_v183 (should have been resolved before IL gen)");
		if ((object)emitZone._overrideRotation != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			object obj58 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj58 == null)
				{
					MissingMethodException ex22 = new MissingMethodException();
					throw ex22;
				}
			}
			obj56 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			object obj59 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2427 @ rax_v211 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rsi_v39 (VampireSurvivors.Framework.Geom.BaseGeom)+1C]");
		num15 = 0f * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rsi_v39 (VampireSurvivors.Framework.Geom.BaseGeom)+14]");
		float num23 = 0f - num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB00]");
		object obj60 = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB00]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj60 == null)
			{
				MissingMethodException ex23 = new MissingMethodException();
				throw ex23;
			}
		}
		object obj61 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		object obj62 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2429 @ rax_v187 (should have been resolved before IL gen)");
		float num27;
		if (emitZone._type == EmitZoneType.Edge)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
			object obj63 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj63 == null)
				{
					MissingMethodException ex24 = new MissingMethodException();
					throw ex24;
				}
			}
			object obj64 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2846 @ rax_v197 (should have been resolved before IL gen)");
			bool flag17 = (object)emitZone._quantity == null;
			float num24 = 0f;
			if (!flag17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+24]");
				num15 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				object obj65 = 0;
				float num25 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [emitZone @ rdx (VampireSurvivors.Framework.Particles.EmitZone)+24]");
				float num26 = num25 / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj65 == null)
					{
						MissingMethodException ex25 = new MissingMethodException();
						throw ex25;
					}
				}
				object obj66 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2986 @ rax_v204 (should have been resolved before IL gen)");
				num24 = num26;
			}
			bool flag18 = !emitZone._yoyo;
			ParticleSystem.ShapeModule shapeModule3 = (ParticleSystem.ShapeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			bool flag19 = !flag18;
			ParticleSystemShapeMultiModeValue arcMode = (ParticleSystemShapeMultiModeValue)((flag19 ? 1 : 0) + 1);
			((ParticleSystem.ShapeModule*)shapeModule3)->arcMode = arcMode;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAF0]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAF0]");
			bool flag20 = (nint)0 != 0;
			num27 = num16;
			BaseGeom source2 = emitZone._source;
			object obj28 = 0;
			if (!flag20)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj27 == null)
				{
					MissingMethodException ex26 = new MissingMethodException();
					throw ex26;
				}
				num27 = num16;
				source2 = emitZone._source;
				obj28 = 0;
			}
			goto IL_0f09;
		}
		if (emitZone._type != EmitZoneType.Random)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj67 == null)
			{
				MissingMethodException ex27 = new MissingMethodException();
				throw ex27;
			}
		}
		object obj68 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2963 @ rax_v191 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		bool flag21 = (nint)0 != 0;
		num27 = num16;
		num19 = 1f;
		source3 = emitZone._source;
		if (!flag21)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj31 == null)
			{
				MissingMethodException ex28 = new MissingMethodException();
				throw ex28;
			}
			num27 = num16;
			num19 = 1f;
			source3 = emitZone._source;
		}
		goto IL_16c8;
	}

	public unsafe static void SetQuantity(ParticleSystem pfx, int quantity)
	{
		//IL_0008: Expected O, but got Ref
		//IL_019c: Expected O, but got Ref
		//IL_01a9: Expected O, but got Ref
		//IL_0025: Expected O, but got Ref
		//IL_0032: Expected O, but got Ref
		//IL_003b: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_005e: Expected O, but got Ref
		//IL_0067: Expected O, but got I4
		//IL_03c9: Expected O, but got I
		//IL_01ca: Expected O, but got Ref
		//IL_00ad: Expected O, but got I
		//IL_0201: Expected O, but got Ref
		//IL_0219: Expected O, but got Ref
		//IL_0243: Expected F4, but got I4
		//IL_023e: Expected native int or pointer, but got O
		//IL_0253: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_0337: Expected O, but got I
		//IL_0357: Expected O, but got I
		//IL_0381: Expected O, but got I
		//IL_0391: Expected O, but got I
		//IL_02e0: Expected O, but got Ref
		//IL_02ee: Expected O, but got Ref
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_0124: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.EmissionModule emissionModule2 = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		((ParticleSystem.EmissionModule*)emissionModule2)->rateOverDistance = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
		object obj3 = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)0;
		object obj4 = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		object obj5 = 0;
		object obj8 = default(object);
		object obj12 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA70]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA70]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj6 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v345 @ rax_v16 (should have been resolved before IL gen)");
			if (System.Runtime.CompilerServices.Unsafe.As<ParticleSystem.MinMaxCurve, UIntPtr>(ref minMaxCurve3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj9 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v387 @ rax_v20 (should have been resolved before IL gen)");
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(quantity));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-64]");
			minMaxCurve4 = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			bool flag = (nint)0 == 0;
			object obj11 = obj12;
			if (!flag)
			{
				obj11 = obj12;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
			bool flag2 = (nint)0 == 0;
			object obj14 = obj12;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v26+10]");
				obj14 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
			object obj15 = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj15 == null)
				{
					break;
				}
			}
			obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
			object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v535 @ rax_v29 (should have been resolved before IL gen)");
			minMaxCurve3++;
			minMaxCurve5 = minMaxCurve3;
		}
		MissingMethodException ex3 = new MissingMethodException();
		throw ex3;
	}

	public unsafe static void SetFrame(ParticleSystem pfx, int frame)
	{
		//IL_0017: Expected F4, but got I4
		//IL_0024: Expected O, but got Ref
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(frame);
		ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = default(ParticleSystem.TextureSheetAnimationModule);
		object obj = default(object);
		textureSheetAnimationModule.startFrame = (ParticleSystem.MinMaxCurve)(&obj);
	}

	public unsafe static void SetFrames(ParticleSystem pfx, List<string> frames, string spritesheet = null, bool clearExistingFrames = false, int cycleCount = 0)
	{
		//IL_0044: Expected O, but got I
		//IL_03e0: Expected O, but got I
		//IL_0189: Expected I, but got O
		//IL_00d3: Expected I, but got O
		//IL_0653: Expected O, but got I
		//IL_0450: Expected I, but got O
		//IL_0313: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_0599: Expected O, but got Ref
		//IL_05a9: Expected O, but got I
		//IL_0502: Expected O, but got I4
		//IL_050a: Expected I, but got O
		//IL_027f: Expected O, but got I4
		//IL_0287: Expected I, but got O
		//IL_02aa: Expected O, but got I
		//IL_0547: Expected O, but got I
		if (frames == null || frames._size <= 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v319 @ rax_v34 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB78]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB78]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v384 @ rax_v37 (should have been resolved before IL gen)");
		bool flag = default(bool);
		nint num3;
		nint num2;
		if (flag)
		{
			nint num = unchecked((nint)null);
			num2 = 1;
			object obj4 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj3 == null)
					{
						MissingMethodException ex3 = new MissingMethodException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v535 @ rax_v78 (should have been resolved before IL gen)");
				bool flag2 = num >= (nint)obj4;
				num3 = unchecked((nint)null);
				if (flag2)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBB8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBB8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj5 == null)
					{
						MissingMethodException ex4 = new MissingMethodException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v665 @ rax_v81 (should have been resolved before IL gen)");
				num++;
				num2 = num;
			}
		}
		else
		{
			num2 = 1;
			num3 = unchecked((nint)null);
		}
		string text2;
		string text = default(string);
		if (text != null)
		{
			bool flag3 = text._stringLength > 0;
			text2 = text;
			if (flag3)
			{
				goto IL_04ab;
			}
		}
		PfxData component = pfx.GetComponent<PfxData>();
		ParticleSystemConfig particleSystemConfig = component._003CCurrentConfig_003Ek__BackingField;
		text2 = particleSystemConfig._003CTexture_003Ek__BackingField;
		num2 = 0;
		goto IL_04ab;
		IL_04ab:
		float max = default(float);
		ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = default(ParticleSystem.TextureSheetAnimationModule);
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		while (true)
		{
			if (num3 < frames._size)
			{
				if (num3 < frames._size)
				{
					string[] items = frames._items;
					Sprite sprite = SpriteManager.GetSprite(items[num3], text2);
					bool flag4 = (object)sprite == null;
					text = (string)1;
					num2 = (nint)text2;
					if (!flag4)
					{
						bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						text = (string)1;
						num2 = (nint)text2;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD8]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD8]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								if (obj6 == null)
								{
									MissingMethodException ex5 = new MissingMethodException();
									throw ex5;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1097 @ rax_v63 (should have been resolved before IL gen)");
							text = (string)(nint)((UnityEngine.Object)sprite).m_CachedPtr;
							num2 = num3;
						}
					}
					num3++;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				goto IL_05d1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj7 == null)
				{
					goto IL_05d1;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v743 @ rax_v42 (should have been resolved before IL gen)");
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, max);
			textureSheetAnimationModule.startFrame = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB90]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB90]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj8 == null)
				{
					break;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v922 @ rax_v47 (should have been resolved before IL gen)");
			return;
			IL_05d1:
			MissingMethodException ex6 = new MissingMethodException();
			throw ex6;
		}
		MissingMethodException ex7 = new MissingMethodException();
		throw ex7;
	}

	public unsafe static void SetSpeed(ParticleSystem pfx, float min = 0f, float max = 0f)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e0: Expected native int or pointer, but got O
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0142: Expected O, but got I
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Expected native int or pointer, but got O
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(obj + 23);
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		ParticleSystem.MinMaxCurve startSpeed = (ParticleSystem.MinMaxCurve)(obj - 9);
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(obj - 73);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+27]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startSpeed = startSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = obj - 33;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v235 @ rax_v12 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)(obj - 65);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(min, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-41]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-41]");
			if ((nint)0 != 3)
			{
				goto IL_01a0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-29]");
			float num = 0f * 0.01f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
		float num2 = 0f * 0.01f;
		goto IL_01a0;
		IL_01a0:
		ParticleSystem.MinMaxCurve startSpeed2 = (ParticleSystem.MinMaxCurve)(obj - 9);
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)(obj - 73);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-41]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-31]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startSpeed = startSpeed2;
	}

	public unsafe static void SetSpeedX(ParticleSystem pfx, ParticleSystem.MinMaxCurve value)
	{
		//IL_0008: Expected O, but got Ref
		//IL_008d: Expected O, but got Ref
		//IL_00a2: Expected native int or pointer, but got O
		//IL_00b5: Expected O, but got Ref
		//IL_00c3: Expected O, but got Ref
		//IL_0104: Expected O, but got I
		//IL_0231: Expected O, but got Ref
		//IL_024b: Expected O, but got I
		//IL_0153: Expected O, but got Ref
		//IL_016b: Expected O, but got Ref
		//IL_0185: Expected native int or pointer, but got O
		//IL_0198: Expected O, but got Ref
		//IL_01a6: Expected O, but got Ref
		//IL_01e5: Expected O, but got Ref
		//IL_01f3: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		ParticleSystem.MinMaxCurve startSpeed = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startSpeed = startSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v226 @ rax_v14 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v288 @ rax_v17 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
		ParticleSystem.MinMaxCurve x = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule)->x = x;
		_ = value.m_CurveMax;
		ParticleSystem.MinMaxCurve x2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule2 = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = value.m_Mode;
		((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule2)->x = x2;
	}

	public unsafe static void SetSpeedY(ParticleSystem pfx, ParticleSystem.MinMaxCurve value)
	{
		//IL_0008: Expected O, but got Ref
		//IL_008d: Expected O, but got Ref
		//IL_00a2: Expected native int or pointer, but got O
		//IL_00b5: Expected O, but got Ref
		//IL_00c3: Expected O, but got Ref
		//IL_0104: Expected O, but got I
		//IL_0231: Expected O, but got Ref
		//IL_024b: Expected O, but got I
		//IL_0153: Expected O, but got Ref
		//IL_016b: Expected O, but got Ref
		//IL_0185: Expected native int or pointer, but got O
		//IL_0198: Expected O, but got Ref
		//IL_01a6: Expected O, but got Ref
		//IL_01e5: Expected O, but got Ref
		//IL_01f3: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		ParticleSystem.MinMaxCurve startSpeed = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startSpeed = startSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v226 @ rax_v14 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v288 @ rax_v17 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
		ParticleSystem.MinMaxCurve y = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule)->y = y;
		_ = value.m_CurveMax;
		ParticleSystem.MinMaxCurve y2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule2 = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = value.m_Mode;
		((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule2)->y = y2;
	}

	public unsafe static void SetCollisionBounds(ParticleSystem particleSystem, ParticleSystemConfig config)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e1: Expected O, but got I
		//IL_0ac0: Expected O, but got Ref
		//IL_1213: Expected O, but got I
		//IL_0b1d: Expected O, but got Ref
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_0bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbd: Expected O, but got Unknown
		//IL_0bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bde: Expected O, but got Unknown
		//IL_03be: Expected O, but got I
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_125c: Expected O, but got Unknown
		//IL_1278: Unknown result type (might be due to invalid IL or missing references)
		//IL_127d: Expected O, but got Unknown
		//IL_0b68: Expected O, but got Ref
		//IL_155b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1560: Expected O, but got Unknown
		//IL_157c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1581: Expected O, but got Unknown
		//IL_1459: Expected O, but got I
		//IL_0b0a: Expected I, but got O
		//IL_15b4: Expected O, but got Ref
		//IL_0353: Expected F4, but got I4
		//IL_0358: Expected I, but got O
		//IL_019b: Expected O, but got Ref
		//IL_09e9: Expected O, but got I
		//IL_09f9: Expected O, but got I
		//IL_1517: Expected O, but got I
		//IL_11f4: Expected O, but got Ref
		//IL_0a57: Expected O, but got I
		//IL_07d5: Expected O, but got I
		//IL_13c3: Expected I, but got O
		//IL_0e92: Expected O, but got Ref
		//IL_0539: Expected O, but got I
		//IL_0ec2: Expected O, but got Ref
		//IL_12b1: Expected I, but got O
		//IL_0f72: Expected O, but got Ref
		//IL_067d: Expected O, but got I
		//IL_0ee7: Expected O, but got Ref
		//IL_0812: Expected O, but got I
		//IL_14cf: Expected O, but got Ref
		//IL_0fae: Expected O, but got Ref
		//IL_0d69: Expected O, but got Ref
		//IL_0576: Expected O, but got I
		//IL_0dc2: Expected O, but got Ref
		//IL_0dd9: Expected I, but got O
		//IL_0957: Expected O, but got I
		//IL_1180: Expected O, but got Ref
		//IL_026e->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_02ca->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_02f8->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_04aa->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_15db->IL01ae: Incompatible stack heights: 1 vs 0
		//IL_06fe->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_05ff->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_09d9->IL15a6: Incompatible stack heights: 2 vs 1
		//IL_089b->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_073a->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_1203->IL01ae: Incompatible stack heights: 1 vs 0
		//IL_0764->IL0a89: Incompatible stack heights: 1 vs 0
		//IL_0e45->IL0a89: Incompatible stack heights: 2 vs 0
		//IL_0a89->IL11e6: Incompatible stack heights: 2 vs 1
		//IL_0633->IL0a89: Incompatible stack heights: 2 vs 0
		//IL_0c9f->IL0a89: Incompatible stack heights: 3 vs 0
		//IL_1073->IL0a89: Incompatible stack heights: 3 vs 0
		//IL_0cf9->IL0a89: Incompatible stack heights: 4 vs 0
		//IL_10cd->IL0a89: Incompatible stack heights: 4 vs 0
		//IL_0f07->IL123b: Incompatible stack heights: 5 vs 1
		//IL_06d2->IL0ed9: Incompatible stack heights: 6 vs 5
		//IL_0fd7->IL153f: Incompatible stack heights: 5 vs 1
		//IL_0867->IL0fa0: Incompatible stack heights: 6 vs 5
		//IL_0dde->IL0b9c: Incompatible stack heights: 8 vs 1
		//IL_11b9->IL1449: Incompatible stack heights: 8 vs 1
		//IL_05cb->IL0db4: Incompatible stack heights: 9 vs 8
		//IL_09ac->IL1172: Incompatible stack heights: 9 vs 8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num5 = default(nint);
		if ((object)particleSystem != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
			if (config != null)
			{
				if ((object)config._collideBottom != null)
				{
					object obj3 = (object?)config._collideBottom >> 8;
					if (obj3 == null && (object)config._collideLeft != null)
					{
						object obj4 = (object?)config._collideLeft >> 8;
						if (obj4 == null && (object)config._collideRight != null)
						{
							object obj5 = (object?)config._collideRight >> 8;
							if (obj5 == null && (object)config._collideTop != null)
							{
								object obj6 = (object?)config._collideTop >> 8;
								if (obj6 == null)
								{
									ParticleSystem.CollisionModule collisionModule = (ParticleSystem.CollisionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
									((ParticleSystem.CollisionModule*)collisionModule)->enabled = false;
									return;
								}
							}
						}
					}
				}
				if ((object)config._bounds == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB28]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB28]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj7 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				}
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v739 @ rax_v146 (should have been resolved before IL gen)");
				bool flag = (object)config._bounds == null;
				Transform transform = particleSystem.transform;
				bool flag2 = (nint)transform < 0;
				if ((object)transform != null)
				{
					int childCount = transform.childCount;
					int num = childCount - 1;
					int num2 = 0;
					if (flag2)
					{
						goto IL_036f;
					}
					while (true)
					{
						Transform transform2 = particleSystem.transform;
						if ((object)transform2 == null)
						{
							break;
						}
						Transform child = transform2.GetChild(num);
						if ((object)child == null)
						{
							break;
						}
						GameObject gameObject = child.gameObject;
						nint num3 = (nint)typeof(UnityEngine.Object);
						UnityEngine.Object.Destroy(gameObject, 0f);
						num--;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1587 @ rcx_v375 (Il2CppClass<UnityEngine.Object>)+E4]");
						bool flag3 = (nint)0 >= (nint)0;
						float num4 = 0f;
						num5 = unchecked((nint)null);
						num2 = 0;
						if (flag3)
						{
							continue;
						}
						goto IL_036f;
					}
				}
			}
		}
		goto IL_0a89;
		IL_036f:
		int num6 = 0;
		object obj11 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB40]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB40]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj9 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1183 @ rax_v153 (should have been resolved before IL gen)");
			if (num6 >= (nint)obj11)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB38]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj12 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
			}
			object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1250 @ rax_v426 (should have been resolved before IL gen)");
			num6++;
			int num2 = num6;
		}
		object obj14 = (object?)config._collideTop >> 8;
		object obj15 = obj14 - 1;
		bool flag4 = obj15 == null;
		object obj16 = (_003F?)config._collideTop & flag4;
		Vector3 euler = default(Vector3);
		Quaternion ret = default(Quaternion);
		object obj19 = default(object);
		if (obj16 != null)
		{
			GameObject gameObject2 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject2, "TopPlane");
			if ((object)gameObject2 != null)
			{
				bool flag5 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag6 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr);
				GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				if ((object)gameObject3 != null)
				{
					bool flag7 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					if ((object)transform3 != null)
					{
						bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4640 @ rcx_v323 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((nint)(delegate*<Transform, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
						}
						Transform.SetParent_Injected(parent: (IntPtr)(((object)transform4 == null) ? null : ((object)(nint)((UnityEngine.Object)transform4).m_CachedPtr)), _unity_self: ((UnityEngine.Object)transform3).m_CachedPtr, worldPositionStays: false);
						bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
						Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
						bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
						Transform.set_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Quaternion*)obj17);
						object obj18 = obj19 + obj19;
						float num4 = (float)obj18 * 0.01f;
						bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5709 @ rcx_v339 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag12 = obj20 == null;
						}
						object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5770 @ rax_v397 (should have been resolved before IL gen)");
						object obj22 = obj19;
						num5 = unchecked((nint)null);
						goto IL_0b9c;
					}
				}
			}
			goto IL_0a89;
		}
		goto IL_0b9c;
		IL_1449:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag13 = obj23 == null;
		}
		object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1734 @ rax_v164 (should have been resolved before IL gen)");
		if (config._bounce != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+260]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+258]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+258]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1789 @ rax_v166+10]");
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+260]");
			bool flag14 = (nint)0 == 0;
			object obj27 = obj19;
			if (!flag14)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ xmm5_v3+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
				obj27 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB48]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB48]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag15 = obj28 == null;
			}
			object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2286 @ rax_v171 (should have been resolved before IL gen)");
		}
		return;
		IL_0a89:
		throw new NullReferenceException();
		IL_123b:
		object obj30 = (object?)config._collideLeft >> 8;
		object obj31 = obj30 - 1;
		bool flag16 = obj31 == null;
		object obj32 = (_003F?)config._collideLeft & flag16;
		Vector3 euler2 = default(Vector3);
		bool flag22;
		if (obj32 != null)
		{
			GameObject gameObject4 = new GameObject("LeftPlane");
			if ((object)gameObject4 != null)
			{
				Transform transform6 = gameObject4.transform;
				GameObject gameObject5 = particleSystem.gameObject;
				if ((object)gameObject5 != null)
				{
					Transform transform7 = gameObject5.transform;
					if ((object)transform6 != null)
					{
						bool flag17 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3076 @ rcx_v233 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Transform.SetParent_Injected(parent: (IntPtr)(((object)transform7 == null) ? null : ((object)(nint)((UnityEngine.Object)transform7).m_CachedPtr)), _unity_self: ((UnityEngine.Object)transform6).m_CachedPtr, worldPositionStays: false);
						bool flag18 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref euler);
						Quaternion.Internal_FromEulerRad_Injected(ref euler2, out ret);
						bool flag19 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						Transform.set_rotation_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Quaternion*)obj33);
						bool flag20 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref euler);
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5267 @ rcx_v249 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag21 = obj34 == null;
						}
						object obj35 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5422 @ rax_v283 (should have been resolved before IL gen)");
						object obj22 = obj19;
						float num4 = 4.712389f;
						flag22 = false;
						goto IL_153f;
					}
				}
			}
			goto IL_0a89;
		}
		goto IL_153f;
		IL_0b9c:
		object obj36 = (object?)config._collideBottom >> 8;
		object obj37 = obj36 - 1;
		bool flag23 = obj37 == null;
		object obj38 = (_003F?)config._collideBottom & flag23;
		bool flag24 = obj38 == null;
		flag22 = (byte)num5 != 0;
		if (!flag24)
		{
			GameObject gameObject6 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject6, "BottomPlane");
			if ((object)gameObject6 != null)
			{
				bool flag25 = ((UnityEngine.Object)gameObject6).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr4 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject6).m_CachedPtr);
				Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
				GameObject gameObject7 = particleSystem.gameObject;
				if ((object)gameObject7 != null)
				{
					Transform transform9 = gameObject7.transform;
					if ((object)transform8 != null)
					{
						transform8.SetParent(transform9, worldPositionStays: false);
						bool flag26 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						Transform.set_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref euler);
						_ = Quaternion.identityQuaternion;
						bool flag27 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						object obj39 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
						Transform.set_rotation_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Quaternion*)obj39);
						_ = 0;
						bool flag28 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						object obj40 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Vector3*)obj40);
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5173 @ rcx_v289 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj41 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag29 = obj41 == null;
						}
						object obj42 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5325 @ rax_v333 (should have been resolved before IL gen)");
						object obj22 = obj19;
						flag22 = false;
						goto IL_123b;
					}
				}
			}
			goto IL_0a89;
		}
		goto IL_123b;
		IL_153f:
		object obj43 = (object?)config._collideRight >> 8;
		object obj44 = obj43 - 1;
		bool flag30 = obj44 == null;
		object obj45 = (_003F?)config._collideRight & flag30;
		bool flag31 = obj45 == null;
		bool flag32 = flag30;
		if (!flag31)
		{
			GameObject gameObject8 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject8, "RightPlane");
			if ((object)gameObject8 != null)
			{
				bool flag33 = ((UnityEngine.Object)gameObject8).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr5 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject8).m_CachedPtr);
				Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
				bool flag34 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr6 = Component.get_gameObject_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr);
				GameObject gameObject9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr6);
				if ((object)gameObject9 != null)
				{
					bool flag35 = ((UnityEngine.Object)gameObject9).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr7 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject9).m_CachedPtr);
					Transform transform11 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
					if ((object)transform10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						bool flag36 = (nint)0 == 0;
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4961 @ rcx_v185 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Transform transform12 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((nint)(delegate*<Transform, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
						}
						bool flag37 = (object)transform11 == null;
						nint parent = 0;
						if (!flag37)
						{
							parent = ((UnityEngine.Object)transform11).m_CachedPtr;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						Transform.SetParent_Injected((IntPtr)0, (IntPtr)parent, false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						bool flag38 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref euler2);
						_ = 0;
						object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&ret), out *(Quaternion*)obj46);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						bool flag39 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						Quaternion value2 = default(Quaternion);
						Transform.set_rotation_Injected((IntPtr)0, ref value2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						bool flag40 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						Transform.set_localPosition_Injected((IntPtr)0, ref euler2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj47 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag41 = obj47 == null;
						}
						object obj48 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5802 @ rax_v223 (should have been resolved before IL gen)");
						object obj22 = obj19;
						float num4 = (float)Math.PI / 2f;
						flag22 = false;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rax_v185 (UnityEngine.Transform)+10]");
						flag32 = false;
						goto IL_1449;
					}
				}
			}
			goto IL_0a89;
		}
		goto IL_1449;
	}

	public unsafe static void SetCollisionBoundsWorld(ParticleSystem particleSystem, ParticleSystemConfig config)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e1: Expected O, but got I
		//IL_0b31: Expected O, but got Ref
		//IL_024a: Expected O, but got I
		//IL_025a: Expected F4, but got I
		//IL_1308: Expected O, but got I
		//IL_0b8e: Expected O, but got Ref
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Expected O, but got Unknown
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Expected O, but got Unknown
		//IL_03f8: Expected O, but got I
		//IL_134c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1351: Expected O, but got Unknown
		//IL_136d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1372: Expected O, but got Unknown
		//IL_0bd9: Expected O, but got Ref
		//IL_168b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1690: Expected O, but got Unknown
		//IL_16ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b1: Expected O, but got Unknown
		//IL_157f: Expected O, but got I
		//IL_0b7b: Expected I, but got O
		//IL_16e4: Expected O, but got Ref
		//IL_038d: Expected F4, but got I4
		//IL_0392: Expected I, but got O
		//IL_019b: Expected O, but got Ref
		//IL_0a55: Expected O, but got I
		//IL_0a65: Expected O, but got I
		//IL_1642: Expected O, but got I
		//IL_12e9: Expected O, but got Ref
		//IL_0ac8: Expected O, but got I
		//IL_0841: Expected O, but got I
		//IL_14d2: Expected I, but got O
		//IL_0f67: Expected I, but got O
		//IL_0f9d: Expected O, but got Ref
		//IL_1503: Expected O, but got Ref
		//IL_1511: Expected O, but got Ref
		//IL_0573: Expected O, but got I
		//IL_06e9: Expected O, but got I
		//IL_13a9: Expected I, but got O
		//IL_0f16: Expected O, but got Ref
		//IL_1190: Expected I, but got O
		//IL_1013: Expected O, but got Ref
		//IL_13dd: Expected O, but got Ref
		//IL_13eb: Expected O, but got Ref
		//IL_11c6: Expected O, but got Ref
		//IL_087e: Expected O, but got I
		//IL_15f5: Expected O, but got Ref
		//IL_1038: Expected O, but got Ref
		//IL_121a: Expected O, but got Ref
		//IL_0e38: Expected O, but got Ref
		//IL_124d: Expected O, but got Ref
		//IL_05b0: Expected O, but got I
		//IL_0e60: Expected O, but got Ref
		//IL_0e77: Expected I, but got O
		//IL_09c3: Expected O, but got I
		//IL_1275: Expected O, but got Ref
		//IL_02a8->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_0304->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_0332->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_04e4->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_170b->IL01ae: Incompatible stack heights: 1 vs 0
		//IL_076a->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_0639->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_0a45->IL16d6: Incompatible stack heights: 2 vs 1
		//IL_0907->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_07a6->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_0675->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_12f8->IL01ae: Incompatible stack heights: 1 vs 0
		//IL_07d0->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_069f->IL0afa: Incompatible stack heights: 1 vs 0
		//IL_0afa->IL12db: Incompatible stack heights: 2 vs 1
		//IL_0d10->IL0afa: Incompatible stack heights: 3 vs 0
		//IL_10fd->IL0afa: Incompatible stack heights: 3 vs 0
		//IL_0d6a->IL0afa: Incompatible stack heights: 4 vs 0
		//IL_1157->IL0afa: Incompatible stack heights: 4 vs 0
		//IL_0f36->IL1330: Incompatible stack heights: 4 vs 1
		//IL_073e->IL0f08: Incompatible stack heights: 5 vs 4
		//IL_1061->IL166f: Incompatible stack heights: 5 vs 1
		//IL_08d3->IL102a: Incompatible stack heights: 6 vs 5
		//IL_0e7c->IL0c0d: Incompatible stack heights: 8 vs 1
		//IL_12ae->IL156f: Incompatible stack heights: 8 vs 1
		//IL_0605->IL0e52: Incompatible stack heights: 9 vs 8
		//IL_0a18->IL1267: Incompatible stack heights: 9 vs 8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num5 = default(nint);
		if ((object)particleSystem != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
			if (config != null)
			{
				if ((object)config._collideBottom != null)
				{
					object obj3 = (object?)config._collideBottom >> 8;
					if (obj3 == null && (object)config._collideLeft != null)
					{
						object obj4 = (object?)config._collideLeft >> 8;
						if (obj4 == null && (object)config._collideRight != null)
						{
							object obj5 = (object?)config._collideRight >> 8;
							if (obj5 == null && (object)config._collideTop != null)
							{
								object obj6 = (object?)config._collideTop >> 8;
								if (obj6 == null)
								{
									ParticleSystem.CollisionModule collisionModule = (ParticleSystem.CollisionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
									((ParticleSystem.CollisionModule*)collisionModule)->enabled = false;
									return;
								}
							}
						}
					}
				}
				if ((object)config._boundsWorld == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB28]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB28]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj7 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				}
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v704 @ rax_v149 (should have been resolved before IL gen)");
				bool flag = (object)config._boundsWorld == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+288]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+298]");
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+288]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+298]");
				_ = 0;
				Transform transform = particleSystem.transform;
				bool flag2 = (nint)transform < 0;
				if ((object)transform != null)
				{
					int childCount = transform.childCount;
					int num2 = childCount - 1;
					int num3 = 0;
					if (flag2)
					{
						goto IL_03a9;
					}
					while (true)
					{
						Transform transform2 = particleSystem.transform;
						if ((object)transform2 == null)
						{
							break;
						}
						Transform child = transform2.GetChild(num2);
						if ((object)child == null)
						{
							break;
						}
						GameObject gameObject = child.gameObject;
						nint num4 = (nint)typeof(UnityEngine.Object);
						UnityEngine.Object.Destroy(gameObject, 0f);
						num2--;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1506 @ rcx_v372 (Il2CppClass<UnityEngine.Object>)+E4]");
						bool flag3 = (nint)0 >= (nint)0;
						num = 0f;
						num5 = unchecked((nint)null);
						num3 = 0;
						if (flag3)
						{
							continue;
						}
						goto IL_03a9;
					}
				}
			}
		}
		goto IL_0afa;
		IL_03a9:
		int num6 = 0;
		object obj12 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB40]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB40]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj10 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1115 @ rax_v156 (should have been resolved before IL gen)");
			if (num6 >= (nint)obj12)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB38]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj13 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
			}
			object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1178 @ rax_v422 (should have been resolved before IL gen)");
			num6++;
			int num3 = num6;
		}
		object obj15 = (object?)config._collideTop >> 8;
		object obj16 = obj15 - 1;
		bool flag4 = obj16 == null;
		object obj17 = (_003F?)config._collideTop & flag4;
		Vector3 value = default(Vector3);
		Quaternion value2 = default(Quaternion);
		object obj23 = default(object);
		if (obj17 != null)
		{
			GameObject gameObject2 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject2, "TopPlane");
			if ((object)gameObject2 != null)
			{
				bool flag5 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag6 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr);
				GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				if ((object)gameObject3 != null)
				{
					bool flag7 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					if ((object)transform3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						bool flag8 = (nint)0 == 0;
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4190 @ rcx_v320 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((nint)(delegate*<Transform, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
						}
						string text = (((object)transform4 == null) ? null : ((string)(nint)((UnityEngine.Object)transform4).m_CachedPtr));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						Transform.SetParent_Injected((IntPtr)0, (IntPtr)text, false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						_ = (float)Math.PI;
						_ = 0;
						object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
						object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj19, out *(Quaternion*)obj18);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						Transform.set_rotation_Injected((IntPtr)0, ref value2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-25]");
						float num8 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
						float num = num8 + 0f;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						bool flag11 = (nint)0 == 0;
						object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v355 (UnityEngine.Transform)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj20);
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5412 @ rcx_v336 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag12 = obj21 == null;
						}
						object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5473 @ rax_v393 (should have been resolved before IL gen)");
						object obj9 = obj23;
						num5 = unchecked((nint)null);
						goto IL_0c0d;
					}
				}
			}
			goto IL_0afa;
		}
		goto IL_0c0d;
		IL_156f:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag13 = obj24 == null;
		}
		object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1646 @ rax_v167 (should have been resolved before IL gen)");
		if (config._bounce != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+260]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+258]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+258]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1701 @ rax_v169+10]");
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+260]");
			bool flag14 = (nint)0 == 0;
			object obj28 = obj23;
			if (!flag14)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ xmm5_v3+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
				obj28 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB48]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB48]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag15 = obj29 == null;
			}
			object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2059 @ rax_v174 (should have been resolved before IL gen)");
		}
		return;
		IL_0afa:
		throw new NullReferenceException();
		IL_1330:
		object obj31 = (object?)config._collideLeft >> 8;
		object obj32 = obj31 - 1;
		bool flag16 = obj32 == null;
		object obj33 = (_003F?)config._collideLeft & flag16;
		bool flag22;
		if (obj33 != null)
		{
			GameObject gameObject4 = new GameObject("LeftPlane");
			if ((object)gameObject4 != null)
			{
				Transform transform6 = gameObject4.transform;
				GameObject gameObject5 = particleSystem.gameObject;
				if ((object)gameObject5 != null)
				{
					Transform transform7 = gameObject5.transform;
					if ((object)transform6 != null)
					{
						bool flag17 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2630 @ rcx_v236 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Transform.SetParent_Injected(parent: (IntPtr)(((object)transform7 == null) ? null : ((object)(nint)((UnityEngine.Object)transform7).m_CachedPtr)), _unity_self: ((UnityEngine.Object)transform6).m_CachedPtr, worldPositionStays: false);
						nint num11 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3590 @ rax_v265 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num12 = 0;
						_ = Vector3.oneVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3591 @ rax_v266 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
						_ = 0;
						bool flag18 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						object obj34 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj34);
						_ = 4.712389f;
						_ = 0;
						object obj35 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
						object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj36, out *(Quaternion*)obj35);
						bool flag19 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						Transform.set_rotation_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value2);
						_ = 0;
						bool flag20 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj37);
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4944 @ rcx_v252 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag21 = obj38 == null;
						}
						object obj39 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5132 @ rax_v286 (should have been resolved before IL gen)");
						float num = 4.712389f;
						object obj9 = obj23;
						flag22 = false;
						goto IL_166f;
					}
				}
			}
			goto IL_0afa;
		}
		goto IL_166f;
		IL_0c0d:
		object obj40 = (object?)config._collideBottom >> 8;
		object obj41 = obj40 - 1;
		bool flag23 = obj41 == null;
		object obj42 = (_003F?)config._collideBottom & flag23;
		bool flag24 = obj42 == null;
		flag22 = (byte)num5 != 0;
		if (!flag24)
		{
			GameObject gameObject6 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject6, "BottomPlane");
			if ((object)gameObject6 != null)
			{
				Transform transform8 = gameObject6.transform;
				GameObject gameObject7 = particleSystem.gameObject;
				if ((object)gameObject7 != null)
				{
					Transform transform9 = gameObject7.transform;
					if ((object)transform8 != null)
					{
						transform8.SetParent(transform9, worldPositionStays: false);
						bool flag25 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						Transform.set_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref value);
						bool flag26 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						Transform.set_rotation_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref value2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-25]");
						float num14 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
						float num = num14 - 0f;
						bool flag27 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref value);
						nint num15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4582 @ rcx_v289 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj43 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag28 = obj43 == null;
						}
						object obj44 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4742 @ rax_v332 (should have been resolved before IL gen)");
						object obj9 = obj23;
						flag22 = false;
						goto IL_1330;
					}
				}
			}
			goto IL_0afa;
		}
		goto IL_1330;
		IL_166f:
		object obj45 = (object?)config._collideRight >> 8;
		object obj46 = obj45 - 1;
		bool flag29 = obj46 == null;
		object obj47 = (_003F?)config._collideRight & flag29;
		bool flag30 = obj47 == null;
		bool flag31 = flag29;
		if (!flag30)
		{
			GameObject gameObject8 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject8, "RightPlane");
			if ((object)gameObject8 != null)
			{
				bool flag32 = ((UnityEngine.Object)gameObject8).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr4 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject8).m_CachedPtr);
				Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
				bool flag33 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr5 = Component.get_gameObject_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr);
				GameObject gameObject9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr5);
				if ((object)gameObject9 != null)
				{
					bool flag34 = ((UnityEngine.Object)gameObject9).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr6 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject9).m_CachedPtr);
					Transform transform11 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
					if ((object)transform10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						bool flag35 = (nint)0 == 0;
						nint num16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4641 @ rcx_v188 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Transform transform12 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((nint)(delegate*<Transform, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
						}
						bool flag36 = (object)transform11 == null;
						nint parent = 0;
						if (!flag36)
						{
							parent = ((UnityEngine.Object)transform11).m_CachedPtr;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						Transform.SetParent_Injected((IntPtr)0, (IntPtr)parent, false);
						nint num17 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4972 @ rax_v205 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num18 = 0;
						_ = Vector3.oneVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4973 @ rax_v206 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						bool flag37 = (nint)0 == 0;
						object obj48 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj48);
						_ = (float)Math.PI / 2f;
						object obj49 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj49, out value2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						bool flag38 = (nint)0 == 0;
						object obj50 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj50);
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						bool flag39 = (nint)0 == 0;
						object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj51);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						object obj52 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB50]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag40 = obj52 == null;
						}
						object obj53 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5505 @ rax_v226 (should have been resolved before IL gen)");
						float num = (float)Math.PI / 2f;
						object obj9 = value2;
						flag22 = false;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2495 @ rax_v188 (UnityEngine.Transform)+10]");
						flag31 = false;
						goto IL_156f;
					}
				}
			}
			goto IL_0afa;
		}
		goto IL_156f;
	}

	public unsafe static void SetCollisionBoundsCircle(ParticleSystem particleSystem, ParticleSystemConfig config)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0431: Expected O, but got I
		//IL_06d6: Expected O, but got Ref
		//IL_00a2: Expected O, but got I4
		//IL_00a7: Expected I, but got O
		//IL_0128: Expected I, but got O
		//IL_0729: Expected O, but got I
		//IL_0588: Expected O, but got Ref
		//IL_016a: Expected O, but got I
		//IL_05bf: Expected O, but got Ref
		//IL_04f2: Expected I4, but got O
		//IL_03c9: Expected O, but got Ref
		//IL_02bc: Expected O, but got Ref
		//IL_02d1: Expected native int or pointer, but got O
		//IL_02f9: Expected O, but got I
		//IL_0670: Expected O, but got I
		//IL_0761: Expected O, but got I
		//IL_034d: Expected O, but got I
		//IL_0570: Expected I, but got O
		//IL_06ab: Expected O, but got Ref
		//IL_06b9: Expected O, but got Ref
		//IL_036f: Expected O, but got I
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_015a->IL057a: Incompatible stack heights: 1 vs 0
		//IL_04bd->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_01bf->IL05b1: Incompatible stack heights: 1 vs 0
		//IL_051b->IL03f2: Incompatible stack heights: 2 vs 0
		//IL_065b->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0250->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0255->IL0255: Incompatible stack heights: 1 vs 0
		//IL_011e->IL0575: Incompatible stack heights: 3 vs 0
		//IL_0123->IL0123: Incompatible stack heights: 3 vs 0
		//IL_03a1->IL069d: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = default(ParticleSystemConfig);
		if (particleSystemConfig != null)
		{
			if (!particleSystemConfig._circleCollision)
			{
				return;
			}
			if ((object)particleSystem != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v452 @ rax_v38 (should have been resolved before IL gen)");
				Transform transform = particleSystem.transform;
				bool flag = (nint)transform < 0;
				if ((object)transform != null)
				{
					int childCount = transform.childCount;
					object obj5 = childCount - 1;
					nint num = unchecked((nint)null);
					if (flag)
					{
						goto IL_0123;
					}
					while (true)
					{
						bool flag2 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr);
						Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform2 == null)
						{
							break;
						}
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						IntPtr child_Injected = Transform.GetChild_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (int)obj5);
						Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
						if ((object)transform3 == null)
						{
							break;
						}
						bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)transform3).m_CachedPtr);
						GameObject obj6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
						nint num2 = (nint)typeof(UnityEngine.Object);
						UnityEngine.Object.Destroy(obj6, 0f);
						obj5--;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1456 @ rcx_v54 (Il2CppClass<UnityEngine.Object>)+E4]");
						bool flag5 = (nint)0 >= (nint)0;
						num = 0;
						if (!flag5)
						{
							goto IL_0123;
						}
					}
				}
			}
		}
		goto IL_03f2;
		IL_0123:
		nint num3 = unchecked((nint)null);
		object obj9 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB40]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB40]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag6 = obj7 == null;
			}
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v675 @ rax_v77 (should have been resolved before IL gen)");
			if (num3 >= (nint)obj9)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB38]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag7 = obj10 == null;
			}
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v878 @ rax_v119 (should have been resolved before IL gen)");
			num3++;
			nint num = num3;
		}
		ParticleSystemCircleCollision component = particleSystem.GetComponent<ParticleSystemCircleCollision>();
		ParticleSystemCircleCollision particleSystemCircleCollision;
		if ((object)component != null)
		{
			bool flag8 = ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0;
			particleSystemCircleCollision = component;
			nint num4 = 0;
			if (flag8)
			{
				goto IL_0255;
			}
		}
		bool flag9 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr);
		GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
		if ((object)gameObject != null)
		{
			ParticleSystemCircleCollision particleSystemCircleCollision2 = gameObject.AddComponent<ParticleSystemCircleCollision>();
			bool flag10 = (object)particleSystemCircleCollision2 == null;
			particleSystemCircleCollision = particleSystemCircleCollision2;
			nint num4 = 0;
			if (!flag10)
			{
				goto IL_0255;
			}
		}
		goto IL_03f2;
		IL_03f2:
		throw new NullReferenceException();
		IL_0255:
		particleSystemCircleCollision._particleSystem = particleSystem;
		float radius = particleSystemConfig._circleCollisionRadius * 0.01f;
		particleSystemCircleCollision._radius = radius;
		if (particleSystemConfig._bounce == null)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
			bool flag11 = (nint)0 == 0;
			object obj14 = default(object);
			object obj13 = obj14;
			if (!flag11)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1353 @ rax_v88+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
				obj13 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
			bool flag12 = (nint)0 == 0;
			object obj16 = obj14;
			if (!flag12)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1413 @ rax_v90+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+27]");
				obj16 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB48]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB48]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag13 = obj17 == null;
			}
			object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1458 @ rax_v93 (should have been resolved before IL gen)");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rdx_v25 (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+250]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rdx_v25 (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+260]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			float bounce = ((ParticleSystem.MinMaxCurve*)minMaxCurve2)->Evaluate(0f, 1f);
			particleSystemCircleCollision._bounce = bounce;
		}
	}

	public static void Start(ParticleSystem pfx)
	{
		//IL_0046: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v110 @ rax_v8 (should have been resolved before IL gen)");
		pfx.Play(withChildren: true);
	}

	public static void StopEmitting(ParticleSystem pfx)
	{
		//IL_0046: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v106 @ rax_v7 (should have been resolved before IL gen)");
	}

	public static void ForceClear(ParticleSystem pfx)
	{
		//IL_0077: Expected O, but got I
		//IL_0103: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v110 @ rax_v11 (should have been resolved before IL gen)");
		pfx.Clear(withChildren: true);
		pfx.Clear(withChildren: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v180 @ rax_v16 (should have been resolved before IL gen)");
	}

	public static float GetRemainingLifetime(ParticleSystem pfx)
	{
		//IL_017c: Expected O, but got I
		//IL_0235: Expected I4, but got I8
		//IL_01c8: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ea: Invalid comparison between I and F4
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0145: Expected F4, but got I
		ParticleSystem.Particle[] cachedParticles = _cachedParticles;
		float result;
		if (_cachedParticles != null && (object)pfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v281 @ rax_v16 (should have been resolved before IL gen)");
			object obj2 = default(object);
			if (cachedParticles.Length < (nint)obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj3 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v497 @ rax_v41 (should have been resolved before IL gen)");
				object obj4 = default(object);
				ParticleSystem.Particle[] cachedParticles2 = new ParticleSystem.Particle[obj4];
				_cachedParticles = cachedParticles2;
			}
			int num = pfx.GetParticles(_cachedParticles, -1, 0);
			bool flag = num <= 0;
			result = -3.4028235E+38f;
			if (flag)
			{
				goto IL_014a;
			}
			float num2 = -3.4028235E+38f;
			object obj5 = 0;
			while (true)
			{
				ParticleSystem.Particle[] cachedParticles3 = _cachedParticles;
				if (_cachedParticles == null)
				{
					break;
				}
				if ((nint)obj5 < cachedParticles3.Length)
				{
					object obj6 = obj5 * 132;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ rdx_v12+8C+v113 @ rcx_v19 (Particle[])]");
					if (0f > num2)
					{
						ParticleSystem.Particle[] cachedParticles4 = _cachedParticles;
						if (_cachedParticles == null)
						{
							break;
						}
						if ((nint)obj5 >= cachedParticles4.Length)
						{
							goto IL_014f;
						}
						object obj7 = obj5 * 132;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rcx_v23+8C+v97 @ rdx_v14 (Particle[])]");
						num2 = 0f;
					}
					obj5++;
					bool flag2 = (nint)obj5 < num;
					result = num2;
					if (!flag2)
					{
						goto IL_014a;
					}
					continue;
				}
				goto IL_014f;
				IL_014f:
				throw new IndexOutOfRangeException();
			}
		}
		throw new NullReferenceException();
		IL_014a:
		return result;
	}

	public unsafe static void EmitParticleAt(ParticleSystem system, Vector2 pos, int count = -1)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_01c0: Expected O, but got I4
		//IL_01f4: Expected O, but got I
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I
		//IL_012c: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2 - 296;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		int num = default(int);
		bool flag = num >= 0;
		int count2 = num;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA70]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA70]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v348 @ rax_v29 (should have been resolved before IL gen)");
			object obj4 = default(object);
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj5 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v578 @ rax_v35 (should have been resolved before IL gen)");
				_ = 0;
				_ = 0;
				ParticleSystem.MinMaxCurveBlittable minMaxCurveBlittable = default(ParticleSystem.MinMaxCurveBlittable);
				if (ParticleSystem.MinMaxCurveBlittable.ToMinMaxCurve(ref minMaxCurveBlittable).m_Mode == ParticleSystemCurveMode.Constant)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj6 == null)
						{
							MissingMethodException ex3 = new MissingMethodException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v686 @ rax_v42 (should have been resolved before IL gen)");
					_ = 0;
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve = ParticleSystem.MinMaxCurveBlittable.ToMinMaxCurve(ref minMaxCurveBlittable);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int num2 = default(int);
					count2 = num2;
					goto IL_0185;
				}
			}
			count2 = 1;
		}
		goto IL_0185;
		IL_0185:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		obj = 0;
		_ = 0;
		_ = 0;
		bool flag2 = ((UnityEngine.Object)system).m_CachedPtr == (IntPtr)0;
		object obj7 = obj - 80;
		ParticleSystem.Emit_Injected(((UnityEngine.Object)system).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj7, count2);
	}

	public unsafe static void SetAlpha(ParticleSystem system, ParticleSystem.MinMaxCurve value, Easing easing = Easing.Linear)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00be: Expected O, but got I4
		//IL_0176: Expected O, but got Ref
		//IL_0184: Expected O, but got Ref
		//IL_00dc: Expected O, but got I4
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Gradient gradient = new Gradient();
		IntPtr ptr = Gradient.Init();
		gradient.m_Ptr = ptr;
		gradient.m_RequiresNativeCleanup = true;
		GradientColorKey[] colorKeys = new GradientColorKey[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
		_ = 0;
		_ = 1f;
		Easing easing2 = default(Easing);
		bool flag = easing2 == Easing.Linear;
		int points = 2;
		if (!flag)
		{
			points = 8;
		}
		ParticleSystem.MinMaxCurve minMaxCurve = default(ParticleSystem.MinMaxCurve);
		float[] easedValues = EasingUtils.GetEasedValues(minMaxCurve.m_ConstantMin, minMaxCurve.m_ConstantMax, easing2, points);
		GradientAlphaKey[] alphaKeys = new GradientAlphaKey[easedValues.Length];
		bool flag2 = easedValues.Length <= 0;
		object obj3 = 0;
		if (!flag2)
		{
			bool flag3;
			do
			{
				object obj4 = easedValues.Length - 1;
				float num = 1f / (float)obj4;
				float num2 = num * (float)obj3;
				object obj5 = obj3 + 1;
				_ = easedValues[obj3];
				flag3 = (nint)obj5 < easedValues.Length;
				obj3 = obj5;
			}
			while (flag3);
		}
		gradient.SetKeys(colorKeys, alphaKeys);
		_ = 1;
		ParticleSystem.MinMaxGradient color = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		((ParticleSystem.ColorOverLifetimeModule*)colorOverLifetimeModule)->color = color;
	}

	public static void SetMaxParticles(ParticleSystem ps, int maxParticles = 1000)
	{
		//IL_0046: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v109 @ rax_v7 (should have been resolved before IL gen)");
	}

	public unsafe static Texture2D ConvertToTexture(Sprite sprite, bool generateMipMaps = false)
	{
		bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
		bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret2);
		IntPtr intPtr = default(IntPtr);
		bool flag3 = default(bool);
		Texture2D texture2D = new Texture2D((int)(&ret2), (int)(nint)intPtr, TextureFormat.RGBA32, flag3);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rsp+5Ch]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+68h]\"");
		Texture2D texture = sprite.texture;
		bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.GetTextureRect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.GetTextureRect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		bool flag6 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.GetTextureRect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret2);
		bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.GetTextureRect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rsp+6Ch]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,dword ptr [rsp+58h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rsp+74h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+80h]\"");
		int miplevel = default(int);
		Color[] pixels = texture.GetPixels((int)(&ret), (int)(nint)intPtr, 4, flag3 ? 1 : 0, miplevel);
		texture2D.SetPixels(pixels);
		texture2D.wrapMode = TextureWrapMode.Repeat;
		string name = ((UnityEngine.Object)sprite).GetName();
		((UnityEngine.Object)texture2D).SetName(name);
		texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
		return texture2D;
	}

	public unsafe static void SetAlpha(Material material, float alpha)
	{
		//IL_0075: Expected O, but got Ref
		int firstPropertyNameIdByAttribute = material.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
		int nameID = ((firstPropertyNameIdByAttribute < 0) ? Material.k_ColorId : firstPropertyNameIdByAttribute);
		Color color = material.GetColor(nameID);
		object obj = default(object);
		material.color = (Color)(&obj);
	}

	public static TextMeshPro AddText(MonoBehaviour monoBehaviour, Vector2 pos, string text)
	{
		if ((object)monoBehaviour != null)
		{
			GameObject gameObject = monoBehaviour.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 62 Invalid \"Jump target not found in method: 0x186C0ADD0\"");
		}
		return (TextMeshPro)(object)new NullReferenceException();
	}

	public static TextMeshPro AddText(GameObject gameObject, Vector2 pos, string text)
	{
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "SpriteRenderer");
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					TextMeshPro textMeshPro = gameObject2.AddComponent<TextMeshPro>();
					bool flag3 = (object)textMeshPro == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
					return textMeshPro;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static TextMeshPro SetAlpha(TextMeshPro textMeshPro, float alpha)
	{
		//IL_0037: Expected O, but got Ref
		if ((object)textMeshPro != null)
		{
			Color color = textMeshPro.color;
			object obj = default(object);
			textMeshPro.color = (Color)(&obj);
			return textMeshPro;
		}
		return (TextMeshPro)(object)new NullReferenceException();
	}

	public unsafe static TextMeshProUGUI SetAlpha(TextMeshProUGUI textMeshPro, float alpha)
	{
		//IL_0037: Expected O, but got Ref
		if ((object)textMeshPro != null)
		{
			Color color = textMeshPro.color;
			object obj = default(object);
			textMeshPro.color = (Color)(&obj);
			return textMeshPro;
		}
		return (TextMeshProUGUI)(object)new NullReferenceException();
	}

	public static TextMeshPro SetTint(TextMeshPro textMeshPro, uint[] tints)
	{
		//IL_0073: Expected O, but got I4
		if (tints != null && tints.Length != 0)
		{
			object obj = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			bool flag = (nint)obj >= tints.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
			return textMeshPro;
		}
		return textMeshPro;
	}

	public unsafe static TextMeshPro SetTint(TextMeshPro textMeshPro, uint tint)
	{
		//IL_0055: Expected O, but got Ref
		if ((object)textMeshPro != null)
		{
			Color color = textMeshPro.color;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			object obj = default(object);
			textMeshPro.color = (Color)(&obj);
			return textMeshPro;
		}
		return (TextMeshPro)(object)new NullReferenceException();
	}

	public unsafe static TextMeshProUGUI SetTint(TextMeshProUGUI textMeshPro, uint tint)
	{
		//IL_0055: Expected O, but got Ref
		if ((object)textMeshPro != null)
		{
			Color color = textMeshPro.color;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			object obj = default(object);
			textMeshPro.color = (Color)(&obj);
			return textMeshPro;
		}
		return (TextMeshProUGUI)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetFlipX(SpriteRenderer spriteRenderer, bool flipX)
	{
		if ((object)spriteRenderer != null)
		{
			spriteRenderer.flipX = flipX;
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetFlipY(SpriteRenderer spriteRenderer, bool flipY)
	{
		if ((object)spriteRenderer != null)
		{
			spriteRenderer.flipY = flipY;
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public unsafe static SpriteRenderer SetX(SpriteRenderer spriteRenderer, float x)
	{
		if ((object)spriteRenderer != null)
		{
			Transform transform = spriteRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Transform transform2 = spriteRenderer.transform;
				bool flag2 = (object)transform2 == null;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&ret));
				return spriteRenderer;
			}
		}
		throw new NullReferenceException();
	}

	public static SpriteRenderer SetY(SpriteRenderer spriteRenderer, float y)
	{
		if ((object)spriteRenderer != null)
		{
			Transform transform = spriteRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform transform2 = spriteRenderer.transform;
				bool flag2 = (object)transform2 == null;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
				return spriteRenderer;
			}
		}
		throw new NullReferenceException();
	}

	public static SpriteRenderer SetVisible(SpriteRenderer spriteRenderer, bool visible)
	{
		if ((object)spriteRenderer != null)
		{
			spriteRenderer.enabled = visible;
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetName(SpriteRenderer spriteRenderer, string name)
	{
		if ((object)spriteRenderer != null)
		{
			((UnityEngine.Object)spriteRenderer).SetName(name);
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetParent(SpriteRenderer spriteRenderer, Transform parent, bool keepWorldPos = true)
	{
		if ((object)spriteRenderer != null)
		{
			Transform transform = spriteRenderer.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, keepWorldPos);
				return spriteRenderer;
			}
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetAlpha(SpriteRenderer spriteRenderer, float alpha)
	{
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out Color _);
		bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value);
		return spriteRenderer;
	}

	public static SpriteRenderer SetBlendMode(SpriteRenderer spriteRenderer, VampireSurvivors.Framework.Particles.BlendMode blendMode)
	{
		MaterialType type;
		if (blendMode == VampireSurvivors.Framework.Particles.BlendMode.Add)
		{
			type = MaterialType.Vfx;
		}
		else
		{
			bool flag = blendMode != VampireSurvivors.Framework.Particles.BlendMode.Screen;
			type = MaterialType.DefaultSprite;
			if (!flag)
			{
				type = MaterialType.VfxScreen;
			}
		}
		Material material = MaterialManager.GetMaterial(type);
		if ((object)spriteRenderer != null)
		{
			((Renderer)spriteRenderer).SetMaterial(material);
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetTileMode(SpriteRenderer spriteRenderer)
	{
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, SpriteDrawMode.Tiled);
		bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.set_tileMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, SpriteTileMode.Continuous);
		return spriteRenderer;
	}

	public unsafe static SpriteRenderer SetTintFill(SpriteRenderer spriteRenderer, bool isEnabled, Color? tintColor = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0143->IL0104: Incompatible stack heights: 3 vs 1
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		IntPtr ptr = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock.m_Ptr = ptr;
		((Renderer)spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
		SetTintFillEnabled(materialPropertyBlock, isEnabled);
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, materialPropertyBlock.m_Ptr);
		if (isEnabled && (object)tintColor != null)
		{
			((Renderer)spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
			bool flag2 = (object)tintColor == null;
			object obj = default(object);
			SetTintFillColor(materialPropertyBlock, (Color)(&obj));
			bool flag3 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, materialPropertyBlock.m_Ptr);
		}
		return spriteRenderer;
	}

	public static SpriteRenderer SetTint(SpriteRenderer spriteRenderer, uint[] tints)
	{
		//IL_0083: Expected O, but got I4
		if (tints != null && tints.Length != 0)
		{
			object obj = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			bool flag = (nint)obj >= tints.Length;
			SpriteRenderer spriteRenderer2 = SetTint(spriteRenderer, tints[obj]);
			return spriteRenderer;
		}
		return spriteRenderer;
	}

	public unsafe static PhaserSprite SetTint(PhaserSprite target, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight, VampireSurvivors.Framework.Particles.BlendMode blendMode = VampireSurvivors.Framework.Particles.BlendMode.Normal)
	{
		//IL_002c: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		if ((object)target != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			object obj3 = default(object);
			Color bottomRight2 = default(Color);
			VampireSurvivors.Framework.Particles.BlendMode blendMode2 = default(VampireSurvivors.Framework.Particles.BlendMode);
			SpriteRenderer spriteRenderer = SetTint(target._spriteRenderer, (Color)(&obj), (Color)(&obj2), (Color)(&obj3), bottomRight2, blendMode2);
			return target;
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public unsafe static PhaserSprite SetTint(PhaserSprite target, uint topLeft, uint topRight, uint bottomLeft, uint bottomRight, VampireSurvivors.Framework.Particles.BlendMode blendMode = VampireSurvivors.Framework.Particles.BlendMode.Normal)
	{
		//IL_002c: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		if ((object)target != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			object obj3 = default(object);
			Color bottomRight2 = default(Color);
			VampireSurvivors.Framework.Particles.BlendMode blendMode2 = default(VampireSurvivors.Framework.Particles.BlendMode);
			SpriteRenderer spriteRenderer = SetTint(target._spriteRenderer, (Color)(&obj), (Color)(&obj2), (Color)(&obj3), bottomRight2, blendMode2);
			return target;
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public unsafe static SpriteRenderer SetTint(SpriteRenderer spriteRenderer, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight, VampireSurvivors.Framework.Particles.BlendMode blendMode)
	{
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_0226: Expected I4, but got O
		//IL_030d: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		//IL_03c3: Expected I4, but got O
		//IL_042f: Expected I4, but got O
		//IL_049b: Expected I4, but got O
		//IL_0507: Expected I4, but got O
		//IL_03cc->IL0287: Incompatible stack heights: 1 vs 0
		//IL_0438->IL0287: Incompatible stack heights: 2 vs 0
		//IL_04a4->IL0287: Incompatible stack heights: 3 vs 0
		//IL_0510->IL0287: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = obj2 - 1;
		bool flag = obj == null;
		bool flag2 = !flag;
		MaterialType type = (MaterialType)((flag2 ? 1 : 0) + 15);
		Material material = MaterialManager.GetMaterial(type);
		Material sharedMaterial;
		if ((object)spriteRenderer != null)
		{
			sharedMaterial = ((Renderer)spriteRenderer).GetSharedMaterial();
			if ((object)sharedMaterial == null || ((UnityEngine.Object)sharedMaterial).m_CachedPtr == (IntPtr)0)
			{
				goto IL_017a;
			}
			Shader shader = sharedMaterial.shader;
			if ((object)material != null)
			{
				Shader shader2 = material.shader;
				bool flag3 = (object)shader2 == null;
				bool flag4 = (object)shader == null;
				object obj3 = flag4 & flag3;
				bool flag5 = obj3 == null;
				object obj4 = !flag5;
				if (obj4 == null)
				{
					bool flag6;
					if ((object)shader2 != null)
					{
						if ((object)shader != null)
						{
							object obj5 = (object)shader - (object)shader2;
							flag6 = obj5 == null;
						}
						else
						{
							flag6 = ((UnityEngine.Object)shader2).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						if ((object)shader == null)
						{
							goto IL_0287;
						}
						flag6 = ((UnityEngine.Object)shader).m_CachedPtr == (IntPtr)0;
					}
					if (!flag6)
					{
						goto IL_017a;
					}
				}
				goto IL_01fd;
			}
		}
		goto IL_0287;
		IL_01fd:
		Material material2 = ((Renderer)spriteRenderer).GetMaterial();
		int name = Shader.PropertyToID("_ColorA");
		if ((int)(~material2) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v32 (UnityEngine.Material)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v32 (UnityEngine.Material)+10]");
			float value = default(float);
			Material.SetColorImpl_Injected((IntPtr)0, name, ref *(Color*)(&value));
			Material material3 = ((Renderer)spriteRenderer).GetMaterial();
			int name2 = Shader.PropertyToID("_ColorB");
			if ((int)(~material3) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rax_v39 (UnityEngine.Material)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rax_v39 (UnityEngine.Material)+10]");
				Material.SetColorImpl_Injected((IntPtr)0, name2, ref *(Color*)(&value));
				Material material4 = ((Renderer)spriteRenderer).GetMaterial();
				int name3 = Shader.PropertyToID("_ColorC");
				if ((int)(~material4) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ rax_v46 (UnityEngine.Material)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ rax_v46 (UnityEngine.Material)+10]");
					Material.SetColorImpl_Injected((IntPtr)0, name3, ref *(Color*)(&value));
					Material material5 = ((Renderer)spriteRenderer).GetMaterial();
					int name4 = Shader.PropertyToID("_ColorD");
					if ((int)(~material5) == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v53 (UnityEngine.Material)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v53 (UnityEngine.Material)+10]");
						Material.SetColorImpl_Injected((IntPtr)0, name4, ref *(Color*)(&value));
						Material material6 = ((Renderer)spriteRenderer).GetMaterial();
						int name5 = Shader.PropertyToID("_ApplyTint");
						if ((int)(~material6) == 0)
						{
							material6.SetFloatImpl(name5, 1f);
							return spriteRenderer;
						}
					}
				}
			}
		}
		goto IL_0287;
		IL_017a:
		((Renderer)spriteRenderer).SetMaterial(material);
		if ((object)sharedMaterial != null && ((UnityEngine.Object)sharedMaterial).m_CachedPtr != (IntPtr)0)
		{
			int instanceID = sharedMaterial.GetInstanceID();
			if (instanceID < 0)
			{
				UnityEngine.Object.Destroy(sharedMaterial);
			}
		}
		goto IL_01fd;
		IL_0287:
		throw new NullReferenceException();
	}

	public static SpriteRenderer FillStyle(SpriteRenderer spriteRenderer, uint tint, float alpha)
	{
		SpriteRenderer spriteRenderer2 = SetTint(spriteRenderer, tint);
		SpriteRenderer spriteRenderer3 = SetAlpha(spriteRenderer, alpha);
		return spriteRenderer;
	}

	public unsafe static SpriteRenderer FillCircle(SpriteRenderer spriteRenderer, int radius, uint colourHex = 16777215u)
	{
		//IL_008c: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		//IL_030d: Expected O, but got Ref
		//IL_00f4: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0118: Invalid comparison between O and F4
		//IL_018b: Expected O, but got Ref
		//IL_0141: Expected O, but got Ref
		//IL_0167: Expected F4, but got I4
		Sprite sprite2;
		if (s_circleCache != null)
		{
			int num = s_circleCache.FindEntry(radius);
			if (num < 0)
			{
				int num2 = default(int);
				Texture2D texture2D = new Texture2D(num2, num2);
				num2 = radius + radius;
				int num3 = (int)colourHex >> 16;
				float num4 = (float)num3 / 255f;
				object obj = radius * radius;
				if ((object)texture2D != null)
				{
					int num5 = radius;
					int num6 = 0;
					float num7 = num4;
					int num8 = 0;
					while (true)
					{
						int width = texture2D.width;
						if (num8 >= width)
						{
							break;
						}
						int num9 = radius;
						int num10 = 0;
						while (true)
						{
							int height = texture2D.height;
							if (num10 >= height)
							{
								break;
							}
							object obj2 = num5 * num5;
							object obj3 = num9 * num9;
							float num11 = (float)obj2 + (float)obj3;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num11))
							{
								texture2D.SetPixel(num6, num10, (Color)(&num7));
								int num12 = num10 + 1;
								num9--;
								num7 = 0f;
								num10 = num12;
							}
							else
							{
								texture2D.SetPixel(num6, num10, (Color)(&num7));
								int num13 = num10 + 1;
								num9--;
								num7 = num4;
								num10 = num13;
							}
						}
						num6++;
						num5--;
						num8 = num6;
					}
					texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
					int width2 = texture2D.width;
					int height2 = texture2D.height;
					int num14 = default(int);
					Vector2 pivot = default(Vector2);
					uint extrude = default(uint);
					SpriteMeshType meshType = default(SpriteMeshType);
					Vector4 border = default(Vector4);
					bool generateFallbackPhysicsShape = default(bool);
					Sprite sprite = Sprite.Create(texture2D, (Rect)(&num14), pivot, 100f, extrude, meshType, border, generateFallbackPhysicsShape, (SecondarySpriteTexture[])1);
					if (s_circleCache != null)
					{
						bool flag = ((Dictionary<int, object>)(object)s_circleCache).TryInsert(radius, (object)sprite, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						sprite2 = sprite;
						goto IL_032f;
					}
				}
			}
			else if (s_circleCache != null)
			{
				Sprite sprite3 = s_circleCache.get_Item(radius);
				sprite2 = sprite3;
				goto IL_032f;
			}
		}
		goto IL_0277;
		IL_0277:
		return (SpriteRenderer)(object)new NullReferenceException();
		IL_032f:
		if ((object)spriteRenderer != null)
		{
			spriteRenderer.sprite = sprite2;
			return spriteRenderer;
		}
		goto IL_0277;
	}

	private unsafe static Texture2D GenerateCircle(Texture2D tex, int x, int y, int r, Color color)
	{
		//IL_0012: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_0115: Expected O, but got Ref
		//IL_00cb: Expected O, but got Ref
		//IL_00f0: Expected O, but got I4
		Color color2 = (Color)(r * r);
		if ((object)tex != null)
		{
			int num = 0;
			int num2 = 0;
			int num3 = x;
			object obj4 = default(object);
			object obj5 = default(object);
			while (true)
			{
				int width = tex.width;
				if (num >= width)
				{
					break;
				}
				int num4 = y;
				int num5 = 0;
				while (true)
				{
					int height = tex.height;
					if (num5 >= height)
					{
						break;
					}
					object obj = num3 * num3;
					object obj2 = num4 * num4;
					object obj3 = obj + obj2;
					if (System.Runtime.CompilerServices.Unsafe.As<Color, UIntPtr>(ref color2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
					{
						tex.SetPixel(num2, num5, (Color)(&obj4));
						int num6 = num5 + 1;
						num4--;
						obj4 = 0;
						num5 = num6;
					}
					else
					{
						tex.SetPixel(num2, num5, (Color)(&obj4));
						int num7 = num5 + 1;
						num4--;
						obj4 = obj5;
						num5 = num7;
					}
				}
				num2++;
				num3--;
				num = num2;
			}
			return tex;
		}
		return (Texture2D)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetTint(SpriteRenderer spriteRenderer, uint tint)
	{
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out Color _);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value);
		return spriteRenderer;
	}

	public unsafe static SpriteRenderer SetTint(SpriteRenderer spriteRenderer, string tintString)
	{
		//IL_0073->IL0039: Incompatible stack heights: 1 vs 0
		if (ColorUtility.DoTryParseHtmlColor(tintString, out Color32 _))
		{
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)(&value));
		}
		return spriteRenderer;
	}

	public static void SetTint(SpriteRenderer spriteRenderer, Color? tint)
	{
		//IL_0061->IL0061: Incompatible stack heights: 1 vs 0
		if ((object)tint != null)
		{
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value);
		}
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, float x, float y, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddSprite(gameObject, x, y, textureName, spriteName);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, float x, float y, SpriteTextureData sprite)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			string spriteName = default(string);
			return AddSprite(gameObject, x, y, sprite.Texture, spriteName);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, Vector2 pos, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddSprite(gameObject, pos, textureName, spriteName);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, Vector2 pos, SpriteTextureData sprite)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddSprite(gameObject, pos, sprite.Texture, sprite.Sprite);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, float x, float y, string textureName = null, string spriteName = null)
	{
		Vector2 pos = default(Vector2);
		string spriteName2 = default(string);
		return AddSprite(gameObject, pos, textureName, spriteName2);
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, float x, float y, SpriteTextureData sprite)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 56 Invalid \"Jump target not found in method: 0x186C0D5E0\"");
		SpriteRenderer result = default(SpriteRenderer);
		return result;
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, Vector2 pos, string textureName, string spriteName)
	{
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "SubSpriteRenderer");
		SpriteRenderer spriteRenderer;
		Sprite unpackedSprite;
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					spriteRenderer = gameObject2.AddComponent<SpriteRenderer>();
					Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
					bool flag3 = (object)spriteRenderer == null;
					((Renderer)spriteRenderer).SetMaterial(material);
					if (textureName == null || textureName._stringLength <= 0)
					{
						if (spriteName == null || spriteName._stringLength <= 0)
						{
							goto IL_01ef;
						}
						if (textureName == null || textureName._stringLength <= 0)
						{
							unpackedSprite = SpriteManager.GetUnpackedSprite(spriteName);
							goto IL_01dd;
						}
					}
					unpackedSprite = SpriteManager.GetSprite(spriteName, textureName);
					goto IL_01dd;
				}
			}
		}
		throw new NullReferenceException();
		IL_01dd:
		spriteRenderer.sprite = unpackedSprite;
		goto IL_01ef;
		IL_01ef:
		return spriteRenderer;
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, float x, float y, Vector2 pivot, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			Vector2 pos = default(Vector2);
			string textureName2 = default(string);
			return AddSprite(gameObject, pos, pivot, textureName2, textureName);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, float x, float y, Vector2 pivot, SpriteTextureData sprite)
	{
		//IL_0038: Expected O, but got I
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_28+8]");
			Vector2 pos = default(Vector2);
			return AddSprite(gameObject, pos, pivot, (string)0, (string)sprite);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, float x, float y, Vector2 pivot, string textureName = null, string spriteName = null)
	{
		Vector2 pos = default(Vector2);
		string textureName2 = default(string);
		return AddSprite(gameObject, pos, pivot, textureName2, textureName);
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, float x, float y, Vector2 pivot, SpriteTextureData sprite)
	{
		//IL_0026: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_28+8]");
		Vector2 pos = default(Vector2);
		return AddSprite(gameObject, pos, pivot, (string)0, (string)sprite);
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, Vector2 pos, Vector2 pivot, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddSprite(gameObject, pos, pivot, textureName, spriteName);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(MonoBehaviour behaviour, Vector2 pos, Vector2 pivot, SpriteTextureData sprite)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			string spriteName = default(string);
			return AddSprite(gameObject, pos, pivot, sprite.Texture, spriteName);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, Vector2 pos, Vector2 pivot, SpriteTextureData sprite)
	{
		string spriteName = default(string);
		return AddSprite(gameObject, pos, pivot, sprite.Texture, spriteName);
	}

	public static SpriteRenderer AddSprite(GameObject gameObject, Vector2 pos, Vector2 pivot, string textureName = null, string spriteName = null)
	{
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "SpriteRenderer");
		SpriteRenderer spriteRenderer;
		Sprite unpackedSprite;
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					spriteRenderer = gameObject2.AddComponent<SpriteRenderer>();
					Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
					bool flag3 = (object)spriteRenderer == null;
					((Renderer)spriteRenderer).SetMaterial(material);
					string text = default(string);
					if (textureName == null || textureName._stringLength <= 0)
					{
						if (text == null || text._stringLength <= 0)
						{
							goto IL_01f2;
						}
						if (textureName == null || textureName._stringLength <= 0)
						{
							unpackedSprite = SpriteManager.GetUnpackedSprite(text, pivot);
							goto IL_01e0;
						}
					}
					unpackedSprite = SpriteManager.GetSprite(text, pivot, textureName);
					goto IL_01e0;
				}
			}
		}
		throw new NullReferenceException();
		IL_01e0:
		spriteRenderer.sprite = unpackedSprite;
		goto IL_01f2;
		IL_01f2:
		return spriteRenderer;
	}

	public static ArcadeSprite SetParent(ArcadeSprite arcadeSprite, Transform parent, bool keepWorldPos = true)
	{
		if ((object)arcadeSprite != null)
		{
			Transform transform = arcadeSprite.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, keepWorldPos);
				return arcadeSprite;
			}
		}
		return (ArcadeSprite)(object)new NullReferenceException();
	}

	public static ArcadeSprite AddArcadeSprite(MonoBehaviour behaviour, Vector2 pos, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddArcadeSprite(gameObject, pos, textureName, spriteName);
		}
		return (ArcadeSprite)(object)new NullReferenceException();
	}

	public static ArcadeSprite AddArcadeSprite(MonoBehaviour behaviour, Vector2 pos, SpriteTextureData sprite)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddArcadeSprite(gameObject, pos, sprite.Texture, sprite.Sprite);
		}
		return (ArcadeSprite)(object)new NullReferenceException();
	}

	public static ArcadeSprite AddArcadeSprite(GameObject gameObject, Vector2 pos, SpriteTextureData sprite)
	{
		return AddArcadeSprite(gameObject, pos, sprite.Texture, sprite.Sprite);
	}

	public static ArcadeSprite AddArcadeSprite(GameObject gameObject, Vector2 pos, string textureName, string spriteName)
	{
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "ArcadeSprite");
		ArcadeSprite arcadeSprite;
		Sprite unpackedSprite;
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					arcadeSprite = gameObject2.AddComponent<ArcadeSprite>();
					GameObject gameObject3 = new GameObject();
					GameObject.Internal_CreateGameObject(gameObject3, "SpriteRenderer");
					bool flag3 = (object)gameObject3 == null;
					Transform transform3 = gameObject3.transform;
					bool flag4 = (object)transform3 == null;
					transform3.parent = transform;
					SpriteRenderer spriteRenderer = gameObject3.AddComponent<SpriteRenderer>();
					Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
					bool flag5 = (object)spriteRenderer == null;
					((Renderer)spriteRenderer).SetMaterial(material);
					bool flag6 = (object)arcadeSprite == null;
					arcadeSprite.CheckRenderer();
					PhaserScene s_scene = ArcadePhysics.s_scene;
					bool flag7 = ArcadePhysics.s_scene == null;
					ArcadePhysics physics = s_scene.physics;
					bool flag8 = (object)s_scene.physics == null;
					Factory add = physics.add;
					bool flag9 = physics.add == null;
					bool flag10 = add._world == null;
					PhaserGameObject phaserGameObject = add._world.enableBody(arcadeSprite);
					if (textureName == null || textureName._stringLength <= 0)
					{
						if (spriteName == null || spriteName._stringLength <= 0)
						{
							goto IL_031a;
						}
						if (textureName == null || textureName._stringLength <= 0)
						{
							unpackedSprite = SpriteManager.GetUnpackedSprite(spriteName);
							goto IL_0304;
						}
					}
					unpackedSprite = SpriteManager.GetSprite(spriteName, textureName);
					goto IL_0304;
				}
			}
		}
		throw new NullReferenceException();
		IL_0304:
		ArcadeSprite arcadeSprite2 = arcadeSprite.setFrame(unpackedSprite);
		goto IL_031a;
		IL_031a:
		return arcadeSprite;
	}

	public static PhaserText text(Factory behaviour, Vector2 pos, string text, Color color, float fontSize = 12f)
	{
		//IL_018e: Expected O, but got I
		//IL_00bd: Expected O, but got I
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PhaserText");
		Transform transform = gameObject.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		PhaserText phaserText = gameObject.AddComponent<PhaserText>();
		bool flag4 = (object)phaserText == null;
		phaserText.EnsureTextRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29ED]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserText phaserText2 = phaserText.SetFont("Courier_HintedSmooth SDF8");
		PhaserText phaserText3 = phaserText.SetText(text);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v33 (VampireSurvivors.Framework.Phaser.PhaserText)+28]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v33 (VampireSurvivors.Framework.Phaser.PhaserText)+28]");
		bool flag5 = (nint)0 == 0;
		object obj2 = obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v589 @ rax_v38+2A8] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v33 (VampireSurvivors.Framework.Phaser.PhaserText)+28]");
		bool flag6 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v33 (VampireSurvivors.Framework.Phaser.PhaserText)+28]");
		float fontSize2 = default(float);
		((TMP_Text)0).fontSize = fontSize2;
		return phaserText;
	}

	public unsafe static BitmapText bitmapText(Factory behaviour, Vector2 pos, string text, Color color, int fontSize = 12)
	{
		//IL_0078: Expected O, but got I
		//IL_0088: Expected O, but got I
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "BitmapText");
		Transform transform = gameObject.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		BitmapText bitmapText = gameObject.AddComponent<BitmapText>();
		bool flag4 = (object)bitmapText == null;
		bitmapText.EnsureTextRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v40 (VampireSurvivors.Framework.Phaser.BitmapText)+28]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v40 (VampireSurvivors.Framework.Phaser.BitmapText)+28]");
		((TextMesh)0).text = text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v40 (VampireSurvivors.Framework.Phaser.BitmapText)+28]");
		GameObject gameObject2 = (GameObject)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v40 (VampireSurvivors.Framework.Phaser.BitmapText)+28]");
		bool flag6 = (nint)0 == 0;
		bool flag7 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
		float value3 = default(float);
		TextMesh.set_color_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, ref *(Color*)(&value3));
		return bitmapText;
	}

	public static PhaserSprite sprite(Factory behaviour, Vector2 pos, string textureName, string spriteName)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PhaserSprite");
		Transform transform = gameObject.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		PhaserSprite phaserSprite = gameObject.AddComponent<PhaserSprite>();
		bool flag4 = (object)phaserSprite == null;
		phaserSprite.EnsureSpriteRenderer();
		Sprite frame = ((textureName == null || textureName._stringLength <= 0) ? SpriteManager.GetUnpackedSprite(spriteName) : SpriteManager.GetSprite(spriteName, textureName));
		PhaserSprite phaserSprite2 = phaserSprite.setFrame(frame);
		return phaserSprite;
	}

	public static PhaserSprite sprite(Factory behaviour, Vector2 pos, SpriteTextureData spriteData)
	{
		return sprite(behaviour, pos, spriteData.Texture, spriteData.Sprite);
	}

	public static PhaserSprite circle(Factory behaviour, Vector2 pos, int radius, uint colour)
	{
		//IL_00a6: Expected O, but got I
		if (radius <= 0)
		{
			int num = default(int);
			string text = num.ToString();
			string message = "Radius for circle function is " + text;
			Debug.LogWarning(message);
		}
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PhaserCircleSprite");
		Transform transform = gameObject.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		PhaserSprite phaserSprite = gameObject.AddComponent<PhaserSprite>();
		bool flag4 = (object)phaserSprite == null;
		phaserSprite.EnsureSpriteRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v34 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
		SpriteRenderer spriteRenderer = FillCircle((SpriteRenderer)0, radius);
		return phaserSprite;
	}

	public static PhaserSprite AddPhaserSprite(MonoBehaviour behaviour, Vector2 pos, string textureName, string spriteName)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddPhaserSprite(gameObject, pos, textureName, spriteName);
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public static PhaserSprite AddPhaserSprite(MonoBehaviour behaviour, Vector2 pos, SpriteTextureData sprite)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddPhaserSprite(gameObject, pos, sprite.Texture, sprite.Sprite);
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public static PhaserSprite AddPhaserSprite(GameObject gameObject, Vector2 pos, SpriteTextureData sprite)
	{
		return AddPhaserSprite(gameObject, pos, sprite.Texture, sprite.Sprite);
	}

	public static PhaserSprite AddPhaserSprite(GameObject gameObject, Vector2 pos, string textureName, string spriteName)
	{
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "PhaserSprite");
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					PhaserSprite phaserSprite = gameObject2.AddComponent<PhaserSprite>();
					bool flag3 = (object)phaserSprite == null;
					phaserSprite.EnsureSpriteRenderer();
					Sprite frame = SpriteManager.GetSprite(spriteName, textureName);
					PhaserSprite phaserSprite2 = phaserSprite.setFrame(frame);
					return phaserSprite;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static PhaserSprite AddPhaserSpriteOfType<T>(MonoBehaviour behaviour, Vector2 pos, string textureName, string spriteName) where T : PhaserSprite
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			return AddPhaserSprite(gameObject, pos, textureName, spriteName);
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public static T AddPhaserSpriteOfType<T>(GameObject gameObject, Vector2 pos, string textureName, string spriteName) where T : PhaserSprite
	{
		//IL_0196: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "PhaserSprite");
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183040620");
					string text = default(string);
					bool flag3 = text == null;
					((PhaserSprite)(object)text).EnsureSpriteRenderer();
					Sprite frame = SpriteManager.GetSprite(spriteName, textureName);
					PhaserSprite phaserSprite = ((PhaserSprite)(object)text).setFrame(frame);
					return (T)(object)text;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static SpriteRenderer AddGraphic(MonoBehaviour behaviour)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			Vector2 pos = default(Vector2);
			return AddGraphic(gameObject, pos);
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddGraphic(MonoBehaviour behaviour, Vector2 pos)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 58 Invalid \"Jump target not found in method: 0x186C0FC10\"");
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer AddGraphic(GameObject gameObject, Vector2 pos)
	{
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "Graphic");
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					return gameObject2.AddComponent<SpriteRenderer>();
				}
			}
		}
		throw new NullReferenceException();
	}

	public static TileSprite AddTileSprite(MonoBehaviour behaviour, float x, float y, float width, float height, string textureName, string spriteName)
	{
		//IL_0012: Expected O, but got F4
		TileSpriteBuilder tileSpriteBuilder = new TileSpriteBuilder();
		if (tileSpriteBuilder != null)
		{
			tileSpriteBuilder._pos = (Vector2)x;
			string text = default(string);
			bool flag = text != null;
			string spriteName2 = text;
			string text2 = default(string);
			if (!flag)
			{
				spriteName2 = text2;
			}
			TileSpriteBuilder tileSpriteBuilder2 = tileSpriteBuilder.SetSpriteInfo(text2, spriteName2);
			float tileHeight = default(float);
			tileSpriteBuilder._tileHeight = tileHeight;
			tileSpriteBuilder._tileWidth = width;
			if ((object)behaviour != null)
			{
				Transform transform = behaviour.transform;
				tileSpriteBuilder._parent = transform;
				return tileSpriteBuilder.Build();
			}
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public static TileSpriteBuilder AddTileSprite(MonoBehaviour behaviour, float x, float y, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 66 Invalid \"Jump target not found in method: 0x186C10060\"");
		}
		return (TileSpriteBuilder)(object)new NullReferenceException();
	}

	public static TileSpriteBuilder AddTileSprite(GameObject go, float x, float y, string textureName, string spriteName)
	{
		//IL_0012: Expected O, but got F4
		TileSpriteBuilder tileSpriteBuilder = new TileSpriteBuilder();
		if (tileSpriteBuilder != null)
		{
			tileSpriteBuilder._pos = (Vector2)x;
			string spriteName2 = default(string);
			TileSpriteBuilder tileSpriteBuilder2 = tileSpriteBuilder.SetSpriteInfo(textureName, spriteName2);
			if ((object)go != null)
			{
				Transform transform = go.transform;
				tileSpriteBuilder._parent = transform;
				return tileSpriteBuilder;
			}
		}
		return (TileSpriteBuilder)(object)new NullReferenceException();
	}

	public static TileSprite SetTexture(TileSprite tileSprite, string texture)
	{
		if ((object)tileSprite != null)
		{
			Sprite unpackedSprite = SpriteManager.GetUnpackedSprite(texture);
			if ((object)tileSprite._spriteRenderer != null)
			{
				tileSprite._spriteRenderer.sprite = unpackedSprite;
				return tileSprite;
			}
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public static TileSprite SetAlpha(TileSprite tileSprite, float alpha)
	{
		if ((object)tileSprite != null)
		{
			SpriteRenderer spriteRenderer = SetAlpha(tileSprite._spriteRenderer, alpha);
			return tileSprite;
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public static TileSprite SetTint(TileSprite tileSprite, uint tint)
	{
		if ((object)tileSprite != null)
		{
			SpriteRenderer spriteRenderer = SetTint(tileSprite._spriteRenderer, tint);
			return tileSprite;
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public unsafe static TileSprite SetTint(TileSprite tileSprite, Color32 tint)
	{
		//IL_001c: Expected O, but got Ref
		if ((object)tileSprite != null)
		{
			object obj = default(object);
			SetTint(tileSprite._spriteRenderer, (Color?)(object)(&obj));
			return tileSprite;
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public static TileSprite SetBlendMode(TileSprite tileSprite, VampireSurvivors.Framework.Particles.BlendMode blendMode)
	{
		if ((object)tileSprite != null)
		{
			MaterialType type;
			if (blendMode == VampireSurvivors.Framework.Particles.BlendMode.Add)
			{
				type = MaterialType.Vfx;
			}
			else
			{
				bool flag = blendMode != VampireSurvivors.Framework.Particles.BlendMode.Screen;
				type = MaterialType.DefaultSprite;
				if (!flag)
				{
					type = MaterialType.VfxScreen;
				}
			}
			Material material = MaterialManager.GetMaterial(type);
			if ((object)tileSprite._spriteRenderer != null)
			{
				((Renderer)tileSprite._spriteRenderer).SetMaterial(material);
				return tileSprite;
			}
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public static TextMesh SetAlpha(TextMesh textMesh, float alpha)
	{
		bool flag = ((UnityEngine.Object)textMesh).m_CachedPtr == (IntPtr)0;
		TextMesh.get_color_Injected(((UnityEngine.Object)textMesh).m_CachedPtr, out Color _);
		bool flag2 = ((UnityEngine.Object)textMesh).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		TextMesh.set_color_Injected(((UnityEngine.Object)textMesh).m_CachedPtr, ref value);
		return textMesh;
	}

	public static TextMesh SetTint(TextMesh textMesh, uint tint)
	{
		bool flag = ((UnityEngine.Object)textMesh).m_CachedPtr == (IntPtr)0;
		TextMesh.get_color_Injected(((UnityEngine.Object)textMesh).m_CachedPtr, out Color _);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		bool flag2 = ((UnityEngine.Object)textMesh).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		TextMesh.set_color_Injected(((UnityEngine.Object)textMesh).m_CachedPtr, ref value);
		return textMesh;
	}

	public static TextMesh SetDepth(TextMesh textMesh, int depth)
	{
		if ((object)textMesh != null)
		{
			Renderer component = textMesh.GetComponent<Renderer>();
			if ((object)component != null)
			{
				component.sortingOrder = depth;
				return textMesh;
			}
		}
		return (TextMesh)(object)new NullReferenceException();
	}

	public static void SetDepth(TrailRenderer trailRenderer, int depth)
	{
		trailRenderer.sortingOrder = depth;
	}

	public static void SetVisible(TrailRenderer trailRenderer, bool visible)
	{
		trailRenderer.enabled = visible;
	}

	public static void SetDepthMultiplied(TrailRenderer trailRenderer, float depth, float mul = 100f)
	{
		float num = depth * mul;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		trailRenderer.sortingOrder = sortingOrder;
	}

	public static void SetDepth(TilemapRenderer tilemapRenderer, int depth)
	{
		tilemapRenderer.sortingOrder = depth;
	}

	public static void SetBlendMode(ParticleSystem pfx, VampireSurvivors.Framework.Particles.BlendMode blendMode)
	{
		//IL_0069: Expected O, but got I4
		object obj = blendMode - 1;
		bool type = obj == null;
		Material material = MaterialManager.GetMaterial(type ? MaterialType.ParticlesAdditive : MaterialType.Particles);
		ParticleSystemRenderer component = pfx.GetComponent<ParticleSystemRenderer>();
		Material material2 = ((Renderer)component).GetMaterial();
		Shader shader = material.shader;
		material2.shader = shader;
	}

	public static void SetDepth(ParticleSystem pfx, int depth)
	{
		ParticleSystemRenderer component = pfx.GetComponent<ParticleSystemRenderer>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.sortingOrder = depth;
		}
	}

	public static void SetDepthMultiplied(ParticleSystem pfx, float depth, float multiplier = 100f)
	{
		ParticleSystemRenderer component = pfx.GetComponent<ParticleSystemRenderer>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			float num = depth * multiplier;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			int sortingOrder = default(int);
			component.sortingOrder = sortingOrder;
		}
	}

	public static TextMeshPro SetDepth(TextMeshPro textMeshPro, int depth)
	{
		if ((object)textMeshPro != null)
		{
			textMeshPro.sortingOrder = depth;
			return textMeshPro;
		}
		return (TextMeshPro)(object)new NullReferenceException();
	}

	public static TextMeshPro SetDepthMultiplied(TextMeshPro textMeshPro, float depth, float multiplier = 100f)
	{
		float num = depth * multiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		if ((object)textMeshPro != null)
		{
			int sortingOrder = default(int);
			textMeshPro.sortingOrder = sortingOrder;
			return textMeshPro;
		}
		return (TextMeshPro)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetDepth(SpriteRenderer spriteRenderer, int depth)
	{
		if ((object)spriteRenderer != null)
		{
			spriteRenderer.sortingOrder = depth;
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	public static SpriteRenderer SetDepthMultiplied(SpriteRenderer spriteRenderer, float depth, float multiplier = 100f)
	{
		float num = depth * multiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		if ((object)spriteRenderer != null)
		{
			int sortingOrder = default(int);
			spriteRenderer.sortingOrder = sortingOrder;
			return spriteRenderer;
		}
		return (SpriteRenderer)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe static void SetDepthCached(SpriteRenderer spriteRenderer, int newDepth, ref int currentDepth)
	{
		if (newDepth != currentDepth)
		{
			ref int reference = ref *(int*)newDepth;
			spriteRenderer.sortingOrder = newDepth;
		}
	}

	public static T SetScrollFactor<T>(T component, float scrollFactor, bool fullscreen = false) where T : Component
	{
		//IL_0025: Invalid comparison between F4 and I4
		//IL_0494: Expected O, but got I4
		//IL_04ae: Expected O, but got I4
		//IL_0675: Expected O, but got I4
		//IL_068f: Expected O, but got I4
		//IL_0218: Expected I4, but got O
		//IL_0561: Expected O, but got I
		//IL_0571: Expected O, but got I
		//IL_0525->IL0437: Incompatible stack heights: 1 vs 0
		//IL_0268->IL0437: Incompatible stack heights: 1 vs 0
		//IL_01c0->IL0437: Incompatible stack heights: 1 vs 0
		//IL_05ae->IL0437: Incompatible stack heights: 1 vs 0
		//IL_054c->IL0437: Incompatible stack heights: 1 vs 0
		//IL_01e7->IL0437: Incompatible stack heights: 1 vs 0
		//IL_0205->IL0437: Incompatible stack heights: 1 vs 0
		//IL_0591->IL0437: Incompatible stack heights: 1 vs 0
		//IL_0645->IL0432: Incompatible stack heights: 4 vs 0
		//IL_023d->IL0437: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		Transform transform;
		if ((object)main != null)
		{
			transform = main.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000183116A15h\"");
			if (scrollFactor != 0f)
			{
				goto IL_02b3;
			}
			if ((object)component != null)
			{
				Transform transform2 = component.transform;
				if ((object)transform2 != null)
				{
					Transform parent = transform2.parent;
					bool flag = (object)parent == null;
					bool flag2 = (object)transform == null;
					object obj = flag2 & flag;
					bool flag3 = obj == null;
					object obj2 = !flag3;
					if (obj2 == null)
					{
						bool flag4;
						if ((object)transform != null)
						{
							if ((object)parent != null)
							{
								object obj3 = (object)parent - (object)transform;
								flag4 = obj3 == null;
							}
							else
							{
								flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							}
						}
						else
						{
							if ((object)parent == null)
							{
								goto IL_0437;
							}
							flag4 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
						}
						if (!flag4)
						{
							Transform transform3 = component.transform;
							if ((object)transform3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v55 (UnityEngine.Transform)+10]");
								bool flag5 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v55 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								Transform transform4 = component.transform;
								if ((object)transform4 != null)
								{
									transform4.SetParent(transform, worldPositionStays: false);
									if (!fullscreen)
									{
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
											{
												bool flag6 = (byte)(int)typeof(ArcadePhysics) != 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r8_v12 (System.Boolean)+B8]");
												object obj4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1342 @ rax_v89+10]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1342 @ rax_v89+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v90+28]");
													if ((nint)0 != 0)
													{
														goto IL_0596;
													}
												}
											}
										}
									}
									else
									{
										Camera main2 = Camera.main;
										if ((object)main2 != null)
										{
											int pixelWidth = main2.pixelWidth;
											int pixelHeight = main2.pixelHeight;
											bool flag6 = false;
											PhaserScene s_scene = null;
											goto IL_0596;
										}
									}
								}
							}
							goto IL_0437;
						}
					}
					goto IL_02b3;
				}
			}
		}
		goto IL_0437;
		IL_0596:
		if ((object)transform != null)
		{
			bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret2);
			Transform transform5 = component.transform;
			bool flag8 = (object)transform5 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rax_v69 (UnityEngine.Transform)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rax_v69 (UnityEngine.Transform)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref ret2);
			goto IL_0432;
		}
		goto IL_0437;
		IL_02b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000183116B3Dh\"");
		if (scrollFactor != 1f)
		{
			goto IL_0432;
		}
		if ((object)component != null)
		{
			Transform transform6 = component.transform;
			if ((object)transform6 != null)
			{
				Transform parent2 = transform6.parent;
				bool flag10 = (object)parent2 == null;
				bool flag11 = (object)transform == null;
				object obj6 = flag11 & flag10;
				bool flag12 = obj6 == null;
				object obj7 = !flag12;
				if (obj7 == null)
				{
					bool flag13;
					if ((object)transform != null)
					{
						if ((object)parent2 != null)
						{
							object obj8 = (object)parent2 - (object)transform;
							flag13 = obj8 == null;
						}
						else
						{
							flag13 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						if ((object)parent2 == null)
						{
							goto IL_0437;
						}
						flag13 = ((UnityEngine.Object)parent2).m_CachedPtr == (IntPtr)0;
					}
					if (!flag13)
					{
						goto IL_0432;
					}
				}
				Transform transform7 = component.transform;
				if ((object)transform7 != null)
				{
					transform7.SetParent(null, worldPositionStays: true);
					goto IL_0432;
				}
			}
		}
		goto IL_0437;
		IL_0432:
		return component;
		IL_0437:
		throw new NullReferenceException();
	}

	public static T setPositionPixelsScrollFactor0<T>(T component, float x, float y) where T : Component
	{
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)component != null)
				{
					Transform transform = component.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Transform transform2 = component.transform;
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						return component;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static TrailRendererPauseController AddPauseController(TrailRenderer trailRenderer)
	{
		//IL_00c3: Expected O, but got F4
		GameObject gameObject = trailRenderer.gameObject;
		bool flag = (object)gameObject == null;
		TrailRendererPauseController trailRendererPauseController;
		if (gameObject.TryGetComponent<TrailRendererPauseController>(out var component))
		{
			trailRendererPauseController = component;
		}
		else
		{
			TrailRendererPauseController trailRendererPauseController2 = gameObject.AddComponent<TrailRendererPauseController>();
			trailRendererPauseController = trailRendererPauseController2;
		}
		bool flag2 = ((UnityEngine.Object)trailRenderer).m_CachedPtr == (IntPtr)0;
		object obj = TrailRenderer.get_time_Injected(((UnityEngine.Object)trailRenderer).m_CachedPtr);
		trailRendererPauseController._trail = trailRenderer;
		float trailTime = default(float);
		trailRendererPauseController._trailTime = trailTime;
		return trailRendererPauseController;
	}

	public static void SetMaterialToPackedSprite(TrailRenderer trailRenderer, Sprite sprite, bool autoSetTrailWidth = true, bool additive = false)
	{
		//IL_0058->IL005d: Incompatible stack heights: 1 vs 0
		SetMaterialToPackedSpriteInternal(trailRenderer, sprite, additive);
		if (autoSetTrailWidth)
		{
			bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
			object obj = default(object);
			float endWidth = (trailRenderer.startWidth = (float)obj / 100f);
			trailRenderer.endWidth = endWidth;
		}
	}

	public static void SetMaterialToPackedSprite(LineRenderer lineRenderer, Sprite sprite, bool autoSetTrailWidth = true, bool additive = false)
	{
		//IL_0058->IL005d: Incompatible stack heights: 1 vs 0
		SetMaterialToPackedSpriteInternal(lineRenderer, sprite, additive);
		if (autoSetTrailWidth)
		{
			bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
			object obj = default(object);
			float endWidth = (lineRenderer.startWidth = (float)obj / 100f);
			lineRenderer.endWidth = endWidth;
		}
	}

	private unsafe static void SetMaterialToPackedSpriteInternal(Renderer trailRenderer, Sprite sprite, bool additive)
	{
		//IL_01ce: Expected O, but got Ref
		Shader shader3;
		if (!additive)
		{
			Shader shader = s_atlasRectTrailShader;
			if ((object)s_atlasRectTrailShader == null || ((UnityEngine.Object)shader).m_CachedPtr == (IntPtr)0)
			{
				Shader shader2 = Shader.Find("Custom/AtlasRectTrail");
				s_atlasRectTrailShader = shader2;
				int num = Shader.PropertyToID("_SpriteRect");
				s_atlasRectTrailRectPropertyID = num;
			}
			shader3 = s_atlasRectTrailShader;
		}
		else
		{
			Shader shader4 = s_atlasRectTrailAdditiveShader;
			if ((object)s_atlasRectTrailAdditiveShader == null || ((UnityEngine.Object)shader4).m_CachedPtr == (IntPtr)0)
			{
				Shader shader5 = Shader.Find("Custom/AtlasRectTrailAdditive");
				s_atlasRectTrailAdditiveShader = shader5;
				int num2 = Shader.PropertyToID("_SpriteRect");
				s_atlasRectTrailRectPropertyID = num2;
			}
			shader3 = s_atlasRectTrailAdditiveShader;
		}
		Material material = new Material(shader3);
		trailRenderer.SetMaterial(material);
		Material material2 = trailRenderer.GetMaterial();
		Texture2D texture = sprite.texture;
		material2.mainTexture = texture;
		bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		Texture2D texture2 = sprite.texture;
		int width = texture2.width;
		bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		Texture2D texture3 = sprite.texture;
		int height = texture3.height;
		bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		Texture2D texture4 = sprite.texture;
		int width2 = texture4.width;
		bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret4);
		Texture2D texture5 = sprite.texture;
		int height2 = texture5.height;
		Material material3 = trailRenderer.GetMaterial();
		material3.SetVector(s_atlasRectTrailRectPropertyID, (Vector4)(&ret4));
	}

	public static void ClearRenderTexture(RenderTexture renderTexture)
	{
		//IL_00b3: Expected F4, but got O
		RenderTexture active = RenderTexture.GetActive();
		IntPtr active_Injected = ((UnityEngine.Object)renderTexture)?.m_CachedPtr ?? ((IntPtr)0);
		RenderTexture.SetActive_Injected(active_Injected);
		Color backgroundColor = default(Color);
		object obj = default(object);
		GL.GLClear_Injected(true, true, ref backgroundColor, (float)obj);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag = (object)active == null;
		nint active_Injected2 = 0;
		if (!flag)
		{
			active_Injected2 = ((UnityEngine.Object)active).m_CachedPtr;
		}
		RenderTexture.SetActive_Injected((IntPtr)active_Injected2);
	}

	public static Image AddImage(MonoBehaviour behaviour, float x, float y, string textureName = null, string spriteName = null)
	{
		if ((object)behaviour != null)
		{
			GameObject gameObject = behaviour.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 66 Invalid \"Jump target not found in method: 0x186C11C00\"");
		}
		return (Image)(object)new NullReferenceException();
	}

	public static Image AddImage(GameObject gameObject, float x, float y, string textureName = null, string spriteName = null)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 56 Invalid \"Jump target not found in method: 0x186C11CA0\"");
		Image result = default(Image);
		return result;
	}

	public static Image AddImage(GameObject gameObject, Vector2 pos, string textureName, string spriteName)
	{
		//IL_013c->IL0153: Incompatible stack heights: 2 vs 0
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, "UIImage");
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					Image image = gameObject2.AddComponent<Image>();
					if ((textureName != null && textureName._stringLength > 0) || (spriteName != null && spriteName._stringLength > 0))
					{
						Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
						if ((object)image == null)
						{
							goto IL_0153;
						}
						image.sprite = sprite;
					}
					return image;
				}
			}
		}
		goto IL_0153;
		IL_0153:
		throw new NullReferenceException();
	}

	public unsafe static Image SetTint(Image image, uint tint)
	{
		//IL_0055: Expected O, but got Ref
		if ((object)image != null)
		{
			Color color = image.color;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			object obj = default(object);
			image.color = (Color)(&obj);
			return image;
		}
		return (Image)(object)new NullReferenceException();
	}

	static RenderingExtensions()
	{
		//IL_00c8: Expected I4, but got I8
		ParticleSystem.Particle[] cachedParticles = new ParticleSystem.Particle[1000];
		_cachedParticles = cachedParticles;
		int applyTint = Shader.PropertyToID("_ApplyTint");
		ApplyTint = applyTint;
		int tintColor = Shader.PropertyToID("_TintColor");
		TintColor = tintColor;
		int applyTintFill = Shader.PropertyToID("_ApplyTintFill");
		ApplyTintFill = applyTintFill;
		int tintFillColor = Shader.PropertyToID("_TintFillColor");
		TintFillColor = tintFillColor;
		Dictionary<int, Sprite> dictionary = new Dictionary<int, Sprite>();
		s_circleCache = dictionary;
		s_atlasRectTrailShader = null;
		s_atlasRectTrailAdditiveShader = null;
		s_atlasRectTrailRectPropertyID = -1;
	}
}
