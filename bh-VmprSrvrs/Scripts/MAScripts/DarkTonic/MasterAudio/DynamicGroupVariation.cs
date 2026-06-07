using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DarkTonic.MasterAudio
{
	public class DynamicGroupVariation : MonoBehaviour
	{
		[Range(0f, 1f)]
		public int probabilityToPlay;

		[Range(0f, 10f)]
		public int importance;

		public bool isUninterruptible;

		public bool useLocalization;

		public bool useRandomPitch;

		public SoundGroupVariation.RandomPitchMode randomPitchMode;

		public float randomPitchMin;

		public float randomPitchMax;

		public bool useRandomVolume;

		public SoundGroupVariation.RandomVolumeMode randomVolumeMode;

		public float randomVolumeMin;

		public float randomVolumeMax;

		public int weight;

		public string clipAlias;

		public MasterAudio.AudioLocation audLocation;

		public string resourceFileName;

		public AssetReference audioClipAddressable;

		public bool isExpanded;

		public bool isChecked;

		public bool useFades;

		public float fadeInTime;

		public float fadeOutTime;

		public bool useCustomLooping;

		public int minCustomLoops;

		public int maxCustomLoops;

		public bool useIntroSilence;

		public float introSilenceMin;

		public float introSilenceMax;

		public bool useRandomStartTime;

		public float randomStartMinPercent;

		public float randomStartMaxPercent;

		public float randomEndPercent;

		private AudioDistortionFilter _distFilter;

		private AudioEchoFilter _echoFilter;

		private AudioHighPassFilter _hpFilter;

		private AudioLowPassFilter _lpFilter;

		private AudioReverbFilter _reverbFilter;

		private AudioChorusFilter _chorusFilter;

		private DynamicSoundGroup _parentGroupScript;

		private Transform _trans;

		private AudioSource _aud;

		public AudioDistortionFilter DistortionFilter => null;

		public AudioReverbFilter ReverbFilter => null;

		public AudioChorusFilter ChorusFilter => null;

		public AudioEchoFilter EchoFilter => null;

		public AudioLowPassFilter LowPassFilter => null;

		public AudioHighPassFilter HighPassFilter => null;

		public DynamicSoundGroup ParentGroup => null;

		public Transform Trans => null;

		public bool HasActiveFXFilter => false;

		public AudioSource VarAudio => null;
	}
}
