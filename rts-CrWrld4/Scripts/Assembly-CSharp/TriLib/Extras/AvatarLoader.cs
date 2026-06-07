using System.Collections.Generic;
using UnityEngine;

namespace TriLib.Extras
{
	public class AvatarLoader : MonoBehaviour
	{
		public GameObject CurrentAvatar;

		public RuntimeAnimatorController RuntimeAnimatorController;

		public float ArmStretch;

		public float FeetSpacing;

		public bool HasTranslationDof;

		public float LegStretch;

		public float LowerArmTwist;

		public float LowerLegTwist;

		public float UpperArmTwist;

		public float UpperLegTwist;

		public float Scale;

		public float HeightOffset;

		public BoneRelationshipList CustomBoneNames;

		private static readonly BoneRelationshipList BipedBoneNames;

		private static readonly BoneRelationshipList MixamoBoneNames;

		private AssetLoaderOptions _loaderOptions;

		protected void Start()
		{
		}

		public bool LoadAvatarFromMemory(byte[] data, string extension, GameObject templateAvatar)
		{
			return false;
		}

		public bool LoadAvatar(string filename, GameObject templateAvatar)
		{
			return false;
		}

		private bool BuildAvatar()
		{
			return false;
		}

		private Dictionary<string, Transform> FindOutBoneTransforms(GameObject loadedObject)
		{
			return null;
		}

		private void SetupCapsuleCollider()
		{
		}

		private static SkeletonBone CreateSkeletonBone(Transform boneTransform)
		{
			return default(SkeletonBone);
		}

		private static HumanBone CreateHumanBone(string humanName, string boneName)
		{
			return default(HumanBone);
		}
	}
}
