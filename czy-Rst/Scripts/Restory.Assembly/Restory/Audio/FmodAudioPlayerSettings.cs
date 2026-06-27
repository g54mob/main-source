using FMODUnity;
using UnityEngine;

namespace Restory.Audio
{
	[CreateAssetMenu(fileName = "FmodAudioPlayerSettings", menuName = "Restory/Audio/AudioPlayerSettings", order = 0)]
	public class FmodAudioPlayerSettings : ScriptableObject
	{
		[SerializeField]
		private FmodTestSounds testSounds;

		[SerializeField]
		[BankRef]
		private string musicBank;

		[SerializeField]
		[Tooltip("If a 2D sound is playing, and the same sound tries to start, it won't play unless this much time in scaled real seconds has passed since the previous sound started playing.")]
		private float same2dSoundTimeLimit = 0.5f;

		[SerializeField]
		private float same2dSoundTimerUpdateStep = 0.1f;

		public FmodTestSounds TestSounds => testSounds;

		public string MusicBank => musicBank;

		public float Same2dSoundTimeLimit => same2dSoundTimeLimit;

		public float Same2dSoundTimerUpdateStep => same2dSoundTimerUpdateStep;
	}
}
