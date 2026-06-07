using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	public class EventBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private MEvent _mEvent;

		[Range(0f, 1f)]
		[SerializeField]
		private float _time;

		[SerializeField]
		private AnimalEvent _animalEvent = new AnimalEvent();

		private bool MessageSent;

		public AnimalEvent AnimalEvent => _animalEvent;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			MessageSent = false;
			if (_time == 0f)
			{
				_animalEvent.Invoke(_mEvent);
				MessageSent = true;
			}
		}

		public override void OnStateUpdate(Animator anim, AnimatorStateInfo state, int layer)
		{
			float num = state.normalizedTime % 1f;
			if (!MessageSent && num >= _time)
			{
				_animalEvent.Invoke(_mEvent);
				MessageSent = true;
			}
		}
	}
}
