using System;
using System.Collections.Generic;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class ParserATNSimulator : ATNSimulator
	{
		public static readonly bool debug;

		public static readonly bool debug_list_atn_decisions;

		public static readonly bool dfa_debug;

		public static readonly bool retry_debug;

		protected readonly Parser parser;

		public readonly DFA[] decisionToDFA;

		private PredictionMode mode = PredictionMode.LL;

		protected MergeCache mergeCache;

		protected ITokenStream input;

		protected int startIndex;

		protected ParserRuleContext context;

		protected DFA thisDfa;

		public PredictionMode PredictionMode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
			}
		}

		public ParserATNSimulator(ATN atn, DFA[] decisionToDFA, PredictionContextCache sharedContextCache)
			: this(null, atn, decisionToDFA, sharedContextCache)
		{
		}

		public ParserATNSimulator(Parser parser, ATN atn, DFA[] decisionToDFA, PredictionContextCache sharedContextCache)
			: base(atn, sharedContextCache)
		{
			this.parser = parser;
			this.decisionToDFA = decisionToDFA;
		}

		public override void Reset()
		{
		}

		public override void ClearDFA()
		{
			for (int i = 0; i < decisionToDFA.Length; i++)
			{
				decisionToDFA[i] = new DFA(atn.GetDecisionState(i), i);
			}
		}

		public virtual int AdaptivePredict(ITokenStream input, int decision, ParserRuleContext outerContext)
		{
			if (debug || debug_list_atn_decisions)
			{
				ConsoleWriteLine("adaptivePredict decision " + decision + " exec LA(1)==" + GetLookaheadName(input) + " line " + input.LT(1).Line + ":" + input.LT(1).Column);
			}
			this.input = input;
			startIndex = input.Index;
			context = outerContext;
			DFA dFA = (thisDfa = decisionToDFA[decision]);
			int marker = input.Mark();
			int index = startIndex;
			try
			{
				DFAState dFAState = ((!dFA.IsPrecedenceDfa) ? dFA.s0 : dFA.GetPrecedenceStartState(parser.Precedence));
				if (dFAState == null)
				{
					if (outerContext == null)
					{
						outerContext = ParserRuleContext.EmptyContext;
					}
					if (debug || debug_list_atn_decisions)
					{
						ConsoleWriteLine("predictATN decision " + dFA.decision + " exec LA(1)==" + GetLookaheadName(input) + ", outerContext=" + outerContext.ToString(parser));
					}
					bool fullCtx = false;
					ATNConfigSet aTNConfigSet = ComputeStartState(dFA.atnStartState, ParserRuleContext.EmptyContext, fullCtx);
					if (!dFA.IsPrecedenceDfa)
					{
						dFAState = (dFA.s0 = AddDFAState(dFA, new DFAState(aTNConfigSet)));
					}
					else
					{
						dFA.s0.configSet = aTNConfigSet;
						aTNConfigSet = ApplyPrecedenceFilter(aTNConfigSet);
						dFAState = AddDFAState(dFA, new DFAState(aTNConfigSet));
						dFA.SetPrecedenceStartState(parser.Precedence, dFAState);
					}
				}
				int result = ExecATN(dFA, dFAState, input, index, outerContext);
				if (debug)
				{
					ConsoleWriteLine("DFA after predictATN: " + dFA.ToString(parser.Vocabulary));
				}
				return result;
			}
			finally
			{
				mergeCache = null;
				thisDfa = null;
				input.Seek(index);
				input.Release(marker);
			}
		}

		protected int ExecATN(DFA dfa, DFAState s0, ITokenStream input, int startIndex, ParserRuleContext outerContext)
		{
			if (debug || debug_list_atn_decisions)
			{
				ConsoleWriteLine("execATN decision " + dfa.decision + " exec LA(1)==" + GetLookaheadName(input) + " line " + input.LT(1).Line + ":" + input.LT(1).Column);
			}
			DFAState dFAState = s0;
			if (debug)
			{
				ConsoleWriteLine("s0 = " + s0);
			}
			int num = input.LA(1);
			DFAState dFAState2;
			while (true)
			{
				dFAState2 = GetExistingTargetState(dFAState, num);
				if (dFAState2 == null)
				{
					dFAState2 = ComputeTargetState(dfa, dFAState, num);
				}
				if (dFAState2 == ATNSimulator.ERROR)
				{
					NoViableAltException ex = NoViableAlt(input, outerContext, dFAState.configSet, startIndex);
					input.Seek(startIndex);
					int synValidOrSemInvalidAltThatFinishedDecisionEntryRule = GetSynValidOrSemInvalidAltThatFinishedDecisionEntryRule(dFAState.configSet, outerContext);
					if (synValidOrSemInvalidAltThatFinishedDecisionEntryRule != 0)
					{
						return synValidOrSemInvalidAltThatFinishedDecisionEntryRule;
					}
					throw ex;
				}
				if (dFAState2.requiresFullContext && mode != PredictionMode.SLL)
				{
					BitSet bitSet = dFAState2.configSet.conflictingAlts;
					if (dFAState2.predicates != null)
					{
						if (debug)
						{
							ConsoleWriteLine("DFA state has preds in DFA sim LL failover");
						}
						int index = input.Index;
						if (index != startIndex)
						{
							input.Seek(startIndex);
						}
						bitSet = EvalSemanticContext(dFAState2.predicates, outerContext, complete: true);
						if (bitSet.Cardinality() == 1)
						{
							if (debug)
							{
								ConsoleWriteLine("Full LL avoided");
							}
							return bitSet.NextSetBit(0);
						}
						if (index != startIndex)
						{
							input.Seek(index);
						}
					}
					if (dfa_debug)
					{
						ConsoleWriteLine("ctx sensitive state " + outerContext?.ToString() + " in " + dFAState2);
					}
					bool fullCtx = true;
					ATNConfigSet s1 = ComputeStartState(dfa.atnStartState, outerContext, fullCtx);
					ReportAttemptingFullContext(dfa, bitSet, dFAState2.configSet, startIndex, input.Index);
					return ExecATNWithFullContext(dfa, dFAState2, s1, input, startIndex, outerContext);
				}
				if (dFAState2.isAcceptState)
				{
					break;
				}
				dFAState = dFAState2;
				if (num != -1)
				{
					input.Consume();
					num = input.LA(1);
				}
			}
			if (dFAState2.predicates == null)
			{
				return dFAState2.prediction;
			}
			int index2 = input.Index;
			input.Seek(startIndex);
			BitSet bitSet2 = EvalSemanticContext(dFAState2.predicates, outerContext, complete: true);
			switch (bitSet2.Cardinality())
			{
			case 0:
				throw NoViableAlt(input, outerContext, dFAState2.configSet, startIndex);
			case 1:
				return bitSet2.NextSetBit(0);
			default:
				ReportAmbiguity(dfa, dFAState2, startIndex, index2, exact: false, bitSet2, dFAState2.configSet);
				return bitSet2.NextSetBit(0);
			}
		}

		protected virtual DFAState GetExistingTargetState(DFAState previousD, int t)
		{
			DFAState[] edges = previousD.edges;
			if (edges == null || t + 1 < 0 || t + 1 >= edges.Length)
			{
				return null;
			}
			return edges[t + 1];
		}

		protected virtual DFAState ComputeTargetState(DFA dfa, DFAState previousD, int t)
		{
			ATNConfigSet aTNConfigSet = ComputeReachSet(previousD.configSet, t, fullCtx: false);
			if (aTNConfigSet == null)
			{
				AddDFAEdge(dfa, previousD, t, ATNSimulator.ERROR);
				return ATNSimulator.ERROR;
			}
			DFAState dFAState = new DFAState(aTNConfigSet);
			int uniqueAlt = GetUniqueAlt(aTNConfigSet);
			if (debug)
			{
				ICollection<BitSet> conflictingAltSubsets = PredictionMode.GetConflictingAltSubsets(aTNConfigSet.configs);
				ConsoleWriteLine("SLL altSubSets=" + conflictingAltSubsets?.ToString() + ", configs=" + aTNConfigSet?.ToString() + ", predict=" + uniqueAlt + ", allSubsetsConflict=" + PredictionMode.AllSubsetsConflict(conflictingAltSubsets) + ", conflictingAlts=" + GetConflictingAlts(aTNConfigSet));
			}
			if (uniqueAlt != 0)
			{
				dFAState.isAcceptState = true;
				dFAState.configSet.uniqueAlt = uniqueAlt;
				dFAState.prediction = uniqueAlt;
			}
			else if (PredictionMode.HasSLLConflictTerminatingPrediction(mode, aTNConfigSet))
			{
				dFAState.configSet.conflictingAlts = GetConflictingAlts(aTNConfigSet);
				dFAState.requiresFullContext = true;
				dFAState.isAcceptState = true;
				dFAState.prediction = dFAState.configSet.conflictingAlts.NextSetBit(0);
			}
			if (dFAState.isAcceptState && dFAState.configSet.hasSemanticContext)
			{
				PredicateDFAState(dFAState, atn.GetDecisionState(dfa.decision));
				if (dFAState.predicates != null)
				{
					dFAState.prediction = 0;
				}
			}
			return AddDFAEdge(dfa, previousD, t, dFAState);
		}

		protected void PredicateDFAState(DFAState dfaState, DecisionState decisionState)
		{
			int numberOfTransitions = decisionState.NumberOfTransitions;
			BitSet conflictingAltsOrUniqueAlt = GetConflictingAltsOrUniqueAlt(dfaState.configSet);
			SemanticContext[] predsForAmbigAlts = GetPredsForAmbigAlts(conflictingAltsOrUniqueAlt, dfaState.configSet, numberOfTransitions);
			if (predsForAmbigAlts != null)
			{
				dfaState.predicates = GetPredicatePredictions(conflictingAltsOrUniqueAlt, predsForAmbigAlts);
				dfaState.prediction = 0;
			}
			else
			{
				dfaState.prediction = conflictingAltsOrUniqueAlt.NextSetBit(0);
			}
		}

		protected int ExecATNWithFullContext(DFA dfa, DFAState D, ATNConfigSet s0, ITokenStream input, int startIndex, ParserRuleContext outerContext)
		{
			if (debug || debug_list_atn_decisions)
			{
				ConsoleWriteLine("execATNWithFullContext " + s0);
			}
			bool fullCtx = true;
			bool exact = false;
			ATNConfigSet aTNConfigSet = null;
			ATNConfigSet aTNConfigSet2 = s0;
			input.Seek(startIndex);
			int num = input.LA(1);
			int num2;
			while (true)
			{
				aTNConfigSet = ComputeReachSet(aTNConfigSet2, num, fullCtx);
				if (aTNConfigSet == null)
				{
					NoViableAltException ex = NoViableAlt(input, outerContext, aTNConfigSet2, startIndex);
					input.Seek(startIndex);
					int synValidOrSemInvalidAltThatFinishedDecisionEntryRule = GetSynValidOrSemInvalidAltThatFinishedDecisionEntryRule(aTNConfigSet2, outerContext);
					if (synValidOrSemInvalidAltThatFinishedDecisionEntryRule != 0)
					{
						return synValidOrSemInvalidAltThatFinishedDecisionEntryRule;
					}
					throw ex;
				}
				ICollection<BitSet> conflictingAltSubsets = PredictionMode.GetConflictingAltSubsets(aTNConfigSet.configs);
				if (debug)
				{
					ConsoleWriteLine("LL altSubSets=" + conflictingAltSubsets?.ToString() + ", predict=" + PredictionMode.GetUniqueAlt(conflictingAltSubsets) + ", ResolvesToJustOneViableAlt=" + PredictionMode.ResolvesToJustOneViableAlt(conflictingAltSubsets));
				}
				aTNConfigSet.uniqueAlt = GetUniqueAlt(aTNConfigSet);
				if (aTNConfigSet.uniqueAlt != 0)
				{
					num2 = aTNConfigSet.uniqueAlt;
					break;
				}
				if (mode != PredictionMode.LL_EXACT_AMBIG_DETECTION)
				{
					num2 = PredictionMode.ResolvesToJustOneViableAlt(conflictingAltSubsets);
					if (num2 != 0)
					{
						break;
					}
				}
				else if (PredictionMode.AllSubsetsConflict(conflictingAltSubsets) && PredictionMode.AllSubsetsEqual(conflictingAltSubsets))
				{
					exact = true;
					num2 = PredictionMode.GetSingleViableAlt(conflictingAltSubsets);
					break;
				}
				aTNConfigSet2 = aTNConfigSet;
				if (num != -1)
				{
					input.Consume();
					num = input.LA(1);
				}
			}
			if (aTNConfigSet.uniqueAlt != 0)
			{
				ReportContextSensitivity(dfa, num2, aTNConfigSet, startIndex, input.Index);
				return num2;
			}
			ReportAmbiguity(dfa, D, startIndex, input.Index, exact, aTNConfigSet.GetAlts(), aTNConfigSet);
			return num2;
		}

		protected virtual ATNConfigSet ComputeReachSet(ATNConfigSet closure, int t, bool fullCtx)
		{
			if (debug)
			{
				ConsoleWriteLine("in computeReachSet, starting closure: " + closure);
			}
			if (mergeCache == null)
			{
				mergeCache = new MergeCache();
			}
			ATNConfigSet aTNConfigSet = new ATNConfigSet(fullCtx);
			List<ATNConfig> list = null;
			foreach (ATNConfig config in closure.configs)
			{
				if (debug)
				{
					ConsoleWriteLine("testing " + GetTokenName(t) + " at " + config.ToString());
				}
				if (config.state is RuleStopState)
				{
					if (fullCtx || t == -1)
					{
						if (list == null)
						{
							list = new List<ATNConfig>();
						}
						list.Add(config);
					}
					continue;
				}
				int numberOfTransitions = config.state.NumberOfTransitions;
				for (int i = 0; i < numberOfTransitions; i++)
				{
					Transition trans = config.state.Transition(i);
					ATNState reachableTarget = GetReachableTarget(trans, t);
					if (reachableTarget != null)
					{
						aTNConfigSet.Add(new ATNConfig(config, reachableTarget), mergeCache);
					}
				}
			}
			ATNConfigSet aTNConfigSet2 = null;
			if (list == null && t != -1)
			{
				if (aTNConfigSet.Count == 1)
				{
					aTNConfigSet2 = aTNConfigSet;
				}
				else if (GetUniqueAlt(aTNConfigSet) != 0)
				{
					aTNConfigSet2 = aTNConfigSet;
				}
			}
			if (aTNConfigSet2 == null)
			{
				aTNConfigSet2 = new ATNConfigSet(fullCtx);
				HashSet<ATNConfig> closureBusy = new HashSet<ATNConfig>();
				bool treatEofAsEpsilon = t == -1;
				foreach (ATNConfig config2 in aTNConfigSet.configs)
				{
					Closure(config2, aTNConfigSet2, closureBusy, collectPredicates: false, fullCtx, treatEofAsEpsilon);
				}
			}
			if (t == -1)
			{
				aTNConfigSet2 = RemoveAllConfigsNotInRuleStopState(aTNConfigSet2, aTNConfigSet2 == aTNConfigSet);
			}
			if (list != null && (!fullCtx || !PredictionMode.HasConfigInRuleStopState(aTNConfigSet2.configs)))
			{
				foreach (ATNConfig item in list)
				{
					aTNConfigSet2.Add(item, mergeCache);
				}
			}
			if (aTNConfigSet2.Empty)
			{
				return null;
			}
			return aTNConfigSet2;
		}

		protected ATNConfigSet RemoveAllConfigsNotInRuleStopState(ATNConfigSet configSet, bool lookToEndOfRule)
		{
			if (PredictionMode.AllConfigsInRuleStopStates(configSet.configs))
			{
				return configSet;
			}
			ATNConfigSet aTNConfigSet = new ATNConfigSet(configSet.fullCtx);
			foreach (ATNConfig config in configSet.configs)
			{
				if (config.state is RuleStopState)
				{
					aTNConfigSet.Add(config, mergeCache);
				}
				else if (lookToEndOfRule && config.state.OnlyHasEpsilonTransitions && atn.NextTokens(config.state).Contains(-2))
				{
					ATNState state = atn.ruleToStopState[config.state.ruleIndex];
					aTNConfigSet.Add(new ATNConfig(config, state), mergeCache);
				}
			}
			return aTNConfigSet;
		}

		protected ATNConfigSet ComputeStartState(ATNState p, RuleContext ctx, bool fullCtx)
		{
			PredictionContext predictionContext = PredictionContext.FromRuleContext(atn, ctx);
			ATNConfigSet aTNConfigSet = new ATNConfigSet(fullCtx);
			for (int i = 0; i < p.NumberOfTransitions; i++)
			{
				ATNConfig config = new ATNConfig(p.Transition(i).target, i + 1, predictionContext);
				HashSet<ATNConfig> closureBusy = new HashSet<ATNConfig>();
				Closure(config, aTNConfigSet, closureBusy, collectPredicates: true, fullCtx, treatEofAsEpsilon: false);
			}
			return aTNConfigSet;
		}

		protected ATNConfigSet ApplyPrecedenceFilter(ATNConfigSet configSet)
		{
			Dictionary<int, PredictionContext> dictionary = new Dictionary<int, PredictionContext>();
			ATNConfigSet aTNConfigSet = new ATNConfigSet(configSet.fullCtx);
			foreach (ATNConfig config in configSet.configs)
			{
				if (config.alt != 1)
				{
					continue;
				}
				SemanticContext semanticContext = config.semanticContext.EvalPrecedence(parser, context);
				if (semanticContext != null)
				{
					dictionary[config.state.stateNumber] = config.context;
					if (semanticContext != config.semanticContext)
					{
						aTNConfigSet.Add(new ATNConfig(config, semanticContext), mergeCache);
					}
					else
					{
						aTNConfigSet.Add(config, mergeCache);
					}
				}
			}
			foreach (ATNConfig config2 in configSet.configs)
			{
				if (config2.alt != 1 && (config2.IsPrecedenceFilterSuppressed || !dictionary.TryGetValue(config2.state.stateNumber, out var value) || value == null || !value.Equals(config2.context)))
				{
					aTNConfigSet.Add(config2, mergeCache);
				}
			}
			return aTNConfigSet;
		}

		protected ATNState GetReachableTarget(Transition trans, int ttype)
		{
			if (trans.Matches(ttype, 0, atn.maxTokenType))
			{
				return trans.target;
			}
			return null;
		}

		protected SemanticContext[] GetPredsForAmbigAlts(BitSet ambigAlts, ATNConfigSet configSet, int nalts)
		{
			SemanticContext[] array = new SemanticContext[nalts + 1];
			foreach (ATNConfig config in configSet.configs)
			{
				if (ambigAlts[config.alt])
				{
					array[config.alt] = SemanticContext.OrOp(array[config.alt], config.semanticContext);
				}
			}
			int num = 0;
			for (int i = 1; i <= nalts; i++)
			{
				if (array[i] == null)
				{
					array[i] = SemanticContext.NONE;
				}
				else if (array[i] != SemanticContext.NONE)
				{
					num++;
				}
			}
			if (num == 0)
			{
				array = null;
			}
			if (debug)
			{
				ConsoleWriteLine("getPredsForAmbigAlts result " + Arrays.ToString(array));
			}
			return array;
		}

		protected PredPrediction[] GetPredicatePredictions(BitSet ambigAlts, SemanticContext[] altToPred)
		{
			List<PredPrediction> list = new List<PredPrediction>();
			bool flag = false;
			for (int i = 1; i < altToPred.Length; i++)
			{
				SemanticContext semanticContext = altToPred[i];
				if (ambigAlts != null && ambigAlts[i])
				{
					list.Add(new PredPrediction(semanticContext, i));
				}
				if (semanticContext != SemanticContext.NONE)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return null;
			}
			return list.ToArray();
		}

		protected int GetSynValidOrSemInvalidAltThatFinishedDecisionEntryRule(ATNConfigSet configs, ParserRuleContext outerContext)
		{
			Pair<ATNConfigSet, ATNConfigSet> pair = SplitAccordingToSemanticValidity(configs, outerContext);
			ATNConfigSet a = pair.a;
			ATNConfigSet b = pair.b;
			int altThatFinishedDecisionEntryRule = getAltThatFinishedDecisionEntryRule(a);
			if (altThatFinishedDecisionEntryRule != 0)
			{
				return altThatFinishedDecisionEntryRule;
			}
			if (b.Count > 0)
			{
				altThatFinishedDecisionEntryRule = getAltThatFinishedDecisionEntryRule(b);
				if (altThatFinishedDecisionEntryRule != 0)
				{
					return altThatFinishedDecisionEntryRule;
				}
			}
			return 0;
		}

		protected int getAltThatFinishedDecisionEntryRule(ATNConfigSet configSet)
		{
			IntervalSet intervalSet = new IntervalSet();
			foreach (ATNConfig config in configSet.configs)
			{
				if (config.OuterContextDepth > 0 || (config.state is RuleStopState && config.context.HasEmptyPath))
				{
					intervalSet.Add(config.alt);
				}
			}
			if (intervalSet.Count == 0)
			{
				return 0;
			}
			return intervalSet.MinElement;
		}

		protected Pair<ATNConfigSet, ATNConfigSet> SplitAccordingToSemanticValidity(ATNConfigSet configSet, ParserRuleContext outerContext)
		{
			ATNConfigSet aTNConfigSet = new ATNConfigSet(configSet.fullCtx);
			ATNConfigSet aTNConfigSet2 = new ATNConfigSet(configSet.fullCtx);
			foreach (ATNConfig config in configSet.configs)
			{
				if (config.semanticContext != SemanticContext.NONE)
				{
					if (EvalSemanticContext(config.semanticContext, outerContext, config.alt, configSet.fullCtx))
					{
						aTNConfigSet.Add(config);
					}
					else
					{
						aTNConfigSet2.Add(config);
					}
				}
				else
				{
					aTNConfigSet.Add(config);
				}
			}
			return new Pair<ATNConfigSet, ATNConfigSet>(aTNConfigSet, aTNConfigSet2);
		}

		protected virtual BitSet EvalSemanticContext(PredPrediction[] predPredictions, ParserRuleContext outerContext, bool complete)
		{
			BitSet bitSet = new BitSet();
			foreach (PredPrediction predPrediction in predPredictions)
			{
				if (predPrediction.pred == SemanticContext.NONE)
				{
					bitSet[predPrediction.alt] = true;
					if (!complete)
					{
						break;
					}
					continue;
				}
				bool fullCtx = false;
				bool flag = EvalSemanticContext(predPrediction.pred, outerContext, predPrediction.alt, fullCtx);
				if (debug || dfa_debug)
				{
					ConsoleWriteLine("eval pred " + predPrediction?.ToString() + "=" + flag);
				}
				if (flag)
				{
					if (debug || dfa_debug)
					{
						ConsoleWriteLine("PREDICT " + predPrediction.alt);
					}
					bitSet[predPrediction.alt] = true;
					if (!complete)
					{
						break;
					}
				}
			}
			return bitSet;
		}

		protected virtual bool EvalSemanticContext(SemanticContext pred, ParserRuleContext parserCallStack, int alt, bool fullCtx)
		{
			return pred.Eval(parser, parserCallStack);
		}

		protected void Closure(ATNConfig config, ATNConfigSet configs, HashSet<ATNConfig> closureBusy, bool collectPredicates, bool fullCtx, bool treatEofAsEpsilon)
		{
			int depth = 0;
			ClosureCheckingStopState(config, configs, closureBusy, collectPredicates, fullCtx, depth, treatEofAsEpsilon);
		}

		protected void ClosureCheckingStopState(ATNConfig config, ATNConfigSet configSet, HashSet<ATNConfig> closureBusy, bool collectPredicates, bool fullCtx, int depth, bool treatEofAsEpsilon)
		{
			if (debug)
			{
				ConsoleWriteLine("closure(" + config.ToString(parser, showAlt: true) + ")");
			}
			if (config.state is RuleStopState)
			{
				if (!config.context.IsEmpty)
				{
					for (int i = 0; i < config.context.Size; i++)
					{
						if (config.context.GetReturnState(i) == PredictionContext.EMPTY_RETURN_STATE)
						{
							if (fullCtx)
							{
								configSet.Add(new ATNConfig(config, config.state, PredictionContext.EMPTY), mergeCache);
								continue;
							}
							if (debug)
							{
								ConsoleWriteLine("FALLING off rule " + GetRuleName(config.state.ruleIndex));
							}
							Closure_(config, configSet, closureBusy, collectPredicates, fullCtx, depth, treatEofAsEpsilon);
						}
						else
						{
							ATNConfig aTNConfig = new ATNConfig(atn.states[config.context.GetReturnState(i)], context: config.context.GetParent(i), alt: config.alt, semanticContext: config.semanticContext);
							aTNConfig.reachesIntoOuterContext = config.OuterContextDepth;
							ClosureCheckingStopState(aTNConfig, configSet, closureBusy, collectPredicates, fullCtx, depth - 1, treatEofAsEpsilon);
						}
					}
					return;
				}
				if (fullCtx)
				{
					configSet.Add(config, mergeCache);
					return;
				}
				if (debug)
				{
					ConsoleWriteLine("FALLING off rule " + GetRuleName(config.state.ruleIndex));
				}
			}
			Closure_(config, configSet, closureBusy, collectPredicates, fullCtx, depth, treatEofAsEpsilon);
		}

		protected void Closure_(ATNConfig config, ATNConfigSet configs, HashSet<ATNConfig> closureBusy, bool collectPredicates, bool fullCtx, int depth, bool treatEofAsEpsilon)
		{
			ATNState state = config.state;
			if (!state.OnlyHasEpsilonTransitions)
			{
				configs.Add(config, mergeCache);
			}
			for (int i = 0; i < state.NumberOfTransitions; i++)
			{
				if (i == 0 && CanDropLoopEntryEdgeInLeftRecursiveRule(config))
				{
					continue;
				}
				Transition transition = state.Transition(i);
				bool collectPredicates2 = !(transition is ActionTransition) && collectPredicates;
				ATNConfig epsilonTarget = GetEpsilonTarget(config, transition, collectPredicates2, depth == 0, fullCtx, treatEofAsEpsilon);
				if (epsilonTarget == null)
				{
					continue;
				}
				int num = depth;
				if (config.state is RuleStopState)
				{
					if (thisDfa != null && thisDfa.IsPrecedenceDfa && ((EpsilonTransition)transition).OutermostPrecedenceReturn == thisDfa.atnStartState.ruleIndex)
					{
						epsilonTarget.SetPrecedenceFilterSuppressed(value: true);
					}
					epsilonTarget.reachesIntoOuterContext++;
					if (!closureBusy.Add(epsilonTarget))
					{
						continue;
					}
					configs.dipsIntoOuterContext = true;
					num--;
					if (debug)
					{
						ConsoleWriteLine("dips into outer ctx: " + epsilonTarget);
					}
				}
				else
				{
					if (!transition.IsEpsilon && !closureBusy.Add(epsilonTarget))
					{
						continue;
					}
					if (transition is RuleTransition && num >= 0)
					{
						num++;
					}
				}
				ClosureCheckingStopState(epsilonTarget, configs, closureBusy, collectPredicates2, fullCtx, num, treatEofAsEpsilon);
			}
		}

		protected bool CanDropLoopEntryEdgeInLeftRecursiveRule(ATNConfig config)
		{
			ATNState state = config.state;
			if (state.StateType != StateType.StarLoopEntry || !((StarLoopEntryState)state).isPrecedenceDecision || config.context.IsEmpty || config.context.HasEmptyPath)
			{
				return false;
			}
			int size = config.context.Size;
			for (int i = 0; i < size; i++)
			{
				if (atn.states[config.context.GetReturnState(i)].ruleIndex != state.ruleIndex)
				{
					return false;
				}
			}
			int stateNumber = ((BlockStartState)state.Transition(0).target).endState.stateNumber;
			BlockEndState blockEndState = (BlockEndState)atn.states[stateNumber];
			for (int j = 0; j < size; j++)
			{
				int returnState = config.context.GetReturnState(j);
				ATNState aTNState = atn.states[returnState];
				if (aTNState.NumberOfTransitions != 1 || !aTNState.Transition(0).IsEpsilon)
				{
					return false;
				}
				ATNState target = aTNState.Transition(0).target;
				if ((aTNState.StateType != StateType.BlockEnd || target != state) && aTNState != blockEndState && target != blockEndState && (target.StateType != StateType.BlockEnd || target.NumberOfTransitions != 1 || !target.Transition(0).IsEpsilon || target.Transition(0).target != state))
				{
					return false;
				}
			}
			return true;
		}

		public string GetRuleName(int index)
		{
			if (parser != null && index >= 0)
			{
				return parser.RuleNames[index];
			}
			return "<rule " + index + ">";
		}

		protected ATNConfig GetEpsilonTarget(ATNConfig config, Transition t, bool collectPredicates, bool inContext, bool fullCtx, bool treatEofAsEpsilon)
		{
			switch (t.TransitionType)
			{
			case TransitionType.RULE:
				return RuleTransition(config, (RuleTransition)t);
			case TransitionType.PRECEDENCE:
				return PrecedenceTransition(config, (PrecedencePredicateTransition)t, collectPredicates, inContext, fullCtx);
			case TransitionType.PREDICATE:
				return PredTransition(config, (PredicateTransition)t, collectPredicates, inContext, fullCtx);
			case TransitionType.ACTION:
				return ActionTransition(config, (ActionTransition)t);
			case TransitionType.EPSILON:
				return new ATNConfig(config, t.target);
			case TransitionType.RANGE:
			case TransitionType.ATOM:
			case TransitionType.SET:
				if (treatEofAsEpsilon && t.Matches(-1, 0, 1))
				{
					return new ATNConfig(config, t.target);
				}
				return null;
			default:
				return null;
			}
		}

		protected ATNConfig ActionTransition(ATNConfig config, ActionTransition t)
		{
			if (debug)
			{
				ConsoleWriteLine("ACTION edge " + t.ruleIndex + ":" + t.actionIndex);
			}
			return new ATNConfig(config, t.target);
		}

		public ATNConfig PrecedenceTransition(ATNConfig config, PrecedencePredicateTransition pt, bool collectPredicates, bool inContext, bool fullCtx)
		{
			if (debug)
			{
				ConsoleWriteLine("PRED (collectPredicates=" + collectPredicates + ") " + pt.precedence + ">=_p, ctx dependent=true");
				if (parser != null)
				{
					ConsoleWriteLine("context surrounding pred is " + parser.GetRuleInvocationStack());
				}
			}
			ATNConfig aTNConfig = null;
			if (collectPredicates && inContext)
			{
				if (fullCtx)
				{
					int index = input.Index;
					input.Seek(startIndex);
					bool num = EvalSemanticContext(pt.Predicate, context, config.alt, fullCtx);
					input.Seek(index);
					if (num)
					{
						aTNConfig = new ATNConfig(config, pt.target);
					}
				}
				else
				{
					SemanticContext semanticContext = SemanticContext.AndOp(config.semanticContext, pt.Predicate);
					aTNConfig = new ATNConfig(config, pt.target, semanticContext);
				}
			}
			else
			{
				aTNConfig = new ATNConfig(config, pt.target);
			}
			if (debug)
			{
				ConsoleWriteLine("config from pred transition=" + aTNConfig);
			}
			return aTNConfig;
		}

		protected ATNConfig PredTransition(ATNConfig config, PredicateTransition pt, bool collectPredicates, bool inContext, bool fullCtx)
		{
			if (debug)
			{
				ConsoleWriteLine("PRED (collectPredicates=" + collectPredicates + ") " + pt.ruleIndex + ":" + pt.predIndex + ", ctx dependent=" + pt.isCtxDependent);
				if (parser != null)
				{
					ConsoleWriteLine("context surrounding pred is " + parser.GetRuleInvocationStack());
				}
			}
			ATNConfig aTNConfig = null;
			if (collectPredicates && (!pt.isCtxDependent || (pt.isCtxDependent && inContext)))
			{
				if (fullCtx)
				{
					int index = input.Index;
					input.Seek(startIndex);
					bool num = EvalSemanticContext(pt.Predicate, context, config.alt, fullCtx);
					input.Seek(index);
					if (num)
					{
						aTNConfig = new ATNConfig(config, pt.target);
					}
				}
				else
				{
					SemanticContext semanticContext = SemanticContext.AndOp(config.semanticContext, pt.Predicate);
					aTNConfig = new ATNConfig(config, pt.target, semanticContext);
				}
			}
			else
			{
				aTNConfig = new ATNConfig(config, pt.target);
			}
			if (debug)
			{
				ConsoleWriteLine("config from pred transition=" + aTNConfig);
			}
			return aTNConfig;
		}

		protected ATNConfig RuleTransition(ATNConfig config, RuleTransition t)
		{
			if (debug)
			{
				ConsoleWriteLine("CALL rule " + GetRuleName(t.target.ruleIndex) + ", ctx=" + config.context);
			}
			ATNState followState = t.followState;
			PredictionContext predictionContext = SingletonPredictionContext.Create(config.context, followState.stateNumber);
			return new ATNConfig(config, t.target, predictionContext);
		}

		protected BitSet GetConflictingAlts(ATNConfigSet configSet)
		{
			return PredictionMode.GetAlts(PredictionMode.GetConflictingAltSubsets(configSet.configs));
		}

		protected BitSet GetConflictingAltsOrUniqueAlt(ATNConfigSet configSet)
		{
			BitSet bitSet;
			if (configSet.uniqueAlt != 0)
			{
				bitSet = new BitSet();
				bitSet[configSet.uniqueAlt] = true;
			}
			else
			{
				bitSet = configSet.conflictingAlts;
			}
			return bitSet;
		}

		public string GetTokenName(int t)
		{
			if (t == -1)
			{
				return "EOF";
			}
			IVocabulary vocabulary;
			if (parser == null)
			{
				IVocabulary emptyVocabulary = Vocabulary.EmptyVocabulary;
				vocabulary = emptyVocabulary;
			}
			else
			{
				vocabulary = parser.Vocabulary;
			}
			string displayName = vocabulary.GetDisplayName(t);
			if (displayName.Equals(t.ToString()))
			{
				return displayName;
			}
			return displayName + "<" + t + ">";
		}

		public string GetLookaheadName(ITokenStream input)
		{
			return GetTokenName(input.LA(1));
		}

		public void DumpDeadEndConfigs(NoViableAltException nvae)
		{
			Console.Error.WriteLine("dead end configs: ");
			foreach (ATNConfig config in nvae.DeadEndConfigs.configs)
			{
				string text = "no edges";
				if (config.state.NumberOfTransitions > 0)
				{
					Transition transition = config.state.Transition(0);
					if (transition is AtomTransition)
					{
						AtomTransition atomTransition = (AtomTransition)transition;
						text = "Atom " + GetTokenName(atomTransition.token);
					}
					else if (transition is SetTransition)
					{
						SetTransition setTransition = (SetTransition)transition;
						text = ((setTransition is NotSetTransition) ? "~" : "") + "Set " + setTransition.set.ToString();
					}
				}
				Console.Error.WriteLine(config.ToString(parser, showAlt: true) + ":" + text);
			}
		}

		protected NoViableAltException NoViableAlt(ITokenStream input, ParserRuleContext outerContext, ATNConfigSet configs, int startIndex)
		{
			return new NoViableAltException(parser, input, input.Get(startIndex), input.LT(1), configs, outerContext);
		}

		protected static int GetUniqueAlt(ATNConfigSet configSet)
		{
			int num = 0;
			foreach (ATNConfig config in configSet.configs)
			{
				if (num == 0)
				{
					num = config.alt;
				}
				else if (config.alt != num)
				{
					return 0;
				}
			}
			return num;
		}

		protected DFAState AddDFAEdge(DFA dfa, DFAState from, int t, DFAState to)
		{
			if (debug)
			{
				ConsoleWriteLine("EDGE " + from?.ToString() + " -> " + to?.ToString() + " upon " + GetTokenName(t));
			}
			if (to == null)
			{
				return null;
			}
			to = AddDFAState(dfa, to);
			if (from == null || t < -1 || t > atn.maxTokenType)
			{
				return to;
			}
			lock (from)
			{
				if (from.edges == null)
				{
					from.edges = new DFAState[atn.maxTokenType + 1 + 1];
				}
				from.edges[t + 1] = to;
			}
			if (debug)
			{
				IVocabulary vocabulary;
				if (parser == null)
				{
					IVocabulary emptyVocabulary = Vocabulary.EmptyVocabulary;
					vocabulary = emptyVocabulary;
				}
				else
				{
					vocabulary = parser.Vocabulary;
				}
				ConsoleWriteLine("DFA=\n" + dfa.ToString(vocabulary));
			}
			return to;
		}

		protected DFAState AddDFAState(DFA dfa, DFAState D)
		{
			if (D == ATNSimulator.ERROR)
			{
				return D;
			}
			lock (dfa.states)
			{
				DFAState dFAState = dfa.states.Get(D);
				if (dFAState != null)
				{
					return dFAState;
				}
				D.stateNumber = dfa.states.Count;
				if (!D.configSet.IsReadOnly)
				{
					D.configSet.OptimizeConfigs(this);
					D.configSet.IsReadOnly = true;
				}
				dfa.states.Put(D, D);
				if (debug)
				{
					ConsoleWriteLine("adding new DFA state: " + D);
				}
				return D;
			}
		}

		protected virtual void ReportAttemptingFullContext(DFA dfa, BitSet conflictingAlts, ATNConfigSet configs, int startIndex, int stopIndex)
		{
			if (debug || retry_debug)
			{
				Interval interval = Interval.Of(startIndex, stopIndex);
				ConsoleWriteLine("reportAttemptingFullContext decision=" + dfa.decision + ":" + configs?.ToString() + ", input=" + parser.TokenStream.GetText(interval));
			}
			if (parser != null)
			{
				parser.ErrorListenerDispatch.ReportAttemptingFullContext(parser, dfa, startIndex, stopIndex, conflictingAlts, null);
			}
		}

		protected virtual void ReportContextSensitivity(DFA dfa, int prediction, ATNConfigSet configs, int startIndex, int stopIndex)
		{
			if (debug || retry_debug)
			{
				Interval interval = Interval.Of(startIndex, stopIndex);
				ConsoleWriteLine("ReportContextSensitivity decision=" + dfa.decision + ":" + configs?.ToString() + ", input=" + parser.TokenStream.GetText(interval));
			}
			if (parser != null)
			{
				parser.ErrorListenerDispatch.ReportContextSensitivity(parser, dfa, startIndex, stopIndex, prediction, null);
			}
		}

		protected virtual void ReportAmbiguity(DFA dfa, DFAState D, int startIndex, int stopIndex, bool exact, BitSet ambigAlts, ATNConfigSet configs)
		{
			if (debug || retry_debug)
			{
				Interval interval = Interval.Of(startIndex, stopIndex);
				ConsoleWriteLine("ReportAmbiguity " + ambigAlts?.ToString() + ":" + configs?.ToString() + ", input=" + parser.TokenStream.GetText(interval));
			}
			if (parser != null)
			{
				parser.ErrorListenerDispatch.ReportAmbiguity(parser, dfa, startIndex, stopIndex, exact, ambigAlts, configs);
			}
		}

		public Parser getParser()
		{
			return parser;
		}
	}
}
