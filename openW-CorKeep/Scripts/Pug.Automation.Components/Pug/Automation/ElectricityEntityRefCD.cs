using Unity.Entities;

namespace Pug.Automation
{
	public struct ElectricityEntityRefCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		public Entity Value;
	}
}
