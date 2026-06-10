using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	public interface IVisitorEvent
	{
		bool Contains(HumanoidInstance humanoidInstance);
	}
}
