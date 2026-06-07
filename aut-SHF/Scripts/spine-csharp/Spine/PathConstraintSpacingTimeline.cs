namespace Spine
{
	public class PathConstraintSpacingTimeline : CurveTimeline1
	{
		private readonly int constraintIndex;

		public int PathConstraintIndex => 0;

		public PathConstraintSpacingTimeline(int frameCount, int bezierCount, int pathConstraintIndex)
			: base(0, 0, null)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
