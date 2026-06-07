using UnityEngine;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EX_Rumba1_Weapon : Weapon
	{
		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private float fxRadius;

		public override float PSpeed()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		protected override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
		{
			return false;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void GenerateParticleSystem()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
