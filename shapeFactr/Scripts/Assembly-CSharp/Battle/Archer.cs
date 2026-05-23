using UnityEngine;

namespace Battle
{
	public class Archer : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public BulletSetting bullet;

		public HitEffect shotParticle;

		[Label("威力減衰")]
		public Attenuation attenuation;

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
