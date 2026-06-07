using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.PoseTools
{
	[Serializable]
	public class UMABonePose : ScriptableObject
	{
		[Serializable]
		public class PoseBone
		{
			public string bone;

			public int hash;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3 scale;

			public string category;
		}

		public PoseBone[] poses;

		public UMABonePose[] tweenPoses;

		public float[] tweenWeights;

		private void Reset()
		{
		}

		private void OnEnable()
		{
		}

		public int PoseCount()
		{
			return 0;
		}

		protected float ApplyPoseTweens(UMASkeleton umaSkeleton, float weight)
		{
			return 0f;
		}

		public void ApplyPose(UMASkeleton umaSkeleton, float weight)
		{
		}

		private static void RecurseTransformsInPrefab(Transform root, List<Transform> transforms)
		{
		}

		public static Transform[] GetTransformsInPrefab(Transform prefab)
		{
			return null;
		}
	}
}
