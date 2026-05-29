using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResearchRewardChoiceButton : RewardChoiceButton
	{
		public Image unlockIcon;

		public Sprite openLockSprite;

		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		public override void PlayAnimation(ref Sequence sequence)
		{
		}
	}
}
