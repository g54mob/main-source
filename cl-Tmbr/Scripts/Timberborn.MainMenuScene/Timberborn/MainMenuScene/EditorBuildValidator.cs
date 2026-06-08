using System;
using Timberborn.AssetSystem;
using UnityEngine;

namespace Timberborn.MainMenuScene
{
	internal class EditorBuildValidator
	{
		private readonly IAssetLoader _assetLoader;

		public EditorBuildValidator(IAssetLoader assetLoader)
		{
			_assetLoader = assetLoader;
		}

		public void Validate()
		{
			try
			{
				if (!Application.isEditor && (bool)_assetLoader.Load<TextAsset>("EditorBuild"))
				{
					throw new ApplicationException("EditorBuild detected outside of Unity Editor.");
				}
			}
			catch (InvalidOperationException)
			{
			}
		}
	}
}
