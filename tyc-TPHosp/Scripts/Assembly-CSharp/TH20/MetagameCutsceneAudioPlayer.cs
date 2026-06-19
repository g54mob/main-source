using UnityEngine;

namespace TH20
{
	public class MetagameCutsceneAudioPlayer : MonoBehaviour
	{
		public AudioSource Source;

		private void OnDisable()
		{
			if (Source.clip != null)
			{
				Source.Stop();
				Source.clip = null;
			}
		}

		public void PlayAudio(AudioClip clip)
		{
			Source.clip = clip;
			Source.Play();
		}

		public void StopAllAudio()
		{
			if (Source.clip != null)
			{
				Source.Stop();
				Source.clip = null;
			}
		}
	}
}
