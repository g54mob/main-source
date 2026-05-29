using UnityEngine;

namespace Battle
{
	public class RockFallMiracle : BaseMiracle
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public StatusEffect statusEffect;

		public HitEffect fall;

		public HitEffect endEffect;

		public float displayDelay;

		[Label("直撃範囲")]
		public float directRange;

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
