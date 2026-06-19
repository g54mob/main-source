using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/App Audio Mixer Manager", order = 1105)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AppAudioMixerManagerConfig : ScriptableObjectWithID
	{
		public AudioMixer AudioMixer;

		[HideInInspector]
		public float MaxMasterVolumeDecibels;

		[HideInInspector]
		public float MinMasterVolumeDecibels = -80f;

		[HideInInspector]
		public float MaxMusicVolumeDecibels;

		[HideInInspector]
		public float MinMusicVolumeDecibels = -80f;

		[HideInInspector]
		public float MaxSFXVolumeDecibels;

		[HideInInspector]
		public float MinSFXVolumeDecibels = -80f;
	}
}
