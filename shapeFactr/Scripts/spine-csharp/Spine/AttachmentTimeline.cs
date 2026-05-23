namespace Spine
{
	public class AttachmentTimeline : Timeline, ISlotTimeline
	{
		private readonly int slotIndex;

		private readonly string[] attachmentNames;

		public int SlotIndex => 0;

		public string[] AttachmentNames => null;

		public AttachmentTimeline(int frameCount, int slotIndex)
			: base(0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, string attachmentName)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}

		private void SetAttachment(Skeleton skeleton, Slot slot, string attachmentName)
		{
		}
	}
}
