using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class AddBoneFollowerAfterXFrames : MonoBehaviour
	{
		public SkeletonRenderer SkeletonRenderer;

		public string BoneName;

		public int FrameCount = 2;

		public bool ShouldFollowRotation = true;

		public bool ShouldFollowZPosition = true;

		public bool ShouldFollowLocalScale;

		public bool ShouldFollowZSkeletonFlip = true;

		private int _frames;

		private void Update()
		{
			if (_frames >= FrameCount)
			{
				BoneFollower boneFollower = base.gameObject.AddComponent<BoneFollower>();
				boneFollower.skeletonRenderer = SkeletonRenderer;
				boneFollower.SetBone(BoneName);
				boneFollower.followBoneRotation = ShouldFollowRotation;
				boneFollower.followZPosition = ShouldFollowZPosition;
				boneFollower.followLocalScale = ShouldFollowLocalScale;
				boneFollower.followSkeletonFlip = ShouldFollowZSkeletonFlip;
				boneFollower.Initialize();
				Object.Destroy(this);
			}
			_frames++;
		}
	}
}
