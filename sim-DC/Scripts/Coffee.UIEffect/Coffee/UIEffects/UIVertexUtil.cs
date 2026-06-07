using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	internal static class UIVertexUtil
	{
		public static Func<UIVertex, UIVertex, UIVertex, float, UIVertex> onLerpVertex;

		public static void Flip(List<UIVertex> verts, bool horizontal, bool vertical)
		{
		}

		public static void Flip(VertexHelper vh, bool horizontal, bool vertical)
		{
		}

		public static void ExpandCapacity(List<UIVertex> verts, int multiplier)
		{
		}

		public static void Expand(List<UIVertex> verts, int start, int bundleSize, Vector4 expandSize, Rect bounds)
		{
		}

		public static UIVertex VertexLerp(UIVertex a, UIVertex b, float t)
		{
			return default(UIVertex);
		}

		public static void GetBounds(List<UIVertex> verts, int start, int bundleSize, out Rect posBounds, out Rect uvBounds)
		{
			posBounds = default(Rect);
			uvBounds = default(Rect);
		}
	}
}
