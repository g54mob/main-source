using CTS.BBT.AI;

namespace CTS.BBT
{
	public interface IBodyDisposalMachine : IManageableFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		BodyDisposalCredibility MachineCredibility { get; }

		bool CanBeUsedToDisposeBody(Agent agent, Customer customer);

		bool CanBeUsedToDisposeBody(Agent agent, DeadBodyData deadBodyData);

		bool CanBeUsedToDisposeBody(DeadBodyData deadBodyData);

		AgentAction GetAction();
	}
}
