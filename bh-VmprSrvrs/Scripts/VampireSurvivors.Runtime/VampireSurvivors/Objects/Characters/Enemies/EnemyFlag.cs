using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyFlag : EnemyController
	{
		[SerializeField]
		protected TrailRenderer _Trail;

		protected Tween _fadeTrailTween;

		protected float _trailTime;

		protected bool _goingRight;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected virtual Vector2 MovementCal()
		{
			return default(Vector2);
		}

		protected virtual void InitTrail()
		{
		}

		protected virtual void UpdateTrailFlip()
		{
		}

		protected override void Die()
		{
		}

		protected override void UpdateDepth()
		{
		}

		protected void FadeTrailOut(bool instant = false)
		{
		}
	}
}
