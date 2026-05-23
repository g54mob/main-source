using UnityEngine;

namespace Battle
{
	public class WyvernBullet : UnitBaseBullet
	{
		public StatusEffect statusEffect;

		public Vector3 adjustmentPosition;

		public Transform rotationObj;

		private Wyvern _wyvern;

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

		public override void DestroyObj()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
