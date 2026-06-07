using UnityEngine;

namespace MalbersAnimations
{
	public interface IInteractable
	{
		bool SingleInteraction { get; }

		bool Active { get; set; }

		bool Auto { get; set; }

		bool Focused { get; set; }

		IInteractor CurrentInteractor { get; set; }

		int Index { get; }

		GameObject Owner { get; }

		void Restart();

		bool Interact(IInteractor interactor);

		bool Interact(int InteracterID, GameObject interactor);

		void Interact();
	}
}
