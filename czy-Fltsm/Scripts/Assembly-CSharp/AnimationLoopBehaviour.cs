using UnityEngine;

public class AnimationLoopBehaviour : StateMachineBehaviour
{
	[SerializeField]
	private AnimationClip _enterClip;

	[SerializeField]
	private AnimationClip _exitClip;

	[SerializeField]
	private string _triggerName = "";

	private float _timer;

	private float _triggerTime;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		float num = animator.GetFloat("Transition Time");
		float length = _enterClip.length;
		float length2 = _exitClip.length;
		if (num < length + length2)
		{
			Debug.LogError($"Entered animation state {animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.name} but the enter and exit length is longer than the loop time.");
		}
		_triggerTime = num - length - length2;
		_timer = 0f;
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator, stateInfo, layerIndex);
		_timer += Time.deltaTime;
		if (_timer >= _triggerTime)
		{
			animator.SetTrigger(_triggerName);
		}
	}
}
