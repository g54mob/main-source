using System.Collections.Generic;
using Data.Shapes;
using Logic.Shapes;

namespace Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs
{
	public class CutterOutputCache : OutputCache
	{
		private readonly List<(ShapeData inputShape, ShapeData[] outputShapes, ShapeData rotatedInputShape)> _cachedOutputs = new List<(ShapeData, ShapeData[], ShapeData)>();

		private readonly List<int> _cuts;

		private readonly ShapeData _configShape;

		private readonly ShapeData _rotatedConfigShape;

		public CutterOutputCache(ShapesDatabase shapesDatabase, List<int> cuts, ShapeData configShape, ShapeData rotatedConfigShape)
			: base(shapesDatabase)
		{
			_configShape = configShape;
			_rotatedConfigShape = rotatedConfigShape;
			_cuts = cuts;
		}

		public ShapeData[] GetOrCreateCutterOutputs(ShapeData inputShapeData, Shape shapeToCut, out ShapeData rotatedInputShapeData)
		{
			foreach (var cachedOutput in _cachedOutputs)
			{
				if (!(cachedOutput.inputShape != inputShapeData))
				{
					rotatedInputShapeData = cachedOutput.rotatedInputShape;
					return cachedOutput.outputShapes;
				}
			}
			rotatedInputShapeData = _shapesDatabase.GetOrCreateShapeData(GetInputShapeInConfigRotation(inputShapeData, _configShape));
			shapeToCut.RotateToDesiredShapeRotation(_rotatedConfigShape);
			Shape[] array = shapeToCut.CutInterval(_cuts);
			ShapeData[] array2 = new ShapeData[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = _shapesDatabase.GetOrCreateShapeData(array[array.Length - 1 - i]);
			}
			_cachedOutputs.Add((inputShapeData, array2, rotatedInputShapeData));
			TrimCache();
			return array2;
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
