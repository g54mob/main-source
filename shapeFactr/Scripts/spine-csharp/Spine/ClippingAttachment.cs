namespace Spine
{
	public class ClippingAttachment : VertexAttachment
	{
		internal SlotData endSlot;

		public SlotData EndSlot
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ClippingAttachment(string name)
			: base((string)null)
		{
		}

		protected ClippingAttachment(ClippingAttachment other)
			: base((string)null)
		{
		}

		public override Attachment Copy()
		{
			return null;
		}
	}
}
