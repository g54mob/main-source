using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	public struct Skeleton
	{
		private Dictionary<HumanBodyBones, int> m_indexMap;

		public Dictionary<HumanBodyBones, int> Bones => m_indexMap;

		public int GetBoneIndex(HumanBodyBones bone)
		{
			if (m_indexMap.TryGetValue(bone, out var value))
			{
				return value;
			}
			return -1;
		}

		public static Skeleton Estimate(Transform hips)
		{
			return new BvhSkeletonEstimator().Detect(hips);
		}

		public void Set(HumanBodyBones bone, IList<IBone> bones, IBone b)
		{
			if (b != null)
			{
				Set(bone, bones.IndexOf(b), b.Name);
			}
		}

		public void Set(HumanBodyBones bone, int index, string name)
		{
			if (m_indexMap == null)
			{
				m_indexMap = new Dictionary<HumanBodyBones, int>();
			}
			m_indexMap[bone] = index;
		}
	}
}
