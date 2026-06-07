using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyCentipede : EnemyFlag
	{
		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override Vector2 MovementCal()
		{
			return default(Vector2);
		}

		protected override void InitTrail()
		{
		}

		protected override void UpdateTrailFlip()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}
	}
}
