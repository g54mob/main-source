using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkSteamAvatar : MonoBehaviour
	{
		[SerializeField]
		private PlayerAvatar _avatar;

		[SerializeField]
		private TooltipSpawner _tooltip;

		[SerializeField]
		private Image _statusIcon;

		[SerializeField]
		private Sprite _completedSprite;

		[SerializeField]
		private Color _completionColor;

		[SerializeField]
		private Sprite _inProgressSprite;

		[SerializeField]
		private Color _inProgressColor;

		private OnlinePlayerID _playerID;

		private bool _completed;

		public void Setup(OnlinePlayerID playerID, bool completed)
		{
			_playerID = playerID;
			_completed = completed;
			_avatar.PlayerID = _playerID;
			_statusIcon.overrideSprite = (completed ? _completedSprite : _inProgressSprite);
			_statusIcon.color = (completed ? _completionColor : _inProgressColor);
		}

		private void OnEnable()
		{
			_tooltip.SetDataProvider(PopulateTooltip);
		}

		private void OnDisable()
		{
			_tooltip.SetDataProvider(null);
		}

		private void PopulateTooltip(Tooltip tooltip)
		{
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_playerID);
			string arg = (_completed ? ScriptLocalization.Tooltip.ResearchNetwork_Completed_CS : ScriptLocalization.Tooltip.ResearchNetwork_InProgress_CS);
			tooltip.Text = ((_playerID == OnlinePlayerID.Nil || playerInfo == null) ? string.Empty : $"{playerInfo.DisplayName}\n{arg}");
		}
	}
}
