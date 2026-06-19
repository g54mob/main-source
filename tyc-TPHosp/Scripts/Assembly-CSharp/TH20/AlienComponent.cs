using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AlienComponent : EntityTickComponent
	{
		private const float cRandomAppearTimeInDayMin = 0f;

		private const float cRandomAppearTimeInDayMax = 2f;

		private const float cAppearanceFlashOnTimeMin = 0.05f;

		private const float cAppearanceFlashOnTimeMax = 0.12f;

		private const float cAppearanceFlashOffTimeMin = 0.05f;

		private const float cAppearanceFlashOffTimeMax = 0.2f;

		private const int cAppearanceNumFlashesMin = 1;

		private const int cAppearanceNumFlashesMax = 4;

		private int _daysRemaining;

		private int _daysToNextAlienAppearance;

		private bool _bDiscovered;

		private bool _bFullyRevealed;

		private bool _bAlienAppearancePending;

		private bool _bAlienAppearanceOn;

		private bool _bReceptionByPassPending;

		private bool _bDiscoveredPending;

		private bool _bLeaveHospitalPending;

		private bool _bLeavingHospital;

		private bool _bHasCheckedRoomQueueForJumping;

		private float _alienAppearanceGeneralTimer;

		private int _alienAppearanceSequenceCount;

		public string _appearanceAudioEvent;

		public string _discoveredAudioEvent;

		public int DaysRemaining
		{
			get
			{
				return _daysRemaining;
			}
			set
			{
				_daysRemaining = value;
			}
		}

		public bool Discovered
		{
			get
			{
				return _bDiscovered;
			}
			set
			{
				_bDiscovered = value;
			}
		}

		public void Setup(int durationDaysMin, int durationDaysMax)
		{
			_daysRemaining = UnityEngine.Random.Range(durationDaysMin, durationDaysMax);
			_daysRemaining = Mathf.Max(_daysRemaining, 0);
			RegisterEvents();
			CheckInitialByPassReception();
			SetRandomDaysToNextAlienAppearance(bApplyInitialDuration: true);
		}

		public override void Tick()
		{
			base.Tick();
			ProcessLeaveHospitalPending();
			ProcessDiscoveredPending();
			ProcessAlienAppearancePending();
			ProcessAlienAppearanceSequence();
		}

		public override void LateTick()
		{
			base.LateTick();
			ProcessCharacterLeavingLookAt();
		}

		public void OnUpdateDaily()
		{
			if (!_bLeavingHospital && !_bLeaveHospitalPending)
			{
				ProcessReceptionByPassPending();
				ProcessAlienAppearanceDaily();
				ProcessAlienQueueJumping();
				CheckSendToNextDiagnosis();
				DecrementDuration();
			}
		}

		public void OnRevealedActionFinished()
		{
			_bFullyRevealed = true;
			SetCharacterLeavingLookAt();
		}

		public string DebuggerDisplay()
		{
			return string.Format("DaysLeft:{0}, Discovered?:{1}", _daysRemaining, _bDiscovered ? "Y" : "N");
		}

		public void SetDiscoveredPending()
		{
			_bDiscoveredPending = true;
		}

		private void ProcessDiscoveredPending()
		{
			if (_bDiscoveredPending)
			{
				_bDiscoveredPending = false;
				SetDiscovered();
			}
		}

		private void SetDiscovered()
		{
			if (!_bDiscovered)
			{
				_bDiscovered = true;
				_daysRemaining = -1;
				NotifyAliensManagerOnAlientDiscovered();
				ApplyAlienLeavingHospitalModifiers();
				SetAlienAppearancePending(bSet: false);
				StopAlienAppearanceSequence();
				ProcessAlienAppearanceDaily();
				ApplyRoomCalledIntoWorkaround();
				PlayDiscoveredAudio();
				_bLeavingHospital = true;
			}
		}

		public bool GetAlienPatient(ref Patient retAlienPatient)
		{
			retAlienPatient = GetOwner() as Patient;
			return retAlienPatient != null;
		}

		public bool GetAlienPatientAndManager(ref Patient retAlienPatient, ref AliensManager retAliensManager)
		{
			bool result = false;
			retAlienPatient = GetOwner() as Patient;
			if (retAlienPatient != null)
			{
				retAliensManager = retAlienPatient.Level.CharacterManager.GetAliensManager();
				if (retAliensManager != null)
				{
					result = true;
				}
			}
			return result;
		}

		public bool ShouldShowSendHomeInspectorFooterButton()
		{
			bool flag = false;
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient))
			{
				flag = retAlienPatient.InteractionInterruptable && !retAlienPatient.HasBeenCalledIntoRoom();
				if (flag && base.Level.WorldState.GetRoomAtWorldCoord(retAlienPatient.Position.ToGridCoord(), includeHospital: false, includeClosedPlots: false) != null)
				{
					flag = false;
				}
			}
			return flag;
		}

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnRegisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient))
			{
				CharacterEvents characterEvents = retAlienPatient.Level.CharacterEvents;
				characterEvents.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents2 = retAlienPatient.Level.CharacterEvents;
				characterEvents2.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents3 = retAlienPatient.Level.CharacterEvents;
				characterEvents3.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents3.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
		}

		private void UnRegisterEvents()
		{
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient))
			{
				CharacterEvents characterEvents = retAlienPatient.Level.CharacterEvents;
				characterEvents.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents2 = retAlienPatient.Level.CharacterEvents;
				characterEvents2.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents3 = retAlienPatient.Level.CharacterEvents;
				characterEvents3.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents3.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
		}

		private void SetLeaveHospitalPending()
		{
			_bLeaveHospitalPending = true;
		}

		private void ProcessLeaveHospitalPending()
		{
			if (!_bLeaveHospitalPending)
			{
				return;
			}
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient))
			{
				retAlienPatient.InterruptNeedSatisfaction();
				bool flag = retAlienPatient.AllowedToLeaveHospital();
				if (!flag && (retAlienPatient.RoomUsing == null || retAlienPatient.RoomUsing.Definition.IsHospitalOrBay) && retAlienPatient.HasBeenCalledIntoRoom() && retAlienPatient.RoomCalledInto == null)
				{
					flag = true;
				}
				if (flag)
				{
					_bLeaveHospitalPending = false;
					_bLeavingHospital = true;
					retAlienPatient.LeaveHospital(Character.ReasonForLeavingHospital.IneffectiveTreatment);
				}
			}
		}

		private void DecrementDuration()
		{
			if (_daysRemaining >= 0 && --_daysRemaining < 0)
			{
				SetLeaveHospitalPending();
			}
		}

		private void CheckInitialByPassReception()
		{
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager) && RandomUtils.GlobalRandomInstance.NextFloat() <= retAliensManager.AliensManagerConfig._chanceOfReceptionByPass)
			{
				_bReceptionByPassPending = true;
			}
		}

		private void ProcessReceptionByPassPending()
		{
			if (_bReceptionByPassPending)
			{
				Patient retAlienPatient = null;
				if (GetAlienPatient(ref retAlienPatient) && retAlienPatient.RoomUsing != null)
				{
					retAlienPatient.RemoveComponents<CharacterCheckInComponent>();
					SendToNextDiagnosisRoom();
					_bReceptionByPassPending = false;
				}
			}
		}

		private void ProcessAlienAppearanceDaily()
		{
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (!GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager))
			{
				return;
			}
			if (!_bDiscovered)
			{
				if (!_bAlienAppearancePending)
				{
					bool flag = true;
					if (retAlienPatient.RoomUsing != null && retAlienPatient.RoomUsing.Definition._type == RoomDefinition.Type.Ward)
					{
						flag = false;
					}
					if (flag && --_daysToNextAlienAppearance <= 0)
					{
						SetAlienAppearancePending();
					}
				}
			}
			else
			{
				SetAlienAppearance(bAlienAppearanceRequired: true, bForce: true);
			}
		}

		private void ProcessAlienQueueJumping()
		{
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (!GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager))
			{
				return;
			}
			if (retAlienPatient.QueuingAtRoom != null)
			{
				if (_bHasCheckedRoomQueueForJumping)
				{
					return;
				}
				_bHasCheckedRoomQueueForJumping = true;
				int queueLength = retAlienPatient.QueuingAtRoom.QueueLength;
				if (queueLength >= 2)
				{
					int num = retAlienPatient.QueuingAtRoom.PositionInQueue(retAlienPatient);
					int num2 = Mathf.FloorToInt((float)queueLength * 0.5f);
					if (num > num2)
					{
						int reqdQueueIndex = UnityEngine.Random.Range(1, num2);
						retAlienPatient.QueuingAtRoom.MoveCharacterToQueuePos(retAlienPatient, reqdQueueIndex);
					}
				}
			}
			else
			{
				_bHasCheckedRoomQueueForJumping = false;
			}
		}

		private void SetAlienAppearancePending(bool bSet = true)
		{
			_bAlienAppearancePending = bSet;
			if (_bAlienAppearancePending)
			{
				_alienAppearanceGeneralTimer = UnityEngine.Random.Range(0f, 2f);
				SetRandomDaysToNextAlienAppearance();
			}
		}

		private void ProcessAlienAppearancePending()
		{
			if (_bAlienAppearancePending)
			{
				_alienAppearanceGeneralTimer -= Time.deltaTime;
				if (_alienAppearanceGeneralTimer <= 0f)
				{
					_bAlienAppearancePending = false;
					_alienAppearanceGeneralTimer = 0f;
					StartAlienAppearanceSequence();
				}
			}
		}

		private void StartAlienAppearanceSequence()
		{
			_alienAppearanceSequenceCount = UnityEngine.Random.Range(1, 4);
			_alienAppearanceGeneralTimer = 0f;
		}

		private void StopAlienAppearanceSequence()
		{
			_alienAppearanceSequenceCount = 0;
			_alienAppearanceGeneralTimer = 0f;
		}

		private void ProcessAlienAppearanceSequence()
		{
			if (_alienAppearanceSequenceCount <= 0)
			{
				return;
			}
			_alienAppearanceGeneralTimer -= Time.unscaledDeltaTime;
			if (_alienAppearanceGeneralTimer <= 0f)
			{
				bool bAlienAppearanceRequired = !_bAlienAppearanceOn;
				if (!_bAlienAppearanceOn)
				{
					_alienAppearanceGeneralTimer = UnityEngine.Random.Range(0.05f, 0.12f);
				}
				else if (--_alienAppearanceSequenceCount > 0)
				{
					_alienAppearanceGeneralTimer = UnityEngine.Random.Range(0.05f, 0.2f);
				}
				else
				{
					StopAlienAppearanceSequence();
				}
				SetAlienAppearance(bAlienAppearanceRequired);
			}
		}

		private void SetAlienAppearance(bool bAlienAppearanceRequired, bool bForce = false)
		{
			if (!(_bAlienAppearanceOn != bAlienAppearanceRequired || bForce))
			{
				return;
			}
			_bAlienAppearanceOn = bAlienAppearanceRequired;
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (!GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager))
			{
				return;
			}
			if ((bool)retAliensManager.AliensManagerConfig._alienModularMask && (!retAliensManager.AliensManagerConfig._replaceAliensWithPaparazzi || bForce))
			{
				if (_bAlienAppearanceOn)
				{
					retAlienPatient.Visual.SetModularMask(retAliensManager.AliensManagerConfig._alienModularMask.Instance);
					PlayRevealedAudio();
				}
				else
				{
					retAlienPatient.Visual.SetModularMask((retAlienPatient.Illness.ModularMask != null) ? retAlienPatient.Illness.ModularMask.Instance : null);
				}
			}
			if (_bAlienAppearanceOn && retAliensManager.AliensManagerConfig._miscAppearanceEffect != null)
			{
				PlayRevealedAudio();
				Transform transform = retAlienPatient.Transform;
				UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(retAliensManager.AliensManagerConfig._miscAppearanceEffect, transform, worldPositionStays: false), retAliensManager.AliensManagerConfig._miscAppearanceEffectTime);
			}
		}

		private void SetRandomDaysToNextAlienAppearance(bool bApplyInitialDuration = false)
		{
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager))
			{
				AliensManager.Config aliensManagerConfig = retAliensManager.AliensManagerConfig;
				_daysToNextAlienAppearance = (bApplyInitialDuration ? aliensManagerConfig._alienFlashAppearanceDaysInitial : 0) + UnityEngine.Random.Range(aliensManagerConfig._alienFlashAppearanceDaysMin, aliensManagerConfig._alienFlashAppearanceDaysMax);
			}
		}

		private void NotifyAliensManagerOnAlientDiscovered()
		{
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager))
			{
				retAliensManager.NotifyAlienDiscovered(retAlienPatient);
			}
		}

		private void ApplyAlienLeavingHospitalModifiers()
		{
			Patient retAlienPatient = null;
			AliensManager retAliensManager = null;
			if (GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager) && retAlienPatient.ModifiersComponent != null)
			{
				AliensManager.Config aliensManagerConfig = retAliensManager.AliensManagerConfig;
				if (aliensManagerConfig._alienModifiers != null)
				{
					retAlienPatient.ModifiersComponent.AddModifiers(aliensManagerConfig._alienModifiers);
				}
			}
		}

		private void SetCharacterLeavingLookAt()
		{
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient))
			{
				LookAtComponent component = retAlienPatient.GetComponent<LookAtComponent>();
				if (component != null)
				{
					component.SetEnabled(enabled: false);
					component.SetComponentTickEnabled(enabled: false);
				}
			}
		}

		private void ProcessCharacterLeavingLookAt()
		{
			if (_bDiscovered && _bFullyRevealed)
			{
				Patient retAlienPatient = null;
				AliensManager retAliensManager = null;
				if (GetAlienPatientAndManager(ref retAlienPatient, ref retAliensManager))
				{
					float alienHeadDownPitchDegrees = retAliensManager.AliensManagerConfig._alienHeadDownPitchDegrees;
					retAlienPatient.Visual.HeadSocket.transform.localEulerAngles = new Vector3(0f, alienHeadDownPitchDegrees, 0f);
				}
			}
		}

		private void CheckSendToNextDiagnosis()
		{
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient))
			{
				bool flag = false;
				if (retAlienPatient.GoingToRoom != null && retAlienPatient.GoingToRoom.Definition._type == RoomDefinition.Type.GPOffice && retAlienPatient.ReasonUsingRoom == ReasonUseRoom.Diagnosis)
				{
					flag = true;
				}
				if (!flag && retAlienPatient.IsWaitingForRoom())
				{
					retAlienPatient.StopWaitingForRoom();
					flag = true;
				}
				if (!flag && retAlienPatient.HasBeenCalledIntoRoom() && retAlienPatient.RoomCalledInto == null)
				{
					flag = true;
				}
				if (flag)
				{
					SendToNextDiagnosisRoom();
				}
			}
		}

		private void SendToNextDiagnosisRoom()
		{
			Patient retAlienPatient = null;
			if (!GetAlienPatient(ref retAlienPatient))
			{
				return;
			}
			List<Staff> list = base.Level.CharacterManager.StaffMembers.FindAll((Staff s) => s.Definition._type == StaffDefinition.Type.Doctor);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			Staff staff = list.RandomItem();
			if (staff != null)
			{
				Room diagnosisRoom = DiagnosisTreatmentComponent.GetDiagnosisRoom(retAlienPatient, staff);
				if (diagnosisRoom == null)
				{
					retAlienPatient.ExhaustedDiagnosisRooms = false;
					retAlienPatient.ResetRoomsDiagnosedIn();
					diagnosisRoom = DiagnosisTreatmentComponent.GetDiagnosisRoom(retAlienPatient, staff);
				}
				if (diagnosisRoom != null)
				{
					retAlienPatient.CalledIntoRoom = false;
					retAlienPatient.SendToDiagnosisRoom(diagnosisRoom);
				}
			}
		}

		private void OnPatientReceivedDiagnosis(Patient patient, Staff staff, Room room, float increment)
		{
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient) && patient == retAlienPatient)
			{
				float a = retAlienPatient.Level.HospitalPolicy.DiagnosisCertainty - 20f;
				a = Mathf.Max(a, 0f);
				float num = UnityEngine.Random.Range(Mathf.Min(20f, a), a);
				retAlienPatient.ModifyDiagnosisCertainty(num - retAlienPatient.DiagnosisCertainty);
			}
		}

		private void OnPatientSentHome(Patient patient)
		{
			if (!_bDiscovered)
			{
				Patient retAlienPatient = null;
				if (GetAlienPatient(ref retAlienPatient) && retAlienPatient == patient)
				{
					SetDiscoveredPending();
				}
			}
		}

		private void ApplyRoomCalledIntoWorkaround()
		{
			Patient retAlienPatient = null;
			if (GetAlienPatient(ref retAlienPatient) && retAlienPatient.RoomCalledInto == null)
			{
				retAlienPatient.CalledIntoRoom = false;
			}
		}

		private void PlayRevealedAudio()
		{
			if (AudioManager.Instance != null && _appearanceAudioEvent != null)
			{
				Patient retAlienPatient = null;
				if (GetAlienPatient(ref retAlienPatient))
				{
					AudioManager.Instance.Play(_appearanceAudioEvent, retAlienPatient.GameObject);
				}
			}
		}

		private void PlayDiscoveredAudio()
		{
			if (string.IsNullOrEmpty(_discoveredAudioEvent))
			{
				_discoveredAudioEvent = "AlienStamp:UI";
			}
			if (AudioManager.Instance != null && _discoveredAudioEvent != null)
			{
				InspectorMenu inspectorMenu = base.Level.HUD.FindMenu<InspectorMenu>(includeInactive: false);
				if (inspectorMenu != null)
				{
					AudioManager.Instance.Play(_discoveredAudioEvent, inspectorMenu.gameObject);
				}
			}
		}
	}
}
