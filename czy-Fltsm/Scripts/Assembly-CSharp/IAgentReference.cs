using UnityEngine.Events;

public interface IAgentReference
{
	Agent AgentReference { get; }

	UnityEvent OnAgentUpdated { get; }
}
