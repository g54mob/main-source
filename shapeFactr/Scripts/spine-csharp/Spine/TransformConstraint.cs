namespace Spine
{
	public class TransformConstraint : IUpdatable
	{
		internal readonly TransformConstraintData data;

		internal readonly ExposedList<Bone> bones;

		internal Bone target;

		internal float mixRotate;

		internal float mixX;

		internal float mixY;

		internal float mixScaleX;

		internal float mixScaleY;

		internal float mixShearY;

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

		public float MixRotate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixShearY
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

		public TransformConstraintData Data => null;

		public TransformConstraint(TransformConstraintData data, Skeleton skeleton)
		{
		}

		public TransformConstraint(TransformConstraint constraint, Skeleton skeleton)
		{
		}

		public void SetToSetupPose()
		{
		}

		public void Update(Skeleton.Physics physics)
		{
		}

		private void ApplyAbsoluteWorld()
		{
		}

		private void ApplyRelativeWorld()
		{
		}

		private void ApplyAbsoluteLocal()
		{
		}

		private void ApplyRelativeLocal()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
