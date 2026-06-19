using System.Collections.Generic;

namespace SickDev.CommandSystem
{
	internal class Config
	{
		private List<string> _assembliesWithCommands = new List<string> { "CommandSystem.dll" };

		public string[] assembliesWithCommands => _assembliesWithCommands.ToArray();

		public void AddAssemblyWithCommands(string assembly)
		{
			_assembliesWithCommands.Add(assembly);
		}
	}
}
