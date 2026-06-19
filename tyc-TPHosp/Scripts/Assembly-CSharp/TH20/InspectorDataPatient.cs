using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class InspectorDataPatient : InspectorData
	{
		private enum Tab
		{
			Info = 0,
			Mood = 1,
			Log = 2
		}

		private enum Button
		{
			Message = 0,
			Vaccinate = 1,
			SendForTreatment = 2,
			SendHome = 3
		}

		private Patient _patient;

		private CharacterMugShot _mugShot;

		private NotificationMessage _patientMessage;

		private InspectorSubItemPatientInfo _patientInfo;

		private InspectorSubItemCharacterMood _characterMood;

		private InspectorSubItemCharacterLog _characterLog;

		private const float SendForTreatmentDiagnosisThreshold = 50f;

		public InspectorDataPatient(InspectorMenu owner, Level level, InspectorMenuAssetReference assetReference)
			: base(owner, level, assetReference)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(AssetReference.PatientInfoPrefab);
			_patientInfo = gameObject.GetComponent<InspectorSubItemPatientInfo>();
			GameObject gameObject2 = UnityEngine.Object.Instantiate(AssetReference.PatientMoodPrefab);
			_characterMood = gameObject2.GetComponent<InspectorSubItemCharacterMood>();
			GameObject gameObject3 = UnityEngine.Object.Instantiate(AssetReference.PatientLogPrefab);
			_characterLog = gameObject3.GetComponent<InspectorSubItemCharacterLog>();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientDied, new Action<Patient>(OnCharacterDestroyed));
			CharacterEvents characterEvents3 = Level.CharacterEvents;
			characterEvents3.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents3.OnPatientTimeTunnel, new Action<Patient>(OnCharacterDestroyed));
			Level.App.LocalPreferences.Video.OnCustomVSyncCountChange += OnCustomVSyncCountChange;
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientDied, new Action<Patient>(OnCharacterDestroyed));
			CharacterEvents characterEvents3 = Level.CharacterEvents;
			characterEvents3.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents3.OnPatientTimeTunnel, new Action<Patient>(OnCharacterDestroyed));
			Level.App.LocalPreferences.Video.OnCustomVSyncCountChange -= OnCustomVSyncCountChange;
			if (_patientInfo != null)
			{
				UnityEngine.Object.Destroy(_patientInfo.gameObject);
				_patientInfo = null;
			}
			if (_characterMood != null)
			{
				UnityEngine.Object.Destroy(_characterMood.gameObject);
				_characterMood = null;
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

		public bool SelectPatient(Patient patient)
		{
			if (_patient != patient)
			{
				_patient = patient;
				if (_mugShot != null)
				{
					_mugShot.Destroy();
					_mugShot = null;
				}
				if (patient != null)
				{
					HUD.MugshotConfig mugshotConfig = Level.HUD.GetConfig().MugshotConfig;
					_mugShot = CharacterMugShot.FromCharacterVisual(patient.Visual, 256, 256, mugshotConfig);
				}
			}
			return true;
		}

		public Patient GetSelectedPatient()
		{
			return _patient;
		}

		private void OnCharacterDestroyed(Character character)
		{
			if (character == _patient)
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
			if (_patient != null)
			{
				HUD.MugshotConfig mugshotConfig = Level.HUD.GetConfig().MugshotConfig;
				_mugShot = CharacterMugShot.FromCharacterVisual(_patient.Visual, 256, 256, mugshotConfig);
			}
		}

		public override void Update()
		{
			if (_patient == null)
			{
				_patientMessage = null;
			}
			else
			{
				_patientMessage = Level.Notifications.GetMessageFor(_patient);
			}
		}

		public override string GetHeaderTitle()
		{
			if (_patient == null)
			{
				return string.Empty;
			}
			return _patient.Name;
		}

		public override string GetUserSpecifiedNameEditButtonTooltip()
		{
			return ScriptLocalization.Inspector_TitleEdit.PatientNameEditButton_CS;
		}

		public override void SetUserSpecifiedName(string userSpecifiedName)
		{
			if (_patient != null)
			{
				bool num = _patient.IsDying(checkPosition: false);
				bool flag = _patient.GetComponent<GhostComponent>() != null;
				if (!(num || flag))
				{
					_patient.SetUserSpecifiedName(userSpecifiedName);
				}
			}
		}

		public override string GetUserSpecifiedName()
		{
			string result = string.Empty;
			if (_patient != null)
			{
				result = _patient.GetUserSpecifiedName();
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

		public override int GetDefaultTabIndex()
		{
			return 0;
		}

		public override int GetTabCount()
		{
			return 3;
		}

		public override string GetTabText(int tabIndex)
		{
			return tabIndex switch
			{
				0 => ScriptLocalization.Menu_Inspector.ButtonInfo_CS, 
				1 => ScriptLocalization.Menu_Inspector.ButtonMood_CS, 
				2 => ScriptLocalization.Menu_Inspector.ButtonLog_CS, 
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
			if (_patient != null)
			{
				Level.CameraLogic.TrackObject(_patient.GameObject.transform);
			}
		}

		public override void OnCycleLeftPressed()
		{
			if (_patient != null)
			{
				int num = Level.CharacterManager.Patients.IndexOf(_patient);
				num--;
				if (num <= -1)
				{
					num = Level.CharacterManager.Patients.Count - 1;
				}
				Patient character = Level.CharacterManager.Patients[num];
				Owner.Inspect(character);
			}
		}

		public override void OnCycleRightPressed()
		{
			if (_patient != null)
			{
				int num = Level.CharacterManager.Patients.IndexOf(_patient);
				num++;
				if (num >= Level.CharacterManager.Patients.Count)
				{
					num = 0;
				}
				Patient character = Level.CharacterManager.Patients[num];
				Owner.Inspect(character);
			}
		}

		public override GameObject GetBodyPrefab(int tabIndex)
		{
			switch ((Tab)tabIndex)
			{
			case Tab.Info:
				_patientInfo.Setup(_patient);
				return _patientInfo.gameObject;
			case Tab.Mood:
				_characterMood.Setup(_patient);
				return _characterMood.gameObject;
			case Tab.Log:
				_characterLog.Setup(_patient);
				return _characterLog.gameObject;
			default:
				return null;
			}
		}

		public override int GetFooterButtonCount()
		{
			return 4;
		}

		public override Sprite GetFooterButtonImage(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Message:
				return AssetReference.MessageButtonIcon;
			case Button.Vaccinate:
				return AssetReference.VaccinateButtonIcon;
			case Button.SendForTreatment:
				return AssetReference.SendForTreatmentButtonIcon;
			case Button.SendHome:
				if (!_patient.IsSendHomeAnachronistic())
				{
					return AssetReference.SendHomeButtonIcon;
				}
				return AssetReference.SendTimeTunnelButtonIcon;
			default:
				return null;
			}
		}

		public override bool IsFooterButtonVisible(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Message:
				return _patientMessage != null;
			case Button.Vaccinate:
			{
				List<ChallengeEpidemic> activeChallengesOfType = Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
				if (activeChallengesOfType.Count == 1 && activeChallengesOfType[0].VaccinesAvailable() && !activeChallengesOfType[0].IsVaccinated(_patient))
				{
					return ChallengeEpidemic.IsInfectableEver(_patient);
				}
				return false;
			}
			case Button.SendForTreatment:
			{
				if (_patient.IsLeavingHospital() || _patient.IsThinkingAboutGoingHome() || _patient.IsThinkingAboutDying())
				{
					return false;
				}
				if (_patient.DiagnosisCertainty < 50f)
				{
					return false;
				}
				if (!_patient.InteractionInterruptable)
				{
					return false;
				}
				if (_patient.RoomUsing != null && !_patient.RoomUsing.Definition.IsHospitalOrBay)
				{
					return false;
				}
				RoomDefinition treatmentRoom = _patient.Illness.GetTreatmentRoom(_patient, Level.ResearchManager);
				if (_patient.RoomUsing != null && _patient.RoomUsing.Definition == treatmentRoom)
				{
					return false;
				}
				if (_patient.GoingToRoom != null && _patient.GoingToRoom.Definition == treatmentRoom && _patient.ReasonUsingRoom == ReasonUseRoom.Treatment)
				{
					return false;
				}
				if (_patient.WaitingForRoom == treatmentRoom._type)
				{
					return false;
				}
				if (_patient.HasBeenCalledIntoRoom())
				{
					return false;
				}
				AnachronisticTreatmentComponent component3 = _patient.GetComponent<AnachronisticTreatmentComponent>();
				if (component3 != null && component3.IsSentHome())
				{
					return false;
				}
				return true;
			}
			case Button.SendHome:
			{
				if (_patient.IsLeavingHospital() || _patient.IsThinkingAboutGoingHome() || _patient.IsThinkingAboutDying())
				{
					return false;
				}
				AlienComponent component = _patient.GetComponent<AlienComponent>();
				if (component != null)
				{
					return component.ShouldShowSendHomeInspectorFooterButton();
				}
				AnachronisticTreatmentComponent component2 = _patient.GetComponent<AnachronisticTreatmentComponent>();
				if (component2 != null && component2.IsSentHome())
				{
					return false;
				}
				if (_patient.InteractionInterruptable)
				{
					return !_patient.HasBeenCalledIntoRoom();
				}
				return false;
			}
			default:
				return false;
			}
		}

		public override bool IsFooterButtonEnabled(int buttonIndex)
		{
			return true;
		}

		public override void OnFooterButtonPressed(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Message:
				OpenMessage();
				break;
			case Button.Vaccinate:
				Vaccinate();
				break;
			case Button.SendForTreatment:
				SendForTreatment();
				break;
			case Button.SendHome:
				SendHome();
				break;
			}
		}

		public override string GetFooterButtonTooltip(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Message:
				return ScriptLocalization.Tooltip.InspectorDataCharacter_Message_CS;
			case Button.Vaccinate:
				return ScriptLocalization.Tooltip.InspectorDataCharacter_Vaccinate_CS;
			case Button.SendForTreatment:
				return ScriptLocalization.Tooltip.InspectorDataPatient_SendForTreatment_CS;
			case Button.SendHome:
				if (!_patient.IsSendHomeAnachronistic())
				{
					return ScriptLocalization.Tooltip.InspectorDataPatient_SendHome_CS;
				}
				return ScriptLocalization.Tooltip_DLC_6.InspectorDataPatient_SendHomeAnachronistic_CS;
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

		private void SendForTreatment()
		{
			_patient.SendToTreatmentRoom(_patient.Illness.GetTreatmentRoom(_patient, Level.ResearchManager), immediately: true);
		}

		private void SendHome()
		{
			_patient.SendHome();
		}

		private void Vaccinate()
		{
			List<ChallengeEpidemic> activeChallengesOfType = Level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				activeChallengesOfType[0].VaccinateCharacter(_patient);
			}
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void OpenMessage()
		{
			if (_patientMessage != null)
			{
				Level.Notifications.Open(_patientMessage);
				Owner.CloseAndRestoreGeneralNotifications();
			}
		}
	}
}
