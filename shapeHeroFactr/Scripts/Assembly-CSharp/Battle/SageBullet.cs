using UnityEngine;

namespace Battle
{
	public class SageBullet : UnitBaseBullet
	{
		public LoopEffect orbParticle;

		private Sage _sage;

		private double _intervalTimer;

		private Vector3 _defaultRadius;

		private void Awake()
		{
		}

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
	}
}
