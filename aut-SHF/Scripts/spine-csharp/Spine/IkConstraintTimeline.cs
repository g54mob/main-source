namespace Spine
{
	public class IkConstraintTimeline : CurveTimeline
	{
		public const int ENTRIES = 6;

		private const int MIX = 1;

		private const int SOFTNESS = 2;

		private const int BEND_DIRECTION = 3;

		private const int COMPRESS = 4;

		private const int STRETCH = 5;

		private readonly int constraintIndex;

		public override int FrameEntries => 0;

		public int IkConstraintIndex => 0;

		public IkConstraintTimeline(int frameCount, int bezierCount, int ikConstraintIndex)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float mix, float softness, int bendDirection, bool compress, bool stretch)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
