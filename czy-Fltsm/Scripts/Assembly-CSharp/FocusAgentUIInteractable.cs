using UnityEngine;

public class FocusAgentUIInteractable : UIInteractable
{
	[SerializeField]
	private AgentPanel _agentPanel;

	public override void Interact()
	{
		base.Interact();
		_agentPanel.LockOnDrifter();
	}
}
