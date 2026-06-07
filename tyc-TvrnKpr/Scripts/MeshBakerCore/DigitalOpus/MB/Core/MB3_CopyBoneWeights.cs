using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB3_CopyBoneWeights
	{
		public static void CopyBoneWeightsFromSeamMeshToOtherMeshes(float radius, Mesh seamMesh, Mesh[] targetMeshes, Transform[][] newBonesForSMRs, Transform[] seamMeshBones, Transform[][] targMeshBones)
		{
		}

		private static void RemapBoneWeightIndexes(string nm, ref BoneWeight seamMeshBw, int[] map_seamMeshIdx2targMeshIdx, Transform[] targBones, Dictionary<int, int> extraBones, Transform[] seamBones)
		{
		}
	}
}
