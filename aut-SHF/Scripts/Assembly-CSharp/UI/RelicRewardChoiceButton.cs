using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class RelicRewardChoiceButton : RewardChoiceButton
	{
		[SerializeField]
		private Image rarityFrame;

		[SerializeField]
		private TMP_Text rarityText;

		private string _archiveCache;

		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		public override void PlayAnimation(ref Sequence sequence)
		{
		}
	}
}
