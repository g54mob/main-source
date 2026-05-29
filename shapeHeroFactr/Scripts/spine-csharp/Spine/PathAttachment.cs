namespace Spine
{
	public class PathAttachment : VertexAttachment
	{
		internal float[] lengths;

		internal bool closed;

		internal bool constantSpeed;

		public float[] Lengths
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Closed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ConstantSpeed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PathAttachment(string name)
			: base((string)null)
		{
		}

		protected PathAttachment(PathAttachment other)
			: base((string)null)
		{
		}

		public override Attachment Copy()
		{
			return null;
		}
	}
}
