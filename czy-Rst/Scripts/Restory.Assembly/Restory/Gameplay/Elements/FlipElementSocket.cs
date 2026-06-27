using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class FlipElementSocket : ElementSocket
	{
		public event Action OnInteract;

		public void ChangeInteractivity(bool isInteractable)
		{
			if ((bool)base.NestedElement && base.NestedElement is FlipElement flipElement)
			{
				flipElement.ChangeInteractivity(isInteractable);
			}
		}

		public void BlockExternalSockets(ICollection<ElementSocket> socketsToBlock)
		{
			foreach (ElementSocket item in socketsToBlock)
			{
				AddExternalBlockedSocket(item);
			}
			NotifyExternalSockets(socketsToBlock);
		}

		public void UnblockExternalSockets(ICollection<ElementSocket> socketsToUnblock)
		{
			foreach (ElementSocket item in socketsToUnblock)
			{
				RemoveExternalBlockedSocket(item);
			}
			NotifyExternalSockets(socketsToUnblock);
		}

		private void NotifyExternalSockets(ICollection<ElementSocket> sockets)
		{
			foreach (ElementSocket socket in sockets)
			{
				NotifyExternalSocket(socket);
			}
		}

		protected override void SetNestedElement(ElementBase element)
		{
			base.SetNestedElement(element);
			if (!(base.NestedElement is FlipElement flipElement))
			{
				Debug.LogError("Not FlipElement component attached to FlipElementSocket");
			}
			else
			{
				flipElement.OnInteract += ResolveFlipElementInteraction;
			}
		}

		protected override void ResolveElementDetached()
		{
			if (!(base.NestedElement is FlipElement flipElement))
			{
				Debug.LogError("Not FlipElement component detached from FlipElementSocket");
			}
			else
			{
				flipElement.ChangeInteractivity(isInteractable: false);
				flipElement.OnInteract -= ResolveFlipElementInteraction;
			}
			base.ResolveElementDetached();
		}

		private void ResolveFlipElementInteraction()
		{
			this.OnInteract?.Invoke();
		}
	}
}
