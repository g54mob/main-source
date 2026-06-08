using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public sealed class LexerChannelAction : ILexerAction
	{
		private readonly int channel;

		public int Channel => channel;

		public LexerActionType ActionType => LexerActionType.Channel;

		public bool IsPositionDependent => false;

		public LexerChannelAction(int channel)
		{
			this.channel = channel;
		}

		public void Execute(Lexer lexer)
		{
			lexer.Channel = channel;
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(), (int)ActionType), channel), 2);
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
			{
				return true;
			}
			if (!(obj is LexerChannelAction))
			{
				return false;
			}
			return channel == ((LexerChannelAction)obj).channel;
		}

		public override string ToString()
		{
			return $"channel({channel})";
		}
	}
}
