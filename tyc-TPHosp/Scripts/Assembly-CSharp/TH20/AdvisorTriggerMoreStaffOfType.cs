using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMoreStaffOfType : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerMoreStaffOfTypeDefinition _definition;

		public AdvisorTriggerMoreStaffOfType(AdvisorTriggerMoreStaffOfTypeDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			int count = Level.CharacterManager.Patients.Count;
			if (count < _definition.NumPatientsThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			foreach (Job allJob in Level.StaffWorkScheduler.AllJobs)
			{
				if (allJob is JobRoom jobRoom && jobRoom.Available() && jobRoom.Room.QueueLength > 0)
				{
					StaffDefinition.Type type = jobRoom.StaffRequired().Definition._type;
					if (_definition.StaffType == type)
					{
						num += jobRoom.Room.QueueLength;
					}
				}
			}
			float num2 = (float)num / (float)count;
			if (num2 < _definition.PercQueuingLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 < _definition.PercQueuingMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _definition.PercQueuingHighPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
