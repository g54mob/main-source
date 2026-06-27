using System;

namespace Restory.Gameplay.Elements
{
	public class FlipElement : InsertableElement, ISwitchableElement
	{
		private bool isInteractable;

		public bool IsInteractable => isInteractable;

		public event Action OnInteract;

		public void ChangeInteractivity(bool isInteractable)
		{
			this.isInteractable = isInteractable;
		}

		public void InitSwitchInteraction()
		{
			if (isInteractable)
			{
				this.OnInteract?.Invoke();
			}
		}
	}
}
