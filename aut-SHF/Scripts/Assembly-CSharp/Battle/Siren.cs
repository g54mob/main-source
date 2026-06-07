using UnityEngine;

namespace Battle
{
	public class Siren : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public BulletSetting bullet;

		[Header("セイレーン専用")]
		[Label("攻撃角度")]
		[Tooltip("セイレーンの向いている方向にn度の扇攻撃")]
		public float bulletAngle;

		[Label("弾の最大サイズ")]
		[Tooltip("スケールと同じ")]
		public float maxSize;

		[Label("攻撃範囲")]
		public float attackRange;

		[Label("複数ヒットまでのディレイ")]
		public float multiHitDelay;

		public HitEffect wave;

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

		public override void CheckLifeTime()
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
