using System;

namespace TinyGiantStudio.Modules
{
	[Serializable]
	public class ModuleContainer
	{
		public Module module;

		public VariableHolder[] variableHolders;

		public void UpdateVariableHolders()
		{
		}
	}
}
