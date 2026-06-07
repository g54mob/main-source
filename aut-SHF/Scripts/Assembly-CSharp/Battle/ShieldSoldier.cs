using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class ShieldSoldier : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public KnockBack knockBack;

		public ParticleSystem startParticle;

		public LoopEffect waitParticle;

		[Header("盾兵専用項目")]
		[SerializeField]
		[Label("出現数")]
		private int splitCount;

		private int[] angleRange;

		private float[] splitDegrees;

		private static List<ShieldSoldier> shieldSoldierList;

		private static int debugIndex;

		private int shieldSoldierIndex;

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

		private void CalcInspectDirection(Vector3 targetPosition, float deltaTime)
		{
		}

		private Vector3? ExchangeShieldSoldier()
		{
			return null;
		}

		public override void DestroyObj()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
