using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Trent : BaseUnit
	{
		public SplitCircleSpawn sallyPoint;

		public StatusEffect effect;

		public KnockBack knockBack;

		public Target target;

		public EffectInterval attackInterval;

		[Header("トレント固有")]
		public LoopEffect sign;

		public float attackDelay;

		private List<BaseEnemy> targetEnemies;

		private static SplitCircleSpawn.SplitCircleCounter<Trent> _splitCounter;

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

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
