namespace Battle
{
	public class BladeChild : BaseEnemy
	{
		public LoopEffect trail;

		private const string innerSuffix = "A";

		private const string outerSuffix = "B";

		public Blade blade { get; set; }

		public bool isInter { get; set; }

		public bool AttackMode { get; private set; }

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public void ChangeAttackMode()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override void LastUpdate()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
