using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Ring_Generic_Magic_Weapon : Weapon
	{
		protected readonly Dictionary<WeaponType, string> _glimmerNames;

		public virtual WeaponType GlimmerName => default(WeaponType);

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
