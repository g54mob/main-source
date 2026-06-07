using System;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyOnDefeat : EnemyController
	{
		public Action OnDefeat { get; set; }

		protected override void Die()
		{
		}
	}
}
