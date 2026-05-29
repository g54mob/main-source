namespace Battle
{
	public class LastBossEnergyBullet : EnemyBaseBullet
	{
		public HitEffect hitEffect;

		public LoopEffect spriteEffect;

		private BaseEnemy _parent;

		private int _townAttackPoint;

		public override void Init()
		{
		}

		public override void UpdateBullet(double deltatime)
		{
		}

		public override void LastUpdate()
		{
		}

		protected override void AttackTown()
		{
		}

		protected override int GetTownAttackPoint()
		{
			return 0;
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = false)
		{
			return false;
		}

		public override void CheckLifeTime()
		{
		}

		protected override void InitAdditionalParameter(BaseBullet bullet)
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
