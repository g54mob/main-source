namespace MoonSharp.Interpreter.REPL
{
	public class ReplHistoryInterpreter : ReplInterpreter
	{
		private string[] m_History;

		private int m_Last;

		private int m_Navi;

		public ReplHistoryInterpreter(Script script, int historySize)
			: base(null)
		{
		}

		public override DynValue Evaluate(string input)
		{
			return null;
		}

		public string HistoryPrev()
		{
			return null;
		}

		public string HistoryNext()
		{
			return null;
		}
	}
}
