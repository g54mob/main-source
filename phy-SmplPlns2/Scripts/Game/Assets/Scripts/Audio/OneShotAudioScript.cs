using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class OneShotAudioScript : MonoBehaviour
	{
		private AudioSource _audioSource;

		public string TrackedSoundId { get; set; }

		protected virtual void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		protected virtual void Update()
		{
			if (!_audioSource.isPlaying)
			{
				if (!string.IsNullOrEmpty(TrackedSoundId))
				{
					AudioManager.TrackedSoundFinished(TrackedSoundId);
				}
				Object.Destroy(base.gameObject);
			}
		}
	}
}
