using UnityEngine;

namespace VRM
{
	public static class VRMBoneExtensions
	{
		public static VRMBone FromHumanBodyBone(this HumanBodyBones human)
		{
			return human.ToVrmBone();
		}

		public static HumanBodyBones ToHumanBodyBone(this VRMBone bone)
		{
			return bone.ToUnityBone();
		}
	}
}
