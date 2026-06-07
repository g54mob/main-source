using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyPile1 : EnemyController
	{
		private float _fireTime;

		protected EnemyType _bulletType;

		private Sequence _onEnterTween;

		private Tween _onFireTimer;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}

		private void KillTweens()
		{
		}

		protected virtual float FireDelay()
		{
			return 0f;
		}

		protected virtual void Fire()
		{
		}
	}
}
