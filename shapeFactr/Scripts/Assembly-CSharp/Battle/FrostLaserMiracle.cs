using UnityEngine;

namespace Battle
{
	public class FrostLaserMiracle : BaseMiracle
	{
		public LoopEffect laser;

		public LoopEffect debris;

		public CircleSpawn sallyPoint;

		public StatusEffect statusEffect;

		public Target target;

		[Label("ヒット間隔")]
		[SerializeField]
		private EffectInterval hitInterval;

		public float frostTickness;

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

		public override void CheckLifeTime()
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
