namespace Spine
{
	public class SlotData
	{
		internal int index;

		internal string name;

		internal BoneData boneData;

		internal float r;

		internal float g;

		internal float b;

		internal float a;

		internal float r2;

		internal float g2;

		internal float b2;

		internal bool hasSecondColor;

		internal string attachmentName;

		internal BlendMode blendMode;

		public int Index => 0;

		public string Name => null;

		public BoneData BoneData => null;

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

		public string AttachmentName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BlendMode BlendMode
		{
			get
			{
				return default(BlendMode);
			}
			set
			{
			}
		}

		public SlotData(int index, string name, BoneData boneData)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
