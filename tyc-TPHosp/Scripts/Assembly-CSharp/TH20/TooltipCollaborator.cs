using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class TooltipCollaborator : Tooltip
	{
		[SerializeField]
		private TMP_Text _nameLabel;

		[SerializeField]
		private TMP_Text _onlineStatusLabel;

		[SerializeField]
		private TMP_Text _nodeCompletionsLabel;

		[SerializeField]
		private TMP_Text _projectDataStatus;

		public void Setup(OnlinePlayerID onlinePlayerID, IResearchNetworkState networkState, bool isLocalPlayer = true, bool isDeprecated = false)
		{
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(onlinePlayerID);
			_nameLabel.text = ((playerInfo != null) ? playerInfo.DisplayName : "");
			_onlineStatusLabel.text = ((playerInfo != null && playerInfo.IsPlayingGame()) ? ScriptLocalization.Collaborative.PlayingTwoPointHospital_CS : ScriptLocalization.Collaborative.NotPlayingTwoPointHospital_CS);
			_nodeCompletionsLabel.text = string.Format(ScriptLocalization.Collaborative.TooltipCompletedNodes_CS, networkState.GetNodeCompletionCountForPlayer(onlinePlayerID));
			_projectDataStatus.text = ScriptLocalization.Collaborative.UpdatePending_CS;
			GameObjectUtils.SetActive(_projectDataStatus.gameObject, isDeprecated);
		}
	}
}
