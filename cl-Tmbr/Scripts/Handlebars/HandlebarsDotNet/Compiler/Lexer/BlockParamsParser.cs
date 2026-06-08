using System;
using System.Text;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class BlockParamsParser : Parser
	{
		public override Token Parse(ExtendedStringReader reader)
		{
			IReaderContext context = reader.GetContext();
			string text = AccumulateWord(reader);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			return Token.BlockParams(text, context);
		}

		private static string AccumulateWord(ExtendedStringReader reader)
		{
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				if (reader.Peek() != 124)
				{
					return null;
				}
				reader.Read();
				while (reader.Peek() != 124 && reader.Peek() != -1)
				{
					value.Append((char)reader.Read());
				}
				reader.Read();
				string text = value.ToString().Trim();
				if (string.IsNullOrEmpty(text))
				{
					throw new HandlebarsParserException("BlockParams expression is not valid", reader.GetContext());
				}
				return text;
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
