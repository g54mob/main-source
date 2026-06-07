using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	[RequireComponent(typeof(Image))]
	public class TouchJoystickExample : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		public bool allowMouseControl;

		public int radius;

		private Vector2 origAnchoredPosition;

		private Vector3 origWorldPosition;

		private Vector2 origScreenResolution;

		private ScreenOrientation origScreenOrientation;

		[NonSerialized]
		private bool hasFinger;

		[NonSerialized]
		private int lastFingerId;

		public Vector2 position { get; private set; }

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void Restart()
		{
		}

		private void StoreOrigValues()
		{
		}

		private void UpdateValue(Vector3 value)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		private static bool IsMousePointerId(int id)
		{
			return false;
		}
	}
}
