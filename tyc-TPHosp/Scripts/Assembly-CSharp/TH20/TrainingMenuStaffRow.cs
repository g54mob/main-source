using System;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TrainingMenuStaffRow : MonoBehaviour
	{
		[SerializeField]
		private Button _rowButton;

		[SerializeField]
		private Button _removeButton;

		[SerializeField]
		private Button _plusButton;

		[SerializeField]
		private TMP_Text _title;

		[SerializeField]
		private TMP_Text _costs;

		[SerializeField]
		private RawImage _mugshotImage;

		[SerializeField]
		private StarIcons _starIcons;

		[SerializeField]
		private QualificationIcons _qualificationIcons;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private GameObject _NumTraineesAvailableCountPanel;

		[SerializeField]
		private TMP_Text _NumTraineesAvailableText;

		[SerializeField]
		private Localize _TraineesAvailableText;

		private CharacterMugShot _characterMugShot;

		public void Setup(Staff staff, Action<Staff> onClicked, Action<Staff> onRemoveClicked, bool isSelected, int freeSlotIndex, int numTraineesAvailable)
		{
			GameObjectUtils.SetInteractable(_rowButton, !isSelected);
			if (_title != null)
			{
				_title.text = GameStringUtils.StaffTitle(staff);
				_title.color = (isSelected ? Color.black : Color.white);
			}
			if (_rowButton != null && onClicked != null)
			{
				_rowButton.onClick.AddListener(delegate
				{
					onClicked.InvokeSafe(staff);
				});
			}
			if (_plusButton != null)
			{
				GameObjectUtils.SetInteractable(_plusButton, !isSelected);
				if (onClicked != null)
				{
					_plusButton.onClick.AddListener(delegate
					{
						onClicked.InvokeSafe(staff);
					});
				}
			}
			if (_removeButton != null)
			{
				if (onRemoveClicked == null)
				{
					GameObjectUtils.SetActive(_removeButton.gameObject, isActive: false);
				}
				else
				{
					GameObjectUtils.SetActive(_removeButton.gameObject, isActive: true);
					_removeButton.onClick.AddListener(delegate
					{
						onRemoveClicked.InvokeSafe(staff);
					});
				}
			}
			if (_starIcons != null)
			{
				_starIcons.SetLevel(staff.Rank, readyForPromotion: false);
			}
			if (_qualificationIcons != null)
			{
				_qualificationIcons.UpdateFrom(staff.Qualifications, staff.MaxQualifications, staff.Level.CharacterManager.StaffMembers);
			}
			if (_mugshotImage != null)
			{
				_characterMugShot = CharacterMugShot.FromCharacterVisual(staff.Visual, 128, 128, staff.Level.HUD.GetConfig().MugshotConfig);
				if (_characterMugShot != null)
				{
					_mugshotImage.texture = _characterMugShot.Texture;
				}
			}
			if (_costs != null)
			{
				GameObjectUtils.SetActive(_costs.gameObject, isActive: false);
			}
			SetupNumTraineesAndSlots(freeSlotIndex, numTraineesAvailable);
		}

		public void Setup(GuestTrainer staff, Action<Staff> onClicked, bool isSelected, GuestTrainerDefinition.Skill skill, int freeSlotIndex, int numTraineesAvailable)
		{
			GameObjectUtils.SetInteractable(_rowButton, !isSelected);
			if (_title != null)
			{
				_title.text = GameStringUtils.StaffTitle(staff);
			}
			if (_rowButton != null && onClicked != null)
			{
				_rowButton.onClick.AddListener(delegate
				{
					onClicked.InvokeSafe(staff);
				});
			}
			if (_removeButton != null)
			{
				GameObjectUtils.SetActive(_removeButton.gameObject, isActive: false);
			}
			if (_starIcons != null)
			{
				_starIcons.gameObject.SetActive(value: false);
			}
			if (_qualificationIcons != null)
			{
				_qualificationIcons.gameObject.SetActive(value: false);
			}
			if (_mugshotImage != null)
			{
				_characterMugShot = CharacterMugShot.FromCharacterVisual(staff.Visual, 128, 128, staff.Level.HUD.GetConfig().MugshotConfig);
				if (_characterMugShot != null)
				{
					_mugshotImage.texture = _characterMugShot.Texture;
				}
			}
			if (_costs != null)
			{
				_costs.text = GameStringUtils.GetGuestTrainerCostText(staff, skill);
			}
			SetupNumTraineesAndSlots(freeSlotIndex, numTraineesAvailable);
		}

		private void SetupNumTraineesAndSlots(int freeSlotIndex, int numTraineesAvailable)
		{
			if (!(_NumTraineesAvailableCountPanel != null))
			{
				return;
			}
			GameObjectUtils.SetActive(_NumTraineesAvailableCountPanel.gameObject, freeSlotIndex == 0);
			GameObjectUtils.SetActive(_TraineesAvailableText.gameObject, freeSlotIndex >= 0);
			if (freeSlotIndex >= 0)
			{
				if (freeSlotIndex == 0)
				{
					_NumTraineesAvailableText.text = $"{numTraineesAvailable}";
					_TraineesAvailableText.SetTerm("Menu/Training/TraineesAvailable");
				}
				else
				{
					_TraineesAvailableText.SetTerm("Menu/Training/TraineeSlotAvailable");
				}
			}
		}

		public void AddTrainerTooltip(Staff staff)
		{
			_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				string arg = GameStringUtils.StaffTitle(staff);
				string newValue = StringUtils.FormatPercentageValue(staff.GetTrainingTeachingSpeed());
				string arg2 = ScriptLocalization.Menu_Training.ToolTip_TrainerTeachingSpeed_CS.Replace("{[SPEED]}", newValue);
				tooltip.Text = $"{arg}\n{arg2}\n{staff.GetStatusText()}";
			});
		}

		public void AddGuestTrainerTooltip(GuestTrainer staff, GuestTrainerDefinition.Skill skill)
		{
			_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				string text = GameStringUtils.StaffTitle(staff);
				string newValue = StringUtils.FormatPercentageValue(staff.GetTrainingTeachingSpeed());
				string guestTrainerCostText = GameStringUtils.GetGuestTrainerCostText(staff, skill);
				string text2 = ((staff.Definition.FlavourTrait.Term != null) ? staff.Definition.FlavourTrait.Translation : "...");
				string text3 = ScriptLocalization.Menu_Training.ToolTip_TrainerTeachingSpeed_CS.Replace("{[SPEED]}", newValue);
				string statusText = staff.GetStatusText();
				if (statusText.IsNullOrEmpty())
				{
					tooltip.Text = $"{text}\n{text2}\n{text3}\n{guestTrainerCostText}";
				}
				else
				{
					tooltip.Text = $"{text}\n{text2}\n{text3}\n{guestTrainerCostText}\n{statusText}";
				}
			});
		}

		public void AddTraineeTooltip(Staff staff)
		{
			_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				string arg = GameStringUtils.StaffTitle(staff);
				string newValue = StringUtils.FormatPercentageValue(staff.GetTrainingLearningSpeed());
				string arg2 = ScriptLocalization.Menu_Training.ToolTip_TraineeLearningSpeed_CS.Replace("{[SPEED]}", newValue);
				tooltip.Text = $"{arg}\n{arg2}\n{staff.GetStatusText()}";
			});
		}

		private void OnDestroy()
		{
			if (_characterMugShot != null)
			{
				_characterMugShot.Destroy();
			}
		}
	}
}
