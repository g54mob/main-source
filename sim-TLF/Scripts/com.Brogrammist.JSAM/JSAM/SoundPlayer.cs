using System.Collections;
using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("AudioManager/Sound Player")]
	public class SoundPlayer : BaseAudioFeedback<SoundFileObject>
	{
		[Tooltip("Behaviour to trigger when the object this is attached to is created")]
		[SerializeField]
		private AudioPlaybackBehaviour onStart = AudioPlaybackBehaviour.Play;

		[Tooltip("Behaviour to trigger when the object this is attached to is enabled or when the object is created")]
		[SerializeField]
		private AudioPlaybackBehaviour onEnable;

		[Tooltip("Behaviour to trigger when the object this is attached to is destroyed or set to in-active")]
		[SerializeField]
		private AudioPlaybackBehaviour onDisable = AudioPlaybackBehaviour.Stop;

		[Tooltip("Behaviour to trigger when the object this is attached to is destroyed")]
		[SerializeField]
		private AudioPlaybackBehaviour onDestroy;

		private bool activated;

		private SoundChannelHelper helper;

		public SoundChannelHelper SoundHelper => helper;

		protected void Start()
		{
			switch (onStart)
			{
			case AudioPlaybackBehaviour.Play:
				if (!activated)
				{
					activated = true;
					StartCoroutine(PlayOnEnable());
				}
				break;
			case AudioPlaybackBehaviour.Stop:
				Stop();
				break;
			}
		}

		public void Play()
		{
			helper = AudioManager.PlaySound(audio, base.transform);
			activated = false;
		}

		public void PlaySound()
		{
			Play();
		}

		public void Stop()
		{
			AudioManager.StopSoundIfPlaying(audio, base.transform);
		}

		private void OnEnable()
		{
			switch (onEnable)
			{
			case AudioPlaybackBehaviour.Play:
				if (!activated)
				{
					activated = true;
					StartCoroutine(PlayOnEnable());
				}
				break;
			case AudioPlaybackBehaviour.Stop:
				Stop();
				break;
			}
		}

		private IEnumerator PlayOnEnable()
		{
			while (!AudioManager.Instance)
			{
				yield return null;
			}
			while (!AudioManager.Instance.Initialized)
			{
				yield return null;
			}
			Play();
		}

		private void OnDisable()
		{
			switch (onDisable)
			{
			case AudioPlaybackBehaviour.Play:
				Play();
				break;
			case AudioPlaybackBehaviour.Stop:
				Stop();
				break;
			}
		}

		private void OnDestroy()
		{
			switch (onDestroy)
			{
			case AudioPlaybackBehaviour.Play:
				Play();
				break;
			case AudioPlaybackBehaviour.Stop:
				Stop();
				break;
			}
		}
	}
}
