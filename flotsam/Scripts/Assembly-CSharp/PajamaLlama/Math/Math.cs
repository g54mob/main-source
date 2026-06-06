using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

namespace PajamaLlama.Math
{
	public class Math
	{
		public static int WrapIndex(int index, int maxIndex)
		{
			int num = index % maxIndex;
			if (num < 0)
			{
				num += maxIndex;
			}
			return num;
		}

		public static int IncrementIndexWrapped(int index, int maxIndex, int amount = 1)
		{
			return (index + amount) % maxIndex;
		}

		public static int DecrementIndexWrapped(int index, int maxIndex, int amount = 1)
		{
			int num = (index - amount) % maxIndex;
			if (num < 0)
			{
				return num + maxIndex;
			}
			return num;
		}

		public static Vector2 ReturnPerpendicularVector(Vector2 vector)
		{
			return new Vector2(0f - vector.y, vector.x);
		}

		public static Vector2 ReturnSmallestVector(List<Vector2> points)
		{
			Vector2 vector = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				vector = Vector2.Min(vector, points[i]);
			}
			return vector;
		}

		public static Vector2 ReturnBiggestVector(List<Vector2> points)
		{
			Vector3 vector = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				vector = Vector2.Max(vector, points[i]);
			}
			return vector;
		}

		public static List<float> ReturnDotProductsFromPointToLine(List<Vector2> points, Vector2 vector)
		{
			List<float> list = new List<float>();
			vector = vector.normalized;
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(ReturnDotProductFromPointToLine(Vector2.zero, vector, points[i]));
			}
			return list;
		}

		public static HashSet<float> ReturnDotProductsFromPointToLineAsHashSet(List<Vector2> points, Vector2 vector)
		{
			HashSet<float> hashSet = new HashSet<float>();
			vector = vector.normalized;
			for (int i = 0; i < points.Count; i++)
			{
				hashSet.Add(ReturnDotProductFromPointToLine(Vector2.zero, vector, points[i]));
			}
			return hashSet;
		}

		private static bool CanAxisBeFoundBetweenPolygons(List<Vector2> firstPolygonPoints, List<Vector2> secondPolygonPoints)
		{
			for (int i = 0; i < firstPolygonPoints.Count; i++)
			{
				Vector2 normalized = ReturnPerpendicularVector((firstPolygonPoints[(i + 1) % firstPolygonPoints.Count] - firstPolygonPoints[i]).normalized).normalized;
				List<float> points = ReturnDotProductsFromPointToLine(firstPolygonPoints, normalized);
				List<float> points2 = ReturnDotProductsFromPointToLine(secondPolygonPoints, normalized);
				float num = ReturnSmallestFloat(points);
				float num2 = ReturnBiggestFloat(points);
				float num3 = ReturnSmallestFloat(points2);
				float num4 = ReturnBiggestFloat(points2);
				if (num >= num4)
				{
					return true;
				}
				if (num2 <= num3)
				{
					return true;
				}
			}
			return false;
		}

		public static bool ArePolygonsOverlapping(List<Vector2> firstPolygonPoints, List<Vector2> secondPolygonPoints)
		{
			if (CanAxisBeFoundBetweenPolygons(firstPolygonPoints, secondPolygonPoints))
			{
				return false;
			}
			if (CanAxisBeFoundBetweenPolygons(secondPolygonPoints, firstPolygonPoints))
			{
				return false;
			}
			return true;
		}

		public static Vector3 ReturnPerpendicularVector(Vector3 vector, Vector3 index)
		{
			return Vector3.Cross(vector, index);
		}

		public static Vector3 ReturnPerpendicularVector(Vector3 vector)
		{
			return Vector3.Cross(vector, Vector3.up);
		}

		public static Vector3 ReturnProjectedPointOnLine(Vector3 lineStartingPoint, Vector3 lineDirectionVector, Vector3 pointToProject)
		{
			float num = Vector3.Dot(pointToProject - lineStartingPoint, lineDirectionVector);
			return lineStartingPoint + lineDirectionVector * num;
		}

		public static float ReturnDotProductFromPointToLine(Vector3 lineStartingPoint, Vector3 lineDirectionVector, Vector3 pointToProject)
		{
			return Vector3.Dot(pointToProject - lineStartingPoint, lineDirectionVector);
		}

		public static float ReturnDotProductFromPointToLine(Vector2 lineStartingPoint, Vector2 lineDirectionVector, Vector2 pointToProject)
		{
			return Vector2.Dot(pointToProject - lineStartingPoint, lineDirectionVector);
		}

		public static List<Vector3> ReturnPointsProjectedOnDirectionVector(List<Vector3> points, Vector3 vector)
		{
			List<Vector3> list = new List<Vector3>();
			vector = vector.normalized;
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(ReturnProjectedPointOnLine(Vector3.zero, vector, points[i]));
			}
			return list;
		}

		public static List<float> ReturnDotProductsFromPointToLine(List<Vector3> points, Vector3 vector)
		{
			List<float> list = new List<float>(points.Capacity);
			vector = vector.normalized;
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(ReturnDotProductFromPointToLine(Vector3.zero, vector, points[i]));
			}
			return list;
		}

		public static bool IsPointOnSegment(Vector3 segmentStart, Vector3 segmentEnd, Vector3 point)
		{
			return Vector3.Distance(segmentStart, segmentEnd) == Vector3.Distance(segmentStart, point) + Vector3.Distance(segmentEnd, point);
		}

		public static Vector3 ReturnSmallestVector(List<Vector3> points)
		{
			Vector3 vector = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				vector = Vector3.Min(vector, points[i]);
			}
			return vector;
		}

		public static Vector3 ReturnBiggestVector(List<Vector3> points)
		{
			Vector3 vector = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				vector = Vector3.Max(vector, points[i]);
			}
			return vector;
		}

		public static float ReturnSmallestFloat(List<float> points)
		{
			float num = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				num = Mathf.Min(num, points[i]);
			}
			return num;
		}

		public static float ReturnSmallestFloat(HashSet<float> points)
		{
			float num = float.MaxValue;
			foreach (float point in points)
			{
				num = Mathf.Min(num, point);
			}
			return num;
		}

		public static float ReturnBiggestFloat(List<float> points)
		{
			float num = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				num = Mathf.Max(num, points[i]);
			}
			return num;
		}

		public static float ReturnBiggestFloat(HashSet<float> points)
		{
			float num = float.MinValue;
			foreach (float point in points)
			{
				num = Mathf.Max(num, point);
			}
			return num;
		}

		public static void CalculateSmallestAndBiggestFloat(List<float> points, out float smallest, out float biggest)
		{
			int count = points.Count;
			biggest = float.MinValue;
			smallest = float.MaxValue;
			for (int i = 0; i < count; i++)
			{
				float b = points[i];
				biggest = Mathf.Max(biggest, b);
				smallest = Mathf.Min(smallest, b);
			}
		}

		private static bool CanAxisBeFoundBetweenPolygons(List<Vector3> firstPolygonPoints, List<Vector3> secondPolygonPoints)
		{
			for (int i = 0; i < firstPolygonPoints.Count; i++)
			{
				Vector3 normalized = ReturnPerpendicularVector((firstPolygonPoints[(i + 1) % firstPolygonPoints.Count] - firstPolygonPoints[i]).normalized).normalized;
				List<float> points = ReturnDotProductsFromPointToLine(firstPolygonPoints, normalized);
				List<float> points2 = ReturnDotProductsFromPointToLine(secondPolygonPoints, normalized);
				CalculateSmallestAndBiggestFloat(points, out var smallest, out var biggest);
				CalculateSmallestAndBiggestFloat(points2, out var smallest2, out var biggest2);
				if (smallest >= biggest2)
				{
					return true;
				}
				if (biggest <= smallest2)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPointOverlappingPolygon(Vector3 point, List<Vector3> leveledPolygonPoints)
		{
			int num = 0;
			point = point.Leveled();
			for (int i = 0; i < leveledPolygonPoints.Count; i++)
			{
				Vector3 vector = leveledPolygonPoints[i];
				Vector3 vector2 = leveledPolygonPoints[(i + 1) % leveledPolygonPoints.Count];
				Vector3 firstLineVector = vector2 - vector;
				Vector3 intersection = Vector3.zero;
				bool flag = false;
				bool flag2 = LineLineIntersection(out intersection, vector, firstLineVector, point, Vector3.right * 100f);
				if (firstLineVector.z > 0f && flag2 && intersection != vector2)
				{
					flag = true;
				}
				bool flag3 = false;
				if (firstLineVector.z < 0f && flag2 && intersection != vector)
				{
					flag3 = true;
				}
				if ((flag || flag3) && point.x < intersection.x)
				{
					num++;
				}
			}
			if (num % 2 == 0)
			{
				return false;
			}
			return true;
		}

		public static bool IsPointOverlappingPolygon(Vector3 point, List<Transform> polygonPoints)
		{
			List<Vector3> list = new List<Vector3>(polygonPoints.Count);
			for (int i = 0; i < polygonPoints.Count; i++)
			{
				list.Add(polygonPoints[i].position.Leveled());
			}
			return IsPointOverlappingPolygon(point, list);
		}

		public static bool ArePolygonsOverlapping(List<Vector3> firstPolygonPoints, List<Vector3> secondPolygonPoints)
		{
			if (CanAxisBeFoundBetweenPolygons(firstPolygonPoints, secondPolygonPoints))
			{
				return false;
			}
			if (CanAxisBeFoundBetweenPolygons(secondPolygonPoints, firstPolygonPoints))
			{
				return false;
			}
			return true;
		}

		public static Vector3 ReturnLeveledEulerAngles(Vector3 eulerAngles)
		{
			return new Vector3(0f, eulerAngles.y, 0f);
		}

		public static bool LineLineIntersection(out Vector3 intersection, Vector3 firstLinePoint, Vector3 firstLineVector, Vector3 secondLinePoint, Vector3 secondLineVector)
		{
			intersection = Vector3.zero;
			Vector3 lhs = secondLinePoint - firstLinePoint;
			Vector3 rhs = Vector3.Cross(firstLineVector, secondLineVector);
			Vector3 lhs2 = Vector3.Cross(lhs, secondLineVector);
			float num = Vector3.Dot(lhs, rhs);
			if (num >= 1E-05f || num <= -1E-05f)
			{
				return false;
			}
			float num2 = Vector3.Dot(lhs2, rhs) / rhs.sqrMagnitude;
			if (num2 >= 0f && num2 <= 1f)
			{
				intersection = firstLinePoint + firstLineVector * num2;
				return true;
			}
			return false;
		}

		public static bool LineLineIntersection(out Vector2 intersection, Vector2 lineStartA, Vector2 lineEndA, Vector2 lineStartB, Vector2 lineEndB)
		{
			intersection = Vector2.zero;
			float num = (lineEndA.x - lineStartA.x) * (lineEndB.y - lineStartB.y) - (lineEndA.y - lineStartA.y) * (lineEndB.x - lineStartB.x);
			if (num == 0f)
			{
				return false;
			}
			float num2 = ((lineStartB.x - lineStartA.x) * (lineEndB.y - lineStartB.y) - (lineStartB.y - lineStartA.y) * (lineEndB.x - lineStartB.x)) / num;
			float num3 = ((lineStartB.x - lineStartA.x) * (lineEndA.y - lineStartA.y) - (lineStartB.y - lineStartA.y) * (lineEndA.x - lineStartA.x)) / num;
			if (num2 < 0f || num2 > 1f || num3 < 0f || num3 > 1f)
			{
				return false;
			}
			intersection.x = lineStartA.x + num2 * (lineEndA.x - lineStartA.x);
			intersection.y = lineStartA.y + num2 * (lineEndA.y - lineStartA.y);
			return true;
		}

		public static bool IsLineIntersectingPolygon(Vector3 lineOrigin, Vector3 lineVector, List<Vector3> polygonPoints, bool finiteLength = true, bool levelPoints = true)
		{
			if (levelPoints)
			{
				lineOrigin = lineOrigin.Leveled();
				lineVector = lineVector.Leveled();
				for (int i = 0; i < polygonPoints.Count; i++)
				{
					polygonPoints[i] = polygonPoints[i].Leveled();
				}
			}
			for (int j = 0; j < polygonPoints.Count; j++)
			{
				Vector3 vector = polygonPoints[j];
				Vector3 vector2 = polygonPoints[(j + 1) % polygonPoints.Count];
				Vector3 firstLineVector = vector2 - vector;
				Vector3 intersection = Vector3.zero;
				bool flag = false;
				if (firstLineVector.z > 0f && LineLineIntersection(out intersection, vector, firstLineVector, lineOrigin, lineVector) && intersection != vector2 && (!finiteLength || (Vector3.Distance(lineOrigin, intersection) <= lineVector.magnitude && Vector3.Distance(lineOrigin + lineVector, intersection) <= lineVector.magnitude)))
				{
					flag = true;
				}
				bool flag2 = false;
				if (firstLineVector.z < 0f && LineLineIntersection(out intersection, vector, firstLineVector, lineOrigin, lineVector) && intersection != vector && (!finiteLength || (Vector3.Distance(lineOrigin, intersection) <= lineVector.magnitude && Vector3.Distance(lineOrigin + lineVector, intersection) <= lineVector.magnitude)))
				{
					flag2 = true;
				}
				if (flag || flag2)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsLineIntersectingPolygon(Vector3 lineOrigin, Vector3 lineVector, List<Vector3> polygonPoints, float width = 0f, bool finiteLength = true, bool showDebugRays = false, bool levelPoints = true)
		{
			if (width == 0f)
			{
				return IsLineIntersectingPolygon(lineOrigin, lineVector, polygonPoints, finiteLength, levelPoints);
			}
			Vector3 vector = Vector3.Cross(lineVector, Vector3.up).normalized * width * 0.5f;
			Vector3 vector2 = lineOrigin + vector;
			Vector3 vector3 = lineOrigin - vector;
			List<Vector3> list = new List<Vector3>(4)
			{
				vector2,
				vector2 + lineVector,
				vector3 + lineVector,
				vector3
			};
			if (showDebugRays)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Debug.DrawRay(list[(i + 1) % list.Count], list[i] - list[(i + 1) % list.Count], Color.cyan * 0.5f);
				}
			}
			return ArePolygonsOverlapping(list, polygonPoints);
		}

		public static Vector3 GetRandomPointInCircle(Vector3 position, float radius, float maximumRadius = 15f)
		{
			float num = radius;
			Vector3 vector;
			while (true)
			{
				vector = position + (Vector3.zero - Random.onUnitSphere.Leveled()).normalized * num;
				if (!Buildable.IsPointOverlapping(vector))
				{
					return vector;
				}
				if (num >= maximumRadius)
				{
					break;
				}
				num += 1f;
			}
			Debugger.Warning($"Couldn't find random spot around position {position}, in radius of {num}.");
			return vector;
		}

		private static bool CanAxisBeFoundBetweenPolygons(List<Transform> firstPolygonTransforms, List<Transform> secondPolygonTransforms)
		{
			for (int i = 0; i < firstPolygonTransforms.Count; i++)
			{
				Vector3 normalized = ReturnPerpendicularVector((firstPolygonTransforms[(i + 1) % firstPolygonTransforms.Count].position - firstPolygonTransforms[i].position).normalized).normalized;
				List<float> points = ReturnDotProductsFromPointToLine(firstPolygonTransforms, normalized);
				List<float> points2 = ReturnDotProductsFromPointToLine(secondPolygonTransforms, normalized);
				float num = ReturnSmallestFloat(points);
				float num2 = ReturnBiggestFloat(points);
				float num3 = ReturnSmallestFloat(points2);
				float num4 = ReturnBiggestFloat(points2);
				if (num >= num4)
				{
					return true;
				}
				if (num2 <= num3)
				{
					return true;
				}
			}
			return false;
		}

		public static bool ArePolygonsOverlapping(List<Transform> firstPolygonPoints, List<Transform> secondPolygonPoints)
		{
			if (CanAxisBeFoundBetweenPolygons(firstPolygonPoints, secondPolygonPoints))
			{
				return false;
			}
			if (CanAxisBeFoundBetweenPolygons(secondPolygonPoints, firstPolygonPoints))
			{
				return false;
			}
			return true;
		}

		public static List<float> ReturnDotProductsFromPointToLine(List<Transform> points, Vector3 vector)
		{
			List<float> list = new List<float>();
			vector = vector.normalized;
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(ReturnDotProductFromPointToLine(Vector3.zero, vector, points[i].position));
			}
			return list;
		}

		public static bool IsLineIntersectingPolygon(Vector3 lineOrigin, Vector3 lineVector, List<Transform> polygonTransforms, bool finiteLength = true, bool levelPoints = true)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < polygonTransforms.Count; i++)
			{
				if (levelPoints)
				{
					list.Add(polygonTransforms[i].position.Leveled());
				}
				else
				{
					list.Add(polygonTransforms[i].position);
				}
			}
			return IsLineIntersectingPolygon(lineOrigin, lineVector, list, finiteLength, levelPoints);
		}

		public static bool IsLineIntersectingPolygon(Vector3 lineOrigin, Vector3 lineVector, List<Transform> polygonTransforms, float width = 0f, bool finiteLength = true, bool showDebugRays = false, bool levelPoints = true)
		{
			if (width == 0f)
			{
				return IsLineIntersectingPolygon(lineOrigin, lineVector, polygonTransforms, finiteLength, levelPoints);
			}
			List<Vector3> polygonPoints = polygonTransforms.ConvertAll((Transform transform) => transform.position);
			return IsLineIntersectingPolygon(lineOrigin, lineVector, polygonPoints, width, finiteLength, showDebugRays, levelPoints);
		}
	}
}
