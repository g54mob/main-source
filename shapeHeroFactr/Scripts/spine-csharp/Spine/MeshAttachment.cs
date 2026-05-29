namespace Spine
{
	public class MeshAttachment : VertexAttachment, IHasTextureRegion
	{
		internal TextureRegion region;

		internal string path;

		internal float[] regionUVs;

		internal float[] uvs;

		internal int[] triangles;

		internal float r;

		internal float g;

		internal float b;

		internal float a;

		internal int hullLength;

		private MeshAttachment parentMesh;

		private Sequence sequence;

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

		public int HullLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float[] RegionUVs
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float[] UVs
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int[] Triangles
		{
			get
			{
				return null;
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

		public string Path
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public MeshAttachment ParentMesh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int[] Edges { get; set; }

		public float Width { get; set; }

		public float Height { get; set; }

		public MeshAttachment(string name)
			: base((string)null)
		{
		}

		protected MeshAttachment(MeshAttachment other)
			: base((string)null)
		{
		}

		public void UpdateRegion()
		{
		}

		public override void ComputeWorldVertices(Slot slot, int start, int count, float[] worldVertices, int offset, int stride = 2)
		{
		}

		public MeshAttachment NewLinkedMesh()
		{
			return null;
		}

		public override Attachment Copy()
		{
			return null;
		}
	}
}
