namespace Spine
{
	public class IkConstraintData : ConstraintData
	{
		internal ExposedList<BoneData> bones;

		internal BoneData target;

		internal int bendDirection;

		internal bool compress;

		internal bool stretch;

		internal bool uniform;

		internal float mix;

		internal float softness;

		public ExposedList<BoneData> Bones => null;

		public BoneData Target
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

		public bool Uniform
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IkConstraintData(string name)
			: base(null)
		{
		}
	}
}
