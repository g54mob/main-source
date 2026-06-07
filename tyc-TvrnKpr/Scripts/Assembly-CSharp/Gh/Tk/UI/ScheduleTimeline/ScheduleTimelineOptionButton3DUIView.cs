using System;
using UnityEngine;

namespace Gh.Tk.UI.ScheduleTimeline
{
	public class ScheduleTimelineOptionButton3DUIView : TextButton3DUIView
	{
		public SchedulingTimeline3DUIView schedulingTimeline;

		[SerializeField]
		private GameObject _draggingElementPrefab;

		private GameObject _draggingElement;

		private static RaycastHit[] _hits;

		public Func<SchedulingTimeline3DUIView.SnapPositionData, ScheduleTimelineItem> CreateScheduleItemFactory;

		protected override void OnDestroy()
		{
		}

		protected override void UpdateIsPressed()
		{
		}

		private void Update()
		{
		}

		protected void OnHoveredOverScheduleArea(SchedulingTimeline3DUIView.SnapPositionData snapData)
		{
		}
	}
}
