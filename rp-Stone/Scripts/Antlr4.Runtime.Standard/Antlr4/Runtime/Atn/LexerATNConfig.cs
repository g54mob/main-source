using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public class LexerATNConfig : ATNConfig
	{
		private readonly LexerActionExecutor lexerActionExecutor;

		private readonly bool passedThroughNonGreedyDecision;

		public LexerATNConfig(ATNState state, int alt, PredictionContext context)
			: base(state, alt, context)
		{
			passedThroughNonGreedyDecision = false;
			lexerActionExecutor = null;
		}

		public LexerATNConfig(ATNState state, int alt, PredictionContext context, LexerActionExecutor lexerActionExecutor)
			: base(state, alt, context, SemanticContext.NONE)
		{
			this.lexerActionExecutor = lexerActionExecutor;
			passedThroughNonGreedyDecision = false;
		}

		public LexerATNConfig(LexerATNConfig c, ATNState state)
			: base(c, state, c.context, c.semanticContext)
		{
			lexerActionExecutor = c.lexerActionExecutor;
			passedThroughNonGreedyDecision = checkNonGreedyDecision(c, state);
		}

		public LexerATNConfig(LexerATNConfig c, ATNState state, LexerActionExecutor lexerActionExecutor)
			: base(c, state, c.context, c.semanticContext)
		{
			this.lexerActionExecutor = lexerActionExecutor;
			passedThroughNonGreedyDecision = checkNonGreedyDecision(c, state);
		}

		public LexerATNConfig(LexerATNConfig c, ATNState state, PredictionContext context)
			: base(c, state, context, c.semanticContext)
		{
			lexerActionExecutor = c.lexerActionExecutor;
			passedThroughNonGreedyDecision = checkNonGreedyDecision(c, state);
		}

		public LexerActionExecutor getLexerActionExecutor()
		{
			return lexerActionExecutor;
		}

		public bool hasPassedThroughNonGreedyDecision()
		{
			return passedThroughNonGreedyDecision;
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Update(MurmurHash.Update(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(7), state.stateNumber), alt), context), semanticContext), passedThroughNonGreedyDecision ? 1 : 0), lexerActionExecutor), 6);
		}

		public override bool Equals(ATNConfig other)
		{
			if (this == other)
			{
				return true;
			}
			if (!(other is LexerATNConfig))
			{
				return false;
			}
			LexerATNConfig lexerATNConfig = (LexerATNConfig)other;
			if (passedThroughNonGreedyDecision != lexerATNConfig.passedThroughNonGreedyDecision)
			{
				return false;
			}
			if (!((lexerActionExecutor == null) ? (lexerATNConfig.lexerActionExecutor == null) : lexerActionExecutor.Equals(lexerATNConfig.lexerActionExecutor)))
			{
				return false;
			}
			return base.Equals(other);
		}

		private static bool checkNonGreedyDecision(LexerATNConfig source, ATNState target)
		{
			if (!source.passedThroughNonGreedyDecision)
			{
				if (target is DecisionState)
				{
					return ((DecisionState)target).nonGreedy;
				}
				return false;
			}
			return true;
		}
	}
}
