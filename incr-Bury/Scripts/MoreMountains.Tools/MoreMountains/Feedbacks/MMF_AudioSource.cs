using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Audio/AudioSource")]
	[FeedbackHelp("This feedback lets you play a target audio source, with some elements at random.")]
	public class MMF_AudioSource : MMF_Feedback
	{
		public enum Modes
		{
			Play = 0,
			Pause = 1,
			UnPause = 2,
			Stop = 3
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Audiosource", true, 5, true, false)]
		[Tooltip("the target audio source to play")]
		public AudioSource TargetAudioSource;

		[Tooltip("whether we should play the audio source or stop it or pause it")]
		public Modes Mode;

		[Header("Random Sound")]
		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		[MMFInspectorGroup("Audio Settings", true, 29, false, false)]
		[Header("Volume")]
		[Tooltip("the minimum volume to play the sound at")]
		public float MinVolume = 1f;

		[Tooltip("the maximum volume to play the sound at")]
		public float MaxVolume = 1f;

		[Header("Pitch")]
		[Tooltip("the minimum pitch to play the sound at")]
		public float MinPitch = 1f;

		[Tooltip("the maximum pitch to play the sound at")]
		public float MaxPitch = 1f;

		[Header("Mixer")]
		[Tooltip("the audiomixer to play the sound with (optional)")]
		public AudioMixerGroup SfxAudioMixerGroup;

		protected AudioClip _randomClip;

		protected float _duration;

		public override bool HasRandomness => true;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				return _duration;
			}
			set
			{
				_duration = value;
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetAudioSource = FindAutomatedTarget<AudioSource>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && RandomSfx == null)
			{
				RandomSfx = Array.Empty<AudioClip>();
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			float num = ComputeIntensity(feedbacksIntensity, position);
			switch (Mode)
			{
			case Modes.Play:
			{
				if (RandomSfx.Length != 0)
				{
					_randomClip = RandomSfx[UnityEngine.Random.Range(0, RandomSfx.Length)];
					TargetAudioSource.clip = _randomClip;
				}
				float volume = UnityEngine.Random.Range(MinVolume, MaxVolume) * num;
				float pitch = UnityEngine.Random.Range(MinPitch, MaxPitch);
				if (TargetAudioSource == null)
				{
					Debug.LogWarning("[AudioSource Feedback] The audio source feedback on " + Owner.name + " doesn't have a TargetAudioSource, it won't work. You need to specify one in its inspector.");
					break;
				}
				_duration = TargetAudioSource.clip.length;
				PlayAudioSource(TargetAudioSource, volume, pitch);
				break;
			}
			case Modes.Pause:
				_duration = 0.1f;
				TargetAudioSource.Pause();
				break;
			case Modes.UnPause:
				_duration = 0.1f;
				TargetAudioSource.UnPause();
				break;
			case Modes.Stop:
				_duration = 0.1f;
				TargetAudioSource.Stop();
				break;
			}
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, float volume, float pitch)
		{
			audioSource.volume = volume;
			audioSource.pitch = pitch;
			audioSource.timeSamples = 0;
			if (!NormalPlayDirection)
			{
				audioSource.pitch = -1f;
				audioSource.timeSamples = audioSource.clip.samples - 1;
			}
			audioSource.Play();
		}

		public override void Stop(Vector3 position, float feedbacksIntensity = 1f)
		{
			base.Stop(position, feedbacksIntensity);
			if (TargetAudioSource != null)
			{
				TargetAudioSource?.Stop();
			}
		}
	}
}
