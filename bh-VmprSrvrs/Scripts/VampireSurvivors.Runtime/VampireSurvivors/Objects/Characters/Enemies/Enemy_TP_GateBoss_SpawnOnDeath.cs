using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_GateBoss_SpawnOnDeath : Enemy_TP_GateBoss
	{
		[SerializeField]
		public EnemyType ToSpawnOnDeath;

		public override void Despawn()
		{
		}

		protected override void DoDeathAnimation()
		{
		}

		private void SpawnNewEnemy(float2 position)
		{
		}
	}
}
