namespace Battle
{
	public class Shell : BaseEnemy
	{
		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		protected override void UpdateHpBar(float currentHp)
		{
		}

		public override void Withdrawal()
		{
		}
	}
}
