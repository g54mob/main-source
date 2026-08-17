using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace PhaserPort;

public static class RenderingHelper
{
	private const float TargetRatio = 1.6f;

	public static float ScreenWidth
	{
		get
		{
			//IL_000e: Expected F4, but got I4
			return Screen.width;
		}
	}

	public static float ScreenHeight
	{
		get
		{
			//IL_000e: Expected F4, but got I4
			return Screen.height;
		}
	}

	public static float2 GetRendererSize()
	{
		//IL_001d: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0052: Expected O, but got F4
		//IL_005b: Invalid comparison between F4 and O
		object obj = Screen.width;
		object obj2 = Screen.height;
		object obj3 = obj / obj2;
		Camera main = Camera.main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj4 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
		}
		float2 result = default(float2);
		return result;
	}

	public static float2 GetRendererSizeIgnoringBorders()
	{
		//IL_004d: Expected O, but got F4
		//IL_0064: Expected O, but got F4
		Camera main = Camera.main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
		bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj2 = Camera.get_aspect_Injected(((UnityEngine.Object)main).m_CachedPtr);
		float2 result = default(float2);
		return result;
	}

	public static float2 GetCameraCenter()
	{
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				float2 result = default(float2);
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static bool IsTablet()
	{
		//IL_003f: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "[VampireSurvivors] OrientationSupport - IsTablet: {0}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		return false;
	}

	public unsafe static bool TryApplySavedOrientation()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0088: Expected native int or pointer, but got O
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01ca: Expected native int or pointer, but got O
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Ref, but got Unknown
		_ = 0;
		object obj2 = default(object);
		if (PlayerPrefs.HasKey("VS_SavedOrientation"))
		{
			int value = PlayerPrefs.GetInt("VS_SavedOrientation", 0);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			System.ParamsArray paramsArray = (System.ParamsArray)(obj2 - 80);
			_ = 0;
			_ = 0;
			object arg = default(object);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
			System.ParamsArray args = (System.ParamsArray)(obj2 - 48);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rsp-40]");
			_ = 0;
			string message = string.FormatHelper((IFormatProvider)null, "[SetupOrientations] Has saved orientation: {0}", args);
			Debug.Log(message);
			_ = 0;
			ReadOnlySpan<char> format = (ReadOnlySpan<char>)(obj2 - 80);
			string value2 = System.Number.FormatInt32(value, format, null);
			bool flag = Enum.TryParse<ScreenOrientation>(value2, ignoreCase: false, out *(ScreenOrientation*)(obj2 + 24));
			if (!flag)
			{
				return flag;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rsp+18]");
			Screen.orientation = ScreenOrientation.Unknown;
			return true;
		}
		object obj3 = obj2 + 24;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		System.ParamsArray paramsArray2 = (System.ParamsArray)(obj2 - 80);
		_ = 0;
		_ = 0;
		object arg2 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg2));
		System.ParamsArray args2 = (System.ParamsArray)(obj2 - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rsp-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rsp-40]");
		_ = 0;
		string message2 = string.FormatHelper((IFormatProvider)null, "[VampireSurvivors] OrientationSupport - IsTablet: {0}", args2);
		Debug.Log(message2);
		PlayerPrefs.SetInt("VS_SavedOrientation", 1);
		PlayerPrefs.Save();
		return false;
	}

	private static float2 UpdateRendererForPortrait()
	{
		//IL_0052: Expected O, but got F4
		//IL_0069: Expected O, but got F4
		//IL_00cd: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_008d: Invalid comparison between F4 and O
		Camera main = Camera.main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
		bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj2 = Camera.get_aspect_Injected(((UnityEngine.Object)main).m_CachedPtr);
		object obj3 = Screen.height;
		object obj4 = Screen.width;
		object obj5 = obj3 / obj4;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
		}
		float2 result = default(float2);
		return result;
	}

	private static float2 UpdateRendererForLandscape()
	{
		//IL_001d: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0052: Expected O, but got F4
		//IL_005b: Invalid comparison between F4 and O
		object obj = Screen.width;
		object obj2 = Screen.height;
		object obj3 = obj / obj2;
		Camera main = Camera.main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj4 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
		}
		float2 result = default(float2);
		return result;
	}
}
