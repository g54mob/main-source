using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyEyes : EnemyController
	{
		[SerializeField]
		private PhaserSprite _Eyes;

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

		protected override void Die()
		{
		}
	}
}
