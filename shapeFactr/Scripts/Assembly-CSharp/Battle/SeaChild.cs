using UnityEngine;

namespace Battle
{
	public class SeaChild : BaseEnemy
	{
		private EnemyBaseInfo _hatchedState;

		public bool IsEggMode { get; private set; }

		public override void Init()
		{
		}

		public void SetStatus(EnemyBaseInfo eggStatus, EnemyBaseInfo hatchedStatus)
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public void Hatch()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override void NockBack(float knockBackPower, float registanceMinus = 0f)
		{
		}

		public override void NockBack(Vector2 velocity, float registanceMinus = 0f)
		{
		}
	}
}
