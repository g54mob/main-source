using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_Lemuria1_Weapon : TP_WhipCore1_Weapon
	{
		protected BulletPool _spikePool;

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		public Projectile CreateSpikeProjectile(float2 pos, int index)
		{
			return null;
		}

		public void FireSpikes(Vector2 spikePos, bool _flipX)
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
