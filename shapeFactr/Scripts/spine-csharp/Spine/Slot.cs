namespace Spine
{
	public class Slot
	{
		internal SlotData data;

		internal Bone bone;

		internal float r;

		internal float g;

		internal float b;

		internal float a;

		internal float r2;

		internal float g2;

		internal float b2;

		internal bool hasSecondColor;

		internal Attachment attachment;

		internal int sequenceIndex;

		internal ExposedList<float> deform;

		internal int attachmentState;

		public SlotData Data => null;

		public Bone Bone => null;

		public Skeleton Skeleton => null;

		public float R
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float G
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float B
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float A
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float R2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float G2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float B2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool HasSecondColor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Attachment Attachment
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int SequenceIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ExposedList<float> Deform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Slot(SlotData data, Bone bone)
		{
		}

		public Slot(Slot slot, Bone bone)
		{
		}

		public void ClampColor()
		{
		}

		public void ClampSecondColor()
		{
		}

		public void SetToSetupPose()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
