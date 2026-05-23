using UnityEngine;

namespace Battle
{
	public class HopliteBullet : UnitBaseBullet
	{
		public KnockBack knockBack;

		[Label("本体との距離")]
		[Tooltip("進行方向に向かって距離が増える")]
		public float distance;

		public ParticleSystemRenderer shield;

		private Vector2 _prevDir;

		private float _angle;

		private Hoplite _hoplite;

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

		public override void BillboardRotation()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
