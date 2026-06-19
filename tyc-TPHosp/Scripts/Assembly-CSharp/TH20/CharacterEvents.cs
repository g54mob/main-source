#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using TH20.EventStaffHire;
using TH20.EventStaffHired;
using UnityEngine;

namespace TH20
{
	public class CharacterEvents : MustCallDestroy, IGameEventsBase, TH20.EventStaffHire.Interface, IGameEventCallback, TH20.EventStaffHired.Interface
	{
		public TH20.EventStaffHire.Action OnStaffHire = new TH20.EventStaffHire.Action();

		public TH20.EventStaffHired.Action OnStaffHired = new TH20.EventStaffHired.Action();

		public Action<bool> OnStaffCancelPickup;

		public Action<Staff> OnStaffSpawned;

		public Action<Staff> OnStaffDestroyed;

		public Action<Staff, JobApplicant> OnStaffPickup;

		public Action<Staff> OnStaffIdle;

		public Action<Staff> OnStaffTakeBreak;

		public Action<Staff> OnStaffThreatenToLeave;

		public Action<Staff> OnStaffStopThreateningToLeave;

		public Action<Staff> OnStaffFired;

		public Action<Staff> OnStaffResigned;

		public Action<Staff, double> OnStaffReachedMaxXP;

		public Action<Staff> OnStaffReadyForPromotion;

		public Action<Staff, int> OnStaffPromote;

		public Action<Staff> OnStaffPromoted;

		public Action<Staff, int> OnStaffSalaryChanged;

		public Action<Staff, RoomLogicTrainingRoom> OnStaffStartTeaching;

		public Action<Staff, RoomLogicTrainingRoom> OnStaffStartLearning;

		public Action<Staff, Room> OnStaffReadyToStartTraining;

		public Action<Staff> OnStaffEndedTraining;

		public Action<QualificationDefinition> OnTrainingCourseFinished;

		public Action<Staff, QualificationDefinition, Staff> OnStaffQualificationComplete;

		public Action<Staff, Room> OnRequestStaffDrop;

		public Action<Staff, Room, bool> OnStaffDrop;

		public Action<Room, Staff, Job, bool> OnStaffAssignedJob;

		public Action<Staff, Job, bool> OnStaffCompletedJob;

		public Action<Staff, Character> OnStaffServedCustomer;

		public Action<Staff, Character> OnStaffCheckCharacterIn;

		public Action<Staff, CharacterAttributes.Type> OnStaffAttributeModified;

		public Action<Staff, RoomItem> OnStaffUsedItem;

		public Action<Character> OnGhostSpawned;

		public Action<Character> OnGhostDestroyed;

		public Action<Character, Staff> OnGhostCaptured;

		public Action<Character> OnCharacterRenamed;

		public Action<Patient> OnPatientSpawned;

		public Action<Patient> OnPatientDestroyed;

		public Action<Patient> OnPatientRageQuit;

		public Action<Patient> OnPatientSendHomeRequested;

		public Action<Patient> OnPatientSentHome;

		public Action<Patient> OnPatientLeftHospital;

		public Action<Patient> OnPatientDied;

		public Action<Patient> OnPatientDiagnosisExhausted;

		public Action<Patient> OnPatientTimeTunnel;

		public Action<Patient> OnAlienExposed;

		public Action<Patient, List<Staff>> OnFatalTreatment;

		public Action<Patient, List<Staff>> OnIneffectiveTreatment;

		public Action<Patient, List<Staff>> OnPatientCured;

		public Action<Patient, Staff, Room, float> OnPatientReceivedDiagnosis;

		public Action<Patient, Staff, Room> OnPatientReceivedTreatment;

		public Action<Patient, CharacterAttributes.Type> OnPatientAttributeModified;

		public Action<Patient, RoomItem> OnPatientUsedItem;

		public Action<List<Patient>, string> OnPatientsCollectedByPlayer;

		public Action<int> OnPatientsCollected;

		public Action<bool, string> OnPatientDiedAtScene;

		public Action<Visitor> OnVisitorSpawned;

		public Action<Visitor> OnVisitorLeftHospital;

		public Action<Visitor> OnVisitorDestroyed;

		public Action<IllnessDefinition> OnAddIllness;

		public Action<IllnessDefinition> OnRemoveIllness;

		public Action<Patient, IllnessDefinition> OnIllnessDiagnosed;

		public Action<QualificationDefinition, int> OnAddQualification;

		public Action<QualificationDefinition> OnRemoveQualification;

		public Action<Character, Room> OnPlanToEnterRoom;

		public Action<Character, Room> OnPlanToExitRoom;

		public Action<Character, Room> OnVisitRoom;

		public Action<Character, Room, double> OnLeaveRoom;

		public Action<Character> OnDestroyCharacter;

		public Action<Character> OnCharacterDestroyed;

		public Action<Character> OnCharacterLeftHospital;

		public Action<Character, CharacterAttributes.Type> OnCharacterUrgentNeed;

		public Action<Character, Vector3> OnCharacterNavFailure;

		public Action<Character, RoomItem> OnInteractionNavFailure;

		public System.Action OnCharacterVaccinated;

		private Level _level;

		public void Initialise(Level level)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			OnStaffHire.Add(this);
			OnStaffHired.Add(this);
			RegisterNormalEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			GameEventsRegistry.RegisterLevelEvent(this);
			RegisterNormalEvents();
		}

		private void RegisterNormalEvents()
		{
			OnStaffFired = (Action<Staff>)Delegate.Combine(OnStaffFired, new Action<Staff>(StaffFired));
			OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Combine(OnStaffPickup, new Action<Staff, JobApplicant>(StaffPickup));
			OnStaffPromote = (Action<Staff, int>)Delegate.Combine(OnStaffPromote, new Action<Staff, int>(StaffPromote));
			OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(StaffQualificationComplete));
			OnPatientDied = (Action<Patient>)Delegate.Combine(OnPatientDied, new Action<Patient>(PatientDied));
			OnDestroyCharacter = (Action<Character>)Delegate.Combine(OnDestroyCharacter, new Action<Character>(DestroyCharacter));
			OnCharacterNavFailure = (Action<Character, Vector3>)Delegate.Combine(OnCharacterNavFailure, new Action<Character, Vector3>(CharacterNavFailure));
			OnInteractionNavFailure = (Action<Character, RoomItem>)Delegate.Combine(OnInteractionNavFailure, new Action<Character, RoomItem>(InteractionNavFailure));
			OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(OnPatientTimeTunnel, new Action<Patient>(PatientTimeTunnel));
		}

		public override void Destroy()
		{
			OnStaffHire.Remove(this);
			OnStaffHired.Remove(this);
			OnStaffFired = (Action<Staff>)Delegate.Remove(OnStaffFired, new Action<Staff>(StaffFired));
			OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Remove(OnStaffPickup, new Action<Staff, JobApplicant>(StaffPickup));
			OnStaffPromote = (Action<Staff, int>)Delegate.Remove(OnStaffPromote, new Action<Staff, int>(StaffPromote));
			OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(StaffQualificationComplete));
			OnPatientDied = (Action<Patient>)Delegate.Remove(OnPatientDied, new Action<Patient>(PatientDied));
			OnDestroyCharacter = (Action<Character>)Delegate.Remove(OnDestroyCharacter, new Action<Character>(DestroyCharacter));
			OnCharacterNavFailure = (Action<Character, Vector3>)Delegate.Remove(OnCharacterNavFailure, new Action<Character, Vector3>(CharacterNavFailure));
			OnInteractionNavFailure = (Action<Character, RoomItem>)Delegate.Remove(OnInteractionNavFailure, new Action<Character, RoomItem>(InteractionNavFailure));
			OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(OnPatientTimeTunnel, new Action<Patient>(PatientTimeTunnel));
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnStaffCancelPickup.VerifyIsNull();
			OnStaffSpawned.VerifyIsNull();
			OnStaffDestroyed.VerifyIsNull();
			OnStaffPickup.VerifyIsNull();
			OnStaffIdle.VerifyIsNull();
			OnStaffTakeBreak.VerifyIsNull();
			OnStaffFired.VerifyIsNull();
			OnStaffResigned.VerifyIsNull();
			OnStaffThreatenToLeave.VerifyIsNull();
			OnStaffStopThreateningToLeave.VerifyIsNull();
			OnStaffPromote.VerifyIsNull();
			OnStaffPromoted.VerifyIsNull();
			OnStaffSalaryChanged.VerifyIsNull();
			OnStaffStartTeaching.VerifyIsNull();
			OnStaffStartLearning.VerifyIsNull();
			OnStaffReadyToStartTraining.VerifyIsNull();
			OnStaffEndedTraining.VerifyIsNull();
			OnTrainingCourseFinished.VerifyIsNull();
			OnStaffQualificationComplete.VerifyIsNull();
			OnStaffReachedMaxXP.VerifyIsNull();
			OnStaffReadyForPromotion.VerifyIsNull();
			OnStaffServedCustomer.VerifyIsNull();
			OnStaffCheckCharacterIn.VerifyIsNull();
			OnRequestStaffDrop.VerifyIsNull();
			OnStaffDrop.VerifyIsNull();
			OnStaffAssignedJob.VerifyIsNull();
			OnStaffCompletedJob.VerifyIsNull();
			OnGhostSpawned.VerifyIsNull();
			OnGhostDestroyed.VerifyIsNull();
			OnCharacterRenamed.VerifyIsNull();
			OnGhostCaptured.VerifyIsNull();
			OnPatientSpawned.VerifyIsNull();
			OnPatientDestroyed.VerifyIsNull();
			OnPatientRageQuit.VerifyIsNull();
			OnPatientSendHomeRequested.VerifyIsNull();
			OnPatientSentHome.VerifyIsNull();
			OnPatientLeftHospital.VerifyIsNull();
			OnPatientDied.VerifyIsNull();
			OnPatientDiagnosisExhausted.VerifyIsNull();
			OnFatalTreatment.VerifyIsNull();
			OnIneffectiveTreatment.VerifyIsNull();
			OnPatientCured.VerifyIsNull();
			OnPatientReceivedDiagnosis.VerifyIsNull();
			OnPatientReceivedTreatment.VerifyIsNull();
			OnIllnessDiagnosed.VerifyIsNull();
			OnVisitorSpawned.VerifyIsNull();
			OnVisitorLeftHospital.VerifyIsNull();
			OnVisitorDestroyed.VerifyIsNull();
			OnAddIllness.VerifyIsNull();
			OnRemoveIllness.VerifyIsNull();
			OnAddQualification.VerifyIsNull();
			OnRemoveQualification.VerifyIsNull();
			OnPlanToEnterRoom.VerifyIsNull();
			OnPlanToExitRoom.VerifyIsNull();
			OnVisitRoom.VerifyIsNull();
			OnLeaveRoom.VerifyIsNull();
			OnCharacterNavFailure.VerifyIsNull();
			OnInteractionNavFailure.VerifyIsNull();
			OnCharacterVaccinated.VerifyIsNull();
			OnDestroyCharacter.VerifyIsNull();
			OnCharacterDestroyed.VerifyIsNull();
			OnCharacterLeftHospital.VerifyIsNull();
			OnCharacterUrgentNeed.VerifyIsNull();
			OnStaffAttributeModified.VerifyIsNull();
			OnPatientAttributeModified.VerifyIsNull();
			OnPatientUsedItem.VerifyIsNull();
			OnStaffUsedItem.VerifyIsNull();
		}

		public void OnStaffHireEvent(JobApplicant applicant)
		{
			Staff staff = _level.CharacterManager.SpawnStaff(applicant, Vector3.zero, navDisabled: true);
			OnStaffPickup.InvokeSafe(staff, applicant);
			staff.OnNewHireStaffPickup();
		}

		private void StaffPickup(Staff staff, JobApplicant applicant)
		{
			_level.CharacterEvents.OnStaffCancelPickup.InvokeSafe(param: false);
			_level.CursorManager.PushMode(new CursorStaffHeld(_level.CursorManager, _level, staff, applicant));
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			staff.OnNewHireStaffHired();
			_level.JobApplicantManager.GetJobApplicantPool(staff.Definition._type).RemoveApplicant(applicant);
		}

		private void StaffFired(Staff staff)
		{
			staff.Fire();
		}

		private void StaffPromote(Staff staff, int newSalary)
		{
			staff.Promote(newSalary);
		}

		private void StaffQualificationComplete(Staff staff, QualificationDefinition qualification, Staff trainer)
		{
			if (staff.HasMaxXP && staff.IsFullyTrained)
			{
				staff.ReadyForPromotion();
			}
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.StaffTrainingCompleted);
		}

		private void PatientDied(Patient patient)
		{
			if (patient.RoomUsing != null && patient.Illness._chanceOfGhostOnDeath >= RandomUtils.GlobalRandomInstance.NextFloat(0f, 100f))
			{
				_level.CharacterManager.SpawnGhostFromCharacter(patient);
			}
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.PatientDied);
		}

		private void DestroyCharacter(Character character)
		{
			_level.CharacterManager.DestroyCharacter(character);
			_level.BuildEvents.OnCursorHoverStop.InvokeSafe(character);
		}

		private void PatientTimeTunnel(Patient patient)
		{
			_level.CharacterManager.DestroyCharacter(patient);
			_level.BuildEvents.OnCursorHoverStop.InvokeSafe(patient);
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.TimeTunnelPatient);
		}

		private void CharacterNavFailure(Character character, Vector3 navTarget)
		{
			DebugDrawUtils.Marker(navTarget, Color.red, 20f);
			DebugDrawUtils.Marker(character.Position, Color.green, 20f);
			DebugDrawUtils.Line(character.Position + Vector3.up, navTarget + Vector3.up, Color.red, 20f);
			character.GetOrAddComponent<EntityNavFailedComponent>().Init();
		}

		private void InteractionNavFailure(Character character, RoomItem roomItem)
		{
			if (!roomItem.HasBeenDestroyed())
			{
				CharacterNavFailure(character, roomItem.WorldPosition);
				roomItem.GetOrAddComponent<EntityNavFailedComponent>().Init();
				Logging.Warning(LogChannels.AI, "{0} failed to reach {1}", character, roomItem);
			}
		}

		public void TriggerGlobalCharacterAction(Character instigator, Room room, Vector3 position, CharacterActionDefinition action)
		{
			if (action == null)
			{
				return;
			}
			DebugDrawUtils.Circle(position, action.RadiusOfEffect, Color.red, 4f);
			if (instigator != null)
			{
				action.ApplyAttributes(instigator);
			}
			float num = MathUtils.Square(action.RadiusOfEffect);
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				if (position.SquareDistance2D(allCharacter.Position) < num && allCharacter != instigator && (room == null || allCharacter.RoomUsing == room))
				{
					action.TriggerReaction(allCharacter, instigator);
				}
			}
		}
	}
}
