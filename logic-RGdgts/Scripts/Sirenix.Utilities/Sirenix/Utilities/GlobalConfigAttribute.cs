using System;

namespace Sirenix.Utilities
{
	public class GlobalConfigAttribute : Attribute
	{
		private string assetPath;

		[Obsolete]
		public string FullPath => null;

		public string AssetPath => null;

		internal string AssetPathWithAssetsPrefix => null;

		internal string AssetPathWithoutAssetsPrefix => null;

		public string ResourcesPath => null;

		[Obsolete]
		public bool UseAsset { get; set; }

		public bool IsInResourcesFolder => false;

		public GlobalConfigAttribute()
		{
		}

		public GlobalConfigAttribute(string assetPath)
		{
		}
	}
}
