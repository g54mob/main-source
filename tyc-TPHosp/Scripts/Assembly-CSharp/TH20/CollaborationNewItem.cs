using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborationNewItem : MonoBehaviour
	{
		public Action<CollaborationNewItem> OnItemSelected;

		[SerializeField]
		private Image _projectIcon;

		[SerializeField]
		private TMP_Text _projectNameLabel;

		[SerializeField]
		private TMP_Text _numPlayersLabel;

		[SerializeField]
		private ButtonAnimator _selectButton;

		[SerializeField]
		private Sprite _unselectedSprite;

		[SerializeField]
		private Sprite _selectedSprite;

		[SerializeField]
		private GameObject _completedTick;

		private CollaborativePortfolio _portfolio;

		private CollaborativeProjectDefinition _projectDefinition;

		public CollaborativeProjectDefinition ProjectDefinition
		{
			get
			{
				return _projectDefinition;
			}
			set
			{
				_projectDefinition = value;
				Refresh();
			}
		}

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
			if (_projectDefinition == null)
			{
				_projectIcon.overrideSprite = null;
				_projectNameLabel.text = string.Empty;
				_numPlayersLabel.text = string.Empty;
				GameObjectUtils.SetActive(_completedTick, isActive: false);
				return;
			}
			_projectIcon.overrideSprite = _projectDefinition.RootNodeSprite;
			_projectNameLabel.text = _projectDefinition.Name.Translation;
			bool isActive = _portfolio.IsResearchProjectTypeCompleted(_projectDefinition);
			GameObjectUtils.SetActive(_completedTick, isActive);
			int minNumParticipants = ResearchNetworkUtils.GetMinNumParticipants(_projectDefinition);
			int maxCollaborators = _projectDefinition.MaxCollaborators;
			string arg = ((minNumParticipants == maxCollaborators) ? minNumParticipants.ToString() : $"{minNumParticipants}-{maxCollaborators}");
			_numPlayersLabel.text = string.Format(ScriptLocalization.Collaborative_GUI.CollaboratorsCount_CS, arg);
		}

		private void OnSelected()
		{
			if (_projectDefinition != null)
			{
				OnItemSelected.InvokeSafe(this);
			}
		}
	}
}
