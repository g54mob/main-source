using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public sealed class LexerMoreAction : ILexerAction
	{
		public static readonly LexerMoreAction Instance = new LexerMoreAction();

		public LexerActionType ActionType => LexerActionType.More;

		public bool IsPositionDependent => false;

		private LexerMoreAction()
		{
		}

		public void Execute(Lexer lexer)
		{
			lexer.More();
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Initialize(), (int)ActionType), 1);
		}

		public override bool Equals(object obj)
		{
			return obj == this;
		}

		public override string ToString()
		{
			return "more";
		}
	}
}
