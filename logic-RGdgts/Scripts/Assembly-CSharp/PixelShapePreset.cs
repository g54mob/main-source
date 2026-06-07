using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PixelShapePreset
{
	public Vector2 position;

	public PixelShape.Shape shape;

	public PixelShapePreset()
	{
	}

	public PixelShapePreset(List<PixelShapePreset> presets)
	{
	}

	public void Apply(PixelShape pixelShape, Transform rootTransform = null)
	{
	}

	public void Cut(RectInt rect)
	{
	}
}
