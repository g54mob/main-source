using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyOrochimario : EnemyController
	{
		private Vector2 _headOffset;

		private Vector2 _invHeadOffset;

		private List<EnemyOrochiHead> _headEnemies;

		private MultiTargetTween _fadeTrailTween;

		[SerializeField]
		private EnemyType _headEnemyType;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void PlayDeathAnimations()
		{
		}

		protected override void Die()
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
