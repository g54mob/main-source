namespace Spine
{
	public abstract class ConstraintData
	{
		internal readonly string name;

		internal int order;

		internal bool skinRequired;

		public string Name => null;

		public int Order
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool SkinRequired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ConstraintData(string name)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
