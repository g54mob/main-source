using UnityEngine;

namespace Battle
{
	public class IcicleShotMiracle : BaseMiracle
	{
		public CircleSpawn sally;

		public LoopEffect iconShot;

		public Target target;

		public StatusEffect statusEffect;

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
