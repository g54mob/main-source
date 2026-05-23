using UnityEngine;

namespace Battle
{
	public class GravityMiracle : BaseMiracle
	{
		[Header("引き寄せ設定はstatusで")]
		public CircleSpawn sallyPoint;

		public Target target;

		public StatusEffect status;

		public HitEffect fall;

		public HitEffect endEffect;

		public LoopEffect loopEffect;

		public float displayDelay;

		[Label("引力を与えるインターバル(s)")]
		public float interval;

		private bool _isEffecting;

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
