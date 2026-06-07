using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI.ScheduleTimeline
{
	public abstract class SchedulingTimeline3DUIView : MonoBehaviour
	{
		public struct SnapPositionData
		{
			public float Position;

			public float MiddlePosition;

			public int Hour;
		}

		public static List<SchedulingTimeline3DUIView> AllTimelines;

		public int PriorityIndex;

		[SerializeField]
		private Button3DUIView _toggleScheduleButtonsButton;

		[SerializeField]
		private Button3DUIView _toggleSchedulingTimelineButton;

		[SerializeField]
		protected GameObject _scheduleOptionButtonPrefab;

		[SerializeField]
		private GameObject _scheduleItemPrefab;

		[SerializeField]
		private PatronAttractionChart _attractionChart;

		[SerializeField]
		private Transform _timelineAnchor;

		private List<GameObject> _scheduleTimelineItems;

		private List<SnapPositionData> _snapPositionData;

		private List<SnapPositionData> _historySnapPositionData;

		private int _highestYLevel;

		private float _yLevelDistance;

		private static RaycastHit[] _hits;

		public static event EventHandler SchedulingTimelineChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Start()
		{
		}

		private void OnDisable()
		{
		}

		public bool IsPositionOnActiveScheduleTimeline(float position)
		{
			return false;
		}

		public SnapPositionData GetClosestSnapData(float position, bool getMiddlePosition = false, bool includeHistoric = false)
		{
			return default(SnapPositionData);
		}

		public float GetStartHourPosition()
		{
			return 0f;
		}

		public float GetEndHourPosition(int hourOffset)
		{
			return 0f;
		}

		public void OnOpen()
		{
		}

		public void OnClose()
		{
		}

		protected virtual void RepopulateScheduleTimelineItems()
		{
		}

		public void ShowScheduleTimeline(bool show)
		{
		}

		private void UpdateScheduleButtons()
		{
		}

		protected abstract void PopulateScheduleButtons(Container3DUIView container);

		private int GetStartingYLevel()
		{
			return 0;
		}

		private int GetYLevelForNextTimeline()
		{
			return 0;
		}

		public void UpdateYLevel(ScheduleTimelineItem3DUIView timelineItemToUpdate, bool updateTimelineBelow = true)
		{
		}

		public void UpdateAllYLevels()
		{
		}

		private void UpdateTimelineBelow()
		{
		}

		public void AddScheduleItem(int hour, ScheduleTimelineItem scheduleItem, bool updateScheduleItems = true, bool isHeld = false)
		{
		}

		public void ChangeScheduleItem(int newHour, ScheduleTimelineItem3DUIView scheduleTimelineItem)
		{
		}

		public void RemoveScheduleItem(ScheduleTimelineItem3DUIView timelineItem)
		{
		}

		public (int, int) CalculateTargetDayHour(int scheduleHour)
		{
			return default((int, int));
		}

		public void ValidateScheduleItems()
		{
		}

		public bool IsHourValidForScheduleItem(int newHour, ScheduleTimelineItem3DUIView scheduleTimelineUI, out string invalidReason)
		{
			invalidReason = null;
			return false;
		}

		public Vector3 CalculateMouseProjectedPoint(Vector2 mouseOffset)
		{
			return default(Vector3);
		}

		public bool IsHoveringAttractionChart()
		{
			return false;
		}
	}
}
