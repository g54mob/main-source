using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementMediaAsset
	{
		public string Name { get; }

		public XblAchievementMediaAssetType MediaAssetType { get; }

		public string Url { get; }

		internal XblAchievementMediaAsset(XGamingRuntime.Interop.XblAchievementMediaAsset mediaAsset)
		{
			Name = mediaAsset.name.GetString();
			MediaAssetType = mediaAsset.mediaAssetType;
			Url = mediaAsset.url.GetString();
		}
	}
}
