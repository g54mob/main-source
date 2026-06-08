using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Dfa
{
	public class DFASerializer
	{
		[NotNull]
		private readonly DFA dfa;

		[NotNull]
		private readonly IVocabulary vocabulary;

		[Nullable]
		internal readonly string[] ruleNames;

		[Nullable]
		internal readonly ATN atn;

		public DFASerializer(DFA dfa, IVocabulary vocabulary)
			: this(dfa, vocabulary, null, null)
		{
		}

		public DFASerializer(DFA dfa, IRecognizer parser)
			: this(dfa, (parser != null) ? parser.Vocabulary : Vocabulary.EmptyVocabulary, parser?.RuleNames, parser?.Atn)
		{
		}

		public DFASerializer(DFA dfa, IVocabulary vocabulary, string[] ruleNames, ATN atn)
		{
			this.dfa = dfa;
			this.vocabulary = vocabulary;
			this.ruleNames = ruleNames;
			this.atn = atn;
		}

		public override string ToString()
		{
			if (dfa.s0 == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (dfa.states != null)
			{
				List<DFAState> list = new List<DFAState>(dfa.states.Values);
				list.Sort((DFAState x, DFAState y) => x.stateNumber - y.stateNumber);
				foreach (DFAState item in list)
				{
					int num = ((item.edges != null) ? item.edges.Length : 0);
					for (int num2 = 0; num2 < num; num2++)
					{
						DFAState dFAState = item.edges[num2];
						if (dFAState != null && dFAState.stateNumber != int.MaxValue)
						{
							stringBuilder.Append(GetStateString(item));
							string edgeLabel = GetEdgeLabel(num2);
							stringBuilder.Append("-");
							stringBuilder.Append(edgeLabel);
							stringBuilder.Append("->");
							stringBuilder.Append(GetStateString(dFAState));
							stringBuilder.Append('\n');
						}
					}
				}
			}
			string text = stringBuilder.ToString();
			if (text.Length == 0)
			{
				return null;
			}
			return text;
		}

		protected internal virtual string GetContextLabel(int i)
		{
			if (i == PredictionContext.EMPTY_RETURN_STATE)
			{
				return "ctx:EMPTY";
			}
			if (atn != null && i > 0 && i <= atn.states.Count)
			{
				int ruleIndex = atn.states[i].ruleIndex;
				if (ruleNames != null && ruleIndex >= 0 && ruleIndex < ruleNames.Length)
				{
					return "ctx:" + i + "(" + ruleNames[ruleIndex] + ")";
				}
			}
			return "ctx:" + i;
		}

		protected internal virtual string GetEdgeLabel(int i)
		{
			return vocabulary.GetDisplayName(i - 1);
		}

		internal virtual string GetStateString(DFAState s)
		{
			if (s == ATNSimulator.ERROR)
			{
				return "ERROR";
			}
			int stateNumber = s.stateNumber;
			string text = (s.isAcceptState ? ":" : "") + "s" + stateNumber + (s.requiresFullContext ? "^" : "");
			if (s.isAcceptState)
			{
				if (s.predicates != null)
				{
					return text + "=>" + Arrays.ToString(s.predicates);
				}
				return text + "=>" + s.prediction;
			}
			return text;
		}
	}
}
