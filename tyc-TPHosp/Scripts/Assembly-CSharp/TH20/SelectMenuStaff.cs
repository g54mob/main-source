using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuStaff : SelectMenuCharacter
	{
		[SerializeField]
		private DynamicButton _pickupButton;

		[SerializeField]
		private DynamicButton _fireButton;

		[SerializeField]
		private DynamicButton _promoteButton;

		[SerializeField]
		private DynamicButton _trainButton;

		[SerializeField]
		private DynamicButton _openMessageButton;

		[SerializeField]
		private DynamicButton _vaccinateButton;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _stateText;

		[SerializeField]
		private TMP_Text _jobText;

		[SerializeField]
		private ProgressBar _XPBar;

		[SerializeField]
		private TMP_Text _salaryText;

		[SerializeField]
		private TMP_Text _traitsText;

		[SerializeField]
		private TooltipSpawner _traitsTooltip;

		[SerializeField]
		private TMP_Text _statusEffectText;

		[SerializeField]
		private TooltipSpawner _statusEffectTooltip;

		[SerializeField]
		private ProgressBar _energyBar;

		[SerializeField]
		private ProgressBar _happinessBar;

		[SerializeField]
		private ProgressBar _hungerBar;

		[SerializeField]
		private ProgressBar _thirstBar;

		[SerializeField]
		private ProgressBar _toiletBar;

		[SerializeField]
		private ProgressBar _temperatureBar;

		[SerializeField]
		private ProgressBar _attractivenessBar;

		[SerializeField]
		private ProgressBar _hygieneBar;

		[SerializeField]
		private StarIcons _starIcons;

		[SerializeField]
		private QualificationIcons _qualificationIcons;

		private Staff _staff;

		private NotificationMessage _staffMessage;

		public override void Setup(Character character, Level level)
		{
			base.Setup(character, level);
			_staff = (Staff)character;
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnStaffReadyForPromotion = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffReadyForPromotion, new Action<Staff>(OnStaffReadyForPromotion));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents3.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			_pickupButton.onPrimaryDown.AddListener(PickupButton);
			_fireButton.onPrimaryDown.AddListener(FireButton);
			_promoteButton.onPrimaryDown.AddListener(PromoteButton);
			_trainButton.onPrimaryDown.AddListener(TrainButton);
			_openMessageButton.onPrimaryDown.AddListener(OpenMessage);
			_vaccinateButton.onPrimaryDown.AddListener(delegate
			{
				VaccinateCharacter(_staff);
			});
			SetupTrainingButton(_staff.HasFreeTrainingSlots);
			SetupPromotionButton(_staff.IsReadyForPromotion);
			_traitsText.text = _staff.Traits.GetShortName(_staff.Gender);
			_traitsTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = _staff.Traits.GetTooltipText(_staff.Gender);
			});
			if (_staff.ModifiersComponent != null)
			{
				_statusEffectTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _staff.ModifiersComponent.GetTooltipText(_staff.Gender);
				});
			}
			_starIcons.OnPromoteClicked = PromoteButton;
			_starIcons.SetLevel(_staff.Rank, _staff.IsReadyForPromotion);
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnStaffReadyForPromotion = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffReadyForPromotion, new Action<Staff>(OnStaffReadyForPromotion));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents3.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			base.Destroy();
		}

		protected override void Update()
		{
			base.Update();
			_staffMessage = base.Level.Notifications.GetMessageFor(_character);
			GameObjectUtils.SetActive(_openMessageButton.gameObject, _staffMessage != null);
			_name.text = _staff.NameWithTitle;
			if (_staff.RankDefinition != null)
			{
				_jobText.text = _staff.RankDefinition.GetTitleLocalised(_staff.Gender).Translation;
			}
			_stateText.text = _staff.GetStatusText();
			_salaryText.text = StringUtils.FormatCurrency(_staff.GetSalary()) + " pa";
			_energyBar.Progress = _staff.Energy.Value() / 100f;
			_energyBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_happinessBar.Progress = ((_staff.Happiness != null) ? (_staff.Happiness.Value() / 100f) : 0f);
			_happinessBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			CharacterAttributes characterAttributes = _staff.GetCharacterAttributes();
			_hungerBar.Progress = 1f - characterAttributes.GetAttribute(CharacterAttributes.Type.Hunger).Value() / 100f;
			_hungerBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_thirstBar.Progress = 1f - characterAttributes.GetAttribute(CharacterAttributes.Type.Thirst).Value() / 100f;
			_thirstBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_toiletBar.Progress = characterAttributes.GetAttribute(CharacterAttributes.Type.Toilet).Value() / 100f;
			_toiletBar.SetColorFromGradient(Color.green, Color.yellow, Color.red);
			_temperatureBar.Progress = MathUtils.ProportionThroughRange(_staff.TemperatureValue, -1f, 1f);
			_temperatureBar.SetColorFromGradient(Color.blue, Color.white, Color.red);
			_attractivenessBar.Progress = MathUtils.ProportionThroughRange(_staff.AttractivenessValue, -1f, 1f);
			_attractivenessBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			_hygieneBar.Progress = characterAttributes.GetAttribute(CharacterAttributes.Type.Hygiene).Value() / 100f;
			_hygieneBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			if (_staff.RankDefinition != null)
			{
				_XPBar.Progress = _staff.XP.Value() / _staff.RankDefinition.MaximumXP;
			}
			_qualificationIcons.UpdateFrom(_staff.Qualifications, _staff.MaxQualifications, _staff.Level.CharacterManager.StaffMembers);
			bool interactable = _staff.CanPickup();
			GameObjectUtils.SetInteractable(_fireButton, interactable);
			GameObjectUtils.SetInteractable(_pickupButton, interactable);
			UpdateVaccinationButton(_vaccinateButton.gameObject, _staff);
			if (_staff.ModifiersComponent != null)
			{
				_statusEffectText.text = _staff.ModifiersComponent.GetHUDString(_staff.Gender);
			}
		}

		private void PickupButton()
		{
			base.Level.CharacterEvents.OnStaffPickup.InvokeSafe(_staff, null);
			CloseMenu();
		}

		private void FireButton()
		{
			string text = ScriptLocalization.Menu_Select_Staff.AreYouSureFire_CS.Replace("{[STAFF]}", GameStringUtils.StaffTitle(_staff));
			text = text + "\n\n" + GameStringUtils.GetStaffRecordText(_staff);
			text = text + "\n\n" + _staff.GuiltTripFlavourText.Translation;
			NotificationMessages.DefinitionDynamic definitionDynamic = new NotificationMessages.DefinitionDynamic(() => ScriptLocalization.Menu_Select_Staff.FireStaffNotification_CS, () => text);
			definitionDynamic.DefaultChoice = 1;
			definitionDynamic.Choices = new LocalisedString[2]
			{
				new LocalisedString("Menu/Yes"),
				new LocalisedString("Menu/No")
			};
			NotificationGenericDecision message = new NotificationGenericDecision(definitionDynamic, delegate(int response)
			{
				if (response == 0)
				{
					base.Level.CharacterEvents.OnStaffFired.InvokeSafe(_staff);
					CloseMenu();
				}
			}, base.Level);
			base.Level.Notifications.OpenPopup(message);
		}

		private void OnStaffReadyForPromotion(Staff staff)
		{
			if (staff == _staff)
			{
				SetupPromotionButton(staff.IsReadyForPromotion);
				_starIcons.SetLevel(_staff.Rank, _staff.IsReadyForPromotion);
			}
		}

		private void OnStaffQualificationComplete(Staff staff, QualificationDefinition qualification, Staff trainer)
		{
			if (staff == _staff)
			{
				SetupTrainingButton(staff.HasFreeTrainingSlots);
			}
		}

		private void OnStaffPromoted(Staff staff)
		{
			if (staff == _staff)
			{
				SetupPromotionButton(readyForPromotion: false);
			}
		}

		private void SetupPromotionButton(bool readyForPromotion)
		{
			_promoteButton.gameObject.SetActive(readyForPromotion);
		}

		private void SetupTrainingButton(bool freeSlot)
		{
			_trainButton.gameObject.SetActive(freeSlot);
		}

		private void PromoteButton()
		{
			_staff.ShowReadyForPromotionMessage(immediately: true);
			CloseMenu();
		}

		private void TrainButton()
		{
			base.Level.HUD.CreateMenu<TrainingMenu>().Setup(base.Level, null, _staff, null);
			CloseMenu();
		}

		private void OpenMessage()
		{
			if (_staffMessage != null)
			{
				base.Level.Notifications.Open(_staffMessage);
				CloseMenu();
			}
		}
	}
}
