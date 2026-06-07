using UnityEngine;

namespace Assets.Scripts.XR.HandPoses
{
	[CreateAssetMenu(fileName = "HandPose", menuName = "XR/SP Hand Pose")]
	public class GripPose : ScriptableObject
	{
		[SerializeField]
		private AnimationClip _leftHandAnimation;

		[SerializeField]
		private Pose _leftHandOffset;

		[SerializeField]
		private bool _overridePoint;

		[SerializeField]
		private bool _overrideThumbsUp;

		[SerializeField]
		private AnimationClip _rightHandAnimation;

		[SerializeField]
		private Pose _rightHandOffset;

		public AnimationClip LeftHandAnimation
		{
			get
			{
				return _leftHandAnimation;
			}
			set
			{
				_leftHandAnimation = value;
			}
		}

		public Pose LeftHandOffset
		{
			get
			{
				return _leftHandOffset;
			}
			set
			{
				_leftHandOffset = value;
			}
		}

		public bool OverridePoint
		{
			get
			{
				return _overridePoint;
			}
			set
			{
				_overridePoint = value;
			}
		}

		public bool OverrideThumbsUp
		{
			get
			{
				return _overrideThumbsUp;
			}
			set
			{
				_overrideThumbsUp = value;
			}
		}

		public AnimationClip RightHandAnimation
		{
			get
			{
				return _rightHandAnimation;
			}
			set
			{
				_rightHandAnimation = value;
			}
		}

		public Pose RightHandOffset
		{
			get
			{
				return _rightHandOffset;
			}
			set
			{
				_rightHandOffset = value;
			}
		}
	}
}
