using System;
using TinyGiantStudio.Modules;

namespace TinyGiantStudio.Layout
{
	[Serializable]
	public class LayoutElementModuleContainer
	{
		public LayoutElementModule module;

		public VariableHolder[] variableHolders;
	}
}
