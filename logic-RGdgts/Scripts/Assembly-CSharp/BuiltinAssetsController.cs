using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

public class BuiltinAssetsController : Controller
{
	[Serializable]
	public class SpriteSheetDefinition
	{
		public Texture2D texture;

		public bool rgb;

		public Vector2Int gridSize;

		public bool isFont;

		[OdinSerialize]
		public Dictionary<int, Vector2Int> gridIds;

		public string chars;

		public Vector2Int charSize;

		public Asset Instantiate(Func<AssetSelector, PaletteAsset> paletteGetter)
		{
			return null;
		}
	}

	[Serializable]
	public class PaletteDefinition
	{
		public Texture2D texture;

		public Color[] colors;

		public Asset Instantiate()
		{
			return null;
		}
	}

	public Dictionary<uint, PaletteDefinition> paletteAssetDefinitions;

	public Dictionary<uint, SpriteSheetDefinition> spriteSheetAssetDefinitions;

	[NonSerialized]
	[HideInInspector]
	public Dictionary<uint, Asset> builtinAssets;

	public override void Init()
	{
	}

	private void OnDestroy()
	{
	}
}
