using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Slash2Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _verbotenTrail;

		[SerializeField]
		protected SpriteTrail _Trail;

		private float startingAngle;

		private float saveAngle;

		private float radiusX;

		private float radiusY;

		private TweenerCore<float, float, FloatOptions> _radiusTween;

		private TweenerCore<float, float, FloatOptions> _radiusTween2;

		private TweenerCore<float, float, FloatOptions> _angleTween;

		private Timer _despawnTimer;

		private Vector2 direction;

		private Sprite _verbotenTrailSprite;

		private static readonly int _FlipX;

		private static readonly int _FlipY;

		private float2 _startingOffset;

		private float finalAngle;

		private float currentAngle;

		private float trailAlpha;

		private TweenerCore<float, float, FloatOptions> _trailAlphaTween;

		private bool _isDespawning;

		private MultiTargetTween _despawnTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void GoBack()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetupVerbotenTrail()
		{
		}
	}
}
