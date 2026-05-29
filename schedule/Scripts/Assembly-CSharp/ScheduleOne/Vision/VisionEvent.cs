namespace ScheduleOne.Vision
{
	public class VisionEvent
	{
		private const float NOTICE_DROP_THRESHOLD = 1f;

		private float timeSinceSighted;

		private float currentNoticeTime;

		public bool playTremolo;

		public ISightable Target { get; protected set; }

		public EntityVisualState State { get; protected set; }

		public VisionCone Owner { get; protected set; }

		public float FullNoticeTime { get; protected set; }

		public float NormalizedNoticeLevel => 0f;

		public VisionEvent(VisionCone _owner, ISightable _target, EntityVisualState _state, float _noticeTime, bool _playTremolo)
		{
		}

		public void UpdateEvent(float visionDeltaThisFrame, float tickTime)
		{
		}

		public void EndEvent()
		{
		}
	}
}
