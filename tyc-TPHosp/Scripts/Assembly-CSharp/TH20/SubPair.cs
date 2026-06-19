namespace TH20
{
	public struct SubPair
	{
		public string Search;

		public string Replace;

		public SubPair(string search, string replace)
		{
			Search = search;
			Replace = replace;
		}

		public SubPair(string search, int replace)
		{
			Search = search;
			Replace = replace.ToString();
		}
	}
}
