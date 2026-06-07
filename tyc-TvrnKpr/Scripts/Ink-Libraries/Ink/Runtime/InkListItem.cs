namespace Ink.Runtime
{
	public struct InkListItem
	{
		public readonly string originName;

		public readonly string itemName;

		public static InkListItem Null => default(InkListItem);

		public bool isNull => false;

		public string fullName => null;

		public InkListItem(string originName, string itemName)
		{
			this.originName = null;
			this.itemName = null;
		}

		public InkListItem(string fullName)
		{
			originName = null;
			itemName = null;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
