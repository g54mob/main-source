using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Mandrake : BaseUnit
	{
		public SplitCircleSpawn sallyPoint;

		public StatusEffect effect;

		public KnockBack knockBack;

		public Target target;

		public EffectInterval attackInterval;

		[Header("Mandrake固有")]
		public LoopEffect voice;

		public LoopEffect sign;

		public float attackDelay;

		private List<BaseEnemy> targetEnemies;

		private bool _onGround;

		private static SplitCircleSpawn.SplitCircleCounter<Mandrake> _splitCounter;

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
