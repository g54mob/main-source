using UnityEngine;

public interface IInteractable
{
	bool IsActive { get; set; }

	Transform InteractionParent { get; set; }

	float CustomInteractionDistance => -1f;

	bool UseSphereCast => true;

	void Interact(PlayerInventory player, Vector3 hitPoint);

	void StopInteract();
}
