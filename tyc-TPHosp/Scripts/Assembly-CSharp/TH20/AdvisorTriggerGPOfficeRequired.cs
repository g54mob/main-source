namespace TH20
{
	public class AdvisorTriggerGPOfficeRequired : AdvisorTrigger
	{
		public AdvisorTriggerGPOfficeRequired(AdvisorTriggerGPOfficeRequiredDefinition definition)
			: base(definition)
		{
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Patient patient in Level.CharacterManager.Patients)
			{
				if (patient.WaitingForRoom == RoomDefinition.Type.GPOffice)
				{
					return Advisor.PriorityLevel.VeryHigh;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
