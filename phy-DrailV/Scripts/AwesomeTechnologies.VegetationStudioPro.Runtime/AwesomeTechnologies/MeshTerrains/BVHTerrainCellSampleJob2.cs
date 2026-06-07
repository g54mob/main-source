using AwesomeTechnologies.Utility.BVHTree;
using AwesomeTechnologies.Utility.Quadtree;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	[BurstCompile(CompileSynchronously = true)]
	public struct BVHTerrainCellSampleJob2 : IJobParallelFor
	{
		public NativeArray<Bounds> VegetationCellBoundsList;

		[ReadOnly]
		public NativeArray<LBVHNODE> Nodes;

		public Rect TerrainRect;

		public void Execute(int index)
		{
			Bounds bounds = VegetationCellBoundsList[index];
			Rect other = RectExtension.CreateRectFromBounds(bounds);
			if (!TerrainRect.Overlaps(other))
			{
				return;
			}
			Vector3 cellMin = bounds.center - bounds.extents;
			Vector3 cellMax = bounds.center + bounds.extents;
			Vector3 vector = cellMin;
			Vector3 vector2 = cellMax;
			cellMin.y = float.MaxValue;
			cellMax.y = float.MinValue;
			Vector3 cellMinExtended = new Vector3(cellMin.x, float.MinValue, cellMin.z);
			Vector3 cellMaxExtended = new Vector3(cellMax.x, float.MaxValue, cellMax.z);
			if (CalculateCellSize(0, ref cellMinExtended, ref cellMaxExtended, ref cellMin, ref cellMax))
			{
				if (bounds.center.y > -99999f)
				{
					cellMax = math.max(cellMax, vector2);
					cellMin = math.min(cellMin, vector);
				}
				float y = (cellMin.y + cellMax.y) / 2f;
				float y2 = cellMax.y - cellMin.y;
				bounds = new Bounds(new Vector3(bounds.center.x, y, bounds.center.z), new Vector3(bounds.size.x, y2, bounds.size.z));
				if (float.IsNegativeInfinity(bounds.size.y))
				{
					bounds.center = new Vector3(bounds.center.x, -100000f, bounds.center.z);
				}
				VegetationCellBoundsList[index] = bounds;
			}
		}

		public bool CalculateCellSize(int nodeID, ref Vector3 cellMinExtended, ref Vector3 cellMaxExtended, ref Vector3 cellMin, ref Vector3 cellMax)
		{
			if (Nodes[nodeID].IsLeaf == 1)
			{
				Vector3 bMin = Nodes[nodeID].BMin;
				Vector3 bMax = Nodes[nodeID].BMax;
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
				CalculateCellSize(Nodes[nodeID].LChildID, ref cellMinExtended, ref cellMaxExtended, ref cellMin, ref cellMax);
				CalculateCellSize(Nodes[nodeID].RChildID, ref cellMinExtended, ref cellMaxExtended, ref cellMin, ref cellMax);
			}
			return true;
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
	}
}
