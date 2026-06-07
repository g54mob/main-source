using System;

namespace DV.ShaderStripping
{
	[Serializable]
	public struct VariantInfo
	{
		public string[] keywords;

		public VariantInfo(string[] keywords)
		{
			this.keywords = keywords;
		}
	}
}
