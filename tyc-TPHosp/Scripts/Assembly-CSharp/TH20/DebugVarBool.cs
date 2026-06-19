using UnityConsole;

namespace TH20
{
	public class DebugVarBool : DebugVar<bool>
	{
		public DebugVarBool(bool initialValue)
			: base(initialValue)
		{
		}

		public override ConsoleCommandResult SetValue(string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool enabled)
			{
				base.Value = enabled;
			}, args);
		}

		public ConsoleCommandResult ToggleValue(string[] args)
		{
			base.Value = !base.Value;
			return ConsoleCommandResult.Succeeded();
		}
	}
}
