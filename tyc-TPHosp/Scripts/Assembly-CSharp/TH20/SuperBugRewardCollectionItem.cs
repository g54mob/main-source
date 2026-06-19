using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugRewardCollectionItem : MonoBehaviour
	{
		private enum State
		{
			Undiscovered = 0,
			Discovered = 1,
			ReadyToCollect = 2,
			Collected = 3
		}

		[SerializeField]
		private Image _rewardIcon;

		[SerializeField]
		private Image _hiddenRewardIcon;

		[SerializeField]
		private Image _victoryIcon;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private TMP_Text _buttonText;

		[SerializeField]
		private TooltipSpawner _rewardTooltipSpawner;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _undiscoveredText;

		[SerializeField]
		private TMP_Text _discoveredText;

		[SerializeField]
		private Animator _animator;

		private SuperBugNode _node;

		private IResearchNetworkState _networkState;

		private CollaborativePortfolio _portfolio;

		private Metagame _metagame;

		private int _superBugID;

		private void OnEnable()
		{
			_rewardTooltipSpawner.SetDataProvider(OnTooltip);
			_button.onPrimaryDown.AddListener(OnCollectPressed);
		}

		private void OnDisable()
		{
			_rewardTooltipSpawner.SetDataProvider(null);
			_button.onPrimaryDown.RemoveListener(OnCollectPressed);
		}

		public void Setup(Metagame metagame, SuperBugNode node, IResearchNetworkState networkState)
		{
			_metagame = metagame;
			_portfolio = metagame.CollaborativePortfolio;
			_superBugID = metagame.SuperBugManager.DownloadedProjectDefinition.SuperBugID;
			_node = node;
			_networkState = networkState;
			_victoryIcon.overrideSprite = networkState.GetVictoryNodeSprite(node.NodeID);
			_undiscoveredText.text = ((node.RewardInfo != null) ? node.RewardInfo.UndiscoveredDescription.Translation : string.Empty);
			_discoveredText.text = ((node.RewardInfo != null) ? node.RewardInfo.DiscoveredDescription.Translation : string.Empty);
			RefreshState();
		}

		private void RefreshState()
		{
			State state = State.Undiscovered;
			if (_node.Status == CollaborativeNode.State.Discovered)
			{
				state = State.Discovered;
			}
			if (_node.Status == CollaborativeNode.State.Completed)
			{
				state = ((_portfolio.PortfolioDataController == null || !_portfolio.PortfolioDataController.IsSuperBugVictoryAchieved(_superBugID, _node.VictoryType)) ? State.ReadyToCollect : State.Collected);
			}
			switch (state)
			{
			case State.Undiscovered:
				_titleText.text = LocalizationManager.GetTranslation("Collaborative/Rewards_???");
				break;
			case State.Discovered:
				_titleText.text = LocalizationManager.GetTranslation("Collaborative/Rewards_???");
				_rewardIcon.overrideSprite = ((_node.RewardInfo != null) ? _node.RewardInfo.Icon : null);
				_hiddenRewardIcon.overrideSprite = ((_node.RewardInfo != null) ? _node.RewardInfo.Icon : null);
				break;
			case State.ReadyToCollect:
				_rewardIcon.overrideSprite = ((_node.RewardInfo != null) ? _node.RewardInfo.Icon : null);
				_hiddenRewardIcon.overrideSprite = ((_node.RewardInfo != null) ? _node.RewardInfo.Icon : null);
				_titleText.text = ((_node.RewardInfo != null) ? _node.RewardInfo.Title.Translation : string.Empty);
				_buttonText.text = ScriptLocalization.Collaborative_GUI.Collect_CS;
				break;
			case State.Collected:
				_rewardIcon.overrideSprite = ((_node.RewardInfo != null) ? _node.RewardInfo.Icon : null);
				_hiddenRewardIcon.overrideSprite = ((_node.RewardInfo != null) ? _node.RewardInfo.Icon : null);
				_titleText.text = ((_node.RewardInfo != null) ? _node.RewardInfo.Title.Translation : string.Empty);
				_buttonText.text = ScriptLocalization.Collaborative_GUI.Collected_CS;
				break;
			}
			_animator.SetInteger("State", (int)state);
		}

		private void OnTooltip(Tooltip tooltip)
		{
			if (_networkState != null && _node != null && _node.Status == CollaborativeNode.State.Completed && _node.RewardInfo != null)
			{
				tooltip.Text = _node.RewardInfo.Tooltip.Translation;
			}
		}

		private void OnCollectPressed()
		{
			if (_networkState != null && _node != null && _node.Status == CollaborativeNode.State.Completed)
			{
				if (_portfolio.PortfolioDataController != null)
				{
					_portfolio.PortfolioDataController.AddCompletedSuperBugVictoryNode(_superBugID, _node.VictoryType);
				}
				if (_node.Rewards != null)
				{
					RewardUtils.GiveAllRewards(_node.Rewards.ToArray(), _metagame);
				}
				RefreshState();
			}
		}
	}
}
