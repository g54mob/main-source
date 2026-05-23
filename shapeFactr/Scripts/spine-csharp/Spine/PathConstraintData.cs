namespace Spine
{
	public class PathConstraintData : ConstraintData
	{
		internal ExposedList<BoneData> bones;

		internal SlotData target;

		internal PositionMode positionMode;

		internal SpacingMode spacingMode;

		internal RotateMode rotateMode;

		internal float offsetRotation;

		internal float position;

		internal float spacing;

		internal float mixRotate;

		internal float mixX;

		internal float mixY;

		public ExposedList<BoneData> Bones => null;

		public SlotData Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PositionMode PositionMode
		{
			get
			{
				return default(PositionMode);
			}
			set
			{
			}
		}

		public SpacingMode SpacingMode
		{
			get
			{
				return default(SpacingMode);
			}
			set
			{
			}
		}

		public RotateMode RotateMode
		{
			get
			{
				return default(RotateMode);
			}
			set
			{
			}
		}

		public float OffsetRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		public float RotateMix
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

		public PathConstraintData(string name)
			: base(null)
		{
		}
	}
}
