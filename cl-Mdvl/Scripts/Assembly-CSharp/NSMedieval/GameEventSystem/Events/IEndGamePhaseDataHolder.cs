using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	public interface IEndGamePhaseDataHolder
	{
		List<HumanoidInstance> NPCs { get; }
	}
}
