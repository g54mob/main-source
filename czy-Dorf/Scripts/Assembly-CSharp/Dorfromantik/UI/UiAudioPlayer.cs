using UnityEngine;

namespace Dorfromantik.UI
{
	public class UiAudioPlayer : MonoBehaviour
	{
		[SerializeField]
		internal AudioClipOptions clickSound;

		[SerializeField]
		internal AudioClipOptions hoverSound;

		[SerializeField]
		internal AudioClipOptions clickInvalidSound;

		public void PlayAudio(AudioClipOptions audioClip)
		{
			if (!(audioClip == null))
			{
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayGlobalSound(audioClip);
				}
				else
				{
					Debug.LogError($"No Sound effect played! {audioClip} could not be played, because {AudioManager.Instance} was not found!");
				}
			}
		}
	}
}
