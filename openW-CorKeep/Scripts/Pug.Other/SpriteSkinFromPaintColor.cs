using System;
using System.Collections.Generic;
using System.Linq;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Core;
using Unity.Entities;
using UnityEngine;

public class SpriteSkinFromPaintColor : MonoBehaviour, IGraphicalObject, IGraphicalSpawn, IGraphicalDespawn
{
	[Serializable]
	public struct Reskins
	{
		public SpriteObject sprite;

		[Tooltip("If the skin is assigned externally, this prevents the script from clearing it when the object is unpainted.")]
		public bool dontNullifyIfUnpainted;

		[Tooltip("Skin to use for each paint color. If null, the sprite's default skin is used, unless dontNullifyIfUnpainted is true.")]
		[ArrayElementTitle("PaintableColorsWithUnpainted")]
		public List<DataBlockRef<SpriteAssetSkin>> skinsRefs;

		public List<SpriteAssetSkin> skins => skinsRefs?.Select((DataBlockRef<SpriteAssetSkin> s) => s.Get()).ToList();
	}

	public List<Reskins> spritesToReskin = new List<Reskins>();

	private PaintableColor _previousColor;

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (entityManager.HasComponent<PaintableObjectCD>(entity))
		{
			UpdatePaint(entityManager.GetComponentData<PaintableObjectCD>(entity).color);
		}
	}

	public void Despawn(Entity entity, EntityManager entityManager)
	{
	}

	public void GraphicalUpdate(Entity entity, EntityManager entityManager, TimeData timeData)
	{
		if (entityManager.HasComponent<PaintableObjectCD>(entity))
		{
			PaintableColor color = entityManager.GetComponentData<PaintableObjectCD>(entity).color;
			if (color != _previousColor)
			{
				UpdatePaint(color);
			}
		}
	}

	private void UpdatePaint(PaintableColor color)
	{
		foreach (Reskins item in spritesToReskin)
		{
			if (color == PaintableColor.Unpainted)
			{
				if (item.dontNullifyIfUnpainted)
				{
					continue;
				}
				item.sprite.skinRef = null;
			}
			else
			{
				item.sprite.skinRef = item.skins[(int)color];
			}
			item.sprite.ApplyVisualChange();
		}
		_previousColor = color;
	}

	private void OnValidate()
	{
		foreach (Reskins item in spritesToReskin)
		{
			List<SpriteAssetSkin> skins = item.skins;
			object elementToFillOutWith;
			if (item.skins.Count <= 0)
			{
				elementToFillOutWith = null;
			}
			else
			{
				List<SpriteAssetSkin> skins2 = item.skins;
				elementToFillOutWith = skins2[skins2.Count - 1];
			}
			skins.Resize((SpriteAssetSkin)elementToFillOutWith, 15);
		}
	}
}
