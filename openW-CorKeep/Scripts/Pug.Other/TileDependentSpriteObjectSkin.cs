using System;
using System.Collections.Generic;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class TileDependentSpriteObjectSkin : MonoBehaviour, IGraphicalSpawn
{
	[Serializable]
	public class TileAndObject
	{
		public Tileset tileset;

		public List<DataBlockRef<SpriteAssetSkin>> spriteSkins;
	}

	public List<SpriteObject> spriteObjects;

	public TileType tileType;

	[ArrayElementTitle("tileset")]
	public List<TileAndObject> variations;

	private int _querySystemTypeIndex;

	private void Awake()
	{
		_querySystemTypeIndex = TypeManager.GetSystemTypeIndex<PugQuerySystem>();
	}

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		PugQuerySystem systemBase = (PugQuerySystem)entityManager.World.GetExistingSystemManaged(_querySystemTypeIndex);
		TileAccessor tileAccessor = new TileAccessor(systemBase);
		int2 worldPosition = entityManager.GetComponentData<LocalTransform>(entity).Position.RoundToInt2();
		if (!tileAccessor.GetType(worldPosition, tileType, out var tileCD))
		{
			return;
		}
		foreach (TileAndObject variation in variations)
		{
			if (variation.tileset == (Tileset)tileCD.tileset)
			{
				for (int i = 0; i < spriteObjects.Count; i++)
				{
					SpriteObject spriteObject = spriteObjects[i];
					spriteObject.skinRef = variation.spriteSkins[i];
					spriteObject.ApplyVisualChange();
				}
			}
		}
	}

	public void OnValidate()
	{
		foreach (TileAndObject variation in variations)
		{
			if (variation.spriteSkins.Count != spriteObjects.Count)
			{
				DataBlockRef<SpriteAssetSkin> dataBlockRef;
				if (variation.spriteSkins.Count != 0)
				{
					List<DataBlockRef<SpriteAssetSkin>> spriteSkins = variation.spriteSkins;
					dataBlockRef = spriteSkins[spriteSkins.Count - 1];
				}
				else
				{
					dataBlockRef = null;
				}
				DataBlockRef<SpriteAssetSkin> elementToFillOutWith = dataBlockRef;
				variation.spriteSkins.Resize(elementToFillOutWith, spriteObjects.Count);
			}
		}
	}
}
