using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyLegionZombie : EnemyController
	{
		private float _timeInMidair;

		private bool _hasHitGround;

		private EnemyLegion _legionBoss;

		[Sync]
		public GameObject LegionBoss
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void Setup(EnemyLegion legionBoss)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
