using System.Collections.Generic;
using Antlr4.Runtime.Dfa;

namespace Antlr4.Runtime.Atn
{
	public class ParseInfo
	{
		protected readonly ProfilingATNSimulator atnSimulator;

		public ParseInfo(ProfilingATNSimulator atnSimulator)
		{
			this.atnSimulator = atnSimulator;
		}

		public DecisionInfo[] getDecisionInfo()
		{
			return atnSimulator.getDecisionInfo();
		}

		public List<int> getLLDecisions()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			List<int> list = new List<int>();
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				if (decisionInfo[i].LL_Fallback > 0)
				{
					list.Add(i);
				}
			}
			return list;
		}

		public long getTotalTimeInPrediction()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			long num = 0L;
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				num += decisionInfo[i].timeInPrediction;
			}
			return num;
		}

		public long getTotalSLLLookaheadOps()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			long num = 0L;
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				num += decisionInfo[i].SLL_TotalLook;
			}
			return num;
		}

		public long getTotalLLLookaheadOps()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			long num = 0L;
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				num += decisionInfo[i].LL_TotalLook;
			}
			return num;
		}

		public long getTotalSLLATNLookaheadOps()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			long num = 0L;
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				num += decisionInfo[i].SLL_ATNTransitions;
			}
			return num;
		}

		public long getTotalLLATNLookaheadOps()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			long num = 0L;
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				num += decisionInfo[i].LL_ATNTransitions;
			}
			return num;
		}

		public long getTotalATNLookaheadOps()
		{
			DecisionInfo[] decisionInfo = atnSimulator.getDecisionInfo();
			long num = 0L;
			for (int i = 0; i < decisionInfo.Length; i++)
			{
				num += decisionInfo[i].SLL_ATNTransitions;
				num += decisionInfo[i].LL_ATNTransitions;
			}
			return num;
		}

		public int getDFASize()
		{
			int num = 0;
			DFA[] decisionToDFA = atnSimulator.decisionToDFA;
			for (int i = 0; i < decisionToDFA.Length; i++)
			{
				num += getDFASize(i);
			}
			return num;
		}

		public int getDFASize(int decision)
		{
			return atnSimulator.decisionToDFA[decision].states.Count;
		}
	}
}
