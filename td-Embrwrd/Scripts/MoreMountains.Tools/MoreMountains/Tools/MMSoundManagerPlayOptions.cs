using System;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Tools
{
	[Serializable]
	public struct MMSoundManagerPlayOptions
	{
		public MMSoundManager.MMSoundManagerTracks MmSoundManagerTrack;

		public Vector3 Location;

		public bool Loop;

		public float Volume;

		public int ID;

		public bool Fade;

		public float FadeInitialVolume;

		public float FadeDuration;

		public MMTweenType FadeTween;

		public bool Persistent;

		public AudioSource RecycleAudioSource;

		public AudioMixerGroup AudioGroup;

		public float Pitch;

		public float PlaybackTime;

		public float PlaybackDuration;

		public float PanStereo;

		public float SpatialBlend;

		public bool SoloSingleTrack;

		public bool SoloAllTracks;

		public bool AutoUnSoloOnEnd;

		public bool BypassEffects;

		public bool BypassListenerEffects;

		public bool BypassReverbZones;

		public int Priority;

		public float ReverbZoneMix;

		public float DopplerLevel;

		public int Spread;

		public AudioRolloffMode RolloffMode;

		public float MinDistance;

		public float MaxDistance;

		public bool DoNotAutoRecycleIfNotDonePlaying;

		public Transform AttachToTransform;

		public bool UseCustomRolloffCurve;

		public AnimationCurve CustomRolloffCurve;

		public bool UseSpatialBlendCurve;

		public AnimationCurve SpatialBlendCurve;

		public bool UseReverbZoneMixCurve;

		public AnimationCurve ReverbZoneMixCurve;

		public bool UseSpreadCurve;

		public AnimationCurve SpreadCurve;

		public static MMSoundManagerPlayOptions Default => default(MMSoundManagerPlayOptions);
	}
}
