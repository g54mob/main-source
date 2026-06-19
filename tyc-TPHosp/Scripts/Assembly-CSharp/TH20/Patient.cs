#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class Patient : Character
	{
		public enum Mode
		{
			Normal = 0,
			Dead = 1,
			RageQuit = 2,
			LeavingHospital = 3,
			SentHome = 4
		}

		private class SendToTreatmentRoomModeChange : IModeChange
		{
			private readonly Patient _patient;

			private readonly RoomDefinition _desiredRoom;

			public SendToTreatmentRoomModeChange(Patient patient, RoomDefinition desiredRoom)
			{
				_patient = patient;
				_desiredRoom = desiredRoom;
			}

			public bool Update()
			{
				if (_patient.IsIdleInHospital() || _patient.IsInUnstaffedRoom())
				{
					_patient.GotoTreatmentRoom(_desiredRoom);
					return true;
				}
				return false;
			}

			public int Priority()
			{
				return 0;
			}
		}

		private class DeathModeChange : IModeChange
		{
			private readonly Patient _patient;

			public DeathModeChange(Patient patient)
			{
				_patient = patient;
			}

			public bool Update()
			{
				_patient.InterruptNeedSatisfaction();
				if (_patient.RoomUsing == null || _patient.IsIdleInHospital() || _patient.IsInUnstaffedRoom())
				{
					_patient.LeaveQueue();
					_patient.SetState(null);
					_patient.SetCurrentMode(Mode.Dead);
					_patient.RemoveComponents<LookAtComponent>();
					_patient.RemoveComponents<TurnToFaceComponent>();
					_patient.SetBehaviour(_patient.Definition._behaviourDeath);
					_patient.Level.StatusIconManager.ShowStatusIcon(_patient, StatusIcon.Type.Dying);
					return true;
				}
				return false;
			}

			public int Priority()
			{
				return 3;
			}
		}

		private class SendHomeModeChange : IModeChange
		{
			private readonly Patient _patient;

			public bool LeaveNow;

			public SendHomeModeChange(Patient patient)
			{
				_patient = patient;
				_patient.Level.CharacterEvents.OnPatientSendHomeRequested.InvokeSafe(_patient);
			}

			public bool Update()
			{
				_patient.InterruptNeedSatisfaction();
				if (LeaveNow)
				{
					Leave();
					return true;
				}
				if ((_patient.GetState() == "WaitBed" || _patient.IsIdleInHospital() || (_patient.RoomUsing == null && _patient.GetComponent<CharacterCheckInComponent>() != null)) && !_patient.HasBeenCalledIntoRoom())
				{
					Leave();
					return true;
				}
				return false;
			}

			private void Leave()
			{
				_patient.LeaveHospital(ReasonForLeavingHospital.SentHomeByPlayer);
				_patient.SetCurrentMode(Mode.SentHome);
				_patient.Level.CharacterEvents.OnPatientSentHome.InvokeSafe(_patient);
			}

			public int Priority()
			{
				return 1;
			}
		}

		private class RageQuitModeChange : IModeChange
		{
			private readonly Patient _patient;

			public RageQuitModeChange(Patient patient)
			{
				_patient = patient;
			}

			public bool Update()
			{
				_patient.InterruptNeedSatisfaction();
				if (_patient.RoomUsing == null || _patient.IsIdleInHospital() || _patient.IsInUnstaffedRoom())
				{
					_patient.LeaveQueue();
					_patient.LeaveHospital(ReasonForLeavingHospital.RageQuit);
					_patient.SetCurrentMode(Mode.RageQuit);
					_patient.RemoveComponents<WaitForRoomToBeBuiltComponent>();
					_patient.Level.CharacterEvents.OnPatientRageQuit.InvokeSafe(_patient);
					_patient.Level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.RageQuit);
					return true;
				}
				return false;
			}

			public int Priority()
			{
				return 2;
			}
		}

		private const int ModePrioritySendToTreatment = 0;

		private const int ModePrioritySentHome = 1;

		private const int ModePriorityRageQuit = 2;

		private const int ModePriorityDead = 3;

		private List<RoomDefinition.Type> _roomsDiagnosedIn = new List<RoomDefinition.Type>();

		private List<RoomDefinition.Type> _waitingForRooms;

		private float _betterRoomCheckTime;

		private int _ambulanceID = -1;

		private string _ambulanceEmergencyID = string.Empty;

		private bool _hasArrivedAndDisembarked;

		private float _timeStuck;

		public new PatientDefinition Definition { get; private set; }

		public float DiagnosisCertainty { get; private set; }

		public bool ExhaustedDiagnosisRooms { private get; set; }

		public IllnessDefinition Illness { get; private set; }

		public Treatment.Outcome TreatmentOutcome { get; private set; }

		public Treatment.Outcome PendingTreatmentOutcome { get; set; }

		public TreatmentCalculationBreakdown TreatmentOutcomeBreakdown { get; private set; }

		public RoomDefinition.Type WaitingForRoom
		{
			get
			{
				if (_waitingForRooms != null)
				{
					return _waitingForRooms[0];
				}
				return RoomDefinition.Type.Invalid;
			}
		}

		public bool WaitingForFurtherDiagnosis
		{
			get
			{
				if (ReasonWaitingForRoom == ReasonUseRoom.Diagnosis && _waitingForRooms != null)
				{
					return _waitingForRooms.Count > 1;
				}
				return false;
			}
		}

		public RoomDefinition.Type WasWaitingForRoom { get; set; }

		public ReasonUseRoom ReasonWaitingForRoom { get; private set; }

		public Mode CurrentMode { get; private set; }

		public AttributeFloat Health { get; private set; }

		public int NumOfDiagnosis { get; private set; }

		public bool IsAEPatient => _ambulanceID > -1;

		public int AmbulanceID => _ambulanceID;

		public string AmbulanceEmergencyID => _ambulanceEmergencyID;

		public Patient(PatientDefinition definition, IllnessDefinition illnessDefinition, Level level, VisualManager visualManager, Sex sex, CharacterName name, int id, Vector3 position, bool navDisabled = false, bool delayedVisualCreation = false, int ambulanceID = -1, string ambulanceEmergencyID = "")
			: base(definition, level, visualManager, sex, name, id, position, navDisabled)
		{
			Definition = definition;
			Illness = illnessDefinition;
			_ambulanceID = ambulanceID;
			_ambulanceEmergencyID = ambulanceEmergencyID;
			if (!delayedVisualCreation)
			{
				CreateVisuals();
			}
			if (Illness._traits != null)
			{
				base.Traits = new CharacterTraits(Illness._traits);
			}
			Health = _attributes.GetAttribute(CharacterAttributes.Type.Health);
			if (Health != null)
			{
				Health.Equals(0f, Death, checkCallback: true);
			}
			AttributeFloat happiness = base.Happiness;
			if (happiness != null)
			{
				happiness.Equals(0f, RageQuit, checkCallback: true);
				happiness.SetValue(illnessDefinition.GetInitialHappiness(), callCallbacks: false);
			}
			ExcludeDiagnosisRooms();
		}

		public void CreateVisuals()
		{
			if (Illness.particleFX != null)
			{
				base.Visual.SetParticleFX(Illness.particleFX, Illness.particleRoot);
			}
			base.Visual.GenerateDefaultModular();
			if (Illness.ModularMask != null && Illness.ModularMask.Instance.CharacterModule != null)
			{
				base.Visual.SetModularMask(Illness.ModularMask.Instance);
			}
			if (Illness.SkinSelectionOverride != null)
			{
				base.Visual.SetSkinSelectionOverride(Illness.SkinSelectionOverride);
			}
			if (Illness._components != null)
			{
				EntityComponent[] components = Illness._components;
				foreach (EntityComponent obj in components)
				{
					AddComponent(MustCallDestroyOnInstance.CreateInstance(obj));
				}
			}
		}

		public void SetArrivedAndDisembarked()
		{
			_hasArrivedAndDisembarked = true;
		}

		public bool HasArrivedAndDisembarked()
		{
			return _hasArrivedAndDisembarked;
		}

		private void ExcludeDiagnosisRooms()
		{
			if (Illness.ExcludedDiagnosisRooms != null)
			{
				RoomDefinition.Type[] excludedDiagnosisRooms = Illness.ExcludedDiagnosisRooms;
				foreach (RoomDefinition.Type item in excludedDiagnosisRooms)
				{
					_roomsDiagnosedIn.AddUnique(item);
				}
			}
		}

		public void ExcludeDiagnosisRoom(RoomDefinition.Type roomType)
		{
			_roomsDiagnosedIn.AddUnique(roomType);
		}

		public void ResetRoomsDiagnosedIn()
		{
			_roomsDiagnosedIn.Clear();
			ExcludeDiagnosisRooms();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (Health != null)
			{
				Health.Equals(0f, Death, checkCallback: false);
			}
			if (base.Happiness != null)
			{
				base.Happiness.Equals(0f, RageQuit, checkCallback: false);
			}
			if (_roomsDiagnosedIn == null)
			{
				_roomsDiagnosedIn = new List<RoomDefinition.Type>();
				ExcludeDiagnosisRooms();
			}
			Level level = base.Level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, new Action(FixUpWanderers));
		}

		private void FixUpWanderers()
		{
			if (HasBeenDestroyed() || (IsAEPatient && !_hasArrivedAndDisembarked) || CurrentMode != Mode.Normal || GetComponent<CharacterCheckInComponent>() != null || base.SatisfyingNeed || base.GoingToRoom != null || base.QueuingAtRoom != null || IsWaitingForRoom() || IsThinkingAboutDying() || IsThinkingAboutRageQuitting() || base.Level.CharacterManager.ArrivalsManager.IsArriving(this))
			{
				return;
			}
			if (TreatmentOutcome == Treatment.Outcome.Unknown)
			{
				if (base.RoomUsing == null || !RoomDefinition.DiagnosisRooms.Contains(base.RoomUsing.Definition._type) || !base.RoomUsing.IsFunctional() || !base.RoomUsing.IsStaffed())
				{
					Logging.Warning(LogChannels.AI, "{0} doesn't have a valid room to go to, sending to diagnosis room", this);
					WaitForDiagnosisRoomToBeBuilt(GameAlgorithms.Config.PatientWaitLongTime);
				}
			}
			else
			{
				Logging.Warning(LogChannels.AI, "{0} doesn't have a valid room to go to, leaving hospital", this);
				LeaveHospital(ReasonForLeavingHospital.Cured);
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (GameTime.time > _betterRoomCheckTime)
			{
				_betterRoomCheckTime = GameTime.time + GameAlgorithms.Config.PatientBetterRoomCheckTime;
				if (base.Interruptable && base.GoingToRoom != null && base.CurrentBehaviour == Definition._behaviourGotoRoom && !base.GoingToRoomSetByPlayer && !HasBeenCalledIntoRoom())
				{
					Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(base.Level.WorldState, base.GoingToRoom.Definition._type, GetUseRoomType(), this);
					if (bestRoomOfType == null)
					{
						DestinationRoomInvalid(base.GoingToRoom);
					}
					else if (bestRoomOfType != base.GoingToRoom)
					{
						GotoRoom(bestRoomOfType, base.ReasonUsingRoom, false);
					}
				}
			}
			if (CurrentMode != Mode.Normal && !BehaviorTreeEnabled)
			{
				_timeStuck += GameTime.deltaTime;
				if (_timeStuck > 120f)
				{
					EnableBehaviour(enabled: true);
				}
			}
		}

		protected override void SetBehaviourVariables(CharacterBehaviorTree behaviorTree)
		{
			base.SetBehaviourVariables(behaviorTree);
			behaviorTree.SetVariable("Patient", new PatientRef(this));
		}

		public override void DebugGUI()
		{
			base.DebugGUI();
			if (!base.ShowDebugInfo)
			{
				return;
			}
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.box)
			{
				richText = true
			};
			Vector3 position = base.Position + Vector3.up * 2f;
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			string empty = string.Empty;
			empty = empty + "Name: " + base.Name;
			string text = empty;
			LocalisedString name = Illness.Name;
			empty = text + "\nIllness: " + name.ToString();
			empty = empty + "\nDiagnosis: " + DiagnosisCertainty + "%";
			empty = empty + "\nTreatment: " + TreatmentOutcome;
			empty = empty + "\nMode: " + CurrentMode.ToString() + "   State: " + GetState();
			empty = empty + "\nUsing: " + base.RoomUsing;
			empty = empty + "\nGoing to: " + base.GoingToRoom;
			empty = empty + "\nQueuing at Room: " + base.QueuingAtRoom;
			empty = empty + "\n" + ((base.BehaviorTree != null) ? base.BehaviorTree.ToString() : "No behaviour!");
			AlienComponent component = GetComponent<AlienComponent>();
			if (component != null)
			{
				empty = empty + "\nAlien: " + component.DebuggerDisplay();
			}
			empty = empty + "\nCan Satisfy Needs: " + CanSatisfyNeeds();
			empty = empty + "\nTemperature: " + base.TemperatureValue;
			empty = empty + "\nAttractiveness: " + base.AttractivenessValue;
			empty = empty + "\n" + _attributes;
			if (base.ModifiersComponent != null)
			{
				empty += base.ModifiersComponent.DebuggerDisplay();
			}
			if (ExhaustedDiagnosisRooms)
			{
				empty += "\nDiagnosis Exhausted";
			}
			if (base.Animator != null)
			{
				AnimatorClipInfo[] currentAnimatorClipInfo = base.Animator.GetCurrentAnimatorClipInfo(0);
				foreach (AnimatorClipInfo animatorClipInfo in currentAnimatorClipInfo)
				{
					empty += $"\nAnimation Clip: {animatorClipInfo.clip.name}";
				}
			}
			Vector2 vector2 = gUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y - vector2.y, vector2.x, vector2.y), empty, gUIStyle);
		}

		public void ModifyDiagnosisCertainty(float amount)
		{
			NumOfDiagnosis++;
			DiagnosisCertainty = Mathf.Min(DiagnosisCertainty + amount, 100f);
		}

		public bool FullyDiagnosed()
		{
			return DiagnosisCertainty >= base.Level.HospitalPolicy.DiagnosisCertainty;
		}

		public bool IsGoingForTreatment()
		{
			if (base.ReasonUsingRoom != ReasonUseRoom.Treatment)
			{
				return ReasonWaitingForRoom == ReasonUseRoom.Treatment;
			}
			return true;
		}

		public bool IsInTreatmentRoom()
		{
			if (base.ReasonUsingRoom == ReasonUseRoom.Treatment && base.GoingToRoom == base.RoomUsing)
			{
				return base.QueuingAtRoom == null;
			}
			return false;
		}

		public bool IsInDiagnosisRoom()
		{
			if (base.ReasonUsingRoom == ReasonUseRoom.Diagnosis && base.GoingToRoom == base.RoomUsing)
			{
				return base.QueuingAtRoom == null;
			}
			return false;
		}

		public bool IsWaitingForRoom()
		{
			return WaitingForRoom != RoomDefinition.Type.Invalid;
		}

		public void Treated(Room room, Treatment.Outcome outcome, TreatmentCalculationBreakdown breakdown)
		{
			TreatmentOutcome = outcome;
			TreatmentOutcomeBreakdown = breakdown;
			Illness.ApplyTreatmentStatusEffect(this, outcome);
			switch (outcome)
			{
			case Treatment.Outcome.Death:
				LeaveHospital(ReasonForLeavingHospital.IneffectiveTreatment);
				Death();
				base.Level.CharacterEvents.OnFatalTreatment.InvokeSafe(this, room.StaffWorkingInRoom);
				base.Level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.TreatmentFatal);
				break;
			case Treatment.Outcome.Ineffective:
				LeaveHospital(ReasonForLeavingHospital.IneffectiveTreatment);
				base.Level.CharacterEvents.OnIneffectiveTreatment.InvokeSafe(this, room.StaffWorkingInRoom);
				base.Level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.TreatmentIneffective);
				break;
			case Treatment.Outcome.Cured:
				if (Health != null)
				{
					Health.Modify(100f, 1f);
				}
				if (base.Happiness != null)
				{
					base.Happiness.Modify(GameAlgorithms.Config.CharacterCureHappinessIncrease, 1f);
				}
				if (Illness.TriggerAchievementOnCured)
				{
					PlatformStatsAndAchievements.TriggerAchievement(Illness.Achievement);
				}
				RemoveIllnessTraits();
				LeaveHospital(ReasonForLeavingHospital.Cured);
				base.Level.CharacterEvents.OnPatientCured.InvokeSafe(this, room.StaffWorkingInRoom);
				base.Level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.TreatmentSuccess);
				break;
			}
		}

		private void RemoveIllnessTraits()
		{
			if (base.Traits != null && Illness._traits != null)
			{
				SharedInstance<CharacterTraitDefinition>[] traits = Illness._traits;
				for (int i = 0; i < traits.Length; i++)
				{
					CharacterTraitDefinition instance = traits[i].Instance;
					base.Traits.Remove(this, instance);
				}
			}
		}

		public void StopWaitingForRoom()
		{
			if (_waitingForRooms != null && _waitingForRooms.Count != 0)
			{
				WasWaitingForRoom = _waitingForRooms[0];
			}
			_waitingForRooms = null;
		}

		public override void GotoRoom(Room room, ReasonUseRoom reason, bool setManually, int queueIndex = -1)
		{
			StopWaitingForRoom();
			RemoveComponents<WaitForRoomToBeBuiltComponent>();
			base.GotoRoom(room, reason, setManually, queueIndex);
		}

		private void WaitForRoomToBeBuilt(List<RoomDefinition.Type> roomTypes, ReasonUseRoom reason, float waitTime)
		{
			if (!IsLeavingHospital() && (!(base.CurrentBehaviour == Definition._behaviourWaitForRoom) || WaitingForRoom != roomTypes[0] || ReasonWaitingForRoom != reason))
			{
				bool flag = roomTypes.Contains(RoomDefinition.Type.Reception);
				if (!flag || !base.Level.ReceptionManager.IsReceptionValid(out var _))
				{
					LeaveQueue();
					base.GoingToRoom = null;
					SetBehaviour(Definition._behaviourWaitForRoom);
					base.BehaviorTree.SetVariable("Reason", new ReasonUseRoomRef(reason));
					base.BehaviorTree.SetVariable("RoomTypes", new RoomTypeListRef(roomTypes));
					base.BehaviorTree.SetVariable("WaitingForReception", flag);
					_waitingForRooms = roomTypes;
					ReasonWaitingForRoom = reason;
					GetOrAddComponent<WaitForRoomToBeBuiltComponent>().Initialise(roomTypes, waitTime);
				}
			}
		}

		public void WaitForRoomToBeBuilt(RoomDefinition.Type roomType, ReasonUseRoom reason, float waitTime)
		{
			WaitForRoomToBeBuilt(new List<RoomDefinition.Type> { roomType }, reason, waitTime);
		}

		public void WaitForTreatmentRoomToBeBuilt(RoomDefinition requiredTreatmentRoom, float waitTime)
		{
			WaitForRoomToBeBuilt(new List<RoomDefinition.Type> { requiredTreatmentRoom._type }, ReasonUseRoom.Treatment, waitTime);
		}

		public void WaitForDiagnosisRoomToBeBuilt(float waitTime)
		{
			List<RoomDefinition.Type> remainingDiagnosisRooms = GetRemainingDiagnosisRooms();
			if (remainingDiagnosisRooms.Count == 0)
			{
				LeaveHospital(ReasonForLeavingHospital.NoDiagnosisRoomsDefined);
			}
			else
			{
				WaitForRoomToBeBuilt(remainingDiagnosisRooms, ReasonUseRoom.Diagnosis, waitTime);
			}
		}

		public bool HasBeenDiagnosedInRoom(RoomDefinition.Type roomType)
		{
			return _roomsDiagnosedIn.Contains(roomType);
		}

		public List<RoomDefinition.Type> GetRemainingDiagnosisRooms()
		{
			List<RoomDefinition.Type> list = new List<RoomDefinition.Type>();
			RoomDefinition.Type[] diagnosisRooms = RoomDefinition.DiagnosisRooms;
			foreach (RoomDefinition.Type type in diagnosisRooms)
			{
				if (!HasBeenDiagnosedInRoom(type))
				{
					list.Add(type);
				}
			}
			return list;
		}

		public void SendToNextDiagnosisRoom(int furtherDiagnosisChoiceCount)
		{
			Room diagnosisRoom = DiagnosisTreatmentComponent.GetDiagnosisRoom(this, furtherDiagnosisChoiceCount);
			base.CalledIntoRoom = false;
			SendToDiagnosisRoom(diagnosisRoom);
		}

		public void SendToDiagnosisRoom(Room diagnosisRoom)
		{
			if (!IsLeavingHospital())
			{
				if (GetActiveModeChange() is SendHomeModeChange sendHomeModeChange)
				{
					sendHomeModeChange.LeaveNow = true;
				}
				else if (diagnosisRoom != null)
				{
					GotoRoom(diagnosisRoom, ReasonUseRoom.Diagnosis, false);
				}
				else
				{
					AwaitDiagnosisRoom();
				}
			}
		}

		private void AwaitDiagnosisRoom()
		{
			NotificationMessage message = new NotificationDiagnosisDecision(base.Level.Notifications.MessageDefinitions._diagnosisMessage, this);
			base.Level.Notifications.Send(message);
			WaitForDiagnosisRoomToBeBuilt(GameAlgorithms.Config.PatientWaitLongTime);
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				if (success)
				{
					CharacterBehaviorTree behaviorTree2 = base.BehaviorTree;
					behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
					base.Level.Notifications.Remove(message);
				}
			};
			CharacterBehaviorTree behaviorTree = base.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		public void SendToTreatmentRoom(RoomDefinition desiredRoom, bool immediately)
		{
			if (!IsLeavingHospital())
			{
				if (GetActiveModeChange() is SendHomeModeChange sendHomeModeChange)
				{
					sendHomeModeChange.LeaveNow = true;
				}
				else if (immediately)
				{
					GotoTreatmentRoom(desiredRoom);
				}
				else
				{
					ChangeMode(new SendToTreatmentRoomModeChange(this, desiredRoom));
				}
			}
		}

		private void GotoTreatmentRoom(RoomDefinition desiredRoom)
		{
			NotificationMessages messageDefinitions = base.Level.Notifications.MessageDefinitions;
			bool flag = base.Level.GameplayStatsTracker.HasIllnessBeenDiagnosedBefore(Illness);
			base.Level.CharacterEvents.OnIllnessDiagnosed.InvokeSafe(this, Illness);
			Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(base.Level.WorldState, desiredRoom._type, RoomUseType.Treatment, this);
			if (bestRoomOfType != null)
			{
				if (!flag)
				{
					NotificationNewIllness message = new NotificationNewIllness(GameAlgorithms.DoesHospitalHaveRoom(base.Level.WorldState, desiredRoom._type) ? messageDefinitions._newIllnessRoomBuiltMessage : messageDefinitions._newIllnessMessage, Illness, base.Level);
					base.Level.Notifications.Send(message);
				}
				GotoRoom(bestRoomOfType, ReasonUseRoom.Treatment, false);
				return;
			}
			NotificationMessages.Definition definition = (flag ? messageDefinitions._treatmentMessage : messageDefinitions._treatmentNewIllnessMessage);
			NotificationTreatmentDecision message2 = new NotificationTreatmentDecision(definition, this);
			base.Level.Notifications.Send(message2);
			WaitForTreatmentRoomToBeBuilt(desiredRoom, GameAlgorithms.Config.PatientWaitLongTime);
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				if (success)
				{
					CharacterBehaviorTree behaviorTree2 = base.BehaviorTree;
					behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
					base.Level.Notifications.Remove(message2);
				}
			};
			CharacterBehaviorTree behaviorTree = base.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void Death()
		{
			if (CurrentMode != Mode.Dead && CurrentMode != Mode.RageQuit && ChangeMode(new DeathModeChange(this)))
			{
				_attributes.Enabled = false;
				RemoveComponents<WaitForRoomToBeBuiltComponent>();
				base.GoingToRoom = null;
				LeaveQueue();
			}
		}

		public override void LeaveHospital(ReasonForLeavingHospital reason)
		{
			if (!IsLeavingHospital() || base.ReasonForLeaving != reason)
			{
				SetCurrentMode(Mode.LeavingHospital);
				base.LeaveHospital(reason);
			}
		}

		public void SendHome()
		{
			if (CurrentMode != Mode.Dead && CurrentMode != Mode.SentHome && ChangeMode(new SendHomeModeChange(this)) && !IsSendHomeAnachronistic())
			{
				base.Level.StatusIconManager.ShowStatusIcon(this, StatusIcon.Type.SentHome);
			}
		}

		public override void Idle()
		{
			if (CurrentMode == Mode.Normal && WaitingForRoom == RoomDefinition.Type.Invalid)
			{
				base.Idle();
			}
		}

		public void InterruptNeedSatisfaction()
		{
			if (base.SatisfyNeedsComponent != null && base.SatisfyNeedsComponent.SatisfyingNeed)
			{
				base.SatisfyNeedsComponent.Interrupt();
			}
		}

		public void RageQuit()
		{
			if (CurrentMode != Mode.Dead && CurrentMode != Mode.RageQuit && ChangeMode(new RageQuitModeChange(this)))
			{
				_attributes.Enabled = false;
				LeaveQueue();
			}
		}

		public override float GetAttributeModifierOverTime(string attributeName)
		{
			return base.GetAttributeModifierOverTime(attributeName) * Illness.GetAttributeMultiplier((CharacterAttributes.Type)_attributes.StringToEnumValue(attributeName));
		}

		protected override void DestinationRoomInvalid(Room room)
		{
			RoomDefinition.Type type = room.Definition._type;
			if (!room.Definition.WaitForRoomToBecomeValid())
			{
				room.RemoveFromQueue(this);
				return;
			}
			if (base.GoingToRoom != null && room != base.GoingToRoom)
			{
				type = base.GoingToRoom.Definition._type;
			}
			else if (base.QueuingAtRoom != null && room != base.QueuingAtRoom)
			{
				type = base.QueuingAtRoom.Definition._type;
			}
			base.GoingToRoom = null;
			if ((CurrentMode == Mode.LeavingHospital || CurrentMode == Mode.SentHome || CurrentMode == Mode.RageQuit) && type == RoomDefinition.Type.TimeTunnel)
			{
				SetCurrentMode(Mode.Normal);
				Idle();
			}
			if (CurrentMode == Mode.Normal)
			{
				room.RemoveFromQueue(this);
				Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(base.Level.WorldState, type, GetUseRoomType(), this);
				if (bestRoomOfType != null)
				{
					GotoRoom(bestRoomOfType, base.ReasonUsingRoom, false);
				}
				else if (base.ReasonUsingRoom == ReasonUseRoom.Diagnosis && type != RoomDefinition.Type.GPOffice && type != RoomDefinition.Type.TimeTunnel)
				{
					WaitForDiagnosisRoomToBeBuilt(GameAlgorithms.Config.PatientWaitLongTime);
				}
				else
				{
					WaitForRoomToBeBuilt(new List<RoomDefinition.Type> { type }, base.ReasonUsingRoom, GameAlgorithms.Config.PatientWaitForNewRoomTime);
				}
			}
			if (base.Interaction != null && base.Interaction.ParentRoomItem.OwningRoom == room)
			{
				base.Interaction.InterruptInteraction(this, characterDestroyed: false);
			}
		}

		public override void EvictedFromRoom(Room room)
		{
			if (!IsWaitingForRoom() && CurrentMode != Mode.RageQuit && TreatmentOutcome == Treatment.Outcome.Unknown)
			{
				base.EvictedFromRoom(room);
			}
		}

		public override IdleAnimation GetIdleAnim()
		{
			IdleAnimation idleAnim = base.GetIdleAnim();
			Character.IdleAnims.Clear();
			Character.IdleAnims.Add(idleAnim);
			if (Definition.FuturePatient)
			{
				Character.IdleAnims.Add(IdleAnimation.FutureIdle);
				Character.IdleAnims.Add(IdleAnimation.FutureIdle2);
			}
			if (Health != null && Health.Value() < 20f)
			{
				Character.IdleAnims.Add(IdleAnimation.Woozy);
			}
			if (RandomUtils.GlobalRandomInstance.NextFloat(0f, 100f) <= GameAlgorithms.Config.ChanceOfNeedsIdle && base.Happiness != null && base.Happiness.Value() > 80f)
			{
				Character.IdleAnims.Add(IdleAnimation.Happy);
			}
			if (RandomUtils.GlobalRandomInstance.NextFloat(0f, 100f) <= GameAlgorithms.Config.ChanceOfIllnessIdle)
			{
				switch (RandomUtils.GlobalRandomInstance.Next(0, 3))
				{
				case 0:
					Character.IdleAnims.Add(IdleAnimation.Scratching);
					break;
				case 1:
					Character.IdleAnims.Add(IdleAnimation.Sneeze);
					break;
				case 2:
					Character.IdleAnims.Add(IdleAnimation.Coughing);
					break;
				}
			}
			IdleAnimation result = Character.IdleAnims.RandomItem();
			Character.IdleAnims.Clear();
			return result;
		}

		public override WalkAnimation GetWalkAnim()
		{
			if (base.ModifiersComponent != null && base.ModifiersComponent.HasModifierOfType<CharacterModifierMovementSpeed>())
			{
				return WalkAnimation.Normal;
			}
			if (CurrentMode == Mode.Dead)
			{
				return WalkAnimation.Sick;
			}
			if (CurrentMode == Mode.RageQuit)
			{
				return WalkAnimation.Sad;
			}
			return base.GetWalkAnim();
		}

		public string GetStatusText()
		{
			string result = "";
			if (TreatmentOutcome != Treatment.Outcome.Unknown)
			{
				switch (TreatmentOutcome)
				{
				case Treatment.Outcome.Cured:
					result = ScriptLocalization.Patient.Status_Cured_CS;
					break;
				case Treatment.Outcome.Death:
					result = ScriptLocalization.Patient.Status_Dying_Treatment_CS;
					break;
				case Treatment.Outcome.Ineffective:
					result = ScriptLocalization.Patient.Status_TreatmentIneffective_CS;
					break;
				}
			}
			else if (IsDying())
			{
				result = ScriptLocalization.Patient.Status_Dying_Health_CS;
			}
			else if (CurrentMode == Mode.RageQuit || IsModeChangeActive<RageQuitModeChange>() || (CurrentMode == Mode.LeavingHospital && base.ReasonForLeaving == ReasonForLeavingHospital.RageQuit))
			{
				result = ScriptLocalization.Patient.Status_RageQuitting_CS;
			}
			else if (WaitingForRoom != RoomDefinition.Type.Invalid)
			{
				if (WaitingForFurtherDiagnosis)
				{
					result = ScriptLocalization.Patient.Status_FurtherDiagnosisRequired_CS;
				}
				else if (ReasonWaitingForRoom == ReasonUseRoom.Diagnosis || ReasonWaitingForRoom == ReasonUseRoom.Treatment)
				{
					result = LocalisedString.Replace(ScriptLocalization.Patient.Status_TreatmentRoomRequired_CS, "{[ROOM]}", RoomAlgorithms.GetDefinitionFromType(base.Level, WaitingForRoom).GetLocalisedName());
				}
			}
			else if (base.Happiness != null && base.Happiness.Value() < GameAlgorithms.Config.PatientLowHappiness)
			{
				result = LocalizationManager.Sources[0].GetTranslation("StatusEffects/Patient_Unhappy_Name_M");
			}
			else if (base.GoingToRoom != null)
			{
				result = ((base.GoingToRoom.Definition._type != RoomDefinition.Type.Reception || base.GoingToRoom.IsStaffed()) ? LocalisedString.Replace(ScriptLocalization.Patient.Status_GoingToRoom_CS, "{[ROOM]}", base.GoingToRoom.Definition.GetLocalisedName()) : ScriptLocalization.Patient.Status_WaitingForReceptionist_CS);
			}
			else if (GoingToReceptionDeskSprite() != null)
			{
				result = (base.Level.ReceptionManager.IsReceptionValid(out var waitingForReceptionist) ? ScriptLocalization.Patient.Status_GoingToReception_CS : ((!waitingForReceptionist) ? LocalisedString.Replace(ScriptLocalization.Patient.Status_TreatmentRoomRequired_CS, "{[ROOM]}", RoomAlgorithms.GetDefinitionFromType(base.Level, RoomDefinition.Type.Reception).GetLocalisedName()) : ScriptLocalization.Patient.Status_WaitingForReceptionist_CS));
			}
			return result;
		}

		public bool IsDying(bool checkPosition = true)
		{
			if (checkPosition && !IsIdleInHospital() && !IsInUnstaffedRoom())
			{
				return false;
			}
			if (CurrentMode != Mode.Dead)
			{
				return IsModeChangeActive<DeathModeChange>();
			}
			return true;
		}

		public Sprite GetStatusSprite()
		{
			Sprite result = null;
			if (TreatmentOutcome != Treatment.Outcome.Unknown)
			{
				switch (TreatmentOutcome)
				{
				case Treatment.Outcome.Cured:
					result = Definition.TreatmentSucessIcon;
					break;
				case Treatment.Outcome.Death:
					result = Definition.DyingIcon;
					break;
				case Treatment.Outcome.Ineffective:
					result = Definition.TreatmentIneffectiveIcon;
					break;
				}
			}
			else if (IsDying())
			{
				result = Definition.DyingIcon;
			}
			else if (CurrentMode == Mode.RageQuit || (CurrentMode == Mode.LeavingHospital && base.ReasonForLeaving == ReasonForLeavingHospital.RageQuit))
			{
				result = Definition.RageQuitIcon;
			}
			else if (CurrentMode == Mode.SentHome || IsModeChangeActive<SendHomeModeChange>() || (CurrentMode == Mode.LeavingHospital && base.ReasonForLeaving == ReasonForLeavingHospital.SentHomeByPlayer))
			{
				result = Definition.SentHomeIcon;
			}
			else if (base.Happiness != null && base.Happiness.Value() < GameAlgorithms.Config.PatientLowHappiness)
			{
				StatusIcon statusIcon = base.Level.StatusIconManager.GetStatusIcon(StatusIcon.Type.Unhappy);
				result = ((statusIcon != null) ? statusIcon.Icon : null);
			}
			else
			{
				if (WaitingForRoom != RoomDefinition.Type.Invalid)
				{
					if (WaitingForFurtherDiagnosis)
					{
						return Definition.MoreDiagnosisIcon;
					}
					return RoomAlgorithms.GetDefinitionFromType(base.Level, WaitingForRoom)._icon;
				}
				result = ((base.GoingToRoom == null) ? GoingToReceptionDeskSprite() : base.GoingToRoom.Definition._icon);
			}
			return result;
		}

		private Sprite GoingToReceptionDeskSprite()
		{
			if (GetComponent<CharacterCheckInComponent>() != null)
			{
				RoomDefinition definitionFromType = RoomAlgorithms.GetDefinitionFromType(base.Level, RoomDefinition.Type.Reception);
				if (definitionFromType != null)
				{
					return definitionFromType._icon;
				}
			}
			return null;
		}

		public override bool CanSatisfyNeeds()
		{
			if (CurrentMode == Mode.Dead || CurrentMode == Mode.RageQuit)
			{
				return false;
			}
			if (base.QueuingAtRoom != null && base.QueuingAtRoom.IsStaffed() && base.QueuingAtRoom.IsFrontOfQueue(this))
			{
				return false;
			}
			if (base.RoomUsing == null || !base.RoomUsing.Definition.AllowNeedsSatisfaction())
			{
				return false;
			}
			if (IsAEPatient && !_hasArrivedAndDisembarked)
			{
				return false;
			}
			return base.CanSatisfyNeeds();
		}

		public override StatusIcon.Type GetStatusIcon()
		{
			if (CurrentMode == Mode.Dead)
			{
				return StatusIcon.Type.Dying;
			}
			if (CurrentMode == Mode.SentHome && !IsSendHomeAnachronistic())
			{
				return StatusIcon.Type.SentHome;
			}
			float num = ((Health != null) ? Health.Value() : 100f);
			float num2 = ((base.Happiness != null) ? base.Happiness.Value() : 100f);
			if (num2 < GameAlgorithms.Config.PatientLowHappiness && num < GameAlgorithms.Config.PatientLowHealth)
			{
				if (!(num2 < num))
				{
					return StatusIcon.Type.HealthLow;
				}
				return StatusIcon.Type.Unhappy;
			}
			if (num2 < GameAlgorithms.Config.PatientLowHappiness)
			{
				return StatusIcon.Type.Unhappy;
			}
			if (num < GameAlgorithms.Config.PatientLowHealth)
			{
				return StatusIcon.Type.HealthLow;
			}
			return TreatmentOutcome switch
			{
				Treatment.Outcome.Cured => StatusIcon.Type.Cured, 
				Treatment.Outcome.Ineffective => StatusIcon.Type.TreatmentIneffective, 
				Treatment.Outcome.Death => StatusIcon.Type.Dying, 
				_ => base.GetStatusIcon(), 
			};
		}

		protected override string GetInteractionPostfix()
		{
			string text = string.Empty;
			if (Illness != null && !string.IsNullOrEmpty(Illness._animGraphPostfixOverride))
			{
				text += Illness._animGraphPostfixOverride;
			}
			return text + base.GetInteractionPostfix();
		}

		public override bool CanPlayReactions()
		{
			if (CurrentMode == Mode.Normal)
			{
				return base.CanPlayReactions();
			}
			return false;
		}

		protected override bool CanUpdateAttribute(CharacterAttributes.Type type)
		{
			if (type == CharacterAttributes.Type.Health)
			{
				return (CurrentMode != Mode.SentHome && CurrentMode != Mode.LeavingHospital) || !IsSendHomeAnachronistic() || TreatmentOutcome != Treatment.Outcome.Cured;
			}
			return true;
		}

		protected override void UpdateAttributes(float deltaTime)
		{
			if (!_attributes.Enabled)
			{
				return;
			}
			base.UpdateAttributes(deltaTime);
			if (!CanUpdateAttribute(CharacterAttributes.Type.Health))
			{
				return;
			}
			AttributeFloat attribute = _attributes.GetAttribute(CharacterAttributes.Type.Hygiene);
			if (attribute != null && Health != null)
			{
				float num = attribute.Value();
				if (num < Definition.HygieneHealthModificationThreshold)
				{
					float num2 = (num - Definition.HygieneHealthModificationThreshold) * Definition.HygieneHealthModificationValue;
					Health.Modify(num2 * deltaTime, GetAttributeMultiplier(CharacterAttributes.Type.Health));
				}
			}
		}

		public bool IsLeavingHospital()
		{
			if (CurrentMode != Mode.LeavingHospital && CurrentMode != Mode.SentHome && CurrentMode != Mode.RageQuit)
			{
				return CurrentMode == Mode.Dead;
			}
			return true;
		}

		private void SetCurrentMode(Mode mode)
		{
			CurrentMode = mode;
			if (CurrentMode == Mode.Dead)
			{
				base.Visual.EyeBlinkingEnabled = false;
			}
		}

		public bool IsThinkingAboutGoingHome()
		{
			return IsModeChangeActive<SendHomeModeChange>();
		}

		public bool IsThinkingAboutRageQuitting()
		{
			return IsModeChangeActive<RageQuitModeChange>();
		}

		public bool IsThinkingAboutDying()
		{
			return IsModeChangeActive<DeathModeChange>();
		}

		public void ReceiveDiagnosis(Room room, Staff doctor, float diagnosisCertaintyIncrement)
		{
			float diagnosisCertainty = DiagnosisCertainty;
			_roomsDiagnosedIn.AddUnique(room.Definition._type);
			ModifyDiagnosisCertainty(diagnosisCertaintyIncrement);
			base.Level.CharacterEvents.OnPatientReceivedDiagnosis.InvokeSafe(this, doctor, room, DiagnosisCertainty - diagnosisCertainty);
		}

		public override void FixupMissingBehaviour()
		{
			base.FixupMissingBehaviour();
			if (base.RoomCalledInto != null)
			{
				base.CalledIntoRoom = false;
				base.RoomCalledInto.CharacterEntering = null;
			}
			switch (CurrentMode)
			{
			case Mode.Normal:
			{
				if (base.GoingToRoom != null)
				{
					GotoRoom(base.GoingToRoom, base.ReasonUsingRoom, false);
					break;
				}
				WaitForRoomToBeBuiltComponent component = GetComponent<WaitForRoomToBeBuiltComponent>();
				if (component != null && _waitingForRooms != null)
				{
					WaitForRoomToBeBuilt(_waitingForRooms, ReasonWaitingForRoom, component.Time);
				}
				else
				{
					Idle();
				}
				break;
			}
			case Mode.Dead:
				CurrentMode = Mode.Normal;
				Death();
				break;
			case Mode.RageQuit:
				CurrentMode = Mode.Normal;
				RageQuit();
				break;
			case Mode.LeavingHospital:
				CurrentMode = Mode.Normal;
				LeaveHospital(base.ReasonForLeaving);
				break;
			case Mode.SentHome:
				CurrentMode = Mode.Normal;
				SendHome();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public bool CanBeCalledIntoRoom()
		{
			if (base.RoomUsing == null || !base.RoomUsing.Definition.IsHospitalOrBay)
			{
				return false;
			}
			if (!base.InteractionInterruptable)
			{
				return false;
			}
			if (IsThinkingAboutGoingHome())
			{
				return false;
			}
			return true;
		}

		public override RoomUseType GetUseRoomType()
		{
			if (WaitingForRoom != RoomDefinition.Type.Invalid)
			{
				if (ReasonWaitingForRoom == ReasonUseRoom.Diagnosis)
				{
					return RoomUseType.Diagnosis;
				}
				if (ReasonWaitingForRoom == ReasonUseRoom.Treatment)
				{
					return RoomUseType.Treatment;
				}
			}
			if (base.ReasonUsingRoom == ReasonUseRoom.Diagnosis)
			{
				return RoomUseType.Diagnosis;
			}
			if (base.ReasonUsingRoom == ReasonUseRoom.Treatment)
			{
				return RoomUseType.Treatment;
			}
			return RoomUseType.Any;
		}

		public override void OnCharacterAttributeModified(CharacterAttributes.Type modifierType)
		{
			base.Level.CharacterEvents.OnPatientAttributeModified.InvokeSafe(this, modifierType);
		}

		public override void OnCharacterUsedItem(RoomItem item)
		{
			base.Level.CharacterEvents.OnPatientUsedItem.InvokeSafe(this, item);
		}

		public bool IsSendHomeAnachronistic()
		{
			if (GetComponent<AnachronisticTreatmentComponent>() == null)
			{
				return false;
			}
			return base.Level.CharacterManager.GetAnachronisticManager()?.Config._hasTimeTunnel ?? false;
		}
	}
}
