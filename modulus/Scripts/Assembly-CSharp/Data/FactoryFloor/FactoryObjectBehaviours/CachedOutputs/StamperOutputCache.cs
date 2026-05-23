using System.Collections.Generic;
using Data.Shapes;
using Logic.Shapes;
using UnityEngine;
using UnityEngine.Pool;

namespace Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs
{
	public class StamperOutputCache : OutputCache
	{
		private readonly List<(ShapeData inputShape, ShapeData[] outputShapes, ShapeData rotatedInputShape)> _cachedOutputs = new List<(ShapeData, ShapeData[], ShapeData)>();

		private readonly ShapeData _configShape;

		private Vector3Int _rotation;

		private Vector2Int _stampStart;

		private Vector2Int _stampEnd;

		public StamperOutputCache(ShapesDatabase shapesDatabase, Vector3Int rotation, Vector2Int stampStart, Vector2Int stampEnd, ShapeData configShape)
			: base(shapesDatabase)
		{
			_configShape = configShape;
			_rotation = rotation;
			_stampStart = stampStart;
			_stampEnd = stampEnd;
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
			Shape inputShapeInConfigRotation = GetInputShapeInConfigRotation(inputShapeData, _configShape);
			rotatedInputShapeData = _shapesDatabase.GetOrCreateShapeData(inputShapeInConfigRotation);
			inputShapeInConfigRotation.Rotate(_rotation);
			(Shape, Shape) tuple = inputShapeInConfigRotation.Stamp(new Vector3Int(_stampStart.x, 0, _stampStart.y), new Vector3Int(_stampEnd.x, inputShapeInConfigRotation.GetBounds().y, _stampEnd.y));
			List<ShapeData> list = CollectionPool<List<ShapeData>, ShapeData>.Get();
			list.Add(_shapesDatabase.GetOrCreateShapeData(tuple.Item2));
			list.Add(_shapesDatabase.GetOrCreateShapeData(tuple.Item1));
			for (int num = list.Count - 1; num >= 0; num--)
			{
				ShapeData shapeData = list[num];
				if (shapeData.IsEmpty())
				{
					list.Remove(shapeData);
				}
			}
			ShapeData[] array = list.ToArray();
			CollectionPool<List<ShapeData>, ShapeData>.Release(list);
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
