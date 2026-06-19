#define LOG_LEVEL_VERBOSE
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	public class UIMapPin : Selectable
	{
		[SerializeField]
		private float _yOffset;

		[SerializeField]
		private ScaleElementOnSelection _scaleComponent;

		public EmergencyDispatchMap DispatchMap;

		protected Vector2 _mapPosition;

		protected MapLayerParent.EMapLayer _mapLayer;

		public Vector2 MapPosition => _mapPosition;

		public MapLayerParent.EMapLayer MapLayer => _mapLayer;

		public void Setup(EmergencyDispatchMap dispatchMap, Vector2 mapPosition)
		{
			_mapPosition = mapPosition;
			DispatchMap = dispatchMap;
			base.gameObject.SetActive(value: true);
		}

		public virtual void UpdatePin(EmergencyDispatchMap map)
		{
		}

		public virtual void SetActive(bool active)
		{
			base.interactable = active;
		}

		protected virtual void ResetPin()
		{
			_mapPosition = Vector2.zero;
			base.transform.localPosition = _mapPosition;
			base.gameObject.SetActive(value: false);
		}

		protected override void OnDestroy()
		{
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left && EventSystem.current != null && IsInteractable())
			{
				Select();
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			Logging.Info("Selected: " + eventData.selectedObject);
			DispatchMap.SetSelectedMapPin(this);
			if (_scaleComponent != null)
			{
				_scaleComponent.SetKeepSizeAfterPointerExit(keepSize: true);
			}
		}

		public void Deselect()
		{
			if (_scaleComponent != null)
			{
				_scaleComponent.SetKeepSizeAfterPointerExit(keepSize: false);
			}
		}

		protected void TriggerScaleComponent(bool active)
		{
			_scaleComponent.SetActive(active);
		}
	}
}
