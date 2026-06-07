using UnityEngine;

namespace Battle
{
	public class ArcherBullet : UnitBaseBullet
	{
		public LoopEffect loopEffect;

		private Archer _archer;

		private bool _isAttenuation;

		protected override void InitAdditionalParameter(BaseBullet bullet)
		{
		}

		public override void Init()
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
