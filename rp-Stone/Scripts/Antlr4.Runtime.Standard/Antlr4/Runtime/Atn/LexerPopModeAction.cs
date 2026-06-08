using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public sealed class LexerPopModeAction : ILexerAction
	{
		public static readonly LexerPopModeAction Instance = new LexerPopModeAction();

		public LexerActionType ActionType => LexerActionType.PopMode;

		public bool IsPositionDependent => false;

		private LexerPopModeAction()
		{
		}

		public void Execute(Lexer lexer)
		{
			lexer.PopMode();
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
			return "popMode";
		}
	}
}
