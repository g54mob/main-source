using UnityConsole;

namespace TH20
{
	public class DebugVarInt : DebugVar<int>
	{
		public DebugVarInt(int initialValue)
			: base(initialValue)
		{
		}

		public override ConsoleCommandResult SetValue(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int value)
			{
				base.Value = value;
			}, args);
		}
	}
}
