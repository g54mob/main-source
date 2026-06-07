namespace Spine
{
	public abstract class Attachment
	{
		public string Name { get; }

		protected Attachment(string name)
		{
		}

		protected Attachment(Attachment other)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public abstract Attachment Copy();
	}
}
