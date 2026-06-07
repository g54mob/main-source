#define ENABLE_DEBUG_EXCEPTIONS
using System;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using NaughtyAttributes;
using UnityEngine;
using Utils;

[Serializable]
public class ObjectiveTargetResource
{
	[SerializeField]
	[ShowIf("HasResourceData")]
	[AllowNesting]
	private NonShapeResourceDataSO _resourceData;

	[SerializeField]
	[ShowIf("HasShapeData")]
	[AllowNesting]
	private ShapeDataSO _shapeData;

	public ShapeDataSO ShapeData => _shapeData;

	public NonShapeResourceDataSO ResourceData => _resourceData;

	public Sprite Icon
	{
		get
		{
			if (_resourceData != null)
			{
				return _resourceData.Sprite;
			}
			if (_shapeData != null && _shapeData.Data.GridIcon != null)
			{
				return Sprite.Create(_shapeData.Data.GridIcon, new Rect(0f, 0f, _shapeData.Data.GridIcon.width, _shapeData.Data.GridIcon.height), new Vector2(0.5f, 0.5f));
			}
			return null;
		}
	}

	public bool HasResourceData => _shapeData == null;

	public bool HasShapeData => _resourceData == null;

	public int GetResourceID()
	{
		if (!HasResourceData)
		{
			this.DevException("HasResourceData is false", "GetResourceID", 47);
			return -1;
		}
		return _resourceData.ID;
	}

	public RotationIndependentHash GetRotationIndependentHash()
	{
		if (!HasShapeData)
		{
			this.DevException("HasShapeData is false", "GetRotationIndependentHash", 57);
			return default(RotationIndependentHash);
		}
		return _shapeData.Data.RotationIndependantHash;
	}
}
