#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.Shapes;
using Logic.Shapes;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

namespace Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs
{
	public class StamperMK2OutputCache : OutputCache
	{
		private readonly List<(ShapeData inputShape, ShapeData[] outputShapes, ShapeData rotatedInputShape)> _cachedOutputs = new List<(ShapeData, ShapeData[], ShapeData)>();

		private readonly Shape _configShape = Shape.CreateEmptyShape(Vector3.zero, Vector3Int.zero, Color.black);

		private readonly Shape _stampShape = Shape.CreateEmptyShape(Vector3.zero, Vector3Int.zero, Color.black);

		public StamperMK2OutputCache(ShapesDatabase shapesDatabase, Shape stampShape, Shape configShape)
			: base(shapesDatabase)
		{
			_stampShape.CopyData(stampShape);
			_configShape.CopyData(configShape);
		}

		public ShapeData[] GetOrCreateStamperOutputs(ShapeData inputShapeData, out ShapeData rotatedInputShapeData)
		{
			foreach (var cachedOutput in _cachedOutputs)
			{
				if (!(cachedOutput.inputShape != inputShapeData))
				{
					rotatedInputShapeData = cachedOutput.rotatedInputShape;
					return cachedOutput.outputShapes;
				}
			}
			Shape inputShapeInConfigRotation = GetInputShapeInConfigRotation(inputShapeData, _shapesDatabase.GetOrCreateShapeData(_configShape));
			Shape inputShapeInConfigRotation2 = GetInputShapeInConfigRotation(inputShapeData, _shapesDatabase.GetOrCreateShapeData(_configShape));
			inputShapeInConfigRotation2.TrimBounds = false;
			inputShapeInConfigRotation2.Regenerate();
			rotatedInputShapeData = _shapesDatabase.GetOrCreateShapeData(inputShapeInConfigRotation2);
			Shape shape = Shape.CreateEmptyShape(Vector3.zero, Vector3Int.zero, Color.black);
			shape.CopyData(_stampShape);
			Voxel[,,] voxels = shape.Voxels;
			List<Voxel> list = new List<Voxel>();
			for (int i = 0; i < voxels.GetLength(0); i++)
			{
				for (int j = 0; j < voxels.GetLength(1); j++)
				{
					for (int k = 0; k < voxels.GetLength(2); k++)
					{
						if (!inputShapeInConfigRotation.TryGetVoxel(new Vector3Int(i, j, k), out var voxel))
						{
							this.DevException("New input shape has different bounds from the configured shape, this should never happen", "GetOrCreateStamperOutputs", 54);
							continue;
						}
						voxels[i, j, k].Color = voxel.Color;
						if (voxels[i, j, k].IsOccupied)
						{
							list.Add(voxels[i, j, k]);
						}
					}
				}
			}
			shape.SetOccupiedVoxels(list);
			shape.SetVoxels(voxels, calculateHash: true, calculateBounds: false);
			Shape shape2 = Shape.CreateEmptyShape(Vector3.zero, Vector3Int.zero, Color.black);
			shape2.CopyData(inputShapeInConfigRotation.Subtract(shape, calculateHash: true, calculateBounds: true, trimBounds: false));
			shape2.TrimBounds = true;
			shape.TrimBounds = true;
			shape2.Regenerate();
			shape.Regenerate();
			List<ShapeData> list2 = CollectionPool<List<ShapeData>, ShapeData>.Get();
			list2.Add(_shapesDatabase.GetOrCreateShapeData(shape2));
			list2.Add(_shapesDatabase.GetOrCreateShapeData(shape));
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				ShapeData shapeData = list2[num];
				if (shapeData.IsEmpty())
				{
					list2.Remove(shapeData);
				}
			}
			ShapeData[] array = list2.ToArray();
			CollectionPool<List<ShapeData>, ShapeData>.Release(list2);
			_cachedOutputs.Add((inputShapeData, array, rotatedInputShapeData));
			TrimCache();
			return array;
		}

		protected override void TrimCache()
		{
			if (_cachedOutputs.Count > 8)
			{
				_cachedOutputs.RemoveAt(0);
			}
		}
	}
}
