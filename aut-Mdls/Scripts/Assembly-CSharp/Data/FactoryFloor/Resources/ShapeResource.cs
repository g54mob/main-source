using Data.Shapes;

namespace Data.FactoryFloor.Resources
{
	public class ShapeResource : Resource
	{
		private const float CUSTOM_SCALE = 5f / 6f;

		public ShapeData ShapeData { get; }

		public ShapeResource(ResourceDataSO resourceData, ShapeData shapeData)
			: base(resourceData)
		{
			base.TargetScale = 5f / 6f;
			ShapeData = shapeData;
		}

		public ShapeResource GetCopy()
		{
			return new ShapeResource(base.Data, ShapeData);
		}
	}
}
