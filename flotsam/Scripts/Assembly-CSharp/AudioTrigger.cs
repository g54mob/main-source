using UnityEngine;
using UnityEngine.Serialization;

public class AudioTrigger : StateMachineBehaviour
{
	[Tooltip("Audio to play on entering the state.")]
	[SerializeField]
	[FormerlySerializedAs("audioOnStart")]
	private AudioClipProperties _audioOnEnter;

	[Tooltip("Audio to play on exiting the state.")]
	[SerializeField]
	[FormerlySerializedAs("audioOnEnd")]
	private AudioClipProperties _audioOnExit;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!(_audioOnEnter == null))
		{
			AudioManager.Play(_audioOnEnter, animator.transform);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!(_audioOnExit == null))
		{
			AudioManager.Play(_audioOnExit, animator.transform);
		}
	}
}
