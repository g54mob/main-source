using System;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Framework
{
	public class GlimmerManager
	{
		private bool m_isFirstGlimmering;

		private EME_Weapon m_currentFirstGlimmeringWeapon;

		public bool IsFirstGlimmering => false;

		public void AddNewGlimmerTechniqueToShow(Tuple<string, WeaponType> glimmerNameAndType)
		{
		}

		public bool SetFirstGlimmering(EME_Weapon firstGlimmeringWeapon)
		{
			return false;
		}

		private void ClearFirstGlimmering()
		{
		}
	}
}
