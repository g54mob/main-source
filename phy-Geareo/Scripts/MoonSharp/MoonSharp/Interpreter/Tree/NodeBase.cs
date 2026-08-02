using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree
{
	internal abstract class NodeBase
	{
		public Script Script { get; private set; }

		protected ScriptLoadingContext LoadingContext { get; private set; }

		public NodeBase(ScriptLoadingContext lcontext)
		{
		}

		public abstract void Compile(ByteCode bc);

		protected static Token UnexpectedTokenType(Token t)
		{
			return null;
		}

		protected static Token CheckTokenType(ScriptLoadingContext lcontext, TokenType tokenType)
		{
			return null;
		}

		protected static Token CheckTokenType(ScriptLoadingContext lcontext, TokenType tokenType1, TokenType tokenType2)
		{
			return null;
		}

		protected static Token CheckTokenType(ScriptLoadingContext lcontext, TokenType tokenType1, TokenType tokenType2, TokenType tokenType3)
		{
			return null;
		}

		protected static void CheckTokenTypeNotNext(ScriptLoadingContext lcontext, TokenType tokenType)
		{
		}

		protected static Token CheckMatch(ScriptLoadingContext lcontext, Token originalToken, TokenType expectedTokenType, string expectedTokenText)
		{
			return null;
		}
	}
}
