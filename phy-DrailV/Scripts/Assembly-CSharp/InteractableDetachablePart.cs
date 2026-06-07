using UnityEngine;

public class InteractableDetachablePart : MonoBehaviour, IInteractableTag
{
	public InteractableTag InteractableTag => InteractableTag.Detachable;
}
