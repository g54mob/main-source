using System.Collections.Generic;

namespace TH20
{
	public class AdviceConfig
	{
		public enum Group
		{
			GenericGroup = 0,
			CashflowGroup = 1,
			ReputationGroup = 2,
			MaintenanceGroup = 3,
			TrainingGroup = 4,
			NeedsGroup = 5,
			EnvironmentGroup = 6
		}

		public Dictionary<Group, AdviceTrigger> AdviceTriggerDictionary;
	}
}
