using UnityEngine;

public class FocusHouseUIInteractable : UIInteractable
{
	[SerializeField]
	private AgentPanel _agentPanel;

	public override void Interact()
	{
		base.Interact();
		_agentPanel.LockOnHouse();
	}
}
