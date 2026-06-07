using System;
using System.Collections.Generic;
using Components.Particles.SingleShot;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	[Serializable]
	public class NPCSpawnerParticlesHandler : SingleShotParticlesGroup<NPCSpawnerParticle>
	{
		[SerializeField]
		private SingleShotParticleSystem m_throwShockwave;

		[SerializeField]
		private SingleShotParticleSystem m_throwFlash;

		[SerializeField]
		private SingleShotParticleSystem m_spawnStart;

		[SerializeField]
		private SingleShotParticleSystem m_spawnComplete;

		[SerializeField]
		private SingleShotParticleSystem m_spawnCompleteDust;

		protected override Dictionary<NPCSpawnerParticle, SingleShotParticleSystem> isr()
		{
			return null;
		}
	}
}
