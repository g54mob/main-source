using System.Collections.Generic;
using UnityConsole;

namespace TH20
{
	public abstract class DebugVarBase
	{
		public static List<DebugVarBase> AllVars = new List<DebugVarBase>();

		public string Name { get; set; }

		public abstract ConsoleCommandResult SetValue(string[] args);
	}
}
