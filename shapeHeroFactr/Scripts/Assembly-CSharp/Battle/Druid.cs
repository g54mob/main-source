using UnityEngine;

namespace Battle
{
	public class Druid : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public LoopEffect myHealEffect;

		public TrackingEffect healEffect;

		private BaseUnit _healTarget;

		private StatusEffect _statusEffect;

		private TrackingEffect _healEffectObj;

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

		private void SearchHero()
		{
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
