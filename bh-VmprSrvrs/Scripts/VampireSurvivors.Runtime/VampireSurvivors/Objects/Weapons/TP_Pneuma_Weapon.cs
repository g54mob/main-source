using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Pneuma_Weapon : Weapon
	{
		private List<SpikeData> spikeData;

		private BulletPool _waveProjectile;

		private float _spikePosLeniency;

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private SpikeData nextSpikeData()
		{
			return null;
		}

		public void addSpikeSprite(float2 pos, float angle, float scale, float alpha)
		{
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
