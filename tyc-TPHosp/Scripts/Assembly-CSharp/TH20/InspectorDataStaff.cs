using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class InspectorDataStaff : InspectorData
	{
		private enum Tab
		{
			Info = 0,
			Mood = 1,
			Stats = 2,
			Log = 3
		}

		private enum Button
		{
			Pickup = 0,
			Fire = 1,
			Promote = 2,
			Train = 3,
			Messages = 4,
			Vaccinate = 5,
			Break = 6,
			PayReview = 7,
			Jobs = 8,
			Customisation = 9
		}

		private Staff _staff;

		private CharacterMugShot _mugShot;

		private NotificationMessage _staffMessage;

		private string _nameWithTitle;

		private InspectorSubItemStaffInfo _staffInfo;

		private InspectorSubItemCharacterMood _characterMood;

		private InspectorSubItemStaffStats _staffStats;

		private InspectorSubItemCharacterLog _characterLog;

		public InspectorDataStaff(InspectorMenu owner, Level level, InspectorMenuAssetReference assetReference)
			: base(owner, level, assetReference)
		{
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			GameObject gameObject = UnityEngine.Object.Instantiate(AssetReference.StaffInfoPrefab);
			_staffInfo = gameObject.GetComponent<InspectorSubItemStaffInfo>();
			GameObject gameObject2 = UnityEngine.Object.Instantiate(AssetReference.StaffMoodPrefab);
			_characterMood = gameObject2.GetComponent<InspectorSubItemCharacterMood>();
			GameObject gameObject3 = UnityEngine.Object.Instantiate(AssetReference.StaffStatsPrefab);
			_staffStats = gameObject3.GetComponent<InspectorSubItemStaffStats>();
			GameObject gameObject4 = UnityEngine.Object.Instantiate(AssetReference.StaffLogPrefab);
			_characterLog = gameObject4.GetComponent<InspectorSubItemCharacterLog>();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			Level.App.LocalPreferences.Video.OnCustomVSyncCountChange += OnCustomVSyncCountChange;
		}

		private void OnLocalize()
		{
			if (_staff != null)
			{
				_nameWithTitle = _staff.NameWithTitle;
			}
		}

		public override void Destroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			Level.App.LocalPreferences.Video.OnCustomVSyncCountChange -= OnCustomVSyncCountChange;
			if (_staffInfo != null)
			{
				UnityEngine.Object.Destroy(_staffInfo.gameObject);
				_staffInfo = null;
			}
			if (_characterMood != null)
			{
				UnityEngine.Object.Destroy(_characterMood.gameObject);
				_characterMood = null;
			}
			if (_staffStats != null)
			{
				UnityEngine.Object.Destroy(_staffStats.gameObject);
				_staffStats = null;
			}
			if (_characterLog != null)
			{
				UnityEngine.Object.Destroy(_characterLog.gameObject);
				_characterLog = null;
			}
			if (_mugShot != null)
			{
				_mugShot.Destroy();
				_mugShot = null;
			}
			base.Destroy();
		}

		public bool SelectStaff(Staff staff)
		{
			if (_staff != staff)
			{
				_staff = staff;
				_nameWithTitle = _staff.NameWithTitle;
				if (_mugShot != null)
				{
					_mugShot.Destroy();
					_mugShot = null;
				}
				if (staff != null)
				{
					HUD.MugshotConfig mugshotConfig = Level.HUD.GetConfig().MugshotConfig;
					_mugShot = CharacterMugShot.FromCharacterVisual(staff.Visual, 256, 256, mugshotConfig);
				}
			}
			return true;
		}

		private void OnCharacterDestroyed(Character character)
		{
			if (character == _staff)
			{
				Owner.CloseAndRestoreGeneralNotifications();
			}
		}

		private void OnCustomVSyncCountChange(int vsyncCount)
		{
			Level.App.StartCoroutine(ReloadMugShot());
		}

		private IEnumerator ReloadMugShot()
		{
			yield return null;
			if (_mugShot != null)
			{
				_mugShot.Destroy();
				_mugShot = null;
			}
			if (_staff != null)
			{
				HUD.MugshotConfig mugshotConfig = Level.HUD.GetConfig().MugshotConfig;
				_mugShot = CharacterMugShot.FromCharacterVisual(_staff.Visual, 256, 256, mugshotConfig);
			}
		}

		public override void Update()
		{
			if (_staff == null)
			{
				_staffMessage = null;
			}
			else
			{
				_staffMessage = Level.Notifications.GetMessageFor(_staff);
			}
		}

		public override string GetHeaderTitle()
		{
			if (_staff == null)
			{
				return string.Empty;
			}
			return _nameWithTitle;
		}

		public override string GetUserSpecifiedNameEditButtonTooltip()
		{
			return ScriptLocalization.Inspector_TitleEdit.StaffNameEditButton_CS;
		}

		public override void SetUserSpecifiedName(string userSpecifiedName)
		{
			if (_staff != null)
			{
				_staff.SetUserSpecifiedName(userSpecifiedName);
				_nameWithTitle = _staff.NameWithTitle;
			}
		}

		public override string GetUserSpecifiedName()
		{
			string result = string.Empty;
			if (_staff != null)
			{
				result = _staff.GetUserSpecifiedName();
			}
			return result;
		}

		public override Texture GetHeaderPolaroidTexture()
		{
			if (_mugShot != null)
			{
				return _mugShot.Texture;
			}
			return Texture2D.blackTexture;
		}

		public override Sprite GetHeaderIcon()
		{
			return null;
		}

		public override bool UsePolaroidBacking()
		{
			return true;
		}

		public override int GetTabCount()
		{
			return 4;
		}

		public override int GetDefaultTabIndex()
		{
			return 0;
		}

		public override string GetTabText(int tabIndex)
		{
			return (Tab)tabIndex switch
			{
				Tab.Info => ScriptLocalization.Menu_Inspector.ButtonInfo_CS, 
				Tab.Mood => ScriptLocalization.Menu_Inspector.ButtonMood_CS, 
				Tab.Stats => ScriptLocalization.Menu_Inspector.ButtonStats_CS, 
				Tab.Log => ScriptLocalization.Menu_Inspector.ButtonLog_CS, 
				_ => string.Empty, 
			};
		}

		public override bool IsTabEnabled(int tabIndex)
		{
			return true;
		}

		public override void OnTabSelected(int tabIndex)
		{
		}

		public override void OnGoToPressed()
		{
			if (_staff != null)
			{
				if (_staff.GetComponent<StaffPickedUpState>() == null)
				{
					Level.CameraLogic.TrackObject(_staff.GameObject.transform);
				}
				else
				{
					Level.CameraLogic.TrackObject(null);
				}
			}
		}

		public override void OnCycleLeftPressed()
		{
			if (_staff != null)
			{
				int num = Level.CharacterManager.StaffMembers.IndexOf(_staff);
				num--;
				if (num <= -1)
				{
					num = Level.CharacterManager.StaffMembers.Count - 1;
				}
				Staff character = Level.CharacterManager.StaffMembers[num];
				Owner.Inspect(character);
			}
		}

		public override void OnCycleRightPressed()
		{
			if (_staff != null)
			{
				int num = Level.CharacterManager.StaffMembers.IndexOf(_staff);
				num++;
				if (num >= Level.CharacterManager.StaffMembers.Count)
				{
					num = 0;
				}
				Staff character = Level.CharacterManager.StaffMembers[num];
				Owner.Inspect(character);
			}
		}

		public override GameObject GetBodyPrefab(int tabIndex)
		{
			switch ((Tab)tabIndex)
			{
			case Tab.Info:
				_staffInfo.Setup(_staff);
				return _staffInfo.gameObject;
			case Tab.Mood:
				_characterMood.Setup(_staff);
				return _characterMood.gameObject;
			case Tab.Stats:
				_staffStats.Setup(_staff);
				return _staffStats.gameObject;
			case Tab.Log:
				_characterLog.Setup(_staff);
				return _characterLog.gameObject;
			default:
				return null;
			}
		}

		public override int GetFooterButtonCount()
		{
			return 10;
		}

		public override Sprite GetFooterButtonImage(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Pickup:
				return AssetReference.PickupButtonIcon;
			case Button.Fire:
				return AssetReference.FireButtonIcon;
			case Button.Promote:
				return AssetReference.PromoteButtonIcon;
			case Button.Train:
				return AssetReference.TrainButtonIcon;
			case Button.Messages:
				return AssetReference.MessageButtonIcon;
			case Button.Vaccinate:
				return AssetReference.VaccinateButtonIcon;
			case Button.Break:
				if (_staff.CurrentMode != Staff.Mode.Break && !_staff.IsRequestingABreak())
				{
					return AssetReference.BreakButtonIcon;
				}
				return AssetReference.BreakSelectedButtonIcon;
			case Button.PayReview:
				return AssetReference.PayReviewButtonIcon;
			case Button.Jobs:
				return AssetReference.JobsButtonIcon;
			case Button.Customisation:
				return AssetReference.StaffCustomisationButtonIcon;
			default:
				return null;
			}
		}

		public override bool IsFooterButtonVisible(int buttonIndex)
		{
			RoboJanitorComponent component = _staff.GetComponent<RoboJanitorComponent>();
			bool flag = component != null;
			bool flag2 = flag && component.SpawnedInLevel;
			bool flag3 = !_staff.HasBeenFired() && !_staff.HasResigned() && _staff.GetComponent<StaffPickedUpState>() == null;
			bool cantBeFired = _staff.Definition._cantBeFired;
			bool flag4 = _staff.CurrentJob is JobAmbulance jobAmbulance && (!jobAmbulance.Ambulance.IsGettingReady || jobAmbulance.Ambulance.StaffOnBoarding);
			flag3 = flag3 && !flag4;
			switch ((Button)buttonIndex)
			{
			case Button.Pickup:
				return flag3;
			case Button.Fire:
				if (flag3 && !flag2)
				{
					return !cantBeFired;
				}
				return false;
			case Button.Promote:
				if (flag3 && _staff.IsReadyForPromotion)
				{
					return !flag;
				}
				return false;
			case Button.Train:
				if (flag3 && _staff.HasFreeTrainingSlots && HasTrainingRooms())
				{
					return !flag;
				}
				return false;
			case Button.Messages:
				return _staffMessage != null;
			case Button.Vaccinate:
			{
				List<ChallengeEpidemic> activeChallengesOfType = Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
				if (activeChallengesOfType.Count == 1 && activeChallengesOfType[0].VaccinesAvailable() && !activeChallengesOfType[0].IsVaccinated(_staff))
				{
					return ChallengeEpidemic.IsInfectableEver(_staff);
				}
				return false;
			}
			case Button.Break:
				return flag3;
			case Button.PayReview:
				if (flag3)
				{
					return !flag;
				}
				return false;
			case Button.Jobs:
				if (flag3)
				{
					return !flag;
				}
				return false;
			case Button.Customisation:
				if (flag3)
				{
					return !flag;
				}
				return false;
			default:
				return false;
			}
		}

		public override bool IsFooterButtonEnabled(int buttonIndex)
		{
			if (buttonIndex == 0)
			{
				return _staff.CanPickup();
			}
			return true;
		}

		public override void OnFooterButtonPressed(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Pickup:
				Pickup();
				break;
			case Button.Fire:
				Fire();
				break;
			case Button.Promote:
				Promote();
				break;
			case Button.Train:
				Train();
				break;
			case Button.Messages:
				ShowMessage();
				break;
			case Button.Vaccinate:
				Vaccinate();
				break;
			case Button.Break:
				ToggleBreakMode();
				break;
			case Button.PayReview:
				PayReview();
				break;
			case Button.Jobs:
				Jobs();
				break;
			case Button.Customisation:
				Customise();
				break;
			}
		}

		public override string GetFooterButtonTooltip(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Pickup:
				return ScriptLocalization.Tooltip.InspectorDataStaff_Pickup_CS;
			case Button.Fire:
				return ScriptLocalization.Tooltip.InspectorDataStaff_Fire_CS;
			case Button.Promote:
				return ScriptLocalization.Tooltip.InspectorDataStaff_Promote_CS;
			case Button.Train:
				return ScriptLocalization.Tooltip.InspectorDataStaff_Train_CS;
			case Button.Messages:
				return ScriptLocalization.Tooltip.InspectorDataCharacter_Message_CS;
			case Button.Vaccinate:
				return ScriptLocalization.Tooltip.InspectorDataCharacter_Vaccinate_CS;
			case Button.Break:
				if (_staff.CurrentMode != Staff.Mode.Break && !_staff.IsRequestingABreak())
				{
					return ScriptLocalization.Tooltip.InspectorDataStaff_Break_CS;
				}
				return ScriptLocalization.Tooltip.InspectorDataStaff_ReturnWork_CS;
			case Button.PayReview:
				return ScriptLocalization.Tooltip.InspectorDataStaff_PayReview_CS;
			case Button.Jobs:
				return ScriptLocalization.Tooltip.InspectorDataStaff_Jobs_CS;
			case Button.Customisation:
				return ScriptLocalization.Tooltip.InspectorDataStaff_Customise_CS;
			default:
				return null;
			}
		}

		public override string GetFooterButtonNotVisibleTooltip(int buttonIndex)
		{
			return string.Empty;
		}

		public override int GetFooterButtonNotificationCount(int buttonIndex)
		{
			return 0;
		}

		private bool HasTrainingRooms()
		{
			return Level.WorldState.CountRoomsOfType(RoomDefinition.Type.Training, includeClosed: true) > 0;
		}

		private void Pickup()
		{
			Level.CharacterEvents.OnStaffPickup.InvokeSafe(_staff, null);
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void Fire()
		{
			string text = LocalisedString.Replace(ScriptLocalization.Notification.StaffFire_Message_CS, "{[STAFF]}", _staff.NameWithTitle);
			text = text + "\n\n" + GameStringUtils.GetStaffRecordText(_staff);
			text = text + "\n\n" + _staff.GuiltTripFlavourText.Translation;
			NotificationMessages.Definition definition = new NotificationMessages.Definition();
			definition.LocalisedTitle = new LocalisedString("Notification/StaffFire_Title_CS");
			definition.Text = text;
			definition.DefaultChoice = 1;
			definition.Choices = new LocalisedString[2]
			{
				new LocalisedString("Tooltip/InspectorDataStaff_Fire_CS"),
				new LocalisedString("Menu/Messages/Cancel_Button_CS")
			};
			NotificationGenericDecision message = new NotificationGenericDecision(definition, delegate(int response)
			{
				if (response == 0)
				{
					Level.CharacterEvents.OnStaffFired.InvokeSafe(_staff);
				}
			}, Level);
			Level.Notifications.OpenPopup(message);
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void Promote()
		{
			_staff.ShowReadyForPromotionMessage(immediately: true);
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void Train()
		{
			Level.HospitalHUDManager.TryOpenMenu(delegate
			{
				Level.HUD.CreateMenu<TrainingMenu>().Setup(Level, null, _staff, null);
			});
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void ShowMessage()
		{
			if (_staffMessage != null)
			{
				Level.Notifications.Open(_staffMessage);
			}
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void Vaccinate()
		{
			List<ChallengeEpidemic> activeChallengesOfType = Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				activeChallengesOfType[0].VaccinateCharacter(_staff);
			}
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void ToggleBreakMode()
		{
			if (_staff.CurrentMode == Staff.Mode.Break)
			{
				_staff.StartWork(null);
			}
			else if (_staff.IsRequestingABreak())
			{
				_staff.CancelModeChange();
			}
			else
			{
				_staff.ForceOnBreak();
			}
		}

		private void PayReview()
		{
			StaffMenu staffMenu = Level.HUD.FindMenu<StaffMenu>();
			if (!(staffMenu != null))
			{
				return;
			}
			bool flag = staffMenu.IsShowingViewFinder();
			if (staffMenu.IsClosing() || staffMenu.IsClosed())
			{
				flag = false;
				Level.HospitalHUDManager.ToggleInfoMenu(delegate(StaffMenu menu)
				{
					menu.Setup(StaffMenu.ViewModes.ViewModePayReview);
				});
			}
			else
			{
				staffMenu.SetViewMode(StaffMenu.ViewModes.ViewModePayReview);
			}
			staffMenu.SetCurrentSelectedStaff(_staff);
			staffMenu.SetInspectedStaffMember(flag ? _staff : null);
			if (!flag)
			{
				staffMenu.HideViewFinder();
			}
		}

		private void Customise()
		{
			StaffCustomisationMenu staffCustomisationMenu = Level.HUD.FindMenu<StaffCustomisationMenu>();
			if (!(staffCustomisationMenu != null))
			{
				return;
			}
			if (staffCustomisationMenu.IsClosing() || staffCustomisationMenu.IsClosed())
			{
				Level.HospitalHUDManager.ToggleInfoMenu(delegate(StaffCustomisationMenu menu)
				{
					menu.Setup();
				});
			}
			staffCustomisationMenu.InspectedStaff = _staff;
		}

		private void Jobs()
		{
			StaffMenu staffMenu = Level.HUD.FindMenu<StaffMenu>();
			if (!(staffMenu != null))
			{
				return;
			}
			bool flag = staffMenu.IsShowingViewFinder();
			if (staffMenu.IsClosing() || staffMenu.IsClosed())
			{
				flag = false;
				Level.HospitalHUDManager.ToggleInfoMenu(delegate(StaffMenu menu)
				{
					menu.Setup(StaffMenu.ViewModes.ViewModeJobAssignment);
				});
			}
			else
			{
				staffMenu.SetViewMode(StaffMenu.ViewModes.ViewModeJobAssignment);
			}
			staffMenu.SetCurrentSelectedStaff(_staff);
			staffMenu.SetInspectedStaffMember(flag ? _staff : null);
			if (!flag)
			{
				staffMenu.HideViewFinder();
			}
		}
	}
}
