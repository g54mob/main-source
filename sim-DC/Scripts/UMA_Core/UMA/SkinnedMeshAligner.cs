using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public static class SkinnedMeshAligner
	{
		public static void AlignBindPose(SkinnedMeshRenderer template, SkinnedMeshRenderer data)
		{
		}

		private static int FindBoneIndexInHierarchy(Transform bone, Transform hierarchyRoot, Dictionary<Transform, Transform> boneMap, Dictionary<Transform, int> boneIndexes)
		{
			return 0;
		}

		private static Transform RecursiveFindBoneInHierarchy(Transform bone, Transform hierarchyRoot, Dictionary<Transform, Transform> boneMap)
		{
			return null;
		}
	}
}
