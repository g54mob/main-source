using UnityEngine;

namespace Battle
{
	public class Medusa : BaseUnit
	{
		[Label("出現角度offset")]
		public float offsetSallyAngle;

		[Label("出現間隔(n度)")]
		public float angleInterval;

		public CircleSpawn sallyPoint;

		public Target target;

		public StatusEffect statusEffect;

		public EffectInterval attackInterval;

		public HitEffect atk;

		public HitEffect ground;

		private static float prevAngle;

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

		private void Shot()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void CheckLifeTime()
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
