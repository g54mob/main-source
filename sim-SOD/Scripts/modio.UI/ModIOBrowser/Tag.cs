namespace ModIOBrowser
{
	internal struct Tag
	{
		public string category;

		public string name;

		public Tag(string category, string name)
		{
			this.category = null;
			this.name = null;
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
