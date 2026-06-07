namespace Spine
{
	public class TransformConstraintData : ConstraintData
	{
		internal ExposedList<BoneData> bones;

		internal BoneData target;

		internal float mixRotate;

		internal float mixX;

		internal float mixY;

		internal float mixScaleX;

		internal float mixScaleY;

		internal float mixShearY;

		internal float offsetRotation;

		internal float offsetX;

		internal float offsetY;

		internal float offsetScaleX;

		internal float offsetScaleY;

		internal float offsetShearY;

		internal bool relative;

		internal bool local;

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

		public float OffsetX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetShearY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Relative
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Local
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TransformConstraintData(string name)
			: base(null)
		{
		}
	}
}
