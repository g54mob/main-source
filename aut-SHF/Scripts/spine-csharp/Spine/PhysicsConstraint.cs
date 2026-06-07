namespace Spine
{
	public class PhysicsConstraint : IUpdatable
	{
		internal readonly PhysicsConstraintData data;

		public Bone bone;

		internal float inertia;

		internal float strength;

		internal float damping;

		internal float massInverse;

		internal float wind;

		internal float gravity;

		internal float mix;

		private bool reset;

		private float ux;

		private float uy;

		private float cx;

		private float cy;

		private float tx;

		private float ty;

		private float xOffset;

		private float xVelocity;

		private float yOffset;

		private float yVelocity;

		private float rotateOffset;

		private float rotateVelocity;

		private float scaleOffset;

		private float scaleVelocity;

		internal bool active;

		private readonly Skeleton skeleton;

		private float remaining;

		private float lastTime;

		public Bone Bone
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Inertia
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Strength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Damping
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MassInverse
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Wind
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Gravity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Mix
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Active => false;

		public PhysicsConstraintData Data => null;

		public PhysicsConstraint(PhysicsConstraintData data, Skeleton skeleton)
		{
		}

		public PhysicsConstraint(PhysicsConstraint constraint, Skeleton skeleton)
		{
		}

		public void Reset()
		{
		}

		public void SetToSetupPose()
		{
		}

		public void Translate(float x, float y)
		{
		}

		public void Rotate(float x, float y, float degrees)
		{
		}

		public void Update(Skeleton.Physics physics)
		{
		}

		public PhysicsConstraintData getData()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
