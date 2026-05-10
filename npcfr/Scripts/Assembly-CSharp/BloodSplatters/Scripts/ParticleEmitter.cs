using System.Collections.Generic;
using UnityEngine;

namespace BloodSplatters.Scripts
{
	public class ParticleEmitter : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem m_particleSystem;

		[SerializeField]
		private ParticleSystem m_splatterParticle;

		private List<ParticleCollisionEvent> phj;

		private void Start()
		{
		}

		private void OnParticleCollision(GameObject other)
		{
		}

		private void ddr()
		{
		}

		private void Update()
		{
		}
	}
}
