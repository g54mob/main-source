namespace DG.Tweening.Timeline.Core.Plugins
{
	public interface IPlugin
	{
		IPluginData[] editor_iPluginDatas { get; }

		int totPluginDatas { get; }
	}
}
