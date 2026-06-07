using System;
using AwesomeTechnologies.MeshTerrains;
using Unity.Mathematics;

namespace AwesomeTechnologies.Utility.BVHTree
{
	[Serializable]
	public struct LBVHNODE
	{
		public float3 BMin;

		public float3 BMax;

		public int NodeID;

		public int PrimitivesCount;

		public int PrimitivesOffset;

		public int ParentID;

		public int LChildID;

		public int RChildID;

		public int IsLeaf;

		public int NearNodeID;

		public int FarNodeID;

		public int SplitAxis;

		public LBVHNODE(BVHNode node)
		{
			BMin = node.Min;
			BMax = node.Max;
			NodeID = node.NodeID;
			PrimitivesCount = node.PrimitivesCount;
			PrimitivesOffset = node.PrimitivesOffset;
			ParentID = node.ParentID;
			LChildID = node.LChildID;
			RChildID = node.RChildID;
			IsLeaf = node.IsLeaf;
			SplitAxis = node.SplitAxis;
			NearNodeID = -1;
			FarNodeID = -1;
		}

		public void GetChildrenIDsAndSplitAxis(out int lChildID, out int rChildID, out int splitAxis)
		{
			lChildID = LChildID;
			rChildID = RChildID;
			splitAxis = SplitAxis;
		}

		public bool IntersectRay(BVHRay r)
		{
			float num = 1f / r.Direction.x;
			float num2 = 1f / r.Direction.y;
			float num3 = 1f / r.Direction.z;
			float x = r.Origin.x;
			float y = r.Origin.y;
			float z = r.Origin.z;
			float x2;
			float x3;
			if (num >= 0f)
			{
				x2 = (BMin.x - x) * num;
				x3 = (BMax.x - x) * num;
			}
			else
			{
				x2 = (BMax.x - x) * num;
				x3 = (BMin.x - x) * num;
			}
			float x4;
			float x5;
			if (num2 >= 0f)
			{
				x4 = (BMin.y - y) * num2;
				x5 = (BMax.y - y) * num2;
			}
			else
			{
				x4 = (BMax.y - y) * num2;
				x5 = (BMin.y - y) * num2;
			}
			float y2;
			float y3;
			if (num3 >= 0f)
			{
				y2 = (BMin.z - z) * num3;
				y3 = (BMax.z - z) * num3;
			}
			else
			{
				y2 = (BMax.z - z) * num3;
				y3 = (BMin.z - z) * num3;
			}
			float num4 = math.max(x2, math.max(x4, y2));
			float num5 = math.min(x3, math.min(x5, y3));
			return num4 <= num5;
		}
	}
}
