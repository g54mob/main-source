using System;
using System.Collections.Generic;
using System.Linq;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Core;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteGradientMapFromPaintColor : MonoBehaviour, IGraphicalObject, IGraphicalSpawn, IGraphicalDespawn
{
	[Serializable]
	public struct Reskins
	{
		public SpriteObject sprite;

		[Tooltip("Gradient map to use for each paint color. If null, the sprite's default skin is used.")]
		[ArrayElementTitle("PaintableColorsWithUnpainted")]
		[FormerlySerializedAs("gradientMaps")]
		public List<DataBlockRef<GradientMapDataBlock>> gradientMapRefs;

		public List<GradientMapDataBlock> gradientMaps => gradientMapRefs?.Select((DataBlockRef<GradientMapDataBlock> s) => s.Get()).ToList();
	}

	[Serializable]
	public struct LightColors
	{
		public Light lightSource;

		public SpriteObject lightEmitter;

		[Tooltip("Gradient map to use for each paint color. If null, the sprite's default skin is used.")]
		[ArrayElementTitle("PaintableColorsWithUnpainted")]
		[ColorUsage(true, true)]
		public List<Color> colors;
	}

	public List<Reskins> sprites = new List<Reskins>();

	public List<LightColors> lights = new List<LightColors>();

	private PaintableColor _previousColor;

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (!entityManager.HasComponent<PaintableObjectCD>(entity))
		{
			Debug.LogError($"{base.name} has {typeof(SpriteGradientMapFromPaintColor)}, but the entity has no {typeof(PaintableObjectCD)}");
		}
		else
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
		foreach (Reskins sprite in sprites)
		{
			sprite.sprite.primaryGradientMapRef = ((color == PaintableColor.Unpainted) ? null : sprite.gradientMaps[(int)color]);
			sprite.sprite.ApplyVisualChange();
		}
		foreach (LightColors light in lights)
		{
			Color color2 = ((color == PaintableColor.Unpainted) ? light.colors[0] : light.colors[(int)color]);
			if (light.lightEmitter != null)
			{
				light.lightEmitter.emissiveColor = color2;
				light.lightEmitter.ApplyVisualChange();
			}
			if (light.lightSource != null)
			{
				light.lightSource.color = color2;
			}
		}
		_previousColor = color;
	}

	private void OnValidate()
	{
		foreach (Reskins sprite in sprites)
		{
			List<GradientMapDataBlock> gradientMaps = sprite.gradientMaps;
			object elementToFillOutWith;
			if (sprite.gradientMaps.Count <= 0)
			{
				elementToFillOutWith = null;
			}
			else
			{
				List<GradientMapDataBlock> gradientMaps2 = sprite.gradientMaps;
				elementToFillOutWith = gradientMaps2[gradientMaps2.Count - 1];
			}
			gradientMaps.Resize((GradientMapDataBlock)elementToFillOutWith, 15);
		}
		foreach (LightColors light in lights)
		{
			List<Color> colors = light.colors;
			Color elementToFillOutWith2;
			if (light.colors.Count <= 0)
			{
				elementToFillOutWith2 = default(Color);
			}
			else
			{
				List<Color> colors2 = light.colors;
				elementToFillOutWith2 = colors2[colors2.Count - 1];
			}
			colors.Resize(elementToFillOutWith2, 15);
		}
	}
}
