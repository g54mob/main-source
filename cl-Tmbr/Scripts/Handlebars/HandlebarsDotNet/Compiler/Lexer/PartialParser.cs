namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class PartialParser : Parser
	{
		public override Token Parse(ExtendedStringReader reader)
		{
			PartialToken result = null;
			if ((ushort)reader.Peek() == 62)
			{
				result = Token.Partial(reader.GetContext());
			}
			return result;
		}
	}
}
