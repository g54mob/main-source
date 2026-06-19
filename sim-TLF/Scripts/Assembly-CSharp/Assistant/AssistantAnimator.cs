using UnityEngine;

namespace Assistant
{
	public class AssistantAnimator : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		public void EnableBlush(bool value)
		{
			_animator.SetBool("isBlushing", value);
		}

		public void SetBrowsAngry()
		{
			_animator.SetTrigger("browsAngry");
		}

		public void SetBrowsRelaxed()
		{
			_animator.SetTrigger("browsRelaxed");
		}

		public void SetBrowsSurprised()
		{
			_animator.SetTrigger("browsSurprised");
		}

		public void SetEyesClosed(bool value)
		{
			_animator.SetBool("eyesClosed", value);
		}

		public void SetSmile()
		{
			_animator.SetTrigger("smile");
		}

		public void SetBigSmile()
		{
			_animator.SetTrigger("bigSmile");
		}

		public void SetSmileNeutral()
		{
			_animator.SetTrigger("faceNeutral");
		}

		public void SetSpeak()
		{
			_animator.SetTrigger("speak");
		}

		public void SetMouthAngry()
		{
			_animator.SetTrigger("mouthAngry");
		}
	}
}
