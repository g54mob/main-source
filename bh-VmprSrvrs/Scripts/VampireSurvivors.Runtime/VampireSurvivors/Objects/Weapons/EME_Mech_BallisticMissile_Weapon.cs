using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Mech_BallisticMissile_Weapon : Weapon
	{
		protected readonly Dictionary<WeaponType, string> _glimmerNames;

		public override void ResetFiringTimer()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		private void AddGlimmerName(WeaponType glimmerWeaponType)
		{
		}

		private string GetGlimmerName(WeaponType weaponType)
		{
			return null;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
