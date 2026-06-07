using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.Shapes;
using Logic.Shapes;
using UnityEngine.Pool;

namespace Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs
{
	public class AssemblerOutputCache : OutputCache
	{
		private readonly List<(List<AssemblerBehaviour.ConfiguredAssemblerShape> inputShapes, ShapeData outputShape)> _cachedOutputs = new List<(List<AssemblerBehaviour.ConfiguredAssemblerShape>, ShapeData)>(9);

		public AssemblerOutputCache(ShapesDatabase shapesDatabase)
			: base(shapesDatabase)
		{
		}

		public ShapeData GetOrCreateAssemblerOutput(List<AssemblerBehaviour.ConfiguredAssemblerShape> inputShapes)
		{
			foreach (var cachedOutput in _cachedOutputs)
			{
				bool flag = true;
				for (int i = 0; i < cachedOutput.inputShapes.Count; i++)
				{
					if (inputShapes[i] != cachedOutput.inputShapes[i] && (inputShapes[i] == null || cachedOutput.inputShapes[i] == null || !(cachedOutput.inputShapes[i].Data == inputShapes[i].Data)))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return cachedOutput.outputShape;
				}
			}
			List<Shape> list = CollectionPool<List<Shape>, Shape>.Get();
			for (int j = 0; j < inputShapes.Count; j++)
			{
				AssemblerBehaviour.ConfiguredAssemblerShape configuredAssemblerShape = inputShapes[j];
				if (configuredAssemblerShape != null)
				{
					Shape shape = Shape.Create(configuredAssemblerShape.Data);
					shape.Rotate(configuredAssemblerShape.Rotation);
					shape.Position = configuredAssemblerShape.Position;
					list.Add(shape);
				}
			}
			Shape shape2 = list[0].Combine(list);
			CollectionPool<List<Shape>, Shape>.Release(list);
			ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(shape2);
			_cachedOutputs.Add((inputShapes, orCreateShapeData));
			TrimCache();
			return orCreateShapeData;
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
