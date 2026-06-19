using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ObjectiveRewardItem : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private Sprite _kudoshSprite;

		private IReward _reward;

		private void OnEnable()
		{
			_tooltipSpawner.SetDataProvider(OnTooltip);
		}

		private void OnDisable()
		{
			_tooltipSpawner.SetDataProvider(null);
		}

		public void Setup(IReward reward)
		{
			_reward = reward;
			if (reward is RewardRoomItemMetagame)
			{
				RewardRoomItemMetagame rewardRoomItemMetagame = reward as RewardRoomItemMetagame;
				_icon.overrideSprite = rewardRoomItemMetagame.Definition.Instance.GetIcon();
				_name.text = rewardRoomItemMetagame.Definition.Instance.GetLocalisedName();
			}
			else if (reward is RewardSilver)
			{
				RewardSilver rewardSilver = reward as RewardSilver;
				_icon.overrideSprite = _kudoshSprite;
				_name.text = StringUtils.FormatCurrencyWithoutSymbol(rewardSilver.Amount);
			}
		}

		private void OnTooltip(Tooltip tooltip)
		{
			if (_reward is RewardRoomItemMetagame)
			{
				RewardRoomItemMetagame rewardRoomItemMetagame = _reward as RewardRoomItemMetagame;
				tooltip.Text = rewardRoomItemMetagame.Definition.Instance.GetDescription();
			}
			else
			{
				tooltip.Text = string.Empty;
			}
		}
	}
}
