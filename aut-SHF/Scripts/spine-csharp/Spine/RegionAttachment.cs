namespace Spine
{
	public class RegionAttachment : Attachment, IHasTextureRegion
	{
		public const int BLX = 0;

		public const int BLY = 1;

		public const int ULX = 2;

		public const int ULY = 3;

		public const int URX = 4;

		public const int URY = 5;

		public const int BRX = 6;

		public const int BRY = 7;

		internal TextureRegion region;

		internal float x;

		internal float y;

		internal float rotation;

		internal float scaleX;

		internal float scaleY;

		internal float width;

		internal float height;

		internal float[] offset;

		internal float[] uvs;

		internal float r;

		internal float g;

		internal float b;

		internal float a;

		internal Sequence sequence;

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

		public float Rotation
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

		public float ScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		public string Path { get; set; }

		public TextureRegion Region
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float[] Offset => null;

		public float[] UVs => null;

		public Sequence Sequence
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RegionAttachment(string name)
			: base((string)null)
		{
		}

		public RegionAttachment(RegionAttachment other)
			: base((string)null)
		{
		}

		public void UpdateRegion()
		{
		}

		public void ComputeWorldVertices(Slot slot, float[] worldVertices, int offset, int stride = 2)
		{
		}

		public override Attachment Copy()
		{
			return null;
		}
	}
}
