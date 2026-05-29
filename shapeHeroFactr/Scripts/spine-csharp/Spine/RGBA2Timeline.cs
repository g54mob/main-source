namespace Spine
{
	public class RGBA2Timeline : CurveTimeline, ISlotTimeline
	{
		public const int ENTRIES = 8;

		protected const int R = 1;

		protected const int G = 2;

		protected const int B = 3;

		protected const int A = 4;

		protected const int R2 = 5;

		protected const int G2 = 6;

		protected const int B2 = 7;

		private readonly int slotIndex;

		public override int FrameEntries => 0;

		public int SlotIndex => 0;

		public RGBA2Timeline(int frameCount, int bezierCount, int slotIndex)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float r, float g, float b, float a, float r2, float g2, float b2)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
