using System.Collections;
using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("AudioManager/Music Player")]
	public class MusicPlayer : BaseAudioMusicFeedback
	{
		public enum FadeBehaviour
		{
			None = 0,
			AdditiveFadeIn = 1,
			CrossFadeIn = 2,
			FadeOutAndFadeIn = 3
		}

		[Tooltip("Behaviour to trigger when the object this is attached to is created")]
		[SerializeField]
		protected AudioPlaybackBehaviour onStart = AudioPlaybackBehaviour.Play;

		[Tooltip("Behaviour to trigger when the object this is attached to is enabled or when the object is created")]
		[SerializeField]
		protected AudioPlaybackBehaviour onEnable;

		[Tooltip("Behaviour to trigger when the object this is attached to is destroyed or set to in-active")]
		[SerializeField]
		protected AudioPlaybackBehaviour onDisable;

		[Tooltip("Behaviour to trigger when the object this is attached to is destroyed")]
		[SerializeField]
		protected AudioPlaybackBehaviour onDestroy = AudioPlaybackBehaviour.Stop;

		[Tooltip("Fade behaviour to use when music is played back.\nNone - No fading\nAdditiveFadeIn - Music fades in with no regard for currently playing music\nCrossFadeIn - Fades out current Main Music while fading in this music\nFadeOutAndFadeIn - Fades out current Main Music, and only after it's done fading, fade in this music")]
		[SerializeField]
		protected FadeBehaviour fadeBehaviour;

		[Tooltip("Total time of the fade process")]
		[SerializeField]
		private float fadeTime;

		private MusicChannelHelper helper;

		private Coroutine playRoutine;

		private MusicChannelHelper oldHelper;

		private Coroutine fadeRoutine;

		public MusicChannelHelper MusicHelper => helper;

		private void Start()
		{
			switch (onStart)
			{
			case AudioPlaybackBehaviour.Play:
				StartCoroutine(PlayDelayed());
				break;
			case AudioPlaybackBehaviour.Stop:
				Stop();
				break;
			}
		}

		private void PlayInvokation()
		{
			if (fadeBehaviour > FadeBehaviour.None)
			{
				helper = AudioManager.FadeMusicIn(audio, fadeTime, !AudioManager.MainMusicHelper.AudioSource.isPlaying);
			}
			else
			{
				helper = AudioManager.PlayMusic(audio, base.transform);
			}
		}

		private void PlayBehaviour()
		{
			float time = 0f;
			switch (fadeBehaviour)
			{
			case FadeBehaviour.None:
			case FadeBehaviour.AdditiveFadeIn:
				if (AudioManager.MainMusicHelper.AudioSource.isPlaying)
				{
					time = AudioManager.MainMusicHelper.AudioSource.time;
				}
				PlayInvokation();
				if (keepPlaybackPosition)
				{
					helper.AudioSource.time = time;
				}
				break;
			case FadeBehaviour.CrossFadeIn:
				if (keepPlaybackPosition && AudioManager.MainMusicHelper.AudioSource.isPlaying)
				{
					time = AudioManager.FadeMainMusicOut(fadeTime).AudioSource.time;
				}
				PlayInvokation();
				if (keepPlaybackPosition)
				{
					helper.AudioSource.time = time;
				}
				break;
			case FadeBehaviour.FadeOutAndFadeIn:
				if (fadeRoutine != null)
				{
					StopCoroutine(fadeRoutine);
				}
				fadeRoutine = StartCoroutine(FadeInOut());
				break;
			}
		}

		private IEnumerator FadeInOut()
		{
			float fadeOutTime = fadeTime / 2f;
			if (keepPlaybackPosition && AudioManager.MainMusicHelper.AudioSource.isPlaying)
			{
				oldHelper = AudioManager.FadeMainMusicOut(fadeOutTime);
			}
			float time = 0f;
			if ((bool)oldHelper)
			{
				while (oldHelper.AudioSource.isPlaying)
				{
					time = oldHelper.AudioSource.time;
					yield return null;
				}
			}
			PlayInvokation();
			if (keepPlaybackPosition)
			{
				helper.AudioSource.time = time;
			}
			fadeRoutine = null;
		}

		public void Play()
		{
			if (!AudioManager.IsMusicPlaying(audio) || restartOnReplay)
			{
				PlayBehaviour();
			}
		}

		public void Stop()
		{
			AudioManager.StopMusic(audio, base.transform);
			helper = null;
		}

		private void OnEnable()
		{
			switch (onEnable)
			{
			case AudioPlaybackBehaviour.Play:
				if (playRoutine != null)
				{
					StopCoroutine(playRoutine);
				}
				playRoutine = StartCoroutine(PlayDelayed());
				break;
			case AudioPlaybackBehaviour.Stop:
				Stop();
				break;
			}
		}

		private IEnumerator PlayDelayed()
		{
			yield return new WaitUntil(() => AudioManager.Instance);
			yield return new WaitUntil(() => AudioManager.Instance.Initialized);
			playRoutine = null;
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
			if ((bool)AudioManager.Instance)
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
}
