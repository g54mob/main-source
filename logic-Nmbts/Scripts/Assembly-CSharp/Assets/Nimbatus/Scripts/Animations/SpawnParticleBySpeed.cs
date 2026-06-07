using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class SpawnParticleBySpeed : MonoBehaviour
	{
		public Rigidbody Rigidbody;

		public float SpeedThreshold;

		public float ParticleAmmount;

		private ParticleSystem _particleSystem;

		private ParticleSystem.EmissionModule _emitter;

		private void Start()
		{
			_particleSystem = GetComponent<ParticleSystem>();
			_emitter = _particleSystem.emission;
		}

		private void Update()
		{
			if (Rigidbody != null && _particleSystem != null)
			{
				if (Rigidbody.velocity.magnitude > SpeedThreshold)
				{
					_emitter.rateOverTime = new ParticleSystem.MinMaxCurve(ParticleAmmount);
				}
				else
				{
					_emitter.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
				}
			}
		}
	}
}
