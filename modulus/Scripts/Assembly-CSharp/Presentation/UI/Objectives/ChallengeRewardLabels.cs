using System;
using System.Collections.Generic;
using Data.Objectives;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Objectives
{
	public class ChallengeRewardLabels : MonoBehaviour
	{
		[Serializable]
		private struct RewardLabel
		{
			public TextMeshProUGUI XpText;

			public TextMeshProUGUI CurrencyText;

			public Image CurrencyIcon;

			public GameObject Checkmark;
		}

		[SerializeField]
		private CurrencyUILibrary _currencyUILibrary;

		[SerializeField]
		private List<RewardLabel> _rewardLabels;

		[SerializeField]
		private Color _textColorNormal;

		[SerializeField]
		private Color _textColorRewarded;

		public void Build(ObjectiveTargetItem item, int tier)
		{
			_rewardLabels[tier].XpText.text = string.Format(LocalizationUtility.GetLocalizedText("Objectives.xpLabel"), item.XpReward.ToString());
			_rewardLabels[tier].CurrencyText.text = item.CurrencyReward.ToString();
			_rewardLabels[tier].CurrencyIcon.sprite = _currencyUILibrary.CurrencyUIs[item.CurrenyRewardResourceData].Sprite;
			_rewardLabels[tier].CurrencyText.color = _currencyUILibrary.CurrencyUIs[item.CurrenyRewardResourceData].Color;
			_rewardLabels[tier].Checkmark.SetActive(value: false);
		}

		public void SetRewarded(bool value, int tier)
		{
			_rewardLabels[tier].Checkmark.SetActive(value);
			_rewardLabels[tier].XpText.color = (value ? _textColorRewarded : _textColorNormal);
		}
	}
}
