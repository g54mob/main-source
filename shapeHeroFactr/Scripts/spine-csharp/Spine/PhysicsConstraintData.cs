namespace Spine
{
	public class PhysicsConstraintData : ConstraintData
	{
		internal BoneData bone;

		internal float x;

		internal float y;

		internal float rotate;

		internal float scaleX;

		internal float shearX;

		internal float limit;

		internal float step;

		internal float inertia;

		internal float strength;

		internal float damping;

		internal float massInverse;

		internal float wind;

		internal float gravity;

		internal float mix;

		internal bool inertiaGlobal;

		internal bool strengthGlobal;

		internal bool dampingGlobal;

		internal bool massGlobal;

		internal bool windGlobal;

		internal bool gravityGlobal;

		internal bool mixGlobal;

		public BoneData Bone => null;

		public float Step
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Rotate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ShearX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Limit
		{
			get
			{
				return 0f;
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

		public bool InertiaGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool StrengthGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DampingGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool MassGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool WindGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool GravityGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool MixGlobal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PhysicsConstraintData(string name)
			: base(null)
		{
		}
	}
}
