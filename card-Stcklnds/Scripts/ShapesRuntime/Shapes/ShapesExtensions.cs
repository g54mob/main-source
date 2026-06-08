using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal static class ShapesExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> elems, Action<T> action)
		{
			foreach (T elem in elems)
			{
				action(elem);
			}
		}

		public static Vector3 Rot90CCW(this Vector3 v)
		{
			return new Vector3(0f - v.y, v.x);
		}

		public static int AsInt(this bool b)
		{
			if (!b)
			{
				return 0;
			}
			return 1;
		}

		public static Vector4 ToVector4(this Rect r)
		{
			return new Vector4(r.x, r.y, r.width, r.height);
		}

		public static float TaxicabMagnitude(this Vector3 v)
		{
			return Mathf.Abs(v.x) + Mathf.Abs(v.y) + Mathf.Abs(v.z);
		}

		public static float AvgComponentMagnitude(this Vector3 v)
		{
			return (Mathf.Abs(v.x) + Mathf.Abs(v.y) + Mathf.Abs(v.z)) / 3f;
		}

		internal static Color ColorSpaceAdjusted(this Color c)
		{
			if (QualitySettings.activeColorSpace != ColorSpace.Linear)
			{
				return c;
			}
			return c.linear;
		}

		public static void DestroyBranched(this UnityEngine.Object obj)
		{
			UnityEngine.Object.Destroy(obj);
		}

		public static void TryDestroyInOnDestroy(this UnityEngine.Object caller, UnityEngine.Object obj)
		{
			if (!(obj == null))
			{
				UnityEngine.Object.Destroy(obj);
			}
		}

		public static int Product<T>(this IEnumerable<T> arr, Func<T, int> mulVal)
		{
			int num = 1;
			foreach (T item in arr)
			{
				num *= mulVal(item);
			}
			return num;
		}

		public static float Product<T>(this IEnumerable<T> arr, Func<T, float> mulVal)
		{
			float num = 1f;
			foreach (T item in arr)
			{
				num *= mulVal(item);
			}
			return num;
		}

		public static IEnumerable<TResult> Zip<T1, T2, T3, TResult>(this IEnumerable<T1> source, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> func)
		{
			using IEnumerator<T1> e1 = source.GetEnumerator();
			using IEnumerator<T2> e2 = second.GetEnumerator();
			using IEnumerator<T3> e3 = third.GetEnumerator();
			while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
			{
				yield return func(e1.Current, e2.Current, e3.Current);
			}
		}

		public static int PopCount(this uint i)
		{
			i -= (i >> 1) & 0x55555555;
			i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
			i = ((i + (i >> 4)) & 0xF0F0F0F) * 16843009 >> 24;
			return (int)i;
		}
	}
}
