using UnityEngine;

public class OnExitDrifterRigEventBehaviour : StateMachineBehaviour
{
	[SerializeField]
	private DrifterRigEventType _eventType;

	private AnimationTools _animationTools;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (_animationTools == null)
		{
			if (animator.TryGetComponent<AnimationTools>(out _animationTools))
			{
				_eventType.Dispatch(_animationTools);
			}
		}
		else
		{
			_eventType.Dispatch(_animationTools);
		}
	}
}
