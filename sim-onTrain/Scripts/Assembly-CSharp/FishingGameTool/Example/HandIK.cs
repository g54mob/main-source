using FishingGameTool.Fishing;
using UnityEngine;

namespace FishingGameTool.Example
{
	public class HandIK : MonoBehaviour
	{
		public Transform _leftHand;

		public Transform _leftHandPole;

		public Transform _rightHand;

		public Transform _rightHandPole;

		[Space]
		public Animator _handleFishingRodAnim;

		public FishingSystem _fishingSystem;

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			AnimationControl();
		}

		private void AnimationControl()
		{
			bool caughtLoot = _fishingSystem._advanced._caughtLoot;
			bool attractInput = _fishingSystem._attractInput;
			bool castFloat = _fishingSystem._castFloat;
			if (_fishingSystem._advanced._caughtLoot)
			{
				float angle = Vector3.Angle(_fishingSystem._fishingRod._fishingFloat.position - base.transform.position, base.transform.right) - 90f;
				_handleFishingRodAnim.SetFloat("AttractLootDir", CalculateAttractDir(angle));
			}
			_handleFishingRodAnim.SetBool("CaughtLoot", caughtLoot);
			_handleFishingRodAnim.SetBool("AttractLoot", attractInput);
			_handleFishingRodAnim.SetBool("CastFloat", castFloat);
		}

		private static float CalculateAttractDir(float angle)
		{
			float b = 60f;
			float t = Mathf.InverseLerp(-60f, b, angle);
			return Mathf.Lerp(-1f, 1f, t);
		}

		private void OnAnimatorIK(int layerIndex)
		{
			_animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHand.position);
			_animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHand.position);
			_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
			_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
			_animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHand.rotation);
			_animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHand.rotation);
			_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
			_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
			_animator.SetIKHintPosition(AvatarIKHint.LeftElbow, _leftHandPole.position);
			_animator.SetIKHintPosition(AvatarIKHint.RightElbow, _rightHandPole.position);
			_animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1f);
			_animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1f);
		}
	}
}
