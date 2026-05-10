using UnityEngine;

namespace RootMotion
{
	public class HumanoidBaker : Baker
	{
		[Tooltip("Should the hand IK curves be added to the animation? Disable this if the original hand positions are not important when using the clip on another character via Humanoid retargeting.")]
		public bool bakeHandIK;

		[Range(0f, 0.1f)]
		[Tooltip("Max keyframe reduction error for the Root.Q/T, LeftFoot IK and RightFoot IK channels. Having a larger error value for 'Key Reduction Error' and a smaller one for this enables you to optimize clip data size without the floating feet effect by enabling 'Foot IK' in the Animator.")]
		public float IKKeyReductionError;

		[Tooltip("Frame rate divider for the muscle curves. If you have 'Frame Rate' set to 30, and this value set to 3, the muscle curves will be baked at 10 fps. Only the Root Q/T and Hand and Foot IK curves will be baked at 30. This enables you to optimize clip data size without the floating feet effect by enabling 'Foot IK' in the Animator.")]
		[Range(1f, 9f)]
		public int muscleFrameRateDiv;

		private BakerMuscle[] bakerMuscles;

		private BakerHumanoidQT rootQT;

		private BakerHumanoidQT leftFootQT;

		private BakerHumanoidQT rightFootQT;

		private BakerHumanoidQT leftHandQT;

		private BakerHumanoidQT rightHandQT;

		private float[] muscles;

		private HumanPose pose;

		private HumanPoseHandler handler;

		private Vector3 bodyPosition;

		private Quaternion bodyRotation;

		private int mN;

		private Quaternion lastBodyRotation;

		private void Awake()
		{
		}

		protected override Transform GetCharacterRoot()
		{
			return null;
		}

		protected override void OnStartBaking()
		{
		}

		protected override void OnSetLoopFrame(float time)
		{
		}

		protected override void OnSetCurves(ref AnimationClip clip)
		{
		}

		protected override void OnSetKeyframes(float time, bool lastFrame)
		{
		}

		private void UpdateHumanPose()
		{
		}
	}
}
