namespace Spine
{
	public class PathConstraint : IUpdatable
	{
		private const int NONE = -1;

		private const int BEFORE = -2;

		private const int AFTER = -3;

		private const float Epsilon = 1E-05f;

		internal readonly PathConstraintData data;

		internal readonly ExposedList<Bone> bones;

		internal Slot target;

		internal float position;

		internal float spacing;

		internal float mixRotate;

		internal float mixX;

		internal float mixY;

		internal bool active;

		internal readonly ExposedList<float> spaces;

		internal readonly ExposedList<float> positions;

		internal readonly ExposedList<float> world;

		internal readonly ExposedList<float> curves;

		internal readonly ExposedList<float> lengths;

		internal readonly float[] segments;

		public float Position
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Spacing
		{
			get
			{
				return 0f;
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

		public ExposedList<Bone> Bones => null;

		public Slot Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Active => false;

		public PathConstraintData Data => null;

		public PathConstraint(PathConstraintData data, Skeleton skeleton)
		{
		}

		public PathConstraint(PathConstraint constraint, Skeleton skeleton)
		{
		}

		public static void ArraysFill(float[] a, int fromIndex, int toIndex, float val)
		{
		}

		public void SetToSetupPose()
		{
		}

		public void Update(Skeleton.Physics physics)
		{
		}

		private float[] ComputeWorldPositions(PathAttachment path, int spacesCount, bool tangents)
		{
			return null;
		}

		private static void AddBeforePosition(float p, float[] temp, int i, float[] output, int o)
		{
		}

		private static void AddAfterPosition(float p, float[] temp, int i, float[] output, int o)
		{
		}

		private static void AddCurvePosition(float p, float x1, float y1, float cx1, float cy1, float cx2, float cy2, float x2, float y2, float[] output, int o, bool tangents)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
