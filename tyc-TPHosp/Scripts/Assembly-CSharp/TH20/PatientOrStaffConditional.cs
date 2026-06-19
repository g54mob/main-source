#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class PatientOrStaffConditional : Conditional
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Staff")]
		private SharedStaffRef _staff;

		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Patient")]
		private SharedPatientRef _patient;

		protected Character Character
		{
			get
			{
				if (_staff.IsValid())
				{
					return _staff.Get;
				}
				if (_patient.IsValid())
				{
					return _patient.Get;
				}
				Logging.Error(LogChannels.AI, "Patient and staff variables are invalid in " + base.Owner);
				return null;
			}
		}
	}
}
