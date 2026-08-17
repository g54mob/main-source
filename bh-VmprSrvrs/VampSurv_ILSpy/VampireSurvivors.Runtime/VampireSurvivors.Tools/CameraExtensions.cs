using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PhaserPort;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Graphics;

namespace VampireSurvivors.Tools;

public static class CameraExtensions
{
	private static Bounds _cachedCamBounds;

	public unsafe static Bounds OrthographicBounds(Camera camera)
	{
		//IL_00a0: Expected I, but got O
		//IL_00d6: Expected I, but got O
		//IL_00ff: Expected I, but got O
		//IL_0118: Expected native int or pointer, but got O
		if ((object)camera != null)
		{
			Transform transform = camera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Bounds ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				nint num = (nint)typeof(CameraExtensions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v16 (Il2CppClass<VampireSurvivors.Tools.CameraExtensions>)+B8]");
				nint num2 = 0;
				_cachedCamBounds = ret;
				_ = 0;
				float2 rendererSize = RenderingHelper.GetRendererSize();
				nint num3 = (nint)typeof(CameraExtensions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v19 (Il2CppClass<VampireSurvivors.Tools.CameraExtensions>)+B8]");
				nint num4 = 0;
				_ = 0;
				nint num5 = (nint)typeof(CameraExtensions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v20 (Il2CppClass<VampireSurvivors.Tools.CameraExtensions>)+B8]");
				nint num6 = 0;
				Bounds bounds = default(Bounds);
				((Bounds*)(nint)bounds)->m_Center = (Vector3)_cachedCamBounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v16 (Il2CppStaticFields<VampireSurvivors.Tools.CameraExtensions>)+10]");
				_ = 0;
				return bounds;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static Bounds OrthographicBoundsIgnoringBorders(Camera camera)
	{
		//IL_0099: Expected native int or pointer, but got O
		//IL_00ac: Expected native int or pointer, but got O
		float2 rendererSizeIgnoringBorders = RenderingHelper.GetRendererSizeIgnoringBorders();
		if ((object)camera != null)
		{
			Transform transform = camera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Bounds bounds = default(Bounds);
				((Bounds*)(nint)bounds)->m_Center = ret;
				_ = 0;
				Vector3 extents = default(Vector3);
				((Bounds*)(nint)bounds)->m_Extents = extents;
				_ = 0;
				return bounds;
			}
		}
		throw new NullReferenceException();
	}

	public static bool IsObjectVisible(Camera camera, Renderer renderer)
	{
		//IL_0033: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		Plane[] array = new Plane[6];
		GeometryUtility.CalculateFrustumPlanes(camera, array);
		bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
		Renderer.get_bounds_Injected(((UnityEngine.Object)renderer).m_CachedPtr, out Bounds _);
		object obj;
		if (array != null)
		{
			obj = array.Length;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			obj = 0;
		}
		if (obj != null)
		{
		}
		UnityEngine.Bindings.ManagedSpanWrapper planes = default(UnityEngine.Bindings.ManagedSpanWrapper);
		Bounds bounds = default(Bounds);
		return GeometryUtility.TestPlanesAABB_Injected(ref planes, ref bounds);
	}

	public static Vector2 GetScreenBounds(Camera camera, bool usePixels = false)
	{
		int2 renderTextureSize = GetRenderTextureSize(camera);
		Vector2 result = default(Vector2);
		if (usePixels)
		{
			return result;
		}
		return result;
	}

	public static float GetRtZoomScaling(Camera camera)
	{
		return 0.666875f;
	}

	public static int2 GetRenderTextureSize(Camera camera)
	{
		//IL_01ac: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_00a5: Invalid comparison between F4 and O
		//IL_0037: Invalid comparison between F4 and O
		//IL_0161: Expected O, but got F8
		object obj = Screen.width;
		object obj2 = Screen.height;
		float num2;
		float num3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			object obj3 = obj / obj2;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				float num = (float)obj3 * 684f;
				num2 = num;
				num3 = 684f;
			}
			else
			{
				num3 = 1094.4f / (float)obj3;
				num2 = 1094.4f;
			}
		}
		else
		{
			object obj4 = obj2 / obj;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				num3 = (float)obj4 * 684f;
				num2 = 684f;
			}
			else
			{
				num2 = 1094.4f / (float)obj4;
				num3 = 1094.4f;
			}
		}
		float num4 = num3 * 0.666875f;
		float num5 = num2 * 0.666875f;
		float num6 = num5 * 0.5f;
		double num7 = Math.Round(num6, 0, MidpointRounding.AwayFromZero);
		float num8 = num4 * 0.5f;
		double num9 = num7 + num7;
		double num10 = Math.Round(num8, 0, MidpointRounding.AwayFromZero);
		return (int2)num9;
	}

	public static void ResetOrthographicSize(Camera camera)
	{
		int2 renderTextureSize = GetRenderTextureSize(camera);
		object obj = (object)renderTextureSize >> 32;
		float num = (float)obj * 0.5f;
		float orthographicSize = num * 0.01f;
		camera.orthographicSize = orthographicSize;
	}

	public static void ResetOrthographicAndRenderTextureSize(Camera camera)
	{
		int2 renderTextureSize = GetRenderTextureSize(camera);
		object obj = (object)renderTextureSize >> 32;
		float num = (float)obj * 0.5f;
		float orthographicSize = num * 0.01f;
		camera.orthographicSize = orthographicSize;
		RenderTextureResizer component = camera.GetComponent<RenderTextureResizer>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.UpdateRT(force: true);
		}
	}
}
