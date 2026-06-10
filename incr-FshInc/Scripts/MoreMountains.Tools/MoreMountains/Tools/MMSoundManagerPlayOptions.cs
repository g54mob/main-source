using System;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Tools
{
	[Serializable]
	public struct MMSoundManagerPlayOptions
	{
		[HideInInspector]
		public bool Initialized;

		[HideInInspector]
		public AudioResource AudioResourceToPlay;

		[Header("Track")]
		public MMSoundManager.MMSoundManagerTracks MmSoundManagerTrack;

		public AudioMixerGroup AudioGroup;

		[Header("Sound")]
		public bool Loop;

		[Range(0f, 2f)]
		public float Volume;

		[Range(-3f, 3f)]
		public float Pitch;

		public int ID;

		[Header("Fade")]
		public bool Fade;

		[MMCondition("Fade", true)]
		public float FadeInitialVolume;

		[MMCondition("Fade", true)]
		public float FadeDuration;

		[MMCondition("Fade", true)]
		public MMTweenType FadeTween;

		public bool Persistent;

		public AudioSource RecycleAudioSource;

		[Header("Time")]
		public float InitialDelay;

		public float PlaybackTime;

		public float PlaybackDuration;

		[Header("Spatial Settings")]
		[Range(-1f, 1f)]
		public float PanStereo;

		[Range(0f, 1f)]
		public float SpatialBlend;

		public Transform AttachToTransform;

		[Header("Solo")]
		public bool SoloSingleTrack;

		public bool SoloAllTracks;

		public bool AutoUnSoloOnEnd;

		public bool BypassEffects;

		public bool BypassListenerEffects;

		public bool BypassReverbZones;

		[Range(0f, 256f)]
		public int Priority;

		[Range(0f, 1.1f)]
		public float ReverbZoneMix;

		[Header("3D Sound Settings")]
		[Range(0f, 5f)]
		public float DopplerLevel;

		public Vector3 Location;

		[Range(0f, 360f)]
		public int Spread;

		public AudioRolloffMode RolloffMode;

		public float MinDistance;

		public float MaxDistance;

		public bool DoNotAutoRecycleIfNotDonePlaying;

		public bool UseCustomRolloffCurve;

		[MMCondition("UseCustomRolloffCurve", true)]
		public AnimationCurve CustomRolloffCurve;

		public bool UseSpatialBlendCurve;

		[MMCondition("UseSpatialBlendCurve", true)]
		public AnimationCurve SpatialBlendCurve;

		public bool UseReverbZoneMixCurve;

		[MMCondition("UseReverbZoneMixCurve", true)]
		public AnimationCurve ReverbZoneMixCurve;

		public bool UseSpreadCurve;

		[MMCondition("UseSpreadCurve", true)]
		public AnimationCurve SpreadCurve;

		public static MMSoundManagerPlayOptions Default => new MMSoundManagerPlayOptions
		{
			Initialized = true,
			AudioResourceToPlay = null,
			MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Sfx,
			Location = Vector3.zero,
			Loop = false,
			Volume = 1f,
			ID = 0,
			Fade = false,
			FadeInitialVolume = 0f,
			FadeDuration = 1f,
			FadeTween = MMTweenType.DefaultEaseInCubic,
			Persistent = false,
			RecycleAudioSource = null,
			AudioGroup = null,
			Pitch = 1f,
			InitialDelay = 0f,
			PanStereo = 0f,
			SpatialBlend = 0f,
			SoloSingleTrack = false,
			SoloAllTracks = false,
			AutoUnSoloOnEnd = false,
			BypassEffects = false,
			BypassListenerEffects = false,
			BypassReverbZones = false,
			Priority = 128,
			ReverbZoneMix = 1f,
			DopplerLevel = 1f,
			Spread = 0,
			RolloffMode = AudioRolloffMode.Logarithmic,
			MinDistance = 1f,
			MaxDistance = 500f,
			DoNotAutoRecycleIfNotDonePlaying = true
		};
	}
}
