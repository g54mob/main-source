using UnityEngine;

namespace Battle
{
	public class Harpy : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public BulletSetting bullet;

		[Header("Harpy固有")]
		public HitEffect windEffect;

		[Label("攻撃角度")]
		[Tooltip("ハーピーの向いている方向にn度の扇攻撃")]
		public float windAngle;

		[Label("最低攻撃力")]
		public int minAttackPoint;

		public float MaxDistanceSquared { get; private set; }

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

		public void Shot()
		{
		}

		public override void DestroyObj()
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public override float GetTotalAttackTime()
		{
			return 0f;
		}
	}
}
