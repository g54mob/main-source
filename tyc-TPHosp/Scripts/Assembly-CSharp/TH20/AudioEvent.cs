using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TH20
{
	[Serializable]
	public class AudioEvent
	{
		[Serializable]
		public class Clip
		{
			public AudioClip AudioClip;

			public string AudioClipTag;

			public float Weight = 1f;

			[Range(0f, 1f)]
			public float Volume = 1f;

			public Clip()
			{
			}

			public Clip(AudioClip audioClip, float weight, float volume)
			{
				AudioClip = audioClip;
				Weight = weight;
				Volume = volume;
			}

			public Clip(Clip clip)
			{
				AudioClip = clip.AudioClip;
				Weight = clip.Weight;
				Volume = clip.Volume;
			}
		}

		public string EventName;

		public List<Clip> Clips = new List<Clip>();

		public List<Clip> IntroClips = new List<Clip>();

		public List<Clip> OutroClips = new List<Clip>();

		[Range(0f, 256f)]
		[Tooltip("Lower number has higher priority")]
		[Space]
		public int Priority = 128;

		[Space]
		public bool Loop;

		public bool StopWhenSourceDies;

		public bool KeepLoopingWhenSourceDies;

		public bool DoNotTrackSourceMovement;

		[Space]
		public bool BypassEffects;

		public bool BypassListenerEffects;

		public bool BypassReverbZones;

		[Space]
		public bool Mute;

		[Space]
		public AudioMixerGroup OutputAudioMixerGroup;

		[Space]
		[Range(-1f, 1f)]
		public float StereoPan;

		[Range(-3f, 3f)]
		public float Pitch = 1f;

		public bool RandomizedPitch;

		public float MaxPitch = 1f;

		public float MinPitch = 1f;

		public bool Spatialize;

		[Range(0f, 1f)]
		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		public float SpatialBlend;

		[Range(0f, 1.1f)]
		public float ReverbZoneMix = 1f;

		[Header("3D Sound Settings")]
		public bool Auto3DRolloff = true;

		public float Auto3DMinRadiusMultiplier = 1f;

		public float Auto3DMaxRadiusMultiplier = 1f;

		public AudioRolloffMode VolumeRolloff;

		public AnimationCurve CustomRolloffCurve;

		[Range(0f, 5f)]
		public float DopplerLevel = 1f;

		[Range(0f, 360f)]
		public float Spread;

		public float MaxDistance = 500f;

		public float MinDistance = 1f;

		[NonSerialized]
		public string BankName;

		public AudioEvent Clone()
		{
			AudioEvent audioEvent = new AudioEvent();
			audioEvent.Clips.Capacity = Clips.Count;
			foreach (Clip clip in Clips)
			{
				audioEvent.Clips.Add(new Clip(clip));
			}
			audioEvent.EventName = EventName;
			audioEvent.Loop = Loop;
			audioEvent.StopWhenSourceDies = StopWhenSourceDies;
			audioEvent.Priority = Priority;
			audioEvent.KeepLoopingWhenSourceDies = KeepLoopingWhenSourceDies;
			audioEvent.DoNotTrackSourceMovement = DoNotTrackSourceMovement;
			audioEvent.BypassEffects = BypassEffects;
			audioEvent.BypassListenerEffects = BypassListenerEffects;
			audioEvent.BypassReverbZones = BypassReverbZones;
			audioEvent.DopplerLevel = DopplerLevel;
			audioEvent.MaxDistance = MaxDistance;
			audioEvent.MinDistance = MinDistance;
			audioEvent.Mute = Mute;
			audioEvent.OutputAudioMixerGroup = OutputAudioMixerGroup;
			audioEvent.StereoPan = StereoPan;
			audioEvent.Pitch = Pitch;
			audioEvent.RandomizedPitch = RandomizedPitch;
			audioEvent.MaxPitch = MaxPitch;
			audioEvent.MinPitch = MinPitch;
			audioEvent.Auto3DRolloff = Auto3DRolloff;
			audioEvent.VolumeRolloff = VolumeRolloff;
			audioEvent.Spread = Spread;
			audioEvent.CustomRolloffCurve = CustomRolloffCurve;
			audioEvent.SpatialBlend = SpatialBlend;
			audioEvent.ReverbZoneMix = ReverbZoneMix;
			audioEvent.Spatialize = Spatialize;
			return audioEvent;
		}

		public void TransferToAudioSource(AudioSource source)
		{
			source.loop = Loop;
			source.bypassEffects = BypassEffects;
			source.bypassListenerEffects = BypassListenerEffects;
			source.bypassReverbZones = BypassReverbZones;
			source.reverbZoneMix = ReverbZoneMix;
			source.mute = Mute;
			source.outputAudioMixerGroup = OutputAudioMixerGroup;
			source.panStereo = StereoPan;
			source.pitch = (RandomizedPitch ? UnityEngine.Random.Range(MinPitch, MaxPitch) : Pitch);
			source.spatialize = Spatialize;
			source.priority = Priority;
			source.spatialBlend = SpatialBlend;
			if (!Auto3DRolloff)
			{
				source.rolloffMode = VolumeRolloff;
				source.dopplerLevel = DopplerLevel;
				source.spread = Spread;
				if (VolumeRolloff == AudioRolloffMode.Custom)
				{
					source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, CustomRolloffCurve);
				}
				source.maxDistance = MaxDistance;
				source.minDistance = MinDistance;
			}
			else
			{
				source.rolloffMode = AudioRolloffMode.Linear;
				source.dopplerLevel = 0f;
				source.spread = 0f;
				source.maxDistance = 100f;
				source.minDistance = 0f;
			}
		}

		public static Clip GetRandomClip(List<Clip> clips)
		{
			return clips.WeightedRandomItem((Clip clip) => clip.Weight);
		}
	}
}
