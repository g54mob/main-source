using UnityEngine;

namespace Battle
{
	public class WizardThunderBullet : UnitBaseBullet
	{
		private Wizard _wizard;

		public ParticleSystem thunder;

		public ParticleSystem thunderFloor;

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
