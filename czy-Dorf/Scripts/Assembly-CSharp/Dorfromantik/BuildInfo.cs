using UnityEngine;

namespace Dorfromantik
{
	public class BuildInfo : ScriptableObject
	{
		public PluginType usedPlugin;

		public int pluginBuildIndex = -1;

		public string buildNumber;

		public string branchName;
	}
}
