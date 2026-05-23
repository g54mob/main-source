using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VFX.Blood;

namespace Infrastructure.Project.Registration.Native
{
	[Serializable]
	public class CreatureParticlesGroupHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private BloodDrainParticle m_bloodDrainParticle;

		public PrefabPassport<BloodDrainParticle> sxp
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
