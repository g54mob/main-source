using System.Collections.Generic;

namespace TH20.ExtContent
{
	public class ExtContentBundleInfo
	{
		public string _bundleName;

		public string _bundlePublishedFileId;

		public List<GameItemBase> _bunldeGameItems = new List<GameItemBase>();

		public ExtContentBundleInfo(string bundleName, string bundlePublishedFileId)
		{
			_bundleName = bundleName;
			_bundlePublishedFileId = bundlePublishedFileId;
		}
	}
}
