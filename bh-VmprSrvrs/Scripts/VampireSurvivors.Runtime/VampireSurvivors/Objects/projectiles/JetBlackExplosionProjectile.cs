using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class JetBlackExplosionProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _rockSprite;

		[SerializeField]
		private SpriteRenderer _starSprite;

		[SerializeField]
		private SpriteRenderer _starSprite2;

		[SerializeField]
		private SpriteRenderer _bubbleSprite;

		[SerializeField]
		private SpriteAnimation _animation;

		private bool _initialisedParticles;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		private MultiTargetTween _tween5;

		private MultiTargetTween _tween6;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle(float salvoDuration)
		{
		}

		private void DisplayMe(float salvoDuration)
		{
		}
	}
}
