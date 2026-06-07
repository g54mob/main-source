using Data.Shapes;
using Logic.Shapes;

namespace Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs
{
	public abstract class OutputCache
	{
		protected ShapesDatabase _shapesDatabase;

		protected const int MAX_OUTPUTS_IN_CACHE = 8;

		protected OutputCache(ShapesDatabase shapesDatabase)
		{
			_shapesDatabase = shapesDatabase;
		}

		protected abstract void TrimCache();

		protected Shape GetInputShapeInConfigRotation(ShapeData inputShape, ShapeData configShape)
		{
			if (configShape.RotationIndependantHash.Contains(inputShape.GetShapeHash()))
			{
				return Shape.Create(configShape);
			}
			Shape shape = Shape.Create(inputShape);
			if (configShape.VoxelHash == shape.GetVoxelHash())
			{
				return shape;
			}
			shape.RotateToDesiredShapeRotation(configShape);
			return shape;
		}
	}
}
