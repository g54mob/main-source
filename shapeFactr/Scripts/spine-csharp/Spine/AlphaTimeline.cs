namespace Spine
{
	public class AlphaTimeline : CurveTimeline1, ISlotTimeline
	{
		private readonly int slotIndex;

		public int SlotIndex => 0;

		public AlphaTimeline(int frameCount, int bezierCount, int slotIndex)
			: base(0, 0, null)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
