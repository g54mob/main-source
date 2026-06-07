using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Axe_HellsFury_Weapon : Weapon
	{
		protected readonly Dictionary<WeaponType, string> _glimmerNames;

		public override float PAmount()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateFiringTimer()
		{
		}

		public override void ResetFiringTimer()
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
