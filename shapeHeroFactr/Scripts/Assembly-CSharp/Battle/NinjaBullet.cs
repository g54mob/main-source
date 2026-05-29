using UnityEngine;

namespace Battle
{
	public class NinjaBullet : UnitBaseBullet
	{
		public LoopEffect shurikenEffect;

		private Ninja _ninja;

		private Vector2 _arriveTarget;

		private bool _isReturn;

		public override void Init()
		{
		}

		protected override void InitAdditionalParameter(BaseBullet bullet)
		{
		}

		public override void UpdateBullet(double deltatime)
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		private void CheckArrivePoint()
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
