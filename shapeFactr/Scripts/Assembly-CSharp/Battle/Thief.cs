using UnityEngine;

namespace Battle
{
	public class Thief : BaseUnit
	{
		public SplitCircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public StatusEffect statusEffect;

		public EffectInterval attackInterval;

		[Header("シーフ固有")]
		public LoopEffect zoneEffect;

		public SpriteAnimation hitShort;

		private static SplitCircleSpawn.SplitCircleCounter<Thief> _splitCounter;

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

		private void PlayHitSprite(Vector3 pos, Vector2 targetDir)
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

		public override int GetTotalPower()
		{
			return 0;
		}
	}
}
