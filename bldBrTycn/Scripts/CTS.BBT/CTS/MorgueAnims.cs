using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MorgueAnims : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private AudioAsset _open;

		private AudioSource _audioSource;

		public void OpenOrCloseMorgue(bool value)
		{
			if (value)
			{
				_animator.SetTrigger("Open");
				_audioSource = MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_open, base.gameObject.transform.position);
			}
			else
			{
				_animator.SetTrigger("Close");
			}
		}

		public void CloseSound()
		{
			if (_audioSource != null)
			{
				_audioSource.Stop();
			}
		}
	}
}
