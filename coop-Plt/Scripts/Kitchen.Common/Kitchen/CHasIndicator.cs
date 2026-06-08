using Unity.Entities;

namespace Kitchen
{
	public struct CHasIndicator : IComponentData
	{
		public Entity Indicator;

		public ViewType IndicatorType;
	}
}
