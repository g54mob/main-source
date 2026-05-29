using UnityEngine;

namespace Battle
{
	public class Wyvern : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public StatusEffect statusEffect;

		public BoundaryReflection reflection;

		[Header("ワイバーン固有")]
		public LoopEffect fire;

		public Vector3 adjustmentSpritePos;

		[Tooltip("本外に出た後もこの範囲までは突き進む")]
		public Rect secondOuterRect;

		private bool _reflectOk;

		private Vector3? _reflectDir;

		private Vector3 uniqueAction01SoundCorrectPosition;

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

		public override void LastUpdate()
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
