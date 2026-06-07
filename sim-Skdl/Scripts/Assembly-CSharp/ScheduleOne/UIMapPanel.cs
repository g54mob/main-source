using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne
{
	public class UIMapPanel : UIPanel, INonNavigablePanel
	{
		[SerializeField]
		private PinchableScrollRect mapScrollRect;

		[SerializeField]
		private float scrollSensitivity;

		[SerializeField]
		private float minZoomScrollSpeedMult;

		[SerializeField]
		private float maxZoomScrollSpeedMult;

		[SerializeField]
		private float zoomSensitivity;

		[SerializeField]
		private RectTransform centerPoint;

		private const float initialHoldThreshold = 0.5f;

		private const float repeatInterval = 0.25f;

		private float zoomTimer;

		private bool wasZoomPressedLastFrame;

		private List<UIMapItem> mapItems;

		private UIMapItem snappedItem;

		private bool lockMapInput;

		public bool LockMapInput
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void Start()
		{
		}

		protected override void Update()
		{
		}

		private void Navigate()
		{
		}

		private void Zoom()
		{
		}

		public void RegisterMapItem(UIMapItem item)
		{
		}

		public void DeregisterMapItem(UIMapItem item)
		{
		}

		public void SetSnappedItem(UIMapItem newItem)
		{
		}

		public void ResetSnappedItem()
		{
		}

		private void SnapToNearestMapItem()
		{
		}

		private void SnapMapToItem(UIMapItem item)
		{
		}

		protected override void HandleInputDeviceChanged(GameInput.InputDeviceType type)
		{
		}
	}
}
