using System;
using System.Collections.Generic;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Dfa
{
	public class DFA
	{
		public Dictionary<DFAState, DFAState> states = new Dictionary<DFAState, DFAState>();

		public DFAState s0;

		public int decision;

		public DecisionState atnStartState;

		private bool precedenceDfa;

		public bool IsPrecedenceDfa => precedenceDfa;

		public DFA(DecisionState atnStartState)
			: this(atnStartState, 0)
		{
		}

		public DFA(DecisionState atnStartState, int decision)
		{
			this.atnStartState = atnStartState;
			this.decision = decision;
			precedenceDfa = false;
			if (atnStartState is StarLoopEntryState && ((StarLoopEntryState)atnStartState).isPrecedenceDecision)
			{
				precedenceDfa = true;
				s0 = new DFAState(new ATNConfigSet())
				{
					edges = new DFAState[0],
					isAcceptState = false,
					requiresFullContext = false
				};
			}
		}

		public DFAState GetPrecedenceStartState(int precedence)
		{
			if (!IsPrecedenceDfa)
			{
				throw new Exception("Only precedence DFAs may contain a precedence start state.");
			}
			if (precedence < 0 || precedence >= s0.edges.Length)
			{
				return null;
			}
			return s0.edges[precedence];
		}

		public void SetPrecedenceStartState(int precedence, DFAState startState)
		{
			if (!IsPrecedenceDfa)
			{
				throw new Exception("Only precedence DFAs may contain a precedence start state.");
			}
			if (precedence < 0)
			{
				return;
			}
			lock (s0)
			{
				if (precedence >= s0.edges.Length)
				{
					s0.edges = Arrays.CopyOf(s0.edges, precedence + 1);
				}
				s0.edges[precedence] = startState;
			}
		}

		public List<DFAState> GetStates()
		{
			List<DFAState> list = new List<DFAState>(states.Keys);
			list.Sort((DFAState x, DFAState y) => x.stateNumber - y.stateNumber);
			return list;
		}

		public override string ToString()
		{
			return ToString(Vocabulary.EmptyVocabulary);
		}

		public string ToString(IVocabulary vocabulary)
		{
			if (s0 == null)
			{
				return "";
			}
			return new DFASerializer(this, vocabulary).ToString();
		}

		public string ToLexerString()
		{
			if (s0 == null)
			{
				return "";
			}
			return new LexerDFASerializer(this).ToString();
		}
	}
}
