using UnityEngine;

namespace Player.Animations
{
	public class ArmsAnimator : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		private int _startDrinkHash = Animator.StringToHash("StartDrink");

		private int _stopDrinkHash = Animator.StringToHash("StopDrinking");

		private int _startSmokingHash = Animator.StringToHash("StartSmoking");

		private int _stopSmokingHash = Animator.StringToHash("StopSmoking");

		private int _drinkingLoopHash = Animator.StringToHash("Drinking");

		private int _smokingLoopHash = Animator.StringToHash("Smoking");

		private int _pushingHash = Animator.StringToHash("Pushing");

		public void EnablePushing()
		{
			_animator.SetBool(_pushingHash, value: true);
		}

		public void DisablePushing()
		{
			_animator.SetBool(_pushingHash, value: false);
		}

		public void StartDrinkingAnimation()
		{
			_animator.ResetTrigger(_stopDrinkHash);
			_animator.SetTrigger(_startDrinkHash);
		}

		public void StopDrinkingAnimation()
		{
			_animator.ResetTrigger(_startDrinkHash);
			_animator.SetTrigger(_stopDrinkHash);
		}

		public void StartSmokingAnimation()
		{
			_animator.ResetTrigger(_stopSmokingHash);
			_animator.SetTrigger(_startSmokingHash);
		}

		public void StopSmokingAnimation()
		{
			_animator.ResetTrigger(_startSmokingHash);
			_animator.SetTrigger(_stopSmokingHash);
		}

		public void SmokinLoop(bool value)
		{
			_animator.SetBool(_smokingLoopHash, value);
		}

		public void DrinkingLoop(bool value)
		{
			_animator.SetBool(_drinkingLoopHash, value);
		}
	}
}
