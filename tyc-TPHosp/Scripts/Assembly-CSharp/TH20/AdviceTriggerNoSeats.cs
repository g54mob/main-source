using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerNoSeats : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("No Seats")]
		[InspectorTooltip("Number of patients before we care about this")]
		[SerializeField]
		private int _numPatientsThreshold = 20;

		[InspectorTooltip("Number of patients in queues before we care about this")]
		[SerializeField]
		private int _numPatientsInQueuesThreshold = 20;

		[InspectorTooltip("Percentage of patients in queue forced to stand to trigger a low priority message")]
		[SerializeField]
		private float _percentageForceToStandLowPri = 0.4f;

		[InspectorTooltip("Percentage of patients in queue forced to stand to trigger a medium priority message")]
		[SerializeField]
		private float _percentageForceToStandMedPri = 0.5f;

		[InspectorTooltip("Percentage of patients in queue forced to stand to trigger a high priority message")]
		[SerializeField]
		private float _percentageForceToStandHiPri = 0.6f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.Patients.Count < _numPatientsThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			int num2 = 0;
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (allRoom.QueueLength <= 0)
				{
					continue;
				}
				num += allRoom.QueueLength;
				foreach (Character item in allRoom.Queue)
				{
					if (item.Interaction == null && item.ReservedInteraction == null)
					{
						num2++;
					}
				}
			}
			if (num < _numPatientsInQueuesThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			float num3 = (float)num2 / (float)num;
			if (num3 < _percentageForceToStandLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num3 <= _percentageForceToStandMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 <= _percentageForceToStandHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
