using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks
{
	public class SpecialAttackController
	{
		private static bool enabled;

		private HashSet<EnemySpecialAttack> attacks;

		private Dictionary<EnemySpecialAttack, float> cooldowns;

		private float updateRate;

		private float nextCheckTime;

		private Enemy enemy;

		private bool isAttacking;

		private float attackOverAtTime;

		private EnemySpecialAttack currentAttack;

		public SpecialAttackController(Enemy enemy)
		{
		}

		public void Tick()
		{
		}

		private void UseSpecialAttack(EnemySpecialAttack attack)
		{
		}

		private void FinishAttack()
		{
		}
	}
}
