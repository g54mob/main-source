namespace DG.Tweening.Timeline.Core.Plugins
{
	public interface IPluginData
	{
		bool wantsTarget { get; }

		string guid { get; }

		string label { get; }

		string targetLabel { get; }

		string stringOptionLabel { get; }

		string intOptionLabel { get; }

		DOTweenClipElement.PropertyType propertyType { get; }
	}
}
