using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class SpearSoldier : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		private StatusEffect _statusEffect;

		[Header("槍兵固有")]
		[Label("2回目以降の検索範囲")]
		public float secondSearchRadius;

		[Label("2回目以降の検索角度")]
		public float secondSearchAngle;

		[Label("ターゲット間隔")]
		public EffectInterval targetInterval;

		[Label("2回目以降検索条件")]
		public List<SearchOption> secondSearchOptions;

		public LoopEffect spearEffect;

		private float _nowDegree;

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

		public override int GetTotalPower()
		{
			return 0;
		}
	}
}
