using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_CannonProjectile_UNUSED_BombardingFire_Setup : EME_MechProjectile_BallisticMissile
	{
		protected override float Radius => 0f;

		protected override float2 SpawnOffset => default(float2);

		protected override List<float> SpawnAngles => null;

		protected override float TurnSpeed => 0f;

		protected override float TurnDuration => 0f;

		protected override float TurnDelay => 0f;

		protected override float AccelRate => 0f;

		protected override float DecelRate => 0f;

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
