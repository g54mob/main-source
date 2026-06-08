using System;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public class LexerATNSimulator : ATNSimulator
	{
		public readonly bool debug;

		public readonly bool dfa_debug;

		public static readonly int MIN_DFA_EDGE = 0;

		public static readonly int MAX_DFA_EDGE = 127;

		protected readonly Lexer recog;

		protected int startIndex = -1;

		protected int thisLine = 1;

		protected int charPositionInLine;

		public readonly DFA[] decisionToDFA;

		protected int mode;

		private readonly SimState prevAccept = new SimState();

		public static int match_calls = 0;

		public int Line
		{
			get
			{
				return thisLine;
			}
			set
			{
				thisLine = value;
			}
		}

		public int Column
		{
			get
			{
				return charPositionInLine;
			}
			set
			{
				charPositionInLine = value;
			}
		}

		public LexerATNSimulator(ATN atn, DFA[] decisionToDFA, PredictionContextCache sharedContextCache)
			: this(null, atn, decisionToDFA, sharedContextCache)
		{
		}

		public LexerATNSimulator(Lexer recog, ATN atn, DFA[] decisionToDFA, PredictionContextCache sharedContextCache)
			: base(atn, sharedContextCache)
		{
			this.decisionToDFA = decisionToDFA;
			this.recog = recog;
		}

		public void CopyState(LexerATNSimulator simulator)
		{
			charPositionInLine = simulator.charPositionInLine;
			thisLine = simulator.thisLine;
			mode = simulator.mode;
			startIndex = simulator.startIndex;
		}

		public int Match(ICharStream input, int mode)
		{
			match_calls++;
			this.mode = mode;
			int marker = input.Mark();
			try
			{
				startIndex = input.Index;
				prevAccept.Reset();
				DFA dFA = decisionToDFA[mode];
				if (dFA.s0 == null)
				{
					return MatchATN(input);
				}
				return ExecATN(input, dFA.s0);
			}
			finally
			{
				input.Release(marker);
			}
		}

		public override void Reset()
		{
			prevAccept.Reset();
			startIndex = -1;
			thisLine = 1;
			charPositionInLine = 0;
			mode = 0;
		}

		public override void ClearDFA()
		{
			for (int i = 0; i < decisionToDFA.Length; i++)
			{
				decisionToDFA[i] = new DFA(atn.GetDecisionState(i), i);
			}
		}

		protected int MatchATN(ICharStream input)
		{
			ATNState aTNState = atn.modeToStartState[mode];
			if (debug)
			{
				ConsoleWriteLine("matchATN mode " + mode + " start: " + aTNState);
			}
			int num = mode;
			ATNConfigSet aTNConfigSet = ComputeStartState(input, aTNState);
			bool hasSemanticContext = aTNConfigSet.hasSemanticContext;
			aTNConfigSet.hasSemanticContext = false;
			DFAState dFAState = AddDFAState(aTNConfigSet);
			if (!hasSemanticContext)
			{
				decisionToDFA[mode].s0 = dFAState;
			}
			int result = ExecATN(input, dFAState);
			if (debug)
			{
				ConsoleWriteLine("DFA after matchATN: " + decisionToDFA[num].ToString());
			}
			return result;
		}

		protected int ExecATN(ICharStream input, DFAState ds0)
		{
			if (debug)
			{
				ConsoleWriteLine("start state closure=" + ds0.configSet);
			}
			if (ds0.isAcceptState)
			{
				CaptureSimState(prevAccept, input, ds0);
			}
			int num = input.LA(1);
			DFAState dFAState = ds0;
			while (true)
			{
				if (debug)
				{
					ConsoleWriteLine("execATN loop starting closure: " + dFAState.configSet);
				}
				DFAState dFAState2 = GetExistingTargetState(dFAState, num);
				if (dFAState2 == null)
				{
					dFAState2 = ComputeTargetState(input, dFAState, num);
				}
				if (dFAState2 == ATNSimulator.ERROR)
				{
					break;
				}
				if (num != -1)
				{
					Consume(input);
				}
				if (dFAState2.isAcceptState)
				{
					CaptureSimState(prevAccept, input, dFAState2);
					if (num == -1)
					{
						break;
					}
				}
				num = input.LA(1);
				dFAState = dFAState2;
			}
			return FailOrAccept(prevAccept, input, dFAState.configSet, num);
		}

		protected DFAState GetExistingTargetState(DFAState s, int t)
		{
			if (s.edges == null || t < MIN_DFA_EDGE || t > MAX_DFA_EDGE)
			{
				return null;
			}
			DFAState dFAState = s.edges[t - MIN_DFA_EDGE];
			if (debug && dFAState != null)
			{
				ConsoleWriteLine("reuse state " + s.stateNumber + " edge to " + dFAState.stateNumber);
			}
			return dFAState;
		}

		protected DFAState ComputeTargetState(ICharStream input, DFAState s, int t)
		{
			ATNConfigSet aTNConfigSet = new OrderedATNConfigSet();
			GetReachableConfigSet(input, s.configSet, aTNConfigSet, t);
			if (aTNConfigSet.Empty)
			{
				if (!aTNConfigSet.hasSemanticContext)
				{
					AddDFAEdge(s, t, ATNSimulator.ERROR);
				}
				return ATNSimulator.ERROR;
			}
			return AddDFAEdge(s, t, aTNConfigSet);
		}

		protected int FailOrAccept(SimState prevAccept, ICharStream input, ATNConfigSet reach, int t)
		{
			if (prevAccept.dfaState != null)
			{
				LexerActionExecutor lexerActionExecutor = prevAccept.dfaState.lexerActionExecutor;
				Accept(input, lexerActionExecutor, startIndex, prevAccept.index, prevAccept.line, prevAccept.charPos);
				return prevAccept.dfaState.prediction;
			}
			if (t == -1 && input.Index == startIndex)
			{
				return -1;
			}
			throw new LexerNoViableAltException(recog, input, startIndex, reach);
		}

		protected void GetReachableConfigSet(ICharStream input, ATNConfigSet closure, ATNConfigSet reach, int t)
		{
			int num = 0;
			foreach (ATNConfig config in closure.configs)
			{
				bool flag = config.alt == num;
				if (flag && ((LexerATNConfig)config).hasPassedThroughNonGreedyDecision())
				{
					continue;
				}
				if (debug)
				{
					ConsoleWriteLine("testing " + GetTokenName(t) + " at " + config.ToString(recog, showAlt: true));
				}
				int numberOfTransitions = config.state.NumberOfTransitions;
				for (int i = 0; i < numberOfTransitions; i++)
				{
					Transition trans = config.state.Transition(i);
					ATNState reachableTarget = GetReachableTarget(trans, t);
					if (reachableTarget != null)
					{
						LexerActionExecutor lexerActionExecutor = ((LexerATNConfig)config).getLexerActionExecutor();
						if (lexerActionExecutor != null)
						{
							lexerActionExecutor = lexerActionExecutor.FixOffsetBeforeMatch(input.Index - startIndex);
						}
						bool treatEofAsEpsilon = t == -1;
						if (Closure(input, new LexerATNConfig((LexerATNConfig)config, reachableTarget, lexerActionExecutor), reach, flag, speculative: true, treatEofAsEpsilon))
						{
							num = config.alt;
							break;
						}
					}
				}
			}
		}

		protected void Accept(ICharStream input, LexerActionExecutor lexerActionExecutor, int startIndex, int index, int line, int charPos)
		{
			if (debug)
			{
				ConsoleWriteLine("ACTION " + lexerActionExecutor);
			}
			input.Seek(index);
			thisLine = line;
			charPositionInLine = charPos;
			if (lexerActionExecutor != null && recog != null)
			{
				lexerActionExecutor.Execute(recog, input, startIndex);
			}
		}

		protected ATNState GetReachableTarget(Transition trans, int t)
		{
			if (trans.Matches(t, 0, 1114111))
			{
				return trans.target;
			}
			return null;
		}

		protected ATNConfigSet ComputeStartState(ICharStream input, ATNState p)
		{
			PredictionContext eMPTY = PredictionContext.EMPTY;
			ATNConfigSet aTNConfigSet = new OrderedATNConfigSet();
			for (int i = 0; i < p.NumberOfTransitions; i++)
			{
				LexerATNConfig config = new LexerATNConfig(p.Transition(i).target, i + 1, eMPTY);
				Closure(input, config, aTNConfigSet, currentAltReachedAcceptState: false, speculative: false, treatEofAsEpsilon: false);
			}
			return aTNConfigSet;
		}

		protected bool Closure(ICharStream input, LexerATNConfig config, ATNConfigSet configs, bool currentAltReachedAcceptState, bool speculative, bool treatEofAsEpsilon)
		{
			if (debug)
			{
				ConsoleWriteLine("closure(" + config.ToString(recog, showAlt: true) + ")");
			}
			if (config.state is RuleStopState)
			{
				if (debug)
				{
					if (recog != null)
					{
						ConsoleWriteLine("closure at " + recog.RuleNames[config.state.ruleIndex] + " rule stop " + config);
					}
					else
					{
						ConsoleWriteLine("closure at rule stop " + config);
					}
				}
				if (config.context == null || config.context.HasEmptyPath)
				{
					if (config.context == null || config.context.IsEmpty)
					{
						configs.Add(config);
						return true;
					}
					configs.Add(new LexerATNConfig(config, config.state, PredictionContext.EMPTY));
					currentAltReachedAcceptState = true;
				}
				if (config.context != null && !config.context.IsEmpty)
				{
					for (int i = 0; i < config.context.Size; i++)
					{
						if (config.context.GetReturnState(i) != PredictionContext.EMPTY_RETURN_STATE)
						{
							PredictionContext parent = config.context.GetParent(i);
							ATNState state = atn.states[config.context.GetReturnState(i)];
							LexerATNConfig config2 = new LexerATNConfig(config, state, parent);
							currentAltReachedAcceptState = Closure(input, config2, configs, currentAltReachedAcceptState, speculative, treatEofAsEpsilon);
						}
					}
				}
				return currentAltReachedAcceptState;
			}
			if (!config.state.OnlyHasEpsilonTransitions && (!currentAltReachedAcceptState || !config.hasPassedThroughNonGreedyDecision()))
			{
				configs.Add(config);
			}
			ATNState state2 = config.state;
			for (int j = 0; j < state2.NumberOfTransitions; j++)
			{
				Transition t = state2.Transition(j);
				LexerATNConfig epsilonTarget = GetEpsilonTarget(input, config, t, configs, speculative, treatEofAsEpsilon);
				if (epsilonTarget != null)
				{
					currentAltReachedAcceptState = Closure(input, epsilonTarget, configs, currentAltReachedAcceptState, speculative, treatEofAsEpsilon);
				}
			}
			return currentAltReachedAcceptState;
		}

		protected LexerATNConfig GetEpsilonTarget(ICharStream input, LexerATNConfig config, Transition t, ATNConfigSet configs, bool speculative, bool treatEofAsEpsilon)
		{
			LexerATNConfig result = null;
			switch (t.TransitionType)
			{
			case TransitionType.RULE:
			{
				RuleTransition ruleTransition = (RuleTransition)t;
				PredictionContext context = new SingletonPredictionContext(config.context, ruleTransition.followState.stateNumber);
				result = new LexerATNConfig(config, t.target, context);
				break;
			}
			case TransitionType.PRECEDENCE:
				throw new Exception("Precedence predicates are not supported in lexers.");
			case TransitionType.PREDICATE:
			{
				PredicateTransition predicateTransition = (PredicateTransition)t;
				if (debug)
				{
					ConsoleWriteLine("EVAL rule " + predicateTransition.ruleIndex + ":" + predicateTransition.predIndex);
				}
				configs.hasSemanticContext = true;
				if (EvaluatePredicate(input, predicateTransition.ruleIndex, predicateTransition.predIndex, speculative))
				{
					result = new LexerATNConfig(config, t.target);
				}
				break;
			}
			case TransitionType.ACTION:
				if (config.context == null || config.context.HasEmptyPath)
				{
					LexerActionExecutor lexerActionExecutor = LexerActionExecutor.Append(config.getLexerActionExecutor(), atn.lexerActions[((ActionTransition)t).actionIndex]);
					result = new LexerATNConfig(config, t.target, lexerActionExecutor);
				}
				else
				{
					result = new LexerATNConfig(config, t.target);
				}
				break;
			case TransitionType.EPSILON:
				result = new LexerATNConfig(config, t.target);
				break;
			case TransitionType.RANGE:
			case TransitionType.ATOM:
			case TransitionType.SET:
				if (treatEofAsEpsilon && t.Matches(-1, 0, 1114111))
				{
					result = new LexerATNConfig(config, t.target);
				}
				break;
			}
			return result;
		}

		protected bool EvaluatePredicate(ICharStream input, int ruleIndex, int predIndex, bool speculative)
		{
			if (recog == null)
			{
				return true;
			}
			if (!speculative)
			{
				return recog.Sempred(null, ruleIndex, predIndex);
			}
			int num = charPositionInLine;
			int num2 = thisLine;
			int index = input.Index;
			int marker = input.Mark();
			try
			{
				Consume(input);
				return recog.Sempred(null, ruleIndex, predIndex);
			}
			finally
			{
				charPositionInLine = num;
				thisLine = num2;
				input.Seek(index);
				input.Release(marker);
			}
		}

		protected void CaptureSimState(SimState settings, ICharStream input, DFAState dfaState)
		{
			settings.index = input.Index;
			settings.line = thisLine;
			settings.charPos = charPositionInLine;
			settings.dfaState = dfaState;
		}

		protected DFAState AddDFAEdge(DFAState from, int t, ATNConfigSet q)
		{
			bool hasSemanticContext = q.hasSemanticContext;
			q.hasSemanticContext = false;
			DFAState dFAState = AddDFAState(q);
			if (hasSemanticContext)
			{
				return dFAState;
			}
			AddDFAEdge(from, t, dFAState);
			return dFAState;
		}

		protected void AddDFAEdge(DFAState p, int t, DFAState q)
		{
			if (t < MIN_DFA_EDGE || t > MAX_DFA_EDGE)
			{
				return;
			}
			if (debug)
			{
				ConsoleWriteLine("EDGE " + p?.ToString() + " -> " + q?.ToString() + " upon " + (char)t);
			}
			lock (p)
			{
				if (p.edges == null)
				{
					p.edges = new DFAState[MAX_DFA_EDGE - MIN_DFA_EDGE + 1];
				}
				p.edges[t - MIN_DFA_EDGE] = q;
			}
		}

		protected DFAState AddDFAState(ATNConfigSet configSet)
		{
			DFAState dFAState = new DFAState(configSet);
			ATNConfig aTNConfig = null;
			foreach (ATNConfig config in configSet.configs)
			{
				if (config.state is RuleStopState)
				{
					aTNConfig = config;
					break;
				}
			}
			if (aTNConfig != null)
			{
				dFAState.isAcceptState = true;
				dFAState.lexerActionExecutor = ((LexerATNConfig)aTNConfig).getLexerActionExecutor();
				dFAState.prediction = atn.ruleToTokenType[aTNConfig.state.ruleIndex];
			}
			DFA dFA = decisionToDFA[mode];
			lock (dFA.states)
			{
				if (dFA.states.TryGetValue(dFAState, out var value))
				{
					return value;
				}
				DFAState dFAState2 = dFAState;
				dFAState2.stateNumber = dFA.states.Count;
				configSet.IsReadOnly = true;
				dFAState2.configSet = configSet;
				dFA.states[dFAState2] = dFAState2;
				return dFAState2;
			}
		}

		public DFA GetDFA(int mode)
		{
			return decisionToDFA[mode];
		}

		public string GetText(ICharStream input)
		{
			return input.GetText(Interval.Of(startIndex, input.Index - 1));
		}

		public void Consume(ICharStream input)
		{
			if (input.LA(1) == 10)
			{
				thisLine++;
				charPositionInLine = 0;
			}
			else
			{
				charPositionInLine++;
			}
			input.Consume();
		}

		public string GetTokenName(int t)
		{
			if (t == -1)
			{
				return "EOF";
			}
			return "'" + (char)t + "'";
		}
	}
}
