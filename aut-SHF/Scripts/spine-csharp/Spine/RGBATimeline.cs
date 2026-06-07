namespace Spine
{
	public class RGBATimeline : CurveTimeline, ISlotTimeline
	{
		public const int ENTRIES = 5;

		protected const int R = 1;

		protected const int G = 2;

		protected const int B = 3;

		protected const int A = 4;

		private readonly int slotIndex;

		public override int FrameEntries => 0;

		public int SlotIndex => 0;

		public RGBATimeline(int frameCount, int bezierCount, int slotIndex)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float r, float g, float b, float a)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
