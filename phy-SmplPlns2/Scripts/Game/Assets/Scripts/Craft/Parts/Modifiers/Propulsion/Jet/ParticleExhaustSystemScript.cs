using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class ParticleExhaustSystemScript : MonoBehaviour, IExhaustSystem
	{
		private ParticleSystem _exhaustParticleSystem;

		private float _exhaustStartLifetime;

		public GameObject GameObject => base.gameObject;

		public float NozzleRadius { get; set; }

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (!active)
			{
				_exhaustParticleSystem.gameObject.SetActive(value: false);
				ParticleSystem.MainModule main = _exhaustParticleSystem.main;
				main.startLifetime = _exhaustStartLifetime;
			}
		}

		public void UpdateExhaust(float throttle, float afterburnerThrottle)
		{
			UpdateExhaustParticleSystem(_exhaustParticleSystem, _exhaustStartLifetime, afterburnerThrottle);
		}

		protected virtual void Awake()
		{
			_exhaustParticleSystem = GetComponent<ParticleSystem>();
			_exhaustParticleSystem.gameObject.layer = 0;
			ParticleSystem.EmissionModule emission = _exhaustParticleSystem.emission;
			emission.enabled = false;
			_exhaustParticleSystem.gameObject.SetActive(value: false);
			_exhaustStartLifetime = _exhaustParticleSystem.main.startLifetime.constant;
		}

		private void UpdateExhaustParticleSystem(ParticleSystem ps, float maxLifetime, float throttle)
		{
			ParticleSystem.MainModule main = ps.main;
			ParticleSystem.EmissionModule emission = ps.emission;
			if (throttle > 0f)
			{
				emission.enabled = true;
				main.startLifetime = maxLifetime * throttle;
			}
			else
			{
				emission.enabled = false;
			}
		}
	}
}
