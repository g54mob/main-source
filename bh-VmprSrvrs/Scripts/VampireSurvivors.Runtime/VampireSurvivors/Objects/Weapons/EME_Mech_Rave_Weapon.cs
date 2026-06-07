using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Mech_Rave_Weapon : Weapon, EME_iCosmicRaveVFX
	{
		private BulletPool _cosmicRaveVFXpool;

		[SerializeField]
		private Projectile _CosmicRaveVFXPrefab;

		protected readonly Dictionary<WeaponType, string> _glimmerNames;

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		public void DisplayCosmicRaveVFX(float2 position)
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
