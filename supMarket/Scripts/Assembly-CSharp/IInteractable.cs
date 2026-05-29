public interface IInteractable
{
	InteractactableType Type { get; }

	bool ContinousInteraction { get; }

	InteractionType InteractionType { get; }

	bool NeedRepair { get; set; }

	string InstantInteractionHint { get; }

	string HoldingInteractionHint { get; }

	string SecondInteractionHint { get; }

	string RepairInteractionHint { get; }

	bool InstantInteract();

	bool HoldingInteract();

	bool CustomInteract();

	bool RepairInteract(bool isHold, PlayerInstance playerInstance);

	bool RemoteInteract(string userId);
}
