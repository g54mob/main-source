using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class PatientOrStaffAction : Action
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Staff")]
		private SharedStaffRef _staff;

		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Patient")]
		private SharedPatientRef _patient;

		protected Staff Staff
		{
			get
			{
				if (!_staff.IsValid())
				{
					return null;
				}
				return _staff.Get;
			}
		}

		protected Patient Patient
		{
			get
			{
				if (!_patient.IsValid())
				{
					return null;
				}
				return _patient.Get;
			}
		}
	}
}
