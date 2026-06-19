using UnityConsole;

namespace TH20
{
	public class DebugVar<T> : DebugVarBase
	{
		public T Value { get; set; }

		protected DebugVar(T initialValue)
		{
			Value = initialValue;
			DebugVarBase.AllVars.Add(this);
		}

		public override ConsoleCommandResult SetValue(string[] args)
		{
			return ConsoleCommandResult.Failed();
		}
	}
}
