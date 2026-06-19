#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DiagnosisTreatmentComponent : EntityComponent
	{
		private Staff _doctor;

		private Room _room;

		public Staff Doctor => _doctor;

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			RegisterEvents();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			base.Destroy();
		}

		public void Initialise(Room room, Staff doctor)
		{
			_room = room;
			_doctor = doctor;
		}

		private void OnRoomDeleted(Room room)
		{
			if (room == _room)
			{
				Destroy();
			}
		}

		private void OnStaffDestroyed(Staff staff)
		{
			if (staff == _doctor)
			{
				Destroy();
			}
		}

		public void Process()
		{
			Patient owner = GetOwner<Patient>();
			float diagnosisCertainty = owner.DiagnosisCertainty;
			float num = ((owner.Happiness != null) ? owner.Happiness.Value() : 0f);
			bool flag = owner.ReasonUsingRoom == ReasonUseRoom.Diagnosis;
			bool flag2 = owner.ReasonUsingRoom == ReasonUseRoom.Treatment;
			if (flag)
			{
				ProcessDiagnosis(owner);
			}
			else if (flag2)
			{
				ProcessTreatment(owner);
			}
			else
			{
				Logging.Error(LogChannels.AI, "{0} isn't using {1} for diagnosis or treatment but {2}", owner, _room, owner.ReasonUsingRoom);
			}
			RoomPrestige roomPrestige = GameAlgorithms.CalculateRoomPrestige(_room.FloorPlan);
			if (owner.Happiness != null)
			{
				owner.Happiness.Modify(roomPrestige.Data.PatientHappinessModifier, 1f);
			}
			if (flag)
			{
				float num2 = owner.DiagnosisCertainty - diagnosisCertainty;
				float num3 = ((owner.Happiness != null) ? (owner.Happiness.Value() - num) : 0f);
				string text = LocalisedString.Replace(ScriptLocalization.Notification.SessionResult_CS, new SubPair[2]
				{
					new SubPair("{[DIAGNOSIS]}", StringUtils.FormatPercentageValue(num2 / 100f, prefixPlus: true)),
					new SubPair("{[HAPPINESS]}", StringUtils.FormatPercentageValue(num3 / 100f, prefixPlus: true))
				});
				base.Level.InWorldMessages.ShowMessage(text, owner.Position + Vector3.up, 4f, InWorldMessages.MessageType.Info);
				if (num3 > 0f && owner.IsThinkingAboutRageQuitting())
				{
					owner.CancelModeChange();
					owner.GetAttributes().Enabled = true;
				}
			}
			Destroy();
		}

		private void ProcessTreatment(Patient patient)
		{
			Treatment.Outcome outcome = ((patient.PendingTreatmentOutcome == Treatment.Outcome.Unknown) ? GameAlgorithms.CalculateTreatmentOutcome(patient, _doctor, _room) : patient.PendingTreatmentOutcome);
			TreatmentCalculationBreakdown breakdown = GameAlgorithms.CalculateEstimatedTreatmentOutcome(patient, _doctor, _room, (patient.Interaction != null) ? patient.Interaction.ParentRoomItem : null);
			patient.Treated(_room, outcome, breakdown);
			if (_doctor.ModifiersComponent != null)
			{
				_doctor.ModifiersComponent.ApplyInteractWithOtherModifiers(patient);
			}
			_doctor.Definition.Common.Instance.ApplyTreatmentStatusEffect(_doctor, outcome);
			patient.Level.CharacterEvents.OnPatientReceivedTreatment.InvokeSafe(patient, _doctor, _room);
			if (_room != null)
			{
				_room.OnUnitProcessed();
			}
		}

		private void ProcessDiagnosis(Patient patient)
		{
			Level level = patient.Level;
			ResearchManager researchManager = level.ResearchManager;
			if (_doctor.ModifiersComponent != null)
			{
				_doctor.ModifiersComponent.ApplyInteractWithOtherModifiers(patient);
			}
			float certainty = GameAlgorithms.GetDiagnosisCertainty(patient, _room, _doctor, researchManager).Certainty;
			patient.ReceiveDiagnosis(_room, _doctor, certainty);
			_room.OnUnitProcessed();
			bool num = (base.Level.HospitalPolicy.AutoSendForTreatment && patient.FullyDiagnosed()) | (patient.FullyDiagnosed() && patient.IsAEPatient);
			bool flag = _room.Definition._type == RoomDefinition.Type.GPOffice || patient.IsAEPatient;
			if (num)
			{
				patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, researchManager), immediately: true);
			}
			else if (flag)
			{
				if (patient.FullyDiagnosed())
				{
					patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, researchManager), immediately: true);
					return;
				}
				Room diagnosisRoom = GetDiagnosisRoom(patient, _doctor);
				if (diagnosisRoom == null)
				{
					OnPatientExhaustedDiagnosisRooms(patient);
				}
				patient.SendToDiagnosisRoom(diagnosisRoom);
			}
			else
			{
				Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(level.WorldState, RoomDefinition.Type.GPOffice, RoomUseType.Any, patient);
				if (bestRoomOfType != null)
				{
					patient.GotoRoom(bestRoomOfType, ReasonUseRoom.Diagnosis, false);
				}
				else
				{
					patient.WaitForRoomToBeBuilt(RoomDefinition.Type.GPOffice, ReasonUseRoom.Diagnosis, GameAlgorithms.Config.PatientWaitLongTime);
				}
			}
		}

		public static Room GetDiagnosisRoom(Patient patient, int furtherDiagnosisChoiceCount)
		{
			Level level = patient.Level;
			List<Room> list = new List<Room>();
			RoomDefinition.Type[] diagnosisRooms = RoomDefinition.DiagnosisRooms;
			foreach (RoomDefinition.Type type in diagnosisRooms)
			{
				Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(level.WorldState, type, RoomUseType.Diagnosis, patient);
				if (bestRoomOfType != null && !patient.HasBeenDiagnosedInRoom(bestRoomOfType.Definition._type))
				{
					list.Add(bestRoomOfType);
				}
			}
			return GameAlgorithms.GetNextDiagnosisRoom(list, patient, level.ResearchManager, furtherDiagnosisChoiceCount);
		}

		public static Room GetDiagnosisRoom(Patient patient, Staff doctor)
		{
			Level level = patient.Level;
			List<Room> list = new List<Room>();
			RoomDefinition.Type[] diagnosisRooms = RoomDefinition.DiagnosisRooms;
			foreach (RoomDefinition.Type type in diagnosisRooms)
			{
				Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(level.WorldState, type, RoomUseType.Diagnosis, patient);
				if (bestRoomOfType != null && !patient.HasBeenDiagnosedInRoom(bestRoomOfType.Definition._type))
				{
					list.Add(bestRoomOfType);
				}
			}
			return GameAlgorithms.GetNextDiagnosisRoom(list, patient, doctor, level.ResearchManager);
		}

		public static void OnPatientExhaustedDiagnosisRooms(Patient patient)
		{
			Level level = patient.Level;
			patient.ExhaustedDiagnosisRooms = true;
			level.CharacterEvents.OnPatientDiagnosisExhausted.InvokeSafe(patient);
		}
	}
}
