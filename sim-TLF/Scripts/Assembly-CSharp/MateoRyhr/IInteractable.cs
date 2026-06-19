using UnityEngine;

namespace MateoRyhr
{
	public interface IInteractable
	{
		InteractionType InteractionType { get; }

		void Interact(GameObject interactor);
	}
}
