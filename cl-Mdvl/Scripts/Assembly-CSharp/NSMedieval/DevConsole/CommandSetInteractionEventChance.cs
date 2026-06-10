using System.Globalization;
using NSEipix.Base;
using Social;

namespace NSMedieval.DevConsole
{
	public class CommandSetInteractionEventChance : ConsoleCommand
	{
		private float value;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument
		{
			get
			{
				if (!(value > 0f))
				{
					return "default";
				}
				return value.ToString(CultureInfo.InvariantCulture);
			}
		}

		public CommandSetInteractionEventChance()
		{
			Command = "setInteractionEventChance";
			Description = "Set interaction event chance";
			Help = "Usage: setInteractionEventChance <chance 0-1>";
		}

		private void CommandMethod(float value)
		{
			this.value = value;
			EventInteractionData.SetDevChanceToFire(value);
			string result = "Interaction event chance set to " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}
	}
}
