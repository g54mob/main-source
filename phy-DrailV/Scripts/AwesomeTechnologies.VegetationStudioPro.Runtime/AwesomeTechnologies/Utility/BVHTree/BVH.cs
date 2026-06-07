using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.BVHTree
{
	public class BVH
	{
		public static int MaxPrimsCountPerNode = 1;

		public static BVHNode Bvh;

		public static List<ObjectData> Objects;

		public static float Progress;

		public static void Build(ref List<ObjectData> allObjects, out List<BVHNode> nodes, out List<BVHTriangle> tris, out List<BVHTriangle> finalPrims)
		{
			int num = 0;
			nodes = new List<BVHNode>();
			tris = new List<BVHTriangle>();
			finalPrims = new List<BVHTriangle>();
			foreach (ObjectData allObject in allObjects)
			{
				if (!allObject.IsValid)
				{
					continue;
				}
				for (int i = 0; i < allObject.Indices.Length; i += 3)
				{
					int index = allObject.Indices[i];
					int index2 = allObject.Indices[i + 1];
					int index3 = allObject.Indices[i + 2];
					Vector3 vector = allObject.VerticeList[index];
					Vector3 vector2 = allObject.VerticeList[index2];
					Vector3 vector3 = allObject.VerticeList[index3];
					Vector3 n = (allObject.HasNormals ? allObject.NormalList[index] : Vector3.zero);
					Vector3 n2 = (allObject.HasNormals ? allObject.NormalList[index2] : Vector3.zero);
					Vector3 n3 = (allObject.HasNormals ? allObject.NormalList[index3] : Vector3.zero);
					Vector3 normalized = Vector3.Cross((vector2 - vector).normalized, (vector3 - vector).normalized).normalized;
					if (Vector3.Dot(Vector3.up, normalized) >= 0f)
					{
						tris.Add(new BVHTriangle(vector, vector2, vector3, n, n2, n3, num++, allObject.TerrainSourceID));
					}
				}
			}
			Bvh = new BVHNode(tris, nodes, ref finalPrims);
		}

		public static void BuildLbvhData(List<BVHNode> nodes, List<BVHTriangle> prims, out List<LBVHNODE> lNodes, out List<LBVHTriangle> lPrims)
		{
			lPrims = new List<LBVHTriangle>();
			lNodes = new List<LBVHNODE>();
			for (int i = 0; i < prims.Count; i++)
			{
				BVHTriangle bVHTriangle = prims[i];
				lPrims.Add(new LBVHTriangle(bVHTriangle.V0, bVHTriangle.V1, bVHTriangle.V2, bVHTriangle.N, bVHTriangle.TerrainSourceID));
			}
			for (int j = 0; j < nodes.Count; j++)
			{
				lNodes.Add(new LBVHNODE(nodes[j]));
			}
		}

		public static bool OverlapBbox(Vector3 aMin, Vector3 aMax, Vector3 bMin, Vector3 bMax)
		{
			if (aMax.x < bMin.x || aMin.x > bMax.x)
			{
				return false;
			}
			if (aMax.y < bMin.y || aMin.y > bMax.y)
			{
				return false;
			}
			if (aMax.z < bMin.z || aMin.z > bMax.z)
			{
				return false;
			}
			return true;
		}

		public static bool CalculateCellSize(int nodeID, List<LBVHNODE> nodes, ref Vector3 cellMinExtended, ref Vector3 cellMaxExtended, ref Vector3 cellMin, ref Vector3 cellMax)
		{
			if (nodes[nodeID].IsLeaf == 1)
			{
				Vector3 bMin = nodes[nodeID].BMin;
				Vector3 bMax = nodes[nodeID].BMax;
				if (OverlapBbox(cellMinExtended, cellMaxExtended, bMin, bMax))
				{
					if (bMin.y < cellMin.y)
					{
						cellMin.y = bMin.y;
					}
					if (bMax.y > cellMax.y)
					{
						cellMax.y = bMax.y;
					}
				}
			}
			else
			{
				CalculateCellSize(nodes[nodeID].LChildID, nodes, ref cellMinExtended, ref cellMaxExtended, ref cellMin, ref cellMax);
				CalculateCellSize(nodes[nodeID].RChildID, nodes, ref cellMinExtended, ref cellMaxExtended, ref cellMin, ref cellMax);
			}
			return true;
		}
	}
}
