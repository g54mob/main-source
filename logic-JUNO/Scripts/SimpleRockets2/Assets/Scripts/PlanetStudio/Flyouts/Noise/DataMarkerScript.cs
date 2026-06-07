using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class DataMarkerScript : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		private int _dragIndex;

		private DataFlowVisualization.DataMarker _dataMarker;

		public DataFlowVisualization.DataMarker DataMarker
		{
			get
			{
				return _dataMarker;
			}
			internal set
			{
				_dataMarker = value;
				if (!value.UserEditable)
				{
					CanvasGroup component = GetComponent<CanvasGroup>();
					component.interactable = false;
					component.blocksRaycasts = false;
				}
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			RectTransform rectTransform = DataMarker.MarkerElement.rectTransform;
			if (DataMarker.Output)
			{
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 20f);
			}
			_dragIndex = DataMarker.DataIndex;
		}

		public void OnDrag(PointerEventData eventData)
		{
			RectTransform rectTransform = DataMarker.MarkerElement.rectTransform;
			int value = (int)(DataMarker.Start.GridElement.rectTransform.InverseTransformPoint(eventData.position).x / 21f);
			value = Mathf.Clamp(value, 0, 9);
			Vector3 position = DataFlowVisualization.CalculatePosition(DataMarker.Start, value);
			rectTransform.position = position;
			_dragIndex = value;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			DataMarker.DataSlotField.DataIndex = _dragIndex;
			DataMarker.NoiseElement.PassContainer.UpdateVisualization();
		}
	}
}
