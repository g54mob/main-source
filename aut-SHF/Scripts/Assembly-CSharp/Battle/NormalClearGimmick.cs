using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class NormalClearGimmick : BaseStageGimmick
	{
		[SerializeField]
		private float playTime;

		[SerializeField]
		private SkeletonAnimationController avatorSpine;

		[SerializeField]
		private SkeletonAnimationController fieldSpine;

		private const string AVATOR = "avator";

		private const string BOSS_ANIMATION = "Boss_animation_ADD";

		public override Sequence PlayBossBattleGimmick()
		{
			return null;
		}

		public override Sequence PlayBattleGimmick()
		{
			return null;
		}

		public override Sequence GetFirstStageSequence()
		{
			return null;
		}
	}
}
