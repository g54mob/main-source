namespace Spine
{
	public class SequenceTimeline : Timeline, ISlotTimeline
	{
		public const int ENTRIES = 3;

		private const int MODE = 1;

		private const int DELAY = 2;

		private readonly int slotIndex;

		private readonly IHasTextureRegion attachment;

		public override int FrameEntries => 0;

		public int SlotIndex => 0;

		public Attachment Attachment => null;

		public SequenceTimeline(int frameCount, int slotIndex, Attachment attachment)
			: base(0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, SequenceMode mode, int index, float delay)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
