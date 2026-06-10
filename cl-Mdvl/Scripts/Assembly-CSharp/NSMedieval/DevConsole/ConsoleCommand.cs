using System.Linq;
using System.Reflection;

namespace NSMedieval.DevConsole
{
	public abstract class ConsoleCommand
	{
		private MethodInfo[] commandMethods;

		public abstract string Command { get; protected set; }

		public abstract string Description { get; protected set; }

		public abstract string Help { get; protected set; }

		public virtual string Argument { get; protected set; }

		public MethodInfo[] GetCommandMethod()
		{
			if (commandMethods != null)
			{
				return commandMethods;
			}
			commandMethods = (from m in GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where m.Name == "CommandMethod"
				select m).ToArray();
			if (commandMethods.Length == 0)
			{
				commandMethods = (from m in GetType().BaseType?.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					where m.Name == "CommandMethod"
					select m).ToArray();
			}
			if (commandMethods != null)
			{
				return commandMethods;
			}
			return null;
		}
	}
}
