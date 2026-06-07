using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResourceRewardChoiceButton : RewardChoiceButton
	{
		public Image unlockIcon;

		public Image rareFrame;

		public Sprite openLockSprite;

		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		public void SetRareFrame()
		{
		}

		public override void PlayAnimation(ref Sequence sequence)
		{
		}
	}
}
