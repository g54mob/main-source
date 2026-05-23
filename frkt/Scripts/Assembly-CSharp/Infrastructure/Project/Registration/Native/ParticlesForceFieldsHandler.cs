using System;
using System.Runtime.CompilerServices;
using Components.Particles.ForceFields;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	[Serializable]
	public class ParticlesForceFieldsHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private ExplosionParticleForceField m_baseExplosion;

		public PrefabPassport<ExplosionParticleForceField> sxq
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public override void isj()
		{
		}
	}
}
