using System.Text;
using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public class ATNConfig
	{
		private static readonly int SUPPRESS_PRECEDENCE_FILTER = 1073741824;

		public readonly ATNState state;

		public readonly int alt;

		public PredictionContext context;

		public int reachesIntoOuterContext;

		public readonly SemanticContext semanticContext;

		public int OuterContextDepth => reachesIntoOuterContext & ~SUPPRESS_PRECEDENCE_FILTER;

		public bool IsPrecedenceFilterSuppressed => (reachesIntoOuterContext & SUPPRESS_PRECEDENCE_FILTER) != 0;

		public ATNConfig(ATNConfig old)
		{
			state = old.state;
			alt = old.alt;
			context = old.context;
			semanticContext = old.semanticContext;
			reachesIntoOuterContext = old.reachesIntoOuterContext;
		}

		public ATNConfig(ATNState state, int alt, PredictionContext context)
			: this(state, alt, context, SemanticContext.NONE)
		{
		}

		public ATNConfig(ATNState state, int alt, PredictionContext context, SemanticContext semanticContext)
		{
			this.state = state;
			this.alt = alt;
			this.context = context;
			this.semanticContext = semanticContext;
		}

		public ATNConfig(ATNConfig c, ATNState state)
			: this(c, state, c.context, c.semanticContext)
		{
		}

		public ATNConfig(ATNConfig c, ATNState state, SemanticContext semanticContext)
			: this(c, state, c.context, semanticContext)
		{
		}

		public ATNConfig(ATNConfig c, SemanticContext semanticContext)
			: this(c, c.state, c.context, semanticContext)
		{
		}

		public ATNConfig(ATNConfig c, ATNState state, PredictionContext context)
			: this(c, state, context, c.semanticContext)
		{
		}

		public ATNConfig(ATNConfig c, ATNState state, PredictionContext context, SemanticContext semanticContext)
		{
			this.state = state;
			alt = c.alt;
			this.context = context;
			this.semanticContext = semanticContext;
			reachesIntoOuterContext = c.reachesIntoOuterContext;
		}

		public void SetPrecedenceFilterSuppressed(bool value)
		{
			if (value)
			{
				reachesIntoOuterContext |= SUPPRESS_PRECEDENCE_FILTER;
			}
			else
			{
				reachesIntoOuterContext &= ~SUPPRESS_PRECEDENCE_FILTER;
			}
		}

		public override bool Equals(object o)
		{
			if (!(o is ATNConfig))
			{
				return false;
			}
			return Equals((ATNConfig)o);
		}

		public virtual bool Equals(ATNConfig other)
		{
			if (this == other)
			{
				return true;
			}
			if (other == null)
			{
				return false;
			}
			if (state.stateNumber == other.state.stateNumber && alt == other.alt && (context == other.context || (context != null && context.Equals(other.context))) && semanticContext.Equals(other.semanticContext))
			{
				return IsPrecedenceFilterSuppressed == other.IsPrecedenceFilterSuppressed;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(7), state.stateNumber), alt), context), semanticContext), 4);
		}

		public override string ToString()
		{
			return ToString(null, showAlt: true);
		}

		public string ToString(IRecognizer recog, bool showAlt)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('(');
			stringBuilder.Append(state);
			if (showAlt)
			{
				stringBuilder.Append(",");
				stringBuilder.Append(alt);
			}
			if (context != null)
			{
				stringBuilder.Append(",[");
				stringBuilder.Append(context.ToString());
				stringBuilder.Append("]");
			}
			if (semanticContext != null && semanticContext != SemanticContext.NONE)
			{
				stringBuilder.Append(",");
				stringBuilder.Append(semanticContext);
			}
			if (OuterContextDepth > 0)
			{
				stringBuilder.Append(",up=").Append(OuterContextDepth);
			}
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}
	}
}
