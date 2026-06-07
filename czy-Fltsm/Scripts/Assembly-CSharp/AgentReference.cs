using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IAgentReference))]
public class AgentReference : MonoBehaviour
{
	private IAgentReference _ref;

	private IAgentReference _reference
	{
		get
		{
			if (_ref == null)
			{
				_ref = GetComponent<IAgentReference>();
			}
			return _ref;
		}
	}

	public Agent Agent => _reference.AgentReference;

	public UnityEvent OnAgentUpdated => _reference.OnAgentUpdated;
}
