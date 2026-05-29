using UnityEngine;

namespace Battle
{
	public class Fenrir : BaseUnit
	{
		public KnockBack knockBack;

		public EffectInterval attackInterval;

		public HitEffect charge;

		public HitEffect shout;

		public HitEffect atk;

		public float hitDelay;

		private StatusEffect _statusEffect;

		private bool _isHitProcess;

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

		private void Shot()
		{
		}

		public override void DestroyObj()
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override float GetTotalAttackTime()
		{
			return 0f;
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
