using AwesomeTechnologies.Utility.BVHTree;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace AwesomeTechnologies.MeshTerrains
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SampleBVHTreeMultiLevelJob : IJob
	{
		[ReadOnly]
		public NativeArray<BVHRay> Rays;

		public NativeList<HitInfo> HitInfos;

		[ReadOnly]
		public NativeArray<LBVHNODE> NativeNodes;

		[ReadOnly]
		public NativeArray<LBVHTriangle> NativePrims;

		public NativeArray<HitInfo> TempHi;

		public void Execute()
		{
			for (int i = 0; i <= Rays.Length - 1; i++)
			{
				if (Rays[i].DoRaycast != 0)
				{
					RayCastStackless(i);
				}
			}
		}

		public bool RayCastStackless(int index)
		{
			LBVHNODE lBVHNODE = NativeNodes[0];
			float3 direction = Rays[index].Direction;
			float num = direction[lBVHNODE.SplitAxis];
			lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
			lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
			int nearNodeID = lBVHNODE.NearNodeID;
			int nodeID = lBVHNODE.NodeID;
			lBVHNODE = NativeNodes[nearNodeID];
			TraverseState traverseState = TraverseState.FromParent;
			bool result = false;
			while (lBVHNODE.NodeID != nodeID)
			{
				float hitDist;
				switch (traverseState)
				{
				case TraverseState.FromChild:
				{
					int nodeID3 = lBVHNODE.NodeID;
					lBVHNODE = NativeNodes[lBVHNODE.ParentID];
					num = direction[lBVHNODE.SplitAxis];
					lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
					lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
					if (nodeID3 == lBVHNODE.NearNodeID)
					{
						lBVHNODE = NativeNodes[lBVHNODE.FarNodeID];
						traverseState = TraverseState.FromSibling;
					}
					else
					{
						traverseState = TraverseState.FromChild;
					}
					break;
				}
				case TraverseState.FromSibling:
					if (!BVHBBox.IntersectRay(Rays[index], lBVHNODE.BMin, lBVHNODE.BMax, out hitDist))
					{
						lBVHNODE = NativeNodes[lBVHNODE.ParentID];
						traverseState = TraverseState.FromChild;
					}
					else if (lBVHNODE.IsLeaf == 1)
					{
						if (NativePrims[lBVHNODE.PrimitivesOffset].IntersectRay(Rays[index], ref TempHi, index))
						{
							HitInfos.Add(TempHi[index]);
							result = true;
						}
						lBVHNODE = NativeNodes[lBVHNODE.ParentID];
						traverseState = TraverseState.FromChild;
					}
					else
					{
						num = direction[lBVHNODE.SplitAxis];
						lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
						lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
						lBVHNODE = NativeNodes[lBVHNODE.NearNodeID];
						traverseState = TraverseState.FromParent;
					}
					break;
				case TraverseState.FromParent:
					if (!BVHBBox.IntersectRay(Rays[index], lBVHNODE.BMin, lBVHNODE.BMax, out hitDist))
					{
						int nodeID2 = lBVHNODE.NodeID;
						lBVHNODE = NativeNodes[lBVHNODE.ParentID];
						num = direction[lBVHNODE.SplitAxis];
						lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
						lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
						if (nodeID2 == lBVHNODE.NearNodeID)
						{
							lBVHNODE = NativeNodes[lBVHNODE.FarNodeID];
							traverseState = TraverseState.FromSibling;
						}
						else
						{
							lBVHNODE = NativeNodes[lBVHNODE.NearNodeID];
							traverseState = TraverseState.FromSibling;
						}
					}
					else if (lBVHNODE.IsLeaf == 1)
					{
						if (NativePrims[lBVHNODE.PrimitivesOffset].IntersectRay(Rays[index], ref TempHi, index))
						{
							HitInfos.Add(TempHi[index]);
							result = true;
						}
						NativeNodes[lBVHNODE.ParentID].GetChildrenIDsAndSplitAxis(out var lChildID, out var rChildID, out var splitAxis);
						num = direction[splitAxis];
						int index2 = math.select(rChildID, lChildID, num < 0f);
						lBVHNODE = NativeNodes[index2];
						traverseState = TraverseState.FromSibling;
					}
					else
					{
						num = direction[lBVHNODE.SplitAxis];
						lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
						lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
						lBVHNODE = NativeNodes[lBVHNODE.NearNodeID];
						traverseState = TraverseState.FromParent;
					}
					break;
				}
			}
			return result;
		}

		public bool RayCast(int index, int nodeID)
		{
			float hitDist;
			if (NativeNodes[nodeID].IsLeaf == 1)
			{
				float num = float.MaxValue;
				HitInfo hitInfo = default(HitInfo);
				for (int i = 0; i < NativeNodes[nodeID].PrimitivesCount; i++)
				{
					hitInfo.Clear();
					if (NativePrims[NativeNodes[nodeID].PrimitivesOffset + i].IntersectRay(Rays[index], out hitInfo) && hitInfo.HitDistance < num)
					{
						num = hitInfo.HitDistance;
						HitInfos.Add(new HitInfo(hitInfo));
					}
				}
			}
			else if (BVHBBox.IntersectRay(Rays[index], NativeNodes[nodeID].BMin, NativeNodes[nodeID].BMax, out hitDist))
			{
				int lChildID = NativeNodes[nodeID].LChildID;
				int rChildID = NativeNodes[nodeID].RChildID;
				float hitDist2;
				bool flag = BVHBBox.IntersectRay(Rays[index], NativeNodes[lChildID].BMin, NativeNodes[lChildID].BMax, out hitDist2);
				float hitDist3;
				bool flag2 = BVHBBox.IntersectRay(Rays[index], NativeNodes[rChildID].BMin, NativeNodes[rChildID].BMax, out hitDist3);
				if (flag && flag2)
				{
					if (hitDist2 > hitDist3)
					{
						RayCast(index, lChildID);
						RayCast(index, rChildID);
					}
					else
					{
						RayCast(index, rChildID);
						RayCast(index, lChildID);
					}
				}
				else if (flag)
				{
					RayCast(index, lChildID);
				}
				else if (flag2)
				{
					RayCast(index, rChildID);
				}
			}
			return false;
		}
	}
}
