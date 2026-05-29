using UnityEngine;

namespace Battle
{
	public class Ninja : BaseUnit
	{
		public StatusEffect statusEffect;

		public SplitCircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public BulletSetting bullet;

		[Header("忍者固有")]
		public LoopEffect zoneEffect;

		[Label("折り返し距離")]
		[Tooltip("検索範囲+この値が手裏剣の折り返し距離")]
		public float overDistance;

		[Label("霧を再稼働させるまでの時間")]
		public float zoneReStartTime;

		private float _zoneTimer;

		private static SplitCircleSpawn.SplitCircleCounter<Ninja> _splitCounter;

		public float ReturnDistance => 0f;

		public Vector2 TargetPosCache { get; private set; }

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

		public void ReturnAnimation(bool hitCount = true)
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

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override int GetTotalPower()
		{
			return 0;
		}

		public override float GetTotalAttackTime()
		{
			return 0f;
		}
	}
}
