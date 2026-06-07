using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class TP_ADV_BOSS_Paranoia : EnemyControllerBoss
	{
		[FormerlySerializedAs("secondBossSpawnDelay")]
		[SerializeField]
		protected float secondBossSpawnInterval;

		private Timer secondBossSpawnTimer;

		private const EnemyType PLAYER_FACADE = EnemyType.TP_ADV_MINION_PLAYERFACADE;

		private const EnemyType PARANOIA_FACADE = EnemyType.TP_ADV_MINION_PARANOIAFACADE;

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		private void InitSpawnSecondaryBoss()
		{
		}

		private void SpawnSecondBoss()
		{
		}

		protected override void SpawnBossMinions(EnemyType type, int spawnAmount)
		{
		}

		public override void Despawn()
		{
		}
	}
}
