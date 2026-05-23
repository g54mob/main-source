using UnityEngine;

public class Mower : Item
{
	private bool isTurnedOn;

	[SerializeField]
	private MowerBody body;

	private void Start()
	{
		FirstPersonController.S.OnItemOutHand += S_OnItemOutHand;
	}

	private void OnDestroy()
	{
		FirstPersonController.S.OnItemOutHand -= S_OnItemOutHand;
	}

	private void S_OnItemOutHand()
	{
		body.isUsing = false;
	}

	public override void Interact()
	{
		if (GameManager.S.player.itemOnHand == null)
		{
			body.isUsing = true;
			GameManager.S.player.GrabTool(base.gameObject);
		}
	}
}
