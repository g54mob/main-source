using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Longsword_SwallowSlice_Weapon : Weapon
	{
		protected readonly Dictionary<WeaponType, string> _glimmerNames;

		private int swallowSliceInterval;

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

		private void FireSwallowSwing(Vector2 pos, float _amount)
		{
		}
	}
}
