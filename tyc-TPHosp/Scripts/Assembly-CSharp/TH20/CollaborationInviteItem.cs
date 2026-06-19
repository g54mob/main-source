using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborationInviteItem : MonoBehaviour
	{
		public Action<CollaborationInviteItem> OnItemSelected;

		[SerializeField]
		private PlayerAvatar _avatar;

		[SerializeField]
		private TMP_Text _projectNameLabel;

		[SerializeField]
		private TMP_Text _leaderLabel;

		[SerializeField]
		private TMP_Text _numPlayersLabel;

		[SerializeField]
		private ButtonAnimator _selectButton;

		[SerializeField]
		private Sprite _unselectedSprite;

		[SerializeField]
		private Sprite _selectedSprite;

		[SerializeField]
		public Image _projectIcon;

		[SerializeField]
		public Image AlertImage;

		[SerializeField]
		private GameObject _completedTick;

		private CollaborativePortfolio _portfolio;

		private CollaborativeProjectData _projectData;

		public ButtonAnimator.State ButtonState
		{
			get
			{
				return _selectButton.CurrentState;
			}
			set
			{
				_selectButton.CurrentState = value;
				_selectButton.Button.image.overrideSprite = ((value == ButtonAnimator.State.Selectable) ? _unselectedSprite : _selectedSprite);
			}
		}

		public CollaborativeProjectData ProjectData
		{
			get
			{
				return _projectData;
			}
			set
			{
				_projectData = value;
				Refresh();
			}
		}

		private void Start()
		{
			_selectButton.Button.onPrimaryDown.AddListener(OnSelected);
		}

		private void OnDestroy()
		{
			_selectButton.Button.onPrimaryDown.RemoveListener(OnSelected);
		}

		public void Initialise(CollaborativePortfolio portfolio)
		{
			_portfolio = portfolio;
		}

		private void Refresh()
		{
			if (_projectData == null)
			{
				_avatar.PlayerID = OnlinePlayerID.Nil;
				_projectIcon.overrideSprite = null;
				_projectNameLabel.text = string.Empty;
				_leaderLabel.text = string.Empty;
				GameObjectUtils.SetActive(_completedTick, isActive: false);
				return;
			}
			bool isActive = _portfolio.IsResearchProjectTypeCompleted(_projectData.Definition);
			GameObjectUtils.SetActive(_completedTick, isActive);
			_avatar.PlayerID = _projectData.LeaderOnlinePlayerID;
			_projectNameLabel.text = _projectData.Definition.Name.Translation;
			_projectIcon.overrideSprite = _projectData.Definition.RootNodeSprite;
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_projectData.LeaderOnlinePlayerID);
			_leaderLabel.text = ((playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
			int minNumParticipants = ResearchNetworkUtils.GetMinNumParticipants(_projectData.Definition);
			int maxCollaborators = _projectData.Definition.MaxCollaborators;
			string arg = ((minNumParticipants == maxCollaborators) ? minNumParticipants.ToString() : $"{minNumParticipants}-{maxCollaborators}");
			_numPlayersLabel.text = string.Format(ScriptLocalization.Collaborative_GUI.CollaboratorsCount_CS, arg);
		}

		private void OnSelected()
		{
			if (_projectData != null)
			{
				OnItemSelected.InvokeSafe(this);
			}
		}
	}
}
