namespace Spine
{
	public abstract class VertexAttachment : Attachment
	{
		private static int nextID;

		private static readonly object nextIdLock;

		internal readonly int id;

		internal VertexAttachment timelineAttachment;

		internal int[] bones;

		internal float[] vertices;

		internal int worldVerticesLength;

		public int Id => 0;

		public int[] Bones
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float[] Vertices
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int WorldVerticesLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public VertexAttachment TimelineAttachment
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public VertexAttachment(string name)
			: base((string)null)
		{
		}

		public VertexAttachment(VertexAttachment other)
			: base((string)null)
		{
		}

		public void ComputeWorldVertices(Slot slot, float[] worldVertices)
		{
		}

		public virtual void ComputeWorldVertices(Slot slot, int start, int count, float[] worldVertices, int offset, int stride = 2)
		{
		}
	}
}
