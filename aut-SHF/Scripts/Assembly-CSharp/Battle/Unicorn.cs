using UnityEngine;

namespace Battle
{
	public class Unicorn : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		[Header("ユニコーン固有")]
		[SerializeField]
		[Label("道中ダメージ")]
		private int loadDamage;

		[Label("ヒット回数")]
		[SerializeField]
		private int hitCount;

		[SerializeField]
		private LoopEffect loopEffect;

		private StatusEffect _statusEffect;

		protected override void InitAdditionalParameter(BaseUnit unit)
		{
		}

		public override void Init()
		{
		}

		public override Vector2 SallyPositionSetting()
		{
			return default(Vector2);
		}

		public override void UpdateUnit(double deltatime)
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
