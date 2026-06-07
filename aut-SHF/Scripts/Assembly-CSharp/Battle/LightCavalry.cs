using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class LightCavalry : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		[Header("軽騎兵固有")]
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

		public override int GetTotalPower()
		{
			return 0;
		}
	}
}
