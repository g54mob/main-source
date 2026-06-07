using UnityEngine;

namespace Battle
{
	public class WaterShotMiracle : BaseMiracle
	{
		public CircleSpawn sally;

		public LoopEffect waterShot;

		public Target target;

		private StatusEffect _statusEffect;

		private Vector3 _firstMouseLocalPos;

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

		public override void DestroyObj()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
