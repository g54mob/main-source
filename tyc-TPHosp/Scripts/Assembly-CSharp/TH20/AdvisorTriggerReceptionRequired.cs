namespace TH20
{
	public class AdvisorTriggerReceptionRequired : AdvisorTrigger
	{
		public AdvisorTriggerReceptionRequired(AdvisorTriggerReceptionRequiredDefinition definition)
			: base(definition)
		{
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!Level.ReceptionManager.IsReceptionValid(out var _) && Level.CharacterManager.Patients.Count > 0)
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
