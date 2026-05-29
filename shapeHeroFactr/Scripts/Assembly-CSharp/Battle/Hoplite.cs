using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Hoplite : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target targetting;

		public KnockBack knockBack;

		[Header("重装歩兵専用項目")]
		[SerializeField]
		[Label("出現数")]
		private int splitCount;

		[SerializeField]
		[Label("停止距離")]
		private float stopDistance;

		[SerializeField]
		[Label("移動時攻撃力")]
		[Tooltip("SubAttackのバフで上がるのはこちら(盾兵に合わせている)")]
		private int subAttack;

		[SerializeField]
		[Label("移動時当たり判定倍率")]
		[Range(0f, 1f)]
		private float colliderIncreaseRate;

		public LoopEffect walkEffect;

		public LoopEffect shieldLoop;

		private int[] angleRange;

		private float[] splitDegrees;

		private static List<Hoplite> hopliteList;

		private static int debugIndex;

		private int hopliteIndex;

		private float initColliderRadius;

		private bool _isArrived;

		private StatusEffect _statusEffect;

		public Hoplite NextHoplite { get; set; }

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

		private bool CheckStopPoint()
		{
			return false;
		}

		private void StopProcess()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		private void CalcInspectDirection(Vector3 targetPosition, float deltaTime)
		{
		}

		private Vector3? ExchangeHoplite()
		{
			return null;
		}

		private void RegisterNextHoplite(Hoplite nowHoplite)
		{
		}

		private int GetReserveCount(Hoplite hoplite)
		{
			return 0;
		}

		public override void DestroyObj()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
