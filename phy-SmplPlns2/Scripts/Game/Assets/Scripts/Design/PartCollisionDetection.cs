using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class PartCollisionDetection
	{
		private const float Tolerance = 0.04f;

		public static bool CheckIfAnyPartsCollide(List<PartScript> listA, List<PartScript> listB, bool samePartTypeOnly = false)
		{
			EditorCollider.GlobalUpdateId++;
			foreach (PartScript listum in listA)
			{
				foreach (PartScript item in listB)
				{
					if (listum != item && (!samePartTypeOnly || listum.Part.PartType.PartTypeId == item.Part.PartType.PartTypeId) && CheckPartCollision(listum, item))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool CheckIfPartsCollide(PartScript partA, PartScript partB)
		{
			EditorCollider.GlobalUpdateId++;
			return CheckPartCollision(partA, partB);
		}

		private static bool BoxBoxIntersection(Bounds bounds1, Bounds bounds2)
		{
			if (bounds1.min.x + 0.04f > bounds2.max.x - 0.04f)
			{
				return false;
			}
			if (bounds1.min.y + 0.04f > bounds2.max.y - 0.04f)
			{
				return false;
			}
			if (bounds1.min.z + 0.04f > bounds2.max.z - 0.04f)
			{
				return false;
			}
			if (bounds1.max.x - 0.04f < bounds2.min.x + 0.04f)
			{
				return false;
			}
			if (bounds1.max.y - 0.04f < bounds2.min.y + 0.04f)
			{
				return false;
			}
			if (bounds1.max.z - 0.04f < bounds2.min.z + 0.04f)
			{
				return false;
			}
			return true;
		}

		private static bool CheckPartCollision(PartScript partA, PartScript partB)
		{
			foreach (EditorCollider editorCollider in partA.EditorColliders)
			{
				if (!editorCollider.IncludeInIntersections)
				{
					continue;
				}
				editorCollider.Update();
				foreach (EditorCollider editorCollider2 in partB.EditorColliders)
				{
					if (!editorCollider2.IncludeInIntersections)
					{
						continue;
					}
					editorCollider2.Update();
					if (BoxBoxIntersection(editorCollider.Bounds, editorCollider2.Bounds))
					{
						if (!editorCollider.RequiresSeparatingAxisTest && !editorCollider2.RequiresSeparatingAxisTest)
						{
							return true;
						}
						if (SeparatingAxisTest(editorCollider, editorCollider2))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private static bool CheckPointOverlapOnAxis(List<Vector3> points1, List<Vector3> points2, Vector3 axis)
		{
			if (axis == Vector3.zero)
			{
				return true;
			}
			GetMinAndMax(points1, axis, out var min, out var max);
			GetMinAndMax(points2, axis, out var min2, out var max2);
			if (min > max2 + 1E-05f)
			{
				return false;
			}
			if (max < min2 - 1E-05f)
			{
				return false;
			}
			return true;
		}

		private static void GetMinAndMax(List<Vector3> points, Vector3 axis, out float min, out float max)
		{
			min = (max = Vector3.Dot(points[0], axis));
			for (int i = 1; i < points.Count; i++)
			{
				float num = Vector3.Dot(points[i], axis);
				if (num < min)
				{
					min = num;
				}
				else if (num > max)
				{
					max = num;
				}
			}
		}

		private static bool SeparatingAxisTest(EditorCollider colliderA, EditorCollider colliderB)
		{
			if (!CheckPointOverlapOnAxis(colliderA.Points, colliderB.Points, new Vector3(1f, 0f, 0f)))
			{
				return false;
			}
			if (!CheckPointOverlapOnAxis(colliderA.Points, colliderB.Points, new Vector3(0f, 1f, 0f)))
			{
				return false;
			}
			if (!CheckPointOverlapOnAxis(colliderA.Points, colliderB.Points, new Vector3(0f, 0f, 1f)))
			{
				return false;
			}
			foreach (Vector3 normal in colliderA.Normals)
			{
				if (!CheckPointOverlapOnAxis(colliderA.Points, colliderB.Points, normal))
				{
					return false;
				}
			}
			foreach (Vector3 normal2 in colliderB.Normals)
			{
				if (!CheckPointOverlapOnAxis(colliderA.Points, colliderB.Points, normal2))
				{
					return false;
				}
			}
			foreach (Vector3 edge in colliderA.Edges)
			{
				foreach (Vector3 edge2 in colliderB.Edges)
				{
					if (!CheckPointOverlapOnAxis(colliderA.Points, colliderB.Points, Vector3.Cross(edge, edge2)))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
