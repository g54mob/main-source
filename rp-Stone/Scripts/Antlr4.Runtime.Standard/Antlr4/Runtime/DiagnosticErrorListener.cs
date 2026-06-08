using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime
{
	public class DiagnosticErrorListener : BaseErrorListener
	{
		protected internal readonly bool exactOnly;

		public DiagnosticErrorListener()
			: this(exactOnly: true)
		{
		}

		public DiagnosticErrorListener(bool exactOnly)
		{
			this.exactOnly = exactOnly;
		}

		public override void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact, BitSet ambigAlts, ATNConfigSet configs)
		{
			if (!exactOnly || exact)
			{
				string decisionDescription = GetDecisionDescription(recognizer, dfa);
				BitSet conflictingAlts = GetConflictingAlts(ambigAlts, configs);
				string text = ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex));
				string msg = $"reportAmbiguity d={decisionDescription}: ambigAlts={conflictingAlts}, input='{text}'";
				recognizer.NotifyErrorListeners(msg);
			}
		}

		public override void ReportAttemptingFullContext(Parser recognizer, DFA dfa, int startIndex, int stopIndex, BitSet conflictingAlts, SimulatorState conflictState)
		{
			string decisionDescription = GetDecisionDescription(recognizer, dfa);
			string text = ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex));
			string msg = $"reportAttemptingFullContext d={decisionDescription}, input='{text}'";
			recognizer.NotifyErrorListeners(msg);
		}

		public override void ReportContextSensitivity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, int prediction, SimulatorState acceptState)
		{
			string decisionDescription = GetDecisionDescription(recognizer, dfa);
			string text = ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex));
			string msg = $"reportContextSensitivity d={decisionDescription}, input='{text}'";
			recognizer.NotifyErrorListeners(msg);
		}

		protected internal virtual string GetDecisionDescription(Parser recognizer, DFA dfa)
		{
			int decision = dfa.decision;
			int ruleIndex = dfa.atnStartState.ruleIndex;
			string[] ruleNames = recognizer.RuleNames;
			if (ruleIndex < 0 || ruleIndex >= ruleNames.Length)
			{
				return decision.ToString();
			}
			string text = ruleNames[ruleIndex];
			if (string.IsNullOrEmpty(text))
			{
				return decision.ToString();
			}
			return $"{decision} ({text})";
		}

		[return: NotNull]
		protected internal virtual BitSet GetConflictingAlts(BitSet reportedAlts, ATNConfigSet configSet)
		{
			if (reportedAlts != null)
			{
				return reportedAlts;
			}
			BitSet bitSet = new BitSet();
			foreach (ATNConfig config in configSet.configs)
			{
				bitSet.Set(config.alt);
			}
			return bitSet;
		}
	}
}
