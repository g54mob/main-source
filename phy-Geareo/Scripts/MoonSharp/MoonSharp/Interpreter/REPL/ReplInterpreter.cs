namespace MoonSharp.Interpreter.REPL
{
	public class ReplInterpreter
	{
		private Script m_Script;

		private string m_CurrentCommand;

		public bool HandleDynamicExprs { get; set; }

		public bool HandleClassicExprsSyntax { get; set; }

		public virtual bool HasPendingCommand => false;

		public virtual string CurrentPendingCommand => null;

		public virtual string ClassicPrompt => null;

		public ReplInterpreter(Script script)
		{
		}

		public virtual DynValue Evaluate(string input)
		{
			return null;
		}
	}
}
