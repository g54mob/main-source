using System;
using UnityEngine;

namespace Doozy.Engine.Extensions;

public static class RectTransformExtensions
{
	public unsafe static void Copy(RectTransform target, RectTransform from)
	{
		//IL_007e: Expected O, but got Ref
		bool flag = ((UnityEngine.Object)from).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)from).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
		Vector2 anchorMin = from.anchorMin;
		target.anchorMin = anchorMin;
		Vector2 anchorMax = from.anchorMax;
		target.anchorMax = anchorMax;
		Vector2 pivot = from.pivot;
		target.pivot = pivot;
		Vector2 sizeDelta = from.sizeDelta;
		target.sizeDelta = sizeDelta;
		Vector3 anchoredPosition3D = from.anchoredPosition3D;
		target.anchoredPosition3D = (Vector3)(&value);
	}

	public unsafe static void FullScreen(RectTransform target, bool resetScaleToOne)
	{
		//IL_0083: Expected O, but got Ref
		if (resetScaleToOne)
		{
			ResetLocalScaleToOne(target);
		}
		Vector2 vector = default(Vector2);
		target.anchorMin = vector;
		target.anchorMax = vector;
		target.pivot = vector;
		target.sizeDelta = vector;
		Vector3 value = default(Vector3);
		target.anchoredPosition3D = (Vector3)(&value);
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
	}

	public static void Center(RectTransform target, bool resetScaleToOne)
	{
		if (resetScaleToOne)
		{
			ResetLocalScaleToOne(target);
		}
		Vector2 vector = default(Vector2);
		target.anchorMin = vector;
		target.anchorMax = vector;
		target.pivot = vector;
		target.sizeDelta = vector;
	}

	public unsafe static void ResetAnchoredPosition3D(RectTransform target)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		target.anchoredPosition3D = (Vector3)(&obj);
	}

	public static void ResetLocalPosition(RectTransform target)
	{
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
	}

	public static void ResetLocalScaleToOne(RectTransform target)
	{
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
	}

	public static void AnchorMinToZero(RectTransform target)
	{
		Vector2 anchorMin = default(Vector2);
		target.anchorMin = anchorMin;
	}

	public static void AnchorMinToCenter(RectTransform target)
	{
		Vector2 anchorMin = default(Vector2);
		target.anchorMin = anchorMin;
	}

	public static void AnchorMaxToOne(RectTransform target)
	{
		Vector2 anchorMax = default(Vector2);
		target.anchorMax = anchorMax;
	}

	public static void AnchorMaxToCenter(RectTransform target)
	{
		Vector2 anchorMax = default(Vector2);
		target.anchorMax = anchorMax;
	}

	public static void CenterPivot(RectTransform target)
	{
		Vector2 pivot = default(Vector2);
		target.pivot = pivot;
	}

	public static void SizeDeltaToZero(RectTransform target)
	{
		Vector2 sizeDelta = default(Vector2);
		target.sizeDelta = sizeDelta;
	}
}
