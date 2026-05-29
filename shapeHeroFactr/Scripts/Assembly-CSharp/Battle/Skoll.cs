using UnityEngine;

namespace Battle
{
	public class Skoll : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public KnockBack knockBack;

		public StatusEffect statusEffect;

		[Header("Skoll固有")]
		public bool clockwise;

		[Label("渦の密度")]
		public float vortexDensity;

		public LoopEffect sun;

		public float adjustmentSunOffset;

		private float _nowRad;

		private float _symbolOffsetRadius;

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

		private void CircularMotion(float deltaTime)
		{
		}

		protected override void Move(Vector3 velocity)
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void LastUpdate()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
