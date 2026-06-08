using System;
using System.IO;
using UnityEngine;

namespace Timberborn.MainMenuScene
{
	internal class AssetBundleValidator
	{
		public void Validate()
		{
			if (Directory.Exists(Path.Combine(Application.streamingAssetsPath, "AssetBundles")))
			{
				throw new NotSupportedException("Loading AssetBundles from StreamingAssets is not supported.");
			}
		}
	}
}
