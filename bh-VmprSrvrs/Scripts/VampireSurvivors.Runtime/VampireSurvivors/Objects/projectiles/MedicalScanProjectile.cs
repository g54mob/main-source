using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MedicalScanProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _medscanFront;

		private VampireSurvivors.Objects.Characters.CharacterController _targetPlayer;

		private float _animationT;

		private bool _isAnimating;

		protected PhaserSprite _explosionSprite;

		private PhaserSprite _rainbowSprite;

		private MultiTargetTween _rainbowTween;

		private MultiTargetTween _rainbowTween2;

		private MultiTargetTween _highlightTween;

		private MultiTargetTween _highlightTween2;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual void ApplyScanEffect()
		{
		}

		public void LateUpdate()
		{
		}

		protected float GetRadius()
		{
			return 0f;
		}

		public override void Despawn()
		{
		}
	}
}
