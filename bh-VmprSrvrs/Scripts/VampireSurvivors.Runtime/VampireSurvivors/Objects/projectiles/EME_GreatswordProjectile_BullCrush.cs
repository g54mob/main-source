using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_GreatswordProjectile_BullCrush : EME_GreatswordProjectile
	{
		[SerializeField]
		private ParticleSystem _SlashVFX;

		private const float VFXScale = 0.5f;

		private const float VFXRotationZ = -20f;

		private const float SwordRotationZ = 165f;

		private Vector3 _defaultSwordSpriteRotation;

		private float2 _bodySize;

		private float2 _bodyOffset;

		private Tween _scaleTween2;

		protected override void DoGlimmerAttack()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void PlaySlashVFX()
		{
		}

		private void SetBodyForSlash()
		{
		}

		private void UpdateBodyForSlash()
		{
		}

		private void RotateSwordSprite()
		{
		}

		private void PlaySlashSfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
