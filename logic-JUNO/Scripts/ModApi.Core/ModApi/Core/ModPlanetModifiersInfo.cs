using System.Collections.Generic;

namespace ModApi.Core
{
	public class ModPlanetModifiersInfo
	{
		public string AssemblyName { get; private set; }

		public IReadOnlyList<string> PlanetModifierTypes { get; private set; }

		public ModPlanetModifiersInfo(string assemblyName, IEnumerable<string> typeNames)
		{
			AssemblyName = assemblyName;
			PlanetModifierTypes = new List<string>(typeNames);
		}
	}
}
