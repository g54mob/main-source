using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySnekShielded : EnemyController
	{
		private Timer _shieldTimer;

		private bool _hasShield;

		private float _shieldDamage;

		private float _shieldDuration;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void SnakeUpdate()
		{
		}
	}
}
