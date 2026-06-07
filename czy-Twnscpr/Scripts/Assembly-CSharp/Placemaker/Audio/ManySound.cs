using UnityEngine;

namespace Placemaker.Audio
{
	public class ManySound : MonoBehaviour
	{
		public AudioSourcePool audioSourcePool;

		public AudioClip[] clips;

		[Space]
		public float timeSpacing;

		public float clickSoundSpacing;

		public float attenuator;

		public float usePropPitch;

		public Vector3 pos;

		public float denom;

		public float volume;

		public float pan;

		public float pitch;

		public float lastTimePlayed;

		public float attenuation;
	}
}
