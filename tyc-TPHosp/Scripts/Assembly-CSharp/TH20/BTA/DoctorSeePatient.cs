using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Staff")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DoctorSeePatient : Action
	{
		public class SaveState : BaseSaveState
		{
			public float _seePatientStart;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[SerializeField]
		private SharedPatientRef _patient;

		[SerializeField]
		private SharedStaffRef _doctor;

		[SerializeField]
		private SharedRoomRef _room;

		[SerializeField]
		private bool _dischargeImmediately = true;

		private float _seePatientStart;

		public override void OnStart()
		{
			base.OnStart();
			_seePatientStart = GameTime.time;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			if (_patient.IsValid() && _dischargeImmediately)
			{
				_patient.Get.GetComponent<DiagnosisTreatmentComponent>()?.Process();
			}
		}

		public override TaskStatus OnUpdate()
		{
			Room get = _room.Get;
			Patient get2 = _patient.Get;
			if (get2 != null && get != null)
			{
				Staff staff = null;
				if (_doctor.IsValid())
				{
					staff = _doctor.Get;
				}
				else if (get.StaffWorkingInRoom.Count != 0)
				{
					staff = get.StaffWorkingInRoom.RandomItem();
				}
				if (staff == null)
				{
					return TaskStatus.Failure;
				}
				ResearchManager researchManager = get2.Level.ResearchManager;
				if (get2.ReasonUsingRoom == ReasonUseRoom.Diagnosis)
				{
					float diagnosisDuration = GameAlgorithms.GetDiagnosisDuration(get2.Illness, get, staff, researchManager);
					if (_seePatientStart + diagnosisDuration < GameTime.time)
					{
						get2.GetOrAddComponent<DiagnosisTreatmentComponent>().Initialise(get, staff);
						return TaskStatus.Success;
					}
				}
				else
				{
					if (get2.ReasonUsingRoom != ReasonUseRoom.Treatment)
					{
						return TaskStatus.Failure;
					}
					float treatmentDuration = get2.Illness.GetTreatmentDuration(get, researchManager);
					if (_seePatientStart + treatmentDuration < GameTime.time)
					{
						get2.GetOrAddComponent<DiagnosisTreatmentComponent>().Initialise(get, staff);
						return TaskStatus.Success;
					}
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Failure;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_seePatientStart = _seePatientStart
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_seePatientStart = saveState._seePatientStart;
		}
	}
}
