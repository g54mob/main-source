using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerTimeline3DUIView : MonoBehaviour
	{
		[SerializeField]
		private PatronAttractionChart _attractionChart;

		[SerializeField]
		private Transform _timelineBacker;

		[SerializeField]
		private GameObject _entertainerBookingItemPrefab;

		public EntertainerBookingControls3DUIView bookingControls;

		private List<EntertainerBookingItem3DUIView> _bookingItems;

		public DissolveArea3DUIView dissolveArea;

		public DraggableAttractionBoard draggableBoard;

		private float previousStartTime;

		private List<TimelineSnappingData> _snapPositionData;

		private List<TimelineSnappingData> _historySnapPositionData;

		private static RaycastHit[] _hits;

		public bool IsOpen { get; private set; }

		private void Start()
		{
		}

		public void ShowTimeline()
		{
		}

		public void HideTimeline()
		{
		}

		public void OnDialogOpened()
		{
		}

		public void OnDialogClosing()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnBookingChanged(object sender, EventArgs e)
		{
		}

		public List<EntertainerBookingItem3DUIView> GetBookingItems()
		{
			return null;
		}

		private void PopulateBookingItems()
		{
		}

		private void CalculateSnappingPoints()
		{
		}

		public static (int, int) CalculatePerformanceTime(int timelineHour)
		{
			return default((int, int));
		}

		public bool TryGetClosestSnappingPoint(Vector2 offset, EntertainerBookingItem3DUIView bookingItem, out TimelineSnappingData snapData)
		{
			snapData = default(TimelineSnappingData);
			return false;
		}

		public Vector3 CalculateMousePositionOnTimeline(Vector2 mouseOffset)
		{
			return default(Vector3);
		}

		private float GetStartHourPosition()
		{
			return 0f;
		}

		private float GetEndHourPosition(int hourOffset)
		{
			return 0f;
		}

		public TimelineSnappingData GetSnapDataForHour(int hour)
		{
			return default(TimelineSnappingData);
		}

		public TimelineSnappingData GetClosestSnapData(float position, bool getMiddlePosition = false, bool includeHistoric = false)
		{
			return default(TimelineSnappingData);
		}

		public bool IsPositionOnActiveScheduleTimeline(float position)
		{
			return false;
		}

		public bool IsHoveringAttractionChart()
		{
			return false;
		}
	}
}
