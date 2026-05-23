using UnityEngine;

namespace Battle
{
	public class MeteorMiracle : BaseMiracle
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public StatusEffect status;

		public HitEffect fall;

		public HitEffect endEffect;

		public LoopEffect loopEffect;

		public float displayDelay;

		[Label("直撃範囲")]
		public float directRange;

		[Label("直撃後のダメージ")]
		[Tooltip("弾にしかダメージを与えない仕様なので注意")]
		public int normalDamage;

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
