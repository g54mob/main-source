using Antlr4.Runtime.Dfa;

namespace Antlr4.Runtime.Atn
{
	public class SimState
	{
		public int index = -1;

		public int line;

		public int charPos = -1;

		public DFAState dfaState;

		public void Reset()
		{
			index = -1;
			line = 0;
			charPos = -1;
			dfaState = null;
		}
	}
}
