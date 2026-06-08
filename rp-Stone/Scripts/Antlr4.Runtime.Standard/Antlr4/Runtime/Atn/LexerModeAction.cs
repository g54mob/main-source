using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public sealed class LexerModeAction : ILexerAction
	{
		private readonly int mode;

		public int Mode => mode;

		public LexerActionType ActionType => LexerActionType.Mode;

		public bool IsPositionDependent => false;

		public LexerModeAction(int mode)
		{
			this.mode = mode;
		}

		public void Execute(Lexer lexer)
		{
			lexer.Mode(mode);
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(), (int)ActionType), mode), 2);
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
			{
				return true;
			}
			if (!(obj is LexerModeAction))
			{
				return false;
			}
			return mode == ((LexerModeAction)obj).mode;
		}

		public override string ToString()
		{
			return $"mode({mode})";
		}
	}
}
