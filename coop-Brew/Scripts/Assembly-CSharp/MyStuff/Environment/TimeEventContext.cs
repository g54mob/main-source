namespace MyStuff.Environment
{
	public class TimeEventContext
	{
		public int DayIndex { get; set; }

		public int Hour { get; set; }

		public int Minute { get; set; }

		public float NormalizedTime { get; set; }

		public TimePhase Phase { get; set; }

		public string EventTag { get; set; }

		public string PayloadJson { get; set; }

		public bool IsServerContext { get; set; }

		public TimeEventContext()
		{
		}

		public TimeEventContext(int dayIndex, int hour, int minute, float normalizedTime, TimePhase phase, string eventTag, string payloadJson, bool isServer)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
