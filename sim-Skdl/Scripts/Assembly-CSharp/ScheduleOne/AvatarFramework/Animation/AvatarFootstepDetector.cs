using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Animation
{
	[RequireComponent(typeof(Avatar))]
	public class AvatarFootstepDetector : GenericFootstepDetector
	{
		private const float StepThreshold = 0.125f;

		[SerializeField]
		private float _detectionRange;

		private Avatar _avatar;

		private bool _leftDown;

		private bool _rightDown;

		private float _detectionRangeSqr;

		private Transform _leftBone => null;

		private Transform _rightBone => null;

		private void Awake()
		{
		}

		protected virtual void LateUpdate()
		{
		}
	}
}
