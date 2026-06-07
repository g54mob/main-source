using DG.Tweening;
using UnityEngine;

namespace UI
{
	public class OrdealRewardChoiceButton : RewardChoiceButton
	{
		[SerializeField]
		private SkeletonGraphicController spineController;

		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		public override void PlayAnimation(ref Sequence sequence)
		{
		}
	}
}
