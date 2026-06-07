using System;
using ModApi.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.UI
{
	public class ThrottleInputScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IBeginDragHandler
	{
		private RectTransform _clickArea;

		private FlightControls _flightControls;

		private DateTime _lastSoundTime;

		public void Initialize(RectTransform throttleRect)
		{
			_clickArea = throttleRect;
			_flightControls = FlightSceneScript.Instance.FlightControls;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
			HandleInput(eventData.position);
		}

		public void OnDrag(PointerEventData eventData)
		{
			HandleInput(eventData.position);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			HandleInput(eventData.position);
		}

		private void HandleInput(Vector2 cursorPosition)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_clickArea, cursorPosition, null, out var localPoint);
			float height = _clickArea.rect.height;
			float num = Mathf.Clamp(localPoint.y / height, 0f, 1f);
			num = Mathf.Round(num * 20f) / 20f;
			float throttle = _flightControls.Controls.Throttle;
			if (num != throttle)
			{
				if ((DateTime.Now - _lastSoundTime).TotalSeconds > 0.05000000074505806)
				{
					_lastSoundTime = DateTime.Now;
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.NavSphereMoved);
				}
				_flightControls.Controls.Throttle = num;
			}
		}
	}
}
