using UnityEngine.EventSystems;

namespace DV.UIFramework
{
	public interface IDraggable : IClickable, IHoverable
	{
		bool IsDragged { get; }

		int Steps { get; set; }

		float MaxOffset { get; }

		event DragDelegate DragStarted;

		event DragDelegate DragFinished;

		event DragDelegate Dragged;

		void ForceSetNormalizedPosition(float normalizedPosition);

		float NormalizedOffsetFromPointerPosition(PointerEventData eventData);
	}
}
