using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchPanelKicked : CollaborativeResearchPanel
	{
		public Action<Guid?> OnAbandonProject;

		[SerializeField]
		private TMP_Text _kickedText;

		[SerializeField]
		private DynamicButton _button;

		protected override void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnAbandonPressed);
		}

		protected override void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnAbandonPressed);
		}

		public override void Show()
		{
			base.Show();
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(Portfolio.GetProject(ProjectId.Value).LeaderOnlinePlayerID);
			_kickedText.text = string.Format(ScriptLocalization.Collaborative_GUI.KickedReason_CS, playerInfo.DisplayName);
		}

		public override void OnGetLatestCompleted()
		{
		}

		private void OnAbandonPressed()
		{
			OnAbandonProject.InvokeSafe(ProjectId);
		}
	}
}
