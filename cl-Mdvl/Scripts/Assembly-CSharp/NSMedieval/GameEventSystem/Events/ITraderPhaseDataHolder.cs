using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	public interface ITraderPhaseDataHolder
	{
		HumanoidInstance Trader { get; }

		List<HumanoidInstance> Guards { get; }
	}
}
