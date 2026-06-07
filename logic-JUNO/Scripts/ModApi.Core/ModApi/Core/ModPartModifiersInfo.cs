using System.Collections.Generic;

namespace ModApi.Core
{
	public class ModPartModifiersInfo
	{
		public string AssemblyName { get; private set; }

		public IReadOnlyList<string> PartModifierTypes { get; private set; }

		public ModPartModifiersInfo(string assemblyName, IEnumerable<string> typeNames)
		{
			AssemblyName = assemblyName;
			PartModifierTypes = new List<string>(typeNames);
		}
	}
}
