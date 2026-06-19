using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace JSAM
{
	public abstract class BaseAudioFileObject : ScriptableObject
	{
		[SerializeField]
		protected string safeName = "";

		[SerializeField]
		private string presetDescription;

		[SerializeField]
		protected List<AudioClip> files = new List<AudioClip>();

		[Tooltip("Only applies to SoundFileObject, after playing this sound, the next time it's played, it will play a different AudioClip in its file list")]
		public bool neverRepeat;

		public float loopStart;

		public float loopEnd;

		public int bpm = 120;

		[Range(0f, 1f)]
		[Tooltip("The volume of this Audio File relative to the volume levels defined in the main AudioManager. Leave at 1 to keep unchanged. The lower the value, the quieter it will be during playback.")]
		public float relativeVolume = 1f;

		[Tooltip("If true, playback will be affected based on distance and direction from listener. Otherwise, sounds will be played at the same volume at all times.")]
		public bool spatialize;

		[Tooltip("If set above 0, sound can be heard from up to this distance before finally fading away. Acts as an override to the max distance value set in the AudioSource prefab. Good for ambient sounds. Only works if \"spatialize\" is set to true.")]
		public float maxDistance;

		[Tooltip("If there are several sounds playing at once, sounds with higher priority will be culled by Unity's sound system later than sounds with lower priority. \"Music\" has the absolute highest priority and \"Spam\" has the lowest.")]
		public Priority priority = Priority.Default;

		[Tooltip("The frequency that the sound plays at by default. \"Pitch shift\" is added to this value additively to get the final pitch.")]
		[Range(0f, 3f)]
		public float startingPitch = 1f;

		[Tooltip("Amount of random variance to the sound's frequency to be applied (both positive and negative) when this sound is played. Keep below 0.2 for best results.")]
		[Range(0f, 0.5f)]
		public float pitchShift = 0.05f;

		[Tooltip("Standard looping disregards all loop point logic and will make the music loop from start to end.\n\n\"Loop with Loop Points\" enables loop point use and makes the music start from the start point upon reaching the end")]
		[SerializeField]
		public LoopMode loopMode;

		[Tooltip("Adds a delay in seconds before this sound is played. If the sound loops, delay is only added to when the sound is first played before the first loop.")]
		public float delay;

		[Tooltip("If true, will ignore the \"Time Scaled Sounds\" parameter in AudioManager and will keep playing the sound even when the Time Scale is set to 0")]
		public bool ignoreTimeScale;

		[Tooltip("The inclusive maximum number of playing instances this Audio File can take up at once. Helpful for things like gun shots where you can easily fire off 50 of the same Audio File in 1 frame. Leave at 0 if that is what you want.")]
		public uint maxPlayingInstances = 10u;

		[Tooltip("Overrides the volume channel this audio will use. Leave at None so Sounds are changed with Sound volume and Music is changed with Music volume.")]
		public VolumeChannel channelOverride;

		[Tooltip("If this property is null, audio will play through the mixer group specified in the AudioManager settings.")]
		public AudioMixerGroup mixerGroupOverride;

		[Tooltip("Add fade to your sound. Set the details of this fade using the FadeMode tools.")]
		public bool fadeInOut;

		[Tooltip("The percentage of time the sound takes to fade-in relative to it's total length.")]
		public float fadeInDuration;

		[Tooltip("The percentage of time the sound takes to fade-out relative to it's total length.")]
		public float fadeOutDuration;

		[Tooltip("If true, this audio file ignore effects applied in the Audio Effects stack and any effects applied to the Audio Listener.")]
		public bool bypassEffects;

		[Tooltip("If true, this audio file will ignore any effects applied to the Audio Listener.")]
		public bool bypassListenerEffects;

		[Tooltip("If true, this audio file will ignore reverb effects created when the Audio Listener enters a reverb zone")]
		public bool bypassReverbZones;

		public AudioChorusObj chorusFilter;

		public AudioDistortionObj distortionFilter;

		public AudioEchoObj echoFilter;

		public AudioLowPassObj lowPassFilter;

		public AudioHighPassObj highPassFilter;

		public AudioReverbObj reverbFilter;

		[NonSerialized]
		public int lastClipIndex = -1;

		public string SafeName => base.name.ConvertToAlphanumeric();

		public List<AudioClip> Files => files;

		public void Initialize()
		{
			lastClipIndex = -1;
		}

		public float GetRandomPitch()
		{
			float num = startingPitch;
			if (pitchShift > 0f)
			{
				num += UnityEngine.Random.Range(0f - pitchShift, pitchShift);
			}
			if (JSAMSettings.Settings.TimeScaledSounds && !ignoreTimeScale)
			{
				num *= Time.timeScale;
			}
			return Mathf.Clamp(num, 0f, 3f);
		}
	}
}
