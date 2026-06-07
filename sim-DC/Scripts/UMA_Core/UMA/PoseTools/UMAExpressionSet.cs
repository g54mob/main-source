using System;
using UnityEngine;

namespace UMA.PoseTools
{
	[Serializable]
	public class UMAExpressionSet : ScriptableObject
	{
		[Serializable]
		public class PosePair
		{
			public UMABonePose primary;

			public UMABonePose inverse;
		}

		public PosePair[] posePairs;

		[NonSerialized]
		private int[] boneHashes;

		private void ValidateBoneHashes()
		{
		}

		public void RestoreBones(UMASkeleton umaSkeleton, bool logErrors = false)
		{
		}

		public int[] GetAnimatedBoneHashes()
		{
			return null;
		}

		public Transform[] GetAnimatedBones(UMASkeleton umaSkeleton)
		{
			return null;
		}
	}
}
