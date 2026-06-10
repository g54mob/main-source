using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	public interface IWorkerPhaseDataHolder
	{
		HumanoidInstance HumanoidToAdd { get; set; }
	}
}
