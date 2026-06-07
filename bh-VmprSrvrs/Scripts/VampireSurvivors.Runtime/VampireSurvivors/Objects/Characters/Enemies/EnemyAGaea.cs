using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyAGaea : EnemyController
	{
		private float _bonusTimes;

		private bool _isInvul;

		private float _recoveredTimes;

		private bool _hasBeenDefeated;

		private BgmType _savedBGM;

		private BgmModType _savedBGMmod;

		private PhaserSprite _ringSprite;

		private Timer _summonEvent;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		public void CalculateBonus()
		{
		}

		public void StartInvulTimer()
		{
		}

		public void RemoveInvul()
		{
		}

		public void StartSummons()
		{
		}

		public void OnDefeat()
		{
		}

		public void GetEnemyToken()
		{
		}

		public void FakeRecover()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}
	}
}
