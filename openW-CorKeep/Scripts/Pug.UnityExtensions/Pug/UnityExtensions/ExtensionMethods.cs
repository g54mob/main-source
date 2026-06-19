using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;
using UnityEngine.Audio;

namespace Pug.UnityExtensions
{
	public static class ExtensionMethods
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct _Int2Comparer : IComparer<int2>
		{
			public int Compare(int2 x, int2 y)
			{
				int num = x.y.CompareTo(y.y);
				return math.select(num, x.x.CompareTo(y.x), num == 0);
			}
		}

		public static _Int2Comparer Int2Comp => default(_Int2Comparer);

		public static void Recycle<T>(this List<T> list, int cap)
		{
			list.Clear();
			if (list.Capacity < cap)
			{
				list.Capacity = cap;
			}
		}

		public static void EnsureCapacity<T>(this List<T> list, int cap)
		{
			if (list.Capacity < cap)
			{
				list.Capacity = cap;
			}
		}

		public static void Fill<T>(this T[] array, T value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		public static V GetValueOrFallback<K, V>(this Dictionary<K, V> dict, K key, V fallback)
		{
			if (!dict.TryGetValue(key, out var value))
			{
				return fallback;
			}
			return value;
		}

		public static void Shuffle<T>(this IList<T> list)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int index = UnityEngine.Random.Range(0, num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
		}

		public static T RandomElement<T>(this IReadOnlyList<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static bool IsValidIndex<T>(this IReadOnlyList<T> list, int i)
		{
			if (i >= 0)
			{
				return i < list.Count;
			}
			return false;
		}

		public static T[] CopyToNewArraySize<T>(this T[] array, int newLength)
		{
			T[] array2 = new T[newLength];
			Array.Copy(array, array2, System.Math.Min(array.Length, array2.Length));
			return array2;
		}

		public static T NextEnumValue<T>(T src) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Argument " + typeof(T).FullName + " is not an Enum");
			}
			T[] array = (T[])Enum.GetValues(src.GetType());
			int num = Array.IndexOf(array, src) + 1;
			if (num != array.Length)
			{
				return array[num];
			}
			return array[0];
		}

		public static void RoundPosition2D(this Transform transform)
		{
			Vector3 position = transform.position;
			float x = Mathf.Round(position.x);
			float y = Mathf.Round(position.y);
			transform.position = new Vector3(x, y, position.z);
		}

		public static void RoundPosition(this Transform transform)
		{
			Vector3 position = transform.position;
			float x = Mathf.Round(position.x);
			float y = Mathf.Round(position.y);
			float z = Mathf.Round(position.z);
			transform.position = new Vector3(x, y, z);
		}

		public static void RoundLocalPosition2D(this Transform transform)
		{
			Vector3 localPosition = transform.localPosition;
			float x = Mathf.Round(localPosition.x);
			float y = Mathf.Round(localPosition.y);
			transform.position = new Vector3(x, y, localPosition.z);
		}

		public static Vector2 Position2D(this Transform transform)
		{
			return transform.position;
		}

		public static Vector2 LocalPosition2D(this Transform transform)
		{
			return transform.localPosition;
		}

		public static Vector2Int RoundedPosition2DInt(this Transform transform)
		{
			return ((Vector2)transform.position).RoundToInt();
		}

		public static Vector3Int RoundedPositionInt(this Transform transform)
		{
			return transform.position.RoundToInt();
		}

		public static Vector2Int RoundedLocalPosition2DInt(this Transform transform)
		{
			return ((Vector2)transform.localPosition).RoundToInt();
		}

		public static Vector3Int RoundedLocalPositionInt(this Transform transform)
		{
			return transform.localPosition.RoundToInt();
		}

		public static void SetLayerRecursive(this GameObject go, int newLayer)
		{
			go.layer = newLayer;
			foreach (Transform item in go.transform)
			{
				if (item != null)
				{
					item.gameObject.SetLayerRecursive(newLayer);
				}
			}
		}

		public static void ResetToIdentityLocal(this Transform transform)
		{
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}

		public static void SetPositionX(this Transform transform, float x)
		{
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}

		public static void SetPositionY(this Transform transform, float y)
		{
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}

		public static void SetPositionZ(this Transform transform, float z)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, z);
		}

		public static void SetRotationZ(this Transform transform, float z = 0f)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, z);
		}

		public static void SetLocalScale(this Transform transform, float x = 1f, float y = 1f, float z = 1f)
		{
			transform.localScale = new Vector3(x, y, z);
		}

		public static void SetLocalRotationZ(this Transform transform, float z = 0f)
		{
			Vector3 eulerAngles = transform.localRotation.eulerAngles;
			transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, z);
		}

		public static void SetLocalPosition(this Transform transform, float x = 0f, float y = 0f, float z = 0f)
		{
			transform.localPosition = new Vector3(x, y, z);
		}

		public static void SetLocalPositionX(this Transform transform, float x)
		{
			transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
		}

		public static void SetLocalPositionY(this Transform transform, float y)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
		}

		public static void SetLocalPositionZ(this Transform transform, float z)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
		}

		public static void SetPosition2D(this Transform transform, Vector2 v)
		{
			transform.position = new Vector3(v.x, v.y, transform.position.z);
		}

		public static void Scale(this Transform transform, float x = 1f, float y = 1f, float z = 1f)
		{
			Vector3 localScale = transform.localScale;
			transform.localScale = new Vector3(localScale.x * x, localScale.y * y, localScale.z * z);
		}

		public static Vector2 XZ(this Vector3 v3)
		{
			return new Vector2(v3.x, v3.z);
		}

		public static Vector3 X0Z(this Vector3 v3)
		{
			return new Vector3(v3.x, 0f, v3.z);
		}

		public static Vector3 X0Y(this Vector2 v2)
		{
			return new Vector3(v2.x, 0f, v2.y);
		}

		public static Vector3 XY0(this Vector2 v2)
		{
			return new Vector3(v2.x, v2.y, 0f);
		}

		public static float2 XZ(this float3 v3)
		{
			return new float2(v3.x, v3.z);
		}

		public static float3 X0Z(this float3 v3)
		{
			return new float3(v3.x, 0f, v3.z);
		}

		public static float3 X0Y(this float2 v2)
		{
			return new float3(v2.x, 0f, v2.y);
		}

		public static float3 XY0(this float2 v2)
		{
			return new float3(v2.x, v2.y, 0f);
		}

		public static Vector2 To2D(this Vector3 v3)
		{
			return v3;
		}

		public static float2 ToFloat2(this Vector3 v3)
		{
			return new float2(v3.x, v3.z);
		}

		public static float3 ToFloat3(this Vector3 v3)
		{
			return new float3(v3.x, v3.y, v3.z);
		}

		public static Vector3 To3D(this Vector2 v2)
		{
			return v2;
		}

		public static Vector2 Blend(this Vector2 a, Vector2 b, float blendFactor)
		{
			Vector2 vector = a * (1f - blendFactor);
			Vector2 vector2 = b * blendFactor;
			return (vector + vector2).normalized * a.magnitude;
		}

		public static Vector3 Blend(this Vector3 a, Vector3 b, float blendFactor)
		{
			Vector3 vector = a * (1f - blendFactor);
			Vector3 vector2 = b * blendFactor;
			return (vector + vector2).normalized * a.magnitude;
		}

		public static Vector2 Round(this Vector2 v)
		{
			return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
		}

		public static Vector3 Round(this Vector3 v)
		{
			return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
		}

		public static float RoundToMultiple(float v, float multiple)
		{
			return Mathf.Round(v / multiple) * multiple;
		}

		public static Vector2 RoundToMultiple(this Vector2 v, float multiple)
		{
			return new Vector2(RoundToMultiple(v.x, multiple), RoundToMultiple(v.y, multiple));
		}

		public static float2 RoundToMultiple(this float2 v, float multiple)
		{
			return new float2(RoundToMultiple(v.x, multiple), RoundToMultiple(v.y, multiple));
		}

		public static Vector3 RoundToMultiple(this Vector3 v, float multiple)
		{
			return new Vector3(RoundToMultiple(v.x, multiple), RoundToMultiple(v.y, multiple), RoundToMultiple(v.z, multiple));
		}

		public static float3 RoundToMultiple(this float3 v, float multiple)
		{
			return new float3(RoundToMultiple(v.x, multiple), RoundToMultiple(v.y, multiple), RoundToMultiple(v.z, multiple));
		}

		public static Vector3 RoundToMultipleXY(this Vector3 v, float multiple)
		{
			return new Vector3(RoundToMultiple(v.x, multiple), RoundToMultiple(v.y, multiple), v.z);
		}

		public static Vector3 RoundToMultipleXZ(this Vector3 v, float multiple)
		{
			return new Vector3(RoundToMultiple(v.x, multiple), v.y, RoundToMultiple(v.z, multiple));
		}

		public static Vector2Int To2D(this Vector3Int v)
		{
			return new Vector2Int(v.x, v.z);
		}

		public static Vector3Int To3D(this Vector2Int v)
		{
			return new Vector3Int(v.x, 0, v.y);
		}

		public static Vector2Int RoundToInt(this Vector2 v)
		{
			return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
		}

		public static Vector2Int FloorToInt(this Vector2 v)
		{
			return new Vector2Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y));
		}

		public static Vector3Int RoundToInt(this Vector3 v)
		{
			return new Vector3Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
		}

		public static Vector3Int FloorToInt(this Vector3 v)
		{
			return new Vector3Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z));
		}

		public static bool Approximately(this Vector2 a, Vector2 b)
		{
			if (Mathf.Approximately(a.x, b.x))
			{
				return Mathf.Approximately(a.y, b.y);
			}
			return false;
		}

		public static bool ApproximatelyCustomEpsilon(this Vector2 a, Vector2 b, float epsilon)
		{
			if (Mathf.Abs(b.x - a.x) < epsilon)
			{
				return Mathf.Abs(b.y - a.y) < epsilon;
			}
			return false;
		}

		public static float Atan2Degrees(this Vector2 a)
		{
			return Mathf.Atan2(a.y, a.x) * 57.29578f;
		}

		public static float AngleTo(this Vector2 a, Vector2 b)
		{
			Vector2 vector = b - a;
			return Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		}

		public static string ToStringHighPrecision(this Vector2 v2)
		{
			return $"({v2.x:F6}, {v2.y:F6})";
		}

		public static bool SameAxis(this Vector2Int a, Vector2Int b)
		{
			if (a.x != b.x)
			{
				return a.y == b.y;
			}
			return true;
		}

		public static Vector2 FlipY(this Vector2 a)
		{
			return new Vector2(a.x, 0f - a.y);
		}

		public static Vector2 Rotate90(this Vector2 a)
		{
			return new Vector2(a.y, 0f - a.x);
		}

		public static Vector2 Rotate90(this Vector2 a, Vector2 pivot)
		{
			return new Vector2(pivot.x + (a.y - pivot.y), pivot.y - (a.x - pivot.x));
		}

		public static int2 RoundToInt2(this Vector3 vec)
		{
			return (int2)math.round(new float2(vec.x, vec.z));
		}

		public static int2 ToInt2(this Vector2Int v)
		{
			return new int2(v.x, v.y);
		}

		public static float2 ToFloat2(this Vector2 v)
		{
			return new float2(v.x, v.y);
		}

		public static int2 ToInt2(this Vector3Int v)
		{
			return new int2(v.x, v.z);
		}

		public static float2 ToFloat2(this Vector3Int v)
		{
			return new float2(v.x, v.z);
		}

		public static float3 ToFloat3(this Vector3Int v)
		{
			return new float3(v.x, 0f, v.z);
		}

		[GenerateTestsForBurstCompatibility]
		public static float3 ToFloat3(this float2 x)
		{
			return new float3(x.x, 0f, x.y);
		}

		[GenerateTestsForBurstCompatibility]
		public static int2 RoundToInt2(this float2 x)
		{
			return (int2)math.round(x);
		}

		[GenerateTestsForBurstCompatibility]
		public static int2 RoundToInt2(this float3 x)
		{
			return (int2)math.round(new float2(x.x, x.z));
		}

		[GenerateTestsForBurstCompatibility]
		public static int2 FloorToInt2(this float3 x)
		{
			return (int2)math.floor(new float2(x.x, x.z));
		}

		[GenerateTestsForBurstCompatibility]
		public static float2 ToFloat2(this float3 x)
		{
			return new float2(x.x, x.z);
		}

		[GenerateTestsForBurstCompatibility]
		public static float2 ToFloat2(this int2 x)
		{
			return new float2(x.x, x.y);
		}

		[GenerateTestsForBurstCompatibility]
		public static float3 ToFloat3(this int2 x)
		{
			return new float3(x.x, 0f, x.y);
		}

		[GenerateTestsForBurstCompatibility]
		public static int2 ToInt2(this int3 x)
		{
			return new int2(x.x, x.z);
		}

		[GenerateTestsForBurstCompatibility]
		public static Vector2Int ToVec2Int(this int2 x)
		{
			return new Vector2Int(x.x, x.y);
		}

		[GenerateTestsForBurstCompatibility]
		public static Vector3Int ToVec3Int(this int2 x)
		{
			return new Vector3Int(x.x, 0, x.y);
		}

		[GenerateTestsForBurstCompatibility]
		public static int3 RoundToInt3(this float3 x)
		{
			return (int3)math.round(x);
		}

		[GenerateTestsForBurstCompatibility]
		public static int3 ToInt3(this int2 x)
		{
			return new int3(x.x, 0, x.y);
		}

		public static float3 Blend(this float3 a, float3 b, float blendFactor)
		{
			float3 obj = a * (1f - blendFactor);
			float3 float5 = b * blendFactor;
			return math.normalizesafe(obj + float5) * math.length(a);
		}

		public static RectInt FloorToRectInt(this Rect b)
		{
			return new RectInt(b.position.FloorToInt(), b.size.FloorToInt());
		}

		public static Rect ToRect(this RectInt b)
		{
			return new Rect(b.position, b.size);
		}

		public static RectInt Pad(this RectInt rect, RectInt padding)
		{
			if (rect.size == Vector2Int.zero)
			{
				return rect;
			}
			return new RectInt(rect.xMin + padding.xMin, rect.yMin + padding.yMin, rect.width + padding.width, rect.height + padding.height);
		}

		public static RectInt Pad(this RectInt rect, int padding)
		{
			return rect.Pad(new RectInt(-padding, -padding, 2 * padding, 2 * padding));
		}

		public static RectInt Fit(this RectInt rect, Vector2Int point)
		{
			if (rect.size == Vector2Int.zero)
			{
				return new RectInt(point, Vector2Int.one);
			}
			if (rect.Contains(point))
			{
				return rect;
			}
			return new RectInt
			{
				xMin = System.Math.Min(point.x, rect.xMin),
				yMin = System.Math.Min(point.y, rect.yMin),
				xMax = System.Math.Max(point.x + 1, rect.xMax),
				yMax = System.Math.Max(point.y + 1, rect.yMax)
			};
		}

		public static RectInt Fit(this RectInt rect, RectInt otherRect)
		{
			if (rect.size == Vector2Int.zero)
			{
				return otherRect;
			}
			if (otherRect.size == Vector2Int.zero)
			{
				return rect;
			}
			return new RectInt
			{
				xMin = System.Math.Min(otherRect.xMin, rect.xMin),
				yMin = System.Math.Min(otherRect.yMin, rect.yMin),
				xMax = System.Math.Max(otherRect.xMax, rect.xMax),
				yMax = System.Math.Max(otherRect.yMax, rect.yMax)
			};
		}

		public static RectInt Intersection(this RectInt rect, RectInt other)
		{
			if (other.size == Vector2Int.zero || rect.size == Vector2Int.zero || rect.FullyOutside(other))
			{
				return default(RectInt);
			}
			return new RectInt
			{
				xMin = System.Math.Max(rect.xMin, other.xMin),
				yMin = System.Math.Max(rect.yMin, other.yMin),
				xMax = System.Math.Min(rect.xMax, other.xMax),
				yMax = System.Math.Min(rect.yMax, other.yMax)
			};
		}

		public static bool FullyContains(this RectInt rect, RectInt other)
		{
			if (other.size == Vector2Int.zero)
			{
				return true;
			}
			if (rect.size == Vector2Int.zero)
			{
				return false;
			}
			if (rect.xMin <= other.xMin && rect.yMin <= other.yMin && rect.xMax >= other.xMax)
			{
				return rect.yMax >= other.yMax;
			}
			return false;
		}

		public static RectInt Scale(this RectInt rect, Vector2Int scale)
		{
			return new RectInt(rect.position * scale, rect.size * scale);
		}

		public static int RowMajorCell(this RectInt rect, int x, int y)
		{
			int num = x - rect.xMin;
			return (y - rect.yMin) * rect.width + num;
		}

		public static bool FullyOutside(this RectInt a, RectInt b)
		{
			if (b.xMin < a.xMax && b.xMax > a.xMin && b.yMin < a.yMax)
			{
				return b.yMax <= a.yMin;
			}
			return true;
		}

		public static Rect Grow(this Rect rect, float f)
		{
			rect.x -= f;
			rect.y -= f;
			rect.width += 2f * f;
			rect.height += 2f * f;
			return rect;
		}

		public static Rect Shrink(this Rect rect, float f)
		{
			return rect.Grow(0f - f);
		}

		public static Vector2 ProjectOnEdgeIfOutside(this Rect rect, Vector2 p)
		{
			if (p.x < rect.xMin)
			{
				p.x = rect.xMin;
			}
			if (p.x > rect.xMax)
			{
				p.x = rect.xMax;
			}
			if (p.y < rect.yMin)
			{
				p.y = rect.yMin;
			}
			if (p.y > rect.yMax)
			{
				p.y = rect.yMax;
			}
			return p;
		}

		public static BoundsInt FloorToBoundsInt(this Bounds b)
		{
			return new BoundsInt(Mathf.FloorToInt(b.min.x), Mathf.FloorToInt(b.min.y), Mathf.FloorToInt(b.min.z), Mathf.FloorToInt(b.size.x), Mathf.FloorToInt(b.size.y), Mathf.FloorToInt(b.size.z));
		}

		public static Bounds ToBounds(this BoundsInt b)
		{
			return new Bounds(b.center, b.size);
		}

		public static BoundsInt Pad(this BoundsInt b, int padding, Vector3Int? directions = null)
		{
			if (!directions.HasValue)
			{
				directions = Vector3Int.one;
			}
			Vector3Int value = directions.Value;
			value *= padding;
			return new BoundsInt(b.min.x - value.x, b.min.y - value.y, b.min.z - value.z, b.max.x + value.x, b.max.y + value.y, b.max.z + value.z);
		}

		public static BoundsInt Fit(this BoundsInt bounds, Vector3Int point)
		{
			if (bounds.size == Vector3Int.zero)
			{
				return new BoundsInt(point, Vector3Int.one);
			}
			if (bounds.Contains(point))
			{
				return bounds;
			}
			return new BoundsInt
			{
				xMin = System.Math.Min(point.x, bounds.xMin),
				yMin = System.Math.Min(point.y, bounds.yMin),
				zMin = System.Math.Min(point.z, bounds.zMin),
				xMax = System.Math.Max(point.x + 1, bounds.xMax),
				yMax = System.Math.Max(point.y + 1, bounds.yMax),
				zMax = System.Math.Max(point.z + 1, bounds.zMax)
			};
		}

		public static BoundsInt Fit(this BoundsInt bounds, BoundsInt otherBounds)
		{
			if (bounds.size == Vector3Int.zero)
			{
				return otherBounds;
			}
			if (otherBounds.size == Vector3Int.zero)
			{
				return bounds;
			}
			return new BoundsInt
			{
				xMin = System.Math.Min(otherBounds.xMin, bounds.xMin),
				yMin = System.Math.Min(otherBounds.yMin, bounds.yMin),
				zMin = System.Math.Min(otherBounds.zMin, bounds.zMin),
				xMax = System.Math.Max(otherBounds.xMax, bounds.xMax),
				yMax = System.Math.Max(otherBounds.yMax, bounds.yMax),
				zMax = System.Math.Max(otherBounds.zMax, bounds.zMax)
			};
		}

		public static BoundsInt Intersection(this BoundsInt bounds, BoundsInt otherBounds)
		{
			if (otherBounds.size == Vector3Int.zero || bounds.size == Vector3Int.zero || bounds.FullyOutside(otherBounds))
			{
				return default(BoundsInt);
			}
			return new BoundsInt
			{
				xMin = System.Math.Max(bounds.xMin, otherBounds.xMin),
				yMin = System.Math.Max(bounds.yMin, otherBounds.yMin),
				zMin = System.Math.Max(bounds.zMin, otherBounds.zMin),
				xMax = System.Math.Min(bounds.xMax, otherBounds.xMax),
				yMax = System.Math.Min(bounds.yMax, otherBounds.yMax),
				zMax = System.Math.Min(bounds.zMax, otherBounds.zMax)
			};
		}

		public static bool FullyContains(this BoundsInt bounds, BoundsInt otherBounds)
		{
			if (otherBounds.size == Vector3Int.zero)
			{
				return true;
			}
			if (bounds.size == Vector3Int.zero)
			{
				return false;
			}
			if (bounds.xMin <= otherBounds.xMin && bounds.yMin <= otherBounds.yMin && bounds.zMin <= otherBounds.zMin && bounds.xMax >= otherBounds.xMax && bounds.yMax >= otherBounds.yMax)
			{
				return bounds.zMax >= otherBounds.zMax;
			}
			return false;
		}

		public static BoundsInt Scale(this BoundsInt bounds, Vector3Int scale)
		{
			return new BoundsInt(bounds.position * scale, bounds.size * scale);
		}

		public static int CellIndex(this BoundsInt bounds, int x, int y, int z)
		{
			return bounds.CellIndex(new Vector3Int(x, y, z));
		}

		public static int CellIndex(this BoundsInt bounds, Vector3Int pos)
		{
			return (pos.z - bounds.zMin) * bounds.size.y * bounds.size.x + (pos.y - bounds.yMin) * bounds.size.x + (pos.x - bounds.xMin);
		}

		public static Vector3Int PositionFromCellIndex(this BoundsInt bounds, int index)
		{
			int z = index / (bounds.size.y * bounds.size.x);
			int y = index / bounds.size.x % bounds.size.y;
			Vector3Int vector3Int = new Vector3Int(index % bounds.size.x, y, z) + bounds.min;
			if (!bounds.Contains(vector3Int))
			{
				Vector3Int vector3Int2 = vector3Int;
				string text = vector3Int2.ToString();
				BoundsInt boundsInt = bounds;
				Debug.Log("pos: " + text + " bounds: " + boundsInt.ToString());
			}
			return vector3Int;
		}

		public static bool FullyOutside(this BoundsInt a, BoundsInt b)
		{
			if (b.xMin < a.xMax && b.xMax > a.xMin && b.yMin < a.yMax && b.yMax > a.yMin && b.zMin < a.zMax)
			{
				return b.zMax <= a.zMin;
			}
			return true;
		}

		public static void SetLinear2D(this ref PhysicsVelocity velocityData, in float3 velocity)
		{
			velocityData.Linear = velocity;
			velocityData.Linear.y = 0f;
		}

		public static void AddLinear2D(this ref PhysicsVelocity velocityData, in float3 velocity)
		{
			velocityData.Linear += velocity;
			velocityData.Linear.y = 0f;
		}

		public static void SetTrigger(this Animator animator, string triggerName, bool set)
		{
			if (set)
			{
				animator.SetTrigger(triggerName);
			}
			else
			{
				animator.ResetTrigger(triggerName);
			}
		}

		public static void SetTrigger(this Animator animator, int triggerHash, bool set)
		{
			if (set)
			{
				animator.SetTrigger(triggerHash);
			}
			else
			{
				animator.ResetTrigger(triggerHash);
			}
		}

		public static Color ColorWithNewAlpha(this Color c, float a)
		{
			return new Color(c.r, c.g, c.b, a);
		}

		public static void SetAlpha(this SpriteRenderer sr, float a)
		{
			Color color = sr.color;
			sr.color = new Color(color.r, color.g, color.b, a);
		}

		public static float ChannelMin(this Color c, bool includeAlpha = false)
		{
			float num = Mathf.Min(c.r, Mathf.Min(c.g, c.b));
			if (includeAlpha)
			{
				num = Mathf.Min(num, c.a);
			}
			return num;
		}

		public static float ChannelMax(this Color c, bool includeAlpha = false)
		{
			float num = Mathf.Max(c.r, Mathf.Max(c.g, c.b));
			if (includeAlpha)
			{
				num = Mathf.Max(num, c.a);
			}
			return num;
		}

		public static Vector2Int GetSize(this Texture2D tex)
		{
			return new Vector2Int(tex.width, tex.height);
		}

		public static int GetPixelCount(this Texture2D tex)
		{
			return tex.width * tex.height;
		}

		public static Rect PixelRectToUVRect(this Texture2D tex, RectInt r, float uvShift)
		{
			return new Rect(((float)r.x + uvShift) / (float)tex.width, ((float)r.y + uvShift) / (float)tex.height, ((float)r.width - uvShift) / (float)tex.width, ((float)r.height - uvShift) / (float)tex.height);
		}

		public static int GetHashCode(this ref Color32 color)
		{
			return (color.r << 24) | (color.g << 16) | (color.b << 8) | color.a;
		}

		public static bool IsWorldPointInOrthoViewport(this Camera cam, Vector2 p)
		{
			Vector3 vector = cam.WorldToViewportPoint(p);
			if (vector.x >= 0f && vector.x <= 1f && vector.y >= 0f)
			{
				return vector.y <= 1f;
			}
			return false;
		}

		public static bool IsWorldPointInOrthoViewport(this Camera cam, Vector3 p, float epsilon)
		{
			if (cam.orthographic)
			{
				p += Vector3.back * cam.transform.localPosition.y;
				float orthographicSize = cam.orthographicSize;
				if (p.z > orthographicSize + cam.transform.position.z + epsilon)
				{
					return false;
				}
				if (p.z < 0f - orthographicSize + cam.transform.position.z - epsilon)
				{
					return false;
				}
				float num = orthographicSize * cam.aspect;
				if (p.x > num + cam.transform.position.x + epsilon)
				{
					return false;
				}
				if (p.x < 0f - num + cam.transform.position.x - epsilon)
				{
					return false;
				}
				return true;
			}
			float num2 = epsilon / (cam.orthographicSize * 2f * cam.aspect);
			float num3 = epsilon / (cam.orthographicSize * 2f);
			Vector3 vector = cam.WorldToViewportPoint(p);
			if (vector.x >= 0f - num2 && vector.x <= 1f + num2 && vector.z >= 0f - num3)
			{
				return vector.z <= 1f + num3;
			}
			return false;
		}

		public static Vector2 ClampWorldPointInOrthoViewport(this Camera cam, Vector2 p, float epsilon)
		{
			float orthographicSize = cam.orthographicSize;
			float num = orthographicSize * cam.aspect;
			float x = Mathf.Clamp(p.x, 0f - num + cam.transform.position.x - epsilon, num + cam.transform.position.x + epsilon);
			float y = Mathf.Clamp(p.y, 0f - orthographicSize + cam.transform.position.y - epsilon, orthographicSize + cam.transform.position.y + epsilon);
			return new Vector2(x, y);
		}

		public static Rect GetOrthoViewportBounds(this Camera cam)
		{
			Vector3 vector = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
			Vector3 vector2 = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
			return Rect.MinMaxRect(vector.x, vector.y, vector2.x, vector2.y);
		}

		public static bool SetLinearVolume(this AudioMixer mixer, string volumeName, float volume01)
		{
			float value = ((volume01 <= float.Epsilon) ? (-80f) : (Mathf.Log(volume01) * 20f));
			return mixer.SetFloat(volumeName, value);
		}

		public static ParticleSystemHandle CreateHandle(this ParticleSystem particleSystem)
		{
			return ParticleSystemHandle.Create(particleSystem);
		}

		public static T GetSingleton<T>(this ref SystemState state) where T : unmanaged, IComponentData
		{
			return state.GetEntityQuery(ComponentType.ReadOnly<T>()).GetSingleton<T>();
		}

		public static Entity GetSingletonEntity<T>(this ref SystemState state) where T : unmanaged
		{
			return state.GetEntityQuery(ComponentType.ReadOnly<T>()).GetSingletonEntity();
		}
	}
}
