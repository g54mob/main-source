using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class TP_ADV_MINION_SwarmBat : EnemyController
	{
		private TP_ADV_BOSS_PhantomBat phantomBatReference;

		private Tween _fadeTween;

		private bool _isInvulnerable;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void FadeIn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public void SetPhantomBatReference(TP_ADV_BOSS_PhantomBat phantomBat)
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}
	}
}
