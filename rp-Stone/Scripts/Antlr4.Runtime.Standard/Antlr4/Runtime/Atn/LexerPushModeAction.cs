using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public sealed class LexerPushModeAction : ILexerAction
	{
		private readonly int mode;

		public int Mode => mode;

		public LexerActionType ActionType => LexerActionType.PushMode;

		public bool IsPositionDependent => false;

		public LexerPushModeAction(int mode)
		{
			this.mode = mode;
		}

		public void Execute(Lexer lexer)
		{
			lexer.PushMode(mode);
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
			if (!(obj is LexerPushModeAction))
			{
				return false;
			}
			return mode == ((LexerPushModeAction)obj).mode;
		}

		public override string ToString()
		{
			return $"pushMode({mode})";
		}
	}
}
