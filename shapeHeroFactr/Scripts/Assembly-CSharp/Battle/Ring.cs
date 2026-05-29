namespace Battle
{
	public class Ring : BaseEnemy
	{
		private RingMaster master;

		private float _myAngle;

		private float _fixedX;

		private float _fixedY;

		private bool _isSymbol;

		public bool isSymbol
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void SetMaster(RingMaster value, float angle, bool isSymbol, int groupId)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public bool CheckMasterAlive()
		{
			return false;
		}

		public override void ReceiveStatusEffect(StatusEffect statusEffect)
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override void DestroyObj()
		{
		}
	}
}
