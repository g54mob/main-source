namespace Spine
{
	public class IkConstraint : IUpdatable
	{
		internal readonly IkConstraintData data;

		internal readonly ExposedList<Bone> bones;

		internal Bone target;

		internal int bendDirection;

		internal bool compress;

		internal bool stretch;

		internal float mix;

		internal float softness;

		internal bool active;

		public ExposedList<Bone> Bones => null;

		public Bone Target
		{
			get
			{
				return null;
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

		public float Softness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int BendDirection
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Compress
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Stretch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Active => false;

		public IkConstraintData Data => null;

		public IkConstraint(IkConstraintData data, Skeleton skeleton)
		{
		}

		public IkConstraint(IkConstraint constraint, Skeleton skeleton)
		{
		}

		public void SetToSetupPose()
		{
		}

		public void Update(Skeleton.Physics physics)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static void Apply(Bone bone, float targetX, float targetY, bool compress, bool stretch, bool uniform, float alpha)
		{
		}

		public static void Apply(Bone parent, Bone child, float targetX, float targetY, int bendDir, bool stretch, bool uniform, float softness, float alpha)
		{
		}
	}
}
