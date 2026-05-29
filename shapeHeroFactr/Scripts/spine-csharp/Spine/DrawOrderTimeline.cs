namespace Spine
{
	public class DrawOrderTimeline : Timeline
	{
		private static readonly string[] propertyIds;

		private readonly int[][] drawOrders;

		public int[][] DrawOrders => null;

		public DrawOrderTimeline(int frameCount)
			: base(0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, int[] drawOrder)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
