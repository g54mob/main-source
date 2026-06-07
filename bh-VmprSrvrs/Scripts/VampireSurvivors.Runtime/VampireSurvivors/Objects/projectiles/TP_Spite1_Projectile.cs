using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Spite1_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _LightTrail;

		private float _bodyRadius;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeInTrailTween;

		private bool _isLight;

		private float _waveAngle;

		private float _waveIncrement;

		private Sprite _cachedLightSprite;

		private Sprite _cachedDarkSprite;

		private float _pathModifier;

		private bool _isUpwards;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartDespawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
