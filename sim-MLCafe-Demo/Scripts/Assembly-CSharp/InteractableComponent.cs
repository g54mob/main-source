using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteraction
{
	[SerializeField]
	public bool needsItemToBeActive;

	[SerializeField]
	public Item activeItem;

	[SerializeField]
	private float interactionRadius = 3f;

	public UnityEvent<CharacterControllerComponent> OnPlayerActionEvent = new UnityEvent<CharacterControllerComponent>();

	public UnityEvent<CharacterControllerComponent> OnPlayerInteractionEvent = new UnityEvent<CharacterControllerComponent>();

	public UnityEvent<CharacterControllerComponent> OnPlayerHoldInteractionEvent = new UnityEvent<CharacterControllerComponent>();

	public UnityEvent<CharacterControllerComponent> OnPlayerHoldInteractionStoppedEvent = new UnityEvent<CharacterControllerComponent>();

	public UnityEvent<Transform> OnEntityExitEvent = new UnityEvent<Transform>();

	public UnityEvent<CharacterControllerComponent> OnPlayerExitEvent = new UnityEvent<CharacterControllerComponent>();

	private bool playerInteractionRunning;

	private Vector3 playerPosition;

	private bool inRange;

	public bool InRange(Vector3 position)
	{
		return Vector3.Distance(position, base.transform.position) <= interactionRadius;
	}

	public bool IsInteractable()
	{
		if (!needsItemToBeActive)
		{
			return true;
		}
		if (GlobalReferences.GetCharacterController().socket.IsHoldingItem())
		{
			return GlobalReferences.GetCharacterController().socket.GetItemComponent().item.id == activeItem.id;
		}
		return false;
	}

	void IInteraction.OnPlayerAction(CharacterControllerComponent character)
	{
		if (InRange(character.transform.position))
		{
			OnPlayerActionEvent.Invoke(character);
			playerPosition = character.transform.position;
			playerInteractionRunning = true;
		}
	}

	void IInteraction.OnPlayerInteraction(CharacterControllerComponent character)
	{
		if (InRange(character.transform.position))
		{
			OnPlayerInteractionEvent.Invoke(character);
			playerPosition = character.transform.position;
			playerInteractionRunning = true;
		}
	}

	void IInteraction.OnPlayerHoldInteraction(CharacterControllerComponent character)
	{
		if (InRange(character.transform.position))
		{
			OnPlayerHoldInteractionEvent.Invoke(character);
			playerPosition = character.transform.position;
			playerInteractionRunning = true;
		}
	}

	void IInteraction.OnPlayerHoldInteractionStopped(CharacterControllerComponent character)
	{
		if (InRange(character.transform.position))
		{
			OnPlayerHoldInteractionStoppedEvent.Invoke(character);
			playerPosition = character.transform.position;
			playerInteractionRunning = false;
		}
	}
}
