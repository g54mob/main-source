namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class StaticToken : Token
	{
		public IReaderContext Context { get; }

		public override TokenType Type => TokenType.Static;

		public override string Value { get; }

		public string Original { get; }

		private StaticToken(string value, string original, IReaderContext context = null)
		{
			Value = value;
			Original = original;
			Context = context;
		}

		internal StaticToken(string value, IReaderContext context = null)
			: this(value, value)
		{
			Context = context;
		}

		public StaticToken GetModifiedToken(string value)
		{
			return new StaticToken(value, Original, Context);
		}
	}
}
