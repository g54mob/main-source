using System;

namespace MyBox
{
	[Serializable]
	public class AssetPath
	{
		public string Path;

		public string Extension;

		public static AssetPath WithExtension(string extension)
		{
			return null;
		}
	}
}
