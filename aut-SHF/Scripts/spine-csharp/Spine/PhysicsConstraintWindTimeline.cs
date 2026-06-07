namespace Spine
{
	public class PhysicsConstraintWindTimeline : PhysicsConstraintTimeline
	{
		public PhysicsConstraintWindTimeline(int frameCount, int bezierCount, int physicsConstraintIndex)
			: base(0, 0, 0, default(Property))
		{
		}

		protected override float Setup(PhysicsConstraint constraint)
		{
			return 0f;
		}

		protected override float Get(PhysicsConstraint constraint)
		{
			return 0f;
		}

		protected override void Set(PhysicsConstraint constraint, float value)
		{
		}

		protected override bool Global(PhysicsConstraintData constraint)
		{
			return false;
		}
	}
}
