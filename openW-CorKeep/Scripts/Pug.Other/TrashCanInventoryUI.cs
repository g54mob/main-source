using UnityEngine;

public class TrashCanInventoryUI : InventoryUI
{
	public Animator animator;

	public ParticleSystem particles;

	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 1;

	public void TrashItemInSlot()
	{
		PlayerController playerController = Manager.main.player;
		if (!(playerController == null))
		{
			animator.SetTrigger(-1923363222);
			AudioManager.Sfx(SfxID.metalImpactSmall, base.transform.position, 0.7f, 0.6f, 0.1f, reuse: true);
			InventoryHandler inventoryHandler = playerController.trashCanHandler.inventoryHandler;
			ObjectDataCD objectData = inventoryHandler.GetObjectData(0);
			if (objectData.objectID != ObjectID.None)
			{
				AudioManager.Sfx(SfxID.woodenDestructable, base.transform.position, 0.9f, 0.9f, 0.1f, reuse: true);
				particles.Play(withChildren: true);
				inventoryHandler.DestroyObject(playerController, 0, objectData.objectID);
			}
		}
	}
}
