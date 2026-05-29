using UnityEngine;

namespace Battle
{
	public class PegasusxKnight : BaseUnit
	{
		public RectSpawn sallyPoint;

		public KnockBack knockBack;

		[Header("ペガサスナイト固有")]
		[Label("攻撃間隔")]
		[SerializeField]
		private float attackInterval;

		[Label("攻撃範囲")]
		[SerializeField]
		private float attackSearchRange;

		public LoopEffect wingEffect;

		public LoopEffect ground;

		public Vector3 adjustmentSpritePos;

		private bool _isLeftSide;

		private double _nextAttackTimer;

		private StatusEffect _statusEffect;

		private bool inBook;

		private Vector3 uniqueAction01SoundCorrectPosition;

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

		public override void CheckOuterRect()
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

		public override int GetTotalPower()
		{
			return 0;
		}

		public override void LastUpdate()
		{
		}
	}
}
