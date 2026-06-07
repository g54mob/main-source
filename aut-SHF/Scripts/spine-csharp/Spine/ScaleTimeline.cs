namespace Spine
{
	public class ScaleTimeline : CurveTimeline2, IBoneTimeline
	{
		private readonly int boneIndex;

		public int BoneIndex => 0;

		public ScaleTimeline(int frameCount, int bezierCount, int boneIndex)
			: base(0, 0, null, null)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
