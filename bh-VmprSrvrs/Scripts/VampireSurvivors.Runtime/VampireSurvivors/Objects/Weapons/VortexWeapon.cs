using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class VortexWeapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _Renderer;

		private MultiTargetTween _imageTween;

		private float _recoveredHP;

		private float _recoveredCalculated;

		private SpriteRenderer _imageBG;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private GravityWell _well;

		private float _imageScale;

		private Circle _shape1;

		private EmitZone _emitZone;

		private float _innerScale;

		private float _innerDuration;

		private float _vfxTime;

		private float _mul;

		private bool _cooldownAffectedByMovement;

		public float RecoveredHP => 0f;

		public override float PAmount()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected void VortexUpdate(float deltaTime)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Cleanup()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
