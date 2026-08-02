using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class SliderAudio : MonoBehaviour
	{
		public SliderAdapter slider;

		public AudioSource audioSource;

		public AudioClipConfig clip;

		public AnimationCurve pitchCurve;

		public float speed;

		private float lastChange;

		private float lastValue;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
