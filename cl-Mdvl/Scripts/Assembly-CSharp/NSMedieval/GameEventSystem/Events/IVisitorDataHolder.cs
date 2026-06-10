using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	public interface IVisitorDataHolder
	{
		HumanoidInstance Visitor { get; }
	}
}
