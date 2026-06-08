namespace Antlr4.Runtime.Atn
{
	public class OrderedATNConfigSet : ATNConfigSet
	{
		public class LexerConfigHashSet : ConfigHashSet
		{
			public LexerConfigHashSet()
				: base(new ObjectEqualityComparator())
			{
			}
		}

		public OrderedATNConfigSet()
		{
			configLookup = new LexerConfigHashSet();
		}
	}
}
