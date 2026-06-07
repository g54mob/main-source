using UnityEngine;

namespace TinyGiantStudio.Modules
{
	[HelpURL("https://app.gitbook.com/@ferdowsur/s/modular-3d-text/scripts/modules")]
	public abstract class ModuleCore : ScriptableObject
	{
		[HideInInspector]
		public VariableHolder[] variableHolders;

		public abstract string VariableWarnings(VariableHolder[] variableHolders);

		public string AddWarning(string toAdd, string original)
		{
			return null;
		}
	}
}
