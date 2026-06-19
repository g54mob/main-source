using UnityEngine;

namespace TH20
{
	public class SMB_CharacterController : StateMachineBehaviour
	{
		[SerializeField]
		private float _idleThreshold = 0.3f;

		[SerializeField]
		private string _paramIsIdle = "Idle";

		[SerializeField]
		private string _paramWalkSpeed = "WalkSpeed";

		[SerializeField]
		private string _paramIdleVariant = "IdleVariant";

		[SerializeField]
		private string _paramWalkVariant = "WalkVariant";

		private const string IdleStateName = "Idle";

		private bool _cached;

		private bool _hasParamIsIdle;

		private bool _hasParamWalkSpeed;

		private bool _hasParamIdleVariant;

		private bool _hasParamWalkVariant;

		private CharacterAnimationController _controller;

		private void CacheValues(Animator animator)
		{
			if (!_cached)
			{
				_cached = true;
				_hasParamIsIdle = animator.HasParameter(_paramIsIdle);
				_hasParamWalkSpeed = animator.HasParameter(_paramWalkSpeed);
				_hasParamIdleVariant = animator.HasParameter(_paramIdleVariant);
				_hasParamWalkVariant = animator.HasParameter(_paramWalkVariant);
				_controller = animator.gameObject.GetComponent<CharacterAnimationController>();
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			CacheValues(animator);
			if (_controller != null)
			{
				Character character = _controller.Character;
				if (_hasParamIsIdle && _hasParamWalkSpeed)
				{
					float movementSpeed = character.MovementSpeed;
					bool value = movementSpeed <= _idleThreshold;
					animator.SetBool(_paramIsIdle, value);
					animator.SetFloat(_paramWalkSpeed, movementSpeed);
				}
				if (animator.IsInState("Idle") && animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime >= 1f)
				{
					ChooseIdle(animator);
					animator.Play("Idle", layerIndex, 0f);
				}
				ChooseWalk(animator);
			}
			base.OnStateUpdate(animator, stateInfo, layerIndex);
		}

		private static float IndexToBlend(int index, int range)
		{
			return 1f / (float)(range - 1) * (float)index;
		}

		private void ChooseIdle(Animator animator)
		{
			if (_hasParamIdleVariant)
			{
				IdleAnimation idleAnimOverride = _controller.Character.GetIdleAnimOverride();
				IdleAnimation index = ((idleAnimOverride != IdleAnimation.Max) ? idleAnimOverride : _controller.Character.GetIdleAnim());
				animator.SetFloat(_paramIdleVariant, IndexToBlend((int)index, 16));
			}
		}

		private void ChooseWalk(Animator animator)
		{
			if (_hasParamWalkVariant)
			{
				WalkAnimation walkAnimOverride = _controller.Character.GetWalkAnimOverride();
				WalkAnimation index = ((walkAnimOverride != WalkAnimation.Max) ? walkAnimOverride : _controller.Character.GetWalkAnim());
				animator.SetFloat(_paramWalkVariant, IndexToBlend((int)index, 5));
			}
		}
	}
}
