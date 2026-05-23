using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public static class RelativeGridPositionsCalculator
{
	public static Vector3Int GridCellSize = new Vector3Int(1, 1, 1);

	public static HashSet<Vector3Int> GetRelativeGridPositionsInBounds(Bounds worldBounds)
	{
		HashSet<Vector3Int> hashSet = new HashSet<Vector3Int>();
		int num = MathUtils.RoundToInt(worldBounds.min.x / (float)GridCellSize.x, roundHalfwayUp: true);
		int num2 = MathUtils.RoundToInt(worldBounds.min.z / (float)GridCellSize.z, roundHalfwayUp: true);
		int num3 = MathUtils.RoundToInt(worldBounds.max.x / (float)GridCellSize.x, roundHalfwayUp: false);
		int num4 = MathUtils.RoundToInt(worldBounds.max.z / (float)GridCellSize.z, roundHalfwayUp: false);
		hashSet.Add(Vector3Int.zero);
		for (int i = num; i <= num3; i++)
		{
			for (int j = num2; j <= num4; j++)
			{
				hashSet.Add(new Vector3Int(i, 0, j));
			}
		}
		return hashSet;
	}

	public static List<Vector3Int> CalculateRelativePositionsUsingMesh(Transform meshParent)
	{
		List<Vector3Int> list = new List<Vector3Int>();
		MeshFilter[] componentsInChildren = meshParent.GetComponentsInChildren<MeshFilter>();
		HashSet<Vector3Int> hashSet = new HashSet<Vector3Int>();
		list.Add(Vector3Int.zero);
		MeshFilter[] array = componentsInChildren;
		foreach (MeshFilter meshFilter in array)
		{
			Bounds bounds = meshFilter.sharedMesh.bounds;
			bounds.center += meshFilter.transform.localPosition;
			hashSet = GetRelativeGridPositionsInBounds(bounds);
			if (meshFilter.sharedMesh == null)
			{
				continue;
			}
			foreach (Vector3Int item in hashSet)
			{
				if (list.Contains(item))
				{
					continue;
				}
				Vector3Int vector3Int = item;
				vector3Int.x *= GridCellSize.x;
				vector3Int.z *= GridCellSize.z;
				Bounds bounds2 = new Bounds(vector3Int, new Vector3(GridCellSize.x, 5f, GridCellSize.z));
				Vector3[] vertices = meshFilter.sharedMesh.vertices;
				foreach (Vector3 vector in vertices)
				{
					if (bounds2.Contains(vector + meshFilter.transform.localPosition))
					{
						list.Add(item);
						break;
					}
				}
			}
		}
		return list;
	}

	public static List<Vector3Int> CalculateRelativePositionsUsingColliders(Transform collidersParent)
	{
		Collider[] componentsInChildren = collidersParent.GetComponentsInChildren<Collider>();
		HashSet<Vector3Int> hashSet = new HashSet<Vector3Int> { Vector3Int.zero };
		Collider[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Bounds bounds = array[i].bounds;
			bounds.center = collidersParent.InverseTransformPoint(bounds.center);
			foreach (Vector3Int relativeGridPositionsInBound in GetRelativeGridPositionsInBounds(bounds))
			{
				hashSet.Add(relativeGridPositionsInBound);
			}
		}
		return hashSet.ToList();
	}
}
