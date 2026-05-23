namespace Battle
{
	public class ProjectileBullet : EnemyBaseBullet
	{
		public LoopEffect loopAmmo;

		public HitEffect hitEffect;

		private BaseEnemy _parent;

		private int townAttackPoint;

		public override void Init()
		{
		}

		protected override void InitAdditionalParameter(BaseBullet bullet)
		{
		}

		public override void UpdateBullet(double deltatime)
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

		public override void DestroyObj()
		{
		}
	}
}
