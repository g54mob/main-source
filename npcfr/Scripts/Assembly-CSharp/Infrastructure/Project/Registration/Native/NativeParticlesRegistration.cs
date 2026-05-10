using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	public class NativeParticlesRegistration : bgg, bgh
	{
		[SerializeField]
		private SingleShotParticlesHandler m_singleShots;

		[SerializeField]
		private CreatureParticlesGroupHandler m_creatures;

		[SerializeField]
		private WeaponParticlesGroupHandler m_weapon;

		[SerializeField]
		private ParticlesForceFieldsHandler m_forceFields;

		public SingleShotParticlesHandler xmu => null;

		public CreatureParticlesGroupHandler xmv => null;

		public WeaponParticlesGroupHandler xmw => null;

		public ParticlesForceFieldsHandler xmx => null;

		protected override List<NativePrefabsGroupHandler> iso()
		{
			return null;
		}
	}
}
