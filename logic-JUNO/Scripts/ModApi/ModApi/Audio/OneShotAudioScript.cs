using UnityEngine;

namespace ModApi.Audio
{
	public class OneShotAudioScript : MonoBehaviour
	{
		private AudioSource _audioSource;

		private void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void Update()
		{
			if (!_audioSource.isPlaying)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
