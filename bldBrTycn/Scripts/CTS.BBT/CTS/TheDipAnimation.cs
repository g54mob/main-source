using UnityEngine;

namespace CTS
{
	public class TheDipAnimation : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		public void ResetTriggerClose()
		{
			_animator.ResetTrigger("CloseDoor");
		}

		public void ResetTriggerOpen()
		{
			_animator.ResetTrigger("OpenDoor");
		}

		public void OpenOrCloseMorgue(bool value)
		{
			if (value)
			{
				_animator.SetTrigger("OpenDoor");
			}
			else
			{
				_animator.SetTrigger("CloseDoor");
			}
		}
	}
}
