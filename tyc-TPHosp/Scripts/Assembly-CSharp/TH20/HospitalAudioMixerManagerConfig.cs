using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Hospital Audio Mixer Manager", order = 1105)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HospitalAudioMixerManagerConfig : ScriptableObjectWithID
	{
		[Serializable]
		public struct ReverbSettings
		{
			[Range(-10000f, 0f)]
			public float DryLevel;

			[Range(-10000f, 0f)]
			public float Room;

			[Range(-10000f, 0f)]
			public float RoomHF;

			[Range(-10000f, 0f)]
			public float RoomLF;

			[Range(0.1f, 20f)]
			public float DecayTime;

			[Range(0.1f, 2f)]
			public float DecayHFRatio;

			[Range(-10000f, 1000f)]
			public float Reflections;

			[Range(0f, 0.3f)]
			public float ReflectDelay;

			[Range(-10000f, 2000f)]
			public float Reverb;

			[Range(0f, 0.1f)]
			public float ReverbDelay;

			[Range(1000f, 20000f)]
			public float HFReference;

			[Range(20f, 1000f)]
			public float LFReference;

			[Range(0f, 100f)]
			public float Diffusion;

			[Range(0f, 100f)]
			public float Density;
		}

		[Serializable]
		public struct LowPassSettings
		{
			[Range(10f, 22000f)]
			public float LowestHeightFreqCutoff;

			[Range(10f, 22000f)]
			public float GreatestHeightFreqCutoff;
		}

		public AudioMixer HospitalAudioMixer;

		public AudioMixerGroup[] HospitalAudioMixerGroups;

		[Space]
		[Header("Tannoy - Reverb")]
		public float TannoyReverbLowestHospitalCameraHeight = 10f;

		public float TannoyReverbGreatestHospitalCameraHeight = 200f;

		[Space]
		public ReverbSettings TannoyLowestHeightReverb = DefaultReverbSettings;

		public ReverbSettings TannoyGreatestHeightReverb = DefaultReverbSettings;

		[Space]
		[Header("Hospital Ambience - Low Pass Filter")]
		public float HospitalAmbienceLowestCameraHeight = 10f;

		public float HospitalAmbienceGreatestCameraHeight = 200f;

		[Space]
		public LowPassSettings HospitalAmbienceLowPassSettings = DefaultLowPassSettings;

		[Space]
		[Header("Hospital SFX - Volume")]
		public float LowestHospitalCameraHeight = 10f;

		public float GreatestHospitalCameraHeight = 200f;

		[Space]
		public float HospitalSFXVolumeAtLowestHeight;

		public float HospitalSFXVolumeAtFurthestHeight = -40f;

		public AnimationCurve HospitalSFXHeightFallOffCurve = AnimationCurve.Linear(1f, 0f, 1f, 0f);

		[Space]
		[Header("Hospital SFX - Low Pass Filter")]
		public float SFXLowPassLowestHospitalCameraHeight = 10f;

		public float SFXLowPassGreatestHospitalCameraHeight = 200f;

		[Space]
		public LowPassSettings HospitalSFXLowPassSettings = DefaultLowPassSettings;

		[Space]
		[Header("Hospital SFX - Reverb")]
		public float HospitalSFXReverbLowestHospitalCameraHeight = 10f;

		public float HospitalSFXReverbGreatestHospitalCameraHeight = 100f;

		[Space]
		public ReverbSettings HospitalSFXLowestHeightReverb = DefaultReverbSettings;

		public ReverbSettings HospitalSFXGreatestHeightReverb = DefaultReverbSettings;

		[HideInInspector]
		public float MaxVolumeDecibels;

		[HideInInspector]
		public float MinVolumeDecibels = -80f;

		private static ReverbSettings DefaultReverbSettings => new ReverbSettings
		{
			DryLevel = 0f,
			RoomHF = 0f,
			RoomLF = 0f,
			DecayTime = 1f,
			DecayHFRatio = 0.5f,
			Reflections = -10000f,
			ReflectDelay = 0.02f,
			Reverb = 0f,
			ReverbDelay = 0.04f,
			HFReference = 5000f,
			LFReference = 250f,
			Diffusion = 100f,
			Density = 100f
		};

		private static LowPassSettings DefaultLowPassSettings => new LowPassSettings
		{
			LowestHeightFreqCutoff = 5000f,
			GreatestHeightFreqCutoff = 5000f
		};
	}
}
