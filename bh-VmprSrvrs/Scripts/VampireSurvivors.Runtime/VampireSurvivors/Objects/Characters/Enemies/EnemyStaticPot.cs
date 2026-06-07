using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStaticPot : EnemyController
	{
		private MultiTargetTween _onEnterTween;

		private float _invulDelay;

		private float _hitsTaken;

		private bool _isInvul;

		private float _maxHits;

		private int _prevDepth;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		protected override void ProcessWiggle()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public void ChangeFrame()
		{
		}
	}
}
