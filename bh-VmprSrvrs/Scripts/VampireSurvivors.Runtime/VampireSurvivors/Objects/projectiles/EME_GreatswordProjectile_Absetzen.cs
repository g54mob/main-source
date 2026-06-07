using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_GreatswordProjectile_Absetzen : EME_GreatswordProjectile
	{
		[SerializeField]
		private ParticleSystem _SwordHeadFX;

		private Vector3 _defaultSwordSpriteRotation;

		protected override float MinTimeToLand => 0f;

		protected override float MaxTimeToLand => 0f;

		protected override void DoGlimmerAttack()
		{
		}

		protected override void InitVelocity()
		{
		}

		public void RotateTowardsBeamTarget(EME_GreatswordProjectile_Absetzen target)
		{
		}

		public void RotateAtAngle(float angle)
		{
		}

		private void RotateSwordSprite(float angle)
		{
		}

		private void PlaySwordHeadVfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
