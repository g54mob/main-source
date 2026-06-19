using UnityEngine;

namespace TH20
{
	public class SuperBugCompleteBanner : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		private bool _completionAudioPlayed;

		public void SetIsCompleted(bool isCompleted)
		{
			_animator.SetBool("IsCompleted", isCompleted);
			if (isCompleted && !_completionAudioPlayed)
			{
				_completionAudioPlayed = true;
				AudioManager.Instance.Play("CompleteGlobalCollab");
			}
		}
	}
}
