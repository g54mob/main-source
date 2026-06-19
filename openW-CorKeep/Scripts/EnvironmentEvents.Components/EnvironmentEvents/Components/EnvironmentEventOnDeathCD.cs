using Unity.Entities;

namespace EnvironmentEvents.Components
{
	public struct EnvironmentEventOnDeathCD : IComponentData, IQueryTypeParameter
	{
		public EnvironmentEventType environmentEvent;
	}
}
