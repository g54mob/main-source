using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Dfa
{
	public class DFAState
	{
		public int stateNumber = -1;

		public ATNConfigSet configSet = new ATNConfigSet();

		public DFAState[] edges;

		public bool isAcceptState;

		public int prediction;

		public LexerActionExecutor lexerActionExecutor;

		public bool requiresFullContext;

		public PredPrediction[] predicates;

		public DFAState()
		{
		}

		public DFAState(int stateNumber)
		{
			this.stateNumber = stateNumber;
		}

		public DFAState(ATNConfigSet configs)
		{
			configSet = configs;
		}

		public HashSet<int> getAltSet()
		{
			HashSet<int> hashSet = new HashSet<int>();
			if (configSet != null)
			{
				foreach (ATNConfig config in configSet.configs)
				{
					hashSet.Add(config.alt);
				}
			}
			if (hashSet.Count == 0)
			{
				return null;
			}
			return hashSet;
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Initialize(7), configSet.GetHashCode()), 1);
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (!(o is DFAState))
			{
				return false;
			}
			DFAState dFAState = (DFAState)o;
			return configSet.Equals(dFAState.configSet);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(stateNumber).Append(":").Append(configSet);
			if (isAcceptState)
			{
				stringBuilder.Append("=>");
				if (predicates != null)
				{
					stringBuilder.Append(Arrays.ToString(predicates));
				}
				else
				{
					stringBuilder.Append(prediction);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
