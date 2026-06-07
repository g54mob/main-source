namespace Spine
{
	public class RGBTimeline : CurveTimeline, ISlotTimeline
	{
		public const int ENTRIES = 4;

		protected const int R = 1;

		protected const int G = 2;

		protected const int B = 3;

		private readonly int slotIndex;

		public override int FrameEntries => 0;

		public int SlotIndex => 0;

		public RGBTimeline(int frameCount, int bezierCount, int slotIndex)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float r, float g, float b)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
