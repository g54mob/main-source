using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Animator/Blink Eyes")]
	public class BlinkEyes : MonoBehaviour, IAnimatorListener
	{
		[RequiredField]
		public Animator animator;

		public string parameter = "Eyes";

		Transform IAnimatorListener.transform => base.transform;

		public virtual void Eyes(int ID)
		{
			animator.SetInteger(parameter, ID);
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
