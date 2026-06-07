using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class SanctuaryMiracle : BaseMiracle
	{
		[Label("付与時間")]
		[Tooltip("範囲から出た後の継続時間")]
		public float grantTime;

		[Label("オート時の検索範囲")]
		public float autoRadius;

		public LoopEffect field;

		public TrackingEffect buffEffect;

		private EffectInterval _interval;

		public override void Init()
		{
		}

		public override void SallyPositionSetting()
		{
		}

		public override void UpdateMiracle(double deltatime)
		{
		}

		private bool SearchHero(Vector2 origin, float radius, out List<BaseUnit> result)
		{
			result = null;
			return false;
		}

		private bool TargetHero(Vector2 origin, float radius, out BaseUnit result)
		{
			result = null;
			return false;
		}

		private void GrantBuff(BaseUnit hero)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
