using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public interface IDragDropContainer
	{
		Transform DragParent { get; }

		void Dragging(PointerEventData eventData);

		void EndDrag(IDragDropElement element);

		void StartDrag(IDragDropElement element);
	}
}
