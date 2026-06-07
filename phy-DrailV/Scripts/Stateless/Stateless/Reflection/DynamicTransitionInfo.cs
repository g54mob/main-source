using System.Collections.Generic;

namespace Stateless.Reflection
{
	public class DynamicTransitionInfo : TransitionInfo
	{
		public InvocationInfo DestinationStateSelectorDescription { get; private set; }

		public DynamicStateInfos PossibleDestinationStates { get; private set; }

		public static DynamicTransitionInfo Create<TTrigger>(TTrigger trigger, IEnumerable<InvocationInfo> guards, InvocationInfo selector, DynamicStateInfos possibleStates)
		{
			return new DynamicTransitionInfo
			{
				Trigger = new TriggerInfo(trigger),
				GuardConditionsMethodDescriptions = (guards ?? new List<InvocationInfo>()),
				DestinationStateSelectorDescription = selector,
				PossibleDestinationStates = possibleStates
			};
		}

		private DynamicTransitionInfo()
		{
		}
	}
}
