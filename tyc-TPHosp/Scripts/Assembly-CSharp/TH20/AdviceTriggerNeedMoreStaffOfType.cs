using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerNeedMoreStaffOfType : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Need More Staff")]
		[InspectorTooltip("The staff type we are interested in")]
		[SerializeField]
		private StaffDefinition.Type _staffType;

		[InspectorTooltip("Number of patients in hospital before we start caring about this")]
		[SerializeField]
		private int _numPatientsThreshold = 20;

		[InspectorTooltip("If total percentage of queuing patients in hospital drifts higher than this threshold then trigger a low priority message")]
		[SerializeField]
		private float _percQueuingLowPri = 0.04f;

		[InspectorTooltip("If total percentage of queuing patients in hospital drifts higher than this threshold then trigger a medium priority message")]
		[SerializeField]
		private float _percQueuingMedPri = 0.06f;

		[InspectorTooltip("If total percentage of queuing patients in hospital drifts higher than this threshold then trigger a high priority message")]
		[SerializeField]
		private float _percQueuingHighPri = 0.08f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int count = Level.CharacterManager.Patients.Count;
			if (count < _numPatientsThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			foreach (Job allJob in Level.StaffWorkScheduler.AllJobs)
			{
				if (allJob is JobRoom jobRoom && jobRoom.Available() && jobRoom.Room.QueueLength > 0)
				{
					StaffDefinition.Type type = jobRoom.StaffRequired().Definition._type;
					if (_staffType == type)
					{
						num += jobRoom.Room.QueueLength;
					}
				}
			}
			float num2 = (float)num / (float)count;
			if (num2 < _percQueuingLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 < _percQueuingMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _percQueuingHighPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
