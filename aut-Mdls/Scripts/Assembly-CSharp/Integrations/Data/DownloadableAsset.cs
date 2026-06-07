using System;

namespace Integrations.Data
{
	[Serializable]
	public class DownloadableAsset
	{
		public string Url;

		public string Location;

		public bool Available;

		public bool Complete;
	}
}
