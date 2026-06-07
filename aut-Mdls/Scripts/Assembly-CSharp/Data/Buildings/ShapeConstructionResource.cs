using Data.FactoryFloor.Resources;
using Data.Shapes;

namespace Data.Buildings
{
	public class ShapeConstructionResource : BuildingConstructionResource
	{
		public ShapeData ShapeData;

		public RotationIndependentHash Hash;

		public bool IsShape(ShapeData shapeData)
		{
			return Hash == shapeData.RotationIndependantHash;
		}

		public ShapeConstructionResource(ResourceDataSO resourceData)
			: base(resourceData)
		{
		}
	}
}
