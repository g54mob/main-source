using UnityEngine;

namespace InteractionSystem
{
	public interface IInteractable
	{
		string GetInteractionPrompt();

		bool CanInteract(ulong clientId);

		void Interact(ulong clientId);

		float GetInteractionDistance();

		Transform GetInteractionTransform();

		int GetInteractionPriority();

		void OnInteractionFocus();

		void OnInteractionLoseFocus();

		Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}
	}
}
