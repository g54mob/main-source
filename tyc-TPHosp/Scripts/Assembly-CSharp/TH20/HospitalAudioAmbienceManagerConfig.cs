using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Hosptal Audio Ambience Manager", order = 1103)]
	public class HospitalAudioAmbienceManagerConfig : ScriptableObjectWithID
	{
		[Flags]
		public enum PopulationSize
		{
			Small = 1,
			Medium = 2,
			Large = 4
		}

		[Flags]
		public enum Location
		{
			Hospital = 1,
			Outside = 2
		}

		[Serializable]
		public class AmbienceConfig
		{
			[InspectorMargin(4)]
			public PopulationSize PopulationSize;

			public Location Location;

			public string HospitalAmbienceAudioEventName;

			public AnimationCurve HeightVolumeCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);
		}

		public AudioMixer HospitalAudioMixer;

		public float AmbiencePopulationFadeDuration = 1f;

		public float AmbienceFadeDuration = 1f;

		[InspectorMargin(4)]
		[InspectorHeader("Small Population Range")]
		public int SmallMinCharacterCount;

		public int SmallMaxCharacterCount;

		[InspectorHeader("Medium Population Range")]
		public int MediumMinCharacterCount;

		public int MediumMaxCharacterCount;

		[InspectorMargin(4)]
		[InspectorHeader("Large Population Range")]
		public int LargeMinCharacterCount;

		public int LargeMaxCharacterCount;

		[InspectorMargin(4)]
		public List<AmbienceConfig> AmbienceConfigs;

		protected void OnValidate()
		{
			AmbienceFadeDuration = Mathf.Max(0.01f, AmbienceFadeDuration);
		}
	}
}
