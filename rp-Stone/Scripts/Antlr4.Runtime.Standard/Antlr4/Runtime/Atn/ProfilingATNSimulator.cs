using System;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class ProfilingATNSimulator : ParserATNSimulator
	{
		protected readonly DecisionInfo[] decisions;

		protected int numDecisions;

		protected int sllStopIndex;

		protected int llStopIndex;

		protected int currentDecision;

		protected DFAState currentState;

		protected int conflictingAltResolvedBySLL;

		public ProfilingATNSimulator(Parser parser)
			: base(parser, parser.Interpreter.atn, parser.Interpreter.decisionToDFA, parser.Interpreter.getSharedContextCache())
		{
			numDecisions = atn.decisionToState.Count;
			decisions = new DecisionInfo[numDecisions];
			for (int i = 0; i < numDecisions; i++)
			{
				decisions[i] = new DecisionInfo(i);
			}
		}

		public override int AdaptivePredict(ITokenStream input, int decision, ParserRuleContext outerContext)
		{
			try
			{
				sllStopIndex = -1;
				llStopIndex = -1;
				currentDecision = decision;
				long num = DateTime.Now.ToFileTime();
				int result = base.AdaptivePredict(input, decision, outerContext);
				long num2 = DateTime.Now.ToFileTime();
				decisions[decision].timeInPrediction += num2 - num;
				decisions[decision].invocations++;
				int num3 = sllStopIndex - startIndex + 1;
				decisions[decision].SLL_TotalLook += num3;
				decisions[decision].SLL_MinLook = ((decisions[decision].SLL_MinLook == 0L) ? num3 : Math.Min(decisions[decision].SLL_MinLook, num3));
				if (num3 > decisions[decision].SLL_MaxLook)
				{
					decisions[decision].SLL_MaxLook = num3;
					decisions[decision].SLL_MaxLookEvent = new LookaheadEventInfo(decision, null, input, startIndex, sllStopIndex, fullCtx: false);
				}
				if (llStopIndex >= 0)
				{
					int num4 = llStopIndex - startIndex + 1;
					decisions[decision].LL_TotalLook += num4;
					decisions[decision].LL_MinLook = ((decisions[decision].LL_MinLook == 0L) ? num4 : Math.Min(decisions[decision].LL_MinLook, num4));
					if (num4 > decisions[decision].LL_MaxLook)
					{
						decisions[decision].LL_MaxLook = num4;
						decisions[decision].LL_MaxLookEvent = new LookaheadEventInfo(decision, null, input, startIndex, llStopIndex, fullCtx: true);
					}
				}
				return result;
			}
			finally
			{
				currentDecision = -1;
			}
		}

		protected override DFAState GetExistingTargetState(DFAState previousD, int t)
		{
			sllStopIndex = input.Index;
			DFAState existingTargetState = base.GetExistingTargetState(previousD, t);
			if (existingTargetState != null)
			{
				decisions[currentDecision].SLL_DFATransitions++;
				if (existingTargetState == ATNSimulator.ERROR)
				{
					decisions[currentDecision].errors.Add(new ErrorInfo(currentDecision, null, input, startIndex, sllStopIndex));
				}
			}
			currentState = existingTargetState;
			return existingTargetState;
		}

		protected override DFAState ComputeTargetState(DFA dfa, DFAState previousD, int t)
		{
			return currentState = base.ComputeTargetState(dfa, previousD, t);
		}

		protected override ATNConfigSet ComputeReachSet(ATNConfigSet closure, int t, bool fullCtx)
		{
			if (fullCtx)
			{
				llStopIndex = input.Index;
			}
			ATNConfigSet aTNConfigSet = base.ComputeReachSet(closure, t, fullCtx);
			if (fullCtx)
			{
				decisions[currentDecision].LL_ATNTransitions++;
				if (aTNConfigSet == null)
				{
					decisions[currentDecision].errors.Add(new ErrorInfo(currentDecision, null, input, startIndex, llStopIndex));
				}
			}
			else
			{
				decisions[currentDecision].SLL_ATNTransitions++;
				if (aTNConfigSet == null)
				{
					decisions[currentDecision].errors.Add(new ErrorInfo(currentDecision, null, input, startIndex, sllStopIndex));
				}
			}
			return aTNConfigSet;
		}

		protected override bool EvalSemanticContext(SemanticContext pred, ParserRuleContext parserCallStack, int alt, bool fullCtx)
		{
			bool flag = base.EvalSemanticContext(pred, parserCallStack, alt, fullCtx);
			if (!(pred is SemanticContext.PrecedencePredicate))
			{
				int stopIndex = ((llStopIndex >= 0) ? llStopIndex : sllStopIndex);
				decisions[currentDecision].predicateEvals.Add(new PredicateEvalInfo(null, currentDecision, input, startIndex, stopIndex, pred, flag, alt));
			}
			return flag;
		}

		protected override void ReportAttemptingFullContext(DFA dfa, BitSet conflictingAlts, ATNConfigSet configs, int startIndex, int stopIndex)
		{
			if (conflictingAlts != null)
			{
				conflictingAltResolvedBySLL = conflictingAlts.NextSetBit(0);
			}
			else
			{
				conflictingAltResolvedBySLL = configs.GetAlts().NextSetBit(0);
			}
			decisions[currentDecision].LL_Fallback++;
			base.ReportAttemptingFullContext(dfa, conflictingAlts, configs, startIndex, stopIndex);
		}

		protected override void ReportContextSensitivity(DFA dfa, int prediction, ATNConfigSet configs, int startIndex, int stopIndex)
		{
			if (prediction != conflictingAltResolvedBySLL)
			{
				decisions[currentDecision].contextSensitivities.Add(new ContextSensitivityInfo(currentDecision, null, input, startIndex, stopIndex));
			}
			base.ReportContextSensitivity(dfa, prediction, configs, startIndex, stopIndex);
		}

		protected override void ReportAmbiguity(DFA dfa, DFAState D, int startIndex, int stopIndex, bool exact, BitSet ambigAlts, ATNConfigSet configSet)
		{
			int num = ambigAlts?.NextSetBit(0) ?? configSet.GetAlts().NextSetBit(0);
			if (configSet.fullCtx && num != conflictingAltResolvedBySLL)
			{
				decisions[currentDecision].contextSensitivities.Add(new ContextSensitivityInfo(currentDecision, null, input, startIndex, stopIndex));
			}
			decisions[currentDecision].ambiguities.Add(new AmbiguityInfo(currentDecision, null, input, startIndex, stopIndex));
			base.ReportAmbiguity(dfa, D, startIndex, stopIndex, exact, ambigAlts, configSet);
		}

		public DecisionInfo[] getDecisionInfo()
		{
			return decisions;
		}

		public DFAState getCurrentState()
		{
			return currentState;
		}
	}
}
