using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyRangedAdvanced : EnemyController
	{
		private EnemyType _originalBullet;

		private float _keepMoving;

		private float _fireDelay;

		private float _firingRandom;

		private float _minRange;

		private float _maxRange;

		private Tween _onEnterTween;

		private Timer _onFireTimer;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}

		private void Fire()
		{
		}
	}
}
