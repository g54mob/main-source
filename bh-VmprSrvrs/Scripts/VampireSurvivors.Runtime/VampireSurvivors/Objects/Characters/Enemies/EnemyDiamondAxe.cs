using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDiamondAxe : EnemyAxeMotion
	{
		private int _hitsTaken;

		private bool _isInvul;

		private bool _canBreak;

		private string[] _availableFrames;

		private Timer _selfTimer;

		private float _invulDelay;

		protected override void OnUpdate()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected void ChangeFrame()
		{
		}

		protected override void Die()
		{
		}
	}
}
