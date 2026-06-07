using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyJellyfish : EnemyController
	{
		private float _sineF;

		private Tween _onEnterTween;

		private Tween _sineTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
