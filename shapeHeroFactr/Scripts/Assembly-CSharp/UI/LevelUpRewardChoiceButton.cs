using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class LevelUpRewardChoiceButton : RewardChoiceButton
	{
		[SerializeField]
		private Image _rareFrame;

		[SerializeField]
		private TMP_Text _nowText;

		[SerializeField]
		private TMP_Text _featureText;

		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		public void SetContent(bool isRare, string nowParam, string featureParam, UnityAction clickSelectAction = null)
		{
		}

		public override void PlayAnimation(ref Sequence sequence)
		{
		}

		public void ResetFade()
		{
		}

		public void FadeOut()
		{
		}

		private void SetNowText(string str)
		{
		}

		private void SetFeatureText(string str)
		{
		}
	}
}
