namespace Spine
{
	public class RotateTimeline : CurveTimeline1, IBoneTimeline
	{
		private readonly int boneIndex;

		public int BoneIndex => 0;

		public RotateTimeline(int frameCount, int bezierCount, int boneIndex)
			: base(0, 0, null)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
