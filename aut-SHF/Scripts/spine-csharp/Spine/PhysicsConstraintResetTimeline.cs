namespace Spine
{
	public class PhysicsConstraintResetTimeline : Timeline
	{
		private static readonly string[] propertyIds;

		private readonly int constraintIndex;

		public int PhysicsConstraintIndex => 0;

		public override int FrameCount => 0;

		public PhysicsConstraintResetTimeline(int frameCount, int physicsConstraintIndex)
			: base(0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
