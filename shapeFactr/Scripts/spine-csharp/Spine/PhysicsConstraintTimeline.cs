namespace Spine
{
	public abstract class PhysicsConstraintTimeline : CurveTimeline1
	{
		private readonly int constraintIndex;

		public int PhysicsConstraintIndex => 0;

		public PhysicsConstraintTimeline(int frameCount, int bezierCount, int physicsConstraintIndex, Property property)
			: base(0, 0, null)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}

		protected abstract float Setup(PhysicsConstraint constraint);

		protected abstract float Get(PhysicsConstraint constraint);

		protected abstract void Set(PhysicsConstraint constraint, float value);

		protected abstract bool Global(PhysicsConstraintData constraint);
	}
}
