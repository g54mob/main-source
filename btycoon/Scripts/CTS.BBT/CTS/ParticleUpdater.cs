using UnityEngine;

namespace CTS
{
	public abstract class ParticleUpdater : VFXUpdater
	{
		[SerializeField]
		protected ParticleSystem ParticleSystem;
	}
}
