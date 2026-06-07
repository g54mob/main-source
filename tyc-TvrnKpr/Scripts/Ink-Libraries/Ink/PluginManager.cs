using System.Collections.Generic;
using Ink.Parsed;
using Ink.Runtime;

namespace Ink
{
	public class PluginManager
	{
		private List<IPlugin> _plugins;

		public PluginManager(List<string> pluginNames)
		{
		}

		public void PostParse(Ink.Parsed.Story parsedStory)
		{
		}

		public void PostExport(Ink.Parsed.Story parsedStory, Ink.Runtime.Story runtimeStory)
		{
		}
	}
}
