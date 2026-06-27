using System;
using Restory.Data.Elements.Condition;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class DragElementRegistrator : IDisposable
	{
		private ElementBase draggingElement;

		public ElementBase DraggingElement => draggingElement;

		public event Action OnElementStartDrag;

		public event Action OnBrokenElementStartDrag;

		public event Action OnElementStopDrag;

		public void RegisterDraggingElement(ElementBase draggingElement)
		{
			if (!draggingElement)
			{
				Debug.LogError("draggingElement is null on RegisterDraggingElement");
				return;
			}
			this.draggingElement = draggingElement;
			this.OnElementStartDrag?.Invoke();
			if (draggingElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				this.OnBrokenElementStartDrag?.Invoke();
			}
		}

		public void UnregisterDraggingElement()
		{
			draggingElement = null;
			this.OnElementStopDrag?.Invoke();
		}

		public void Dispose()
		{
			draggingElement = null;
		}
	}
}
