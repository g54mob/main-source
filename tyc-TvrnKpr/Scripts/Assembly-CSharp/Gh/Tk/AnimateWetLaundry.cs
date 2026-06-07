using UnityEngine;

namespace Gh.Tk
{
	public class AnimateWetLaundry : MonoBehaviour
	{
		private enum LaundryState
		{
			Dry = 0,
			Wet = 1,
			Drying = 2
		}

		public Color startColor;

		public Color endColor;

		public ParticleSystem _particleSystem;

		public float maxParticleRate;

		public float animationDuration;

		private LaundryState laundryState;

		private Material mat;

		private float currentAnimationTime;

		private float glossiness;

		private ParticleSystem.EmissionModule _emissionModule;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
