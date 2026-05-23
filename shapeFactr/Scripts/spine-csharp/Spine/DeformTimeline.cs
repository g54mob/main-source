namespace Spine
{
	public class DeformTimeline : CurveTimeline, ISlotTimeline
	{
		private readonly int slotIndex;

		private readonly VertexAttachment attachment;

		internal float[][] vertices;

		public int SlotIndex => 0;

		public VertexAttachment Attachment => null;

		public float[][] Vertices => null;

		public DeformTimeline(int frameCount, int bezierCount, int slotIndex, VertexAttachment attachment)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float[] vertices)
		{
		}

		public void setBezier(int bezier, int frame, int value, float time1, float value1, float cx1, float cy1, float cx2, float cy2, float time2, float value2)
		{
		}

		private float GetCurvePercent(float time, int frame)
		{
			return 0f;
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
