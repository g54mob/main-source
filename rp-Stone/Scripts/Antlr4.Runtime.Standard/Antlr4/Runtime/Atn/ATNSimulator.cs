using System;
using Antlr4.Runtime.Dfa;

namespace Antlr4.Runtime.Atn
{
	public abstract class ATNSimulator
	{
		public static readonly DFAState ERROR = InitERROR();

		public readonly ATN atn;

		protected readonly PredictionContextCache sharedContextCache;

		private static DFAState InitERROR()
		{
			return new DFAState(new ATNConfigSet())
			{
				stateNumber = int.MaxValue
			};
		}

		public ATNSimulator(ATN atn, PredictionContextCache sharedContextCache)
		{
			this.atn = atn;
			this.sharedContextCache = sharedContextCache;
		}

		public abstract void Reset();

		public virtual void ClearDFA()
		{
			throw new Exception("This ATN simulator does not support clearing the DFA.");
		}

		protected void ConsoleWriteLine(string format, params object[] arg)
		{
			Console.WriteLine(format, arg);
		}

		public PredictionContextCache getSharedContextCache()
		{
			return sharedContextCache;
		}

		public PredictionContext getCachedContext(PredictionContext context)
		{
			if (sharedContextCache == null)
			{
				return context;
			}
			lock (sharedContextCache)
			{
				PredictionContext.IdentityHashMap visited = new PredictionContext.IdentityHashMap();
				return PredictionContext.GetCachedContext(context, sharedContextCache, visited);
			}
		}
	}
}
