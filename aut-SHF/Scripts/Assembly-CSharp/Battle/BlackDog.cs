using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class BlackDog : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public KnockBack knockBack;

		[Header("BlackDog固有")]
		[Label("間隔(度)")]
		public float spaceDegree;

		public bool clockwise;

		private StatusEffect _statusEffect;

		private static List<BlackDog> blackDogs;

		private string _moveActionStr;

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
