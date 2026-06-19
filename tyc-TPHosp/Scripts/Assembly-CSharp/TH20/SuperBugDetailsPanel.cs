using System;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugDetailsPanel : SuperBugCreatorTabPanel
	{
		private enum PickerResponseID
		{
			NodeIconPicker = 1,
			NodeObjectivePicker = 2,
			RewardInfoPicker = 3
		}

		[SerializeField]
		private TMP_InputField _nameField;

		[SerializeField]
		private TMP_Text _nameTranslation;

		[SerializeField]
		private TMP_InputField _leaderNameField;

		[SerializeField]
		private TMP_Text _leaderNameTranslation;

		[SerializeField]
		private TMP_InputField _descriptionField;

		[SerializeField]
		private TMP_Text _descriptionTranslation;

		[SerializeField]
		private TMP_InputField _introLetterField;

		[SerializeField]
		private TMP_Text _introLetterTranslation;

		[SerializeField]
		private TMP_InputField _completionLetterField;

		[SerializeField]
		private TMP_Text _completionLetterTranslation;

		[SerializeField]
		private TMP_InputField _versionNumberInputField;

		[SerializeField]
		private TMP_InputField _superBugIDInputField;

		[SerializeField]
		private TMP_InputField _expiryInputField;

		[SerializeField]
		private Button _expiryLinkButton;

		[SerializeField]
		private GameObject _nodePanel;

		[SerializeField]
		private TMP_InputField _numCompletionsField;

		[SerializeField]
		private TMP_InputField _numBoostField;

		[SerializeField]
		private Dropdown _victoryNodeDropdown;

		[SerializeField]
		private DynamicButton _nodeIconButton;

		[SerializeField]
		private TMP_Text _objectiveDefinitionLabel;

		[SerializeField]
		private TMP_Text _objectiveDefinitionPathLabel;

		[SerializeField]
		private DynamicButton _objectiveButton;

		[SerializeField]
		private TMP_Text _nodeIDLabel;

		[SerializeField]
		private TMP_Text _childrenLabel;

		[SerializeField]
		private TMP_Text _rewardsInfoPathLabel;

		[SerializeField]
		private DynamicButton _rewardsInfoButton;

		[SerializeField]
		private TMP_Text _rewardsLabel;

		[SerializeField]
		private DynamicButton _rewardsButton;

		[SerializeField]
		private ResearchNetworkDebugRewardPanel _rewardsPanel;

		protected override void Start()
		{
			_nameField.onEndEdit.AddListener(OnNameEdited);
			_leaderNameField.onEndEdit.AddListener(OnLeaderNameEdited);
			_descriptionField.onEndEdit.AddListener(OnDescriptionEdited);
			_introLetterField.onEndEdit.AddListener(OnIntroLetterEdited);
			_completionLetterField.onEndEdit.AddListener(OnCompletionLetterEdited);
			_versionNumberInputField.onEndEdit.AddListener(OnVersionNumberEdited);
			_superBugIDInputField.onEndEdit.AddListener(OnSuperBugIDEdited);
			_expiryInputField.onEndEdit.AddListener(OnExpiryEdited);
			_expiryLinkButton.onClick.AddListener(OnExpiryLinkClicked);
			_numCompletionsField.onEndEdit.AddListener(OnNumCompletionsEdited);
			_numBoostField.onEndEdit.AddListener(OnNumBoostEdited);
			_victoryNodeDropdown.onValueChanged.AddListener(OnVictoryDropdownChanged);
			_nodeIconButton.onPrimaryDown.AddListener(OnNodeIconButton);
			_objectiveButton.onPrimaryDown.AddListener(OnObjectiveButton);
			_rewardsButton.onPrimaryDown.AddListener(OnRewardsButton);
			_rewardsInfoButton.onPrimaryDown.AddListener(OnRewardInfoButton);
			ResearchNetworkDebugRewardPanel rewardsPanel = _rewardsPanel;
			rewardsPanel.OnSavePressed = (Action)Delegate.Combine(rewardsPanel.OnSavePressed, new Action(OnSaveRewardsPressed));
			base.Start();
		}

		protected override void OnDestroy()
		{
			_nameField.onEndEdit.RemoveListener(OnNameEdited);
			_leaderNameField.onEndEdit.RemoveListener(OnLeaderNameEdited);
			_descriptionField.onEndEdit.RemoveListener(OnDescriptionEdited);
			_introLetterField.onEndEdit.RemoveListener(OnIntroLetterEdited);
			_completionLetterField.onEndEdit.RemoveListener(OnCompletionLetterEdited);
			_versionNumberInputField.onEndEdit.RemoveListener(OnVersionNumberEdited);
			_superBugIDInputField.onEndEdit.RemoveListener(OnSuperBugIDEdited);
			_expiryInputField.onEndEdit.RemoveListener(OnExpiryEdited);
			_expiryLinkButton.onClick.RemoveListener(OnExpiryLinkClicked);
			_numCompletionsField.onEndEdit.RemoveListener(OnNumCompletionsEdited);
			_numBoostField.onEndEdit.RemoveListener(OnNumBoostEdited);
			_victoryNodeDropdown.onValueChanged.RemoveListener(OnVictoryDropdownChanged);
			_nodeIconButton.onPrimaryDown.RemoveListener(OnNodeIconButton);
			_objectiveButton.onPrimaryDown.RemoveListener(OnObjectiveButton);
			_rewardsButton.onPrimaryDown.RemoveListener(OnRewardsButton);
			_rewardsInfoButton.onPrimaryDown.RemoveListener(OnRewardInfoButton);
			ResearchNetworkDebugRewardPanel rewardsPanel = _rewardsPanel;
			rewardsPanel.OnSavePressed = (Action)Delegate.Remove(rewardsPanel.OnSavePressed, new Action(OnSaveRewardsPressed));
			base.OnDestroy();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Refresh();
		}

		protected override void Refresh()
		{
			_nameField.text = Definition.Name.Term;
			_nameTranslation.text = Definition.Name.Translation;
			_leaderNameField.text = Definition.LeaderName.Term;
			_leaderNameTranslation.text = Definition.LeaderName.Translation;
			_descriptionField.text = Definition.Description.Term;
			_descriptionTranslation.text = Definition.Description.Translation;
			_introLetterField.text = Definition.IntroLetterText.Term;
			_introLetterTranslation.text = Definition.IntroLetterText.Translation;
			_completionLetterField.text = Definition.CompletedLetterText.Term;
			_completionLetterTranslation.text = Definition.CompletedLetterText.Translation;
			_superBugIDInputField.text = Definition.SuperBugID.ToString();
			_versionNumberInputField.text = Definition.Version.ToString();
			_expiryInputField.text = Definition.ExpiryTimeStamp.ToString();
			bool flag = SelectedNode != null && !SelectedNode.IsRoot;
			_nodePanel.gameObject.SetActive(flag);
			if (!flag)
			{
				return;
			}
			_nodeIconButton.image.overrideSprite = SelectedNode?.Definition.Icon;
			_numCompletionsField.text = SelectedNode?.Definition?.CompletionsRequired.ToString();
			_objectiveDefinitionLabel.text = SelectedNode?.Definition?.Objective?.NameLocalised.Translation;
			_rewardsLabel.text = $"{((SelectedNode?.Rewards == null) ? new int?(0) : SelectedNode?.Rewards.Count)} Reward(s)";
			string text = SelectedNode.VictoryType.ToString();
			int num = 0;
			bool flag2 = false;
			foreach (Dropdown.OptionData option in _victoryNodeDropdown.options)
			{
				if (option.text == text)
				{
					_victoryNodeDropdown.value = num;
					flag2 = true;
					break;
				}
				num++;
			}
			if (!flag2)
			{
				_victoryNodeDropdown.value = 0;
			}
			_numBoostField.text = SelectedNode?.ProgressBoost.ToString();
			_nodeIDLabel.text = SelectedNode?.NodeID.ToString();
			_childrenLabel.text = SelectedNode?.Children.Count.ToString();
		}

		private void OnNameEdited(string value)
		{
			Definition.Name = new LocalisedString(value);
			Refresh();
		}

		private void OnLeaderNameEdited(string value)
		{
			Definition.LeaderName = new LocalisedString(value);
			Refresh();
		}

		private void OnDescriptionEdited(string value)
		{
			Definition.Description = new LocalisedString(value);
			Refresh();
		}

		private void OnIntroLetterEdited(string value)
		{
			Definition.IntroLetterText = new LocalisedString(value);
			Refresh();
		}

		private void OnCompletionLetterEdited(string value)
		{
			Definition.CompletedLetterText = new LocalisedString(value);
			Refresh();
		}

		private void OnVersionNumberEdited(string value)
		{
			Definition.Version = int.Parse(value);
		}

		private void OnSuperBugIDEdited(string value)
		{
			Definition.SuperBugID = int.Parse(value);
		}

		private void OnExpiryEdited(string value)
		{
			Definition.ExpiryTimeStamp = uint.Parse(value);
		}

		private void OnNumCompletionsEdited(string value)
		{
			if (SelectedNode != null && !SelectedNode.IsRoot && SelectedNode.Definition != null)
			{
				SelectedNode.Definition.CompletionsRequired = int.Parse(value);
			}
		}

		private void OnNumBoostEdited(string value)
		{
			if (SelectedNode != null && !SelectedNode.IsRoot)
			{
				SelectedNode.ProgressBoost = int.Parse(value);
			}
		}

		private void OnVictoryDropdownChanged(int selectedIndex)
		{
			Dropdown.OptionData optionData = _victoryNodeDropdown.options[selectedIndex];
			CollaborativeNode.VictoryNodeType isVictoryNode = (CollaborativeNode.VictoryNodeType)Enum.Parse(typeof(CollaborativeNode.VictoryNodeType), optionData.text);
			SelectedNode.SetIsVictoryNode(isVictoryNode);
			Refresh();
			OnDefinitionChanged.InvokeSafe();
		}

		private void OnNodeIconButton()
		{
			if (SelectedNode != null)
			{
				_ = SelectedNode.IsRoot;
			}
		}

		private void OnObjectiveButton()
		{
			if (SelectedNode != null && !SelectedNode.IsRoot)
			{
				_ = SelectedNode.Definition;
			}
		}

		private void OnRewardsButton()
		{
			if (SelectedNode != null && !SelectedNode.IsRoot && SelectedNode.Definition != null && Definition != null)
			{
				_rewardsPanel.Show(SelectedNode);
			}
		}

		private void OnRewardInfoButton()
		{
			if (SelectedNode != null)
			{
				_ = SelectedNode.IsRoot;
			}
		}

		private void OnSaveRewardsPressed()
		{
			Refresh();
		}

		private void OnExpiryLinkClicked()
		{
			Application.OpenURL("https://www.unixtimestamp.com/index.php");
		}
	}
}
