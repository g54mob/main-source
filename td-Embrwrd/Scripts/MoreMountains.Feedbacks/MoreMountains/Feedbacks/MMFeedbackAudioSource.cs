using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you play a target audio source, with some elements at random.")]
	[FeedbackPath("Audio/AudioSource")]
	[AddComponentMenu(null)]
	public class MMFeedbackAudioSource : MMFeedback
	{
		public enum Modes
		{
			Play = 0,
			Pause = 1,
			UnPause = 2,
			Stop = 3
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target audio source to play")]
		[Header("AudioSource")]
		public AudioSource TargetAudioSource;

		[Tooltip("whether we should play the audio source or stop it or pause it")]
		public Modes Mode;

		[Header("Random Sound")]
		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		[Header("Volume")]
		[Tooltip("the minimum volume to play the sound at")]
		public float MinVolume;

		[Tooltip("the maximum volume to play the sound at")]
		public float MaxVolume;

		[Tooltip("the minimum pitch to play the sound at")]
		[Header("Pitch")]
		public float MinPitch;

		[Tooltip("the maximum pitch to play the sound at")]
		public float MaxPitch;

		[Tooltip("the audiomixer to play the sound with (optional)")]
		[Header("Mixer")]
		public AudioMixerGroup SfxAudioMixerGroup;

		protected AudioClip _randomClip;

		protected float _duration;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, float volume, float pitch)
		{
		}

		public override void Stop(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
