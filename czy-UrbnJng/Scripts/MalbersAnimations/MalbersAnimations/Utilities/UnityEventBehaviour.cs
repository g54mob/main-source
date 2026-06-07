using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	public class UnityEventBehaviour : StateMachineBehaviour
	{
		[Range(0f, 1f)]
		[SerializeField]
		private float _time;

		[SerializeField]
		private AnimatorEvent Invoke;

		private bool MessageSent;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			MessageSent = false;
			if (_time == 0f)
			{
				Invoke.Invoke(animator);
				MessageSent = true;
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo state, int layer)
		{
			float num = state.normalizedTime % 1f;
			if (!MessageSent && num >= _time)
			{
				Invoke.Invoke(animator);
				MessageSent = true;
			}
		}

		public void Pause()
		{
			Debug.Log("Pause Editor", this);
			Debug.Break();
		}
	}
}
