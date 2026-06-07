using System;

namespace GreenbackIntegration
{
	[Serializable]
	public class LoadShareCodeResult
	{
		public string ShareCodeUrl { get; set; }

		public ShareCodeType ShareCodeType { get; set; }

		public string ShareCodeAuthorHash { get; set; }

		public string ShareCodeAuthorName { get; set; }
	}
}
