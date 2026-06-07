using Assets.Scripts.Flight.UI;
using ModApi;
using ModApi.Flight.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Vizzy.UI
{
	public class ProgramContainerScript : MonoBehaviour
	{
		private InputResponder _inputResponder = new InputResponder("ProgramContainerScript");

		private RectTransform _rectTransform;

		private float _zoom = 1f;

		public float MaxZoom { get; set; } = 2f;

		public float MinZoom { get; set; } = 0.25f;

		public IVizzyUI VizzyUI { get; set; }

		public float Zoom
		{
			get
			{
				return _zoom;
			}
			set
			{
				Vector3 vector = VizzyUI.ProgramTransform.localPosition / _zoom;
				_zoom = Mathf.Clamp(value, MinZoom, MaxZoom);
				VizzyUI.ProgramTransform.localScale = new Vector3(_zoom, _zoom, _zoom);
				VizzyUI.ProgramTransform.localPosition = vector * Zoom;
				VizzyUI.DragTransform.localScale = VizzyUI.ProgramTransform.localScale;
			}
		}

		public bool OnDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
			Vector3 vector = new Vector3(eventData.delta.x, eventData.delta.y, 0f);
			VizzyUI.ProgramTransform.localPosition += vector / _rectTransform.lossyScale.x;
			return true;
		}

		public bool OnPinch(PinchEventData eventData)
		{
			float num = (eventData.Distance + eventData.DistanceDelta) / eventData.Distance;
			Zoom *= num;
			return true;
		}

		public bool OnScroll(PointerEventData eventData)
		{
			if (Game.Instance.UserInterface.ActiveDialog == null || Game.Instance.UserInterface.ActiveDialog.AllowCameraZoom)
			{
				float num = eventData.scrollDelta.y;
				if (Device.IsOsxRuntime)
				{
					num = Mathf.Clamp(num / 2f, -8f, 8f);
				}
				float num2 = 1f + num * 0.05f;
				Zoom *= num2;
			}
			return true;
		}

		protected virtual void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			InputHandlerScript inputHandlerScript = base.gameObject.AddComponent<InputHandlerScript>();
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnPinch = OnPinch;
			_inputResponder.OnScroll = OnScroll;
			_inputResponder.IsResponding = () => base.gameObject.activeSelf;
			inputHandlerScript.AddInputResponder(_inputResponder);
		}
	}
}
