using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyKitsune : EnemyController
	{
		private Vector2 _headOffset;

		private Vector2 _invHeadOffset;

		private List<EnemyKitsuneTailTip> _headEnemies;

		private MultiTargetTween _fadeTrailTween;

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
