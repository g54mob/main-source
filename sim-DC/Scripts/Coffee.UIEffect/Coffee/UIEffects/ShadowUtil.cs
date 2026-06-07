using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIEffects
{
	public static class ShadowUtil
	{
		public static Func<UIVertex, float, UIVertex> onMarkAsShadow;

		public static void DoShadow(List<UIVertex> verts, Vector2[] vectors, Vector2 distance, int iteration, float fade)
		{
		}

		public static void DoMirror(List<UIVertex> verts, Vector2 distance, float scale, float fade, RectTransform root)
		{
		}

		private static void ApplyMirror(List<UIVertex> verts, int count, float rate, Vector2 range, float scale, float offset, float alpha)
		{
		}

		private static void ApplyShadow(List<UIVertex> verts, Vector2[] vectors, ref int start, ref int end, Vector2 distance, float alpha)
		{
		}

		private static void ApplyShadowZeroAlloc(List<UIVertex> verts, ref int start, ref int end, float x, float y, float alpha)
		{
		}
	}
}
