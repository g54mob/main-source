using System;

namespace VoxelBusters.EssentialKit
{
	public class DeepLinkServicesDynamicLinkOpenResult
	{
		public Uri Url { get; private set; }

		public string RawUrlString { get; private set; }

		internal DeepLinkServicesDynamicLinkOpenResult(Uri url, string rawUrlString)
		{
		}
	}
}
