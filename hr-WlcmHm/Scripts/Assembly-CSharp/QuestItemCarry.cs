using UnityEngine;

public class QuestItemCarry : QuestItemBase
{
	private new void Start()
	{
		base.Start();
	}

	private void Update()
	{
	}

	public override void Interact()
	{
		if (playerController.CanPickUpItem())
		{
			if (playerController.HasFreeSpot())
			{
				playerController.StartCarryingItem(base.gameObject);
				PlayInteractSound();
			}
			else
			{
				MonoBehaviour.print("Player can only carry 2 items at a time!");
			}
		}
	}

	public override void Activate()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
	}

	public override void Deactivate()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
}
