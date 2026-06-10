using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Water
{
	public class Waterfall
	{
		private Vector3 boundsMin;

		private Vector3 boundsMax;

		public Vector3 GridPosition { get; private set; }

		public Vector3 WorldPosition => GridUtils.GetWorldPosition((int)GridPosition.x, (int)GridPosition.y, (int)GridPosition.z);

		public Vector3 BoundsMin => boundsMin;

		public Vector3 BoundsMax => boundsMax;

		public int WaterNodesCount { get; private set; }

		public int NodesHash { get; private set; }

		public Waterfall(HashSet<int> nodes)
		{
			Init(nodes);
		}

		public static int CalculateHash(HashSet<int> nodes)
		{
			HashCode hashCode = default(HashCode);
			foreach (int node in nodes)
			{
				hashCode.Add(node);
			}
			return hashCode.ToHashCode();
		}

		public void Reset()
		{
			GridPosition = Vector3.zero;
			boundsMin = Vector3.zero;
			boundsMax = Vector3.zero;
			WaterNodesCount = 0;
			NodesHash = 0;
		}

		private void Init(HashSet<int> nodes)
		{
			WaterNodesCount = nodes.Count;
			Vec3Int a = Vec3Int.zero;
			Vec3Int vec3Int = GridDataIndexTools.FastTo3DIndex(nodes.FirstOrDefault());
			boundsMin.x = vec3Int.x;
			boundsMin.y = vec3Int.y;
			boundsMin.z = vec3Int.z;
			boundsMax.x = vec3Int.x;
			boundsMax.y = vec3Int.y;
			boundsMax.z = vec3Int.z;
			foreach (int node in nodes)
			{
				Vec3Int b = GridDataIndexTools.FastTo3DIndex(node);
				a += b;
				boundsMin.x = Math.Min(b.x, boundsMin.x);
				boundsMin.y = Math.Min(b.y, boundsMin.y);
				boundsMin.z = Math.Min(b.z, boundsMin.z);
				boundsMax.x = Math.Max(b.x, boundsMax.x);
				boundsMax.y = Math.Max(b.y, boundsMax.y);
				boundsMax.z = Math.Max(b.z, boundsMax.z);
			}
			boundsMax += Vector3.one;
			GridPosition = new Vector3((float)a.x / (float)WaterNodesCount, (float)a.y / (float)WaterNodesCount, (float)a.z / (float)WaterNodesCount);
			NodesHash = CalculateHash(nodes);
		}
	}
}
