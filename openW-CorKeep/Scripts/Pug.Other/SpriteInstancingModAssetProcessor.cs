using System;
using System.Collections.Generic;
using Pug.Sprite;
using PugMod;
using UnityEngine;

public static class SpriteInstancingModAssetProcessor
{
	private static List<SpriteAssetBase> _spriteAssets = new List<SpriteAssetBase>();

	private static List<GradientMapDataBlock> _gradientMaps = new List<GradientMapDataBlock>();

	private static List<TransformAnimation> _transformAnimations = new List<TransformAnimation>();

	private static List<SpriteAssetManifest> _assetManifests = new List<SpriteAssetManifest>();

	public static void Init()
	{
		Integration.Instance.AssetProcessor += delegate(object asset)
		{
			if (asset is SpriteAssetBase item)
			{
				_spriteAssets.Add(item);
			}
			else if (asset is GradientMapDataBlock item2)
			{
				_gradientMaps.Add(item2);
			}
			else if (asset is TransformAnimation item3)
			{
				_transformAnimations.Add(item3);
			}
			else if (asset is SpriteAssetManifest item4)
			{
				_assetManifests.Add(item4);
			}
			if (asset is GameObject gameObject)
			{
				MaterialSwapTable materialSwapTable = Resources.Load<MaterialSwapTable>("ModSDK/MaterialSwapTable");
				if (!(materialSwapTable == null))
				{
					Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(SpriteObject), includeInactive: true);
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						SpriteObject spriteObject = componentsInChildren[i] as SpriteObject;
						if (!(spriteObject.material == null))
						{
							string name = spriteObject.material.name;
							foreach (MaterialSwapTable.SwapEntry material in materialSwapTable.materials)
							{
								if (material.materialName.Equals(name, StringComparison.OrdinalIgnoreCase))
								{
									Debug.Log("material in " + spriteObject.name + " replaced with " + material.materialToSwapTo.name);
									spriteObject.material = material.materialToSwapTo;
									break;
								}
							}
						}
					}
				}
			}
		};
	}

	public static void Done()
	{
		for (int num = _gradientMaps.Count - 1; num >= 0; num--)
		{
			GradientMapDataBlock gradientMapDataBlock = _gradientMaps[num];
			bool flag = false;
			foreach (SpriteAssetManifest assetManifest in _assetManifests)
			{
				if (assetManifest.gradientMaps.Contains(gradientMapDataBlock.texture))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				_gradientMaps.RemoveAt(num);
			}
		}
		SpriteAssetManager.AddAdditionalAssets(_spriteAssets, _gradientMaps, _transformAnimations);
	}
}
