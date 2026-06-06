using UnityEngine.Events;

public interface IAgentNameable
{
	string Name { get; }

	UnityEvent OnNameUpdatedEvent { get; }

	void SetName(string name);
}
