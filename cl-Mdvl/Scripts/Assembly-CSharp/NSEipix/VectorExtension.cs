using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NSMedieval;
using NSMedieval.Map;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSEipix
{
	public static class VectorExtension
	{
		public static bool IsZero(this Vector3 point)
		{
			if (Mathf.Approximately(point.x, 0f) && Mathf.Approximately(point.y, 0f))
			{
				return Mathf.Approximately(point.z, 0f);
			}
			return false;
		}

		public static int ToNodeIndex(this Vec3Int vec)
		{
			return GridDataIndexTools.FastTo1DIndex(vec);
		}

		public static Vector3 BarycentricCoordinate(this Vector3 point, Vector3[] trinaglePoints)
		{
			if (trinaglePoints == null || trinaglePoints.Length != 3)
			{
				throw new Exception();
			}
			return point.BarycentricCoordinate(trinaglePoints[0], trinaglePoints[1], trinaglePoints[2]);
		}

		public static Vector3 BarycentricCoordinate(this Vector3 point, Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 vector = c - a;
			Vector3 vector2 = b - a;
			Vector3 rhs = point - a;
			float num = Vector3.Dot(vector, vector);
			float num2 = Vector3.Dot(vector, vector2);
			float num3 = Vector3.Dot(vector, rhs);
			float num4 = Vector3.Dot(vector2, vector2);
			float num5 = Vector3.Dot(vector2, rhs);
			float num6 = num * num4 - num2 * num2;
			if (num6 == 0f)
			{
				return new Vector3(-2f, -1f, -1f);
			}
			num6 = 1f / num6;
			float num7 = (num4 * num3 - num2 * num5) * num6;
			float num8 = (num * num5 - num2 * num3) * num6;
			return new Vector3(1f - num7 - num8, num8, num7);
		}

		public static Vector3 Abs(this Vector3 value)
		{
			return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
		}

		public static bool Contains(this Vector3 point, Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 vector = point.BarycentricCoordinate(a, b, c);
			if (vector.x >= 0f && vector.y >= 0f)
			{
				return vector.x + vector.y <= 1f;
			}
			return false;
		}

		public static bool ContainsBarycentric(this Vector3 point)
		{
			if (point.x >= 0f && point.y >= 0f)
			{
				return point.x + point.y <= 1f;
			}
			return false;
		}

		public static float DistanceXZ(this Vector3 a, Vector3 b)
		{
			float num = a.x - b.x;
			float num2 = a.z - b.z;
			return Mathf.Sqrt(num * num + num2 * num2);
		}

		public static float DistanceXY(this Vector3 a, Vector3 b)
		{
			float num = a.x - b.x;
			float num2 = a.y - b.y;
			return Mathf.Sqrt(num * num + num2 * num2);
		}

		public static float DistanceYZ(this Vector3 a, Vector3 b)
		{
			float num = a.z - b.z;
			float num2 = a.y - b.y;
			return Mathf.Sqrt(num * num + num2 * num2);
		}

		public static float DistanceSquared(this in Vector3 a, in Vector3 b)
		{
			return Vector3.SqrMagnitude(b - a);
		}

		public static float DistanceSquared(this in Vector2 a, in Vector2 b)
		{
			return Vector2.SqrMagnitude(b - a);
		}

		public static float Distance(this Vector3 point, Vector3 a, Vector3 b, out Vector3 closestPoint)
		{
			Vector3 vector = b - a;
			float num = Vector3.Dot(point - a, vector);
			if (num <= 0f)
			{
				closestPoint = a;
				return Vector3.Distance(point, a);
			}
			float num2 = Vector3.Dot(vector, vector);
			if (num2 <= num)
			{
				closestPoint = b;
				return Vector3.Distance(point, b);
			}
			float num3 = num / num2;
			closestPoint = a + vector * num3;
			return Vector3.Distance(point, closestPoint);
		}

		public static float Distance(this Vector3 point, Vector3 a, Vector3 b, Vector3 c, out Vector3 closestPoint, out Vector3 planeNormal)
		{
			closestPoint = Vector3.zero;
			planeNormal = Vector3.Cross(c - b, a - b).normalized;
			float num = 0f - Vector3.Dot(a, planeNormal);
			Vector3 vector = planeNormal * (Vector3.Dot(planeNormal, point) + num) + point;
			if (vector.Contains(a, b, c))
			{
				closestPoint = vector;
				return Vector3.Distance(point, vector);
			}
			KeyValuePair<Vector3, Vector3>[] array = new KeyValuePair<Vector3, Vector3>[3]
			{
				new KeyValuePair<Vector3, Vector3>(a, b),
				new KeyValuePair<Vector3, Vector3>(b, c),
				new KeyValuePair<Vector3, Vector3>(c, a)
			};
			float num2 = float.PositiveInfinity;
			for (int i = 0; i < 3; i++)
			{
				Vector3 closestPoint2 = Vector3.zero;
				float num3 = point.Distance(array[i].Key, array[i].Value, out closestPoint2);
				if (num3 < num2)
				{
					num2 = num3;
					closestPoint = closestPoint2;
				}
			}
			return num2;
		}

		public static bool IsBetween(this Vector3 position, Vector3 begin, Vector3 end)
		{
			Vector3 lhs = position - begin;
			Vector3 vector = end - begin;
			float num = Vector3.Dot(lhs, vector);
			if (num < 0f)
			{
				return false;
			}
			return num < Vector3.Dot(vector, vector);
		}

		public static List<Vector3> BezierSmooth(this List<Vector3> vectors, int smoothness)
		{
			List<Vector3> list = new List<Vector3>();
			smoothness = Mathf.Max(smoothness, 1);
			int count = vectors.Count;
			int num = count * smoothness - 1;
			float num2 = 0f;
			for (int i = 0; i < num + 1; i++)
			{
				num2 = Mathf.InverseLerp(0f, num, i);
				List<Vector3> list2 = vectors.ToList();
				for (int num3 = count - 1; num3 > 0; num3--)
				{
					for (int j = 0; j < num3; j++)
					{
						list2[j] = (1f - num2) * list2[j] + num2 * list2[j + 1];
					}
				}
				list.Add(list2[0]);
			}
			return list;
		}

		public static IEnumerable<Vec3Int> ForEachSuroundingPosXZ(this Vec3Int input)
		{
			yield return input + Vec3Int.left;
			yield return input + Vec3Int.forward;
			yield return input + Vec3Int.right;
			yield return input + Vec3Int.back;
		}

		public static Vec3Int ToGridXZVec3Int(this Vector3 input)
		{
			Vec3Int gridPosition = GridUtils.GetGridPosition(input);
			gridPosition.y = Mathf.FloorToInt(input.y);
			return gridPosition;
		}

		public static Vector3 ToGridXZ(this Vector3 input)
		{
			Vector3 result = (Vector3)GridUtils.GetGridPosition(input);
			result.y = Mathf.Floor(input.y);
			return result;
		}

		public static Vector3 Floor(this Vector3 input)
		{
			input.x = Mathf.Floor(input.x);
			input.y = Mathf.Floor(input.y);
			input.z = Mathf.Floor(input.z);
			return input;
		}

		public static float Distance(this Vector3 a, Vec3Int b)
		{
			float num = a.x - (float)b.x;
			float num2 = a.y - (float)b.y;
			float num3 = a.z - (float)b.z;
			return (float)Math.Sqrt((double)num * (double)num + (double)num2 * (double)num2 + (double)num3 * (double)num3);
		}

		public static float Distance(this Vector3 a, in Vector3 b)
		{
			return Vector3.Distance(a, b);
		}

		public static float DistanceSquared(this Vector3 a, in Vector3 b)
		{
			return Vector3.SqrMagnitude(a - b);
		}

		public static float DistanceSquared(this Vec3Int a, in Vec3Int b)
		{
			return Vec3Int.DistanceSquared(in a, in b);
		}

		public static Vector3 ToGridVector3(this Vector3 input)
		{
			return (Vector3)GridUtils.GetGridPosition(input);
		}

		public static Vec3Int ToGridVec3Int(this Vector3 input, float raiseYAmount = 0f)
		{
			return GridUtils.GetGridPosition(input, raiseYAmount);
		}

		public static Vec3Int ToGridRoundY(this Vector3 input, float raiseYAmount = 0f)
		{
			return GridUtils.GetGridPositionRoundY(input, raiseYAmount);
		}

		public static Vec3Int ToVec3IntWorld(this Vec3Int input)
		{
			return (Vec3Int)GridUtils.GetWorldPosition(input);
		}

		public static Vec3Int ToGridY(this Vec3Int input)
		{
			return new Vec3Int(input.x, Mathf.FloorToInt((float)input.y / (float)World.MapBlockHeight), input.z);
		}

		public static Vector3 SnapToGrid(this Vector3 input, float raiseYAmount = 0f)
		{
			Vector3 result = (Vector3)GridUtils.GetGridPosition(input, raiseYAmount);
			result.y *= World.MapBlockHeight;
			return result;
		}

		public static Vec3Int SnapToGridVec3Int(this Vector3 input, float raiseYAmount = 0f)
		{
			Vec3Int gridPosition = GridUtils.GetGridPosition(input, raiseYAmount);
			gridPosition.y *= World.MapBlockHeight;
			return gridPosition;
		}

		public static Vector3 ToVector3World(this Vec3Int input)
		{
			return GridUtils.GetWorldPosition(input);
		}

		public static Vector3 ToVector3(this Vector2 input)
		{
			return new Vector3(input.x, input.y, 0f);
		}

		public static Vector3 ToVector3(this Vec3Int input)
		{
			return new Vector3(input.x, input.y, input.z);
		}

		public static Vector2 ToVector2XZ(this Vector3 input)
		{
			return new Vector2(input.x, input.z);
		}

		public static Vector2 ToVector2XY(this Vector3 input)
		{
			return new Vector2(input.x, input.y);
		}

		public static Vector2Int ToVector2XZ(this Vec3Int input)
		{
			return new Vector2Int(input.x, input.z);
		}

		public static Vector2Int ToVector2XY(this Vec3Int input)
		{
			return new Vector2Int(input.x, input.y);
		}

		public static Vector3 Divide(this Vector3 input, Vector3 other)
		{
			return new Vector3(input.x / other.x, input.y / other.y, input.z / other.z);
		}

		public static Vector3 Min(this Vector3 input, Vector3 other)
		{
			return new Vector3(Mathf.Min(input.x, other.x), Mathf.Min(input.y, other.y), Mathf.Min(input.z, other.z));
		}

		public static Vector3 Max(this Vector3 input, Vector3 other)
		{
			return new Vector3(Mathf.Max(input.x, other.x), Mathf.Max(input.y, other.y), Mathf.Max(input.z, other.z));
		}

		public static Vec3Int Min(this Vec3Int input, Vec3Int other)
		{
			return new Vec3Int(Mathf.Min(input.x, other.x), Mathf.Min(input.y, other.y), Mathf.Min(input.z, other.z));
		}

		public static Vec3Int Max(this Vec3Int input, Vec3Int other)
		{
			return new Vec3Int(Mathf.Max(input.x, other.x), Mathf.Max(input.y, other.y), Mathf.Max(input.z, other.z));
		}

		public static Vec3Int MinX(this List<Vec3Int> input)
		{
			Vec3Int result = input.First();
			foreach (Vec3Int item in input)
			{
				if (result.x >= item.x)
				{
					result = item;
				}
			}
			return result;
		}

		public static Vec3Int MinZ(this List<Vec3Int> input)
		{
			Vec3Int result = input.First();
			foreach (Vec3Int item in input)
			{
				if (result.z >= item.z)
				{
					result = item;
				}
			}
			return result;
		}

		public static Vec3Int MaxX(this List<Vec3Int> input)
		{
			Vec3Int result = input.First();
			foreach (Vec3Int item in input)
			{
				if (result.x <= item.x)
				{
					result = item;
				}
			}
			return result;
		}

		public static Vec3Int MaxZ(this List<Vec3Int> input)
		{
			Vec3Int result = input.First();
			foreach (Vec3Int item in input)
			{
				if (result.z <= item.z)
				{
					result = item;
				}
			}
			return result;
		}

		public static Vec3Int Left(this Vec3Int input)
		{
			return input + Vec3Int.left;
		}

		public static Vec3Int Right(this Vec3Int input)
		{
			return input + Vec3Int.right;
		}

		public static Vec3Int Front(this Vec3Int input)
		{
			return input + new Vec3Int(0, 0, 1);
		}

		public static Vec3Int Back(this Vec3Int input)
		{
			return input + new Vec3Int(0, 0, -1);
		}

		public static bool Approximately(this Vector3 thisVector, Vector3 otherVector)
		{
			if (Mathf.Approximately(thisVector.x, otherVector.x) && Mathf.Approximately(thisVector.y, otherVector.y))
			{
				return Mathf.Approximately(thisVector.z, otherVector.z);
			}
			return false;
		}

		[MustDisposeResource]
		public static PooledList<Vec3Int> GetPositionsInRange(this Vec3Int input, Vec3Int range)
		{
			PooledList<Vec3Int> janitor = ListPool<Vec3Int>.GetJanitor();
			for (int i = input.x - range.x; i <= input.x + range.x; i++)
			{
				for (int j = input.y - range.y; j <= input.y + range.y; j++)
				{
					for (int k = input.z - range.z; k <= input.z + range.z; k++)
					{
						janitor.Add(new Vec3Int(i, j, k));
					}
				}
			}
			return janitor;
		}
	}
}
