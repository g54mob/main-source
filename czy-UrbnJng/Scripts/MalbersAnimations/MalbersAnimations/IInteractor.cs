using UnityEngine;

namespace MalbersAnimations
{
	public interface IInteractor
	{
		int ID { get; }

		bool Enabled { get; set; }

		GameObject Owner { get; }

		bool Interact(IInteractable interactable);

		void UnFocus(IInteractable interactable);

		void Focus(IInteractable interactable);

		void Restart();
	}
}
