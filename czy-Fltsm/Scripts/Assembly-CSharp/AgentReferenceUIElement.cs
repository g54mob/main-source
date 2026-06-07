using PajamaLlama.Extensions;
using UnityEngine;

public abstract class AgentReferenceUIElement : SceneBehaviour
{
	[SerializeField]
	private AgentReference _agentReference;

	protected Agent _agent;

	protected virtual void OnEnable()
	{
		if ((bool)_agentReference)
		{
			_agentReference.OnAgentUpdated.AddListener(OnAgentUpdated);
			OnAgentUpdated();
		}
		else
		{
			Debug.LogErrorFormat("Agent reference not set on '{0}'", base.transform.HierarchyPathToString());
		}
	}

	protected virtual void OnDisable()
	{
		if ((bool)_agentReference)
		{
			_agentReference.OnAgentUpdated.RemoveListener(OnAgentUpdated);
			if (_agent != null)
			{
				Unsubscribe(_agent);
				_agent = null;
			}
		}
	}

	protected abstract void Subscribe(Agent agent);

	protected abstract void Unsubscribe(Agent agent);

	private void OnAgentUpdated()
	{
		if (_agentReference.Agent != null && _agentReference.Agent.Initialized)
		{
			UpdateAgent(_agentReference.Agent);
		}
	}

	protected virtual void UpdateAgent(Agent agent)
	{
		if (_agent != null)
		{
			Unsubscribe(_agent);
		}
		_agent = agent;
		Subscribe(_agent);
	}
}
