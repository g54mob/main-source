using System.Collections.Generic;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public class DOVisualActionPlugin : IPlugin
	{
		public readonly PlugDataAction[] pluginDatas;

		private readonly Dictionary<string, PlugDataAction> _guidToPlugData;

		public int totPluginDatas { get; }

		public IPluginData[] editor_iPluginDatas => null;

		public DOVisualActionPlugin(PlugDataAction[] pluginDatas)
		{
		}

		public PlugDataAction GetPlugData(DOTweenClipElement clipElement)
		{
			return null;
		}

		public PlugDataAction GetPlugData(string plugDataGuid, int plugDataIndex)
		{
			return null;
		}

		public bool HasPlugData(DOTweenClipElement clipElement)
		{
			return false;
		}
	}
}
