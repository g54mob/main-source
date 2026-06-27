using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class SerialElementSocket : ElementSocket
	{
		[SerializeField]
		private List<SubordinateElementSocket> subordinateSockets;

		private DragElementRegistrator dragElementRegistrator;

		private bool isSubscribed;

		[Inject]
		private void Construct(DragElementRegistrator dragElementRegistrator)
		{
			this.dragElementRegistrator = dragElementRegistrator;
			if (subordinateSockets.Count == 0)
			{
				Debug.LogError("subordinateSockets is empty in " + base.CompatibleElementInfo.ID + " socket");
			}
			foreach (SubordinateElementSocket subordinateSocket in subordinateSockets)
			{
				if (subordinateSocket.CompatibleElementInfo != base.CompatibleElementInfo)
				{
					Debug.LogError("subordinateSockets of " + base.CompatibleElementInfo.ID + " socket contains not compatible socket " + subordinateSocket.CompatibleElementInfo.ID);
				}
			}
			Subscribe();
		}

		private void OnEnable()
		{
			Subscribe();
		}

		private void OnDisable()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			if (dragElementRegistrator != null && !isSubscribed)
			{
				isSubscribed = true;
				dragElementRegistrator.OnElementStartDrag += ResolveElementStartDrag;
				dragElementRegistrator.OnElementStopDrag += ResolveElementStopDrag;
			}
		}

		private void Unsubscribe()
		{
			if (dragElementRegistrator != null && isSubscribed)
			{
				isSubscribed = false;
				dragElementRegistrator.OnElementStartDrag -= ResolveElementStartDrag;
				dragElementRegistrator.OnElementStopDrag -= ResolveElementStopDrag;
			}
		}

		private void ResolveElementStartDrag()
		{
			if (!(dragElementRegistrator.DraggingElement.Info != base.CompatibleElementInfo) && (bool)base.NestedElement)
			{
				int num = subordinateSockets.Count - 1;
				while (num >= 0 && !TryPassElementToSocket(subordinateSockets[num]))
				{
					num--;
				}
			}
		}

		private void ResolveElementStopDrag()
		{
			if ((bool)base.NestedElement)
			{
				return;
			}
			foreach (SubordinateElementSocket subordinateSocket in subordinateSockets)
			{
				if (TryTakeElementFromSocket(subordinateSocket))
				{
					break;
				}
			}
		}

		private bool TryPassElementToSocket(ElementSocket toSocket)
		{
			if ((bool)toSocket.NestedElement)
			{
				return false;
			}
			ElementBase transitionElement = base.NestedElement;
			TransitElement(this, toSocket, transitionElement);
			return true;
		}

		private bool TryTakeElementFromSocket(ElementSocket fromSocket)
		{
			ElementBase elementBase = fromSocket.NestedElement;
			if (!elementBase)
			{
				return false;
			}
			TransitElement(fromSocket, this, elementBase);
			return true;
		}

		private void TransitElement(ElementSocket fromSocket, ElementSocket toSocket, ElementBase transitionElement)
		{
			fromSocket.DetachElement();
			toSocket.AttachElement(transitionElement);
			transitionElement.IsBlocked = toSocket.IsBlocked;
		}
	}
}
