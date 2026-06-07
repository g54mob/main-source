using System;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[RequireComponent(typeof(Animator))]
	public class AnimatorLink : MonoBehaviour
	{
		private Animator _animator;

		private bool _resetIKWeightsFlag;

		public event Action OnAnimatorMoveEvent;

		public event Action<int> OnAnimatorIKEvent;

		public void ResetIKWeights()
		{
			_resetIKWeightsFlag = true;
		}

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void OnAnimatorMove()
		{
			this.OnAnimatorMoveEvent?.Invoke();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (_resetIKWeightsFlag)
			{
				_resetIKWeightsFlag = false;
				_animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
				_animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
				_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
				_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
			}
			this.OnAnimatorIKEvent?.Invoke(layerIndex);
		}
	}
}
