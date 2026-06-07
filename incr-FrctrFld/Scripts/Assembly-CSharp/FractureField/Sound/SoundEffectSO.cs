using UnityEngine;

namespace FractureField.Sound
{
	[CreateAssetMenu(fileName = "SoundEffect", menuName = "ScriptableObjects/SoundEffect")]
	public class SoundEffectSO : ScriptableObject
	{
		public SoundEffectType Type;

		public AudioClip Clip;

		public float Volume;

		public float MinTimeBetween;

		[Range(0f, 0.5f)]
		public float PitchVariance;
	}
}
