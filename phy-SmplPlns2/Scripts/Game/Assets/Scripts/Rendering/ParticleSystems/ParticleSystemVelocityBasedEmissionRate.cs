using UnityEngine;

namespace Assets.Scripts.Rendering.ParticleSystems
{
	public class ParticleSystemVelocityBasedEmissionRate : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The maximum emission rate for the particle system.")]
		private float _maxRate;

		[SerializeField]
		[Tooltip("The minimum emission rate for the particle system.")]
		private float _minRate;

		[SerializeField]
		[Tooltip("If running on mobile, this value is multiplied by the calculated emission rate to determine the final emission rate.")]
		[Range(0f, 1f)]
		private float _mobileMultiplier;

		private Vector3 _previousGlobalPosition;

		[SerializeField]
		[Tooltip("This is multiplied by the absolute value of the magnitude of the current velocity to determine the emission rate.")]
		private float _velocityBasedEmissionRate;

		public float MaxRate => _maxRate;

		public float MinRate => _minRate;

		public float MobileMultiplier => _mobileMultiplier;

		public ParticleSystem ParticleSystem { get; private set; }

		public Vector3 Velocity { get; private set; }

		public float VelocityBasedEmissionRate => _velocityBasedEmissionRate;

		protected virtual void Awake()
		{
			ParticleSystem = GetComponent<ParticleSystem>();
			if (ParticleSystem == null)
			{
				Debug.LogError("Particle system not found");
			}
		}

		protected virtual void Update()
		{
			Vector3 vector = Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position);
			Velocity = (vector - _previousGlobalPosition) / Time.deltaTime;
			_previousGlobalPosition = vector;
			if (ParticleSystem != null)
			{
				float num = Mathf.Abs(Velocity.magnitude) * VelocityBasedEmissionRate;
				if (SystemInfo.deviceType == DeviceType.Handheld)
				{
					num *= MobileMultiplier;
				}
				num = Mathf.Clamp(num, MinRate, MaxRate);
				ParticleSystem.EmissionModule emission = ParticleSystem.emission;
				emission.rateOverTime = new ParticleSystem.MinMaxCurve(num);
			}
		}
	}
}
