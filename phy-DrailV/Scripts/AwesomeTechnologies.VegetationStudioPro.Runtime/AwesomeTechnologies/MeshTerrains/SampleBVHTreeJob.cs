using AwesomeTechnologies.Utility.BVHTree;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace AwesomeTechnologies.MeshTerrains
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SampleBVHTreeJob : IJobParallelFor
	{
		public enum TraverseSstate
		{
			FromParent = 0,
			FromSibling = 1,
			FromChild = 2
		}

		[ReadOnly]
		public NativeArray<BVHRay> Rays;

		public NativeArray<HitInfo> HitInfos;

		[ReadOnly]
		public NativeArray<LBVHNODE> NativeNodes;

		[ReadOnly]
		public NativeArray<LBVHTriangle> NativePrims;

		public NativeArray<HitInfo> TempHi;

		public void Execute(int index)
		{
			if (Rays[index].DoRaycast == 0)
			{
				HitInfo value = new HitInfo
				{
					HitDistance = -1f
				};
				HitInfos[index] = value;
			}
			else
			{
				RayCastStackless(index);
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
			TraverseSstate traverseSstate = TraverseSstate.FromParent;
			bool result = false;
			float num2 = float.MaxValue;
			while (lBVHNODE.NodeID != nodeID)
			{
				switch (traverseSstate)
				{
				case TraverseSstate.FromChild:
				{
					int nodeID3 = lBVHNODE.NodeID;
					lBVHNODE = NativeNodes[lBVHNODE.ParentID];
					num = direction[lBVHNODE.SplitAxis];
					lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
					lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
					if (nodeID3 == lBVHNODE.NearNodeID)
					{
						lBVHNODE = NativeNodes[lBVHNODE.FarNodeID];
						traverseSstate = TraverseSstate.FromSibling;
					}
					else
					{
						traverseSstate = TraverseSstate.FromChild;
					}
					break;
				}
				case TraverseSstate.FromSibling:
					if (!lBVHNODE.IntersectRay(Rays[index]))
					{
						lBVHNODE = NativeNodes[lBVHNODE.ParentID];
						traverseSstate = TraverseSstate.FromChild;
					}
					else if (lBVHNODE.IsLeaf == 1)
					{
						if (NativePrims[lBVHNODE.PrimitivesOffset].IntersectRay(Rays[index], ref TempHi, index) && TempHi[index].HitDistance < num2)
						{
							num2 = TempHi[index].HitDistance;
							HitInfos[index] = TempHi[index];
							result = true;
						}
						lBVHNODE = NativeNodes[lBVHNODE.ParentID];
						traverseSstate = TraverseSstate.FromChild;
					}
					else
					{
						num = direction[lBVHNODE.SplitAxis];
						lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
						lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
						lBVHNODE = NativeNodes[lBVHNODE.NearNodeID];
						traverseSstate = TraverseSstate.FromParent;
					}
					break;
				case TraverseSstate.FromParent:
					if (!lBVHNODE.IntersectRay(Rays[index]))
					{
						int nodeID2 = lBVHNODE.NodeID;
						lBVHNODE = NativeNodes[lBVHNODE.ParentID];
						num = direction[lBVHNODE.SplitAxis];
						lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
						lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
						lBVHNODE = ((nodeID2 == lBVHNODE.NearNodeID) ? NativeNodes[lBVHNODE.FarNodeID] : NativeNodes[lBVHNODE.NearNodeID]);
						traverseSstate = TraverseSstate.FromSibling;
					}
					else if (lBVHNODE.IsLeaf == 1)
					{
						if (NativePrims[lBVHNODE.PrimitivesOffset].IntersectRay(Rays[index], ref TempHi, index) && TempHi[index].HitDistance < num2)
						{
							num2 = TempHi[index].HitDistance;
							HitInfos[index] = TempHi[index];
							result = true;
						}
						NativeNodes[lBVHNODE.ParentID].GetChildrenIDsAndSplitAxis(out var lChildID, out var rChildID, out var splitAxis);
						num = direction[splitAxis];
						int index2 = math.select(rChildID, lChildID, num < 0f);
						lBVHNODE = NativeNodes[index2];
						traverseSstate = TraverseSstate.FromSibling;
					}
					else
					{
						num = direction[lBVHNODE.SplitAxis];
						lBVHNODE.NearNodeID = math.select(lBVHNODE.LChildID, lBVHNODE.RChildID, num < 0f);
						lBVHNODE.FarNodeID = math.select(lBVHNODE.RChildID, lBVHNODE.LChildID, num < 0f);
						lBVHNODE = NativeNodes[lBVHNODE.NearNodeID];
						traverseSstate = TraverseSstate.FromParent;
					}
					break;
				}
			}
			return result;
		}
	}
}
