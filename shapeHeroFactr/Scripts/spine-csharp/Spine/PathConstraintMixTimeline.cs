namespace Spine
{
	public class PathConstraintMixTimeline : CurveTimeline
	{
		public const int ENTRIES = 4;

		private const int ROTATE = 1;

		private const int X = 2;

		private const int Y = 3;

		private readonly int constraintIndex;

		public override int FrameEntries => 0;

		public int PathConstraintIndex => 0;

		public PathConstraintMixTimeline(int frameCount, int bezierCount, int pathConstraintIndex)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float mixRotate, float mixX, float mixY)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
