using System;
using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStalkerNoob : EnemyController
	{
		private float _sineF;

		private float _fireTime;

		private float _fireDelay;

		private EnemyType _bulletType;

		private Tween _onEnterTween;

		private Tween _onFireTimer;

		private Sequence _onSineTween;

		public Action OnDefeat;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}

		private void Fire()
		{
		}
	}
}
