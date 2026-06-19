using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerNoSeats : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerNoSeatsDefinition _definition;

		public AdvisorTriggerNoSeats(AdvisorTriggerNoSeatsDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.Patients.Count < _definition.NumPatientsThreshold)
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
			if (num < _definition.NumPatientsInQueuesThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			float num3 = (float)num2 / (float)num;
			if (num3 < _definition.PercentageForceToStandLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num3 <= _definition.PercentageForceToStandMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 <= _definition.PercentageForceToStandHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
