namespace Spine
{
	public class BoundingBoxAttachment : VertexAttachment
	{
		public BoundingBoxAttachment(string name)
			: base((string)null)
		{
		}

		protected BoundingBoxAttachment(BoundingBoxAttachment other)
			: base((string)null)
		{
		}

		public override Attachment Copy()
		{
			return null;
		}
	}
}
