using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Trigger Particles")]
	public sealed class TriggerParticles : MonoBehaviour
	{
		[Tooltip("List of particle systems that should emit on enter.")]
		[SerializeField]
		private List<ParticleSystem> particlesToActivate;

		[Tooltip("List of particle systems that should stop emit on exit.")]
		[SerializeField]
		private List<ParticleSystem> particlesToDeactivate;

		public List<ParticleSystem> ParticlesToActivate
		{
			get
			{
				return particlesToActivate;
			}
			set
			{
				particlesToActivate = value;
			}
		}

		public List<ParticleSystem> ParticlesToDeactivate
		{
			get
			{
				return particlesToDeactivate;
			}
			set
			{
				particlesToDeactivate = value;
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			Vector3 position = collider.transform.position;
			foreach (ParticleSystem item in particlesToActivate)
			{
				item.transform.position = position;
				item.Play();
			}
		}

		private void OnTriggerExit(Collider collider)
		{
			foreach (ParticleSystem item in particlesToDeactivate)
			{
				item.Stop();
			}
		}
	}
}
