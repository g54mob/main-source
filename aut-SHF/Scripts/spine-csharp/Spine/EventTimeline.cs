namespace Spine
{
	public class EventTimeline : Timeline
	{
		private static readonly string[] propertyIds;

		private readonly Event[] events;

		public Event[] Events => null;

		public EventTimeline(int frameCount)
			: base(0, (string[])null)
		{
		}

		public void SetFrame(int frame, Event e)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
