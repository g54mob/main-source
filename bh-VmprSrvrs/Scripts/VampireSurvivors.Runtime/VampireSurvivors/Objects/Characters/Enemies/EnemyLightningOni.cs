using Coherence.Toolkit;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyLightningOni : EnemyController
	{
		private int _activated;

		private bool _performingDeath;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		[Command]
		public void OnlineDie(long startingSimFrame)
		{
		}

		protected override void Die()
		{
		}

		private void PerformDeath()
		{
		}
	}
}
