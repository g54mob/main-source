using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStatic : EnemyController
	{
		private MultiTargetTween _onEnterTween;

		private float _randomDepthOffset;

		private int _prevDepth;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void UpdateDepth()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
