using UnityEngine;

namespace Battle
{
	public class ThorsHammerMiracle : BaseMiracle
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public HitEffect clickEffectArk;

		public HitEffect clickEffectGround;

		public float delayDamage;

		private KnockBack _knockback;

		public override void Init()
		{
		}

		public override void SallyPositionSetting()
		{
		}

		public override void UpdateMiracle(double deltatime)
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
