using UnityEngine;

namespace ARPGFX
{
	public class ARPGFXLightFlicker : MonoBehaviour
	{
		[Header("sin,tri,sqr,saw,inv,noise")]
		public string waveFunction;

		public float startValue;

		[Header("Amplitude of wave")]
		public float amplitude;

		[Header("Start point inside on wave cycle")]
		public float phase;

		[Header("Frequency per second")]
		public float frequency;

		private Color originalColor;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private float EvalWave()
		{
			return 0f;
		}
	}
}
