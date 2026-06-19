using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeProjectInfoItem : MonoBehaviour
	{
		public Action<int> OnProjectSelected;

		[SerializeField]
		private Image _projectIcon;

		[SerializeField]
		private PlayerAvatar _leaderPlayerAvatar;

		[SerializeField]
		private TMP_Text _projectNameLabel;

		[SerializeField]
		private TMP_Text _leaderNameLabel;

		[SerializeField]
		private ButtonAnimator _button;

		[SerializeField]
		private Image _buttonImage;

		[SerializeField]
		private GameObject _kickedBanner;

		[SerializeField]
		private GameObject _completedBanner;

		[SerializeField]
		private GameObject _alertIcon;

		[SerializeField]
		private GameObject _createProjectPanel;

		[SerializeField]
		private GameObject _inspectProjectPanel;

		[SerializeField]
		private int _slotIndex;

		[SerializeField]
		private Sprite _selectableBacking;

		[SerializeField]
		private Sprite _selectedBacking;

		private CollaborativeProject _project;

		private bool _isSelected;

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				_buttonImage.overrideSprite = (value ? _selectedBacking : _selectableBacking);
			}
		}

		public int SlotIndex => _slotIndex;

		public void Setup(CollaborativePortfolio portfolio)
		{
			if (_slotIndex < portfolio.ActiveProjectSlots.Count)
			{
				_project = portfolio.ActiveProjectSlots[_slotIndex];
			}
			else
			{
				_project = null;
			}
			Refresh();
		}

		private void OnEnable()
		{
			_button.Button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		private void OnDisable()
		{
			_button.Button.onPrimaryDown.RemoveListener(OnButtonPressed);
		}

		public void Refresh()
		{
			if (_project == null || _project.LocalPlayerData == null)
			{
				_completedBanner.gameObject.SetActive(value: false);
				_kickedBanner.gameObject.SetActive(value: false);
				_createProjectPanel.SetActive(value: true);
				_inspectProjectPanel.SetActive(value: false);
				return;
			}
			_createProjectPanel.SetActive(value: false);
			_inspectProjectPanel.SetActive(value: true);
			bool flag = _project.Portfolio.PortfolioDataController != null && _project.Portfolio.PortfolioDataController.PortfolioData.IsProjectCompleted(_project.ProjectID);
			_completedBanner.gameObject.SetActive(flag);
			_kickedBanner.gameObject.SetActive(_project.HasPlayerBeenKicked() && !flag);
			_projectNameLabel.text = _project.LocalPlayerData.Definition.Name.Translation;
			_projectIcon.overrideSprite = _project.LocalPlayerData.Definition.RootNodeSprite;
			if (_leaderPlayerAvatar != null)
			{
				_leaderPlayerAvatar.PlayerID = _project.LeaderOnlinePlayerID;
			}
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(_project.LeaderOnlinePlayerID);
			_leaderNameLabel.text = ((playerInfo != null) ? $"Project Manager: {playerInfo.DisplayName}" : ScriptLocalization.Misc.Unknown_CS);
			_alertIcon.SetActive(_project.Portfolio.HasProjectGotNewData(_project));
		}

		private void OnButtonPressed()
		{
			OnProjectSelected.InvokeSafe(_slotIndex);
		}
	}
}
