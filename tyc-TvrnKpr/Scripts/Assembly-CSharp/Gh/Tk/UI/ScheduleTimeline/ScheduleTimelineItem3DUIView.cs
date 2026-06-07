using UnityEngine;

namespace Gh.Tk.UI.ScheduleTimeline
{
	public class ScheduleTimelineItem3DUIView : Button3DUIView
	{
		private SchedulingTimeline3DUIView _timeline;

		private Vector2 _mouseOffsetFromStart;

		private Vector3 _previousMouseProjectedPoint;

		[SerializeField]
		private GameObject _invalidVisual;

		private string _invalidReason;

		public ScheduleTimelineItem ScheduleTimelineItem { get; private set; }

		public int YLevel { get; set; }

		public int CurrentHour { get; private set; }

		public override bool IsPressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsValid { get; private set; }

		public void SetData(SchedulingTimeline3DUIView timeline, ScheduleTimelineItem scheduleItem)
		{
		}

		public void SetPositioningData(float positionX, int durationHours, int zLayer)
		{
		}

		public override void OnClicked()
		{
		}

		private void Update()
		{
		}

		private void OnReleased()
		{
		}

		private void ShowInvalidVisual(bool isValid)
		{
		}

		public void SetValid()
		{
		}

		public void SetInvalid(string invalidReason)
		{
		}
	}
}
