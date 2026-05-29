using UnityEngine;

namespace Battle
{
	public class Fairy : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public BoundaryReflection reflection;

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

		public override void CheckOuterRect()
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
