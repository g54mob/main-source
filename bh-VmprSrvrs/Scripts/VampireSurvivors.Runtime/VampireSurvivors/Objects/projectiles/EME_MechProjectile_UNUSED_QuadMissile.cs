using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile_UNUSED_QuadMissile : EME_MechProjectile_BallisticMissile
	{
		protected override float Radius => 0f;

		protected override float2 SpawnOffset => default(float2);

		protected override List<float> SpawnAngles => null;

		protected override float TurnSpeed => 0f;

		protected override float TurnDuration => 0f;

		protected override float TurnDelay => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void SetMovementPattern()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
