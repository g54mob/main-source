using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public sealed class LexerSkipAction : ILexerAction
	{
		public static readonly LexerSkipAction Instance = new LexerSkipAction();

		public LexerActionType ActionType => LexerActionType.Skip;

		public bool IsPositionDependent => false;

		private LexerSkipAction()
		{
		}

		public void Execute(Lexer lexer)
		{
			lexer.Skip();
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
			return "skip";
		}
	}
}
